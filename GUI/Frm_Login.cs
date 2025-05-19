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
        private void cbx_showPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtBx_Password.PasswordChar = cbx_showPassword.Checked ? '\0' : '●';
        }
        private void btn_Ingresar_Click(object sender, EventArgs e) // Evento para iniciar sesión con valores de prueba
        {
            if (string.IsNullOrWhiteSpace(txtBx_Username.Text) || string.IsNullOrWhiteSpace(txtBx_Password.Text))
            {
                MessageBox.Show("No pueden quedar campos vacíos", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            // Credenciales de ejemplo:
            if (txtBx_Username.Text == "admin" && txtBx_Password.Text == "12345")
            {
                UserRole = "Admin";
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            // FUTURO: validar vendedor cuando exista Frm_Vendedor
            // else if (txtBx_Username.Text == "vendedor" && txtBx_Password.Text == "54321")
            // {
            //     UserRole = "Vendedor";
            //     this.DialogResult = DialogResult.OK;
            //     this.Close();
            // }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void ibtn_Minimized_LogIn_Click(object sender, EventArgs e) // Evento para minimizar la ventana
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void ibtn_Exit_LogIn_Click(object sender, EventArgs e) // Evento para cerrar la aplicación
        {
            Application.Exit();
        }

    }
}
