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
    public partial class Frm_InventoryByVendorReport : Form
    {
        private readonly IReporteService _reporteService;
        private readonly IVendedorService _vendedorService;
        private readonly int _idAdminLogueado;
        private Vendedor _vendedorSeleccionadoParaReporte = null;

        public Frm_InventoryByVendorReport(int idAdminLogueado)
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
                _vendedorService = new VendedorService();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico al inicializar servicios: {ex.Message}", "Error de Inicialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (ibtn_Buscar != null) ibtn_Buscar.Enabled = false;
                if (ibtn_Add != null) ibtn_Add.Enabled = false;
                if (tbx_Busqueda != null) tbx_Busqueda.Enabled = false;
                if (dtp_FInicio != null) dtp_FInicio.Enabled = false;
                if (dtp_FFin != null) dtp_FFin.Enabled = false;
            }
        }

        private void Frm_InventoryByVendorReport_Load(object sender, EventArgs e)
        {
            if (_idAdminLogueado > 0 && _reporteService != null)
            {
                ConfigurarControlesIniciales();
                LimpiarGrilla();
            }
        }

        private void ConfigurarControlesIniciales()
        {
            // El ComboBox cbx_FiltroV no se usa en este formulario según el Designer.cs proporcionado.
            // Los DateTimePickers son para la metadata del reporte.
            if (dtp_FInicio != null)
            {
                dtp_FInicio.Value = DateTime.Today.AddMonths(-1); // Rango por defecto
            }
            if (dtp_FFin != null)
            {
                dtp_FFin.Value = DateTime.Today;
            }
            // No hay PlaceholderText en System.Windows.Forms.TextBox
            if (tbx_Busqueda != null) tbx_Busqueda.Text = ""; // Limpiar texto inicial
        }

        private void LimpiarGrilla()
        {
            if (dgv_ReportesVentxVend != null) dgv_ReportesVentxVend.DataSource = null;
        }

        // ibtn_Buscar es para buscar al VENDEDOR
        private void ibtn_Buscar_Click(object sender, EventArgs e)
        {
            if (_vendedorService == null) { MessageBox.Show("Servicio de vendedores no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (tbx_Busqueda == null || string.IsNullOrWhiteSpace(tbx_Busqueda.Text))
            {
                MessageBox.Show("Por favor, ingrese un código o nombre de vendedor para buscar.", "Información Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _vendedorSeleccionadoParaReporte = null;
                LimpiarGrilla();
                return;
            }

            string textoBusquedaVendedor = tbx_Busqueda.Text.Trim();
            Vendedor vendedorEncontrado = _vendedorService.ObtenerVendedorPorCodigo(textoBusquedaVendedor);

            if (vendedorEncontrado == null)
            {
                var vendedoresPorNombre = _vendedorService.BuscarVendedoresPorNombreOApellido(textoBusquedaVendedor);
                if (vendedoresPorNombre.Any())
                {
                    vendedorEncontrado = vendedoresPorNombre.First();
                }
            }

            if (vendedorEncontrado != null)
            {
                _vendedorSeleccionadoParaReporte = vendedorEncontrado;
                GenerarReporteInventarioVendedor();
            }
            else
            {
                _vendedorSeleccionadoParaReporte = null;
                MessageBox.Show($"No se encontró ningún vendedor con el código o nombre '{textoBusquedaVendedor}'.", "Búsqueda sin Resultados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpiarGrilla();
            }
        }

        private void ibtn_Add_Click(object sender, EventArgs e)
        {
            GenerarReporteInventarioVendedor();
        }

        private void GenerarReporteInventarioVendedor()
        {
            if (_vendedorSeleccionadoParaReporte == null)
            {
                MessageBox.Show("Por favor, primero busque y seleccione un vendedor.", "Vendedor Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LimpiarGrilla();
                return;
            }
            if (_reporteService == null) { MessageBox.Show("Servicio de reportes no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            // Las fechas son para la metadata del reporte, el inventario es el actual del vendedor.
            // DateTime fechaInicio = dtp_FInicio.Value.Date; 
            // DateTime fechaFin = dtp_FFin.Value.Date;

            string mensajeError;
            IEnumerable<Producto> productos = _reporteService.GenerarReporteInventarioPorVendedor(_idAdminLogueado, _vendedorSeleccionadoParaReporte.IdVendedor, out mensajeError);

            if (!string.IsNullOrEmpty(mensajeError))
            {
                MessageBox.Show(mensajeError, "Error al Generar Reporte", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LimpiarGrilla();
                return;
            }
            LoadReportDataGrid(productos);
        }

        private void LoadReportDataGrid(IEnumerable<Producto> productos)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID Producto", typeof(int));
            dt.Columns.Add("Nombre Producto", typeof(string));
            dt.Columns.Add("Categoría", typeof(string));
            dt.Columns.Add("Unidad Medida", typeof(string));
            dt.Columns.Add("Stock Actual", typeof(int));
            dt.Columns.Add("Precio Unitario", typeof(decimal));
            dt.Columns.Add("Fecha Últ. Act. Stock", typeof(DateTime));

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
                        producto.FechaActualizacionStock
                    );
                }
            }

            if (dgv_ReportesVentxVend != null)
            {
                dgv_ReportesVentxVend.DataSource = dt;
                if (dgv_ReportesVentxVend.Columns["ID Producto"] != null) dgv_ReportesVentxVend.Columns["ID Producto"].Visible = false;
                if (dgv_ReportesVentxVend.Columns["Precio Unitario"] != null) dgv_ReportesVentxVend.Columns["Precio Unitario"].DefaultCellStyle.Format = "C2";
            }
        }

        // ibtn_Clear en tu Designer
        private void ibtn_Clear_Click(object sender, EventArgs e)
        {
            if (tbx_Busqueda != null) tbx_Busqueda.Clear();
            _vendedorSeleccionadoParaReporte = null;
            // No hay cbx_FiltroV para resetear en este formulario
            // dtp_FInicio.Value = DateTime.Today.AddMonths(-1); // Opcional resetear fechas
            // dtp_FFin.Value = DateTime.Today;
            LimpiarGrilla();
        }
    }
}
