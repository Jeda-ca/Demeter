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
    public partial class Frm_InventoryByVendorReport : Form
    {
        private readonly IReporteService _reporteService; // Aunque no se use directamente, se mantiene por si evoluciona
        private readonly IVendedorService _vendedorService;
        private readonly IProductoService _productoService;
        private readonly int _idAdminLogueado;
        private Vendedor _vendedorSeleccionadoParaReporte = null;
        private IEnumerable<Producto> _productosActualesDelVendedor; // Para guardar los datos del reporte

        public Frm_InventoryByVendorReport(int idAdminLogueado)
        {
            InitializeComponent();
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            _idAdminLogueado = idAdminLogueado;
            _productosActualesDelVendedor = new List<Producto>(); // Inicializar

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
                _productoService = new ProductoService();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico al inicializar servicios: {ex.Message}", "Error de Inicialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (ibtn_Buscar != null) ibtn_Buscar.Enabled = false;
                if (ibtn_Add != null) ibtn_Add.Enabled = false; // Botón "Generar PDF"
                if (tbx_Busqueda != null) tbx_Busqueda.Enabled = false;
                if (cbx_FiltroV != null) cbx_FiltroV.Enabled = false;
                if (dtp_FInicio != null) dtp_FInicio.Enabled = false;
                if (dtp_FFin != null) dtp_FFin.Enabled = false;
            }
        }

        private void Frm_InventoryByVendorReport_Load(object sender, EventArgs e)
        {
            if (_idAdminLogueado > 0 && _vendedorService != null && _productoService != null)
            {
                ConfigurarControlesIniciales();
                LimpiarGrillaYDatos();
            }
        }

        private void ConfigurarControlesIniciales()
        {
            if (cbx_FiltroV != null)
            {
                cbx_FiltroV.Items.Clear();
                cbx_FiltroV.Items.Add("Inventario Actual");
                cbx_FiltroV.Items.Add("Por Rango de Fechas (Últ. Act. Stock)");
                cbx_FiltroV.SelectedIndex = 0;
                cbx_FiltroV.SelectedIndexChanged += Cbx_FiltroV_SelectedIndexChanged;
            }

            if (dtp_FInicio != null)
            {
                dtp_FInicio.Value = DateTime.Today.AddMonths(-1);
                dtp_FInicio.Visible = false;
            }
            if (dtp_FFin != null)
            {
                dtp_FFin.Value = DateTime.Today;
                dtp_FFin.Visible = false;
            }

            if (tbx_Busqueda != null) tbx_Busqueda.Text = "";
        }

        private void LimpiarGrillaYDatos()
        {
            if (dgv_ReportesVentxVend != null) dgv_ReportesVentxVend.DataSource = null;
            _productosActualesDelVendedor = new List<Producto>();
        }

        private void Cbx_FiltroV_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool mostrarDatePickers = cbx_FiltroV.SelectedItem?.ToString() == "Por Rango de Fechas (Últ. Act. Stock)";
            if (dtp_FInicio != null) dtp_FInicio.Visible = mostrarDatePickers;
            if (dtp_FFin != null) dtp_FFin.Visible = mostrarDatePickers;
        }

        private void ibtn_Buscar_Click(object sender, EventArgs e)
        {
            // Este botón carga/filtra los datos en el DataGridView.
            CargarDatosReporteInventarioVendedor();
        }

        private void CargarDatosReporteInventarioVendedor()
        {
            if (_vendedorService == null) { MessageBox.Show("Servicio de vendedores no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); LimpiarGrillaYDatos(); return; }
            if (string.IsNullOrWhiteSpace(tbx_Busqueda.Text))
            {
                MessageBox.Show("Por favor, ingrese un código o nombre de vendedor para buscar.", "Información Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _vendedorSeleccionadoParaReporte = null;
                LimpiarGrillaYDatos();
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
                if (_productoService == null) { MessageBox.Show("Servicio de productos no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); LimpiarGrillaYDatos(); return; }

                IEnumerable<Producto> productosDelVendedor = _productoService.ObtenerProductosPorVendedor(_vendedorSeleccionadoParaReporte.IdVendedor);

                if (productosDelVendedor == null)
                {
                    MessageBox.Show("No se pudieron obtener los productos del vendedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimpiarGrillaYDatos();
                    return;
                }

                string filtroFechaSeleccionado = cbx_FiltroV.SelectedItem?.ToString();
                if (filtroFechaSeleccionado == "Por Rango de Fechas (Últ. Act. Stock)")
                {
                    DateTime fechaInicio = dtp_FInicio.Value.Date;
                    DateTime fechaFin = dtp_FFin.Value.Date.AddDays(1).AddTicks(-1);
                    if (fechaInicio > fechaFin.Date.AddDays(-1).AddTicks(1))
                    {
                        MessageBox.Show("La fecha de inicio no puede ser posterior a la fecha de fin.", "Rango de Fechas Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        LimpiarGrillaYDatos();
                        return;
                    }
                    productosDelVendedor = productosDelVendedor.Where(p => p.FechaActualizacionStock >= fechaInicio && p.FechaActualizacionStock <= fechaFin).ToList();
                }
                _productosActualesDelVendedor = productosDelVendedor.ToList(); // Guardar los datos filtrados
                LoadReportDataGrid(_productosActualesDelVendedor);
            }
            else
            {
                _vendedorSeleccionadoParaReporte = null;
                MessageBox.Show($"No se encontró ningún vendedor con el código o nombre '{textoBusquedaVendedor}'.", "Búsqueda sin Resultados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpiarGrillaYDatos();
            }
        }

        private void ibtn_Add_Click(object sender, EventArgs e) // Botón "Generar PDF"
        {
            if (_vendedorSeleccionadoParaReporte == null)
            {
                MessageBox.Show("Por favor, primero busque y seleccione un vendedor para generar el reporte.", "Vendedor no Seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_productosActualesDelVendedor == null || !_productosActualesDelVendedor.Any())
            {
                // Intentar cargar los datos si están vacíos
                CargarDatosReporteInventarioVendedor();
                if (_productosActualesDelVendedor == null || !_productosActualesDelVendedor.Any())
                {
                    MessageBox.Show("No hay datos de inventario para este vendedor en el período seleccionado.", "Datos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            string nombreAdmin = SessionManager.CurrentUser?.NombreUsuario ?? "Admin Desconocido";
            string reporteId = Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
            string tituloReporte = "Reporte de Inventario por Vendedor";
            string infoAdicional = $"Vendedor: {_vendedorSeleccionadoParaReporte.Nombre} {_vendedorSeleccionadoParaReporte.Apellido} (Cód: {_vendedorSeleccionadoParaReporte.CodigoVendedor})";

            try
            {
                ReportePdfExporter exporter = new ReportePdfExporter();
                // El último argumento 'false' indica que NO es un reporte general de inventario
                exporter.GenerarReporteInventarioPdf(_productosActualesDelVendedor, nombreAdmin, reporteId, tituloReporte, infoAdicional);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar exportar a PDF: {ex.Message}", "Error de Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadReportDataGrid(IEnumerable<Producto> productos)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IdProducto", typeof(int));
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
                if (dgv_ReportesVentxVend.Columns["IdProducto"] != null) dgv_ReportesVentxVend.Columns["IdProducto"].Visible = false;
                if (dgv_ReportesVentxVend.Columns["Precio Unitario"] != null) dgv_ReportesVentxVend.Columns["Precio Unitario"].DefaultCellStyle.Format = "C2";
            }
        }

        private void ibtn_Clear_Click(object sender, EventArgs e)
        {
            if (tbx_Busqueda != null) tbx_Busqueda.Clear();
            _vendedorSeleccionadoParaReporte = null;

            if (cbx_FiltroV != null && cbx_FiltroV.Items.Count > 0)
            {
                cbx_FiltroV.SelectedIndex = 0;
            }
            LimpiarGrillaYDatos();
        }
    }
}