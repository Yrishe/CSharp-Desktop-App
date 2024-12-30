using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using Extract_Mc_Results.Backend;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Security.AccessControl;


namespace Extract_Mc_Results.Frontend
{
    public partial class View : Form
    {
        //Hold current date
        private string globalDate;

        //List to enable checkings and dir manipulation
        private readonly List<string> checkedBox = new List<string>();

        // Define the pre-defined paths
        private const string defaultSourcePath = @"\\Public\Mc\work\results\741"; // Change to your default source folder
        private const string defaultTargetPath = @"\\Depts\Requests\Results\741"; // Change to your default target folder

        // TEST ONLY
        //private const string defaultSourcePath = @"I:\Quality\Metrology Lab\PEOPLE\2. Engineering\Yarli\Test\test1\Results"; // Change to your default source folder
        //private const string defaultTargetPath = @"I:\Quality\Metrology Lab\PEOPLE\2. Engineering\Yarli\Test\Checking"; // Change to your default target folder


        public View()
        {
            InitializeComponent();

            //default checkBox
            for (int i = 0; i < checkedListBox2.Items.Count; i++) 
            { 
                checkedListBox2.SetItemChecked(i, true);
                //MessageBox.Show(" checkedListBox2.SetItemChecked(i, true) = " + i.ToString());
            }

            //Convert the checkedBoxItems to an array
            foreach (var item in checkedListBox2.CheckedItems)
            { 
                checkedBox.Add(item.ToString());
                //MessageBox.Show("checkedBox.Add(item.ToString()) = " + item);
            }

            sourceTxtBox.Text = defaultSourcePath;
            targetTxtBox.Text = defaultTargetPath;
        }

        //FIX CHECKBOX
        private void CheckedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("It was clicked outside the loop!"); 

            // Loop through all items in the CheckedListBox
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                string itemStr = checkedListBox2.Items[i].ToString();

                //MessageBox.Show("It was clicked inside the loop!");

                if (checkedListBox2.GetItemChecked(i)) // Check if item is checked
                {
                    if (!checkedBox.Contains(itemStr))
                    {
                        checkedBox.Add(itemStr); // Add if not present
                        //MessageBox.Show("Added: " + itemStr); // Notify about addition
                    }
                }
                else // If unchecked
                {
                    if (checkedBox.Contains(itemStr))
                    {
                        checkedBox.Remove(itemStr); // Remove if already present
                        //MessageBox.Show("Removed: " + itemStr); // Notify about removal
                    }
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //string formattedDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            dateTimePicker1.Value = DateTime.Now;
            //MessageBox.Show(formattedDate);

        }

        /*  SOURCE FOLDER BROWSER */
        private void btnSourceBrowser_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                sourceTxtBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        /*  TARGET FOLDER BROWSER */
        private void btnTargetBrowser_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                targetTxtBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        /*  SOURCE TXT FIELD */
        private void sourceTxtBox_TextChanged(object sender, EventArgs e)
        {
        }

        /*  TARGET TXT FIELD */
        private void targetTxtBox_TextChanged(object sender, EventArgs e)
        {
        }

        /*  PROGRESS BAR */
        private async void progressBar_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            int totalSteps = 100; // Total number of steps for processing

            for (int i = 0; i <= totalSteps; i++)
            {
                // Update the progress bar
                await Task.Delay(100);

                progressBar.Value = i;
                percent.Text = progressBar.Value.ToString() + "%";
            }
            progressLabel.Text = "Operations Completed!";

            await Task.Delay(100);

            MessageBox.Show("You can now close the application!");

        }

        /*  HELPER IN CASE FUNCTIONS ARE NOT TRIGGERED */
        private void do_this() 
        {
            string currentDate = DateTime.Now.ToString("yyyy.MM.dd"); //Date to be used on Macro naming
            globalDate = currentDate;

            //Check if source and target text box are empty
            if(string.IsNullOrWhiteSpace(sourceTxtBox.Text))
                sourceTxtBox.Text = defaultSourcePath;

            if (string.IsNullOrWhiteSpace(targetTxtBox.Text))
                targetTxtBox.Text = defaultTargetPath;

            //Initiate class instace and call operations function
            Operations ops = new Operations();
            ops.Organize_directories(sourceTxtBox.Text, targetTxtBox.Text, globalDate, checkedBox);
        }

        private async void runBtn_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Initiating Operations");
            //Call helper
            do_this();

            //Indicate progress bar
            progressBar_Click(sender, e);
        }
    }
}
