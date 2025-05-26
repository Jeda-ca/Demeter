using ENTITY;
using System;
using System.Windows.Forms;

namespace GUI
{
    public class AppContext : ApplicationContext
    {
        private Frm_Login loginForm;
        private Form mainForm; // Puede ser Frm_MainAdmin o Frm_MainVendor

        public AppContext()
        {
            ShowLoginForm();
        }

        private void ShowLoginForm()
        {
            SessionManager.ClearSession(); // Asegurarse de que no haya sesión previa
            loginForm = new Frm_Login();
            loginForm.FormClosed += OnLoginClosed; // Suscribirse al evento FormClosed
            MainForm = loginForm; // Establecer el formulario de login como el principal inicialmente
            loginForm.Show();
        }

        private void OnLoginClosed(object sender, FormClosedEventArgs e)
        {
            // Desuscribirse del evento para evitar múltiples llamadas si se reusa loginForm
            if (sender is Frm_Login closedLoginForm)
            {
                closedLoginForm.FormClosed -= OnLoginClosed;
            }

            if (loginForm.DialogResult == DialogResult.OK && loginForm.UserRole != null)
            {

                if (loginForm.AuthenticatedUser != null) // Asumiendo que Frm_Login expone el usuario
                {
                    SessionManager.SetCurrentUser(loginForm.AuthenticatedUser);
                    MessageBox.Show($"Bienvenido/a {SessionManager.CurrentUser.NombreUsuario} ({SessionManager.CurrentUser.Rol?.Nombre})", "¡Hola!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    switch (loginForm.UserRole) // UserRole se sigue usando para decidir qué form abrir
                    {
                        case "Admin":
                            mainForm = new Frm_MainAdmin(); // Frm_MainAdmin ahora usará SessionManager
                            break;
                        case "Vendedor":
                            mainForm = new Frm_MainVendor(); // Frm_MainVendor ahora usará SessionManager
                            break;
                        default:
                            MessageBox.Show("Rol de usuario no soportado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ExitThread();
                            return;
                    }

                    mainForm.FormClosed += OnMainFormClosed;
                    MainForm = mainForm; // Cambiar el formulario principal de la aplicación
                    loginForm.Dispose(); // Liberar recursos del formulario de login
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("No se pudo obtener la información del usuario autenticado.", "Error de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ShowLoginForm(); // Volver a mostrar el login
                }
            }
            else
            {
                // Si el login no fue OK o UserRole es null (ej. se cerró el form de login)
                // Solo salir si no hay otro formulario principal ya asignado (evita error si se cierra login mientras main form está abierto)
                if (MainForm == loginForm || MainForm == null || MainForm.IsDisposed)
                {
                    ExitThread();
                }
            }
        }

        private void OnMainFormClosed(object sender, FormClosedEventArgs e)
        {
            // Desuscribirse del evento
            if (sender is Form closedMainForm)
            {
                closedMainForm.FormClosed -= OnMainFormClosed;
            }
            // Limpiar la sesión y volver a mostrar el formulario de login
            ShowLoginForm();
        }
    }
}
