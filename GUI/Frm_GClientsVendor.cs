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
    public partial class Frm_GClientsVendor : Form
    {
        private readonly int _idUsuarioVendedorLogueado;
        private readonly int _idVendedorTabla;
        private IClienteService _clienteService;
        private ITipoDocumentoService _tipoDocumentoService; // Para el ComboBox en Frm_AddClientVendor

        public Frm_GClientsVendor(int idUsuarioVendedor, int idVendedorTabla)
        {
            InitializeComponent();
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            _idUsuarioVendedorLogueado = idUsuarioVendedor;
            _idVendedorTabla = idVendedorTabla;

            if (_idUsuarioVendedorLogueado <= 0)
            {
                MessageBox.Show("Error: Información de vendedor no válida para el gestor de clientes.", "Error de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new MethodInvoker(this.Close));
                return;
            }

            try
            {
                _clienteService = new ClienteService();
                _tipoDocumentoService = new TipoDocumentoService(); // Para Frm_AddClientVendor
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar servicios en Gestor de Clientes Vendedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Deshabilitar controles si falla la inicialización
                if (ibtn_Add != null) ibtn_Add.Enabled = false;
                if (ibtn_Buscar != null) ibtn_Buscar.Enabled = false;
                if (ibtn_Clear != null) ibtn_Clear.Enabled = false;
                if (cbx_Buscar != null) cbx_Buscar.Enabled = false;
            }
        }

        private void Frm_GClientsVendor_Load(object sender, EventArgs e)
        {
            if (_idUsuarioVendedorLogueado > 0 && _clienteService != null)
            {
                CargarFiltrosComboBox();
                LoadClientsData();
            }
        }

        private void CargarFiltrosComboBox()
        {
            if (cbx_Buscar == null) return;
            cbx_Buscar.Items.Clear();
            cbx_Buscar.Items.Add("-- Seleccione Criterio --");
            cbx_Buscar.Items.Add("Nombre o Apellido");
            cbx_Buscar.Items.Add("Número de Documento");
            cbx_Buscar.Items.Add("Email");
            cbx_Buscar.SelectedIndex = 0;
        }

        private void LoadClientsData(IEnumerable<Cliente> clientes = null)
        {
            try
            {
                if (_clienteService == null) { MessageBox.Show("Servicio de clientes no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                if (clientes == null)
                {
                    // Por defecto, el vendedor ve todos los clientes activos del sistema.
                    // Si la lógica fuera que un vendedor solo ve los clientes que ÉL registró,
                    // necesitarías un método en ClienteService que filtre por VendedorId (si esa relación existe).
                    // Por ahora, se asume que ve todos los clientes activos.
                    clientes = _clienteService.ObtenerTodosLosClientes().Where(c => c.Activo).ToList();
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("IdCliente", typeof(int));
                dt.Columns.Add("NombreCompleto", typeof(string));
                dt.Columns.Add("TipoDocumento", typeof(string));
                dt.Columns.Add("NumeroDocumento", typeof(string));
                dt.Columns.Add("Telefono", typeof(string));
                dt.Columns.Add("Email", typeof(string));

                foreach (var cliente in clientes.OrderBy(c => c.Apellido).ThenBy(c => c.Nombre))
                {
                    dt.Rows.Add(
                        cliente.IdCliente,
                        $"{cliente.Nombre} {cliente.Apellido}",
                        cliente.TipoDocumento?.Nombre ?? "N/A", // Asume que TipoDocumento se carga
                        cliente.NumeroDocumento,
                        cliente.Telefono,
                        cliente.Correo
                    );
                }
                if (dgv_ListaClientes != null)
                {
                    dgv_ListaClientes.DataSource = dt;
                    if (dgv_ListaClientes.Columns["IdCliente"] != null) dgv_ListaClientes.Columns["IdCliente"].Visible = false;
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        // Este es el método que el Designer.cs está buscando para el botón ibtn_Add
        private void ibtn_Add_Click(object sender, EventArgs e)
        {
            // Frm_AddClientVendor necesitará el _idUsuarioVendedorLogueado para auditoría
            // y _idVendedorTabla si el cliente se asocia al vendedor que lo registra (esto último no está en tu modelo actual de Cliente).
            // Por ahora, solo pasamos el ID del usuario vendedor.
            using (Frm_AddClientVendor frmAdd = new Frm_AddClientVendor(_idUsuarioVendedorLogueado /*, _idVendedorTabla (si es necesario)*/))
            {
                if (frmAdd.ShowDialog() == DialogResult.OK)
                {
                    LoadClientsData(); // Recargar la lista de clientes
                }
            }
        }

        private void ibtn_Buscar_Click(object sender, EventArgs e)
        {
            string criterio = cbx_Buscar.SelectedItem?.ToString();
            string textoBusqueda = tbx_Busqueda.Text.Trim();
            IEnumerable<Cliente> clientesFiltrados = new List<Cliente>();

            if (string.IsNullOrEmpty(criterio) || criterio == "-- Seleccione Criterio --")
            {
                if (string.IsNullOrWhiteSpace(textoBusqueda)) LoadClientsData();
                else criterio = "Nombre o Apellido";
            }
            if (_clienteService == null) { MessageBox.Show("Servicio de clientes no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            try
            {
                // Siempre buscar sobre los clientes activos para la vista del vendedor
                var todosLosClientesActivos = _clienteService.ObtenerTodosLosClientes().Where(c => c.Activo);

                switch (criterio)
                {
                    case "Nombre o Apellido":
                        if (!string.IsNullOrWhiteSpace(textoBusqueda))
                            clientesFiltrados = todosLosClientesActivos.Where(c =>
                                (c.Nombre.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                 c.Apellido.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0)
                            ).ToList();
                        else { LoadClientsData(); return; }
                        break;
                    case "Número de Documento":
                        if (!string.IsNullOrWhiteSpace(textoBusqueda))
                            clientesFiltrados = todosLosClientesActivos.Where(c => c.NumeroDocumento.Contains(textoBusqueda)).ToList();
                        else { LoadClientsData(); return; }
                        break;
                    case "Email":
                        if (!string.IsNullOrWhiteSpace(textoBusqueda))
                            clientesFiltrados = todosLosClientesActivos.Where(c => c.Correo != null && c.Correo.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                        else { LoadClientsData(); return; }
                        break;
                    default:
                        clientesFiltrados = todosLosClientesActivos.ToList();
                        break;
                }
                LoadClientsData(clientesFiltrados);
            }
            catch (Exception ex) { MessageBox.Show($"Error al buscar clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ibtn_Clear_Click(object sender, EventArgs e)
        {
            if (tbx_Busqueda != null) tbx_Busqueda.Clear();
            if (cbx_Buscar != null && cbx_Buscar.Items.Count > 0) cbx_Buscar.SelectedIndex = 0;
            LoadClientsData();
        }
    }
}