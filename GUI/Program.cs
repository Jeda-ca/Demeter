using QuestPDF.Infrastructure;
using System;
using System.Windows.Forms;

namespace GUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            QuestPDF.Settings.License = LicenseType.Community;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Único bucle de mensajes: arrancamos nuestro contexto
            Application.Run(new AppContext());
        }
    }
}
