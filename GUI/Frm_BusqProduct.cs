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
        private readonly ICategoriaProductoService _categoriaService; // Para el filtro por categoría
        private readonly int _idVendedorActual; // Para filtrar productos por el vendedor que registra la venta

        // Constructor que acepta el ID del vendedor (de la tabla 'sellers')
        public Frm_BusqProduct(int idVendedor)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;

            _idVendedorActual = idVendedor;

            if (_idVendedorActual <= 0)
            {
                MessageBox.Show("ID de Vendedor no válido. No se pueden buscar productos.", "Error de Contexto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new MethodInvoker(this.Close)); // Cierra de forma segura
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
                // Deshabilitar controles si es necesario
                if (ibtn_Buscar != null) ibtn_Buscar.Enabled = false;
                if (ibtn_OK != null) ibtn_OK.Enabled = false;
            }
        }

        // Constructor por defecto (necesario para el diseñador de Windows Forms)
        public Frm_BusqProduct()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            _idVendedorActual = 0; // Valor inválido, el formulario no funcionará correctamente en ejecución
            try
            {
                _productoService = new ProductoService();
                _categoriaService = new CategoriaProductoService();
                InitializeControls();
                // No cargar datos si no hay un vendedor válido
            }
            catch (Exception ex) { /* Silencioso en modo diseño o loggear */ }
        }

        private void InitializeControls()
        {
            if (dgv_Product != null) dgv_Product.CellDoubleClick += dgv_Product_CellDoubleClick;

            if (cbx_Busq != null) // cbx_Busq es tu ComboBox para criterios
            {
                cbx_Busq.Items.Clear();
                cbx_Busq.Items.Add("-- Seleccione Criterio --");
                cbx_Busq.Items.Add("Nombre");
                cbx_Busq.Items.Add("Categoría (Nombre Exacto)");
                // cbx_Busq.Items.Add("Stock Bajo"); // Podría no ser relevante aquí
                cbx_Busq.SelectedIndex = 0;
            }
        }

        private void LoadProductsData(IEnumerable<Producto> productos = null)
        {
            try
            {
                if (_productoService == null) { MessageBox.Show("Servicio de productos no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                if (_idVendedorActual <= 0 && productos == null) { /* No cargar si no hay vendedor y no se pasan productos filtrados */ dgv_Product.DataSource = null; return; }


                if (productos == null)
                {
                    // Cargar solo productos activos del vendedor actual
                    productos = _productoService.ObtenerProductosPorVendedor(_idVendedorActual)
                                             .Where(p => p.Activo).ToList();
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int)); // IdProducto
                dt.Columns.Add("Nombre", typeof(string));
                dt.Columns.Add("Precio", typeof(decimal));
                dt.Columns.Add("Stock", typeof(int));
                dt.Columns.Add("Categoría", typeof(string));
                dt.Columns.Add("Unidad", typeof(string));


                foreach (var producto in productos.OrderBy(p => p.Nombre))
                {
                    dt.Rows.Add(
                        producto.IdProducto,
                        producto.Nombre,
                        producto.Precio,
                        producto.Stock,
                        producto.Categoria?.Nombre ?? "N/A",
                        producto.UnidadMedida?.Nombre ?? "N/A"
                        );
                }
                if (dgv_Product != null) // dgv_Product es tu DataGridView
                {
                    dgv_Product.DataSource = dt;
                    if (dgv_Product.Columns["ID"] != null) dgv_Product.Columns["ID"].Visible = false;
                    if (dgv_Product.Columns["Precio"] != null) dgv_Product.Columns["Precio"].DefaultCellStyle.Format = "C2";
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
                if (string.IsNullOrWhiteSpace(textoBusqueda)) LoadProductsData(); // Carga todos los del vendedor
                else criterio = "Nombre"; // Búsqueda por defecto si hay texto
            }

            try
            {
                // Siempre filtrar sobre los productos activos del vendedor actual
                var productosDelVendedorActivos = _productoService.ObtenerProductosPorVendedor(_idVendedorActual)
                                                               .Where(p => p.Activo);
                switch (criterio)
                {
                    case "Nombre":
                        if (!string.IsNullOrWhiteSpace(textoBusqueda))
                            productosFiltrados = productosDelVendedorActivos.Where(p => p.Nombre.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0);
                        else { LoadProductsData(); return; }
                        break;
                    case "Categoría (Nombre Exacto)":
                        if (!string.IsNullOrWhiteSpace(textoBusqueda) && _categoriaService != null)
                        {
                            var categoria = _categoriaService.ObtenerPorNombre(textoBusqueda);
                            if (categoria != null)
                                productosFiltrados = productosDelVendedorActivos.Where(p => p.CategoriaId == categoria.IdCategoria);
                            else
                                MessageBox.Show($"Categoría '{textoBusqueda}' no encontrada.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    SelectedProductStock = Convert.ToInt32(selectedRow.Cells["Stock"].Value);

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