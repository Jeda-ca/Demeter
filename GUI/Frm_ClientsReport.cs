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
    public partial class Frm_ClientsReport : Form
    {
        private readonly IClienteService _clienteService;
        private readonly ITipoDocumentoService _tipoDocumentoService; // Para obtener el nombre del tipo de documento
        private readonly int _idAdminLogueado;
        private IEnumerable<Cliente> _clientesActualesParaReporte; // Variable para guardar los datos

        public Frm_ClientsReport(int idAdminLogueado)
        {
            InitializeComponent();
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            _idAdminLogueado = idAdminLogueado;
            _clientesActualesParaReporte = new List<Cliente>(); // Inicializar

            if (_idAdminLogueado <= 0)
            {
                MessageBox.Show("Error: ID de administrador no válido.", "Error de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new MethodInvoker(this.Close));
                return;
            }

            try
            {
                _clienteService = new ClienteService();
                _tipoDocumentoService = new TipoDocumentoService(); // Inicializar
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico al inicializar servicios: {ex.Message}", "Error de Inicialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // En Frm_ClientsReport.Designer.cs, el botón para generar PDF parece ser ibtn_GenReport
                if (ibtn_GenReport != null) ibtn_GenReport.Enabled = false;
                if (dtp_FInicio != null) dtp_FInicio.Enabled = false;
                if (dtp_FFin != null) dtp_FFin.Enabled = false;
                if (cbx_DateFilter != null) cbx_DateFilter.Enabled = false;
                if (ibtn_OKCustomDate != null) ibtn_OKCustomDate.Enabled = false;
            }
        }

        private void Frm_ClientsReport_Load(object sender, EventArgs e)
        {
            if (_idAdminLogueado > 0 && _clienteService != null && _tipoDocumentoService != null)
            {
                ConfigurarFiltroFecha();
                CargarDatosReporteClientes();
            }
        }

        private void ConfigurarFiltroFecha()
        {
            if (cbx_DateFilter != null)
            {
                cbx_DateFilter.Items.Clear();
                cbx_DateFilter.Items.Add("Todos los Clientes");
                cbx_DateFilter.Items.Add("Por Rango de Fechas de Registro");
                cbx_DateFilter.SelectedIndex = 0;
                cbx_DateFilter.SelectedIndexChanged += Cbx_DateFilter_Clients_SelectedIndexChanged;
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

        private void Cbx_DateFilter_Clients_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool mostrarDatePickers = cbx_DateFilter.SelectedItem?.ToString() == "Por Rango de Fechas de Registro";
            if (dtp_FInicio != null) dtp_FInicio.Visible = mostrarDatePickers;
            if (dtp_FFin != null) dtp_FFin.Visible = mostrarDatePickers;
            if (ibtn_OKCustomDate != null) ibtn_OKCustomDate.Visible = mostrarDatePickers;

            if (!mostrarDatePickers)
            {
                CargarDatosReporteClientes();
            }
        }

        private void CargarDatosReporteClientes() // Renombrado desde GenerarReporteClientes para claridad
        {
            try
            {
                if (_clienteService == null)
                {
                    MessageBox.Show("Servicio de clientes no inicializado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _clientesActualesParaReporte = new List<Cliente>();
                    if (dgv_ReportesVentxVend != null) dgv_ReportesVentxVend.DataSource = null;
                    return;
                }

                IEnumerable<Cliente> clientes = _clienteService.ObtenerTodosLosClientes();

                if (cbx_DateFilter.SelectedItem?.ToString() == "Por Rango de Fechas de Registro")
                {
                    if (dtp_FInicio == null || dtp_FFin == null) { MessageBox.Show("Controles de fecha no configurados.", "Error UI", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                    DateTime fechaInicio = dtp_FInicio.Value.Date;
                    DateTime fechaFin = dtp_FFin.Value.Date.AddDays(1).AddTicks(-1);

                    if (fechaInicio > fechaFin.Date.AddDays(-1).AddTicks(1))
                    {
                        MessageBox.Show("La fecha de inicio no puede ser posterior a la fecha de fin.", "Rango de Fechas Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _clientesActualesParaReporte = new List<Cliente>();
                        if (dgv_ReportesVentxVend != null) dgv_ReportesVentxVend.DataSource = null;
                        return;
                    }
                    clientes = clientes.Where(c => c.FechaRegistro.Date >= fechaInicio && c.FechaRegistro.Date <= fechaFin.Date.AddDays(-1).AddTicks(1));
                }

                _clientesActualesParaReporte = clientes.ToList();
                if (_clientesActualesParaReporte == null)
                {
                    _clientesActualesParaReporte = new List<Cliente>();
                }


                DataTable dt = new DataTable();
                dt.Columns.Add("ID Cliente", typeof(int));
                dt.Columns.Add("Nombre Completo", typeof(string));
                dt.Columns.Add("Tipo Documento", typeof(string));
                dt.Columns.Add("Número Documento", typeof(string));
                dt.Columns.Add("Teléfono", typeof(string));
                dt.Columns.Add("Email", typeof(string));
                dt.Columns.Add("Fecha Registro", typeof(DateTime));
                dt.Columns.Add("Estado", typeof(string));

                if (_clientesActualesParaReporte != null)
                {
                    foreach (var cliente in _clientesActualesParaReporte.OrderBy(c => c.Apellido).ThenBy(c => c.Nombre))
                    {
                        // Obtener el nombre del tipo de documento. Asumiendo que TipoDocumento se carga en la entidad Cliente.
                        // Si no, se necesitaría una llamada a _tipoDocumentoService.ObtenerPorId(cliente.TipoDocumentoId).Nombre
                        string nombreTipoDoc = cliente.TipoDocumento?.Nombre ?? _tipoDocumentoService?.ObtenerPorId(cliente.TipoDocumentoId)?.Nombre ?? cliente.TipoDocumentoId.ToString();
                        dt.Rows.Add(
                            cliente.IdCliente,
                            $"{cliente.Nombre} {cliente.Apellido}",
                            nombreTipoDoc,
                            cliente.NumeroDocumento,
                            cliente.Telefono,
                            cliente.Correo,
                            cliente.FechaRegistro,
                            cliente.Activo ? "Activo" : "Inactivo"
                        );
                    }
                }

                if (dgv_ReportesVentxVend != null)
                {
                    dgv_ReportesVentxVend.DataSource = dt;
                    if (dgv_ReportesVentxVend.Columns["ID Cliente"] != null) dgv_ReportesVentxVend.Columns["ID Cliente"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el reporte de clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _clientesActualesParaReporte = new List<Cliente>();
            }
        }

        private void ibtn_GenReport_Click(object sender, EventArgs e)
        {
            if (_clientesActualesParaReporte == null || !_clientesActualesParaReporte.Any())
            {
                CargarDatosReporteClientes(); // Intenta cargar datos si no hay
                if (_clientesActualesParaReporte == null || !_clientesActualesParaReporte.Any())
                {
                    MessageBox.Show("No hay datos de clientes para exportar. Por favor, genere el reporte primero.", "Datos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            string nombreAdmin = SessionManager.CurrentUser?.NombreUsuario ?? "Admin Desconocido";
            string reporteId = Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
            string tituloReporte = "Reporte de Clientes";

            try
            {
                ReportePdfExporter exporter = new ReportePdfExporter();
                exporter.GenerarReporteClientesPdf(_clientesActualesParaReporte, nombreAdmin, reporteId, tituloReporte);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar exportar a PDF: {ex.Message}", "Error de Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibtn_OKCustomDate_Click(object sender, EventArgs e)
        {
            CargarDatosReporteClientes();
        }
    }
}
