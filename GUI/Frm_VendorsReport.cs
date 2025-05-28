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
    public partial class Frm_VendorsReport : Form
    {
        private readonly IVendedorService _vendedorService;
        private readonly int _idAdminLogueado;
        // Asume que tienes un ComboBox llamado cbx_DateFilter 
        // y un IconButton llamado ibtn_OKCustomDate en tu Frm_VendorsReport.Designer.cs

        public Frm_VendorsReport(int idAdminLogueado)
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
                _vendedorService = new VendedorService();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico al inicializar servicios: {ex.Message}", "Error de Inicialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                var btnGenerar = this.Controls.Find("ibtn_Add", true).FirstOrDefault(); // Este será el botón PDF
                if (btnGenerar != null) btnGenerar.Enabled = false; // O mantenerlo activo y manejar PDF
                if (dtp_FInicio != null) dtp_FInicio.Enabled = false;
                if (dtp_FFin != null) dtp_FFin.Enabled = false;
                if (cbx_DateFilter != null) cbx_DateFilter.Enabled = false;
                if (ibtn_OKCustomDate != null) ibtn_OKCustomDate.Enabled = false; // Deshabilitar también
            }
        }

        private void Frm_VendorsReport_Load(object sender, EventArgs e)
        {
            if (_idAdminLogueado > 0 && _vendedorService != null)
            {
                ConfigurarFiltroFecha();
                GenerarReporteVendedores(); // Carga inicial (general por defecto)
            }
        }

        private void ConfigurarFiltroFecha()
        {
            if (cbx_DateFilter != null)
            {
                cbx_DateFilter.Items.Clear();
                cbx_DateFilter.Items.Add("Todos los Vendedores");
                cbx_DateFilter.Items.Add("Por Rango de Fechas de Registro");
                cbx_DateFilter.SelectedIndex = 0; // Por defecto, mostrar todos
                cbx_DateFilter.SelectedIndexChanged += Cbx_DateFilter_SelectedIndexChanged;
            }

            if (dtp_FInicio != null)
            {
                dtp_FInicio.Value = DateTime.Today.AddYears(-1).Date;
                dtp_FInicio.Visible = false; // Oculto inicialmente
            }
            if (dtp_FFin != null)
            {
                dtp_FFin.Value = DateTime.Today.Date;
                dtp_FFin.Visible = false; // Oculto inicialmente
            }
            // MODIFICADO: Ocultar el botón OK inicialmente
            if (ibtn_OKCustomDate != null)
            {
                ibtn_OKCustomDate.Visible = false; // Oculto inicialmente
            }
        }

        private void Cbx_DateFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool mostrarDatePickers = cbx_DateFilter.SelectedItem?.ToString() == "Por Rango de Fechas de Registro";
            if (dtp_FInicio != null) dtp_FInicio.Visible = mostrarDatePickers;
            if (dtp_FFin != null) dtp_FFin.Visible = mostrarDatePickers;
            // MODIFICADO: Mostrar/Ocultar el botón OK junto con los DateTimePickers
            if (ibtn_OKCustomDate != null) ibtn_OKCustomDate.Visible = mostrarDatePickers;

            // Si se vuelve a "Todos", recargar la grilla
            if (!mostrarDatePickers)
            {
                GenerarReporteVendedores();
            }
        }

        private void GenerarReporteVendedores()
        {
            try
            {
                if (_vendedorService == null) { MessageBox.Show("Servicio de vendedores no inicializado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                IEnumerable<Vendedor> vendedores = _vendedorService.ObtenerTodosLosVendedores();

                if (cbx_DateFilter.SelectedItem?.ToString() == "Por Rango de Fechas de Registro")
                {
                    if (dtp_FInicio == null || dtp_FFin == null) { MessageBox.Show("Controles de fecha no configurados.", "Error UI", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                    DateTime fechaInicio = dtp_FInicio.Value.Date;
                    DateTime fechaFin = dtp_FFin.Value.Date.AddDays(1).AddTicks(-1);

                    if (fechaInicio > fechaFin.Date.AddDays(-1).AddTicks(1))
                    {
                        MessageBox.Show("La fecha de inicio no puede ser posterior a la fecha de fin.", "Rango de Fechas Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (dgv_ReportesVentxVend != null) dgv_ReportesVentxVend.DataSource = null;
                        return;
                    }
                    vendedores = vendedores.Where(v => v.FechaRegistro.Date >= fechaInicio && v.FechaRegistro.Date <= fechaFin.Date.AddDays(-1).AddTicks(1));
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("ID Vendedor", typeof(int));
                dt.Columns.Add("Nombre Completo", typeof(string));
                dt.Columns.Add("Código Vendedor", typeof(string));
                dt.Columns.Add("Teléfono", typeof(string));
                dt.Columns.Add("Fecha Registro", typeof(DateTime));
                dt.Columns.Add("Estado", typeof(string));

                if (vendedores != null)
                {
                    foreach (var vendedor in vendedores.OrderBy(v => v.Apellido).ThenBy(v => v.Nombre))
                    {
                        dt.Rows.Add(
                            vendedor.IdVendedor,
                            $"{vendedor.Nombre} {vendedor.Apellido}",
                            vendedor.CodigoVendedor,
                            vendedor.Telefono,
                            vendedor.FechaRegistro,
                            vendedor.Activo ? "Activo" : "Inactivo"
                        );
                    }
                }

                if (dgv_ReportesVentxVend != null)
                {
                    dgv_ReportesVentxVend.DataSource = dt;
                    if (dgv_ReportesVentxVend.Columns["ID Vendedor"] != null) dgv_ReportesVentxVend.Columns["ID Vendedor"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el reporte de vendedores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Este es el botón que llamas "Generar" (el verde) y se usará para PDF
        private void ibtn_Add_Click(object sender, EventArgs e)
        {
            // Aquí irá la lógica para generar el PDF en el futuro
            MessageBox.Show("Función 'Generar PDF' aún no implementada.", "Próximamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Este es tu NUEVO botón para confirmar la fecha
        private void ibtn_OKCustomDate_Click(object sender, EventArgs e)
        {
            GenerarReporteVendedores(); // Llama al método que carga/filtra la grilla
        }
    }
}
