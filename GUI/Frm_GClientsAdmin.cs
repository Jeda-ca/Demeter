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
        private readonly ITipoDocumentoService _tipoDocumentoService; // Para mostrar nombre de tipo doc
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
                this.BeginInvoke(new MethodInvoker(this.Close)); // Cerrar de forma segura
                return;
            }

            try
            {
                _clienteService = new ClienteService();
                _tipoDocumentoService = new TipoDocumentoService(); // Para obtener nombres de TipoDocumento
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico al inicializar servicios: {ex.Message}", "Error de Inicialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Deshabilitar controles si la inicialización falla
                if (ibtn_ModifyInfo != null) ibtn_ModifyInfo.Enabled = false;
                if (ibtn_Delete != null) ibtn_Delete.Enabled = false;
                if (ibtn_Buscar != null) ibtn_Buscar.Enabled = false;
            }
        }

        private void Frm_GClientsAdmin_Load(object sender, EventArgs e)
        {
            if (_idAdminLogueado > 0 && _clienteService != null)
            {
                CargarFiltrosComboBox();
                LoadClientsData(true); // Cargar solo activos por defecto
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
                if (soloActivos)
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

                foreach (var cliente in clientes)
                {
                    // Para obtener el nombre del TipoDocumento, necesitamos la entidad TipoDocumento poblada.
                    // Si _clienteService.ObtenerTodosLosClientes() ya incluye esto (por eager loading en DAL), está bien.
                    // Si no, necesitaríamos llamar a _tipoDocumentoService.ObtenerPorId(cliente.TipoDocumentoId).Nombre
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
                        // Usar el nombre de tu formulario de modificación: Frm_ModifyClient o Frm_ModifyClientAdmin
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

        private void ibtn_Delete_Click(object sender, EventArgs e) // Cambia estado Activo/Inactivo
        {
            if (dgv_ListaClientes.SelectedRows.Count > 0)
            {
                try
                {
                    int idCliente = Convert.ToInt32(dgv_ListaClientes.SelectedRows[0].Cells["IdCliente"].Value);
                    string nombreCliente = dgv_ListaClientes.SelectedRows[0].Cells["NombreCompleto"].Value.ToString();
                    string estadoActualStr = dgv_ListaClientes.SelectedRows[0].Cells["Estado"].Value.ToString();
                    bool estaActivo = estadoActualStr.Equals("Activo", StringComparison.OrdinalIgnoreCase);

                    string accion = estaActivo ? "inactivar" : "reactivar";
                    DialogResult confirmacion = MessageBox.Show($"¿Está seguro que desea {accion} al cliente '{nombreCliente}'?", $"Confirmar {accion}", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmacion == DialogResult.Yes)
                    {
                        if (_clienteService == null) { MessageBox.Show("Servicio de clientes no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                        bool resultadoOp = _clienteService.CambiarEstadoActividadCliente(idCliente, !estaActivo);

                        string mensajeResultado = resultadoOp ?
                            $"Estado del cliente '{nombreCliente}' cambiado exitosamente a {(!estaActivo ? "Activo" : "Inactivo")}." :
                            $"No se pudo cambiar el estado del cliente '{nombreCliente}'.";

                        MessageBox.Show(mensajeResultado, "Cambio de Estado", MessageBoxButtons.OK,
                                        resultadoOp ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                        LoadClientsData(true);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cambiar estado del cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            bool mostrarColumnaEstadoAlBuscar = false;

            if (string.IsNullOrEmpty(criterio) || criterio == "-- Seleccione Criterio --")
            {
                LoadClientsData(true);
                return;
            }
            if (_clienteService == null) { MessageBox.Show("Servicio de clientes no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            try
            {
                var todosLosClientes = _clienteService.ObtenerTodosLosClientes();

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
                        mostrarColumnaEstadoAlBuscar = true;
                        if (textoBusqueda.Equals("Activo", StringComparison.OrdinalIgnoreCase))
                            clientesFiltrados = todosLosClientes.Where(c => c.Activo).ToList();
                        else if (textoBusqueda.Equals("Inactivo", StringComparison.OrdinalIgnoreCase))
                            clientesFiltrados = todosLosClientes.Where(c => !c.Activo).ToList();
                        else if (string.IsNullOrWhiteSpace(textoBusqueda))
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

                DataTable dt = new DataTable();
                dt.Columns.Add("IdCliente", typeof(int));
                dt.Columns.Add("NombreCompleto", typeof(string));
                dt.Columns.Add("TipoDocumento", typeof(string));
                dt.Columns.Add("NumeroDocumento", typeof(string));
                dt.Columns.Add("Telefono", typeof(string));
                dt.Columns.Add("Email", typeof(string));
                dt.Columns.Add("Estado", typeof(string));

                foreach (var cliente in clientesFiltrados)
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
                dgv_ListaClientes.DataSource = dt;

                if (dgv_ListaClientes.Columns["IdCliente"] != null)
                    dgv_ListaClientes.Columns["IdCliente"].Visible = false;
                if (dgv_ListaClientes.Columns["Estado"] != null)
                    dgv_ListaClientes.Columns["Estado"].Visible = mostrarColumnaEstadoAlBuscar;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Asegúrate de que el botón Limpiar(ibtn_Clear) esté conectado a este evento en el Designer.cs
        private void ibtn_Clear_Click(object sender, EventArgs e)
        {
            if (tbx_Busqueda != null) tbx_Busqueda.Clear();
            if (cbx_Buscar != null && cbx_Buscar.Items.Count > 0) cbx_Buscar.SelectedIndex = 0;
            LoadClientsData(true); // Recargar solo activos
        }

    }
}