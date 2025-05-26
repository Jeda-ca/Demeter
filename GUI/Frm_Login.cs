using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Frm_Login : Form
    {
        public string UserRole { get; private set; }

        public Frm_Login()
        {
            InitializeComponent();
        }

        // EVENTOS
        private void cbx_showPassword_CheckedChanged(object sender, EventArgs e) // Evento para mostrar/ocultar la contraseña
        {
            tbx_Password.PasswordChar = cbx_showPassword.Checked ? '\0' : '●'; // Cambia el carácter de la contraseña según el estado del checkbox (\0 es el carácter nulo, que muestra el texto sin ocultarlo)
        }
        private void btn_Ingresar_Click(object sender, EventArgs e) // Evento para iniciar sesión con valores de prueba
        {
            IniciarSesion();
        }
        private void ibtn_Minimized_LogIn_Click(object sender, EventArgs e) // Evento para minimizar la ventana
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void ibtn_Exit_LogIn_Click(object sender, EventArgs e) // Evento para cerrar la aplicación
        {
            Application.Exit();
        }

        // Nuevo evento para abrir el formulario de registro de administrador
        private void lbl_RegisterAdmin_Click(object sender, EventArgs e)
        {
            Frm_RegisterAdmin frmRegisterAdmin = new Frm_RegisterAdmin();
            this.Hide(); // Oculta el formulario de Login
            frmRegisterAdmin.ShowDialog(); // Muestra el formulario de registro como un diálogo modal
            this.Show(); // Vuelve a mostrar el formulario de Login cuando el de registro se cierra
            // Si el registro fue exitoso, podrías querer hacer algo aquí,
            // por ejemplo, limpiar los campos del login o mostrar un mensaje.
        }

        //MÉTODOS PRIVADOS
        private void IniciarSesion()
        {
            if (string.IsNullOrWhiteSpace(tbx_Username.Text) || string.IsNullOrWhiteSpace(tbx_Password.Text)) // Se valida que no haya campos vacíos
            {
                MessageBox.Show("No pueden quedar campos vacíos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            // --- Valores de prueba para el usuario admin y vendedor (PLACEHOLDER) ---
            // En un escenario real, aquí se llamaría a la capa BLL para validar las credenciales
            // y obtener el rol del usuario desde la base de datos.
            if (tbx_Username.Text == "admin" && tbx_Password.Text == "12345") // Valores de prueba para el usuario admin
            {
                UserRole = "Admin";
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }
            else if (tbx_Username.Text == "vendedor" && tbx_Password.Text == "54321") // Valores de prueba para el usuario vendedor
            {
                UserRole = "Vendedor";
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Mensaje de error si las credenciales no son correctas
                return;
            }
        }
    }
}