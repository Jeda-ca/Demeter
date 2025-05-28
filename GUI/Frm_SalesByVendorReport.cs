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
    public partial class Frm_SalesByVendorReport : Form
    {
        private readonly IReporteService _reporteService;
        private readonly IVendedorService _vendedorService;
        private readonly int _idAdminLogueado;
        private Vendedor _vendedorSeleccionadoParaReporte = null;

        public Frm_SalesByVendorReport(int idAdminLogueado)
        {
            InitializeComponent();
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            _idAdminLogueado = idAdminLogueado;

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
                if (ibtn_Add != null) ibtn_Add.Enabled = false;
                if (cbx_FiltroV != null) cbx_FiltroV.Enabled = false;
                if (tbx_Busqueda != null) tbx_Busqueda.Enabled = false;
            }
        }

        private void Frm_SalesByVendorReport_Load(object sender, EventArgs e)
        {
            if (_idAdminLogueado > 0 && _reporteService != null)
            {
                ConfigurarControlesIniciales();
                LimpiarGrilla();
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
                cbx_FiltroV.SelectedIndex = 0; // Por defecto, sin filtro de fecha
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

        private void LimpiarGrilla()
        {
            if (dgv_ReportesVentxVend != null) dgv_ReportesVentxVend.DataSource = null;
        }

        // Evento del ComboBox de filtro de fecha
        private void cbx_FiltroV_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDateTimePickerVisibility();
            // Opcional: Si hay un vendedor seleccionado, regenerar el reporte con el nuevo filtro de fecha
            // if (_vendedorSeleccionadoParaReporte != null)
            // {
            //     GenerarReporteParaVendedor();
            // }
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

        // Botón para BUSCAR VENDEDOR
        private void ibtn_Buscar_Click(object sender, EventArgs e)
        {
            if (_vendedorService == null) { MessageBox.Show("Servicio de vendedores no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (tbx_Busqueda == null || string.IsNullOrWhiteSpace(tbx_Busqueda.Text))
            {
                MessageBox.Show("Por favor, ingrese un código o nombre de vendedor para buscar.", "Información Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _vendedorSeleccionadoParaReporte = null;
                LimpiarGrilla();
                return;
            }

            string textoBusquedaVendedor = tbx_Busqueda.Text.Trim();
            Vendedor vendedorEncontrado = _vendedorService.ObtenerVendedorPorCodigo(textoBusquedaVendedor);

            if (vendedorEncontrado == null)
            {
                var vendedoresPorNombre = _vendedorService.BuscarVendedoresPorNombreOApellido(textoBusquedaVendedor);
                if (vendedoresPorNombre.Any())
                {
                    // Si hay múltiples, podrías mostrar un diálogo para seleccionar uno.
                    // Por simplicidad, tomamos el primero.
                    vendedorEncontrado = vendedoresPorNombre.First();
                }
            }

            if (vendedorEncontrado != null)
            {
                _vendedorSeleccionadoParaReporte = vendedorEncontrado;
                // MODIFICADO: Generar reporte inmediatamente después de encontrar el vendedor
                GenerarReporteParaVendedor();
            }
            else
            {
                _vendedorSeleccionadoParaReporte = null;
                MessageBox.Show($"No se encontró ningún vendedor con el código o nombre '{textoBusquedaVendedor}'.", "Búsqueda sin Resultados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpiarGrilla();
            }
        }

        // Botón "Generar" (ibtn_Add en tu Designer) - Ahora principalmente para aplicar/refrescar filtros de fecha
        private void ibtn_Add_Click(object sender, EventArgs e)
        {
            GenerarReporteParaVendedor();
        }

        private void GenerarReporteParaVendedor()
        {
            if (_vendedorSeleccionadoParaReporte == null)
            {
                // Este mensaje ya no debería aparecer si la búsqueda de vendedor es el único trigger inicial
                // MessageBox.Show("Por favor, primero busque y seleccione un vendedor.", "Vendedor Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LimpiarGrilla(); // Si no hay vendedor, limpiar la grilla
                return;
            }
            if (_reporteService == null) { MessageBox.Show("Servicio de reportes no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            string filtroFecha = cbx_FiltroV.SelectedItem?.ToString();
            DateTime fechaInicio = dtp_FInicio.Value.Date;
            DateTime fechaFin = dtp_FFin.Value.Date.AddDays(1).AddTicks(-1);
            string mensajeError;
            IEnumerable<Venta> ventas;

            if (filtroFecha == "Fecha Específica")
            {
                ventas = _reporteService.GenerarReporteVentasPorVendedorYFechas(_idAdminLogueado, _vendedorSeleccionadoParaReporte.IdVendedor, fechaInicio, fechaInicio.AddDays(1).AddTicks(-1), out mensajeError);
            }
            else if (filtroFecha == "Rango de Fechas")
            {
                if (fechaInicio > fechaFin.Date.AddDays(-1).AddTicks(1))
                {
                    MessageBox.Show("La fecha de inicio no puede ser posterior a la fecha de fin.", "Rango de Fechas Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LimpiarGrilla();
                    return;
                }
                ventas = _reporteService.GenerarReporteVentasPorVendedorYFechas(_idAdminLogueado, _vendedorSeleccionadoParaReporte.IdVendedor, fechaInicio, fechaFin, out mensajeError);
            }
            else // "-- Sin Filtro de Fecha --" o no seleccionado
            {
                ventas = _reporteService.GenerarReporteVentasPorVendedor(_idAdminLogueado, _vendedorSeleccionadoParaReporte.IdVendedor, out mensajeError);
            }

            if (!string.IsNullOrEmpty(mensajeError))
            {
                MessageBox.Show(mensajeError, "Error al Generar Reporte", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LimpiarGrilla();
                return;
            }
            LoadReportDataGrid(ventas);
        }

        private void LoadReportDataGrid(IEnumerable<Venta> ventas)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID Venta", typeof(int));
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
                if (dgv_ReportesVentxVend.Columns["ID Venta"] != null) dgv_ReportesVentxVend.Columns["ID Venta"].Visible = false;
                if (dgv_ReportesVentxVend.Columns["Total Venta"] != null) dgv_ReportesVentxVend.Columns["Total Venta"].DefaultCellStyle.Format = "C2";
            }
        }

        private void ibtn_Clear_Click(object sender, EventArgs e)
        {
            if (tbx_Busqueda != null) tbx_Busqueda.Clear();
            if (cbx_FiltroV != null && cbx_FiltroV.Items.Count > 0) cbx_FiltroV.SelectedIndex = 0; // Resetear filtro de fecha
            _vendedorSeleccionadoParaReporte = null;
            UpdateDateTimePickerVisibility();
            LimpiarGrilla();
        }
    }
}
