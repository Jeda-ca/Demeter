using BLL.Interfaces;
using BLL.Services;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class Frm_GSalesAdmin : Form
    {
        private readonly IVentaService _ventaService;
        private readonly IClienteService _clienteService;
        private readonly IVendedorService _vendedorService;
        private readonly int _idAdminLogueado;

        public Frm_GSalesAdmin(int idAdminLogueado)
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
                _ventaService = new VentaService();
                _clienteService = new ClienteService();
                _vendedorService = new VendedorService();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico al inicializar servicios: {ex.Message}", "Error de Inicialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (ibtn_Buscar != null) ibtn_Buscar.Enabled = false;
                if (ibtn_StatusVenta != null) ibtn_StatusVenta.Enabled = false;
                if (ibtn_CancelVenta != null) ibtn_CancelVenta.Enabled = false;
                if (cbx_TipoV != null) cbx_TipoV.Enabled = false;
                // if (ibtn_AdminAddSale != null) ibtn_AdminAddSale.Enabled = false; // Si el botón ya existe en el designer
            }
        }

        private void Frm_GSalesAdmin_Load(object sender, EventArgs e)
        {
            if (_idAdminLogueado > 0 && _ventaService != null)
            {
                CargarTiposConsultaComboBox();
                panelFiltro.Visible = false;
                dtp_FInicio.Visible = false;
                dtp_FFin.Visible = false;
                tbx_Busqueda.Visible = false;
                LoadSalesData();
            }
        }

        private void CargarTiposConsultaComboBox()
        {
            if (cbx_TipoV == null) return;
            cbx_TipoV.Items.Clear();
            cbx_TipoV.Items.Add("-- Seleccione Tipo de Consulta --");
            cbx_TipoV.Items.Add("VENTAS GENERALES");
            cbx_TipoV.Items.Add("VENTAS POR VENDEDOR");
            cbx_TipoV.Items.Add("VENTAS POR CLIENTE");
            cbx_TipoV.SelectedIndex = 0;
        }

        private void cbx_TipoReport_SelectedIndexChanged(object sender, EventArgs e) // Nombre del evento en el Designer
        {
            UpdateFilterPanelVisibility();
        }

        private void cbx_FiltroReport_SelectedIndexChanged(object sender, EventArgs e) // Nombre del evento en el Designer
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

            if (selectedReportType == "VENTAS GENERALES")
            {
                panelFiltro.Visible = true;
                cbx_FiltroV.Enabled = true;
                cbx_FiltroV.Items.Add("-- Sin Filtro de Fecha --");
                cbx_FiltroV.Items.Add("Por Fecha Específica");
                cbx_FiltroV.Items.Add("Por Rango de Fechas");
                cbx_FiltroV.SelectedIndex = 0;
                UpdateDateTimePickerVisibility(); // Asegurar que los datepickers se oculten si es necesario
            }
            else if (selectedReportType == "VENTAS POR VENDEDOR" || selectedReportType == "VENTAS POR CLIENTE")
            {
                panelFiltro.Visible = true;
                cbx_FiltroV.Enabled = true;
                cbx_FiltroV.Items.Add("-- Sin Filtro de Fecha --");
                cbx_FiltroV.Items.Add("Por Fecha Específica");
                cbx_FiltroV.Items.Add("Por Rango de Fechas");
                cbx_FiltroV.SelectedIndex = 0;
                tbx_Busqueda.Visible = true;
                UpdateDateTimePickerVisibility(); // Asegurar que los datepickers se oculten si es necesario
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
                    ventas = _ventaService.ObtenerTodasLasVentasParaAdmin();
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("IdVenta", typeof(int));
                dt.Columns.Add("Fecha", typeof(DateTime));
                dt.Columns.Add("Subtotal", typeof(decimal));
                dt.Columns.Add("Descuento", typeof(decimal));
                dt.Columns.Add("Total", typeof(decimal));
                dt.Columns.Add("VendedorCodigo", typeof(string));
                dt.Columns.Add("ClienteNombre", typeof(string));
                dt.Columns.Add("Estado", typeof(string));
                dt.Columns.Add("Observaciones", typeof(string));

                foreach (var venta in ventas.OrderByDescending(v => v.FechaOcurrencia))
                {
                    dt.Rows.Add(
                        venta.IdVenta,
                        venta.FechaOcurrencia,
                        venta.Subtotal,
                        venta.Descuento,
                        venta.Total,
                        venta.Vendedor?.CodigoVendedor ?? "N/A",
                        (venta.Cliente != null) ? $"{venta.Cliente.Nombre} {venta.Cliente.Apellido}" : "N/A",
                        venta.EstadoVenta?.Nombre ?? "N/A",
                        venta.Observaciones
                    );
                }
                if (dgv_ListaVentas != null)
                {
                    dgv_ListaVentas.DataSource = dt;
                    if (dgv_ListaVentas.Columns["IdVenta"] != null) dgv_ListaVentas.Columns["IdVenta"].Visible = false;
                    if (dgv_ListaVentas.Columns["Subtotal"] != null) dgv_ListaVentas.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
                    if (dgv_ListaVentas.Columns["Descuento"] != null) dgv_ListaVentas.Columns["Descuento"].DefaultCellStyle.Format = "C2";
                    if (dgv_ListaVentas.Columns["Total"] != null) dgv_ListaVentas.Columns["Total"].DefaultCellStyle.Format = "C2";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos de ventas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                    case "VENTAS GENERALES":
                        if (filtroFecha == "Por Fecha Específica")
                            ventasResultado = _ventaService.ObtenerVentasPorRangoFechas(fechaInicio, fechaInicio.AddDays(1).AddTicks(-1));
                        else if (filtroFecha == "Por Rango de Fechas")
                            ventasResultado = _ventaService.ObtenerVentasPorRangoFechas(fechaInicio, fechaFin);
                        else
                            ventasResultado = _ventaService.ObtenerTodasLasVentasParaAdmin();
                        break;

                    case "VENTAS POR VENDEDOR":
                        if (string.IsNullOrWhiteSpace(textoBusqueda)) { MessageBox.Show("Ingrese un código de vendedor.", "Información Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                        var vendedor = _vendedorService.ObtenerVendedorPorCodigo(textoBusqueda);
                        if (vendedor == null) { MessageBox.Show("Vendedor no encontrado.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information); LoadSalesData(new List<Venta>()); return; }

                        if (filtroFecha == "Por Fecha Específica")
                            ventasResultado = _ventaService.ObtenerVentasPorVendedorYFechas(vendedor.IdVendedor, fechaInicio, fechaInicio.AddDays(1).AddTicks(-1));
                        else if (filtroFecha == "Por Rango de Fechas")
                            ventasResultado = _ventaService.ObtenerVentasPorVendedorYFechas(vendedor.IdVendedor, fechaInicio, fechaFin);
                        else
                            ventasResultado = _ventaService.ObtenerVentasPorVendedor(vendedor.IdVendedor);
                        break;

                    case "VENTAS POR CLIENTE":
                        if (string.IsNullOrWhiteSpace(textoBusqueda)) { MessageBox.Show("Ingrese nombre, apellido o documento del cliente.", "Información Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                        var clientes = _clienteService.BuscarClientesPorNombreOApellido(textoBusqueda).ToList();
                        if (!clientes.Any())
                        {
                            var clientePorDoc = _clienteService.ObtenerClientePorDocumento(0, textoBusqueda); // Asume que 0 busca en todos los tipos de doc
                            if (clientePorDoc != null) clientes.Add(clientePorDoc);
                        }
                        clientes = clientes.Where(c => c != null).Distinct().ToList();

                        if (!clientes.Any()) { MessageBox.Show("Cliente no encontrado.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information); LoadSalesData(new List<Venta>()); return; }

                        var ventasClientes = new List<Venta>();
                        // Primero obtener todas las ventas del periodo para no consultar la BD repetidamente
                        IEnumerable<Venta> ventasDelPeriodo;
                        if (filtroFecha == "Por Fecha Específica")
                            ventasDelPeriodo = _ventaService.ObtenerVentasPorRangoFechas(fechaInicio, fechaInicio.AddDays(1).AddTicks(-1));
                        else if (filtroFecha == "Por Rango de Fechas")
                            ventasDelPeriodo = _ventaService.ObtenerVentasPorRangoFechas(fechaInicio, fechaFin);
                        else
                            ventasDelPeriodo = _ventaService.ObtenerTodasLasVentasParaAdmin();

                        foreach (var cliente in clientes)
                        {
                            ventasClientes.AddRange(ventasDelPeriodo.Where(v => v.ClienteId == cliente.IdCliente));
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

        private void ibtn_StatusVenta_Click(object sender, EventArgs e)
        {
            if (dgv_ListaVentas.SelectedRows.Count > 0)
            {
                try
                {
                    int idVenta = Convert.ToInt32(dgv_ListaVentas.SelectedRows[0].Cells["IdVenta"].Value);
                    if (_ventaService == null) { MessageBox.Show("Servicio de ventas no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                    Venta ventaAModificar = _ventaService.ObtenerVentaPorId(idVenta);

                    if (ventaAModificar != null)
                    {
                        using (Frm_ModifyVentState frmModifyState = new Frm_ModifyVentState(ventaAModificar, _idAdminLogueado))
                        {
                            if (frmModifyState.ShowDialog() == DialogResult.OK)
                            {
                                ibtn_Buscar_Click(sender, e);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo encontrar la venta seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al modificar estado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una venta para modificar su estado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ibtn_CancelVenta_Click(object sender, EventArgs e)
        {
            if (dgv_ListaVentas.SelectedRows.Count > 0)
            {
                try
                {
                    int idVenta = Convert.ToInt32(dgv_ListaVentas.SelectedRows[0].Cells["IdVenta"].Value);
                    string clienteNombre = dgv_ListaVentas.SelectedRows[0].Cells["ClienteNombre"].Value?.ToString() ?? "N/A";
                    string estadoActual = dgv_ListaVentas.SelectedRows[0].Cells["Estado"].Value?.ToString() ?? "DESCONOCIDO";

                    if (estadoActual.Equals("CANCELADA", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("Esta venta ya ha sido cancelada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    DialogResult confirm = MessageBox.Show($"¿Está seguro que desea cancelar la venta ID {idVenta} del cliente '{clienteNombre}'?", "Confirmar Cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirm == DialogResult.Yes)
                    {
                        if (_ventaService == null) { MessageBox.Show("Servicio de ventas no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                        string motivo = $"Cancelada por Admin ID: {_idAdminLogueado} el {DateTime.Now.ToString("g")}";
                        string resultado = _ventaService.CancelarVenta(idVenta, motivo);
                        MessageBox.Show(resultado, "Cancelar Venta", MessageBoxButtons.OK, resultado.ToLower().Contains("exitosamente") ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                        ibtn_Buscar_Click(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cancelar venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una venta para cancelar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ibtn_Clear_Click(object sender, EventArgs e)
        {
            if (cbx_TipoV != null && cbx_TipoV.Items.Count > 0) cbx_TipoV.SelectedIndex = 0;
            // El evento SelectedIndexChanged de cbx_TipoV llamará a UpdateFilterPanelVisibility,
            // que a su vez limpiará cbx_FiltroV y tbx_Busqueda, y ocultará los filtros.
            LoadSalesData();
        }

        // NUEVO: Evento para el botón "Registrar Nueva Venta" que debes crear en el diseñador
        private void ibtn_AdminAddSale_Click(object sender, EventArgs e)
        {
            // Paso 1: Pedir al admin que seleccione un vendedor
            using (Frm_BusqVendedorParaVentaAdmin frmBusqVendedor = new Frm_BusqVendedorParaVentaAdmin())
            {
                if (frmBusqVendedor.ShowDialog() == DialogResult.OK)
                {
                    int idVendedorSeleccionadoTabla = frmBusqVendedor.SelectedSellerIdTabla; // PK de la tabla 'sellers'
                    int idUsuarioDelVendedor = frmBusqVendedor.SelectedSellerUserId;     // PK de la tabla 'users'

                    if (idVendedorSeleccionadoTabla > 0 && idUsuarioDelVendedor > 0)
                    {
                        // Paso 2: Abrir Frm_AddSaleVendor con los IDs del vendedor seleccionado
                        using (Frm_AddSaleVendor frmAddSale = new Frm_AddSaleVendor(idUsuarioDelVendedor, idVendedorSeleccionadoTabla))
                        {
                            if (frmAddSale.ShowDialog() == DialogResult.OK)
                            {
                                LoadSalesData(); // Recargar la lista de ventas del admin
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se seleccionó un vendedor válido.", "Operación Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
    }
}

    //public partial class Frm_GSalesAdmin : Form
    //{
    //    private readonly IVentaService _ventaService;
    //    private readonly IClienteService _clienteService;
    //    private readonly IVendedorService _vendedorService;
    //    // private readonly IEstadoVentaService _estadoVentaService; // No se usa directamente aquí, sino en Frm_ModifyVentState
    //    private readonly int _idAdminLogueado;

    //    public Frm_GSalesAdmin(int idAdminLogueado)
    //    {
    //        InitializeComponent();
    //        this.TopLevel = false;
    //        this.FormBorderStyle = FormBorderStyle.None;
    //        this.Dock = DockStyle.Fill;

    //        _idAdminLogueado = idAdminLogueado;

    //        if (_idAdminLogueado <= 0)
    //        {
    //            MessageBox.Show("Error: ID de administrador no válido. No se pueden realizar operaciones.", "Error de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //            this.BeginInvoke(new MethodInvoker(this.Close)); // Cerrar de forma segura
    //            return;
    //        }

    //        try
    //        {
    //            _ventaService = new VentaService();
    //            _clienteService = new ClienteService();
    //            _vendedorService = new VendedorService();
    //            // _estadoVentaService = new EstadoVentaService(); // No es necesario instanciarlo aquí
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show($"Error crítico al inicializar servicios: {ex.Message}", "Error de Inicialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //            // Deshabilitar controles si la inicialización falla
    //            if (ibtn_Buscar != null) ibtn_Buscar.Enabled = false;
    //            if (ibtn_StatusVenta != null) ibtn_StatusVenta.Enabled = false;
    //            if (ibtn_CancelVenta != null) ibtn_CancelVenta.Enabled = false;
    //            if (cbx_TipoV != null) cbx_TipoV.Enabled = false;
    //        }
    //    }

    //    private void Frm_GSalesAdmin_Load(object sender, EventArgs e)
    //    {
    //        if (_idAdminLogueado > 0 && _ventaService != null)
    //        {
    //            CargarTiposConsultaComboBox(); // Carga cbx_TipoV
    //            panelFiltro.Visible = false;
    //            dtp_FInicio.Visible = false;
    //            dtp_FFin.Visible = false;
    //            tbx_Busqueda.Visible = false;
    //            // Si tienes un label para el placeholder de tbx_Busqueda, ocúltalo también.
    //            // Ejemplo: if (label_tbx_busqueda_placeholder != null) label_tbx_busqueda_placeholder.Visible = false;
    //            LoadSalesData(); // Cargar todas las ventas por defecto
    //        }
    //    }

    //    private void CargarTiposConsultaComboBox()
    //    {
    //        if (cbx_TipoV == null) return;
    //        cbx_TipoV.Items.Clear();
    //        cbx_TipoV.Items.Add("-- Seleccione Tipo de Consulta --");
    //        cbx_TipoV.Items.Add("VENTAS GENERALES");
    //        cbx_TipoV.Items.Add("VENTAS POR VENDEDOR");
    //        cbx_TipoV.Items.Add("VENTAS POR CLIENTE");
    //        cbx_TipoV.SelectedIndex = 0;
    //    }

    //    // Event handler para cbx_TipoV (nombre del Designer.cs)
    //    private void cbx_TipoReport_SelectedIndexChanged(object sender, EventArgs e)
    //    {
    //        UpdateFilterPanelVisibility();
    //    }

    //    // Event handler para cbx_FiltroV (nombre del Designer.cs)
    //    private void cbx_FiltroReport_SelectedIndexChanged(object sender, EventArgs e)
    //    {
    //        UpdateDateTimePickerVisibility();
    //    }

    //    private void UpdateFilterPanelVisibility()
    //    {
    //        if (cbx_TipoV == null || cbx_FiltroV == null || panelFiltro == null || tbx_Busqueda == null) return;

    //        cbx_FiltroV.Items.Clear();
    //        cbx_FiltroV.Enabled = false;
    //        dtp_FInicio.Visible = false;
    //        dtp_FFin.Visible = false;
    //        tbx_Busqueda.Visible = false;
    //        tbx_Busqueda.Clear();
    //        panelFiltro.Visible = false;

    //        string selectedReportType = cbx_TipoV.SelectedItem?.ToString();

    //        if (selectedReportType == "VENTAS GENERALES")
    //        {
    //            panelFiltro.Visible = true;
    //            cbx_FiltroV.Enabled = true;
    //            cbx_FiltroV.Items.Add("-- Sin Filtro de Fecha --");
    //            cbx_FiltroV.Items.Add("Por Fecha Específica");
    //            cbx_FiltroV.Items.Add("Por Rango de Fechas");
    //            cbx_FiltroV.SelectedIndex = 0;
    //        }
    //        else if (selectedReportType == "VENTAS POR VENDEDOR" || selectedReportType == "VENTAS POR CLIENTE")
    //        {
    //            panelFiltro.Visible = true;
    //            cbx_FiltroV.Enabled = true;
    //            cbx_FiltroV.Items.Add("-- Sin Filtro de Fecha --");
    //            cbx_FiltroV.Items.Add("Por Fecha Específica");
    //            cbx_FiltroV.Items.Add("Por Rango de Fechas");
    //            cbx_FiltroV.SelectedIndex = 0;
    //            tbx_Busqueda.Visible = true;
    //        }
    //    }

    //    private void UpdateDateTimePickerVisibility()
    //    {
    //        if (cbx_FiltroV == null || dtp_FInicio == null || dtp_FFin == null) return;
    //        string selectedFilter = cbx_FiltroV.SelectedItem?.ToString();

    //        dtp_FInicio.Visible = false;
    //        dtp_FFin.Visible = false;

    //        if (selectedFilter == "Por Fecha Específica")
    //        {
    //            dtp_FInicio.Visible = true;
    //        }
    //        else if (selectedFilter == "Por Rango de Fechas")
    //        {
    //            dtp_FInicio.Visible = true;
    //            dtp_FFin.Visible = true;
    //        }
    //    }

    //    private void LoadSalesData(IEnumerable<Venta> ventas = null)
    //    {
    //        try
    //        {
    //            if (_ventaService == null) { MessageBox.Show("Servicio de ventas no inicializado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

    //            if (ventas == null)
    //            {
    //                ventas = _ventaService.ObtenerTodasLasVentasParaAdmin();
    //            }

    //            DataTable dt = new DataTable();
    //            dt.Columns.Add("IdVenta", typeof(int));
    //            dt.Columns.Add("Fecha", typeof(DateTime));
    //            dt.Columns.Add("Subtotal", typeof(decimal));
    //            dt.Columns.Add("Descuento", typeof(decimal));
    //            dt.Columns.Add("Total", typeof(decimal));
    //            dt.Columns.Add("VendedorCodigo", typeof(string));
    //            dt.Columns.Add("ClienteNombre", typeof(string));
    //            dt.Columns.Add("Estado", typeof(string));
    //            dt.Columns.Add("Observaciones", typeof(string));

    //            foreach (var venta in ventas.OrderByDescending(v => v.FechaOcurrencia)) // Ordenar por fecha más reciente
    //            {
    //                dt.Rows.Add(
    //                    venta.IdVenta,
    //                    venta.FechaOcurrencia,
    //                    venta.Subtotal,
    //                    venta.Descuento,
    //                    venta.Total,
    //                    venta.Vendedor?.CodigoVendedor ?? "N/A",
    //                    (venta.Cliente != null) ? $"{venta.Cliente.Nombre} {venta.Cliente.Apellido}" : "N/A",
    //                    venta.EstadoVenta?.Nombre ?? "N/A",
    //                    venta.Observaciones
    //                );
    //            }
    //            if (dgv_ListaVentas != null)
    //            {
    //                dgv_ListaVentas.DataSource = dt;
    //                if (dgv_ListaVentas.Columns["IdVenta"] != null) dgv_ListaVentas.Columns["IdVenta"].Visible = false;
    //                if (dgv_ListaVentas.Columns["Subtotal"] != null) dgv_ListaVentas.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
    //                if (dgv_ListaVentas.Columns["Descuento"] != null) dgv_ListaVentas.Columns["Descuento"].DefaultCellStyle.Format = "C2";
    //                if (dgv_ListaVentas.Columns["Total"] != null) dgv_ListaVentas.Columns["Total"].DefaultCellStyle.Format = "C2";
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show($"Error al cargar datos de ventas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //        }
    //    }

    //    private void ibtn_Buscar_Click(object sender, EventArgs e)
    //    {
    //        if (_ventaService == null || cbx_TipoV.SelectedItem == null) return;

    //        string tipoConsulta = cbx_TipoV.SelectedItem.ToString();
    //        string filtroFecha = cbx_FiltroV.SelectedItem?.ToString();
    //        string textoBusqueda = tbx_Busqueda.Text.Trim();
    //        DateTime fechaInicio = dtp_FInicio.Value.Date;
    //        DateTime fechaFin = dtp_FFin.Value.Date.AddDays(1).AddTicks(-1);

    //        IEnumerable<Venta> ventasResultado = new List<Venta>();

    //        try
    //        {
    //            switch (tipoConsulta)
    //            {
    //                case "VENTAS GENERALES":
    //                    if (filtroFecha == "Por Fecha Específica")
    //                        ventasResultado = _ventaService.ObtenerVentasPorRangoFechas(fechaInicio, fechaInicio.AddDays(1).AddTicks(-1));
    //                    else if (filtroFecha == "Por Rango de Fechas")
    //                        ventasResultado = _ventaService.ObtenerVentasPorRangoFechas(fechaInicio, fechaFin);
    //                    else
    //                        ventasResultado = _ventaService.ObtenerTodasLasVentasParaAdmin();
    //                    break;

    //                case "VENTAS POR VENDEDOR":
    //                    if (string.IsNullOrWhiteSpace(textoBusqueda)) { MessageBox.Show("Ingrese un código de vendedor.", "Información Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
    //                    var vendedor = _vendedorService.ObtenerVendedorPorCodigo(textoBusqueda);
    //                    if (vendedor == null) { MessageBox.Show("Vendedor no encontrado.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information); LoadSalesData(new List<Venta>()); return; }

    //                    if (filtroFecha == "Por Fecha Específica")
    //                        ventasResultado = _ventaService.ObtenerVentasPorVendedorYFechas(vendedor.IdVendedor, fechaInicio, fechaInicio.AddDays(1).AddTicks(-1));
    //                    else if (filtroFecha == "Por Rango de Fechas")
    //                        ventasResultado = _ventaService.ObtenerVentasPorVendedorYFechas(vendedor.IdVendedor, fechaInicio, fechaFin);
    //                    else
    //                        ventasResultado = _ventaService.ObtenerVentasPorVendedor(vendedor.IdVendedor);
    //                    break;

    //                case "VENTAS POR CLIENTE":
    //                    if (string.IsNullOrWhiteSpace(textoBusqueda)) { MessageBox.Show("Ingrese nombre, apellido o documento del cliente.", "Información Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

    //                    var clientes = _clienteService.BuscarClientesPorNombreOApellido(textoBusqueda).ToList();
    //                    // Intenta buscar también por número de documento si no se encontraron por nombre/apellido
    //                    if (!clientes.Any())
    //                    {
    //                        // Asumimos que el servicio puede manejar un tipo de documento 0 o null para buscar por número en todos los tipos
    //                        var clientePorDoc = _clienteService.ObtenerClientePorDocumento(0, textoBusqueda);
    //                        if (clientePorDoc != null) clientes.Add(clientePorDoc);
    //                    }
    //                    clientes = clientes.Where(c => c != null).Distinct().ToList();

    //                    if (!clientes.Any()) { MessageBox.Show("Cliente no encontrado.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information); LoadSalesData(new List<Venta>()); return; }

    //                    var ventasClientes = new List<Venta>();
    //                    foreach (var cliente in clientes)
    //                    {
    //                        IEnumerable<Venta> ventasDeCliente;
    //                        if (filtroFecha == "Por Fecha Específica")
    //                            ventasDeCliente = _ventaService.ObtenerVentasPorRangoFechas(fechaInicio, fechaInicio.AddDays(1).AddTicks(-1));
    //                        else if (filtroFecha == "Por Rango de Fechas")
    //                            ventasDeCliente = _ventaService.ObtenerVentasPorRangoFechas(fechaInicio, fechaFin);
    //                        else
    //                            ventasDeCliente = _ventaService.ObtenerVentasPorCliente(cliente.IdCliente);

    //                        ventasClientes.AddRange(ventasDeCliente.Where(v => v.ClienteId == cliente.IdCliente));
    //                    }
    //                    ventasResultado = ventasClientes.Distinct().OrderByDescending(v => v.FechaOcurrencia);
    //                    break;
    //                default:
    //                    LoadSalesData();
    //                    return;
    //            }
    //            LoadSalesData(ventasResultado);
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show($"Error al buscar ventas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //        }
    //    }

    //    private void ibtn_StatusVenta_Click(object sender, EventArgs e)
    //    {
    //        if (dgv_ListaVentas.SelectedRows.Count > 0)
    //        {
    //            try
    //            {
    //                int idVenta = Convert.ToInt32(dgv_ListaVentas.SelectedRows[0].Cells["IdVenta"].Value);
    //                if (_ventaService == null) { MessageBox.Show("Servicio de ventas no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
    //                Venta ventaAModificar = _ventaService.ObtenerVentaPorId(idVenta);

    //                if (ventaAModificar != null)
    //                {
    //                    using (Frm_ModifyVentState frmModifyState = new Frm_ModifyVentState(ventaAModificar, _idAdminLogueado))
    //                    {
    //                        if (frmModifyState.ShowDialog() == DialogResult.OK)
    //                        {
    //                            ibtn_Buscar_Click(sender, e); // Refrescar la vista actual
    //                        }
    //                    }
    //                }
    //                else
    //                {
    //                    MessageBox.Show("No se pudo encontrar la venta seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                MessageBox.Show($"Error al modificar estado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //            }
    //        }
    //        else
    //        {
    //            MessageBox.Show("Seleccione una venta para modificar su estado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
    //        }
    //    }

    //    private void ibtn_CancelVenta_Click(object sender, EventArgs e)
    //    {
    //        if (dgv_ListaVentas.SelectedRows.Count > 0)
    //        {
    //            try
    //            {
    //                int idVenta = Convert.ToInt32(dgv_ListaVentas.SelectedRows[0].Cells["IdVenta"].Value);
    //                string clienteNombre = dgv_ListaVentas.SelectedRows[0].Cells["ClienteNombre"].Value?.ToString() ?? "N/A";
    //                string estadoActual = dgv_ListaVentas.SelectedRows[0].Cells["Estado"].Value?.ToString() ?? "DESCONOCIDO";

    //                if (estadoActual.Equals("CANCELADA", StringComparison.OrdinalIgnoreCase))
    //                {
    //                    MessageBox.Show("Esta venta ya ha sido cancelada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
    //                    return;
    //                }

    //                DialogResult confirm = MessageBox.Show($"¿Está seguro que desea cancelar la venta ID {idVenta} del cliente '{clienteNombre}'?", "Confirmar Cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
    //                if (confirm == DialogResult.Yes)
    //                {
    //                    if (_ventaService == null) { MessageBox.Show("Servicio de ventas no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
    //                    string motivo = $"Cancelada por Admin ID: {_idAdminLogueado} el {DateTime.Now.ToString("g")}";
    //                    string resultado = _ventaService.CancelarVenta(idVenta, motivo);
    //                    MessageBox.Show(resultado, "Cancelar Venta", MessageBoxButtons.OK, resultado.ToLower().Contains("exitosamente") ? MessageBoxIcon.Information : MessageBoxIcon.Error);
    //                    ibtn_Buscar_Click(sender, e); // Refrescar la vista actual
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                MessageBox.Show($"Error al cancelar venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //            }
    //        }
    //        else
    //        {
    //            MessageBox.Show("Seleccione una venta para cancelar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
    //        }
    //    }

    //    private void ibtn_Clear_Click(object sender, EventArgs e)
    //    {
    //        if (cbx_TipoV != null && cbx_TipoV.Items.Count > 0) cbx_TipoV.SelectedIndex = 0;
    //        // El evento SelectedIndexChanged de cbx_TipoV llamará a UpdateFilterPanelVisibility,
    //        // que a su vez limpiará cbx_FiltroV y tbx_Busqueda, y ocultará los filtros.
    //        LoadSalesData(); // Cargar todas las ventas
    //    }
    //}
