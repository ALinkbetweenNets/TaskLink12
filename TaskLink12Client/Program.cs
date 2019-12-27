using System;
using System.Windows.Forms;

namespace TaskLink12Client
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            TLC.Form = new FormTLClient();
            Application.Run(TLC.Form);
        }
    }
}
