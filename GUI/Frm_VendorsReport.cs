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
    public partial class Frm_VendorsReport : Form
    {
        private readonly IVendedorService _vendedorService;
        private readonly int _idAdminLogueado;
        private IEnumerable<Vendedor> _vendedoresActualesParaReporte;

        public Frm_VendorsReport(int idAdminLogueado)
        {
            InitializeComponent();
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            _idAdminLogueado = idAdminLogueado;
            _vendedoresActualesParaReporte = new List<Vendedor>();

            if (_idAdminLogueado <= 0)
            {
                MessageBox.Show("Error: ID de administrador no válido.", "Error de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new MethodInvoker(this.Close));
                return;
            }

            try
            {
                _vendedorService = new VendedorService();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico al inicializar servicios: {ex.Message}", "Error de Inicialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (ibtn_GenReport != null) ibtn_GenReport.Enabled = false;
                if (dtp_FInicio != null) dtp_FInicio.Enabled = false;
                if (dtp_FFin != null) dtp_FFin.Enabled = false;
                if (cbx_DateFilter != null) cbx_DateFilter.Enabled = false;
                if (ibtn_OKCustomDate != null) ibtn_OKCustomDate.Enabled = false;
            }
        }

        private void Frm_VendorsReport_Load(object sender, EventArgs e)
        {
            if (_idAdminLogueado > 0 && _vendedorService != null)
            {
                ConfigurarFiltroFecha();
                CargarDatosReporteVendedores();
            }
        }

        private void ConfigurarFiltroFecha()
        {
            if (cbx_DateFilter != null)
            {
                cbx_DateFilter.Items.Clear();
                cbx_DateFilter.Items.Add("Todos los Vendedores");
                cbx_DateFilter.Items.Add("Por Rango de Fechas de Registro");
                cbx_DateFilter.SelectedIndex = 0;
                cbx_DateFilter.SelectedIndexChanged += Cbx_DateFilter_SelectedIndexChanged;
            }

            if (dtp_FInicio != null)
            {
                dtp_FInicio.Value = DateTime.Today.AddYears(-1).Date;
                dtp_FInicio.Visible = false;
            }
            if (dtp_FFin != null)
            {
                dtp_FFin.Value = DateTime.Today.Date;
                dtp_FFin.Visible = false;
            }
            if (ibtn_OKCustomDate != null)
            {
                ibtn_OKCustomDate.Visible = false;
            }
        }

        private void Cbx_DateFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool mostrarDatePickers = cbx_DateFilter.SelectedItem?.ToString() == "Por Rango de Fechas de Registro";
            if (dtp_FInicio != null) dtp_FInicio.Visible = mostrarDatePickers;
            if (dtp_FFin != null) dtp_FFin.Visible = mostrarDatePickers;
            if (ibtn_OKCustomDate != null) ibtn_OKCustomDate.Visible = mostrarDatePickers;

            if (!mostrarDatePickers)
            {
                CargarDatosReporteVendedores(); // Recargar con "Todos" si se desactiva el filtro de fecha
            }
        }

        // Método renombrado y modificado para claridad
        private void CargarDatosReporteVendedores()
        {
            try
            {
                if (_vendedorService == null)
                {
                    MessageBox.Show("Servicio de vendedores no inicializado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _vendedoresActualesParaReporte = new List<Vendedor>();
                    if (dgv_ReportesVentxVend != null) dgv_ReportesVentxVend.DataSource = null;
                    return;
                }

                IEnumerable<Vendedor> vendedores = _vendedorService.ObtenerTodosLosVendedores();

                if (cbx_DateFilter.SelectedItem?.ToString() == "Por Rango de Fechas de Registro")
                {
                    if (dtp_FInicio == null || dtp_FFin == null) { MessageBox.Show("Controles de fecha no configurados.", "Error UI", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                    DateTime fechaInicio = dtp_FInicio.Value.Date;
                    DateTime fechaFin = dtp_FFin.Value.Date.AddDays(1).AddTicks(-1);

                    if (fechaInicio > fechaFin.Date.AddDays(-1).AddTicks(1))
                    {
                        MessageBox.Show("La fecha de inicio no puede ser posterior a la fecha de fin.", "Rango de Fechas Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _vendedoresActualesParaReporte = new List<Vendedor>();
                        if (dgv_ReportesVentxVend != null) dgv_ReportesVentxVend.DataSource = null;
                        return;
                    }
                    vendedores = vendedores.Where(v => v.FechaRegistro.Date >= fechaInicio && v.FechaRegistro.Date <= fechaFin.Date.AddDays(-1).AddTicks(1));
                }

                _vendedoresActualesParaReporte = vendedores.ToList(); // Guardar los datos para el PDF
                if (_vendedoresActualesParaReporte == null) // Verificación adicional
                {
                    _vendedoresActualesParaReporte = new List<Vendedor>();
                }


                DataTable dt = new DataTable();
                dt.Columns.Add("IdVendedor", typeof(int)); // Oculta, para referencia si es necesario
                dt.Columns.Add("Nombre Completo", typeof(string));
                dt.Columns.Add("Código Vendedor", typeof(string));
                dt.Columns.Add("Teléfono", typeof(string));
                dt.Columns.Add("Fecha Registro", typeof(DateTime));
                dt.Columns.Add("Estado", typeof(string));

                if (_vendedoresActualesParaReporte != null)
                {
                    foreach (var vendedor in _vendedoresActualesParaReporte.OrderBy(v => v.Apellido).ThenBy(v => v.Nombre))
                    {
                        dt.Rows.Add(
                            vendedor.IdVendedor,
                            $"{vendedor.Nombre} {vendedor.Apellido}",
                            vendedor.CodigoVendedor,
                            vendedor.Telefono,
                            vendedor.FechaRegistro, // Asegúrate que FechaRegistro esté disponible en Vendedor
                            vendedor.Activo ? "Activo" : "Inactivo"
                        );
                    }
                }

                if (dgv_ReportesVentxVend != null)
                {
                    dgv_ReportesVentxVend.DataSource = dt;
                    if (dgv_ReportesVentxVend.Columns["IdVendedor"] != null) dgv_ReportesVentxVend.Columns["IdVendedor"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el reporte de vendedores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _vendedoresActualesParaReporte = new List<Vendedor>();
            }
        }

        private void ibtn_GenReport_Click(object sender, EventArgs e) // Cambiado de ibtn_Add_Click a ibtn_GenReport_Click
        {
            if (_vendedoresActualesParaReporte == null || !_vendedoresActualesParaReporte.Any())
            {
                // Intentar cargar los datos si están vacíos
                CargarDatosReporteVendedores();
                if (_vendedoresActualesParaReporte == null || !_vendedoresActualesParaReporte.Any())
                {
                    MessageBox.Show("No hay datos de vendedores para exportar. Por favor, genere el reporte primero.", "Datos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            string nombreAdmin = SessionManager.CurrentUser?.NombreUsuario ?? "Admin Desconocido";
            string reporteId = Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
            string tituloReporte = "Reporte de Vendedores";

            try
            {
                ReportePdfExporter exporter = new ReportePdfExporter();
                exporter.GenerarReporteVendedoresPdf(_vendedoresActualesParaReporte, nombreAdmin, reporteId, tituloReporte);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar exportar a PDF: {ex.Message}", "Error de Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibtn_OKCustomDate_Click(object sender, EventArgs e)
        {
            CargarDatosReporteVendedores();
        }
    }
}
