using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Extract_Mc_Results.Backend
{
    internal class Operations
    {

        /* MAIN OPERATIONS *****************************************************/
        public void Organize_directories(string source, string target, string date, List<string> checkedList)
        {
            bool stateFileCopy = false;

            //MessageBox.Show(date);

            // Create the 'Results' folder within the specified target directory
            string resultsDir = Path.Combine(target, "Results");
            if (!Directory.Exists(resultsDir))
            {
                Directory.CreateDirectory(resultsDir);
            }

            //Create backup folder within source folder
            string backupFolder = Path.Combine(source, "Backup");
            if (!Directory.Exists(backupFolder))
            {
                Directory.CreateDirectory(backupFolder);
            }

            //Create folder with current date
            string resultsThisDate = Path.Combine(resultsDir, date);
            if(!Directory.Exists(resultsThisDate))
            { 
                Directory.CreateDirectory(resultsThisDate); 
            }

            string backResultThisDate = Path.Combine(backupFolder, date);
            if(!Directory.Exists(backResultThisDate))
            {
                Directory.CreateDirectory(backResultThisDate);
            }

            try
            {
                foreach (var kvp in checkedList)
                {
                    if (kvp.ToString() != "Process Data")
                    {
                        string specificSourceDir = Path.Combine(source, kvp.ToString());
                        string specificTargetDir = Path.Combine(resultsThisDate, kvp.ToString());
                        string specificBackupDir = Path.Combine(backResultThisDate, kvp.ToString());

                        if (Directory.Exists(specificSourceDir) && !string.IsNullOrEmpty(specificSourceDir))
                        {
                            // Ensure target directory exists
                            Directory.CreateDirectory(specificTargetDir);
                            Directory.CreateDirectory(specificBackupDir);
                        }

                        var filesFromMc = GetFilesFromMc(specificSourceDir);

                        if (filesFromMc.Count > 0)
                        {
                            //foreach (var file in filesFromDateRange)
                            foreach (var file in filesFromMc)
                            {
                                string sourceFile = Path.Combine(specificSourceDir, file);
                                string destinationFile = Path.Combine(specificTargetDir, file);

                                //Copy files over to task folder
                                File.Copy(sourceFile, destinationFile, true);
                                stateFileCopy = true;

                                //********************************************
                                //Move files into backup folder
                                string backupFile = Path.Combine(specificBackupDir, file);
                                try {
                                    File.Move(sourceFile, backupFile);
                                }
                                catch (Exception ex) { 
                                    Console.WriteLine($"An error occurred: {ex.ToString()}");
                                }
                                Console.WriteLine("Backup copied successfully!");
                                //********************************************
                            }

                            Console.WriteLine($"{kvp} files from date {date} was successfully copied.");

                            //*****************************************
                            /* DELETE THE FILES FROM MAIN DIR IN CMM ONCE OPERATIONS HAVE BEEN COMPLETED */
                            if (!stateFileCopy)
                            {
                                if (filesFromMc.Count == 0) { Console.WriteLine("Files"); }
                            }

                        }
                        else
                        {
                            Console.WriteLine($"No files from {date} to {date} to copy in {kvp}.");
                        }
                    }
                    else if (stateFileCopy && kvp.ToString() == "Process Data")
                    {
                        Process_Data(resultsThisDate);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private List<string> GetFilesFromMc(string directory)
        {

            DirectoryInfo directoryInfo = new DirectoryInfo(directory);

            //Check if dir exists
            if (!directoryInfo.Exists)
            {
                MessageBox.Show($"The directory {directory} does not exist.");
                return new List<string>();  // Return an empty list to avoid further processing.
            }

            //Check if files exists and collect them
            FileInfo[] files = directoryInfo.GetFiles();
            if (files.Length == 0)
            {
                MessageBox.Show($"Directory {directory} is empty");
                return new List<string>();
            }

            // List existing files
            return files.Select(f => f.Name).ToList();
        }
        private async void Process_Data(string targetDir)
        {
            string resultsFolder = Path.Combine(targetDir, "CHRs");
            //string currentDate = DateTime.Now.ToString("yyyy.MM.dd_HH:mm:ss"); //Date to be used on Macro naming
            string currentDate = DateTime.Now.ToString("yyyy.MM.dd"); //Date to be used on Macro naming

            // Default macro path
            string masterMacro = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Macro\CMM_Data_Compiler_Date_AutoRun.xlsm");
            string backupMasterMacro = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Gauges\Tools\DataCompiler\CMM_Data_Compiler_Date_AutoRun.xlsm");


            string macroFileName = Path.GetFileName(masterMacro);

            //*********************************************************
            // Define the destination path for the macro file
            string destinationPath = Path.Combine(resultsFolder, macroFileName);

            string concatenatePaths = Path.Combine(targetDir, resultsFolder);
            //MessageBox.Show($"DestinationPath from Process_Data = {concatenatePaths}");

            try
            {
                // Add delay to ensure the previous process is completed
                await Task.Delay(1000);

                if (Directory.Exists(masterMacro)) {
                    // Copy the additional file to the destination directory
                    File.Copy(masterMacro, destinationPath, true);

                    // Open the copied Excel file and run a macro
                    OpenExcelAndRunMacro(destinationPath, macroFileName, currentDate, concatenatePaths, "Click this button"); // Replace "MacroName" with your actual macro name
                }
                else {
                    File.Copy(backupMasterMacro, destinationPath, true);
                    OpenExcelAndRunMacro(destinationPath, macroFileName, currentDate, concatenatePaths, "Click this button"); // Replace "MacroName" with your actual macro name
                }

                // Add delay to ensure the previous process is completed
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to copy additional file: {ex.Message}");
            }
        }

        public async void OpenExcelAndRunMacro(string filePath, string macroName, string date, string getPath, string buttonName)
        {
            await Task.Delay(10);
            Excel.Application excelApp = new Excel.Application();
            try
            {
                excelApp.Visible = true; // Set the Excel application to be visible

                // Open the Excel file
                Excel.Workbook workbook = excelApp.Workbooks.Open(filePath);
                Excel.Worksheet worksheet = workbook.Sheets[1];

                // Save and close the workbook
                workbook.Save();

                workbook.Close();
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

                /* RENAME AND MOVE MACRO FILE  */
                try
                {
                    // Define parth to macro folder
                    string macroTargetFolder = @"C:\Results\Excel_Files\Macro_Files_Waiting";
                    //string macroTargetFolder = @"I:\Quality\Metrology Lab\PEOPLE\2. Engineering\Yarli\Test\Checking\macro";

                    //MessageBox.Show($"getPath from OpenExcelAndRunMacro = {getPath}");
                    // Get all .xlsm files in the directory
                    string[] xlsmFiles = Directory.GetFiles(getPath, "*.xlsm");

                    if (xlsmFiles.Length > 0)
                    {
                        foreach (string file in xlsmFiles)
                        {
                            //Console.WriteLine($"Found .xlsm file: {file}");
                            //MessageBox.Show($"Found .xlsm file: {file}");

                            // Define the new file name using the current date
                            string renameMacroFile = $"{date}.xlsm"; // Just using the date as the new name

                            // Combine the directory path with the new file name
                            string newMacroFilePath = Path.Combine(getPath, renameMacroFile);

                            // Rename the file
                            // MessageBox.Show(newMacroFilePath);
                            File.Move(file, newMacroFilePath);

                            //Combine Macro target folder and file name
                            string modifiedMacroPath = Path.Combine(macroTargetFolder, Path.GetFileName(newMacroFilePath));

                            /////////////////////////TEST ONLY
                            //MessageBox.Show($"This is the source path = {Path.GetFullPath(newMacroFilePath)}");
                            //MessageBox.Show($"This is the target path = {Path.GetFullPath(modifiedMacroPath)}");
                            ////////////////////////////////////////////////////////////////////////////

                            // Move macro
                            File.Move(newMacroFilePath, modifiedMacroPath);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No .xlsm files found in the directory.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
        /***************************************************************************/
    }
}
