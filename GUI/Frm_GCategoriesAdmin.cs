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
    public partial class Frm_GCategoriesAdmin : Form
    {
        private readonly ICategoriaProductoService _categoriaService;
        private readonly IProductoService _productoService;
        private readonly int _idAdminLogueado;

        public Frm_GCategoriesAdmin(int idAdminLogueado)
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
                _categoriaService = new CategoriaProductoService();
                _productoService = new ProductoService();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico al inicializar servicios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (ibtn_Add != null) ibtn_Add.Enabled = false;
                if (ibtn_ModifyInfo != null) ibtn_ModifyInfo.Enabled = false;
                if (ibtn_Delete != null) ibtn_Delete.Enabled = false;
                if (ibtn_Buscar != null) ibtn_Buscar.Enabled = false;
            }
        }

        private void Frm_GCategoriesAdmin_Load(object sender, EventArgs e)
        {
            if (_idAdminLogueado > 0 && _categoriaService != null)
            {
                CargarFiltrosComboBox();
                LoadCategoriesData();
            }
        }

        private void CargarFiltrosComboBox()
        {
            if (cbx_FiltroV == null) return;
            cbx_FiltroV.Items.Clear();
            cbx_FiltroV.Items.Add("-- Seleccione Criterio --");
            cbx_FiltroV.Items.Add("Nombre");
            cbx_FiltroV.SelectedIndex = 0;
        }

        private void LoadCategoriesData(IEnumerable<CategoriaProducto> categorias = null)
        {
            try
            {
                if (_categoriaService == null) { MessageBox.Show("Servicio de categorías no inicializado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                if (categorias == null)
                {
                    categorias = _categoriaService.ObtenerTodas();
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("IdCategoria", typeof(int));
                dt.Columns.Add("Nombre", typeof(string));

                foreach (var categoria in categorias.OrderBy(cat => cat.Nombre))
                {
                    dt.Rows.Add(categoria.IdCategoria, categoria.Nombre);
                }

                if (dgv_ListaProductos != null)
                {
                    dgv_ListaProductos.DataSource = dt;
                    if (dgv_ListaProductos.Columns["IdCategoria"] != null)
                        dgv_ListaProductos.Columns["IdCategoria"].HeaderText = "ID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos de categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibtn_Add_Click(object sender, EventArgs e)
        {
            using (Frm_AddCategoryAdmin frmAdd = new Frm_AddCategoryAdmin())
            {
                if (frmAdd.ShowDialog() == DialogResult.OK)
                {
                    LoadCategoriesData();
                }
            }
        }

        private void ibtn_ModifyInfo_Click(object sender, EventArgs e)
        {
            if (dgv_ListaProductos.SelectedRows.Count > 0)
            {
                try
                {
                    int idCategoria = Convert.ToInt32(dgv_ListaProductos.SelectedRows[0].Cells["IdCategoria"].Value);
                    if (_categoriaService == null) { MessageBox.Show("Servicio de categorías no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                    CategoriaProducto categoriaAModificar = _categoriaService.ObtenerPorId(idCategoria);

                    if (categoriaAModificar != null)
                    {
                        using (Frm_ModifyCategoryAdmin frmModify = new Frm_ModifyCategoryAdmin(categoriaAModificar, _idAdminLogueado))
                        {
                            if (frmModify.ShowDialog() == DialogResult.OK)
                            {
                                LoadCategoriesData();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo encontrar la categoría seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al preparar modificación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una categoría para modificar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ibtn_Delete_Click(object sender, EventArgs e)
        {
            if (dgv_ListaProductos.SelectedRows.Count > 0)
            {
                try
                {
                    int idCategoria = Convert.ToInt32(dgv_ListaProductos.SelectedRows[0].Cells["IdCategoria"].Value);
                    string nombreCategoria = dgv_ListaProductos.SelectedRows[0].Cells["Nombre"].Value.ToString();

                    DialogResult confirm = MessageBox.Show($"¿Está seguro que desea eliminar la categoría '{nombreCategoria}'?\nEsto solo será posible si no hay productos asociados a ella.", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirm == DialogResult.Yes)
                    {
                        if (_categoriaService == null || _productoService == null) { MessageBox.Show("Servicios no disponibles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                        var productosConCategoria = _productoService.BuscarProductosPorCategoria(idCategoria);
                        if (productosConCategoria.Any())
                        {
                            MessageBox.Show($"No se puede eliminar la categoría '{nombreCategoria}' porque está siendo utilizada por uno o más productos.", "Eliminación Fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string resultado = _categoriaService.EliminarCategoria(idCategoria);

                        MessageBox.Show(resultado, "Eliminar Categoría", MessageBoxButtons.OK,
                                        resultado.ToLower().Contains("exitosamente") ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                        LoadCategoriesData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una categoría para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ibtn_Buscar_Click(object sender, EventArgs e)
        {
            string criterio = cbx_FiltroV.SelectedItem?.ToString();
            string textoBusqueda = tbx_Busqueda.Text.Trim();
            IEnumerable<CategoriaProducto> categoriasFiltradas = new List<CategoriaProducto>();

            if (_categoriaService == null) { MessageBox.Show("Servicio de categorías no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            if (string.IsNullOrEmpty(criterio) || criterio == "-- Seleccione Criterio --" || string.IsNullOrWhiteSpace(textoBusqueda))
            {
                LoadCategoriesData();
                return;
            }

            try
            {
                if (criterio == "Nombre")
                {
                    var todas = _categoriaService.ObtenerTodas();
                    categoriasFiltradas = todas.Where(cat => cat.Nombre.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                }
                LoadCategoriesData(categoriasFiltradas);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibtn_Clear_Click(object sender, EventArgs e)
        {
            if (tbx_Busqueda != null) tbx_Busqueda.Clear();
            if (cbx_FiltroV != null && cbx_FiltroV.Items.Count > 0) cbx_FiltroV.SelectedIndex = 0;
            LoadCategoriesData();
        }
    }
}