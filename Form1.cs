using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;


namespace Extract_Zeiss_Results
{
    public partial class ZRCompiler : Form
    {
        // Declare the text boxes as class-level variables
        private TextBox txtFileName;
        private TextBox txtTargetPath;
        private Button btnCopy;
        private DateTimePicker datePickerStart;
        private DateTimePicker datePickerEnd;
        //private TextBox txtAdditionalFilePath;
        private readonly Dictionary<CheckBox, string> checkboxes = new Dictionary<CheckBox, string>();

        // Define the pre-defined paths
        private const string predefinedSourcePath = @"\\Public\Documents\results\"; // Change to your default source folder
        private const string predefinedTargetPath = @"I:\Results_Final\"; // Change to your default target folder

        public ZRCompiler()
        {
            InitializeComponent();
            this.BackColor = Color.DarkGray;
        }

        //Front End
        private void ZRCompiler_Load(object sender, EventArgs e)
        {
            Label labelDateSelStart = new Label()
            {
                Text = "Start Date: ",
                Location = new Point(10, 40),
                Font = new Font("Arial", 11, FontStyle.Bold),
                Width = 150, //was 130
                TabIndex = 7
            };

            datePickerStart = new DateTimePicker()
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy - hh:mm tt", //Custom format with date and time
                Location = new Point(10, 70), //was 145
                Width = 150 //was 100
            };

            Label labelDateSelEnd = new Label()
            {
                Text = "End Date: ",
                Location = new Point(200, 40),
                Font = new Font("Arial", 11, FontStyle.Bold),
                Width = 150, //was 130
                TabIndex = 8
            };

            datePickerEnd = new DateTimePicker()
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy - hh:mm tt", //Custom format with date and time
                Location = new Point(200, 70), //was 145
                Width = 150 //was 100
            };


            Label labelFileName = new Label()
            {
                Text = "Source Folder:",
                Font = new Font("Arial", 11, FontStyle.Bold),
                Height = 16,
                Width = 170,
                Location = new Point(10, 110),
                TabIndex = 1 //was 0
            };

            txtFileName = new TextBox()
            {
                Location = new Point(labelFileName.Location.X, (labelFileName.Bounds.Bottom + Padding.Top)+10),
                Size = new Size(490, 20),
                Font = new Font("Arial", 11, FontStyle.Italic),
                TabIndex = 2 //was 1
            };

            Button btnBrowseSource = new Button()
            {
                Text = "Browse...",
                Font = new Font("Arial", 9, FontStyle.Regular),
                Location = new Point(txtFileName.Bounds.Right + 30, txtFileName.Location.Y),
                BackColor = Color.LightGray,
                TabIndex = 9,
                Width = 75,
                Height = 25
            };

            btnBrowseSource.Click += BtnBrowseSource_Click;

            Label labelTarget = new Label()
            {
                Text = "Target Folder:",
                Font = new Font("Arial", 11, FontStyle.Bold),
                Width = 170,
                Location = new Point(10, 170), // Adjusted for better layout
                TabIndex = 4 //was 2
            };

            txtTargetPath = new TextBox()
            {
                Location = new Point(labelTarget.Location.X, labelTarget.Bounds.Bottom + Padding.Top),
                Size = new Size(490, 20),
                Font = new Font("Arial", 11, FontStyle.Italic),
                TabIndex = 5 //was 3
            };

            Button btnBrowseTarget = new Button()
            {
                Text = "Browse...",
                Font = new Font("Arial", 9, FontStyle.Regular),
                Location = new Point(txtTargetPath.Bounds.Right + 30, txtTargetPath.Location.Y),
                BackColor = Color.LightGray,
                TabIndex = 10,
                Width = 75,
                Height = 25
            };

            btnBrowseTarget.Click += BtnBrowseTarget_Click;

            btnCopy = new Button()
            {
                Text = "Run",
                Font = new Font("Arial", 11, FontStyle.Bold),
                Location = new Point(10, txtTargetPath.Bounds.Bottom + 20),
                BackColor = Color.LightGreen,
                TabIndex = 6, //was 4
                Width = 100,
                Height = 40
            };

            // this.Controls.Add(btnOpenExplorer);
            this.Controls.Add(btnBrowseSource);
            this.Controls.Add(btnBrowseTarget);

            string[] checkboxNames = { "CHRs", "FETs", "HDRs", "PDFs", "Points", "Process Data" };
            int yPos = 40;
            int xPos = 400;
            int counter = 0;

            foreach (string name in checkboxNames)
            {
                if (counter == 3)
                {
                    xPos = 400;
                    yPos += 30;
                }
                // Create a new CheckBox
                CheckBox checkBox = new CheckBox
                {
                    Text = name,
                    AutoSize = true,
                    Location = new System.Drawing.Point(xPos, yPos),

                    /* Add a conditional to select some checkboxes*/
                    Checked = true //boxes checked by default
                };
                // Subscribe to the CheckedChanged event
                checkBox.CheckedChanged += CheckBox;
                // Add the checkbox to the form's controls
                this.Controls.Add(checkBox);
                //Map the checkbox to a folder name
                checkboxes[checkBox] = name;
                // Increment the vertical position for the next checkbox
                xPos += 60; // Adjust spacing to your preference
                counter++;
            };

