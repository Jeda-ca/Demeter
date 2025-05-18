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
        public Frm_Login()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void cbx_showPass_CheckedChanged(object sender, EventArgs e)
        {
            txtBx_Password.PasswordChar = cbx_showPass.Checked ? '\0' : '●';
        }

        private void btn_Ingresar_Click(object sender, EventArgs e)
        {
            if (txtBx_Username.Text == "" || txtBx_Password.Text == "")
            {
                MessageBox.Show("No pueden quedar campos vacíos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (txtBx_Username.Text == "admin" && txtBx_Password.Text == "12345")
            {
                MessageBox.Show("Bienvenido/a " + txtBx_Username.Text, "Acceso concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var frmAdmin = new Frm_MainAdmin();
                frmAdmin.Show();
                this.Hide();
                frmAdmin.FormClosed += (s, args) => this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}
