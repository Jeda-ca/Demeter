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
    public partial class Frm_GeneralSalesReport : Form
    {
        public Frm_GeneralSalesReport()
        {
            InitializeComponent();
            // Configuración esencial para que este formulario pueda ser incrustado como un control.
            this.TopLevel = false; // Indica que no es una ventana de nivel superior independiente.
            this.FormBorderStyle = FormBorderStyle.None; // Elimina el borde y la barra de título.
            this.Dock = DockStyle.Fill; // Hace que el formulario llene el control contenedor.
        }

        // Evento Load del formulario.
        private void Frm_GeneralSalesReport_Load(object sender, EventArgs e)
        {
            LoadReportData(); // Carga los datos iniciales al cargar el formulario.
        }

        // Método placeholder para cargar/recargar datos del DataGridView de ventas generales.
        private void LoadReportData()
        {
            // --- Lógica para cargar datos de ventas generales desde la capa BLL y llenar el dgv_Reportes. ---
            // Por ahora, el DataGridView tendrá columnas definidas y datos de ejemplo.
            DataTable dt = new DataTable();
            dt.Columns.Add("ID Venta", typeof(int));
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("Subtotal", typeof(decimal));
            dt.Columns.Add("Descuento", typeof(decimal));
            dt.Columns.Add("Total", typeof(decimal));
            dt.Columns.Add("Estado", typeof(string));
            dt.Columns.Add("Cliente", typeof(string));
            dt.Columns.Add("Vendedor", typeof(string));

            // Datos de ejemplo para las columnas
            //dt.Rows.Add(1, DateTime.Now.AddDays(-10), 15000.00m, 0.00m, 15000.00m, "COMPLETADA", "Ana Gómez", "Carlos Vargas", "Compra para el hogar");
            //dt.Rows.Add(2, DateTime.Now.AddDays(-5), 13200.00m, 0.00m, 13200.00m, "COMPLETADA", "Jorge Martínez", "Lucía Fernández", "");
            //dt.Rows.Add(3, DateTime.Now.AddDays(-2), 4700.00m, 200.00m, 4500.00m, "PENDIENTE", "Sofía Rojas", "Miguel Suárez", "Para el almuerzo");
            //dt.Rows.Add(4, DateTime.Now.AddDays(-1), 18000.00m, 1000.00m, 17000.00m, "COMPLETADA", "Andrés Parra", "Isabela Mendoza", "Productos para tienda");

            // Asumiendo que el DataGridView se llama dgv_Reportes en tu Designer.cs
            // Si el nombre es diferente, por favor, ajusta esta línea.
            dgv_ReportesVentxVend.DataSource = dt; // Ajusta el nombre de tu DataGridView
        }
    }
}
