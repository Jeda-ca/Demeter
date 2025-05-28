using BLL.Interfaces;
using BLL.Services;
using ENTITY;
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

        public Frm_GeneralInventoryReport(int idAdminLogueado)
        {
            InitializeComponent();
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            _idAdminLogueado = idAdminLogueado;

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
                // Deshabilitar controles
                // Tu botón "Generar" se llama ibtn_Add en el Designer de Frm_GeneralInventoryReport.cs
                var btnGenerar = this.Controls.Find("ibtn_Add", true).FirstOrDefault();
                if (btnGenerar != null) btnGenerar.Enabled = false;
                if (dtp_FInicio != null) dtp_FInicio.Enabled = false;
                if (dtp_FFin != null) dtp_FFin.Enabled = false;
            }
        }

        private void Frm_GeneralInventoryReport_Load(object sender, EventArgs e)
        {
            if (_idAdminLogueado > 0 && _reporteService != null)
            {
                // Configurar DateTimePickers
                if (dtp_FInicio != null) dtp_FInicio.Value = DateTime.Today.AddMonths(-1);
                if (dtp_FFin != null) dtp_FFin.Value = DateTime.Today;

                GenerarReporteInventario();
            }
        }

        private void GenerarReporteInventario()
        {
            try
            {
                if (_reporteService == null) { MessageBox.Show("Servicio de reportes no inicializado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                string mensajeError;
                IEnumerable<Producto> productos = _reporteService.GenerarReporteInventarioGeneral(_idAdminLogueado, out mensajeError);

                if (!string.IsNullOrEmpty(mensajeError))
                {
                    MessageBox.Show(mensajeError, "Error al Generar Reporte", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (dgv_ReportesVentxVend != null) dgv_ReportesVentxVend.DataSource = null;
                    return;
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("ID Producto", typeof(int));
                dt.Columns.Add("Nombre Producto", typeof(string));
                dt.Columns.Add("Categoría", typeof(string));
                dt.Columns.Add("Unidad Medida", typeof(string));
                dt.Columns.Add("Stock Actual", typeof(int));
                dt.Columns.Add("Precio Unitario", typeof(decimal));
                dt.Columns.Add("Fecha Últ. Modif. Stock", typeof(DateTime));
                dt.Columns.Add("Vendedor (Código)", typeof(string));


                if (productos != null)
                {
                    foreach (var producto in productos.OrderBy(p => p.Nombre))
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

                // dgv_ReportesVentxVend es el nombre de tu DataGridView
                if (dgv_ReportesVentxVend != null)
                {
                    dgv_ReportesVentxVend.DataSource = dt;
                    if (dgv_ReportesVentxVend.Columns["ID Producto"] != null) dgv_ReportesVentxVend.Columns["ID Producto"].Visible = false;
                    if (dgv_ReportesVentxVend.Columns["Precio Unitario"] != null) dgv_ReportesVentxVend.Columns["Precio Unitario"].DefaultCellStyle.Format = "C2";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el reporte de inventario general: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // El botón "Generar" en tu Frm_GeneralInventoryReport.Designer.cs se llama ibtn_Add.
        // El evento Click de este botón debe estar enlazado a este método.
        private void ibtn_Add_Click(object sender, EventArgs e)
        {
            // Para el inventario general, las fechas seleccionadas podrían no afectar directamente
            // la consulta del stock (que es actual), pero se pueden usar para registrar el periodo
            // en la metadata del reporte si así lo deseas.
            // O, si el servicio GenerarReporteInventarioGeneral las usa para filtrar por fecha de creación/modificación de producto.
            GenerarReporteInventario();
        }
    }
}
