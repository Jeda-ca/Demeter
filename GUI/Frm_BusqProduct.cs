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
    public partial class Frm_BusqProduct : Form
    {
        public int SelectedProductId { get; private set; }
        public string SelectedProductName { get; private set; }
        public decimal SelectedProductPrice { get; private set; }
        public int SelectedProductStock { get; private set; }

        private readonly IProductoService _productoService;
        private readonly ICategoriaProductoService _categoriaService;
        private readonly int _idVendedorActual;
        private readonly List<CarritoItemTemporal> _itemsEnCarritoActual;

        public Frm_BusqProduct(int idVendedor, List<CarritoItemTemporal> itemsEnCarrito)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;

            _idVendedorActual = idVendedor;
            _itemsEnCarritoActual = itemsEnCarrito ?? new List<CarritoItemTemporal>();

            if (_idVendedorActual <= 0)
            {
                MessageBox.Show("ID de Vendedor no válido. No se pueden buscar productos.", "Error de Contexto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new MethodInvoker(this.Close));
                return;
            }

            try
            {
                _productoService = new ProductoService();
                _categoriaService = new CategoriaProductoService();
                InitializeControls();
                LoadProductsData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar búsqueda de productos: {ex.Message}", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (ibtn_Buscar != null) ibtn_Buscar.Enabled = false;
                if (ibtn_OK != null) ibtn_OK.Enabled = false;
                if (ibtn_Clear != null) ibtn_Clear.Enabled = false;
            }
        }

        public Frm_BusqProduct()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            _idVendedorActual = 0;
            _itemsEnCarritoActual = new List<CarritoItemTemporal>();
            try
            {
                _productoService = new ProductoService();
                _categoriaService = new CategoriaProductoService();
                InitializeControls();
            }
            catch (Exception ex) { }
        }

        private void InitializeControls()
        {
            if (dgv_Product != null) dgv_Product.CellDoubleClick += dgv_Product_CellDoubleClick;

            if (cbx_Busq != null)
            {
                cbx_Busq.Items.Clear();
                cbx_Busq.Items.Add("-- Seleccione Criterio --");
                cbx_Busq.Items.Add("Nombre");
                cbx_Busq.Items.Add("Categoría");
                cbx_Busq.SelectedIndex = 0;
            }
        }

        private void LoadProductsData(IEnumerable<Producto> productos = null)
        {
            try
            {
                if (_productoService == null) { MessageBox.Show("Servicio de productos no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                if (_idVendedorActual <= 0 && productos == null) { if (dgv_Product != null) dgv_Product.DataSource = null; return; }

                if (productos == null)
                {
                    productos = _productoService.ObtenerProductosPorVendedor(_idVendedorActual)
                                             .Where(p => p.Activo).ToList();
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Nombre", typeof(string));
                dt.Columns.Add("Precio", typeof(decimal));
                dt.Columns.Add("StockDB", typeof(int));
                dt.Columns.Add("StockDisponible", typeof(int));
                dt.Columns.Add("Categoría", typeof(string));
                dt.Columns.Add("Unidad", typeof(string));

                foreach (var producto in productos.OrderBy(p => p.Nombre))
                {
                    var itemEnCarrito = _itemsEnCarritoActual.FirstOrDefault(item => item.IdProducto == producto.IdProducto);
                    int cantidadEnCarrito = itemEnCarrito?.Cantidad ?? 0;

                    int stockDisponible = producto.Stock - cantidadEnCarrito;

                    dt.Rows.Add(
                        producto.IdProducto,
                        producto.Nombre,
                        producto.Precio,
                        producto.Stock,
                        stockDisponible < 0 ? 0 : stockDisponible,
                        producto.Categoria?.Nombre ?? "N/A",
                        producto.UnidadMedida?.Nombre ?? "N/A"
                        );
                }
                if (dgv_Product != null)
                {
                    dgv_Product.DataSource = dt;
                    if (dgv_Product.Columns["ID"] != null) dgv_Product.Columns["ID"].Visible = false;
                    if (dgv_Product.Columns["StockDB"] != null) dgv_Product.Columns["StockDB"].Visible = false;
                    if (dgv_Product.Columns["Precio"] != null) dgv_Product.Columns["Precio"].DefaultCellStyle.Format = "C2";
                    if (dgv_Product.Columns["StockDisponible"] != null) dgv_Product.Columns["StockDisponible"].HeaderText = "Stock Disp.";
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ibtn_Buscar_Click(object sender, EventArgs e)
        {
            if (_productoService == null || cbx_Busq == null || tbx_Busq == null) return;

            string criterio = cbx_Busq.SelectedItem?.ToString();
            string textoBusqueda = tbx_Busq.Text.Trim();
            IEnumerable<Producto> productosFiltrados = new List<Producto>();

            if (string.IsNullOrEmpty(criterio) || criterio == "-- Seleccione Criterio --")
            {
                if (string.IsNullOrWhiteSpace(textoBusqueda)) LoadProductsData();
                else criterio = "Nombre";
            }

            try
            {
                var productosDelVendedorActivos = _productoService.ObtenerProductosPorVendedor(_idVendedorActual)
                                                               .Where(p => p.Activo);
                switch (criterio)
                {
                    case "Nombre":
                        if (!string.IsNullOrWhiteSpace(textoBusqueda))
                            productosFiltrados = productosDelVendedorActivos.Where(p => p.Nombre.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0);
                        else { LoadProductsData(); return; }
                        break;
                    case "Categoría":
                        if (!string.IsNullOrWhiteSpace(textoBusqueda) && _categoriaService != null)
                        {
                            var todasLasCategorias = _categoriaService.ObtenerTodas();
                            var categoriasCoincidentes = todasLasCategorias
                                .Where(cat => cat.Nombre.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0)
                                .Select(cat => cat.IdCategoria)
                                .ToList();

                            if (categoriasCoincidentes.Any())
                            {
                                productosFiltrados = productosDelVendedorActivos
                                    .Where(p => categoriasCoincidentes.Contains(p.CategoriaId));
                            }
                            else
                            {
                                MessageBox.Show($"No se encontraron categorías que coincidan con '{textoBusqueda}'.", "Búsqueda de Categoría", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                productosFiltrados = new List<Producto>();
                            }
                        }
                        else { LoadProductsData(); return; }
                        break;
                    default:
                        productosFiltrados = productosDelVendedorActivos;
                        break;
                }
                LoadProductsData(productosFiltrados.ToList());
            }
            catch (Exception ex) { MessageBox.Show($"Error al buscar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ibtn_Clear_Click(object sender, EventArgs e)
        {
            if (tbx_Busq != null) tbx_Busq.Clear();
            if (cbx_Busq != null && cbx_Busq.Items.Count > 0) cbx_Busq.SelectedIndex = 0;
            LoadProductsData();
        }

        private void ibtn_OK_Click(object sender, EventArgs e)
        {
            SelectProductAndClose();
        }

        private void dgv_Product_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectProductAndClose();
            }
        }

        private void SelectProductAndClose()
        {
            if (dgv_Product.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow selectedRow = dgv_Product.SelectedRows[0];
                    SelectedProductId = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                    SelectedProductName = selectedRow.Cells["Nombre"].Value.ToString();
                    SelectedProductPrice = Convert.ToDecimal(selectedRow.Cells["Precio"].Value);
                    SelectedProductStock = Convert.ToInt32(selectedRow.Cells["StockDisponible"].Value);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al seleccionar producto: {ex.Message}", "Error de Selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un producto de la lista.", "No hay selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}