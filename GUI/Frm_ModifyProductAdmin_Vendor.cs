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
    public partial class Frm_ModifyProductAdmin_Vendor : Form
    {
        private readonly IProductoService _productoService;
        private readonly ICategoriaProductoService _categoriaService;
        private readonly IUnidadMedidaService _unidadMedidaService;
        private readonly Producto _productoAModificar;
        private readonly int _idUsuarioQueModifica; // Puede ser AdminId o VendedorId (IdUsuario)

        public Frm_ModifyProductAdmin_Vendor(Producto producto, int idUsuarioQueModifica)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;

            _productoAModificar = producto ?? throw new ArgumentNullException(nameof(producto));
            _idUsuarioQueModifica = idUsuarioQueModifica;

            try
            {
                _productoService = new ProductoService();
                _categoriaService = new CategoriaProductoService();
                _unidadMedidaService = new UnidadMedidaService();

                CargarCategoriasComboBox();
                CargarUnidadesMedidaComboBox();
                LoadProductData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico al inicializar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Deshabilitar controles si falla la inicialización
                if (ibtn_Modify != null) ibtn_Modify.Enabled = false;
                if (ibtn_Clear != null) ibtn_Clear.Enabled = false;
            }
        }

        private void CargarCategoriasComboBox()
        {
            try
            {
                if (_categoriaService == null) return;
                var categorias = _categoriaService.ObtenerTodas().ToList();
                if (cbx_Category != null) // cbx_Category es el ComboBox de categorías
                {
                    cbx_Category.DataSource = null;
                    cbx_Category.Items.Clear();
                    cbx_Category.DisplayMember = "Nombre";
                    cbx_Category.ValueMember = "IdCategoria";
                    cbx_Category.DataSource = categorias;
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
                if (cbx_UdMedida != null) // cbx_UdMedida es el ComboBox de unidades
                {
                    cbx_UdMedida.DataSource = null;
                    cbx_UdMedida.Items.Clear();
                    cbx_UdMedida.DisplayMember = "Nombre";
                    cbx_UdMedida.ValueMember = "IdUnidadMedida";
                    cbx_UdMedida.DataSource = unidades;
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error al cargar unidades de medida: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void LoadProductData()
        {
            if (_productoAModificar != null)
            {
                // Asegúrate que los nombres de tus controles coincidan
                if (tbx_Name != null) tbx_Name.Text = _productoAModificar.Nombre;
                if (tbx_NumDoc != null) tbx_NumDoc.Text = _productoAModificar.Descripcion; // tbx_NumDoc es para Descripción aquí
                if (nud_Price != null) nud_Price.Value = _productoAModificar.Precio > nud_Price.Maximum ? nud_Price.Maximum : _productoAModificar.Precio; // Evitar error si el precio es muy alto
                if (nud_Stock != null) nud_Stock.Value = _productoAModificar.Stock > nud_Stock.Maximum ? nud_Stock.Maximum : _productoAModificar.Stock;

                if (cbx_Category.Items.Count > 0 && _productoAModificar.CategoriaId > 0)
                    cbx_Category.SelectedValue = _productoAModificar.CategoriaId;

                if (cbx_UdMedida.Items.Count > 0 && _productoAModificar.UnidadMedidaId > 0)
                    cbx_UdMedida.SelectedValue = _productoAModificar.UnidadMedidaId;
            }
        }

        private void ibtn_Modify_Click(object sender, EventArgs e) // Botón "Guardar Cambios"
        {
            if (string.IsNullOrWhiteSpace(tbx_Name.Text) ||
                cbx_Category.SelectedValue == null || !(cbx_Category.SelectedValue is int) || ((int)cbx_Category.SelectedValue) <= 0 ||
                cbx_UdMedida.SelectedValue == null || !(cbx_UdMedida.SelectedValue is int) || ((int)cbx_UdMedida.SelectedValue) <= 0 ||
                nud_Price.Value < 0 || nud_Stock.Value < 0)
            {
                MessageBox.Show("Nombre, Categoría, Unidad de Medida son obligatorios. Precio y Stock no pueden ser negativos.", "Campos Inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _productoAModificar.Nombre = tbx_Name.Text.Trim();
            _productoAModificar.Descripcion = tbx_NumDoc.Text.Trim(); // tbx_NumDoc es Descripción
            _productoAModificar.Precio = nud_Price.Value;
            _productoAModificar.Stock = (int)nud_Stock.Value;
            _productoAModificar.CategoriaId = (int)cbx_Category.SelectedValue;
            _productoAModificar.UnidadMedidaId = (int)cbx_UdMedida.SelectedValue;
            // El VendedorId no se cambia aquí. El estado Activo se maneja desde el gestor principal.

            try
            {
                if (_productoService == null) { MessageBox.Show("Servicio de productos no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                string resultado = _productoService.ModificarProducto(_productoAModificar, _idUsuarioQueModifica);

                MessageBox.Show(resultado, "Modificar Producto", MessageBoxButtons.OK,
                                resultado.ToLower().Contains("exitosamente") ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (resultado.ToLower().Contains("exitosamente"))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (ApplicationException appEx)
            {
                MessageBox.Show($"Error de aplicación: {appEx.Message}", "Error al Modificar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error inesperado: {ex.Message}", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibtn_Clear_Click(object sender, EventArgs e)
        {
            LoadProductData(); // Recarga los datos originales del producto
        }

        private void ibtn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}