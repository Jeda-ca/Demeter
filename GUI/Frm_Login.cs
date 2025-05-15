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
            var frmAdmin = new Frm_Admin();

            frmAdmin.Show();
            this.Hide();

            frmAdmin.FormClosed += (s, args) => this.Close();
        }
    }
}
