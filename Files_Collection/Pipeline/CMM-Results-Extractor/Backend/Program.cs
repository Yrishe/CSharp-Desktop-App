using System;
using System.Windows.Forms;

namespace Extract_Zeiss_Results.Backend
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new ZRCompiler());
            Application.Run(new Frontend.View());

        }
    }
}
