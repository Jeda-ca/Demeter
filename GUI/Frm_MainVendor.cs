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
    public partial class Frm_MainVendor : Frm_MainBase
    {
        private Form currentChildForm; // Variable para mantener una referencia al formulario hijo actualmente activo.

        public Frm_MainVendor()
        {
            InitializeComponent(); // Inicializa los componentes específicos de Frm_MainVendor.Designer.cs
            label1.Text = "Demeter - Sesión de Vendedor";

            ICONBTN_HEIGHT = 80; // Sobrescribe el valor por defecto de la clase base a 80.

            // Asignar eventos Click a los botones del menú.
            // Estas líneas son necesarias si no están ya en el Designer.cs
            // o si quieres sobrescribir la asignación predeterminada.
            ibtn_Dashboard.Click += ibtn_Dashboard_Click;
            ibtn_Productos.Click += ibtn_Productos_Click;
            ibtn_Ventas.Click += ibtn_Ventas_Click;
            ibtn_Clientes.Click += ibtn_Clientes_Click;
            ibtn_Signout.Click += ibtn_Signout_Click;
        }

        // --- MÉTODOS PRIVADOS ---

        // Método para abrir un formulario hijo dentro del panel de contenido (panelContent).
        private void OpenChildForm(Form childForm)
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

        // --- EVENTOS ESPECÍFICOS DE Frm_MainVendor ---

        // Evento Click para el botón de Dashboard.
        private void ibtn_Dashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_DashboardVendor()); // Abre el formulario del Dashboard del Vendedor.
        }

        // Evento Click para el botón de Productos.
        private void ibtn_Productos_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_GProductsVendor()); // Abre el formulario de Gestión de Productos del Vendedor.
        }

        // Evento Click para el botón de Ventas.
        private void ibtn_Ventas_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_GSalesVendor()); // Abre el formulario de Gestión de Ventas del Vendedor.
        }

        // Evento Click para el botón de Clientes.
        private void ibtn_Clientes_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_GClientsVendor()); // Abre el formulario de Gestión de Clientes del Vendedor.
        }

        // Evento Click para el botón de Cerrar Sesión.
        private void ibtn_Signout_Click(object sender, EventArgs e)
        {
            CerrarSesion(); // Llama al método CerrarSesion de la clase base.
        }

        // --- MÉTODOS SOBREESCRITOS DE LA CLASE BASE / PROTECTED ---

        protected override void OnFormLoad(object sender, EventArgs e) // Sobrescribe el método OnFormLoad de la clase base para añadir lógica específica.
        {
            // Abre el Dashboard por defecto al cargar el formulario del vendedor.
            OpenChildForm(new Frm_DashboardVendor());
        }

        protected override void OnFormResize(object sender, EventArgs e) // Sobrescribe el método OnFormResize de la clase base para añadir lógica específica
        {
            // Lógica específica del vendedor al redimensionar el formulario, si la hay.
            // El formulario hijo ya se adaptará debido a DockStyle.Fill.
        }

        // Los eventos para btn_Minimized_Click, btn_Maximized_Click, btn_Exit_Click,
        // btnMenu_Click, tim_PanelMenu_Tick y panelTitleBar_MouseDown
        // ya están definidos y manejados en Frm_MainBase.
    }
}