            Label copyWriter = new Label()
            {
                Text = "Yarli Rabelo - (Metrology Lab)",
                Font = new Font("Arial", 11, FontStyle.Underline),
                Height = 18,
                Width = 220,
                Location = new Point(400, 260),
                TabIndex = 1 //was 0
            };

            btnCopy.Click += BtnCopy_Click; // Event handler for button click

            //this.Controls.Add(labelAdditionalFile);
            //this.Controls.Add(txtAdditionalFilePath);
            this.Controls.Add(labelDateSelStart);
            this.Controls.Add(labelDateSelEnd);
            this.Controls.Add(labelFileName);
            this.Controls.Add(txtFileName);
            this.Controls.Add(labelTarget);
            this.Controls.Add(txtTargetPath);
            this.Controls.Add(datePickerStart);
            this.Controls.Add(datePickerEnd);
            this.Controls.Add(btnCopy);
            this.Controls.Add(copyWriter);

        }

        private void BtnBrowseSource_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select Source Folder";
                folderDialog.SelectedPath = predefinedSourcePath; //set predefined source path
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFileName.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void BtnBrowseTarget_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select Target Folder";
                folderDialog.SelectedPath = predefinedTargetPath; //set predefined target path
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtTargetPath.Text = folderDialog.SelectedPath;
                }
            }
        }

        public void CreateFolder(string folderPath)
        {
            // Check if the directory already exists
            if (!Directory.Exists(folderPath))
            {
                // Create the directory
                Directory.CreateDirectory(folderPath);
                Console.WriteLine("Directory created successfully.");
            }
            else
            {
                Console.WriteLine("Directory already exists.");
            }
        }


        private void BtnCopy_Click(object sender, EventArgs e)
        {
            string sourceDir = txtFileName.Text.Trim();  // User input for source directory
            string targetDir = txtTargetPath.Text.Trim(); // User input for destination directory
            //DateTime selectedDate = datePicker.Value;    // Get the date from the DateTimePicker

            DateTime startDate = datePickerStart.Value;    // Get the start date from the DateTimePicker
            DateTime endDate = datePickerEnd.Value;    // Get the end date from the DateTimePicker


            if (string.IsNullOrEmpty(sourceDir) || string.IsNullOrEmpty(targetDir))
            {
                MessageBox.Show("Please enter both source and destination paths.");
                return;
            }

            bool stateFileCopy = false;
            // Create the 'Results' folder within the specified target directory
            string resultsDir = Path.Combine(targetDir, "Results");
            if (!Directory.Exists(resultsDir))
            {
                Directory.CreateDirectory(resultsDir);
            }

            try
            {
                foreach (var kvp in checkboxes)
                {
                    if (kvp.Key.Checked && kvp.Value != "Process Data")
                    {
                        string specificSourceDir = Path.Combine(sourceDir, kvp.Value);
                        //string specificTargetDir = Path.Combine(targetDir, kvp.Value);
                        string specificTargetDir = Path.Combine(resultsDir, kvp.Value);

                        // Ensure target directory exists
                        if (!Directory.Exists(specificTargetDir))
                        {
                            Directory.CreateDirectory(specificTargetDir);
                        }
                        var filesFromDateRange = GetFilesFromDateRange(specificSourceDir, startDate, endDate);
                        if (filesFromDateRange.Count > 0)
                        {
                            foreach (var file in filesFromDateRange)
                            {
                                string sourceFile = Path.Combine(specificSourceDir, file);
                                string destinationFile = Path.Combine(specificTargetDir, file);
                                File.Copy(sourceFile, destinationFile, true);
                                stateFileCopy = true;
                            }

                            MessageBox.Show($"{kvp.Value} files from {startDate.ToShortDateString()} to {endDate.ToShortDateString()} copied successfully.");
                        }
                        else
                        {
                            MessageBox.Show($"No files from {startDate.ToShortDateString()} to {endDate.ToShortDateString()} to copy in {kvp.Value}.");
                        }
                    }
                }
                if (stateFileCopy && checkboxes.FirstOrDefault(x => x.Value == "Process Data").Key.Checked)
                {
                    
                    Process_Data(resultsDir);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private List<string> GetFilesFromDateRange(string directory, DateTime startDate, DateTime endDate)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directory);
            if (!directoryInfo.Exists)
            {
                MessageBox.Show($"The directory {directory} does not exist.");
                return new List<string>();  // Return an empty list to avoid further processing.
            }

            // Filter files to only those that were last modified within the specified date range
            return directoryInfo.GetFiles()
                                .Where(f => f.LastWriteTime.Date >= startDate.Date && f.LastWriteTime.Date <= endDate.Date)
                                .Select(f => f.Name)
                                .ToList();
        }

        private async void Process_Data(string targetDir)
        {
            string resultsFolder = Path.Combine(targetDir, "CHRs");

            // Check if the user has provided an additional file path, otherwise use a default
            string predefinedPath = @"I:\Compiler_AutoRun.xlsm";  // Modify with actual file path
            //string additionalFilePath = string.IsNullOrEmpty(txtAdditionalFilePath.Text) ? predefinedPath : txtAdditionalFilePath.Text;

            // Ensure the results directory exists
            if (!Directory.Exists(resultsFolder))
            {
                Directory.CreateDirectory(resultsFolder);
            }

            // Define the destination path for the additional file
            string destinationPath = Path.Combine(resultsFolder, Path.GetFileName(predefinedPath));

            try
            {
                // Copy the additional file to the results directory
                File.Copy(predefinedPath, destinationPath, true);

                // Add delay to ensure the previous process is completed
                await Task.Delay(1000);

                // Open the copied Excel file and run a macro
                OpenExcelAndRunMacro(destinationPath, "CMM_Data_Compiler_Master", "Click this button"); // Replace "MacroName" with your actual macro name

                // Add delay to ensure the previous process is completed
                await Task.Delay(1000);

                MoveFileOneLevelUp(destinationPath, targetDir);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to copy additional file: {ex.Message}");
            }
        }

        private void MoveFileOneLevelUp(string sourcePath, string targetDir)
        {
            string fileName = Path.GetFileName(sourcePath);
            string newLocation = Path.Combine(targetDir, fileName);

            if (File.Exists(newLocation))
            {
                File.Delete(newLocation); // Ensure there is no conflict with existing files
            }

            File.Move(sourcePath, newLocation);
            MessageBox.Show($"File moved to {newLocation}");
        }

        public async void OpenExcelAndRunMacro(string filePath, string macroName, string buttonName)
        {
            await Task.Delay(10);
                Excel.Application excelApp = new Excel.Application();
                try
                {
                    excelApp.Visible = true; // Set the Excel application to be visible

                    // Open the Excel file
                    Excel.Workbook workbook = excelApp.Workbooks.Open(filePath);
                    Excel.Worksheet worksheet = workbook.Sheets[1];

                    // Run the macro
                    excelApp.Run(macroName);

                    // Optionally click a button if required
                    Excel.OLEObject excelButton = worksheet.OLEObjects(buttonName) as Excel.OLEObject;
                    excelButton.GetType().InvokeMember("Click", System.Reflection.BindingFlags.InvokeMethod, null, excelButton.Object, null);

                    // Save and close the workbook
                    workbook.Save();
                    workbook.Close(true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
                finally
                {
                    // Release COM objects to fully kill Excel process from running in the background
                    if (excelApp != null)
                    {
                        excelApp.Quit();
                        Marshal.ReleaseComObject(excelApp);
                    }
                }
        }

        private void CheckBox(object sender, EventArgs e)
        {
            // Event handler for checkbox state change
            //var checkBox = sender as CheckBox;
            //var checkBox = new CheckBox();
            if(sender is CheckBox)
            //if (checkBox != null)
            {
                Console.WriteLine("CheckBox::Checked");
                //MessageBox.Show($"{checkBox.Text} is {(checkBox.Checked ? "checked" : "unchecked")}.");
            }
        }

        private void CopySubdirectories(string sourceDirPath, string destDirPath)
        {
            // Get the subdirectories for the specified directory
            DirectoryInfo dir = new DirectoryInfo(sourceDirPath);
            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the destination directory doesn't exist, create it
            if (!Directory.Exists(destDirPath))
            {
                Directory.CreateDirectory(destDirPath);
            }

            // Get the files in the directory and copy them to the new location
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDirPath, file.Name);
                file.CopyTo(tempPath, true);
            }

            // If copying subdirectories, recurse into them
            foreach (DirectoryInfo subdir in dirs)
            {
                string tempPath = Path.Combine(destDirPath, subdir.Name);
                CopySubdirectories(subdir.FullName, tempPath);
            }
        }

        private void BtnOpenExplorer_Click(object sender, EventArgs e)
        {
            string targetDir = txtTargetPath.Text.Trim(); //User input for destination directory

            if (string.IsNullOrEmpty(targetDir))
            {
                Console.WriteLine("BtnOpenExplorer_Click::emptyBtn");
                MessageBox.Show("Please enter a target path.");
                return;
            }

            if (Directory.Exists(targetDir))
            {
                Process.Start("explorer.exe", targetDir);
            }
            else
            {
                MessageBox.Show("The directory {targetDir} does not exist.");
            }
        }
    }
}
