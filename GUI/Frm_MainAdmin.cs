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
    public partial class Frm_MainAdmin : Frm_MainBase
    {
        // Variable para mantener una referencia al formulario hijo actualmente activo.
        private Form currentChildForm;

        public Frm_MainAdmin()
        {
            InitializeComponent();
            label1.Text = "Demeter - Sesión de Administrador";
            // No es necesario ajustar ICONBTN_HEIGHT aquí si ya es 65 por defecto en la base.
        }

        // --- MÉTODOS PRIVADOS/PROTECTED ESPECÍFICOS DE Frm_MainAdmin ---

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

        // --- EVENTOS ESPECÍFICOS DE Frm_MainAdmin ---

        // Sobrescribe el método OnFormLoad de la clase base para añadir lógica específica.
        protected override void OnFormLoad(object sender, EventArgs e)
        {
            // Abre el Dashboard por defecto al cargar el formulario del administrador.
            OpenChildForm(new Frm_DashboardAdmin());
        }

        // Sobrescribe el método OnFormResize de la clase base para añadir lógica específica.
        protected override void OnFormResize(object sender, EventArgs e)
        {
            // Lógica específica del administrador al redimensionar el formulario, si la hay.
            // El formulario hijo ya se adaptará debido a DockStyle.Fill.
        }

        // Evento Click para el botón de Cerrar Sesión.
        private void ibtn_CerrarSesion_Click(object sender, EventArgs e)
        {
            CerrarSesion(); // Llama al método CerrarSesion de la clase base.
        }

        // Evento Click para el botón de Dashboard.
        private void ibtn_Dashboard_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_DashboardAdmin()); // Abre el formulario del Dashboard.
        }
        private void ibtn_Clientes_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_GClientsAdmin()); // Abre el formulario del Gestor de clientes.
        }
        private void ibtn_Vendedores_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_GVendorsAdmin()); // Abre el formulario del Gestor de vendedores.
        }
        private void ibtn_Ventas_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_GSalesAdmin()); // Abre el formulario del Gestor de ventas.
        }
        private void ibtn_Usuarios_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_GUsersAdmin()); // Abre el formulario del Gestor de usuarios.
        }

        private void ibtn_Reportes_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Frm_ReportsAdmin()); // Abre el formulario de Reportes.
        }

        // Los demás eventos (minimizar, maximizar, salir, menú hamburguesa, etc.)
        // se manejan en la clase base Frm_MainBase.
    }
}