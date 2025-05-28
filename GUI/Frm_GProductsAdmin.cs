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
    public partial class Frm_GProductsAdmin : Form
    {
        private readonly IProductoService _productoService;
        private readonly ICategoriaProductoService _categoriaProductoService;
        private readonly IVendedorService _vendedorService;
        private readonly int _idAdminLogueado;

        public Frm_GProductsAdmin(int idAdminLogueado)
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
                _productoService = new ProductoService();
                _categoriaProductoService = new CategoriaProductoService();
                _vendedorService = new VendedorService();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico al inicializar servicios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Deshabilitar controles si la inicialización falla
                if (ibtn_Buscar != null) ibtn_Buscar.Enabled = false;
                if (ibtn_ModifyInfo != null) ibtn_ModifyInfo.Enabled = false;
                if (ibtn_Delete != null) ibtn_Delete.Enabled = false;
                if (cbx_FiltroV != null) cbx_FiltroV.Enabled = false;
                if (ibtn_Clear != null) ibtn_Clear.Enabled = false;
            }
        }

        private void Frm_GProductsAdmin_Load(object sender, EventArgs e)
        {
            if (_idAdminLogueado > 0 && _productoService != null)
            {
                CargarFiltrosComboBox();
                LoadProductsData(true); // Cargar solo activos por defecto
            }
        }

        private void CargarFiltrosComboBox()
        {
            // cbx_FiltroV es el ComboBox para los criterios de búsqueda
            if (cbx_FiltroV == null) return;
            cbx_FiltroV.Items.Clear();
            cbx_FiltroV.Items.Add("-- Seleccione Criterio --");
            cbx_FiltroV.Items.Add("Nombre Producto");
            cbx_FiltroV.Items.Add("Categoría (Nombre Exacto)");
            cbx_FiltroV.Items.Add("Código Vendedor");
            cbx_FiltroV.Items.Add("Stock Bajo (menor a 10)");
            cbx_FiltroV.Items.Add("Estado (Activo/Inactivo)");
            cbx_FiltroV.SelectedIndex = 0;
        }

        private void LoadProductsData(bool soloActivos = false, IEnumerable<Producto> productosFiltrados = null)
        {
            try
            {
                if (_productoService == null) { MessageBox.Show("Servicio de productos no inicializado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                IEnumerable<Producto> productosAMostrar;

                if (productosFiltrados != null)
                {
                    productosAMostrar = productosFiltrados.ToList();
                }
                else if (soloActivos)
                {
                    productosAMostrar = _productoService.ObtenerTodosLosProductos().Where(p => p.Activo).ToList();
                }
                else
                {
                    productosAMostrar = _productoService.ObtenerTodosLosProductos().ToList();
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("IdProducto", typeof(int));
                dt.Columns.Add("Nombre", typeof(string));
                dt.Columns.Add("Descripcion", typeof(string));
                dt.Columns.Add("Precio", typeof(decimal));
                dt.Columns.Add("UnidadMedida", typeof(string));
                dt.Columns.Add("Categoria", typeof(string));
                dt.Columns.Add("Stock", typeof(int));
                dt.Columns.Add("VendedorCodigo", typeof(string));
                dt.Columns.Add("Estado", typeof(string));

                foreach (var producto in productosAMostrar.OrderBy(p => p.Nombre))
                {
                    dt.Rows.Add(
                        producto.IdProducto,
                        producto.Nombre,
                        producto.Descripcion,
                        producto.Precio,
                        producto.UnidadMedida?.Nombre ?? "N/A",
                        producto.Categoria?.Nombre ?? "N/A",
                        producto.Stock,
                        producto.Vendedor?.CodigoVendedor ?? "N/A",
                        producto.Activo ? "Activo" : "Inactivo"
                    );
                }

                // dgv_ListaCategorías es el nombre de tu DataGridView en Frm_GProductsAdmin.cs
                if (dgv_ListaCategorías != null)
                {
                    dgv_ListaCategorías.DataSource = dt;
                    if (dgv_ListaCategorías.Columns["IdProducto"] != null) dgv_ListaCategorías.Columns["IdProducto"].Visible = false;
                    if (dgv_ListaCategorías.Columns["Precio"] != null) dgv_ListaCategorías.Columns["Precio"].DefaultCellStyle.Format = "C2";

                    // Lógica para mostrar/ocultar la columna Estado
                    bool criterioEsEstado = cbx_FiltroV.SelectedItem?.ToString() == "Estado (Activo/Inactivo)";
                    if (dgv_ListaCategorías.Columns["Estado"] != null)
                        dgv_ListaCategorías.Columns["Estado"].Visible = !soloActivos || criterioEsEstado || (productosFiltrados != null && criterioEsEstado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos de productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibtn_ModifyInfo_Click(object sender, EventArgs e)
        {
            if (dgv_ListaCategorías.SelectedRows.Count > 0)
            {
                try
                {
                    int idProducto = Convert.ToInt32(dgv_ListaCategorías.SelectedRows[0].Cells["IdProducto"].Value);
                    if (_productoService == null) { MessageBox.Show("Servicio de productos no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                    Producto productoAModificar = _productoService.ObtenerProductoPorId(idProducto);

                    if (productoAModificar != null)
                    {
                        using (Frm_ModifyProductAdmin_Vendor frmModify = new Frm_ModifyProductAdmin_Vendor(productoAModificar, _idAdminLogueado))
                        {
                            if (frmModify.ShowDialog() == DialogResult.OK)
                            {
                                LoadProductsData(true);
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
                MessageBox.Show("Seleccione un producto para modificar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ibtn_Delete_Click(object sender, EventArgs e)
        {
            if (dgv_ListaCategorías.SelectedRows.Count > 0)
            {
                try
                {
                    int idProducto = Convert.ToInt32(dgv_ListaCategorías.SelectedRows[0].Cells["IdProducto"].Value);
                    string nombreProducto = dgv_ListaCategorías.SelectedRows[0].Cells["Nombre"].Value.ToString();
                    bool estaActivo = dgv_ListaCategorías.SelectedRows[0].Cells["Estado"].Value.ToString().Equals("Activo", StringComparison.OrdinalIgnoreCase);

                    string accion = estaActivo ? "inactivar" : "reactivar";
                    DialogResult confirm = MessageBox.Show($"¿Está seguro que desea {accion} el producto '{nombreProducto}'?", $"Confirmar {accion}", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirm == DialogResult.Yes)
                    {
                        if (_productoService == null) { MessageBox.Show("Servicio de productos no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                        string resultado = _productoService.CambiarEstadoActividadProducto(idProducto, !estaActivo, _idAdminLogueado);
                        MessageBox.Show(resultado, "Cambio de Estado", MessageBoxButtons.OK,
                                        resultado.ToLower().Contains("exitosamente") ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                        LoadProductsData(true);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cambiar estado del producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto de la lista.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ibtn_Buscar_Click(object sender, EventArgs e)
        {
            string criterio = cbx_FiltroV.SelectedItem?.ToString();
            string textoBusqueda = tbx_Busqueda.Text.Trim();
            IEnumerable<Producto> productosFiltrados = new List<Producto>();
            bool soloActivosAlBuscar = true;
            bool mostrarColumnaEstado = false;

            if (string.IsNullOrEmpty(criterio) || criterio == "-- Seleccione Criterio --")
            {
                if (string.IsNullOrWhiteSpace(textoBusqueda)) // Si no hay criterio ni texto, mostrar activos
                {
                    LoadProductsData(true);
                    return;
                }
                // Si hay texto pero no criterio, podríamos buscar por nombre por defecto
                criterio = "Nombre Producto";
            }
            if (_productoService == null) { MessageBox.Show("Servicio de productos no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            try
            {
                var todosLosProductos = _productoService.ObtenerTodosLosProductos();

                switch (criterio)
                {
                    case "Nombre Producto":
                        if (!string.IsNullOrWhiteSpace(textoBusqueda))
                            productosFiltrados = todosLosProductos.Where(p => p.Nombre.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0 && p.Activo);
                        else { LoadProductsData(true); return; }
                        break;
                    case "Categoría (Nombre Exacto)":
                        if (!string.IsNullOrWhiteSpace(textoBusqueda) && _categoriaProductoService != null)
                        {
                            var categoria = _categoriaProductoService.ObtenerPorNombre(textoBusqueda);
                            if (categoria != null)
                                productosFiltrados = todosLosProductos.Where(p => p.CategoriaId == categoria.IdCategoria && p.Activo);
                            else
                                MessageBox.Show($"Categoría '{textoBusqueda}' no encontrada.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else { LoadProductsData(true); return; }
                        break;
                    case "Código Vendedor":
                        if (!string.IsNullOrWhiteSpace(textoBusqueda) && _vendedorService != null)
                        {
                            var vendedor = _vendedorService.ObtenerVendedorPorCodigo(textoBusqueda);
                            if (vendedor != null)
                                productosFiltrados = todosLosProductos.Where(p => p.VendedorId == vendedor.IdVendedor && p.Activo);
                            else
                                MessageBox.Show($"Vendedor con código '{textoBusqueda}' no encontrado.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else { LoadProductsData(true); return; }
                        break;
                    case "Stock Bajo (menor a 10)":
                        productosFiltrados = todosLosProductos.Where(p => p.Stock < 10 && p.Activo);
                        break;
                    case "Estado (Activo/Inactivo)":
                        mostrarColumnaEstado = true;
                        soloActivosAlBuscar = false;
                        if (textoBusqueda.Equals("Activo", StringComparison.OrdinalIgnoreCase))
                            productosFiltrados = todosLosProductos.Where(p => p.Activo).ToList();
                        else if (textoBusqueda.Equals("Inactivo", StringComparison.OrdinalIgnoreCase))
                            productosFiltrados = todosLosProductos.Where(p => !p.Activo).ToList();
                        else if (string.IsNullOrWhiteSpace(textoBusqueda))
                            productosFiltrados = todosLosProductos.ToList();
                        else
                        {
                            MessageBox.Show("Para filtrar por estado, ingrese 'Activo', 'Inactivo' o deje el campo vacío para ver todos.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadProductsData(true); return;
                        }
                        break;
                    default: // Si el criterio no es reconocido o es "-- Seleccione Criterio --" pero hay texto, busca por nombre
                        if (!string.IsNullOrWhiteSpace(textoBusqueda))
                            productosFiltrados = todosLosProductos.Where(p => p.Nombre.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0 && p.Activo);
                        else
                            productosFiltrados = todosLosProductos.Where(p => p.Activo).ToList();
                        break;
                }
                LoadProductsData(soloActivosAlBuscar && !mostrarColumnaEstado, productosFiltrados);
                if (dgv_ListaCategorías.Columns["Estado"] != null)
                    dgv_ListaCategorías.Columns["Estado"].Visible = mostrarColumnaEstado;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Asegúrate que el nombre del botón Limpiar en tu Designer sea ibtn_Clear
        private void ibtn_Clear_Click(object sender, EventArgs e)
        {
            if (tbx_Busqueda != null) tbx_Busqueda.Clear();
            if (cbx_FiltroV != null && cbx_FiltroV.Items.Count > 0) cbx_FiltroV.SelectedIndex = 0;
            LoadProductsData(true);
        }
    }
}