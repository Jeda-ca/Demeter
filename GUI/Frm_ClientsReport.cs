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
    public partial class Frm_ClientsReport : Form
    {
        public Frm_ClientsReport()
        {
            InitializeComponent();
            // Configuración esencial para que este formulario pueda ser incrustado como un control.
            this.TopLevel = false; // Indica que no es una ventana de nivel superior independiente.
            this.FormBorderStyle = FormBorderStyle.None; // Elimina el borde y la barra de título.
            this.Dock = DockStyle.Fill; // Hace que el formulario llene el control contenedor.
        }

        // Evento Load del formulario.
        private void Frm_ClientsReport_Load(object sender, EventArgs e)
        {
            LoadReportData(); // Carga los datos iniciales al cargar el formulario.
        }

        // Método placeholder para cargar/recargar datos del DataGridView de reportes de clientes.
        private void LoadReportData()
        {
            // --- Lógica para cargar datos de clientes desde la capa BLL y llenar el dgv_Reportes. ---
            // Por ahora, el DataGridView tendrá columnas definidas y datos de ejemplo.
            DataTable dt = new DataTable();
            dt.Columns.Add("ID Cliente", typeof(int));
            dt.Columns.Add("Nombre Completo", typeof(string));
            dt.Columns.Add("Tipo Documento", typeof(string));
            dt.Columns.Add("Número Documento", typeof(string));
            dt.Columns.Add("Teléfono", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("Fecha Registro", typeof(DateTime));

            // Datos de ejemplo para las columnas
            //dt.Rows.Add(1, "Ana López", "Cédula de Ciudadanía", "1001001", "3011112233", "ana.lopez@example.com", DateTime.Now.AddMonths(-6), DateTime.Now.AddDays(-10), true);
            //dt.Rows.Add(2, "Jorge Martínez", "Cédula de Ciudadanía", "1001002", "3152233402", "jorge.martinez@example.com", DateTime.Now.AddMonths(-8), DateTime.Now.AddDays(-5), true);
            //dt.Rows.Add(3, "Sofía Rojas", "Cédula de Extranjería", "X000001Z", "3213344503", "sofia.rojas@example.com", DateTime.Now.AddMonths(-12), DateTime.Now.AddDays(-30), false);
            //dt.Rows.Add(4, "Andrés Parra", "Cédula de Ciudadanía", "1001003", "3004455604", "andres.parra@example.com", DateTime.Now.AddMonths(-3), DateTime.Now.AddDays(-2), true);

            // Asumiendo que el DataGridView se llama dgv_Reportes en tu Designer.cs
            // Si el nombre es diferente, por favor, ajusta esta línea.
            // Por ejemplo, si se llama dgv_ListaClientes: dgv_ListaClientes.DataSource = dt;
            // Si no tienes un dgv en este formulario, puedes omitir esta línea o añadir uno.
            dgv_ReportesVentxVend.DataSource = dt; // Ajusta el nombre de tu DataGridView
        }
    }
}
