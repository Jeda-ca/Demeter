using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.Interfaces;
using BLL.Services;
using ENTITY;

namespace GUI
{
    public partial class Frm_Login : Form
    {
        public string UserRole { get; private set; }
        public Usuario AuthenticatedUser { get; private set; } // Propiedad para almacenar el usuario autenticado
        private readonly IUsuarioService _usuarioService; // Campo para el servicio de usuario

        public Frm_Login()
        {
            InitializeComponent();
            try
            {
                // La GUI solo instancia el servicio. 
                // El servicio (UsuarioService) se encarga de instanciar sus propias dependencias de DAL.
                _usuarioService = new UsuarioService();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico al inicializar UsuarioService: {ex.Message}\n\n{ex.StackTrace}", "Error de Inicialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Considerar deshabilitar el botón de login si la inicialización falla.
                btn_Ingresar.Enabled = false;
            }
        }

        // Evento para mostrar/ocultar la contraseña
        private void cbx_showPassword_CheckedChanged(object sender, EventArgs e)
        {
            tbx_Password.PasswordChar = cbx_showPassword.Checked ? '\0' : '●';
        }

        // Evento para iniciar sesión
        private void btn_Ingresar_Click(object sender, EventArgs e)
        {
            IniciarSesion();
        }

        // Evento para minimizar la ventana
        private void ibtn_Minimized_LogIn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Evento para cerrar la aplicación
        private void ibtn_Exit_LogIn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Evento para abrir el formulario de registro de administrador
        private void lbl_RegisterAdmin_Click(object sender, EventArgs e)
        {
            using (Frm_RegisterAdmin frmRegisterAdmin = new Frm_RegisterAdmin())
            {
                this.Hide();
                frmRegisterAdmin.ShowDialog();
                this.Show();
            }
        }

        // Método para la lógica de inicio de sesión
        private void IniciarSesion()
        {
            if (string.IsNullOrWhiteSpace(tbx_Username.Text) || string.IsNullOrWhiteSpace(tbx_Password.Text))
            {
                MessageBox.Show("El nombre de usuario y la contraseña no pueden estar vacíos.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = tbx_Username.Text.Trim();
            string password = tbx_Password.Text;

            try
            {
                if (_usuarioService == null)
                {
                    MessageBox.Show("El servicio de autenticación no está disponible. Contacte al administrador.", "Error de Servicio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Usuario usuarioAutenticado = _usuarioService.AutenticarUsuario(username, password);

                if (usuarioAutenticado != null)
                {
                    if (!usuarioAutenticado.Activo)
                    {
                        MessageBox.Show("El usuario está inactivo. Contacte al administrador.", "Usuario Inactivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (usuarioAutenticado is ENTITY.Administrador)
                    {
                        UserRole = "Admin";
                    }
                    else if (usuarioAutenticado is ENTITY.Vendedor)
                    {
                        UserRole = "Vendedor";
                    }
                    else if (usuarioAutenticado.Rol != null && !string.IsNullOrEmpty(usuarioAutenticado.Rol.Nombre))
                    {
                        UserRole = usuarioAutenticado.Rol.Nombre.ToUpper() == "ADMIN" ? "Admin" :
                                   usuarioAutenticado.Rol.Nombre.ToUpper() == "VENDEDOR" ? "Vendedor" : null;
                    }

                    if (UserRole != null)
                    {
                        this.AuthenticatedUser = usuarioAutenticado;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Rol de usuario no reconocido.", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Nombre de usuario o contraseña incorrectos.", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ApplicationException appEx)
            {
                MessageBox.Show($"Error de aplicación durante el inicio de sesión: {appEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error inesperado: {ex.Message}", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}