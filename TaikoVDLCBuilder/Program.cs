using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;

namespace TaikoVDLCBuilder
{
    [SuppressMessage("Interoperability", "CA1416:Validate platform compatibility")]
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
            Application.Run(new DlcSelector());
        }
    }
}
