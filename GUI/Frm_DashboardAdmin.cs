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
        public Frm_DashboardAdmin() // Constructor del formulario.
        {
            InitializeComponent();

            // Configuración para que este formulario pueda ser incrustado como un control al Frm_MainAdmin:
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            SetDateRange(DateTime.Today, DateTime.Today); // Inicializar el rango de fechas a "Hoy" por defecto.
            DisableCustomDateControls(); // Deshabilita los controles de fecha personalizada al inicio.

            ApplyChartStyles();// Aplicar estilos generales a los gráficos una sola vez al inicio.
        }
        private void Frm_DashboardAdmin_Load(object sender, EventArgs e) // Evento Load del formulario.
        {
            LoadDashboardData(); // Carga los datos iniciales al cargar el formulario (sin datos por ahora).
        }

        // Método principal para cargar todos los datos del dashboard.
        private void LoadDashboardData()
        {
            // Las llamadas a los métodos de actualización se mantienen, pero estos no poblarán datos por ahora.
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;

            UpdateSummaryCards(startDate, endDate);
            UpdateTotalCounters();
            LoadSalesChart(startDate, endDate); // Solo define la serie y el título
            LoadTopSellingProductsChart(); // Solo define la serie y el título
            LoadLowStockProducts();
        }

        // --- EVENTOS DEL FORMULARIO Y BOTONES ---
        private void ibtn_Today_Click(object sender, EventArgs e) // Evento Click del botón "Hoy".
        {
            DisableCustomDateControls();
            SetDateRange(DateTime.Today, DateTime.Today);
        }
        private void ibtn_7Days_Click(object sender, EventArgs e) // Evento Click del botón "Últ. 7 días".
        {
            DisableCustomDateControls();
            SetDateRange(DateTime.Today.AddDays(-6), DateTime.Today); // Últimos 7 días incluyendo hoy.
        }
        private void ibtn_30Days_Click(object sender, EventArgs e) // Evento Click del botón "Últ. 30 días".
        {
            DisableCustomDateControls();
            SetDateRange(DateTime.Today.AddDays(-29), DateTime.Today); // Últimos 30 días incluyendo hoy.
        }
        private void ibtn_ThisMonth_Click(object sender, EventArgs e) // Evento Click del botón "Este mes".
        {
            DisableCustomDateControls();
            DateTime firstDayOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            SetDateRange(firstDayOfMonth, DateTime.Today);
        }
        private void ibtn_CustomDate_Click(object sender, EventArgs e) // Evento Click del botón "Fecha personalizada".
        {
            EnableCustomDateControls();
        }
        private void ibtn_OKCustomDate_Click(object sender, EventArgs e) // Evento Click del botón "OK" para fecha personalizada.
        {
            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                MessageBox.Show("La fecha de inicio no puede ser posterior a la fecha de fin.", "Error de Fecha", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoadDashboardData(); // Recarga los datos con el rango de fechas personalizado (sin datos por ahora).
        }

        // --- MÉTODOS PRIVADOS ---
        private void UpdateSummaryCards(DateTime startDate, DateTime endDate) // Actualiza los valores de las tarjetas de resumen (Ventas y Ganancias).
        {
            // Valores de ejemplo vacíos o "N/A" por ahora.
            lblVentas.Text = "N/A";
            lblGanancias.Text = "N/A";
        }
        private void UpdateTotalCounters() // Actualiza los contadores totales (Clientes, Vendedores, Productos).
        {
            // Valores de ejemplo vacíos o "N/A" por ahora.
            lblClientes.Text = "N/A";
            lblVendedores.Text = "N/A";
            lblProductos.Text = "N/A";
        }

        // Carga datos en el gráfico de ventas por fecha (chart_IngresoPorFecha).
        // Este método se enfoca en la serie de datos y el título, los estilos generales están en ApplyChartStyles().
        private void LoadSalesChart(DateTime startDate, DateTime endDate)
        {
            chart_IngresoPorFecha.Series.Clear();
            chart_IngresoPorFecha.Titles.Clear();

            // Título del gráfico
            Title title = new Title("Ingreso bruto por Fecha", Docking.Top);
            title.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(37, 60, 48); // Verde oscuro
            chart_IngresoPorFecha.Titles.Add(title);

            // Serie de datos (vacía por ahora, solo se define el tipo y color de la serie)
            Series series = new Series("Ingresos");
            series.ChartType = SeriesChartType.Area; // Gráfico de área para tendencia
            series.Color = Color.FromArgb(49, 133, 201); // Azul claro
            series.BorderColor = Color.FromArgb(45, 66, 98); // Azul oscuro
            series.BorderWidth = 2;
            series.MarkerStyle = MarkerStyle.Circle;
            series.MarkerSize = 8;
            series.MarkerColor = Color.FromArgb(251, 203, 91); // Amarillo
            // No se añaden puntos de datos por ahora.
            chart_IngresoPorFecha.Series.Add(series);
        }

        // Carga datos en el gráfico de pastel de productos más vendidos (chart_Top10Products).
        // Este método se enfoca en la serie de datos y el título, los estilos generales están en ApplyChartStyles().
        private void LoadTopSellingProductsChart()
        {
            chart_Top10Products.Series.Clear();
            chart_Top10Products.Titles.Clear();

            // Título del gráfico
            Title title = new Title("Top 10 productos más vendidos", Docking.Top);
            title.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(37, 60, 48); // Verde oscuro
            chart_Top10Products.Titles.Add(title);

            // Serie de datos (vacía por ahora, solo se define el tipo y formato de la serie)
            Series series = new Series("Productos");
            series.ChartType = SeriesChartType.Doughnut; // Gráfico de anillo
            series.IsValueShownAsLabel = true; // Mostrar valores en las etiquetas
            series.LabelFormat = "#VALX (#PERCENT{P0})"; // Formato: Nombre (Porcentaje)
            series.Font = new Font("Tahoma", 9F, FontStyle.Bold);
            series.LabelForeColor = Color.White; // Color de las etiquetas
            series.BorderWidth = 2;
            series.BorderColor = Color.FromArgb(237, 233, 221); // Color del borde de los segmentos
            series["DoughnutRadius"] = "60"; // Tamaño del agujero central

            // No se añaden puntos de datos por ahora.
            chart_Top10Products.Series.Add(series);
        }

        // Carga datos en la tabla de productos con bajo stock (dgv_PBajoStock).
        // Este método se enfoca en la definición de columnas.
        private void LoadLowStockProducts()
        {
            DataTable dtBajoStock = new DataTable();
            dtBajoStock.Columns.Add("Producto", typeof(string));
            dtBajoStock.Columns.Add("Stock", typeof(int));

            // La tabla estará vacía por ahora.
            dgv_PBajoStock.DataSource = dtBajoStock;

            // Ajustar el estilo de las columnas si es necesario (HeaderText)
            dgv_PBajoStock.Columns["Producto"].HeaderText = "Producto";
            dgv_PBajoStock.Columns["Stock"].HeaderText = "Stock";
        }

        // Método para aplicar estilos generales a los gráficos (llamado desde el constructor).
        // Contiene estilos que no cambian con los datos y son comunes a las áreas/leyendas.
        private void ApplyChartStyles()
        {
            // Estilos para chart_IngresoPorFecha
            chart_IngresoPorFecha.ChartAreas[0].AxisX.IsLabelAutoFit = true;
            chart_IngresoPorFecha.ChartAreas[0].AxisY.IsLabelAutoFit = true;
            chart_IngresoPorFecha.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Tahoma", 8.25F, FontStyle.Regular);
            chart_IngresoPorFecha.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Tahoma", 8.25F, FontStyle.Regular);
            chart_IngresoPorFecha.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chart_IngresoPorFecha.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart_IngresoPorFecha.ChartAreas[0].AxisX.LineColor = Color.FromArgb(45, 66, 98); // Azul oscuro
            chart_IngresoPorFecha.ChartAreas[0].AxisY.LineColor = Color.FromArgb(45, 66, 98); // Azul oscuro
            chart_IngresoPorFecha.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.FromArgb(45, 66, 98); // Azul oscuro
            chart_IngresoPorFecha.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.FromArgb(45, 66, 98); // Azul oscuro
            chart_IngresoPorFecha.ChartAreas[0].BackColor = Color.FromArgb(237, 233, 221); // Fondo del área de gráfico
            chart_IngresoPorFecha.BackColor = Color.FromArgb(237, 233, 221); // Fondo del control Chart
            if (chart_IngresoPorFecha.Legends.Any())
            {
                chart_IngresoPorFecha.Legends[0].LegendStyle = LegendStyle.Table;
                chart_IngresoPorFecha.Legends[0].BackColor = Color.FromArgb(237, 233, 221); // Fondo de la leyenda
                chart_IngresoPorFecha.Legends[0].ForeColor = Color.FromArgb(37, 60, 48); // Color de texto de la leyenda
            }

            // Estilos para chart_Top10Products
            chart_Top10Products.ChartAreas[0].BackColor = Color.FromArgb(237, 233, 221); // Fondo del área de gráfico
            chart_Top10Products.BackColor = Color.FromArgb(237, 233, 221); // Fondo del control Chart
            if (chart_Top10Products.Legends.Any())
            {
                chart_Top10Products.Legends[0].BackColor = Color.FromArgb(237, 233, 221); // Fondo de la leyenda
                chart_Top10Products.Legends[0].ForeColor = Color.FromArgb(37, 60, 48); // Color de texto de la leyenda
                chart_Top10Products.Legends[0].Docking = Docking.Bottom; // Leyenda en la parte inferior
                chart_Top10Products.Legends[0].Alignment = StringAlignment.Center; // Centrar leyenda
            }
        }

        // --- MANEJO DE RANGO DE FECHAS ---
        private void SetDateRange(DateTime startDate, DateTime endDate) // Establece el rango de fechas en los DateTimePicker y recarga los datos.
        {
            dtpStartDate.Value = startDate;
            dtpEndDate.Value = endDate;
            LoadDashboardData(); // Recarga los datos con el nuevo rango (que ahora no poblará datos).
        }
        private void EnableCustomDateControls() // Habilita los controles de fecha personalizada.
        {
            dtpStartDate.Enabled = true;
            dtpEndDate.Enabled = true;
            ibtn_OKCustomDate.Visible = true; // Hacer visible el botón OK
        }
        private void DisableCustomDateControls() // Deshabilita los controles de fecha personalizada.
        {
            dtpStartDate.Enabled = false;
            dtpEndDate.Enabled = false;
            ibtn_OKCustomDate.Visible = false; // Ocultar el botón OK
        }        
    }
}