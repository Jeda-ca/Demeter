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
    public partial class Frm_GClientsVendor : Form
    {
        public Frm_GClientsVendor()
        {
            InitializeComponent();
            // Configuración esencial para que este formulario pueda ser incrustado como un control.
            this.TopLevel = false; // Indica que no es una ventana de nivel superior independiente.
            this.FormBorderStyle = FormBorderStyle.None; // Elimina el borde y la barra de título.
            this.Dock = DockStyle.Fill; // Hace que el formulario llene el control contenedor.

            // Inicializar ComboBox de búsqueda (placeholder)
            cbx_Buscar.Items.Add("-- Seleccione --");
            cbx_Buscar.Items.Add("Nombre");
            cbx_Buscar.Items.Add("Apellido");
            cbx_Buscar.Items.Add("Número de Documento");
            cbx_Buscar.Items.Add("Teléfono");
            cbx_Buscar.Items.Add("Email");
            cbx_Buscar.SelectedIndex = 0;
        }

        // Evento Load del formulario.
        private void Frm_GClientsVendor_Load(object sender, EventArgs e)
        {
            LoadClientsData(); // Carga los datos iniciales al cargar el formulario.
        }

        // Método placeholder para cargar/recargar datos de clientes.
        private void LoadClientsData()
        {
            // --- Lógica para cargar datos de clientes desde la capa BLL y llenar el DataGridView. ---
            // Por ahora, el DataGridView estará vacío o con columnas definidas.
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Nombre Completo", typeof(string));
            dt.Columns.Add("Documento", typeof(string));
            dt.Columns.Add("Teléfono", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            // No se añaden filas de datos de prueba.
            // Para probar:
            // dt.Rows.Add(1, "Cliente A Apellido A", "12345", "3001234567", "clienteA@mail.com"); // DATOS DE PRUEBA
            // dt.Rows.Add(2, "Cliente B Apellido B", "67890", "3109876543", "clienteB@mail.com"); // DATOS DE PRUEBA

            dgv_ListaClientes.DataSource = dt; // Asignar el DataTable al DataGridView
        }

        // Evento Click del botón "Agregar" para abrir Frm_AddClientVendor
        private void ibtn_Add_Click(object sender, EventArgs e)
        {
            // Lógica para abrir un formulario de agregar cliente.
            Frm_AddClientVendor frmAddClient = new Frm_AddClientVendor();
            DialogResult result = frmAddClient.ShowDialog(); // Abre el formulario como un diálogo modal

            // Si el formulario se cerró con DialogResult.OK (indicando que se agregó algo)
            // if (result == DialogResult.OK)
            // {
            //    LoadClientsData(); // Recargar la lista de clientes si es necesario.
            // }
        }

        // Evento Click del botón "Buscar" (placeholder para la lógica de búsqueda)
        private void ibtn_Buscar_Click(object sender, EventArgs e)
        {
            // --- Lógica para buscar clientes basada en el texto y el criterio de búsqueda. ---
            string searchText = tbx_Busqueda.Text;
            string searchCriteria = cbx_Buscar.SelectedItem?.ToString();

            if (cbx_Buscar.SelectedIndex == 0 || string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show("Por favor, seleccione un criterio de búsqueda y/o ingrese un texto.", "Búsqueda incompleta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadClientsData(); // Recargar todos los clientes si la búsqueda es inválida o vacía.
                return;
            }

            MessageBox.Show($"Lógica de búsqueda para '{searchText}' por '{searchCriteria}'.", "Buscar Cliente (Placeholder)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Aquí llamarías a la capa BLL para filtrar los datos y actualizar el DataGridView.
            // Ejemplo: dgv_ListaClientes.DataSource = BLL.ClientManager.SearchClients(searchText, searchCriteria);
        }

        // Evento Click del botón "Limpiar"
        private void ibtn_Clear_Click(object sender, EventArgs e)
        {
            tbx_Busqueda.Clear();
            cbx_Buscar.SelectedIndex = 0;
            LoadClientsData(); // Recargar todos los clientes al limpiar la búsqueda.
            MessageBox.Show("Campos de búsqueda limpiados.", "Limpiar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}