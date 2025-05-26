using RJCodeAdvance.RJControls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class Frm_MainAdmin : Frm_MainBase
    {
        private Form currentChildForm; // Variable para mantener una referencia al formulario hijo actualmente activo.
        private int _currentAdminUserId; // Variable para almacenar el ID del administrador actual.
        public Frm_MainAdmin()
        {
            InitializeComponent();
            label1.Text = "Demeter - Sesión de Administrador";

            if (SessionManager.IsUserAdminActive()) // Verifica que sea admin y esté activo
            {
                _currentAdminUserId = SessionManager.CurrentUserId;;
            }
            else
            {
                MessageBox.Show("Error: No se pudo identificar al administrador o no está activo. La aplicación se cerrará.", "Error de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Load += (s, e) => this.Close();    
                return;
            }
        }

        // EVENTOS
        private void ibtn_Dashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_DashboardAdmin()); // Abre el formulario del Dashboard.
        }
        private void ibtn_Clientes_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_GClientsAdmin(_currentAdminUserId)); // _currentAdminUserId es el IdUsuario del admin
        }
        private void ibtn_Vendedores_Click(object sender, EventArgs e)
        {
            // Pasas el _currentAdminUserId
            OpenChildForm(new Frm_GVendorsAdmin(_currentAdminUserId));
        }
        private void ibtn_Ventas_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_GSalesAdmin()); // Abre el formulario del Gestor de ventas.
        }
        private void ibtn_Manten_Click(object sender, EventArgs e)
        {
            Open_DropdownMenu(ddm_Mantenimiento, sender); // Abre el menu del botón Mantenimiento.
        }
        private void categoria_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_GCategoriesAdmin()); // Abre el formulario del Gestor de productos.
        }
        private void producto_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_GProductsAdmin()); // Abre el formulario del Gestor de categorías.
        }
        private void ibtn_Usuarios_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_GUsersAdmin()); // Abre el formulario del Gestor de usuarios.
        }
        private void ibtn_Reportes_Click(object sender, EventArgs e)
        {
            Open_DropdownMenu(ddm_Reportes, sender); // Abre el menu del botón Reportes.
        }
        private void Ventas_general_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_GeneralSalesReport()); // Abre el formulario del reporte de ventas general.
        }
        private void Ventas_porVendedor_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_SalesByVendorReport()); // Abre el formulario del reporte de ventas por vendedor.
        }
        private void Inventario_general_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_GeneralInventoryReport()); // Abre el formulario del reporte de inventario general.
        }
        private void Inventario_porVendedor_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_InventoryByVendorReport()); // Abre el formulario del reporte de inventario por vendedor.
        }
        private void vendedores_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_VendorsReport()); // Abre el formulario del Gestor de vendedores desde el menú desplegable de Reportes.
        }
        private void clientes_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_ClientsReport()); // Abre el formulario del Gestor de clientes desde el menú desplegable de Reportes.
        }
        private void ibtn_CerrarSesion_Click(object sender, EventArgs e) // Evento Click para el botón de Cerrar Sesión.
        {
            CerrarSesion(); // Llama al método CerrarSesion de la clase base.
        }

        // MÉTODOS PRIVADOS
        private void OpenChildForm(Form childForm) // Método para abrir un formulario hijo dentro del panel de contenido (panelContent).
        {
            // Si ya hay un formulario hijo abierto, ciérralo para evitar superposiciones.
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm; // Asigna el nuevo formulario hijo.

            // Configura el formulario hijo para ser incrustado:
            childForm.TopLevel = false; // Indica que no es una ventana independiente de nivel superior.
            childForm.FormBorderStyle = FormBorderStyle.None; // Elimina el borde y la barra de título del formulario hijo.
            childForm.Dock = DockStyle.Fill; // Hace que el formulario hijo llene completamente el panel contenedor.

            // Añade el formulario hijo al panel de contenido y lo muestra.
            panelContent.Controls.Add(childForm); // Agrega el formulario como un control al panel.
            panelContent.Tag = childForm; // Opcional: Guarda una referencia al formulario en la propiedad Tag del panel.
            childForm.BringToFront(); // Asegura que el formulario hijo esté al frente.
            childForm.Show(); // Muestra el formulario hijo.
        }
        private void Open_DropdownMenu(RJDropdownMenu dropdownMenu, object sender)
        {
            Control control = (Control)sender;
            dropdownMenu.VisibleChanged += new EventHandler((sender2, ev) => DropdownMenu_VisibleChanged(sender2, ev, control));
            dropdownMenu.Show(control, control.Width, 0);
        }
        private void DropdownMenu_VisibleChanged(object sender, EventArgs e, Control ctrl)
        {
            RJDropdownMenu dropdownMenu = (RJDropdownMenu)sender;
            if (!DesignMode)
            {
                if (dropdownMenu.Visible)
                {
                    ctrl.BackColor = Color.FromArgb(117, 82, 72);
                }
                else
                {
                    ctrl.BackColor = Color.FromArgb(117, 82, 72);
                }
            }
        }

        // MÉTODOS SOBREESCRITOS DE LA CLASE BASE / PROTECTED
        protected override void OnFormLoad(object sender, EventArgs e) // Sobrescribe el método OnFormLoad de la clase base para añadir lógica específica.
        {
            // Abre el Dashboard por defecto al cargar el formulario del administrador.
            OpenChildForm(new Frm_DashboardAdmin());
        }
        protected override void OnFormResize(object sender, EventArgs e) // Sobrescribe el método OnFormResize de la clase base para añadir lógica específica.
        {
            // Lógica específica del administrador al redimensionar el formulario, si la hay.
            // El formulario hijo ya se adaptará debido a DockStyle.Fill.
        }

        // Los demás eventos (minimizar, maximizar, salir, menú hamburguesa, etc.)
        // se manejan en la clase base Frm_MainBase.
    }
}