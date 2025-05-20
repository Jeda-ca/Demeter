using System;
using System.Windows.Forms;

namespace GUI
{
    public class AppContext : ApplicationContext
    {
        private Frm_Login loginForm;
        private Form mainForm;

        public AppContext()
        {
            // Mostrar login (no crea un bucle separado)
            loginForm = new Frm_Login();
            loginForm.FormClosed += OnLoginClosed;
            loginForm.Show();
        }

        private void OnLoginClosed(object sender, FormClosedEventArgs e) // Evento que se ejecuta al cerrar el formulario de login
        {
            if (loginForm.DialogResult != DialogResult.OK) // Si el resultado del diálogo no es OK, se cierra la aplicación (es decir, el usuario no ha iniciado sesión correctamente)
            {
                ExitThread();
                return;
            }
            MessageBox.Show($"Bienvenido/a {loginForm.UserRole}", "¡Hola!", MessageBoxButtons.OK, MessageBoxIcon.Information); // Mensaje de bienvenida al usuario según su rol

            // 1) Crear la instancia según rol
            switch (loginForm.UserRole)
            {
                case "Admin": // Si el rol es Admin, se crea/muestra el formulario de administrador
                    mainForm = new Frm_MainAdmin();
                    break;
                case "Vendedor": // Si el rol es Vendedor, se crea/muestra el formulario de vendedor
                    mainForm = new Frm_MainVendor();
                    break;
                default:
                    MessageBox.Show("Rol de usuario no soportado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Mensaje de error si el rol no es soportado
                    ExitThread();
                    return;
            }

            // 2) Ahora que mainForm está garantizado no nulo, suscribimos el evento
            mainForm.FormClosed += OnMainFormClosed;

            // 3) Mostrar el formulario principal
            mainForm.Show();
        }


        private void OnMainFormClosed(object sender, FormClosedEventArgs e) // Evento que se ejecuta al cerrar el formulario principal
        {
            // Vuelve a instanciar un login limpio
            loginForm = new Frm_Login();
            loginForm.FormClosed += OnLoginClosed;
            loginForm.Show();
        }
    }
}
