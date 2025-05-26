using System;
using System.Data;
using System.Windows.Forms;

namespace GUI
{
    public partial class Frm_GSalesAdmin : Form
    {
        public Frm_GSalesAdmin()
        {
            InitializeComponent();

            // Configuración esencial para que este formulario pueda ser incrustado como un control:
            this.TopLevel = false; // Indica que no es una ventana de nivel superior independiente.
            this.FormBorderStyle = FormBorderStyle.None; // Elimina el borde y la barra de título.
            this.Dock = DockStyle.Fill; // Hace que el formulario llene el control contenedor.
        }
        private void Frm_GSalesAdmin_Load(object sender, EventArgs e) // Evento Load del formulario.
        {
            // Inicializar cbx_TipoReport con tipos de reporte de ventas.
            //cbx_TipoV.Items.Add("-- Seleccione un tipo de reporte --"); // Índice 0
            //cbx_TipoV.Items.Add("VENTAS GENERALES"); // Índice 1
            //cbx_TipoV.Items.Add("VENTAS POR VENDEDOR"); // Índice 2
            //cbx_TipoV.Items.Add("VENTAS POR CLIENTE"); // Índice 3
            // Puedes añadir más tipos de reporte aquí si es necesario.
            // cbx_TipoV.SelectedIndex = 0; // Seleccionar la opción por defecto al inicio

            // Asegurar que los paneles y DateTimePickers estén ocultos al inicio.
            panelFiltro.Visible = false;
            dtp_FInicio.Visible = false;
            dtp_FFin.Visible = false;
        }

        //EVENTOS
        private void cbx_TipoReport_SelectedIndexChanged(object sender, EventArgs e) // Evento SelectedIndexChanged del ComboBox cbx_TipoReport.
        {
            UpdateFilterPanelVisibility();
        }
        private void cbx_FiltroReport_SelectedIndexChanged(object sender, EventArgs e) // Evento SelectedIndexChanged del ComboBox cbx_FiltroReport.
        {
            UpdateDateTimePickerVisibility();
        }
        private void ibtn_StatusVenta_Click(object sender, EventArgs e)
        {

        }
        private void ibtn_CancelVenta_Click(object sender, EventArgs e)
        {

        }

        // MÉTODOS PRIVADOS
        private void UpdateFilterPanelVisibility() // Método para actualizar la visibilidad del panelFiltro y las opciones de cbx_FiltroReport.
        {
            // Limpiar opciones de filtro previas.
            cbx_FiltroV.Items.Clear();
            dtp_FInicio.Visible = false;
            dtp_FFin.Visible = false;

            string selectedReportType = cbx_TipoV.SelectedItem?.ToString();

            // Mostrar panelFiltro solo para tipos de reporte que requieren filtros adicionales.
            // Para "VENTAS POR VENDEDOR" y "VENTAS POR CLIENTE" se ofrecerán filtros de fecha.
            if (selectedReportType == "VENTAS POR VENDEDOR" || selectedReportType == "VENTAS POR CLIENTE")
            {
                panelFiltro.Visible = true;
                cbx_FiltroV.Items.Add("-- Seleccione un filtro --"); // Índice 0
                cbx_FiltroV.Items.Add("Fecha"); // Índice 1
                cbx_FiltroV.Items.Add("Rango de fecha"); // Índice 2
                // Puedes añadir más filtros aquí, por ejemplo:
                // cbx_FiltroReport.Items.Add("Por Vendedor Específico");
                // cbx_FiltroReport.Items.Add("Por Cliente Específico");
                cbx_FiltroV.SelectedIndex = 0; // Seleccionar la opción por defecto
            }
            else
            {
                panelFiltro.Visible = false;
            }
        }
        private void UpdateDateTimePickerVisibility() // Método para actualizar la visibilidad de los DateTimePicker.
        {
            string selectedFilter = cbx_FiltroV.SelectedItem?.ToString();

            dtp_FInicio.Visible = false;
            dtp_FFin.Visible = false;

            if (selectedFilter == "Fecha")
            {
                dtp_FInicio.Visible = true;
                dtp_FFin.Visible = false; // Asegurarse de que el segundo esté oculto
            }
            else if (selectedFilter == "Rango de fecha")
            {
                dtp_FInicio.Visible = true;
                dtp_FFin.Visible = true;
            }
            // Para otros filtros, ambos DateTimePicker permanecerán ocultos.
        }
        private void ibtn_Buscar_Click(object sender, EventArgs e) // Método placeholder para el botón de búsqueda.
        {
            // --- Lógica de búsqueda de ventas basada en el tipo de reporte, filtro y fechas/texto. ---
            string tipoReporte = cbx_TipoV.SelectedItem?.ToString();
            string filtroSeleccionado = cbx_FiltroV.SelectedItem?.ToString();
            string textoBusqueda = tbx_Busqueda.Text;
            DateTime? fechaInicio = dtp_FInicio.Visible ? dtp_FInicio.Value : (DateTime?)null;
            DateTime? fechaFin = dtp_FFin.Visible ? dtp_FFin.Value : (DateTime?)null;

            // Validaciones básicas antes de buscar (pueden ser más robustas)
            if (cbx_TipoV.SelectedIndex == 0) // Si no se ha seleccionado un tipo de reporte
            {
                MessageBox.Show("Por favor, seleccione un tipo de reporte de ventas.", "Búsqueda incompleta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show($"Buscando Ventas:\nTipo: {tipoReporte}\nFiltro: {filtroSeleccionado ?? "N/A"}\nTexto: {textoBusqueda}\nFecha Inicio: {fechaInicio?.ToShortDateString() ?? "N/A"}\nFecha Fin: {fechaFin?.ToShortDateString() ?? "N/A"}", "Búsqueda de Ventas (Placeholder)", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Aquí llamarías a la capa BLL para obtener los datos de ventas y llenar el dgv_Reportes.
            LoadSalesData(); // Por ahora, solo recarga los datos placeholder
        }
        private void LoadSalesData() // Método placeholder para cargar/recargar datos de ventas.
        {
            // --- Lógica para cargar datos de ventas desde la capa BLL y llenar el dgv_Reportes. ---
            // Por ahora, el DataGridView estará vacío o con columnas definidas.
            DataTable dt = new DataTable();
            dt.Columns.Add("ID Venta", typeof(int));
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("Total", typeof(decimal));
            dt.Columns.Add("Vendedor", typeof(string));
            dt.Columns.Add("Cliente", typeof(string));
            // No se añaden filas de datos de prueba, solo las columnas.
            // Para probar:
            // dt.Rows.Add(1, DateTime.Now.AddDays(-5), 150.00m, "Juan Pérez", "Ana López"); // DATOS DE PRUEBA
            // dt.Rows.Add(2, DateTime.Now.AddDays(-2), 230.50m, "María Gómez", "Carlos Ramírez"); // DATOS DE PRUEBA

            dgv_ListaVentas.DataSource = dt; // Asignar el DataTable al DataGridView
        }
    }
}
