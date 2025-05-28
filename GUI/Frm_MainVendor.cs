using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Frm_MainVendor : Frm_MainBase // Asegúrate que herede de Frm_MainBase
    {
        private Form currentChildForm;
        private readonly int _currentVendedorUserId;    // IdUsuario del vendedor
        private readonly int _currentVendedorTablaId; // IdVendedor (PK de la tabla sellers)

        public Frm_MainVendor()
        {
            InitializeComponent();
            label1.Text = "Demeter - Sesión de Vendedor"; // label1 es el título del form
            ICONBTN_HEIGHT = 80; // Ajuste específico para este formulario

            if (SessionManager.IsUserLoggedIn() && SessionManager.CurrentUserRoleName?.ToUpper() == "VENDEDOR" && SessionManager.CurrentSpecificRoleId.HasValue)
            {
                _currentVendedorUserId = SessionManager.CurrentUserId;
                _currentVendedorTablaId = SessionManager.CurrentSpecificRoleId.Value;
                // Console.WriteLine($"Frm_MainVendor: UserId={_currentVendedorUserId}, VendedorTablaId={_currentVendedorTablaId}"); // Para depurar
            }
            else
            {
                MessageBox.Show("Error: No se pudo identificar al vendedor o la sesión no es válida. La aplicación se cerrará.", "Error de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Load += (s, e) => this.Close();
                return;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelContent.Controls.Add(childForm); // panelContent es el panel donde se muestran los forms hijos
            panelContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void ibtn_Dashboard_Click(object sender, EventArgs e)
        {
            // Frm_DashboardVendor podría necesitar el _currentVendedorTablaId para filtrar sus datos
            OpenChildForm(new Frm_DashboardVendor(_currentVendedorTablaId));
        }

        private void ibtn_Productos_Click(object sender, EventArgs e)
        {
            // Frm_GProductsVendor necesita ambos IDs
            OpenChildForm(new Frm_GProductsVendor(_currentVendedorUserId, _currentVendedorTablaId));
        }

        private void ibtn_Ventas_Click(object sender, EventArgs e)
        {
            // Frm_GSalesVendor necesita ambos IDs
            OpenChildForm(new Frm_GSalesVendor(_currentVendedorUserId, _currentVendedorTablaId));
        }

        private void ibtn_Clientes_Click(object sender, EventArgs e)
        {
            // Frm_GClientsVendor podría necesitar el _currentVendedorUserId si el vendedor solo ve clientes que él registró,
            // o _currentVendedorTablaId si la lógica de negocio lo requiere.
            // Por ahora, si solo lista y agrega, quizás solo el _currentVendedorUserId para auditoría.
            OpenChildForm(new Frm_GClientsVendor(_currentVendedorUserId, _currentVendedorTablaId));
        }

        private void ibtn_Signout_Click(object sender, EventArgs e)
        {
            CerrarSesion();
        }

        protected override void OnFormLoad(object sender, EventArgs e)
        {
            if (_currentVendedorUserId > 0)
            {
                OpenChildForm(new Frm_DashboardVendor(_currentVendedorTablaId));
            }
        }
    }
}