using BLL.Interfaces;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; // Necesario para .Any()
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; // Necesario para los controles Chart

namespace GUI
{
    public partial class Frm_DashboardAdmin : Form
    {
        private readonly IReporteService _reporteService;
        private readonly int _idAdminLogueado;
        private DateTime _fechaInicioActual;
        private DateTime _fechaFinActual;

        public Frm_DashboardAdmin(int idAdminLogueado)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico al inicializar servicios: {ex.Message}", "Error de Inicialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public Frm_DashboardAdmin()
        {
            InitializeComponent();
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            _idAdminLogueado = 1; // Placeholder, solo para diseño o pruebas limitadas
            try { _reporteService = new ReporteService(); } catch (Exception ex) { MessageBox.Show($"Error servicios (constructor por defecto): {ex.Message}"); }
        }


        private void Frm_DashboardAdmin_Load(object sender, EventArgs e)
        {
            if (_idAdminLogueado > 0 && _reporteService != null)
            {
                SetDateRange(DateTime.Today, DateTime.Today);
                DisableCustomDateControls();
                ApplyChartStyles();
                LoadAllDashboardData();
            }
            else if (_reporteService == null)
            {
                MessageBox.Show("Servicio de reportes no pudo ser inicializado.", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetDateRange(DateTime startDate, DateTime endDate)
        {
            _fechaInicioActual = startDate.Date;
            _fechaFinActual = endDate.Date.AddDays(1).AddTicks(-1);

            if (dtpStartDate != null) dtpStartDate.Value = _fechaInicioActual;
            if (dtpEndDate != null) dtpEndDate.Value = _fechaFinActual.Date;
        }

        private void DisableCustomDateControls()
        {
            if (dtpStartDate != null) dtpStartDate.Enabled = false;
            if (dtpEndDate != null) dtpEndDate.Enabled = false;
            if (ibtn_OKCustomDate != null) ibtn_OKCustomDate.Visible = false;
        }

        private void EnableCustomDateControls()
        {
            if (dtpStartDate != null) dtpStartDate.Enabled = true;
            if (dtpEndDate != null) dtpEndDate.Enabled = true;
            if (ibtn_OKCustomDate != null) ibtn_OKCustomDate.Visible = true;
        }

        private void ApplyChartStyles()
        {
            if (chart_IngresoPorFecha != null && chart_IngresoPorFecha.ChartAreas.Any())
            {
                chart_IngresoPorFecha.Series.Clear();
                chart_IngresoPorFecha.Titles.Clear();
                Title titleIngreso = new Title("Ingresos por Fecha", Docking.Top, new Font("Tahoma", 12F, FontStyle.Bold), Color.FromArgb(37, 60, 48));
                chart_IngresoPorFecha.Titles.Add(titleIngreso);
                chart_IngresoPorFecha.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
                chart_IngresoPorFecha.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
                chart_IngresoPorFecha.ChartAreas[0].BackColor = Color.FromArgb(237, 233, 221);
                chart_IngresoPorFecha.BackColor = Color.FromArgb(237, 233, 221);
                if (chart_IngresoPorFecha.Legends.Any()) chart_IngresoPorFecha.Legends[0].Enabled = false;
            }

            if (chart_Top10Products != null && chart_Top10Products.ChartAreas.Any())
            {
                chart_Top10Products.Series.Clear();
                chart_Top10Products.Titles.Clear();
                Title titleTop = new Title("Top 10 Productos Vendidos", Docking.Top, new Font("Tahoma", 12F, FontStyle.Bold), Color.FromArgb(37, 60, 48));
                chart_Top10Products.Titles.Add(titleTop);
                chart_Top10Products.ChartAreas[0].BackColor = Color.FromArgb(237, 233, 221);
                chart_Top10Products.BackColor = Color.FromArgb(237, 233, 221);
                if (chart_Top10Products.Legends.Any())
                {
                    chart_Top10Products.Legends[0].Docking = Docking.Bottom;
                    chart_Top10Products.Legends[0].Alignment = StringAlignment.Center;
                }
            }
        }

        private void LoadAllDashboardData()
        {
            if (_reporteService == null) { MessageBox.Show("Servicio de reportes no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            string mensajeError;

            // 1. Tarjetas de Resumen (Nombres de Labels Corregidos)
            var resumenVentas = _reporteService.ObtenerResumenVentasDashboard(_idAdminLogueado, _fechaInicioActual, _fechaFinActual, out mensajeError);
            if (resumenVentas != null)
            {
                if (lblVentas != null) lblVentas.Text = resumenVentas.NumeroDeVentas.ToString(); // CORREGIDO
                if (lblGanancias != null) lblGanancias.Text = resumenVentas.TotalGanancias.ToString("C"); // CORREGIDO
            }
            else
            {
                if (lblVentas != null) lblVentas.Text = "0";
                if (lblGanancias != null) lblGanancias.Text = "$0.00";
                // Podrías mostrar 'mensajeError' si es relevante para el usuario
                // MessageBox.Show(mensajeError, "Error Resumen Ventas"); 
            }

            // 2. Gráfico de Ingresos por Fecha
            var ingresosData = _reporteService.ObtenerIngresosPorFechaDashboard(_idAdminLogueado, _fechaInicioActual, _fechaFinActual, out mensajeError);
            if (ingresosData != null && chart_IngresoPorFecha != null)
            {
                chart_IngresoPorFecha.Series.Clear();
                Series seriesIngresos = new Series("Ingresos") { ChartType = SeriesChartType.Area, Color = Color.FromArgb(150, 75, 150, 225), BorderColor = Color.FromArgb(45, 66, 98), BorderWidth = 2 };
                if (ingresosData.Any())
                {
                    foreach (var dataPoint in ingresosData) { seriesIngresos.Points.AddXY(dataPoint.Fecha.ToShortDateString(), dataPoint.Ingreso); }
                }
                else // Añadir puntos dummy si no hay datos para que el gráfico no esté vacío
                {
                    seriesIngresos.Points.AddXY(_fechaInicioActual.ToShortDateString(), 0);
                    if (_fechaInicioActual.Date != _fechaFinActual.Date) seriesIngresos.Points.AddXY(_fechaFinActual.ToShortDateString(), 0);
                }
                chart_IngresoPorFecha.Series.Add(seriesIngresos);
                if (chart_IngresoPorFecha.ChartAreas.Any()) chart_IngresoPorFecha.ChartAreas[0].AxisX.LabelStyle.Format = "MMM dd";
            }
            else { /* MessageBox.Show(mensajeError, "Error Gráfico Ingresos"); */ }

            // 3. Gráfico Top 10 Productos
            var topProductos = _reporteService.ObtenerTopProductosVendidosDashboard(_idAdminLogueado, _fechaInicioActual, _fechaFinActual, 10, out mensajeError);
            if (topProductos != null && chart_Top10Products != null)
            {
                chart_Top10Products.Series.Clear();
                Series seriesTopProductos = new Series("TopProductos") { ChartType = SeriesChartType.Doughnut, IsValueShownAsLabel = true, LabelFormat = "#VALX (#PERCENT{P0})", Font = new Font("Tahoma", 8F) };
                if (topProductos.Any())
                {
                    foreach (var producto in topProductos) { seriesTopProductos.Points.AddXY(producto.NombreProducto, producto.CantidadVendida); }
                }
                else
                {
                    seriesTopProductos.Points.AddXY("Sin Datos", 1); // Placeholder para gráfico vacío
                    seriesTopProductos.Points[0].Label = "Sin Datos";
                    seriesTopProductos.Points[0].LegendText = "Sin Datos";
                }
                chart_Top10Products.Series.Add(seriesTopProductos);
            }
            else { /* MessageBox.Show(mensajeError, "Error Gráfico Top Productos"); */ }

            // 4. Contadores Generales (Nombres de Labels Corregidos)
            var contadores = _reporteService.ObtenerContadoresGeneralesDashboard(_idAdminLogueado, out mensajeError);
            if (contadores != null)
            {
                if (lblClientes != null) lblClientes.Text = contadores.TotalClientesActivos.ToString(); // CORREGIDO
                if (lblVendedores != null) lblVendedores.Text = contadores.TotalVendedoresActivos.ToString(); // CORREGIDO
                if (lblProductos != null) lblProductos.Text = contadores.TotalProductosActivos.ToString(); // CORREGIDO
            }
            else { /* MessageBox.Show(mensajeError, "Error Contadores"); */ }

            // 5. Grilla Productos Bajo Stock
            var bajoStock = _reporteService.ObtenerProductosConBajoStockDashboard(_idAdminLogueado, 10, out mensajeError); // Umbral de 10
            if (bajoStock != null && dgv_PBajoStock != null)
            {
                DataTable dtBajoStock = new DataTable();
                dtBajoStock.Columns.Add("Producto", typeof(string));
                dtBajoStock.Columns.Add("Stock Actual", typeof(int));
                dtBajoStock.Columns.Add("Vendedor", typeof(string));
                foreach (var prod in bajoStock) { dtBajoStock.Rows.Add(prod.Nombre, prod.Stock, prod.Vendedor?.CodigoVendedor ?? "N/A"); }
                dgv_PBajoStock.DataSource = dtBajoStock;
            }
            else { /* MessageBox.Show(mensajeError, "Error Productos Bajo Stock"); */ }
        }

        // --- MANEJADORES DE EVENTOS PARA BOTONES DE FILTRO DE FECHA ---
        private void ibtn_Today_Click(object sender, EventArgs e)
        {
            SetDateRange(DateTime.Today, DateTime.Today);
            DisableCustomDateControls();
            LoadAllDashboardData();
        }

        private void ibtn_7Days_Click(object sender, EventArgs e)
        {
            SetDateRange(DateTime.Today.AddDays(-6), DateTime.Today);
            DisableCustomDateControls();
            LoadAllDashboardData();
        }

        private void ibtn_30Days_Click(object sender, EventArgs e)
        {
            SetDateRange(DateTime.Today.AddDays(-29), DateTime.Today);
            DisableCustomDateControls();
            LoadAllDashboardData();
        }

        private void ibtn_ThisMonth_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
            SetDateRange(firstDayOfMonth, today);
            DisableCustomDateControls();
            LoadAllDashboardData();
        }

        private void ibtn_CustomDate_Click(object sender, EventArgs e)
        {
            EnableCustomDateControls();
        }

        private void ibtn_OKCustomDate_Click(object sender, EventArgs e)
        {
            if (dtpStartDate.Value.Date > dtpEndDate.Value.Date)
            {
                MessageBox.Show("La fecha de inicio no puede ser posterior a la fecha de fin.", "Error de Fecha", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SetDateRange(dtpStartDate.Value, dtpEndDate.Value);
            LoadAllDashboardData();
        }
    }
}