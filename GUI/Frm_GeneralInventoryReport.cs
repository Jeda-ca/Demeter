using BLL.Interfaces;
using BLL.Services;
using ENTITY;
using GUI.Helpers;
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
        private readonly IReporteService _reporteService;
        private readonly int _idAdminLogueado;
        private IEnumerable<Producto> _productosActualesParaReporte; // Variable para guardar los datos

        public Frm_GeneralInventoryReport(int idAdminLogueado)
        {
            InitializeComponent();
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            _idAdminLogueado = idAdminLogueado;
            _productosActualesParaReporte = new List<Producto>(); // Inicializar

            if (_idAdminLogueado <= 0)
            {
                MessageBox.Show("Error: ID de administrador no válido.", "Error de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new MethodInvoker(this.Close));
                return;
            }

            try
            {
                _reporteService = new ReporteService();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico al inicializar servicios: {ex.Message}", "Error de Inicialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                var btnGenerar = this.Controls.Find("ibtn_Add", true).FirstOrDefault();
                if (btnGenerar != null) btnGenerar.Enabled = false;

            }
        }

        private void Frm_GeneralInventoryReport_Load(object sender, EventArgs e)
        {
            if (_idAdminLogueado > 0 && _reporteService != null)
            {

                GenerarReporteInventario();
            }
        }

        private void GenerarReporteInventario()
        {
            try
            {
                if (_reporteService == null)
                {
                    MessageBox.Show("Servicio de reportes no inicializado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _productosActualesParaReporte = new List<Producto>();
                    if (dgv_ReportesVentxVend != null) dgv_ReportesVentxVend.DataSource = null;
                    return;
                }

                string mensajeError;
                _productosActualesParaReporte = _reporteService.GenerarReporteInventarioGeneral(_idAdminLogueado, out mensajeError);

                if (!string.IsNullOrEmpty(mensajeError))
                {
                    MessageBox.Show(mensajeError, "Error al Generar Reporte", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _productosActualesParaReporte = new List<Producto>();
                    if (dgv_ReportesVentxVend != null) dgv_ReportesVentxVend.DataSource = null;
                    return;
                }
                if (_productosActualesParaReporte == null) // Verificación adicional
                {
                    _productosActualesParaReporte = new List<Producto>();
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("IdProducto", typeof(int));
                dt.Columns.Add("Nombre Producto", typeof(string));
                dt.Columns.Add("Categoría", typeof(string));
                dt.Columns.Add("Unidad Medida", typeof(string));
                dt.Columns.Add("Stock Actual", typeof(int));
                dt.Columns.Add("Precio Unitario", typeof(decimal));
                dt.Columns.Add("Fecha Últ. Modif. Stock", typeof(DateTime));
                dt.Columns.Add("Vendedor (Código)", typeof(string));


                if (_productosActualesParaReporte != null)
                {
                    foreach (var producto in _productosActualesParaReporte.OrderBy(p => p.Nombre))
                    {
                        dt.Rows.Add(
                            producto.IdProducto,
                            producto.Nombre,
                            producto.Categoria?.Nombre ?? "N/A",
                            producto.UnidadMedida?.Nombre ?? "N/A",
                            producto.Stock,
                            producto.Precio,
                            producto.FechaActualizacionStock,
                            producto.Vendedor?.CodigoVendedor ?? "N/A"
                        );
                    }
                }

                if (dgv_ReportesVentxVend != null)
                {
                    dgv_ReportesVentxVend.DataSource = dt;
                    if (dgv_ReportesVentxVend.Columns["IdProducto"] != null) dgv_ReportesVentxVend.Columns["IdProducto"].Visible = false;
                    if (dgv_ReportesVentxVend.Columns["Precio Unitario"] != null) dgv_ReportesVentxVend.Columns["Precio Unitario"].DefaultCellStyle.Format = "C2";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el reporte de inventario general: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _productosActualesParaReporte = new List<Producto>();
            }
        }

        // El botón "Generar" en tu Frm_GeneralInventoryReport.Designer.cs se llama ibtn_Add.
        private void ibtn_Add_Click(object sender, EventArgs e)
        {

            if (_productosActualesParaReporte == null || !_productosActualesParaReporte.Any())
            {
                GenerarReporteInventario(); // Intenta cargar datos si no hay
                if (_productosActualesParaReporte == null || !_productosActualesParaReporte.Any())
                {
                    MessageBox.Show("No hay datos de inventario para exportar.", "Datos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            string nombreAdmin = SessionManager.CurrentUser?.NombreUsuario ?? "Admin Desconocido";
            string reporteId = Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
            string tituloReporte = "Reporte General de Inventario";

            try
            {
                ReportePdfExporter exporter = new ReportePdfExporter();
                // El tercer argumento de GenerarReporteInventarioPdf es 'esReporteGeneral'
                exporter.GenerarReporteInventarioPdf(_productosActualesParaReporte, nombreAdmin, reporteId, tituloReporte);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar exportar a PDF: {ex.Message}", "Error de Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
