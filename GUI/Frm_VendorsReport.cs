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
    public partial class Frm_VendorsReport : Form
    {
        public Frm_VendorsReport()
        {
            InitializeComponent();
            // Configuración esencial para que este formulario pueda ser incrustado como un control.
            this.TopLevel = false; // Indica que no es una ventana de nivel superior independiente.
            this.FormBorderStyle = FormBorderStyle.None; // Elimina el borde y la barra de título.
            this.Dock = DockStyle.Fill; // Hace que el formulario llene el control contenedor.
        }

        // Evento Load del formulario.
        private void Frm_VendorsReport_Load(object sender, EventArgs e)
        {
            LoadReportData(); // Carga los datos iniciales al cargar el formulario.
        }

        // Método placeholder para cargar/recargar datos del DataGridView de reportes de vendedores.
        private void LoadReportData()
        {
            // --- Lógica para cargar datos de vendedores desde la capa BLL y llenar el dgv_Reportes. ---
            // Por ahora, el DataGridView tendrá columnas definidas y datos de ejemplo.
            DataTable dt = new DataTable();
            dt.Columns.Add("ID Vendedor", typeof(int));
            dt.Columns.Add("Nombre Completo", typeof(string));
            dt.Columns.Add("Código Vendedor", typeof(string));
            dt.Columns.Add("Teléfono", typeof(string));
            dt.Columns.Add("Fecha Registro", typeof(DateTime));
            dt.Columns.Add("Total Ventas Realizadas", typeof(decimal)); // Puedes añadir métricas de ventas aquí

            // Datos de ejemplo para las columnas
            //dt.Rows.Add(1, "Carlos Vargas", "VEND-CV-001", "3101234501", DateTime.Now.AddMonths(-6), 15000000.00m);
            //dt.Rows.Add(2, "Lucía Fernández", "VEND-LF-002", "3202345602", DateTime.Now.AddMonths(-5), 12000000.00m);
            //dt.Rows.Add(3, "Miguel Suárez", "VEND-MS-003", "3113456703", DateTime.Now.AddMonths(-4), 8000000.00m);
            //dt.Rows.Add(4, "Isabela Mendoza", "VEND-IM-004", "3214567804", DateTime.Now.AddMonths(-3), 20000000.00m);

            // Asumiendo que el DataGridView se llama dgv_Reportes en tu Designer.cs
            // Si el nombre es diferente, por favor, ajusta esta línea.
            dgv_ReportesVentxVend.DataSource = dt; // Ajusta el nombre de tu DataGridView
        }
    }
}
