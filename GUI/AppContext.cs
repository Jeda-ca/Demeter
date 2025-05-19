using System;
using System.Windows.Forms;

namespace GUI
{
    /// <summary>
    /// Gestiona el flujo: primero login, luego formulario según rol.
    /// Por ahora solo Admin; en el futuro, cuando crees Frm_Vendedor,
    /// descomenta las líneas correspondientes.
    /// </summary>
    public class AppContext : ApplicationContext
    {
        private Frm_Login loginForm;
        private Form mainForm;

        public AppContext()
        {
            // 1) Mostrar login (no crea un bucle separado)
            loginForm = new Frm_Login();
            loginForm.FormClosed += OnLoginClosed;
            loginForm.Show();
        }

        private void OnLoginClosed(object sender, FormClosedEventArgs e)
        {
            // 2) Tras cerrar login, si OK -> arrancar formulario principal
            if (loginForm.DialogResult == DialogResult.OK)
            {
                switch (loginForm.UserRole)
                {
                    case "Admin":
                        mainForm = new Frm_MainAdmin();
                        break;

                    // FUTURO:
                    // case "Vendedor":
                    //     mainForm = new Frm_Vendedor();
                    //     break;

                    default:
                        // Rol no reconocido: salir o mostrar mensaje
                        MessageBox.Show("Rol de usuario no soportado.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ExitThread();
                        return;
                }

                // 3) Cuando el mainForm se cierre, cerramos la app
                mainForm.FormClosed += (s, args) => ExitThread();
                mainForm.Show();
            }
            else
            {
                // 4) Login cancelado o fallido → salir
                ExitThread();
            }
        }
    }
}
