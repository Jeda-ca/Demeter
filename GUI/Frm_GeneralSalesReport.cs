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
    public partial class Frm_GeneralSalesReport : Form
    {
        private readonly IReporteService _reporteService;
        private readonly int _idAdminLogueado;

        public Frm_GeneralSalesReport(int idAdminLogueado)
        {
            InitializeComponent();
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            _idAdminLogueado = idAdminLogueado;

            if (_idAdminLogueado <= 0)
            {
                MessageBox.Show("Error: ID de administrador no válido.", "Error de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new MethodInvoker(this.Close)); // Cierra de forma segura
                return;
            }

            try
            {
                _reporteService = new ReporteService();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico al inicializar servicios: {ex.Message}", "Error de Inicialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Deshabilitar controles si la inicialización falla
                // Asumiendo que tu botón "Generar" se llama ibtn_Add en el Designer
                var btnGenerar = this.Controls.Find("ibtn_Add", true).FirstOrDefault();
                if (btnGenerar != null) btnGenerar.Enabled = false;
                if (dtp_FInicio != null) dtp_FInicio.Enabled = false;
                if (dtp_FFin != null) dtp_FFin.Enabled = false;
            }
        }

        private void Frm_GeneralSalesReport_Load(object sender, EventArgs e)
        {
            if (_idAdminLogueado > 0 && _reporteService != null)
            {
                // Configurar DateTimePickers para un rango por defecto (ej. último mes)
                if (dtp_FInicio != null) dtp_FInicio.Value = DateTime.Today.AddMonths(-1).Date;
                if (dtp_FFin != null) dtp_FFin.Value = DateTime.Today.Date;

                // Cargar el reporte con el rango por defecto
                GenerarReporte();
            }
        }

        private void GenerarReporte()
        {
            try
            {
                if (_reporteService == null) { MessageBox.Show("Servicio de reportes no inicializado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                if (dtp_FInicio == null || dtp_FFin == null) { MessageBox.Show("Controles de fecha no encontrados.", "Error de UI", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }


                DateTime fechaInicio = dtp_FInicio.Value.Date;
                DateTime fechaFin = dtp_FFin.Value.Date.AddDays(1).AddTicks(-1); // Incluir todo el día de fechaFin

                if (fechaInicio > fechaFin)
                {
                    MessageBox.Show("La fecha de inicio no puede ser posterior a la fecha de fin.", "Rango de Fechas Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string mensajeError;
                // Usar el método que filtra por fechas. Si se quieren todas, se podría tener un botón/opción aparte
                // o pasar fechas muy amplias.
                IEnumerable<Venta> ventas = _reporteService.GenerarReporteVentasGeneralesPorFechas(_idAdminLogueado, fechaInicio, fechaFin, out mensajeError);

                if (!string.IsNullOrEmpty(mensajeError))
                {
                    MessageBox.Show(mensajeError, "Error al Generar Reporte", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (dgv_ReportesVentxVend != null) dgv_ReportesVentxVend.DataSource = null;
                    return;
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("ID Venta", typeof(int));
                dt.Columns.Add("Fecha", typeof(DateTime));
                dt.Columns.Add("Subtotal", typeof(decimal));
                dt.Columns.Add("Descuento", typeof(decimal));
                dt.Columns.Add("Total", typeof(decimal));
                dt.Columns.Add("Estado", typeof(string));
                dt.Columns.Add("Cliente", typeof(string));
                dt.Columns.Add("Vendedor", typeof(string));
                dt.Columns.Add("Observaciones", typeof(string));

                if (ventas != null)
                {
                    foreach (var venta in ventas.OrderByDescending(v => v.FechaOcurrencia))
                    {
                        dt.Rows.Add(
                            venta.IdVenta,
                            venta.FechaOcurrencia,
                            venta.Subtotal,
                            venta.Descuento,
                            venta.Total,
                            venta.EstadoVenta?.Nombre ?? "N/A",
                            (venta.Cliente != null) ? $"{venta.Cliente.Nombre} {venta.Cliente.Apellido}" : "N/A",
                            venta.Vendedor?.CodigoVendedor ?? "N/A",
                            venta.Observaciones
                        );
                    }
                }

                // dgv_ReportesVentxVend es el nombre de tu DataGridView en Frm_GeneralSalesReport.Designer.cs
                if (dgv_ReportesVentxVend != null)
                {
                    dgv_ReportesVentxVend.DataSource = dt;
                    if (dgv_ReportesVentxVend.Columns["ID Venta"] != null) dgv_ReportesVentxVend.Columns["ID Venta"].Visible = false; // Opcional
                    if (dgv_ReportesVentxVend.Columns["Subtotal"] != null) dgv_ReportesVentxVend.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
                    if (dgv_ReportesVentxVend.Columns["Descuento"] != null) dgv_ReportesVentxVend.Columns["Descuento"].DefaultCellStyle.Format = "C2";
                    if (dgv_ReportesVentxVend.Columns["Total"] != null) dgv_ReportesVentxVend.Columns["Total"].DefaultCellStyle.Format = "C2";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el reporte de ventas generales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // El botón "Generar" en tu Frm_GeneralSalesReport.Designer.cs se llama ibtn_Add.
        // Por lo tanto, el manejador de eventos debe llamarse ibtn_Add_Click.
        private void ibtn_Add_Click(object sender, EventArgs e)
        {
            GenerarReporte();
        }
    }
}
