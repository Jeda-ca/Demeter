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
        private readonly int _idVendedorTabla;
        // Ejemplo de servicios que podrías necesitar:
        // private readonly IVentaService _ventaService;
        // private readonly IProductoService _productoService;

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
                // Aquí inicializarías tus servicios BLL
                // _ventaService = new VentaService();
                // _productoService = new ProductoService();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar servicios en Dashboard Vendedor: {ex.Message}", "Error de Inicialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Considera deshabilitar funcionalidades si la inicialización de servicios falla
            }
        }

        private void Frm_DashboardVendor_Load(object sender, EventArgs e)
        {
            if (_idVendedorTabla > 0)
            {
                // Configuración inicial de fechas y UI
                SetDateRange(DateTime.Today, DateTime.Today);
                DisableCustomDateControls();
                ApplyChartStyles(); // Aplica estilos base a los gráficos
                LoadDashboardData(); // Carga los datos (inicialmente placeholders o vacíos)
            }
        }

        private void LoadDashboardData()
        {
            // Este método se encargará de llamar a los servicios BLL para obtener datos
            // y actualizar los componentes del dashboard (labels, gráficos, grilla).
            // Por ahora, usaremos datos de placeholder para que la UI se vea.

            DateTime startDate = dtpStartDate.Value.Date; // Asegúrate que dtpStartDate existe en tu Designer
            DateTime endDate = dtpEndDate.Value.Date.AddDays(1).AddTicks(-1); // Asegúrate que dtpEndDate existe

            // Actualizar tarjetas de resumen (labels)
            if (lblVentas != null) lblVentas.Text = "0"; // Placeholder
            if (lblProducts != null) lblProducts.Text = "0"; // Placeholder
            if (lblGanancias != null) lblGanancias.Text = "$0.00"; // Placeholder

            // Cargar gráficos (con datos de placeholder o vacíos)
            LoadSalesChart(startDate, endDate);
            LoadTopSellingProductsChart();
            LoadLowStockProducts();
        }

        private void SetDateRange(DateTime startDate, DateTime endDate)
        {
            if (dtpStartDate != null) dtpStartDate.Value = startDate;
            if (dtpEndDate != null) dtpEndDate.Value = endDate;
        }

        private void DisableCustomDateControls()
        {
            if (dtpStartDate != null) dtpStartDate.Enabled = false;
            if (dtpEndDate != null) dtpEndDate.Enabled = false;
            // Asegúrate que ibtn_OKCustomDate exista en tu Designer y tenga este nombre
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
            // Estilos para chart_IngresoPorFecha
            if (chart_IngresoPorFecha != null && chart_IngresoPorFecha.ChartAreas.Count > 0)
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

            // Estilos para chart_Top10Products
            if (chart_Top10Products != null && chart_Top10Products.ChartAreas.Count > 0)
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

        private void LoadSalesChart(DateTime startDate, DateTime endDate)
        {
            if (chart_IngresoPorFecha == null || !chart_IngresoPorFecha.IsHandleCreated) return;
            chart_IngresoPorFecha.Series.Clear();

            Series seriesIngresos = new Series("Ingresos")
            {
                ChartType = SeriesChartType.Area,
                Color = Color.FromArgb(150, 75, 150, 225), // Un azul más suave
                BorderColor = Color.FromArgb(45, 66, 98),
                BorderWidth = 2
            };
            // TODO: Reemplazar con datos reales del servicio BLL
            // Ejemplo: var salesData = _ventaService.ObtenerIngresosPorFechaParaVendedor(_idVendedorTabla, startDate, endDate);
            // foreach (var dataPoint in salesData) { seriesIngresos.Points.AddXY(dataPoint.Fecha, dataPoint.Ingreso); }
            seriesIngresos.Points.AddXY(startDate.ToOADate(), 0); // Placeholder
            seriesIngresos.Points.AddXY(endDate.ToOADate(), 0);   // Placeholder
            chart_IngresoPorFecha.Series.Add(seriesIngresos);
            chart_IngresoPorFecha.ChartAreas[0].AxisX.LabelStyle.Format = "MMM dd"; // Formato de fecha
        }

        private void LoadTopSellingProductsChart()
        {
            if (chart_Top10Products == null || !chart_Top10Products.IsHandleCreated) return;
            chart_Top10Products.Series.Clear();

            Series seriesProductos = new Series("Productos")
            {
                ChartType = SeriesChartType.Doughnut,
                IsValueShownAsLabel = true,
                LabelFormat = "#VALX (#PERCENT{P0})",
                Font = new Font("Tahoma", 8F),
                LabelForeColor = Color.FromArgb(37, 60, 48)
            };
            // TODO: Reemplazar con datos reales del servicio BLL
            // Ejemplo: var topProducts = _productoService.ObtenerTopProductosVendidosPorVendedor(_idVendedorTabla, 10);
            // foreach (var product in topProducts) { seriesProductos.Points.AddXY(product.Nombre, product.CantidadVendida); }
            seriesProductos.Points.AddXY("Producto A", 0); // Placeholder
            chart_Top10Products.Series.Add(seriesProductos);
        }

        private void LoadLowStockProducts()
        {
            if (dgv_PBajoStock == null) return; // dgv_PBajoStock es el DataGridView para productos con bajo stock
            DataTable dt = new DataTable();
            dt.Columns.Add("Producto", typeof(string));
            dt.Columns.Add("Stock Actual", typeof(int));
            // TODO: Reemplazar con datos reales del servicio BLL
            // Ejemplo: var lowStock = _productoService.ObtenerProductosBajoStockPorVendedor(_idVendedorTabla, 10); // umbral de 10
            // foreach (var item in lowStock) { dt.Rows.Add(item.Nombre, item.Stock); }
            dgv_PBajoStock.DataSource = dt;
        }

        // --- MANEJADORES DE EVENTOS PARA BOTONES DE FECHA ---
        // Asegúrate que los nombres de estos métodos coincidan con los de tu Frm_DashboardVendor.Designer.cs

        private void ibtn_Today_Click(object sender, EventArgs e)
        {
            DisableCustomDateControls();
            SetDateRange(DateTime.Today, DateTime.Today);
            LoadDashboardData();
        }
        private void ibtn_7Days_Click(object sender, EventArgs e)
        {
            DisableCustomDateControls();
            SetDateRange(DateTime.Today.AddDays(-6), DateTime.Today);
            LoadDashboardData();
        }
        private void ibtn_30Days_Click(object sender, EventArgs e)
        {
            DisableCustomDateControls();
            SetDateRange(DateTime.Today.AddDays(-29), DateTime.Today);
            LoadDashboardData();
        }
        private void ibtn_ThisMonth_Click(object sender, EventArgs e)
        {
            DisableCustomDateControls();
            DateTime today = DateTime.Today;
            DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
            SetDateRange(firstDayOfMonth, today);
            LoadDashboardData();
        }
        private void ibtn_CustomDate_Click(object sender, EventArgs e)
        {
            EnableCustomDateControls();
        }

        // Este es el método que causaba el error CS1061
        private void ibtn_OKCustomDate_Click(object sender, EventArgs e)
        {
            if (dtpStartDate.Value.Date > dtpEndDate.Value.Date)
            {
                MessageBox.Show("La fecha de inicio no puede ser posterior a la fecha de fin.", "Error de Fecha", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoadDashboardData();
        }
    }
}
