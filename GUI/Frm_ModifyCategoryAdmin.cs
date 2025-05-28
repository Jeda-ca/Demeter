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
    public partial class Frm_ModifyCategoryAdmin : Form
    {
        private readonly ICategoriaProductoService _categoriaService;
        private CategoriaProducto _categoriaAModificar;

        public Frm_ModifyCategoryAdmin(CategoriaProducto categoria, int idAdminLogueado)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;

            _categoriaAModificar = categoria ?? throw new ArgumentNullException(nameof(categoria));

            try
            {
                _categoriaService = new CategoriaProductoService();
                LoadCategoryData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar servicio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (ibtn_Modify != null) ibtn_Modify.Enabled = false;
            }
        }

        private void LoadCategoryData()
        {
            if (_categoriaAModificar != null && tbx_Name != null)
            {
                tbx_Name.Text = _categoriaAModificar.Nombre;
            }
        }

        private void ibtn_Modify_Click(object sender, EventArgs e)
        {
            string nuevoNombre = tbx_Name.Text.Trim();
            if (string.IsNullOrWhiteSpace(nuevoNombre))
            {
                MessageBox.Show("El nombre de la categoría no puede estar vacío.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nuevoNombre.Equals(_categoriaAModificar.Nombre, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("No se realizaron cambios en el nombre.", "Sin Cambios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            try
            {
                if (_categoriaService == null)
                {
                    MessageBox.Show("Servicio de categorías no disponible.", "Error de Servicio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _categoriaAModificar.Nombre = nuevoNombre;
                string resultado = _categoriaService.ActualizarCategoria(_categoriaAModificar);

                MessageBox.Show(resultado, "Modificar Categoría", MessageBoxButtons.OK,
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
            if (_categoriaAModificar != null && tbx_Name != null)
            {
                tbx_Name.Text = _categoriaAModificar.Nombre;
            }
        }

        private void ibtn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}