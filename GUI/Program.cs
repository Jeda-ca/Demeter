using System;
using System.Windows.Forms;

namespace GUI
{
    internal static class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Único bucle de mensajes: arrancamos nuestro contexto
            Application.Run(new AppContext());
        }
    }
}
