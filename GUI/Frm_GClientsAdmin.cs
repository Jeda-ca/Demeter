using GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI
{
    public partial class Frm_GClientsAdmin : Form
    {
        public Frm_GClientsAdmin()
        {
            InitializeComponent();

            // Configuración esencial para que este formulario pueda ser incrustado como un control:
            this.TopLevel = false; // Indica que no es una ventana de nivel superior independiente.
            this.FormBorderStyle = FormBorderStyle.None; // Elimina el borde y la barra de título.
            this.Dock = DockStyle.Fill; // Hace que el formulario llene el control contenedor.

            // Inicializar ComboBox de búsqueda (placeholder)
            //cbx_Buscar.Items.Add("-- Seleccione --");
            //cbx_Buscar.Items.Add("Nombre");
            //cbx_Buscar.Items.Add("Apellido");
            //cbx_Buscar.Items.Add("Número de Documento");
            //cbx_Buscar.Items.Add("Email");
            //cbx_Buscar.SelectedIndex = 0;
        }
        private void Frm_GClientsAdmin_Load(object sender, EventArgs e) // Evento Load del formulario.
        {
            LoadClientsData(); // Lógica para cargar datos de clientes en el DataGridView.
        }

        //EVENTOS
        private void ibtn_ModifyInfo_Click(object sender, EventArgs e) // Evento Click del botón "Modificar Información" para abrir Frm_ModifyC
        {
            if (dgv_ListaClientes.SelectedRows.Count > 0) // Lógica para verificar si hay un cliente seleccionado en el DataGridView
            {
                ModifyClientInfo(); // Llama al método para abrir el formulario de modificar cliente.
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente para modificar.", "Modificar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ibtn_Delete_Click(object sender, EventArgs e) // Evento Click del botón "Eliminar" (placeholder para la lógica de eliminar cliente)
        {
            if (dgv_ListaClientes.SelectedRows.Count > 0)
            {
                DeleteClient(); // Llama al método para eliminar el cliente seleccionado.
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente para eliminar.", "Eliminar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ibtn_Buscar_Click(object sender, EventArgs e) // Evento Click del botón "Buscar" (placeholder para la lógica de búsqueda)
        {
            BuscarClient(); // Llama al método para buscar clientes.
        }

        // MÉTODOS PRIVADOS
        private void LoadClientsData() // Método placeholder para cargar/recargar datos de clientes.
        {
            // --- Lógica para cargar datos de clientes desde la capa BLL y llenar el DataGridView. ---
            // Por ahora, el DataGridView estará vacío o con columnas definidas.
            //DataTable dt = new DataTable();
            //dt.Columns.Add("ID", typeof(int));
            //dt.Columns.Add("Nombre", typeof(string));
            //dt.Columns.Add("Apellido", typeof(string));
            //dt.Columns.Add("Documento", typeof(string));
            //dt.Columns.Add("Teléfono", typeof(string));
            //dt.Columns.Add("Email", typeof(string));
            // No se añaden filas de datos de prueba.
            // Para probar:
            // dt.Rows.Add(1, "Ana", "López", "1001001", "3011112233", "ana.lopez@example.com"); // DATOS DE PRUEBA
            // dt.Rows.Add(2, "Carlos", "Ramírez", "1001002", "3024445566", "carlos.ramirez@example.com"); // DATOS DE PRUEBA

            // dgv_ListaClientes.DataSource = dt; // Asignar el DataTable al DataGridView
        }
        private void ModifyClientInfo()
        {
            // --- Lógica para pasar la información del cliente seleccionado a Frm_ModifyC ---
            // Ejemplo:
            // int clienteId = (int)dgv_ListaClientes.SelectedRows[0].Cells["ID"].Value;
            // string nombre = dgv_ListaClientes.SelectedRows[0].Cells["Nombre"].Value.ToString();
            // ... y pasar todos los datos necesarios al constructor de Frm_ModifyC

            Frm_ModifyClient frmModifyC = new Frm_ModifyClient(); // Si necesitas pasar datos, modifica el constructor de Frm_ModifyC
            DialogResult result = frmModifyC.ShowDialog(); // Abre el formulario Frm_ModifyC como un diálogo modal

            // Si el formulario Frm_ModifyC se cerró con DialogResult.OK
            // if (result == DialogResult.OK)
            // {
            //     LoadClientsData(); // Recargar la lista de clientes si es necesario.
            // }
        }
        private void DeleteClient()
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar el cliente seleccionado?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                // --- Lógica placeholder para eliminar el cliente seleccionado ---
                // Ejemplo: int clienteId = (int)dgv_ListaClientes.SelectedRows[0].Cells["ID"].Value;
                // BLL.ClienteManager.DeleteCliente(clienteId); // Llamada a la capa BLL

                MessageBox.Show("Cliente eliminado con éxito (Placeholder).", "Eliminar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Después de eliminar, podrías recargar la lista de clientes:
                // LoadClientsData();
            }
        }
        private void BuscarClient()
        {
            // --- Lógica para buscar clientes basada en el texto y el criterio de búsqueda. ---
            string searchText = tbx_Busqueda.Text;
            string searchCriteria = cbx_Buscar.SelectedItem?.ToString(); // Asumiendo que cbx_Buscar existe y tiene opciones

            if (cbx_Buscar.SelectedIndex == 0 || string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show("Por favor, seleccione un criterio de búsqueda y/o ingrese un texto.", "Búsqueda incompleta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadClientsData(); // Recargar todos los clientes si la búsqueda es inválida o vacía.
                return;
            }

            MessageBox.Show($"Lógica de búsqueda para '{searchText}' por '{searchCriteria}'.", "Buscar Cliente (Placeholder)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Aquí llamarías a la capa BLL para filtrar los datos y actualizar el DataGridView.
            // Ejemplo: dgv_ListaClientes.DataSource = BLL.ClienteManager.SearchClients(searchText, searchCriteria);
        }
    }
}