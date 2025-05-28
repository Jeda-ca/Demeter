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
    public partial class Frm_GSalesVendor : Form
    {
        private readonly int _idUsuarioVendedorLogueado;
        private readonly int _idVendedorTabla;
        private IVentaService _ventaService;
        private IClienteService _clienteService;
        // private IProductoService _productoService; // Se instanciará en Frm_AddSaleVendor

        public Frm_GSalesVendor(int idUsuarioVendedor, int idVendedorTabla)
        {
            InitializeComponent();
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            _idUsuarioVendedorLogueado = idUsuarioVendedor;
            _idVendedorTabla = idVendedorTabla;

            if (_idUsuarioVendedorLogueado <= 0 || _idVendedorTabla <= 0)
            {
                MessageBox.Show("Error: Información de vendedor no válida para el gestor de ventas.", "Error de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new MethodInvoker(this.Close));
                return;
            }

            try
            {
                _ventaService = new VentaService();
                _clienteService = new ClienteService();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar servicios en Gestor de Ventas Vendedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Deshabilitar controles principales si falla
                if (ibtn_Add != null) ibtn_Add.Enabled = false;
                if (ibtn_Buscar != null) ibtn_Buscar.Enabled = false;
                if (ibtn_Clear != null) ibtn_Clear.Enabled = false;
                if (cbx_TipoV != null) cbx_TipoV.Enabled = false;
                if (cbx_FiltroV != null) cbx_FiltroV.Enabled = false;
            }
        }

        private void Frm_GSalesVendor_Load(object sender, EventArgs e)
        {
            if (_idUsuarioVendedorLogueado > 0 && _idVendedorTabla > 0 && _ventaService != null)
            {
                CargarTiposConsultaComboBox(); // Para cbx_TipoV
                // El panelFiltro, DateTimePickers y tbx_Busqueda se manejan en UpdateFilterPanelVisibility
                UpdateFilterPanelVisibility(); // Llamar para establecer el estado inicial correcto
                LoadSalesData();
            }
        }

        private void CargarTiposConsultaComboBox()
        {
            if (cbx_TipoV == null) return;
            cbx_TipoV.Items.Clear();
            cbx_TipoV.Items.Add("-- Seleccione Tipo de Consulta --");
            cbx_TipoV.Items.Add("MIS VENTAS GENERALES");
            cbx_TipoV.Items.Add("MIS VENTAS POR CLIENTE");
            cbx_TipoV.SelectedIndex = 0;
        }

        // Event handler para cbx_TipoV 
        // Asegúrate que el nombre de este método coincida con Frm_GSalesVendor.Designer.cs
        // Tu Designer espera: cbx_TipoReport_SelectedIndexChanged
        private void cbx_TipoV_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFilterPanelVisibility();
        }

        // Event handler para cbx_FiltroV 
        // Asegúrate que el nombre de este método coincida con Frm_GSalesVendor.Designer.cs
        // Tu Designer espera: cbx_FiltroReport_SelectedIndexChanged O cbx_FiltroV_SelectedIndexChanged
        private void cbx_FiltroV_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDateTimePickerVisibility();
        }

        private void UpdateFilterPanelVisibility()
        {
            if (cbx_TipoV == null || cbx_FiltroV == null || panelFiltro == null || tbx_Busqueda == null) return;

            cbx_FiltroV.Items.Clear();
            cbx_FiltroV.Enabled = false;
            dtp_FInicio.Visible = false;
            dtp_FFin.Visible = false;
            tbx_Busqueda.Visible = false;
            tbx_Busqueda.Clear();
            panelFiltro.Visible = false;

            string selectedReportType = cbx_TipoV.SelectedItem?.ToString();

            if (selectedReportType == "MIS VENTAS GENERALES" || selectedReportType == "MIS VENTAS POR CLIENTE")
            {
                panelFiltro.Visible = true;
                cbx_FiltroV.Enabled = true;
                cbx_FiltroV.Items.Add("-- Sin Filtro de Fecha --");
                cbx_FiltroV.Items.Add("Por Fecha Específica");
                cbx_FiltroV.Items.Add("Por Rango de Fechas");
                cbx_FiltroV.SelectedIndex = 0;
                if (selectedReportType == "MIS VENTAS POR CLIENTE")
                {
                    tbx_Busqueda.Visible = true;
                }
            }
        }

        private void UpdateDateTimePickerVisibility()
        {
            if (cbx_FiltroV == null || dtp_FInicio == null || dtp_FFin == null) return;
            string selectedFilter = cbx_FiltroV.SelectedItem?.ToString();

            dtp_FInicio.Visible = false;
            dtp_FFin.Visible = false;

            if (selectedFilter == "Por Fecha Específica")
            {
                dtp_FInicio.Visible = true;
            }
            else if (selectedFilter == "Por Rango de Fechas")
            {
                dtp_FInicio.Visible = true;
                dtp_FFin.Visible = true;
            }
        }
        private void LoadSalesData(IEnumerable<Venta> ventas = null)
        {
            try
            {
                if (_ventaService == null) { MessageBox.Show("Servicio de ventas no inicializado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                if (ventas == null)
                {
                    ventas = _ventaService.ObtenerVentasPorVendedor(_idVendedorTabla);
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("IdVenta", typeof(int));
                dt.Columns.Add("Fecha", typeof(DateTime));
                dt.Columns.Add("Total", typeof(decimal));
                dt.Columns.Add("ClienteNombre", typeof(string));
                dt.Columns.Add("Estado", typeof(string));

                foreach (var venta in ventas.OrderByDescending(v => v.FechaOcurrencia))
                {
                    dt.Rows.Add(
                        venta.IdVenta,
                        venta.FechaOcurrencia,
                        venta.Total,
                        (venta.Cliente != null) ? $"{venta.Cliente.Nombre} {venta.Cliente.Apellido}" : "N/A",
                        venta.EstadoVenta?.Nombre ?? "N/A"
                    );
                }
                if (dgv_ListaVentas != null)
                {
                    dgv_ListaVentas.DataSource = dt;
                    if (dgv_ListaVentas.Columns["IdVenta"] != null) dgv_ListaVentas.Columns["IdVenta"].Visible = false;
                    if (dgv_ListaVentas.Columns["Total"] != null) dgv_ListaVentas.Columns["Total"].DefaultCellStyle.Format = "C2";
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error al cargar ventas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        // Evento para el botón Agregar Venta (ibtn_Add)
        private void ibtn_Add_Click(object sender, EventArgs e)
        {
            using (Frm_AddSaleVendor frmAddSale = new Frm_AddSaleVendor(_idUsuarioVendedorLogueado, _idVendedorTabla))
            {
                if (frmAddSale.ShowDialog() == DialogResult.OK)
                {
                    LoadSalesData();
                }
            }
        }

        // Evento para el botón Buscar (ibtn_Buscar)
        private void ibtn_Buscar_Click(object sender, EventArgs e)
        {
            if (_ventaService == null || cbx_TipoV.SelectedItem == null) return;

            string tipoConsulta = cbx_TipoV.SelectedItem.ToString();
            string filtroFecha = cbx_FiltroV.SelectedItem?.ToString();
            string textoBusqueda = tbx_Busqueda.Text.Trim();
            DateTime fechaInicio = dtp_FInicio.Value.Date;
            DateTime fechaFin = dtp_FFin.Value.Date.AddDays(1).AddTicks(-1);

            IEnumerable<Venta> ventasResultado = new List<Venta>();

            try
            {
                switch (tipoConsulta)
                {
                    case "MIS VENTAS GENERALES":
                        if (filtroFecha == "Por Fecha Específica")
                            ventasResultado = _ventaService.ObtenerVentasPorVendedorYFechas(_idVendedorTabla, fechaInicio, fechaInicio.AddDays(1).AddTicks(-1));
                        else if (filtroFecha == "Por Rango de Fechas")
                            ventasResultado = _ventaService.ObtenerVentasPorVendedorYFechas(_idVendedorTabla, fechaInicio, fechaFin);
                        else
                            ventasResultado = _ventaService.ObtenerVentasPorVendedor(_idVendedorTabla);
                        break;

                    case "MIS VENTAS POR CLIENTE":
                        if (string.IsNullOrWhiteSpace(textoBusqueda)) { MessageBox.Show("Ingrese nombre, apellido o documento del cliente.", "Información Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning); LoadSalesData(new List<Venta>()); return; }

                        var clientes = _clienteService.BuscarClientesPorNombreOApellido(textoBusqueda).ToList();
                        var clientePorDoc = _clienteService.ObtenerClientePorDocumento(0, textoBusqueda);
                        if (clientePorDoc != null && !clientes.Any(c => c.IdCliente == clientePorDoc.IdCliente))
                        {
                            clientes.Add(clientePorDoc);
                        }
                        clientes = clientes.Where(c => c != null).Distinct().ToList();

                        if (!clientes.Any()) { MessageBox.Show("Cliente no encontrado.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information); LoadSalesData(new List<Venta>()); return; }

                        var ventasClientes = new List<Venta>();
                        var ventasDelVendedor = _ventaService.ObtenerVentasPorVendedor(_idVendedorTabla);

                        foreach (var cliente in clientes)
                        {
                            IEnumerable<Venta> ventasFiltradasPorFecha;
                            if (filtroFecha == "Por Fecha Específica")
                                ventasFiltradasPorFecha = ventasDelVendedor.Where(v => v.FechaOcurrencia.Date == fechaInicio.Date);
                            else if (filtroFecha == "Por Rango de Fechas")
                                ventasFiltradasPorFecha = ventasDelVendedor.Where(v => v.FechaOcurrencia.Date >= fechaInicio.Date && v.FechaOcurrencia.Date <= fechaFin.Date);
                            else
                                ventasFiltradasPorFecha = ventasDelVendedor;

                            ventasClientes.AddRange(ventasFiltradasPorFecha.Where(v => v.ClienteId == cliente.IdCliente));
                        }
                        ventasResultado = ventasClientes.Distinct().OrderByDescending(v => v.FechaOcurrencia);
                        break;
                    default:
                        LoadSalesData();
                        return;
                }
                LoadSalesData(ventasResultado);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar ventas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Evento para el botón Limpiar (ibtn_Clear)
        private void ibtn_Clear_Click(object sender, EventArgs e)
        {
            if (cbx_TipoV != null && cbx_TipoV.Items.Count > 0) cbx_TipoV.SelectedIndex = 0;
            // El cambio en cbx_TipoV debería disparar UpdateFilterPanelVisibility
            // que a su vez limpia cbx_FiltroV y oculta/limpia otros filtros.
            // Si no lo hace automáticamente, llama explícitamente:
            // UpdateFilterPanelVisibility();
            LoadSalesData();
        }
    }
}