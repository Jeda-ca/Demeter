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
        public Frm_SalesByVendorReport()
        {
            InitializeComponent();
            // Configuración esencial para que este formulario pueda ser incrustado como un control.
            this.TopLevel = false; // Indica que no es una ventana de nivel superior independiente.
            this.FormBorderStyle = FormBorderStyle.None; // Elimina el borde y la barra de título.
            this.Dock = DockStyle.Fill; // Hace que el formulario llene el control contenedor.
            
            ibtn_Buscar.Click += ibtn_Buscar_Click;
            cbx_FiltroV.SelectedIndexChanged += cbx_FiltroV_SelectedIndexChanged;


            // Inicializar el ComboBox de filtro (placeholder)
            cbx_FiltroV.Items.Add("-- Seleccione un filtro --"); // Índice 0
            cbx_FiltroV.Items.Add("Fecha"); // Índice 1
            cbx_FiltroV.Items.Add("Rango de fecha"); // Índice 2
            cbx_FiltroV.SelectedIndex = 0; // Seleccionar la opción por defecto al inicio

            // Asegurar que los DateTimePickers estén ocultos al inicio.
            // Asumiendo que dtp_FInicio y dtp_FFin existen en el Designer.cs
            // Si no existen, estas líneas causarán un error.
            // dtp_FInicio.Visible = false;
            // dtp_FFin.Visible = false;
        }

        // Evento Load del formulario.
        // Nombre del método corregido para coincidir con el nombre del formulario.
        private void Frm_SalesByVendorReport_Load(object sender, EventArgs e)
        {
            LoadReportData(); // Carga los datos iniciales al cargar el formulario.
        }

        // Método para actualizar la visibilidad de los DateTimePicker.
        private void UpdateDateTimePickerVisibility()
        {
            string selectedFilter = cbx_FiltroV.SelectedItem?.ToString();

            // Asumiendo que dtp_FInicio y dtp_FFin existen en el Designer.cs
            // Si no existen, estas líneas causarán un error.
            // dtp_FInicio.Visible = false;
            // dtp_FFin.Visible = false;

            if (selectedFilter == "Fecha")
            {
                // dtp_FInicio.Visible = true;
                // dtp_FFin.Visible = false; // Asegurarse de que el segundo esté oculto
            }
            else if (selectedFilter == "Rango de fecha")
            {
                // dtp_FInicio.Visible = true;
                // dtp_FFin.Visible = true;
            }
            // Para otros filtros, ambos DateTimePicker permanecerán ocultos.
        }

        // Evento SelectedIndexChanged del ComboBox cbx_FiltroV.
        // Nombre del método corregido para coincidir con el nombre del control en Designer.cs.
        private void cbx_FiltroV_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDateTimePickerVisibility();
        }

        // Método placeholder para el botón de búsqueda.
        private void ibtn_Buscar_Click(object sender, EventArgs e)
        {
            // --- Lógica de búsqueda de reporte basada en el tipo, filtro y texto. ---
            string filtroSeleccionado = cbx_FiltroV.SelectedItem?.ToString(); // Puede ser null
            // string textoBusqueda = tbx_BusqReport.Text; // Asumiendo tbx_BusqReport existe
            // DateTime? fechaInicio = dtp_FInicio.Visible ? dtp_FInicio.Value : (DateTime?)null;
            // DateTime? fechaFin = dtp_FFin.Visible ? dtp_FFin.Value : (DateTime?)null;

            // Validaciones básicas
            if (cbx_FiltroV.SelectedIndex == 0)
            {
                MessageBox.Show("Por favor, seleccione un tipo de filtro.", "Búsqueda incompleta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show($"Generando Reporte:\nFiltro: {filtroSeleccionado ?? "Ninguno"}", "Generar Reporte (Placeholder)", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Aquí se llamaría a la capa BLL para obtener los datos del reporte y llenar dgv_ReportesVentxVend.
            LoadReportData(); // Recarga los datos placeholder.
        }

        // Método placeholder para cargar/recargar datos del DataGridView de reportes de ventas por vendedor.
        private void LoadReportData()
        {
            // --- Lógica para cargar datos del reporte en dgv_ReportesVentxVend. ---
            // Por ahora, el DataGridView tendrá columnas definidas y datos de ejemplo.
            DataTable dt = new DataTable();
            dt.Columns.Add("ID Venta", typeof(int));
            dt.Columns.Add("Fecha Ocurrencia", typeof(DateTime));
            dt.Columns.Add("Total Venta", typeof(decimal));
            dt.Columns.Add("Cliente", typeof(string));
            dt.Columns.Add("Estado", typeof(string));

            // Datos de ejemplo para las columnas (simulando ventas de un vendedor específico)
            //dt.Rows.Add(1, DateTime.Now.AddDays(-10), 15000.00m, "Ana Gómez", "COMPLETADA");
            //dt.Rows.Add(5, DateTime.Now.AddDays(-3), 11800.00m, "Camila Torres", "COMPLETADA");
            //dt.Rows.Add(9, DateTime.Now.AddDays(-1), 7000.00m, "Daniela Moreno", "PENDIENTE");

            // Asumiendo que el DataGridView se llama dgv_ReportesVentxVend en tu Designer.cs
            // Si el nombre es diferente, por favor, ajusta esta línea.
            dgv_ReportesVentxVend.DataSource = dt; // Ajusta el nombre de tu DataGridView
        }
    }
}
