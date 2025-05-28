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
    public partial class Frm_AddProductVendor : Form
    {
        private readonly IProductoService _productoService;
        private readonly ICategoriaProductoService _categoriaService;
        private readonly IUnidadMedidaService _unidadMedidaService;
        private readonly int _idUsuarioVendedorLogueado;
        private readonly int _idVendedorTabla; // PK de la tabla 'sellers'

        // Constructor actualizado
        public Frm_AddProductVendor(int idUsuarioVendedor, int idVendedorTabla)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;

            _idUsuarioVendedorLogueado = idUsuarioVendedor;
            _idVendedorTabla = idVendedorTabla;

            try
            {
                _productoService = new ProductoService();
                _categoriaService = new CategoriaProductoService();
                _unidadMedidaService = new UnidadMedidaService();

                CargarCategoriasComboBox();
                CargarUnidadesMedidaComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico al inicializar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (ibtn_Add != null) ibtn_Add.Enabled = false;
                if (ibtn_Clear != null) ibtn_Clear.Enabled = false;
            }
        }

        private void CargarCategoriasComboBox()
        {
            try
            {
                if (_categoriaService == null) return;
                var categorias = _categoriaService.ObtenerTodas().ToList();
                if (cbx_Category != null)
                {
                    cbx_Category.DataSource = null;
                    cbx_Category.Items.Clear();
                    cbx_Category.DisplayMember = "Nombre";
                    cbx_Category.ValueMember = "IdCategoria";
                    var listaConDefault = categorias;
                    listaConDefault.Insert(0, new CategoriaProducto { IdCategoria = 0, Nombre = "-- Seleccione Categoría --" });
                    cbx_Category.DataSource = listaConDefault;
                    cbx_Category.SelectedIndex = 0;
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error al cargar categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void CargarUnidadesMedidaComboBox()
        {
            try
            {
                if (_unidadMedidaService == null) return;
                var unidades = _unidadMedidaService.ObtenerTodas().ToList();
                if (cbx_UnMedida != null)
                {
                    cbx_UnMedida.DataSource = null;
                    cbx_UnMedida.Items.Clear();
                    cbx_UnMedida.DisplayMember = "Nombre";
                    cbx_UnMedida.ValueMember = "IdUnidadMedida";
                    var listaConDefault = unidades;
                    listaConDefault.Insert(0, new UnidadMedida { IdUnidadMedida = 0, Nombre = "-- Seleccione Unidad --" });
                    cbx_UnMedida.DataSource = listaConDefault;
                    cbx_UnMedida.SelectedIndex = 0;
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error al cargar unidades de medida: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        private void ibtn_Add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbx_Name.Text) ||
                cbx_Category.SelectedValue == null || !(cbx_Category.SelectedValue is int) || ((int)cbx_Category.SelectedValue) <= 0 ||
                cbx_UnMedida.SelectedValue == null || !(cbx_UnMedida.SelectedValue is int) || ((int)cbx_UnMedida.SelectedValue) <= 0 ||
                nud_Price.Value <= 0 || nud_Stock.Value < 0)
            {
                MessageBox.Show("Nombre, Categoría, Unidad de Medida son obligatorios. Precio debe ser mayor a 0 y Stock no puede ser negativo.", "Campos Inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nuevoProducto = new Producto
            {
                Nombre = tbx_Name.Text.Trim(),
                Descripcion = tbx_NumDoc.Text.Trim(), // tbx_NumDoc es Descripción
                Precio = nud_Price.Value,
                Stock = (int)nud_Stock.Value,
                CategoriaId = (int)cbx_Category.SelectedValue,
                UnidadMedidaId = (int)cbx_UnMedida.SelectedValue,
                VendedorId = _idVendedorTabla // ID de la tabla 'sellers'
            };

            try
            {
                if (_productoService == null) { MessageBox.Show("Servicio de productos no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                // El servicio RegistrarNuevoProducto espera el IdUsuario del que registra
                string resultado = _productoService.RegistrarNuevoProducto(nuevoProducto, _idUsuarioVendedorLogueado);

                MessageBox.Show(resultado, "Agregar Producto", MessageBoxButtons.OK,
                                resultado.ToLower().Contains("exitosamente") ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (resultado.ToLower().Contains("exitosamente"))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibtn_Clear_Click(object sender, EventArgs e)
        {
            tbx_Name.Clear();
            tbx_NumDoc.Clear();
            nud_Price.Value = 0;
            nud_Stock.Value = 0;
            if (cbx_Category.Items.Count > 0) cbx_Category.SelectedIndex = 0;
            if (cbx_UnMedida.Items.Count > 0) cbx_UnMedida.SelectedIndex = 0;
        }

        private void ibtn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
