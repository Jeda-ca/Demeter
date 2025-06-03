using BLL.Interfaces;
using BLL.Services;
using ENTITY;
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
        public int SelectedClientId { get; private set; }
        public string SelectedClientDocument { get; private set; } // Para mostrar en Frm_AddSaleVendor
        public string SelectedClientName { get; private set; }   // Para mostrar en Frm_AddSaleVendor
        public string SelectedClientCode { get; private set; } // Para uso futuro si es necesario

        private readonly IClienteService _clienteService;
        private readonly ITipoDocumentoService _tipoDocumentoService; // Para mostrar nombre de tipo doc

        public Frm_BusqClient()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;

            try
            {
                _clienteService = new ClienteService();
                _tipoDocumentoService = new TipoDocumentoService(); // Para obtener nombres de TipoDocumento
                InitializeControls();
                LoadClientsData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar búsqueda de clientes: {ex.Message}", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (ibtn_Buscar != null) ibtn_Buscar.Enabled = false;
                if (ibtn_OK != null) ibtn_OK.Enabled = false;
                if (ibtn_Clear != null) ibtn_Clear.Enabled = false;
            }
        }

        private void InitializeControls()
        {
            if (dgv_Client != null) dgv_Client.CellDoubleClick += dgv_Client_CellDoubleClick;

            if (cbx_Busq != null)
            {
                cbx_Busq.Items.Clear();
                cbx_Busq.Items.Add("-- Seleccione Criterio --");
                cbx_Busq.Items.Add("Código Cliente"); // NUEVO CRITERIO
                cbx_Busq.Items.Add("Número de Documento");
                cbx_Busq.Items.Add("Nombre o Apellido");
                cbx_Busq.Items.Add("Email");
                cbx_Busq.SelectedIndex = 0;
            }
        }

        private void LoadClientsData(IEnumerable<Cliente> clientes = null)
        {
            try
            {
                if (_clienteService == null)
                {
                    MessageBox.Show("Servicio de clientes no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (dgv_Client != null) dgv_Client.DataSource = null;
                    return;
                }

                if (clientes == null)
                {
                    // Cargar todos los clientes ACTIVOS por defecto
                    clientes = _clienteService.ObtenerTodosLosClientes().Where(c => c.Activo).ToList();
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int)); // IdCliente
                dt.Columns.Add("CodigoCliente", typeof(string)); // NUEVA COLUMNA
                dt.Columns.Add("Documento", typeof(string));
                dt.Columns.Add("TipoDoc", typeof(string));
                dt.Columns.Add("NombreCompleto", typeof(string));
                dt.Columns.Add("Email", typeof(string));
                dt.Columns.Add("Teléfono", typeof(string));


                foreach (var cliente in clientes.OrderBy(c => c.Apellido).ThenBy(c => c.Nombre))
                {
                    string nombreTipoDoc = cliente.TipoDocumento?.Nombre ?? _tipoDocumentoService?.ObtenerPorId(cliente.TipoDocumentoId)?.Nombre ?? cliente.TipoDocumentoId.ToString();
                    dt.Rows.Add(
                        cliente.IdCliente,
                        cliente.CodigoCliente, // NUEVO DATO
                        cliente.NumeroDocumento,
                        nombreTipoDoc,
                        $"{cliente.Nombre} {cliente.Apellido}",
                        cliente.Correo,
                        cliente.Telefono
                        );
                }

                if (dgv_Client != null)
                {
                    dgv_Client.DataSource = dt;
                    if (dgv_Client.Columns["ID"] != null) dgv_Client.Columns["ID"].Visible = false;
                    if (dgv_Client.Columns["CodigoCliente"] != null) dgv_Client.Columns["CodigoCliente"].HeaderText = "Código"; // Ajustar texto de cabecera
                    if (dgv_Client.Columns["NombreCompleto"] != null) dgv_Client.Columns["NombreCompleto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dgv_Client != null) dgv_Client.DataSource = null;
            }
        }

        private void ibtn_Buscar_Click(object sender, EventArgs e)
        {
            if (_clienteService == null) { MessageBox.Show("Servicio de clientes no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            string searchText = tbx_Busq.Text.Trim();
            string searchCriteria = cbx_Busq.SelectedItem?.ToString();
            IEnumerable<Cliente> clientesFiltrados = new List<Cliente>();

            if (cbx_Busq.SelectedIndex == 0 || string.IsNullOrWhiteSpace(searchText))
            {
                LoadClientsData();
                return;
            }

            try
            {
                var todosLosClientesActivos = _clienteService.ObtenerTodosLosClientes().Where(c => c.Activo);

                switch (searchCriteria)
                {
                    case "Código Cliente": // NUEVO CASO
                        Cliente clientePorCodigo = _clienteService.ObtenerClientePorCodigo(searchText);
                        if (clientePorCodigo != null && clientePorCodigo.Activo)
                        {
                            clientesFiltrados = new List<Cliente> { clientePorCodigo };
                        }
                        break;
                    case "Número de Documento":
                        clientesFiltrados = todosLosClientesActivos.Where(c => c.NumeroDocumento.Contains(searchText)).ToList();
                        break;
                    case "Nombre o Apellido":
                        clientesFiltrados = todosLosClientesActivos.Where(c =>
                            (c.Nombre.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                             c.Apellido.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                        ).ToList();
                        break;
                    case "Email":
                        clientesFiltrados = todosLosClientesActivos.Where(c => c.Correo != null && c.Correo.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                        break;
                    default:
                        clientesFiltrados = todosLosClientesActivos.ToList();
                        break;
                }
                LoadClientsData(clientesFiltrados);

                if (!clientesFiltrados.Any())
                {
                    MessageBox.Show("No se encontraron clientes que coincidan con la búsqueda.", "Búsqueda sin Resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar clientes: {ex.Message}", "Error de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibtn_Clear_Click(object sender, EventArgs e)
        {
            if (tbx_Busq != null) tbx_Busq.Clear();
            if (cbx_Busq != null && cbx_Busq.Items.Count > 0) cbx_Busq.SelectedIndex = 0;
            LoadClientsData();
        }

        private void ibtn_OK_Click(object sender, EventArgs e)
        {
            SelectClientAndClose();
        }

        private void dgv_Client_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectClientAndClose();
            }
        }

        private void SelectClientAndClose()
        {
            if (dgv_Client.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow selectedRow = dgv_Client.SelectedRows[0];
                    SelectedClientId = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                    SelectedClientDocument = selectedRow.Cells["Documento"].Value.ToString();
                    SelectedClientName = selectedRow.Cells["NombreCompleto"].Value.ToString();
                    SelectedClientCode = selectedRow.Cells["CodigoCliente"].Value.ToString(); // Obtener el código

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al seleccionar cliente: {ex.Message}", "Error de Selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente de la lista.", "No hay selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}