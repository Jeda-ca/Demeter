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
    public partial class Frm_GSalesVendor : Form
    {
        public Frm_GSalesVendor()
        {
            InitializeComponent();
            // Configuración esencial para que este formulario pueda ser incrustado como un control.
            this.TopLevel = false; // Indica que no es una ventana de nivel superior independiente.
            this.FormBorderStyle = FormBorderStyle.None; // Elimina el borde y la barra de título.
            this.Dock = DockStyle.Fill; // Hace que el formulario llene el control contenedor.
        }

        // Evento Load del formulario.
        private void Frm_GSalesVendor_Load(object sender, EventArgs e)
        {
            // Inicializar cbx_TipoV con tipos de reporte de ventas.
            cbx_TipoV.Items.Add("-- Seleccione un tipo de reporte --"); // Índice 0
            cbx_TipoV.Items.Add("VENTAS GENERALES"); // Índice 1
            cbx_TipoV.Items.Add("VENTAS POR CLIENTE"); // Índice 2
            // Puedes añadir más tipos de reporte aquí si es necesario.
            cbx_TipoV.SelectedIndex = 0; // Seleccionar la opción por defecto al inicio

            // Asegurar que los paneles y DateTimePickers estén ocultos al inicio.
            panelFiltro.Visible = false;
            dtp_FInicio.Visible = false;
            dtp_FFin.Visible = false;

            LoadSalesData(); // Carga los datos iniciales en el DataGridView de ventas.
        }

        // --- EVENTOS DE CONTROLES ---

        // Evento SelectedIndexChanged del ComboBox cbx_TipoV.
        private void cbx_TipoV_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFilterPanelVisibility();
        }

        // Evento SelectedIndexChanged del ComboBox cbx_FiltroV.
        private void cbx_FiltroV_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDateTimePickerVisibility();
        }

        // Evento Click del botón "Agregar nueva venta" para abrir Frm_AddSaleVendor
        private void ibtn_Add_Click(object sender, EventArgs e)
        {
            // Lógica para abrir un formulario de agregar venta.
            Frm_AddSaleVendor frmAddSale = new Frm_AddSaleVendor();
            DialogResult result = frmAddSale.ShowDialog(); // Abre el formulario como un diálogo modal

            // Si el formulario se cerró con DialogResult.OK (indicando que se agregó algo)
            // if (result == DialogResult.OK)
            // {
            //    LoadSalesData(); // Recargar la lista de ventas si es necesario.
            // }
        }

        // Evento Click del botón "Buscar" (placeholder para la lógica de búsqueda)
        private void ibtn_Buscar_Click(object sender, EventArgs e)
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

            // Aquí llamarías a la capa BLL para obtener los datos de ventas y llenar el dgv_ListaVentas.
            LoadSalesData(); // Por ahora, solo recarga los datos placeholder
        }

        // Evento Click del botón "Limpiar"
        private void ibtn_Clear_Click(object sender, EventArgs e)
        {
            tbx_Busqueda.Clear();
            cbx_TipoV.SelectedIndex = 0; // Volver a la opción por defecto del tipo de venta
            cbx_FiltroV.Items.Clear(); // Limpiar opciones del filtro secundario
            panelFiltro.Visible = false; // Ocultar panel de filtro
            dtp_FInicio.Visible = false;
            dtp_FFin.Visible = false;
            LoadSalesData(); // Recargar todos los datos de ventas al limpiar.
            MessageBox.Show("Campos de búsqueda y filtro limpiados.", "Limpiar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // --- MÉTODOS PRIVADOS AUXILIARES ---

        // Método para actualizar la visibilidad del panelFiltro y las opciones de cbx_FiltroV.
        private void UpdateFilterPanelVisibility()
        {
            // Limpiar opciones de filtro previas.
            cbx_FiltroV.Items.Clear();
            dtp_FInicio.Visible = false;
            dtp_FFin.Visible = false;

            string selectedReportType = cbx_TipoV.SelectedItem?.ToString();

            // Mostrar panelFiltro solo para tipos de reporte que requieren filtros adicionales.
            // Para "VENTAS GENERALES" y "VENTAS POR CLIENTE" se ofrecerán filtros de fecha.
            if (selectedReportType == "VENTAS GENERALES" || selectedReportType == "VENTAS POR CLIENTE")
            {
                panelFiltro.Visible = true;
                cbx_FiltroV.Items.Add("-- Seleccione un filtro --"); // Índice 0
                cbx_FiltroV.Items.Add("Fecha"); // Índice 1
                cbx_FiltroV.Items.Add("Rango de fecha"); // Índice 2
                // Puedes añadir más filtros aquí, por ejemplo:
                // cbx_FiltroV.Items.Add("Por Cliente Específico");
                cbx_FiltroV.SelectedIndex = 0; // Seleccionar la opción por defecto
            }
            else
            {
                panelFiltro.Visible = false;
            }
        }

        // Método para actualizar la visibilidad de los DateTimePicker.
        private void UpdateDateTimePickerVisibility()
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

        // Método placeholder para cargar/recargar datos de ventas.
        private void LoadSalesData()
        {
            // --- Lógica para cargar datos de ventas desde la capa BLL y llenar el dgv_ListaVentas. ---
            // Por ahora, el DataGridView estará vacío o con columnas definidas.
            DataTable dt = new DataTable();
            dt.Columns.Add("ID Venta", typeof(int));
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("Total", typeof(decimal));
            dt.Columns.Add("Cliente", typeof(string)); // En el módulo de vendedor, no se necesita "Vendedor"
            // No se añaden filas de datos de prueba, solo las columnas.
            // Para probar:
            // dt.Rows.Add(1, DateTime.Now.AddDays(-5), 150.00m, "Ana López"); // DATOS DE PRUEBA
            // dt.Rows.Add(2, DateTime.Now.AddDays(-2), 230.50m, "Carlos Ramírez"); // DATOS DE PRUEBA

            dgv_ListaVentas.DataSource = dt; // Asignar el DataTable al DataGridView
        }
    }
}