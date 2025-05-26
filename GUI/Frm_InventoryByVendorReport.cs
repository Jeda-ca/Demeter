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
    public partial class Frm_InventoryByVendorReport : Form
    {
        public Frm_InventoryByVendorReport()
        {
            InitializeComponent();
            // Configuración esencial para que este formulario pueda ser incrustado como un control.
            this.TopLevel = false; // Indica que no es una ventana de nivel superior independiente.
            this.FormBorderStyle = FormBorderStyle.None; // Elimina el borde y la barra de título.
            this.Dock = DockStyle.Fill; // Hace que el formulario llene el control contenedor.
        }

        // Evento Load del formulario.
        private void Frm_InventoryByVendorReport_Load(object sender, EventArgs e)
        {
            LoadReportData(); // Carga los datos iniciales al cargar el formulario.
        }

        // Método placeholder para cargar/recargar datos del DataGridView de inventario por vendedor.
        private void LoadReportData()
        {
            // --- Lógica para cargar datos de inventario por vendedor desde la capa BLL y llenar el dgv_Reportes. ---
            // Por ahora, el DataGridView tendrá columnas definidas y datos de ejemplo.
            DataTable dt = new DataTable();
            dt.Columns.Add("ID Producto", typeof(int));
            dt.Columns.Add("Nombre Producto", typeof(string));
            dt.Columns.Add("Categoría", typeof(string));
            dt.Columns.Add("Stock Actual", typeof(int));
            dt.Columns.Add("Precio Unitario", typeof(decimal));
            dt.Columns.Add("Fecha Última Actualización", typeof(DateTime));

            // Datos de ejemplo para las columnas (simulando inventario de un vendedor específico)
            //dt.Rows.Add(101, "Tomate Chonto", "VERDURAS Y HORTALIZAS", 50, 2800.00m, DateTime.Now.AddDays(-2));
            //dt.Rows.Add(105, "Huevos Criollos", "HUEVOS Y LÁCTEOS", 30, 9000.00m, DateTime.Now.AddDays(-1));
            //dt.Rows.Add(109, "Plátano Maduro", "FRUTAS", 70, 1500.00m, DateTime.Now.AddDays(-3));
            //dt.Rows.Add(113, "Mazorca Tierna", "VERDURAS Y HORTALIZAS", 120, 1000.00m, DateTime.Now.AddDays(-4));

            // Asumiendo que el DataGridView se llama dgv_Reportes en tu Designer.cs
            // Si el nombre es diferente, por favor, ajusta esta línea.
            dgv_ReportesVentxVend.DataSource = dt; // Ajusta el nombre de tu DataGridView
        }
    }
}
