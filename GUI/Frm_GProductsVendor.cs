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
    public partial class Frm_GProductsVendor : Form
    {
        private readonly IProductoService _productoService;
        private readonly ICategoriaProductoService _categoriaProductoService;
        private readonly IUnidadMedidaService _unidadMedidaService;
        private readonly int _idUsuarioVendedorLogueado; // ID del usuario (tabla users) del vendedor logueado
        private readonly int _idVendedorTabla; // ID de la tabla 'sellers' del vendedor logueado

        // Constructor actualizado para recibir ambos IDs del vendedor
        public Frm_GProductsVendor(int idUsuarioVendedor, int idVendedorTabla)
        {
            InitializeComponent();
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            _idUsuarioVendedorLogueado = idUsuarioVendedor;
            _idVendedorTabla = idVendedorTabla;


            if (_idUsuarioVendedorLogueado <= 0 || _idVendedorTabla <= 0)
            {
                MessageBox.Show("Error: Información del vendedor no válida.", "Error de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new MethodInvoker(this.Close));
                return;
            }

            try
            {
                _productoService = new ProductoService();
                _categoriaProductoService = new CategoriaProductoService();
                _unidadMedidaService = new UnidadMedidaService();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico al inicializar servicios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Deshabilitar controles
                if (ibtn_Add != null) ibtn_Add.Enabled = false;
                if (ibtn_Modify != null) ibtn_Modify.Enabled = false;
                if (ibtn_Buscar != null) ibtn_Buscar.Enabled = false;
                if (cbx_FiltroV != null) cbx_FiltroV.Enabled = false;
                if (ibtn_Clear != null) ibtn_Clear.Enabled = false;
            }
        }

        private void Frm_GProductsVendor_Load(object sender, EventArgs e)
        {
            if (_idUsuarioVendedorLogueado > 0 && _productoService != null)
            {
                CargarFiltrosComboBox();
                LoadProductsData(); // Cargar productos del vendedor logueado
            }
        }

        private void CargarFiltrosComboBox()
        {
            if (cbx_FiltroV == null) return;
            cbx_FiltroV.Items.Clear();
            cbx_FiltroV.Items.Add("-- Seleccione Criterio --");
            cbx_FiltroV.Items.Add("Nombre");
            cbx_FiltroV.Items.Add("Categoría");
            cbx_FiltroV.Items.Add("Stock Bajo (menor a 10)");
            cbx_FiltroV.SelectedIndex = 0;
        }

        private void LoadProductsData(IEnumerable<Producto> productosFiltrados = null)
        {
            try
            {
                if (_productoService == null) { MessageBox.Show("Servicio de productos no inicializado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                IEnumerable<Producto> productosAMostrar;

                if (productosFiltrados != null)
                {
                    productosAMostrar = productosFiltrados.ToList();
                }
                else
                {
                    // Cargar solo productos del vendedor logueado y que estén activos
                    productosAMostrar = _productoService.ObtenerProductosPorVendedor(_idVendedorTabla)
                                                     .Where(p => p.Activo).ToList();
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("IdProducto", typeof(int));
                dt.Columns.Add("Nombre", typeof(string));
                // dt.Columns.Add("Descripcion", typeof(string)); // Opcional para la grilla principal
                dt.Columns.Add("Precio", typeof(decimal));
                dt.Columns.Add("UnidadMedida", typeof(string));
                dt.Columns.Add("Categoria", typeof(string));
                dt.Columns.Add("Stock", typeof(int));
                // No es necesario mostrar "VendedorCodigo" ni "Estado" si solo se ven productos activos del propio vendedor

                foreach (var producto in productosAMostrar.OrderBy(p => p.Nombre))
                {
                    dt.Rows.Add(
                        producto.IdProducto,
                        producto.Nombre,
                        // producto.Descripcion,
                        producto.Precio,
                        producto.UnidadMedida?.Nombre ?? "N/A",
                        producto.Categoria?.Nombre ?? "N/A",
                        producto.Stock
                    );
                }

                // dgv_ListaCategorías es el nombre de tu DataGridView en Frm_GProductsVendor.cs
                if (dgv_ListaCategorías != null)
                {
                    dgv_ListaCategorías.DataSource = dt;
                    if (dgv_ListaCategorías.Columns["IdProducto"] != null) dgv_ListaCategorías.Columns["IdProducto"].Visible = false;
                    if (dgv_ListaCategorías.Columns["Precio"] != null) dgv_ListaCategorías.Columns["Precio"].DefaultCellStyle.Format = "C2";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibtn_Add_Click(object sender, EventArgs e)
        {
            // Frm_AddProductVendor necesitará el IdUsuario del vendedor y su IdVendedor (de la tabla sellers)
            using (Frm_AddProductVendor frmAdd = new Frm_AddProductVendor(_idUsuarioVendedorLogueado, _idVendedorTabla))
            {
                if (frmAdd.ShowDialog() == DialogResult.OK)
                {
                    LoadProductsData();
                }
            }
        }

        // CORREGIDO: Evento para el botón Modificar
        private void ibtn_Modify_Click(object sender, EventArgs e)
        {
            if (dgv_ListaCategorías.SelectedRows.Count > 0)
            {
                try
                {
                    int idProductoSeleccionado = Convert.ToInt32(dgv_ListaCategorías.SelectedRows[0].Cells["IdProducto"].Value);
                    if (_productoService == null) { MessageBox.Show("Servicio de productos no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                    Producto productoAModificar = _productoService.ObtenerProductoPorId(idProductoSeleccionado);

                    if (productoAModificar != null)
                    {
                        // El vendedor solo puede modificar sus propios productos.
                        // La validación de si es su producto ya está implícita porque solo carga sus productos.
                        // Se pasa el _idUsuarioVendedorLogueado para el parámetro idUsuarioQueModifica del constructor.
                        using (Frm_ModifyProductAdmin_Vendor frmModify = new Frm_ModifyProductAdmin_Vendor(productoAModificar, _idUsuarioVendedorLogueado))
                        {
                            if (frmModify.ShowDialog() == DialogResult.OK)
                            {
                                LoadProductsData(); // Recargar los productos del vendedor
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo encontrar el producto seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al preparar modificación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto de la lista para modificar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ibtn_Buscar_Click(object sender, EventArgs e)
        {
            string criterio = cbx_FiltroV.SelectedItem?.ToString();
            string textoBusqueda = tbx_Busqueda.Text.Trim();
            IEnumerable<Producto> productosFiltrados = new List<Producto>();

            if (string.IsNullOrEmpty(criterio) || criterio == "-- Seleccione Criterio --")
            {
                if (string.IsNullOrWhiteSpace(textoBusqueda)) LoadProductsData(); // Carga todos los del vendedor si no hay texto
                else criterio = "Nombre"; // Si hay texto pero no criterio, busca por nombre
            }
            if (_productoService == null) { MessageBox.Show("Servicio de productos no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            try
            {
                // Siempre filtrar sobre los productos del vendedor logueado y que estén activos
                var productosDelVendedor = _productoService.ObtenerProductosPorVendedor(_idVendedorTabla).Where(p => p.Activo);

                switch (criterio)
                {
                    case "Nombre":
                        if (!string.IsNullOrWhiteSpace(textoBusqueda))
                            productosFiltrados = productosDelVendedor.Where(p => p.Nombre.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0);
                        else { LoadProductsData(); return; }
                        break;
                    case "Categoría":
                        if (!string.IsNullOrWhiteSpace(textoBusqueda) && _categoriaProductoService != null)
                        {
                            // Buscar por nombre de categoría es más amigable para el usuario
                            var categoria = _categoriaProductoService.ObtenerPorNombre(textoBusqueda);
                            if (categoria != null)
                                productosFiltrados = productosDelVendedor.Where(p => p.CategoriaId == categoria.IdCategoria);
                            else
                                MessageBox.Show($"Categoría '{textoBusqueda}' no encontrada.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else { LoadProductsData(); return; }
                        break;
                    case "Stock Bajo (menor a 10)":
                        productosFiltrados = productosDelVendedor.Where(p => p.Stock < 10);
                        break;
                    default:
                        productosFiltrados = productosDelVendedor; // Si el criterio no es reconocido o es default
                        break;
                }
                LoadProductsData(productosFiltrados);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Asegúrate que el nombre de tu botón Limpiar en el Designer sea ibtn_Clear
        private void ibtn_Clear_Click(object sender, EventArgs e)
        {
            if (tbx_Busqueda != null) tbx_Busqueda.Clear();
            if (cbx_FiltroV != null && cbx_FiltroV.Items.Count > 0) cbx_FiltroV.SelectedIndex = 0;
            LoadProductsData();
        }
    }
}