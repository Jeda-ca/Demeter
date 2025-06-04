using BLL.Interfaces;
using BLL.Services;
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
    public partial class Frm_DashboardAdmin : Form
    {
        private readonly IReporteService _reporteService;
        private readonly int _idAdminLogueado;
        private DateTime? _fechaInicioActual = null;
        private DateTime? _fechaFinActual = null;

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
            _idAdminLogueado = 1;
            try { _reporteService = new ReporteService(); } catch (Exception) { /* Silenciar para diseñador */ }
        }


        private void Frm_DashboardAdmin_Load(object sender, EventArgs e)
        {
            if (_idAdminLogueado > 0 && _reporteService != null)
            {
                DateTime today = DateTime.Today;
                DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);

                SetDateRange(firstDayOfMonth, today);

                DisableCustomDateControls();
                ApplyChartStyles();
                LoadAllDashboardData();
            }
            else if (_reporteService == null)
            {
                MessageBox.Show("Servicio de reportes no pudo ser inicializado.", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetDateRange(DateTime? startDate, DateTime? endDate)
        {
            _fechaInicioActual = startDate?.Date;

            _fechaFinActual = endDate?.Date.AddDays(1).AddTicks(-1);

            if (dtpStartDate != null) dtpStartDate.Value = startDate ?? DateTime.Today;
            if (dtpEndDate != null) dtpEndDate.Value = endDate ?? DateTime.Today;
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

            // Si _fechaInicioActual o _fechaFinActual son null, significa "todos los tiempos".
            // Si tienen valor, significa que se ha seleccionado un rango específico.
            DateTime inicioParaConsulta = _fechaInicioActual ?? DateTime.MinValue;
            DateTime finParaConsulta = _fechaFinActual ?? DateTime.MaxValue;


            // 1. Tarjetas de Resumen 
            var resumenVentas = _reporteService.ObtenerResumenVentasDashboard(_idAdminLogueado, inicioParaConsulta, finParaConsulta, out mensajeError);
            if (resumenVentas != null)
            {
                if (lblVentas != null) lblVentas.Text = resumenVentas.NumeroDeVentas.ToString();
                if (lblGanancias != null) lblGanancias.Text = resumenVentas.TotalGanancias.ToString("C");
            }
            else
            {
                if (lblVentas != null) lblVentas.Text = "0";
                if (lblGanancias != null) lblGanancias.Text = "$0.00";
                Console.WriteLine($"Error Resumen Ventas Admin: {mensajeError}");
            }

            // 2. Gráfico de Ingresos por Fecha
            var ingresosData = _reporteService.ObtenerIngresosPorFechaDashboard(_idAdminLogueado, inicioParaConsulta, finParaConsulta, out mensajeError);
            if (ingresosData != null && chart_IngresoPorFecha != null)
            {
                chart_IngresoPorFecha.Series.Clear();
                Series seriesIngresos = new Series("Ingresos") { ChartType = SeriesChartType.SplineArea, Color = Color.FromArgb(150, 75, 150, 225), BorderColor = Color.FromArgb(45, 66, 98), BorderWidth = 2 };
                if (ingresosData.Any())
                {
                    foreach (var dataPoint in ingresosData) { seriesIngresos.Points.AddXY(dataPoint.Fecha.ToShortDateString(), dataPoint.Ingreso); }
                }
                else
                {
                    // Si no hay datos, mostrar el rango consultado con valor 0
                    seriesIngresos.Points.AddXY(inicioParaConsulta == DateTime.MinValue ? (_fechaInicioActual ?? DateTime.Today).ToShortDateString() : inicioParaConsulta.ToShortDateString(), 0);
                    if (inicioParaConsulta.Date != (finParaConsulta == DateTime.MaxValue ? (_fechaFinActual ?? DateTime.Today).Date : finParaConsulta.Date.AddDays(-1).AddTicks(1).Date))
                    {
                        seriesIngresos.Points.AddXY(finParaConsulta == DateTime.MaxValue ? (_fechaFinActual ?? DateTime.Today).ToShortDateString() : finParaConsulta.Date.AddDays(-1).AddTicks(1).ToShortDateString(), 0);
                    }
                }
                chart_IngresoPorFecha.Series.Add(seriesIngresos);
                if (chart_IngresoPorFecha.ChartAreas.Any())
                {
                    chart_IngresoPorFecha.ChartAreas[0].AxisX.LabelStyle.Format = "MMM dd";
                    chart_IngresoPorFecha.ChartAreas[0].AxisX.Interval = 0;
                    chart_IngresoPorFecha.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Auto;
                }
            }
            else { Console.WriteLine($"Error Gráfico Ingresos Admin: {mensajeError}"); }

            // 3. Gráfico Top 10 Productos
            var topProductos = _reporteService.ObtenerTopProductosVendidosDashboard(_idAdminLogueado, inicioParaConsulta, finParaConsulta, 10, out mensajeError);
            if (topProductos != null && chart_Top10Products != null)
            {
                chart_Top10Products.Series.Clear();
                Series seriesTopProductos = new Series("TopProductos") { ChartType = SeriesChartType.Doughnut, IsValueShownAsLabel = true, LabelFormat = "#VALX (#PERCENT{P0})", Font = new Font("Tahoma", 8F) };
                if (topProductos.Any())
                {
                    foreach (var producto in topProductos)
                    {
                        DataPoint dp = seriesTopProductos.Points.Add(producto.CantidadVendida);
                        dp.LegendText = $"{producto.NombreProducto} ({producto.CantidadVendida})";
                        dp.Label = producto.NombreProducto;
                    }
                }
                else
                {
                    DataPoint dp = seriesTopProductos.Points.Add(1);
                    dp.LegendText = "Sin datos"; dp.Label = "Sin datos"; dp.Color = Color.LightGray;
                }
                chart_Top10Products.Series.Add(seriesTopProductos);
            }
            else { Console.WriteLine($"Error Gráfico Top Productos Admin: {mensajeError}"); }

            // 4. Contadores Generales (Estos no dependen del filtro de fecha)
            var contadores = _reporteService.ObtenerContadoresGeneralesDashboard(_idAdminLogueado, out mensajeError);
            if (contadores != null)
            {
                if (lblClientes != null) lblClientes.Text = contadores.TotalClientesActivos.ToString();
                if (lblVendedores != null) lblVendedores.Text = contadores.TotalVendedoresActivos.ToString();
                if (lblProductos != null) lblProductos.Text = contadores.TotalProductosActivos.ToString();
            }
            else { Console.WriteLine($"Error Contadores Admin: {mensajeError}"); }

            // 5. Grilla Productos Bajo Stock (No depende del filtro de fecha)
            var bajoStock = _reporteService.ObtenerProductosConBajoStockDashboard(_idAdminLogueado, 10, out mensajeError);
            if (bajoStock != null && dgv_PBajoStock != null)
            {
                DataTable dtBajoStock = new DataTable();
                dtBajoStock.Columns.Add("Producto", typeof(string));
                dtBajoStock.Columns.Add("Stock Actual", typeof(int));
                dtBajoStock.Columns.Add("Vendedor", typeof(string));
                foreach (var prod in bajoStock) { dtBajoStock.Rows.Add(prod.Nombre, prod.Stock, prod.Vendedor?.CodigoVendedor ?? "N/A"); }
                dgv_PBajoStock.DataSource = dtBajoStock;
            }
            else { Console.WriteLine($"Error Productos Bajo Stock Admin: {mensajeError}"); }
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

    //public partial class Frm_DashboardAdmin : Form
    //{
    //    private readonly IReporteService _reporteService;
    //    private readonly int _idAdminLogueado;
    //    private DateTime? _fechaInicioActual = null;
    //    private DateTime? _fechaFinActual = null;

    //    public Frm_DashboardAdmin(int idAdminLogueado)
    //    {
    //        InitializeComponent();
    //        this.TopLevel = false;
    //        this.FormBorderStyle = FormBorderStyle.None;
    //        this.Dock = DockStyle.Fill;

    //        _idAdminLogueado = idAdminLogueado;

    //        if (_idAdminLogueado <= 0)
    //        {
    //            MessageBox.Show("Error: ID de administrador no válido.", "Error de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //            this.BeginInvoke(new MethodInvoker(this.Close));
    //            return;
    //        }

    //        try
    //        {
    //            _reporteService = new ReporteService();
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show($"Error crítico al inicializar servicios: {ex.Message}", "Error de Inicialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //            return;
    //        }
    //    }
    //    public Frm_DashboardAdmin()
    //    {
    //        InitializeComponent();
    //        this.TopLevel = false;
    //        this.FormBorderStyle = FormBorderStyle.None;
    //        this.Dock = DockStyle.Fill;
    //        _idAdminLogueado = 1;
    //        try { _reporteService = new ReporteService(); } catch (Exception) { }
    //    }


    //    private void Frm_DashboardAdmin_Load(object sender, EventArgs e)
    //    {
    //        if (_idAdminLogueado > 0 && _reporteService != null)
    //        {
    //            // Por defecto, no se establece un rango de fechas específico (_fechaInicioActual y _fechaFinActual son null)
    //            // Los DateTimePickers pueden mostrar la fecha actual, pero no se usan para filtrar inicialmente.
    //            if (dtpStartDate != null) dtpStartDate.Value = DateTime.Today;
    //            if (dtpEndDate != null) dtpEndDate.Value = DateTime.Today;

    //            DisableCustomDateControls();
    //            ApplyChartStyles();
    //            LoadAllDashboardData(); // Carga los datos totales por defecto
    //        }
    //        else if (_reporteService == null)
    //        {
    //            MessageBox.Show("Servicio de reportes no pudo ser inicializado.", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //        }
    //    }

    //    private void SetDateRange(DateTime? startDate, DateTime? endDate)
    //    {
    //        _fechaInicioActual = startDate?.Date;
    //        _fechaFinActual = endDate?.Date.AddDays(1).AddTicks(-1); // Incluye todo el día final

    //        // Actualizar los DateTimePickers si las fechas no son null,
    //        // de lo contrario, podrían mantener su valor actual o resetearse.
    //        if (dtpStartDate != null) dtpStartDate.Value = startDate ?? DateTime.Today;
    //        if (dtpEndDate != null) dtpEndDate.Value = endDate ?? DateTime.Today;
    //    }

    //    private void DisableCustomDateControls()
    //    {
    //        if (dtpStartDate != null) dtpStartDate.Enabled = false;
    //        if (dtpEndDate != null) dtpEndDate.Enabled = false;
    //        if (ibtn_OKCustomDate != null) ibtn_OKCustomDate.Visible = false;
    //    }

    //    private void EnableCustomDateControls()
    //    {
    //        if (dtpStartDate != null) dtpStartDate.Enabled = true;
    //        if (dtpEndDate != null) dtpEndDate.Enabled = true;
    //        if (ibtn_OKCustomDate != null) ibtn_OKCustomDate.Visible = true;
    //    }

    //    private void ApplyChartStyles()
    //    {
    //        if (chart_IngresoPorFecha != null && chart_IngresoPorFecha.ChartAreas.Any())
    //        {
    //            chart_IngresoPorFecha.Series.Clear();
    //            chart_IngresoPorFecha.Titles.Clear();
    //            Title titleIngreso = new Title("Ingresos por Fecha", Docking.Top, new Font("Tahoma", 12F, FontStyle.Bold), Color.FromArgb(37, 60, 48));
    //            chart_IngresoPorFecha.Titles.Add(titleIngreso);
    //            chart_IngresoPorFecha.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
    //            chart_IngresoPorFecha.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
    //            chart_IngresoPorFecha.ChartAreas[0].BackColor = Color.FromArgb(237, 233, 221);
    //            chart_IngresoPorFecha.BackColor = Color.FromArgb(237, 233, 221);
    //            if (chart_IngresoPorFecha.Legends.Any()) chart_IngresoPorFecha.Legends[0].Enabled = false;
    //        }

    //        if (chart_Top10Products != null && chart_Top10Products.ChartAreas.Any())
    //        {
    //            chart_Top10Products.Series.Clear();
    //            chart_Top10Products.Titles.Clear();
    //            Title titleTop = new Title("Top 10 Productos Vendidos", Docking.Top, new Font("Tahoma", 12F, FontStyle.Bold), Color.FromArgb(37, 60, 48));
    //            chart_Top10Products.Titles.Add(titleTop);
    //            chart_Top10Products.ChartAreas[0].BackColor = Color.FromArgb(237, 233, 221);
    //            chart_Top10Products.BackColor = Color.FromArgb(237, 233, 221);
    //            if (chart_Top10Products.Legends.Any())
    //            {
    //                chart_Top10Products.Legends[0].Docking = Docking.Bottom;
    //                chart_Top10Products.Legends[0].Alignment = StringAlignment.Center;
    //            }
    //        }
    //    }

    //    private void LoadAllDashboardData()
    //    {
    //        if (_reporteService == null) { MessageBox.Show("Servicio de reportes no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
    //        string mensajeError;

    //        DateTime inicioParaConsulta = _fechaInicioActual ?? DateTime.MinValue;
    //        DateTime finParaConsulta = _fechaFinActual ?? DateTime.MaxValue;


    //        // 1. Tarjetas de Resumen 
    //        var resumenVentas = _reporteService.ObtenerResumenVentasDashboard(_idAdminLogueado, inicioParaConsulta, finParaConsulta, out mensajeError);
    //        if (resumenVentas != null)
    //        {
    //            if (lblVentas != null) lblVentas.Text = resumenVentas.NumeroDeVentas.ToString();
    //            if (lblGanancias != null) lblGanancias.Text = resumenVentas.TotalGanancias.ToString("C");
    //        }
    //        else
    //        {
    //            if (lblVentas != null) lblVentas.Text = "0";
    //            if (lblGanancias != null) lblGanancias.Text = "$0.00";
    //            Console.WriteLine($"Error Resumen Ventas Admin: {mensajeError}");
    //        }

    //        // 2. Gráfico de Ingresos por Fecha
    //        var ingresosData = _reporteService.ObtenerIngresosPorFechaDashboard(_idAdminLogueado, inicioParaConsulta, finParaConsulta, out mensajeError);
    //        if (ingresosData != null && chart_IngresoPorFecha != null)
    //        {
    //            chart_IngresoPorFecha.Series.Clear();
    //            Series seriesIngresos = new Series("Ingresos") { ChartType = SeriesChartType.SplineArea, Color = Color.FromArgb(150, 75, 150, 225), BorderColor = Color.FromArgb(45, 66, 98), BorderWidth = 2 };
    //            if (ingresosData.Any())
    //            {
    //                foreach (var dataPoint in ingresosData) { seriesIngresos.Points.AddXY(dataPoint.Fecha.ToShortDateString(), dataPoint.Ingreso); }
    //            }
    //            else
    //            {
    //                seriesIngresos.Points.AddXY(inicioParaConsulta == DateTime.MinValue ? "Inicio" : inicioParaConsulta.ToShortDateString(), 0);
    //                if (inicioParaConsulta != finParaConsulta) seriesIngresos.Points.AddXY(finParaConsulta == DateTime.MaxValue ? "Fin" : finParaConsulta.ToShortDateString(), 0);
    //            }
    //            chart_IngresoPorFecha.Series.Add(seriesIngresos);
    //            if (chart_IngresoPorFecha.ChartAreas.Any())
    //            {
    //                chart_IngresoPorFecha.ChartAreas[0].AxisX.LabelStyle.Format = "MMM dd";
    //                chart_IngresoPorFecha.ChartAreas[0].AxisX.Interval = 0; // Auto interval
    //                chart_IngresoPorFecha.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Auto;
    //            }
    //        }
    //        else { Console.WriteLine($"Error Gráfico Ingresos Admin: {mensajeError}"); }

    //        // 3. Gráfico Top 10 Productos
    //        var topProductos = _reporteService.ObtenerTopProductosVendidosDashboard(_idAdminLogueado, inicioParaConsulta, finParaConsulta, 10, out mensajeError);
    //        if (topProductos != null && chart_Top10Products != null)
    //        {
    //            chart_Top10Products.Series.Clear();
    //            Series seriesTopProductos = new Series("TopProductos") { ChartType = SeriesChartType.Doughnut, IsValueShownAsLabel = true, LabelFormat = "#VALX (#PERCENT{P0})", Font = new Font("Tahoma", 8F) };
    //            if (topProductos.Any())
    //            {
    //                foreach (var producto in topProductos)
    //                {
    //                    DataPoint dp = seriesTopProductos.Points.Add(producto.CantidadVendida);
    //                    dp.LegendText = $"{producto.NombreProducto} ({producto.CantidadVendida})";
    //                    dp.Label = producto.NombreProducto;
    //                }
    //            }
    //            else
    //            {
    //                DataPoint dp = seriesTopProductos.Points.Add(1);
    //                dp.LegendText = "Sin datos"; dp.Label = "Sin datos"; dp.Color = Color.LightGray;
    //            }
    //            chart_Top10Products.Series.Add(seriesTopProductos);
    //        }
    //        else { Console.WriteLine($"Error Gráfico Top Productos Admin: {mensajeError}"); }

    //        // 4. Contadores Generales (Estos no dependen del filtro de fecha)
    //        var contadores = _reporteService.ObtenerContadoresGeneralesDashboard(_idAdminLogueado, out mensajeError);
    //        if (contadores != null)
    //        {
    //            if (lblClientes != null) lblClientes.Text = contadores.TotalClientesActivos.ToString();
    //            if (lblVendedores != null) lblVendedores.Text = contadores.TotalVendedoresActivos.ToString();
    //            if (lblProductos != null) lblProductos.Text = contadores.TotalProductosActivos.ToString();
    //        }
    //        else { Console.WriteLine($"Error Contadores Admin: {mensajeError}"); }

    //        // 5. Grilla Productos Bajo Stock (No depende del filtro de fecha)
    //        var bajoStock = _reporteService.ObtenerProductosConBajoStockDashboard(_idAdminLogueado, 10, out mensajeError); // Umbral de 10
    //        if (bajoStock != null && dgv_PBajoStock != null)
    //        {
    //            DataTable dtBajoStock = new DataTable();
    //            dtBajoStock.Columns.Add("Producto", typeof(string));
    //            dtBajoStock.Columns.Add("Stock Actual", typeof(int));
    //            dtBajoStock.Columns.Add("Vendedor", typeof(string)); // Código del vendedor
    //            foreach (var prod in bajoStock) { dtBajoStock.Rows.Add(prod.Nombre, prod.Stock, prod.Vendedor?.CodigoVendedor ?? "N/A"); }
    //            dgv_PBajoStock.DataSource = dtBajoStock;
    //        }
    //        else { Console.WriteLine($"Error Productos Bajo Stock Admin: {mensajeError}"); }
    //    }

    //    // --- MANEJADORES DE EVENTOS PARA BOTONES DE FILTRO DE FECHA ---
    //    private void ibtn_Today_Click(object sender, EventArgs e)
    //    {
    //        SetDateRange(DateTime.Today, DateTime.Today);
    //        DisableCustomDateControls();
    //        LoadAllDashboardData();
    //    }

    //    private void ibtn_7Days_Click(object sender, EventArgs e)
    //    {
    //        SetDateRange(DateTime.Today.AddDays(-6), DateTime.Today);
    //        DisableCustomDateControls();
    //        LoadAllDashboardData();
    //    }

    //    private void ibtn_30Days_Click(object sender, EventArgs e)
    //    {
    //        SetDateRange(DateTime.Today.AddDays(-29), DateTime.Today);
    //        DisableCustomDateControls();
    //        LoadAllDashboardData();
    //    }

    //    private void ibtn_ThisMonth_Click(object sender, EventArgs e)
    //    {
    //        DateTime today = DateTime.Today;
    //        DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
    //        SetDateRange(firstDayOfMonth, today);
    //        DisableCustomDateControls();
    //        LoadAllDashboardData();
    //    }

    //    private void ibtn_CustomDate_Click(object sender, EventArgs e)
    //    {
    //        EnableCustomDateControls();
    //        // Al presionar "Fecha Personalizada", reseteamos las fechas internas
    //        // para que si el usuario no presiona OK, al recargar por otro botón,
    //        // se usen los rangos predefinidos o el total.
    //        _fechaInicioActual = null;
    //        _fechaFinActual = null;

    //    }

    //    private void ibtn_OKCustomDate_Click(object sender, EventArgs e)
    //    {
    //        if (dtpStartDate.Value.Date > dtpEndDate.Value.Date)
    //        {
    //            MessageBox.Show("La fecha de inicio no puede ser posterior a la fecha de fin.", "Error de Fecha", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    //            return;
    //        }
    //        SetDateRange(dtpStartDate.Value, dtpEndDate.Value);
    //        LoadAllDashboardData();
    //    }
    //}
}

