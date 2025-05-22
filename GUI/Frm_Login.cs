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

        //MÉTODOS PRIVADOS
        private void IniciarSesion()
        {
            if (string.IsNullOrWhiteSpace(tbx_Username.Text) || string.IsNullOrWhiteSpace(tbx_Password.Text)) // Se valida que no haya campos vacíos
            {
                MessageBox.Show("No pueden quedar campos vacíos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
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
                MessageBox.Show( "Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error ); // Mensaje de error si las credenciales no son correctas
                return;
            }
        }
    }
}
