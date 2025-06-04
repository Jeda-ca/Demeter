using BLL.Interfaces;
using BLL.Services;
using ENTITY;
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
    public partial class Frm_DashboardVendor : Form
    {
        private readonly int _idVendedorTabla; // Este es el ID de la tabla 'sellers'
        private readonly IVentaService _ventaService;
        private readonly IProductoService _productoService;

        private DateTime _fechaInicioActual;
        private DateTime _fechaFinActual;

        public Frm_DashboardVendor(int idVendedorTabla)
        {
            InitializeComponent();
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            _idVendedorTabla = idVendedorTabla;

            if (_idVendedorTabla <= 0)
            {
                MessageBox.Show("Error: ID de vendedor no válido para el dashboard.", "Error de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new MethodInvoker(this.Close));
                return;
            }

            try
            {
                _ventaService = new VentaService();
                _productoService = new ProductoService();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar servicios en Dashboard Vendedor: {ex.Message}", "Error de Inicialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Considera deshabilitar funcionalidades si la inicialización de servicios falla
            }
        }

        private void Frm_DashboardVendor_Load(object sender, EventArgs e)
        {
            if (_idVendedorTabla > 0 && _ventaService != null && _productoService != null)
            {
                SetDateRange(DateTime.Today, DateTime.Today); // Rango inicial: solo hoy
                DisableCustomDateControls();
                ApplyChartStyles();
                LoadDashboardData();
            }
            else if (_ventaService == null || _productoService == null)
            {
                MessageBox.Show("Los servicios necesarios para el dashboard no pudieron ser inicializados.", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetDateRange(DateTime startDate, DateTime endDate)
        {
            _fechaInicioActual = startDate.Date;
            _fechaFinActual = endDate.Date.AddDays(1).AddTicks(-1); // Para incluir todo el día final

            if (dtpStartDate != null) dtpStartDate.Value = _fechaInicioActual;
            if (dtpEndDate != null) dtpEndDate.Value = _fechaFinActual.Date; // Mostrar solo la fecha en el picker
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
                Title titleIngreso = new Title("Ingreso bruto por Fecha", Docking.Top, new Font("Tahoma", 12F, FontStyle.Bold), Color.FromArgb(37, 60, 48));
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
                Title titleTop = new Title("Top 10 productos más vendidos", Docking.Top, new Font("Tahoma", 12F, FontStyle.Bold), Color.FromArgb(37, 60, 48));
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

        private void LoadDashboardData()
        {
            if (_ventaService == null || _productoService == null)
            {
                MessageBox.Show("Servicios no disponibles para cargar datos del dashboard.", "Error de Servicio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 1. Obtener ventas del vendedor en el rango de fechas
            IEnumerable<Venta> ventasDelPeriodo = _ventaService.ObtenerVentasPorVendedorYFechas(_idVendedorTabla, _fechaInicioActual, _fechaFinActual);
            List<Venta> ventasCompletadas = ventasDelPeriodo.Where(v => v.EstadoVenta != null && v.EstadoVenta.Nombre.ToUpper() == "COMPLETADA").ToList();

            // 2. Actualizar tarjetas de resumen (labels)
            if (lblVentas != null) lblVentas.Text = ventasCompletadas.Count().ToString();
            if (lblGanancias != null) lblGanancias.Text = ventasCompletadas.Sum(v => v.Total).ToString("C");

            var productosDelVendedor = _productoService.ObtenerProductosPorVendedor(_idVendedorTabla).Where(p => p.Activo).ToList();
            if (lblProducts != null) lblProducts.Text = productosDelVendedor.Count().ToString();


            // 3. Cargar gráfico de Ingresos por Fecha
            LoadSalesChart(ventasCompletadas);

            // 4. Cargar gráfico Top 10 Productos Vendidos
            LoadTopSellingProductsChart(ventasCompletadas);

            // 5. Cargar grilla de Productos con Bajo Stock
            LoadLowStockProducts(productosDelVendedor);
        }

        private void LoadSalesChart(List<Venta> ventasCompletadas)
        {
            if (chart_IngresoPorFecha == null || !chart_IngresoPorFecha.IsHandleCreated) return;
            chart_IngresoPorFecha.Series.Clear();

            Series seriesIngresos = new Series("Ingresos")
            {
                ChartType = SeriesChartType.Area, // O Column, SplineArea, etc.
                Color = Color.FromArgb(150, 75, 150, 225),
                BorderColor = Color.FromArgb(45, 66, 98),
                BorderWidth = 2
            };

            var ingresosPorDia = ventasCompletadas
                .GroupBy(v => v.FechaOcurrencia.Date)
                .Select(g => new { Fecha = g.Key, TotalIngreso = g.Sum(v => v.Total) })
                .OrderBy(x => x.Fecha);

            if (ingresosPorDia.Any())
            {
                foreach (var dataPoint in ingresosPorDia)
                {
                    seriesIngresos.Points.AddXY(dataPoint.Fecha.ToShortDateString(), dataPoint.TotalIngreso);
                }
            }
            else // Mostrar el rango aunque no haya datos
            {
                seriesIngresos.Points.AddXY(_fechaInicioActual.ToShortDateString(), 0);
                if (_fechaInicioActual.Date != _fechaFinActual.Date.AddDays(-1).AddTicks(1)) // Evitar duplicar si es un solo día
                    seriesIngresos.Points.AddXY(_fechaFinActual.Date.AddDays(-1).AddTicks(1).ToShortDateString(), 0);
            }

            chart_IngresoPorFecha.Series.Add(seriesIngresos);
            if (chart_IngresoPorFecha.ChartAreas.Any())
            {
                chart_IngresoPorFecha.ChartAreas[0].AxisX.LabelStyle.Format = "MMM dd";
                chart_IngresoPorFecha.ChartAreas[0].AxisX.Interval = 1; // Mostrar cada día si el rango es pequeño
                chart_IngresoPorFecha.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
                // Auto-ajustar intervalo si el rango es muy grande
                if ((_fechaFinActual - _fechaInicioActual).TotalDays > 30)
                {
                    chart_IngresoPorFecha.ChartAreas[0].AxisX.Interval = 0; // Auto
                    chart_IngresoPorFecha.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Auto;
                }
            }
        }

        private void LoadTopSellingProductsChart(List<Venta> ventasCompletadas)
        {
            if (chart_Top10Products == null || !chart_Top10Products.IsHandleCreated) return;
            chart_Top10Products.Series.Clear();

            Series seriesProductos = new Series("Productos")
            {
                ChartType = SeriesChartType.Doughnut,
                IsValueShownAsLabel = true,
                LabelFormat = "#VALX (#PERCENT{P0})", // Muestra nombre y porcentaje
                Font = new Font("Tahoma", 8F),
                LabelForeColor = Color.FromArgb(37, 60, 48)
            };

            var topProductos = ventasCompletadas
                .SelectMany(v => v.DetallesVenta) // Aplana todos los detalles de venta
                .GroupBy(dv => dv.ProductoId)    // Agrupa por ID de producto
                .Select(g => new
                {
                    // Intenta obtener el nombre del producto. Si el objeto Producto no está cargado en DetalleVenta,
                    // se necesitaría una llamada a _productoService.ObtenerProductoPorId(g.Key).Nombre
                    // Por ahora, asumimos que dv.Producto.Nombre está disponible o lo obtenemos.
                    NombreProducto = g.First().Producto?.Nombre ?? _productoService.ObtenerProductoPorId(g.Key)?.Nombre ?? $"ID:{g.Key}",
                    CantidadTotalVendida = g.Sum(dv => dv.Cantidad)
                })
                .OrderByDescending(p => p.CantidadTotalVendida)
                .Take(10) // Tomar los 10 primeros
                .ToList();

            if (topProductos.Any())
            {
                foreach (var producto in topProductos)
                {
                    DataPoint dp = seriesProductos.Points.Add(producto.CantidadTotalVendida);
                    dp.LegendText = producto.NombreProducto; // Para la leyenda
                    dp.Label = $"{producto.NombreProducto}\n({producto.CantidadTotalVendida})"; // Para la etiqueta en el gráfico
                }
            }
            else
            {
                DataPoint dp = seriesProductos.Points.Add(1);
                dp.LegendText = "Sin datos";
                dp.Label = "Sin datos";
                dp.Color = Color.LightGray;
            }
            chart_Top10Products.Series.Add(seriesProductos);
        }

        private void LoadLowStockProducts(List<Producto> productosDelVendedor)
        {
            if (dgv_PBajoStock == null) return;

            DataTable dt = new DataTable();
            dt.Columns.Add("Producto", typeof(string));
            dt.Columns.Add("Stock Actual", typeof(int));

            var productosBajoStock = productosDelVendedor
                .Where(p => p.Stock < 10) // Umbral de bajo stock
                .OrderBy(p => p.Stock)   // Opcional: ordenar por el que menos stock tiene
                .ToList();

            if (productosBajoStock.Any())
            {
                foreach (var item in productosBajoStock)
                {
                    dt.Rows.Add(item.Nombre, item.Stock);
                }
            }
            dgv_PBajoStock.DataSource = dt;
        }

        private void ibtn_Today_Click(object sender, EventArgs e)
        {
            SetDateRange(DateTime.Today, DateTime.Today);
            DisableCustomDateControls();
            LoadDashboardData();
        }
        private void ibtn_7Days_Click(object sender, EventArgs e)
        {
            SetDateRange(DateTime.Today.AddDays(-6), DateTime.Today);
            DisableCustomDateControls();
            LoadDashboardData();
        }
        private void ibtn_30Days_Click(object sender, EventArgs e)
        {
            SetDateRange(DateTime.Today.AddDays(-29), DateTime.Today);
            DisableCustomDateControls();
            LoadDashboardData();
        }
        private void ibtn_ThisMonth_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
            SetDateRange(firstDayOfMonth, today);
            DisableCustomDateControls();
            LoadDashboardData();
        }
        private void ibtn_CustomDate_Click(object sender, EventArgs e)
        {
            EnableCustomDateControls();
            // No recargar datos aquí, esperar al botón OK
        }

        private void ibtn_OKCustomDate_Click(object sender, EventArgs e)
        {
            if (dtpStartDate.Value.Date > dtpEndDate.Value.Date)
            {
                MessageBox.Show("La fecha de inicio no puede ser posterior a la fecha de fin.", "Error de Fecha", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SetDateRange(dtpStartDate.Value, dtpEndDate.Value); // Actualiza _fechaInicioActual y _fechaFinActual
            LoadDashboardData();
        }
    }
}
