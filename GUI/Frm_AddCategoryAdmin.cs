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
    public partial class Frm_AddCategoryAdmin : Form
    {
        private readonly ICategoriaProductoService _categoriaService;
        // private readonly int _idAdminLogueado; // No se usa en este servicio específico, pero podría pasarse

        public Frm_AddCategoryAdmin(/* int idAdminLogueado */)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;

            // _idAdminLogueado = idAdminLogueado;
            try
            {
                _categoriaService = new CategoriaProductoService();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar servicio de categorías: {ex.Message}", "Error de Inicialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Asumiendo que tu botón de agregar se llama ibtn_Add
                if (this.Controls.Find("ibtn_Add", true).FirstOrDefault() is Button btn) btn.Enabled = false;
            }
        }

        private void ibtn_Add_Click(object sender, EventArgs e)
        {
            // Asumiendo que tu TextBox para el nombre de la categoría se llama tbx_Name
            string nombreCategoria = tbx_Name.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombreCategoria))
            {
                MessageBox.Show("El nombre de la categoría no puede estar vacío.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (_categoriaService == null)
                {
                    MessageBox.Show("Servicio de categorías no disponible.", "Error de Servicio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var nuevaCategoria = new CategoriaProducto { Nombre = nombreCategoria };
                string resultado = _categoriaService.AgregarCategoria(nuevaCategoria);

                MessageBox.Show(resultado, "Agregar Categoría", MessageBoxButtons.OK,
                                resultado.ToLower().Contains("exitosamente") ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (resultado.ToLower().Contains("exitosamente"))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (ApplicationException appEx)
            {
                MessageBox.Show($"Error de aplicación: {appEx.Message}", "Error al Agregar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error inesperado: {ex.Message}", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibtn_Clear_Click(object sender, EventArgs e)
        {
            if (tbx_Name != null) tbx_Name.Clear();
        }

        private void ibtn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}