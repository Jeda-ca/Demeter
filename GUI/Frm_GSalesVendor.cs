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
    public partial class Frm_GSalesVendor : Form
    {
        public Frm_GSalesVendor()
        {
            InitializeComponent();
        }

        private void ibtn_Add_Click(object sender, EventArgs e)
        {
            Frm_AddSaleVendor frmAdd = new Frm_AddSaleVendor();
            DialogResult result = frmAdd.ShowDialog();

        }
    }
}
