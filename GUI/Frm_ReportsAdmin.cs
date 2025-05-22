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
    public partial class Frm_ReportsAdmin : Form
    {
        public Frm_ReportsAdmin()
        {
            InitializeComponent();
            // Configuración esencial para que este formulario pueda ser incrustado como un control.
            this.TopLevel = false; // Indica que no es una ventana de nivel superior independiente.
            this.FormBorderStyle = FormBorderStyle.None; // Elimina el borde y la barra de título.
            this.Dock = DockStyle.Fill; // Hace que el formulario llene el control contenedor.
        }

        // Evento Load del formulario.
        private void Frm_Reports_Load(object sender, EventArgs e) // <-- Nombre del método corregido (si no lo estaba ya)
        {
            // Inicializar el ComboBox con tipos de reporte.
            cbx_TipoReport.Items.Add("-- Seleccione un tipo de reporte --"); // Opción por defecto (Índice 0)
            cbx_TipoReport.Items.Add("VENTAS GENERALES"); // Índice 1
            cbx_TipoReport.Items.Add("VENTAS POR VENDEDOR"); // Índice 2
            cbx_TipoReport.Items.Add("INVENTARIO GENERAL"); // Índice 3
            cbx_TipoReport.Items.Add("INVENTARIO POR VENDEDOR"); // Índice 4
            cbx_TipoReport.Items.Add("LISTA DE CLIENTES"); // Índice 5
            cbx_TipoReport.SelectedIndex = 0; // Seleccionar la opción por defecto al inicio

            // Asegurar que el panel de filtro esté oculto al inicio.
            panelFiltro.Visible = false;
        }

        // Evento SelectedIndexChanged del ComboBox cbx_TipoReport.
        private void cbx_TipoReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            // El panelFiltro se hará visible solo si se selecciona una opción diferente a la por defecto
            // y a "VENTAS GENERALES".
            if (cbx_TipoReport.SelectedIndex > 1) // Es decir, a partir de "VENTAS POR VENDEDOR" (Índice 2)
            {
                panelFiltro.Visible = true;
                // --- Lógica placeholder para cargar opciones específicas en cbx_FiltroReport ---
                cbx_FiltroReport.Items.Clear();
                cbx_FiltroReport.Items.Add("-- Seleccione un filtro --");
                string selectedType = cbx_TipoReport.SelectedItem.ToString();

                if (selectedType == "VENTAS POR VENDEDOR" || selectedType == "INVENTARIO POR VENDEDOR")
                {
                    cbx_FiltroReport.Items.Add("Vendedor Específico");
                    cbx_FiltroReport.Items.Add("Fecha");
                    cbx_FiltroReport.Items.Add("Rango de fecha");
                }
                else if (selectedType == "LISTA DE CLIENTES")
                {
                    cbx_FiltroReport.Items.Add("Cliente Específico");
                }
                // Si añades otros tipos de reporte que necesiten filtro, añádelos aquí.

                cbx_FiltroReport.SelectedIndex = 0;
            }
            else
            {
                panelFiltro.Visible = false;
                cbx_FiltroReport.Items.Clear(); // Limpiar el filtro secundario si el panel se oculta.
            }
            // También deberías llamar a una lógica para cargar el DataGridView aquí con los datos adecuados.
            // LoadReportData(); // Método placeholder para cargar datos del reporte.
        }

        // Método placeholder para el botón de búsqueda.
        private void ibtn_Buscar_Click(object sender, EventArgs e)
        {
            // --- Lógica de búsqueda de reporte basada en el tipo, filtro y texto. ---
            string tipoReporte = cbx_TipoReport.SelectedItem?.ToString();
            string filtroSeleccionado = cbx_FiltroReport.SelectedItem?.ToString(); // Puede ser null
            string textoBusqueda = tbx_BusqReport.Text;

            // Validaciones básicas
            if (cbx_TipoReport.SelectedIndex == 0)
            {
                MessageBox.Show("Por favor, seleccione un tipo de reporte.", "Búsqueda incompleta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show($"Generando Reporte:\nTipo: {tipoReporte}\nFiltro: {filtroSeleccionado ?? "Ninguno"}\nTexto de Búsqueda: {textoBusqueda}", "Generar Reporte (Placeholder)", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Aquí se llamaría a la capa BLL para obtener los datos del reporte y llenar dgv_Reportes.
            LoadReportData(); // Recarga los datos placeholder.
        }

        // Método placeholder para cargar/recargar datos del DataGridView de reportes.
        private void LoadReportData()
        {
            // --- Lógica para cargar datos del reporte en dgv_Reportes. ---
            // Por ahora, el DataGridView estará vacío o con columnas definidas.
            DataTable dt = new DataTable();
            dt.Columns.Add("Columna A", typeof(string));
            dt.Columns.Add("Columna B", typeof(string));
            dt.Columns.Add("Columna C", typeof(string));
            // No se añaden filas de datos de prueba.
            dgv_Reportes.DataSource = dt;
        }
    }
}


