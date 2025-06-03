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
        private readonly IProductoService _productoService;
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
                _productoService = new ProductoService();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico al inicializar servicios: {ex.Message}", "Error de Inicialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (ibtn_Buscar != null) ibtn_Buscar.Enabled = false;
                if (ibtn_Add != null) ibtn_Add.Enabled = false;
                if (tbx_Busqueda != null) tbx_Busqueda.Enabled = false;
                if (cbx_FiltroV != null) cbx_FiltroV.Enabled = false;
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

        private void LimpiarGrilla()
        {
            if (dgv_ReportesVentxVend != null) dgv_ReportesVentxVend.DataSource = null;
        }

        private void Cbx_FiltroV_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool mostrarDatePickers = cbx_FiltroV.SelectedItem?.ToString() == "Por Rango de Fechas (Últ. Act. Stock)";

            if (dtp_FInicio != null) dtp_FInicio.Visible = mostrarDatePickers;
            if (dtp_FFin != null) dtp_FFin.Visible = mostrarDatePickers;

        }

        // Botón para buscar VENDEDOR y APLICAR FILTROS DE FECHA
        private void ibtn_Buscar_Click(object sender, EventArgs e)
        {
            if (_vendedorService == null) { MessageBox.Show("Servicio de vendedores no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            string textoBusquedaVendedor = tbx_Busqueda.Text.Trim();

            if (string.IsNullOrWhiteSpace(textoBusquedaVendedor))
            {
                // Si no hay texto de búsqueda de vendedor, pero se quiere aplicar un filtro de fecha a un vendedor ya seleccionado
                if (_vendedorSeleccionadoParaReporte != null && cbx_FiltroV.SelectedItem?.ToString() == "Por Rango de Fechas (Últ. Act. Stock)")
                {
                    if (dtp_FInicio.Value.Date > dtp_FFin.Value.Date)
                    {
                        MessageBox.Show("La fecha de inicio no puede ser posterior a la fecha de fin.", "Rango de Fechas Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    GenerarReporteInventarioVendedor();
                    return;
                }
                else if (_vendedorSeleccionadoParaReporte != null && cbx_FiltroV.SelectedItem?.ToString() == "Inventario Actual")
                {
                    GenerarReporteInventarioVendedor();
                    return;
                }
                MessageBox.Show("Por favor, ingrese un código o nombre de vendedor para buscar.", "Información Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _vendedorSeleccionadoParaReporte = null;
                LimpiarGrilla();
                return;
            }

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
            }
            else
            {
                _vendedorSeleccionadoParaReporte = null;
                MessageBox.Show($"No se encontró ningún vendedor con el código o nombre '{textoBusquedaVendedor}'.", "Búsqueda sin Resultados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimpiarGrilla();
                return; // si no se encuentra vendedor, no continuar a generar reporte
            }

            // Si se encontró un vendedor (o se mantuvo el anterior y se quiere aplicar filtro de fecha), generar reporte.
            if (cbx_FiltroV.SelectedItem?.ToString() == "Por Rango de Fechas (Últ. Act. Stock)")
            {
                if (dtp_FInicio.Value.Date > dtp_FFin.Value.Date)
                {
                    MessageBox.Show("La fecha de inicio no puede ser posterior a la fecha de fin.", "Rango de Fechas Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            GenerarReporteInventarioVendedor();
        }

        private void ibtn_Add_Click(object sender, EventArgs e)
        {
            // Futura lógica para generar PDF
            MessageBox.Show("Función 'Generar PDF' aún no implementada.", "Próximamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GenerarReporteInventarioVendedor()
        {
            if (_vendedorSeleccionadoParaReporte == null)
            {
                // Si el usuario no ha buscado un vendedor aún, no se genera el reporte.
                LimpiarGrilla();
                return;
            }
            if (_reporteService == null || _productoService == null)
            {
                MessageBox.Show("Servicios no disponibles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IEnumerable<Producto> productosDelVendedor;

            // Obtener productos del vendedor seleccionado. El servicio ya debería filtrar por activos si es la lógica.
            // Si necesitas filtrar explícitamente por activos aquí:
            // productosDelVendedor = _productoService.ObtenerProductosPorVendedor(_vendedorSeleccionadoParaReporte.IdVendedor).Where(p => p.Activo).ToList();
            productosDelVendedor = _productoService.ObtenerProductosPorVendedor(_vendedorSeleccionadoParaReporte.IdVendedor);

            if (productosDelVendedor == null)
            {
                MessageBox.Show("No se pudieron obtener los productos del vendedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarGrilla();
                return;
            }

            string filtroFechaSeleccionado = cbx_FiltroV.SelectedItem?.ToString();
            if (filtroFechaSeleccionado == "Por Rango de Fechas (Últ. Act. Stock)")
            {
                DateTime fechaInicio = dtp_FInicio.Value.Date;
                DateTime fechaFin = dtp_FFin.Value.Date.AddDays(1).AddTicks(-1);
                // Filtrar los productos obtenidos por el rango de fechas de actualización de stock
                productosDelVendedor = productosDelVendedor.Where(p => p.FechaActualizacionStock >= fechaInicio && p.FechaActualizacionStock <= fechaFin).ToList();
            }

            LoadReportDataGrid(productosDelVendedor);
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

        private void ibtn_Clear_Click(object sender, EventArgs e)
        {
            if (tbx_Busqueda != null) tbx_Busqueda.Clear();
            _vendedorSeleccionadoParaReporte = null;

            if (cbx_FiltroV != null && cbx_FiltroV.Items.Count > 0)
            {
                cbx_FiltroV.SelectedIndex = 0; // disparará Cbx_FiltroV_SelectedIndexChanged y ocultará los DateTimePickers
            }
            LimpiarGrilla();
        }
    }
}
