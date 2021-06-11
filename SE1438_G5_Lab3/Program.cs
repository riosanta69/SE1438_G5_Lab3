using SE1438_G5_Lab3.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SE1438_G5_Lab3
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainGUI());
            Application.Run(new GUI.MainGUI());
            //Application.Run(new ReportGUI());
        }
    }
}
