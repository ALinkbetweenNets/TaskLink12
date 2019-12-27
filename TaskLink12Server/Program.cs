using System;
using System.Windows.Forms;

namespace TaskLink12Server
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
            TLS.Form = new FormTLServer();
            Application.Run(new FormTLServer());
        }
    }
}
