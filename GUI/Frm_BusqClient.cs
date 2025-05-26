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
    public partial class Frm_BusqClient : Form
    {
        // Propiedades para devolver el cliente seleccionado
        public int SelectedClientId { get; private set; }
        public string SelectedClientDocument { get; private set; }
        public string SelectedClientName { get; private set; }

        public Frm_BusqClient()
        {
            InitializeComponent();
            // Configuración por defecto para un formulario de diálogo.
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Borde fijo para diálogos
            this.StartPosition = FormStartPosition.CenterParent; // Centrar respecto al padre

            // Inicializar ComboBox de búsqueda
            cbx_Busq.Items.Add("-- Seleccione --");
            cbx_Busq.Items.Add("Número de Documento");
            cbx_Busq.Items.Add("Nombre");
            cbx_Busq.Items.Add("Apellido");
            cbx_Busq.SelectedIndex = 0;

            LoadClientsData(); // Cargar datos iniciales al abrir el formulario
        }

        // Método placeholder para cargar/recargar datos de clientes.
        private void LoadClientsData()
        {
            // --- Lógica para cargar datos de clientes desde la capa BLL y llenar el DataGridView. ---
            // Por ahora, el DataGridView estará vacío o con columnas definidas.
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Documento", typeof(string));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Apellido", typeof(string));
            // No se añaden filas de datos de prueba.
            // Para probar:
            // dt.Rows.Add(1, "123456789", "Juan", "Pérez"); // DATOS DE PRUEBA
            // dt.Rows.Add(2, "987654321", "Ana", "Gómez"); // DATOS DE PRUEBA

            dgv_Client.DataSource = dt; // Asignar el DataTable al DataGridView
        }

        // Evento Click del botón "Buscar".
        private void ibtn_Buscar_Click(object sender, EventArgs e)
        {
            // --- Lógica para buscar clientes basada en el texto y el criterio de búsqueda. ---
            string searchText = tbx_Busq.Text;
            string searchCriteria = cbx_Busq.SelectedItem?.ToString();

            if (cbx_Busq.SelectedIndex == 0 || string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show("Por favor, seleccione un criterio de búsqueda y/o ingrese un texto.", "Búsqueda incompleta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadClientsData(); // Recargar todos los clientes si la búsqueda es inválida o vacía.
                return;
            }

            MessageBox.Show($"Lógica de búsqueda para '{searchText}' por '{searchCriteria}'.", "Buscar Cliente (Placeholder)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Aquí llamarías a la capa BLL para filtrar los datos y actualizar el DataGridView.
            // Ejemplo: dgv_Client.DataSource = BLL.ClientManager.SearchClients(searchText, searchCriteria);
        }

        // Evento Click del botón "Limpiar".
        private void ibtn_Clear_Click(object sender, EventArgs e)
        {
            tbx_Busq.Clear();
            cbx_Busq.SelectedIndex = 0;
            LoadClientsData(); // Recargar todos los clientes al limpiar la búsqueda.
            MessageBox.Show("Campos de búsqueda limpiados.", "Limpiar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Evento Click del botón "OK" para seleccionar el cliente.
        private void ibtn_OK_Click(object sender, EventArgs e)
        {
            SelectClientAndClose();
        }

        // Evento DoubleClick en una celda del DataGridView para seleccionar el cliente.
        private void dgv_Client_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Asegurarse de que no sea el encabezado
            {
                SelectClientAndClose();
            }
        }

        // Método auxiliar para seleccionar el cliente y cerrar el formulario.
        private void SelectClientAndClose()
        {
            if (dgv_Client.SelectedRows.Count > 0)
            {
                // --- Lógica para obtener los datos del cliente de la fila seleccionada ---
                // Ejemplo:
                // SelectedClientId = (int)dgv_Client.SelectedRows[0].Cells["ID"].Value;
                // SelectedClientDocument = dgv_Client.SelectedRows[0].Cells["Documento"].Value.ToString();
                // SelectedClientName = dgv_Client.SelectedRows[0].Cells["Nombre"].Value.ToString();

                MessageBox.Show("Cliente seleccionado con éxito (Placeholder).", "Selección Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Indica que se seleccionó un cliente
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente de la lista.", "No hay selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}