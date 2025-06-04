using BLL.Interfaces;
using BLL.Services;
using ENTITY;
using GUI.Helpers;
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
    public partial class Frm_SalesByVendorReport : Form
    {
        private readonly IReporteService _reporteService;
        private readonly IVendedorService _vendedorService;
        private readonly int _idAdminLogueado;
        private Vendedor _vendedorSeleccionadoParaReporte = null;
        private IEnumerable<Venta> _ventasActualesDelVendedor; // Para guardar los datos del reporte

        public Frm_SalesByVendorReport(int idAdminLogueado)
        {
            InitializeComponent();
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            _idAdminLogueado = idAdminLogueado;
            _ventasActualesDelVendedor = new List<Venta>(); // Inicializar

            if (_idAdminLogueado <= 0)
            {
                MessageBox.Show("Error: ID de administrador no válido.", "Error de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new MethodInvoker(this.Close));
                return;
            }

            try
            {
                _reporteService = new ReporteService();
                _vendedorService = new VendedorService();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico al inicializar servicios: {ex.Message}", "Error de Inicialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (ibtn_Buscar != null) ibtn_Buscar.Enabled = false;
                if (ibtn_Add != null) ibtn_Add.Enabled = false; // Este es el botón "Generar PDF"
                if (cbx_FiltroV != null) cbx_FiltroV.Enabled = false;
                if (tbx_Busqueda != null) tbx_Busqueda.Enabled = false;
            }
        }

        private void Frm_SalesByVendorReport_Load(object sender, EventArgs e)
        {
            if (_idAdminLogueado > 0 && _reporteService != null)
            {
                ConfigurarControlesIniciales();
                LimpiarGrillaYDatos(); // Limpia la grilla y _ventasActualesDelVendedor
            }
        }

        private void ConfigurarControlesIniciales()
        {
            if (cbx_FiltroV != null)
            {
                cbx_FiltroV.Items.Clear();
                cbx_FiltroV.Items.Add("-- Sin Filtro de Fecha --");
                cbx_FiltroV.Items.Add("Fecha Específica");
                cbx_FiltroV.Items.Add("Rango de Fechas");
                cbx_FiltroV.SelectedIndex = 0;
            }

            if (dtp_FInicio != null)
            {
                dtp_FInicio.Value = DateTime.Today.AddMonths(-1);
                dtp_FInicio.Visible = false;
            }
            if (dtp_FFin != null)
            {
                dtp_FFin.Value = DateTime.Today;
                dtp_FFin.Visible = false;
            }
            if (tbx_Busqueda != null) tbx_Busqueda.Text = "";
        }

        private void LimpiarGrillaYDatos()
        {
            if (dgv_ReportesVentxVend != null) dgv_ReportesVentxVend.DataSource = null;
            _ventasActualesDelVendedor = new List<Venta>();
        }

        private void cbx_FiltroV_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDateTimePickerVisibility();
        }

        private void UpdateDateTimePickerVisibility()
        {
            if (cbx_FiltroV == null || dtp_FInicio == null || dtp_FFin == null) return;
            string selectedFilter = cbx_FiltroV.SelectedItem?.ToString();

            dtp_FInicio.Visible = false;
            dtp_FFin.Visible = false;

            if (selectedFilter == "Fecha Específica")
            {
                dtp_FInicio.Visible = true;
            }
            else if (selectedFilter == "Rango de Fechas")
            {
                dtp_FInicio.Visible = true;
                dtp_FFin.Visible = true;
            }
        }

        private void ibtn_Buscar_Click(object sender, EventArgs e)
        {
            // Este botón ahora solo carga/filtra los datos en el DataGridView.
            // La exportación a PDF se hará con el botón "Generar" (ibtn_Add).
            CargarDatosReporteVendedor();
        }

        private void CargarDatosReporteVendedor()
        {
            if (_vendedorService == null) { MessageBox.Show("Servicio de vendedores no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); LimpiarGrillaYDatos(); return; }
            if (string.IsNullOrWhiteSpace(tbx_Busqueda.Text))
            {
                MessageBox.Show("Por favor, ingrese un código o nombre de vendedor para buscar.", "Información Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _vendedorSeleccionadoParaReporte = null;
                LimpiarGrillaYDatos();
                return;
            }

            string textoBusquedaVendedor = tbx_Busqueda.Text.Trim();
            Vendedor vendedorEncontrado = _vendedorService.ObtenerVendedorPorCodigo(textoBusquedaVendedor);

            if (vendedorEncontrado == null)
            {
                var vendedoresPorNombre = _vendedorService.BuscarVendedoresPorNombreOApellido(textoBusquedaVendedor);
                if (vendedoresPorNombre.Any())
                {
                    vendedorEncontrado = vendedoresPorNombre.First(); // Podría mejorarse para seleccionar de una lista si hay múltiples
                }
            }

            if (vendedorEncontrado != null)
            {
                _vendedorSeleccionadoParaReporte = vendedorEncontrado;
                // Proceder a cargar las ventas de este vendedor
                if (_reporteService == null) { MessageBox.Show("Servicio de reportes no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); LimpiarGrillaYDatos(); return; }

                string filtroFecha = cbx_FiltroV.SelectedItem?.ToString();
                DateTime fechaInicio = dtp_FInicio.Value.Date;
                DateTime fechaFin = dtp_FFin.Value.Date.AddDays(1).AddTicks(-1);
                string mensajeError;

                if (filtroFecha == "Fecha Específica")
                {
                    _ventasActualesDelVendedor = _reporteService.GenerarReporteVentasPorVendedorYFechas(_idAdminLogueado, _vendedorSeleccionadoParaReporte.IdVendedor, fechaInicio, fechaInicio.AddDays(1).AddTicks(-1), out mensajeError);
                }
                else if (filtroFecha == "Rango de Fechas")
                {
                    if (fechaInicio > fechaFin.Date.AddDays(-1).AddTicks(1))
                    {
                        MessageBox.Show("La fecha de inicio no puede ser posterior a la fecha de fin.", "Rango de Fechas Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        LimpiarGrillaYDatos();
                        return;
                    }
                    _ventasActualesDelVendedor = _reporteService.GenerarReporteVentasPorVendedorYFechas(_idAdminLogueado, _vendedorSeleccionadoParaReporte.IdVendedor, fechaInicio, fechaFin, out mensajeError);
                }
                else
                {
                    _ventasActualesDelVendedor = _reporteService.GenerarReporteVentasPorVendedor(_idAdminLogueado, _vendedorSeleccionadoParaReporte.IdVendedor, out mensajeError);
                }

                if (!string.IsNullOrEmpty(mensajeError))
                {
                    MessageBox.Show(mensajeError, "Error al Generar Reporte", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LimpiarGrillaYDatos();
                    return;
                }
                if (_ventasActualesDelVendedor == null) // Verificación adicional
                {
                    _ventasActualesDelVendedor = new List<Venta>();
                }
                LoadReportDataGrid(_ventasActualesDelVendedor);

            }
            else
            {
                _vendedorSeleccionadoParaReporte = null;
                MessageBox.Show($"No se encontró ningún vendedor con el código o nombre '{textoBusquedaVendedor}'.", "Búsqueda sin Resultados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpiarGrillaYDatos();
            }
        }

        private void ibtn_Add_Click(object sender, EventArgs e) // Este es el botón "Generar PDF"
        {
            if (_vendedorSeleccionadoParaReporte == null)
            {
                MessageBox.Show("Por favor, primero busque y seleccione un vendedor para generar el reporte.", "Vendedor no Seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_ventasActualesDelVendedor == null || !_ventasActualesDelVendedor.Any())
            {
                // Intentar cargar los datos si están vacíos, por si el usuario solo quiere exportar sin cambiar filtros de fecha
                CargarDatosReporteVendedor();
                if (_ventasActualesDelVendedor == null || !_ventasActualesDelVendedor.Any())
                {
                    MessageBox.Show("No hay datos de ventas para este vendedor en el período seleccionado.", "Datos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            string nombreAdmin = SessionManager.CurrentUser?.NombreUsuario ?? "Admin Desconocido";
            string reporteId = Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
            string tituloReporte = "Reporte de Ventas por Vendedor";
            string infoAdicional = $"Vendedor: {_vendedorSeleccionadoParaReporte.Nombre} {_vendedorSeleccionadoParaReporte.Apellido} (Cód: {_vendedorSeleccionadoParaReporte.CodigoVendedor})";

            try
            {
                ReportePdfExporter exporter = new ReportePdfExporter();
                exporter.GenerarReporteVentasPdf(_ventasActualesDelVendedor, nombreAdmin, reporteId, tituloReporte, infoAdicional);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar exportar a PDF: {ex.Message}", "Error de Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadReportDataGrid(IEnumerable<Venta> ventas)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IdVenta", typeof(int));
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("Total Venta", typeof(decimal));
            dt.Columns.Add("Cliente", typeof(string));
            dt.Columns.Add("Estado", typeof(string));

            if (ventas != null)
            {
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
            }

            if (dgv_ReportesVentxVend != null)
            {
                dgv_ReportesVentxVend.DataSource = dt;
                if (dgv_ReportesVentxVend.Columns["IdVenta"] != null) dgv_ReportesVentxVend.Columns["IdVenta"].Visible = false;
                if (dgv_ReportesVentxVend.Columns["Total Venta"] != null) dgv_ReportesVentxVend.Columns["Total Venta"].DefaultCellStyle.Format = "C2";
            }
        }

        private void ibtn_Clear_Click(object sender, EventArgs e)
        {
            if (tbx_Busqueda != null) tbx_Busqueda.Clear();
            if (cbx_FiltroV != null && cbx_FiltroV.Items.Count > 0) cbx_FiltroV.SelectedIndex = 0;
            _vendedorSeleccionadoParaReporte = null;
            UpdateDateTimePickerVisibility();
            LimpiarGrillaYDatos();
        }
    }
}