//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace GUI
//{
//    public partial class Frm_ReportsAdmin : Form
//    {
//        public Frm_ReportsAdmin()
//        {
//            InitializeComponent();
//            // Configuración esencial para que este formulario pueda ser incrustado como un control.
//            this.TopLevel = false; // Indica que no es una ventana de nivel superior independiente.
//            this.FormBorderStyle = FormBorderStyle.None; // Elimina el borde y la barra de título.
//            this.Dock = DockStyle.Fill; // Hace que el formulario llene el control contenedor.
//        }

//        // Evento Load del formulario.
//        private void Frm_Reports_Load(object sender, EventArgs e)
//        {
//            // Inicializar el ComboBox con tipos de reporte.
//            // Puedes obtener estos datos de la base de datos o una lista predefinida.
//            cbx_TipoReport.Items.Add("-- Seleccione un tipo de reporte --"); // Opción por defecto
//            cbx_TipoReport.Items.Add("VENTAS GENERALES");
//            cbx_TipoReport.Items.Add("VENTAS POR VENDEDOR");
//            cbx_TipoReport.Items.Add("INVENTARIO GENERAL");
//            cbx_TipoReport.Items.Add("INVENTARIO POR VENDEDOR");
//            cbx_TipoReport.Items.Add("LISTA DE CLIENTES");
//            cbx_TipoReport.SelectedIndex = 0; // Seleccionar la opción por defecto al inicio
//        }

//        // Evento SelectedIndexChanged del ComboBox cbx_TipoReport.
//        private void cbx_TipoReport_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            // El panelFiltro se hará visible solo si se selecciona una opción diferente a la por defecto.
//            if (cbx_TipoReport.SelectedIndex > 1) // Si no es la opción "-- Seleccione un tipo de reporte --"
//            {
//                panelFiltro.Visible = true;
//                // Aquí podrías cargar opciones específicas en cbx_FiltroReport
//                // dependiendo del tipo de reporte seleccionado.
//                // Por ejemplo:
//                // if (cbx_TipoReport.SelectedItem.ToString() == "VENTAS POR VENDEDOR")
//                // {
//                //     cbx_FiltroReport.Items.Clear();
//                //     cbx_FiltroReport.Items.Add("Vendedor 1");
//                //     cbx_FiltroReport.Items.Add("Vendedor 2");
//                // }
//            }
//            else
//            {
//                panelFiltro.Visible = false;
//            }
//        }
//    }
//}


////using System;
////using System.Collections.Generic;
////using System.ComponentModel;
////using System.Data;
////using System.Drawing;
////using System.Linq;
////using System.Text;
////using System.Threading.Tasks;
////using System.Windows.Forms;

////namespace GUI
////{
////    public partial class Frm_Reports : Form
////    {
////        public Frm_Reports()
////        {
////            InitializeComponent();
////            // Configuración esencial para que este formulario pueda ser incrustado como un control.
////            this.TopLevel = false; // Indica que no es una ventana de nivel superior independiente.
////            this.FormBorderStyle = FormBorderStyle.None; // Elimina el borde y la barra de título.
////            this.Dock = DockStyle.Fill; // Hace que el formulario llene el control contenedor.
////        }

////        // Evento Load del formulario (sin lógica de carga de datos por ahora, según tu solicitud).
////        private void Frm_GClientesAdmin_Load(object sender, EventArgs e)
////        {
////            // Lógica para cargar datos de vendedores en el DataGridView, etc.
////            // Por ahora, solo es un placeholder.
////        }
////    }
////}
