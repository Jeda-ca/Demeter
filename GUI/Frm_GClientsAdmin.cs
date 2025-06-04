using BLL.Interfaces;
using BLL.Services;
using ENTITY;
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
        private readonly IClienteService _clienteService;
        private readonly ITipoDocumentoService _tipoDocumentoService;
        private readonly int _idAdminLogueado;

        public Frm_GClientsAdmin(int idAdminLogueado)
        {
            InitializeComponent();
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            _idAdminLogueado = idAdminLogueado;

            if (_idAdminLogueado <= 0)
            {
                MessageBox.Show("Error: ID de administrador no válido. No se pueden realizar operaciones.", "Error de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new MethodInvoker(this.Close));
                return;
            }

            try
            {
                _clienteService = new ClienteService();
                _tipoDocumentoService = new TipoDocumentoService();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico al inicializar servicios: {ex.Message}", "Error de Inicialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (ibtn_ModifyInfo != null) ibtn_ModifyInfo.Enabled = false;
                if (ibtn_Delete != null) ibtn_Delete.Enabled = false;
                if (ibtn_Buscar != null) ibtn_Buscar.Enabled = false;
                // Deshabilitar el nuevo botón si se añade aquí
                // if (ibtn_AddClientAdmin != null) ibtn_AddClientAdmin.Enabled = false; 
            }
        }

        private void Frm_GClientsAdmin_Load(object sender, EventArgs e)
        {
            if (_idAdminLogueado > 0 && _clienteService != null)
            {
                CargarFiltrosComboBox();
                LoadClientsData(true);
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
            cbx_Buscar.Items.Add("Estado (Activo/Inactivo)");
            cbx_Buscar.SelectedIndex = 0;
        }

        private void LoadClientsData(bool soloActivos = false)
        {
            try
            {
                if (_clienteService == null)
                {
                    MessageBox.Show("Servicio de clientes no inicializado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                IEnumerable<Cliente> clientes;
                if (soloActivos && !(cbx_Buscar.SelectedItem?.ToString() == "Estado (Activo/Inactivo)" && tbx_Busqueda.Text.Trim().Equals("Inactivo", StringComparison.OrdinalIgnoreCase)))
                {
                    clientes = _clienteService.ObtenerTodosLosClientes().Where(c => c.Activo).ToList();
                }
                else
                {
                    clientes = _clienteService.ObtenerTodosLosClientes().ToList();
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("IdCliente", typeof(int));
                dt.Columns.Add("NombreCompleto", typeof(string));
                dt.Columns.Add("TipoDocumento", typeof(string));
                dt.Columns.Add("NumeroDocumento", typeof(string));
                dt.Columns.Add("Telefono", typeof(string));
                dt.Columns.Add("Email", typeof(string));
                dt.Columns.Add("Estado", typeof(string));

                foreach (var cliente in clientes.OrderBy(c => c.Apellido).ThenBy(c => c.Nombre))
                {
                    string nombreTipoDoc = cliente.TipoDocumento?.Nombre ?? _tipoDocumentoService?.ObtenerPorId(cliente.TipoDocumentoId)?.Nombre ?? cliente.TipoDocumentoId.ToString();

                    dt.Rows.Add(
                        cliente.IdCliente,
                        $"{cliente.Nombre} {cliente.Apellido}",
                        nombreTipoDoc,
                        cliente.NumeroDocumento,
                        cliente.Telefono,
                        cliente.Correo,
                        cliente.Activo ? "Activo" : "Inactivo"
                    );
                }

                if (dgv_ListaClientes != null)
                {
                    dgv_ListaClientes.DataSource = dt;

                    if (dgv_ListaClientes.Columns["IdCliente"] != null)
                        dgv_ListaClientes.Columns["IdCliente"].Visible = false;

                    bool mostrarColumnaEstadoActual = (cbx_Buscar.SelectedItem?.ToString() == "Estado (Activo/Inactivo)");
                    if (dgv_ListaClientes.Columns["Estado"] != null)
                        dgv_ListaClientes.Columns["Estado"].Visible = !soloActivos || mostrarColumnaEstadoActual;
                }
            }
            catch (ApplicationException appEx)
            {
                MessageBox.Show(appEx.Message, "Error de Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos de clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibtn_AddClientAdmin_Click(object sender, EventArgs e)
        {
            // El constructor de Frm_AddClientVendor espera el ID del usuario que realiza la operación.
            // En este caso, es el administrador logueado.
            using (Frm_AddClientVendor frmAddClient = new Frm_AddClientVendor(_idAdminLogueado))
            {
                if (frmAddClient.ShowDialog() == DialogResult.OK)
                {
                    LoadClientsData(true); // Recargar la lista, mostrando activos por defecto
                }
            }
        }

        private void ibtn_ModifyInfo_Click(object sender, EventArgs e)
        {
            if (dgv_ListaClientes.SelectedRows.Count > 0)
            {
                try
                {
                    int idClienteSeleccionado = Convert.ToInt32(dgv_ListaClientes.SelectedRows[0].Cells["IdCliente"].Value);
                    if (_clienteService == null) { MessageBox.Show("Servicio de clientes no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                    Cliente clienteAModificar = _clienteService.ObtenerClientePorId(idClienteSeleccionado);

                    if (clienteAModificar != null)
                    {
                        // Pasar el cliente y el ID del admin al formulario de modificación
                        using (Frm_ModifyClientAdmin frmModify = new Frm_ModifyClientAdmin(clienteAModificar, _idAdminLogueado))
                        {
                            if (frmModify.ShowDialog() == DialogResult.OK)
                            {
                                LoadClientsData(true);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo encontrar el cliente seleccionado para modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al preparar modificación del cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente de la lista para modificar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ibtn_Delete_Click(object sender, EventArgs e)
        {
            if (dgv_ListaClientes.SelectedRows.Count > 0)
            {
                try
                {
                    int idCliente = Convert.ToInt32(dgv_ListaClientes.SelectedRows[0].Cells["IdCliente"].Value);
                    string nombreCliente = dgv_ListaClientes.SelectedRows[0].Cells["NombreCompleto"].Value.ToString();
                    string estadoActualStr = dgv_ListaClientes.SelectedRows[0].Cells["Estado"].Value.ToString();
                    bool estaActivo = estadoActualStr.Equals("Activo", StringComparison.OrdinalIgnoreCase);

                    // El botón "Eliminar" ahora solo inactiva. La reactivación se hará desde Frm_ModifyClientAdmin.
                    if (!estaActivo)
                    {
                        MessageBox.Show($"El cliente '{nombreCliente}' ya está inactivo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    DialogResult confirmacion = MessageBox.Show($"¿Está seguro que desea inactivar al cliente '{nombreCliente}'?", $"Confirmar Inactivación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmacion == DialogResult.Yes)
                    {
                        if (_clienteService == null) { MessageBox.Show("Servicio de clientes no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                        bool resultadoOp = _clienteService.CambiarEstadoActividadCliente(idCliente, false); // false para inactivar

                        string mensajeResultado = resultadoOp ?
                            $"Cliente '{nombreCliente}' inactivado exitosamente." :
                            $"No se pudo inactivar al cliente '{nombreCliente}'.";

                        MessageBox.Show(mensajeResultado, "Inactivar Cliente", MessageBoxButtons.OK,
                                        resultadoOp ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                        LoadClientsData(true); // Recargar mostrando activos (el inactivado ya no aparecerá por defecto)
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al inactivar cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente de la lista.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ibtn_Buscar_Click(object sender, EventArgs e)
        {
            string criterio = cbx_Buscar.SelectedItem?.ToString();
            string textoBusqueda = tbx_Busqueda.Text.Trim();
            IEnumerable<Cliente> clientesFiltrados = new List<Cliente>();
            bool soloActivosParaEstaBusqueda = true; // Por defecto, las búsquedas muestran activos

            if (string.IsNullOrEmpty(criterio) || criterio == "-- Seleccione Criterio --")
            {
                LoadClientsData(true);
                return;
            }
            if (_clienteService == null) { MessageBox.Show("Servicio de clientes no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            try
            {
                var todosLosClientes = _clienteService.ObtenerTodosLosClientes(); // Obtener todos para filtrar

                switch (criterio)
                {
                    case "Nombre o Apellido":
                        if (!string.IsNullOrWhiteSpace(textoBusqueda))
                            clientesFiltrados = todosLosClientes.Where(c =>
                                (c.Nombre.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                 c.Apellido.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0) && c.Activo
                            ).ToList();
                        else { LoadClientsData(true); return; }
                        break;
                    case "Número de Documento":
                        if (!string.IsNullOrWhiteSpace(textoBusqueda))
                            clientesFiltrados = todosLosClientes.Where(c => c.NumeroDocumento.Contains(textoBusqueda) && c.Activo).ToList();
                        else { LoadClientsData(true); return; }
                        break;
                    case "Email":
                        if (!string.IsNullOrWhiteSpace(textoBusqueda))
                            clientesFiltrados = todosLosClientes.Where(c => c.Correo != null && c.Correo.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0 && c.Activo).ToList();
                        else { LoadClientsData(true); return; }
                        break;
                    case "Estado (Activo/Inactivo)":
                        soloActivosParaEstaBusqueda = false; // Permitir ver inactivos
                        if (textoBusqueda.Equals("Activo", StringComparison.OrdinalIgnoreCase))
                            clientesFiltrados = todosLosClientes.Where(c => c.Activo).ToList();
                        else if (textoBusqueda.Equals("Inactivo", StringComparison.OrdinalIgnoreCase))
                            clientesFiltrados = todosLosClientes.Where(c => !c.Activo).ToList();
                        else if (string.IsNullOrWhiteSpace(textoBusqueda)) // Si el texto está vacío pero el filtro es Estado, mostrar todos.
                            clientesFiltrados = todosLosClientes.ToList();
                        else
                        {
                            MessageBox.Show("Para filtrar por estado, ingrese 'Activo', 'Inactivo' o deje el campo vacío para ver todos.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadClientsData(true); return;
                        }
                        break;
                    default:
                        clientesFiltrados = todosLosClientes.Where(c => c.Activo).ToList();
                        break;
                }
                LoadClientsData(soloActivosParaEstaBusqueda, clientesFiltrados);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadClientsData(bool soloActivos, IEnumerable<Cliente> clientesFiltrados)
        {
            try
            {
                if (_clienteService == null)
                {
                    MessageBox.Show("Servicio de clientes no inicializado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("IdCliente", typeof(int));
                dt.Columns.Add("NombreCompleto", typeof(string));
                dt.Columns.Add("TipoDocumento", typeof(string));
                dt.Columns.Add("NumeroDocumento", typeof(string));
                dt.Columns.Add("Telefono", typeof(string));
                dt.Columns.Add("Email", typeof(string));
                dt.Columns.Add("Estado", typeof(string));

                foreach (var cliente in clientesFiltrados.OrderBy(c => c.Apellido).ThenBy(c => c.Nombre))
                {
                    string nombreTipoDoc = cliente.TipoDocumento?.Nombre ?? _tipoDocumentoService?.ObtenerPorId(cliente.TipoDocumentoId)?.Nombre ?? cliente.TipoDocumentoId.ToString();
                    dt.Rows.Add(
                        cliente.IdCliente,
                        $"{cliente.Nombre} {cliente.Apellido}",
                        nombreTipoDoc,
                        cliente.NumeroDocumento,
                        cliente.Telefono,
                        cliente.Correo,
                        cliente.Activo ? "Activo" : "Inactivo"
                    );
                }

                if (dgv_ListaClientes != null)
                {
                    dgv_ListaClientes.DataSource = dt;

                    if (dgv_ListaClientes.Columns["IdCliente"] != null)
                        dgv_ListaClientes.Columns["IdCliente"].Visible = false;

                    bool mostrarColumnaEstadoActual = (cbx_Buscar.SelectedItem?.ToString() == "Estado (Activo/Inactivo)");
                    if (dgv_ListaClientes.Columns["Estado"] != null)
                        dgv_ListaClientes.Columns["Estado"].Visible = !soloActivos || mostrarColumnaEstadoActual;
                }
            }
            catch (ApplicationException appEx)
            {
                MessageBox.Show(appEx.Message, "Error de Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos de clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ibtn_Clear_Click(object sender, EventArgs e)
        {
            if (tbx_Busqueda != null) tbx_Busqueda.Clear();
            if (cbx_Buscar != null && cbx_Buscar.Items.Count > 0) cbx_Buscar.SelectedIndex = 0;
            LoadClientsData(true);
        }
    }
}