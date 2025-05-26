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
    public partial class Frm_GeneralInventoryReport : Form
    {
        public Frm_GeneralInventoryReport()
        {
            InitializeComponent();
            // Configuración esencial para que este formulario pueda ser incrustado como un control.
            this.TopLevel = false; // Indica que no es una ventana de nivel superior independiente.
            this.FormBorderStyle = FormBorderStyle.None; // Elimina el borde y la barra de título.
            this.Dock = DockStyle.Fill; // Hace que el formulario llene el control contenedor.
        }

        // Evento Load del formulario.
        private void Frm_GeneralInventoryReport_Load(object sender, EventArgs e)
        {
            LoadReportData(); // Carga los datos iniciales al cargar el formulario.
        }

        // Método placeholder para cargar/recargar datos del DataGridView de inventario general.
        private void LoadReportData()
        {
            // --- Lógica para cargar datos de inventario desde la capa BLL y llenar el dgv_Reportes. ---
            // Por ahora, el DataGridView tendrá columnas definidas y datos de ejemplo.
            DataTable dt = new DataTable();
            dt.Columns.Add("ID Producto", typeof(int));
            dt.Columns.Add("Nombre Producto", typeof(string));
            dt.Columns.Add("Categoría", typeof(string));
            dt.Columns.Add("Unidad Medida", typeof(string));
            dt.Columns.Add("Stock Actual", typeof(int));
            dt.Columns.Add("Precio Unitario", typeof(decimal));
            dt.Columns.Add("Fecha Última Actualización", typeof(DateTime));

            // Datos de ejemplo para las columnas
            //dt.Rows.Add(101, "Tomate Chonto", "VERDURAS Y HORTALIZAS", "KILOGRAMO", 50, 2800.00m, "Carlos Vargas", DateTime.Now.AddDays(-2));
            //dt.Rows.Add(102, "Mango Tommy", "FRUTAS", "UNIDAD", 60, 3200.00m, "Lucía Fernández", DateTime.Now.AddDays(-1));
            //dt.Rows.Add(103, "Papa Pastusa", "TUBÉRCULOS Y RAÍCES", "KILOGRAMO", 80, 2000.00m, "Miguel Suárez", DateTime.Now.AddDays(-3));
            //dt.Rows.Add(104, "Cebolla Larga", "VERDURAS Y HORTALIZAS", "ATADO", 75, 2200.00m, "Isabela Mendoza", DateTime.Now.AddDays(-4));

            // Asumiendo que el DataGridView se llama dgv_Reportes en tu Designer.cs
            // Si el nombre es diferente, por favor, ajusta esta línea.
            dgv_ReportesVentxVend.DataSource = dt; // Ajusta el nombre de tu DataGridView
        }
    }
}
