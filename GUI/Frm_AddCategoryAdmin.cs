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
        public Frm_AddCategoryAdmin()
        {
            InitializeComponent();
            // Configuración por defecto para un formulario de diálogo.
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Borde fijo para diálogos
            this.StartPosition = FormStartPosition.CenterParent; // Centrar respecto al padre
        }

        // Método para limpiar todos los TextBox del formulario
        private void ClearFormFields()
        {
            tbx_Name.Clear();
        }

        // Evento Click del botón "Agregar" (placeholder para la lógica de agregar categoría)
        private void ibtn_Add_Click(object sender, EventArgs e)
        {
            // --- Lógica placeholder para agregar una nueva categoría ---
            string categoryName = tbx_Name.Text;

            if (string.IsNullOrWhiteSpace(categoryName))
            {
                MessageBox.Show("Por favor, ingrese el nombre de la categoría.", "Campo Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Aquí se llamaría a la capa BLL para agregar la nueva categoría.
            // Ejemplo: BLL.CategoryManager.AddCategory(categoryName);

            MessageBox.Show($"Lógica para agregar nueva categoría: '{categoryName}'.", "Agregar Categoría (Placeholder)", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK; // Indica que la operación fue exitosa
            this.Close(); // Cierra el formulario
        }

        // Evento Click del botón "Limpiar"
        private void ibtn_Clear_Click(object sender, EventArgs e)
        {
            ClearFormFields();
        }

        // Evento Click del botón "Cancelar"
        private void ibtn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Indica que la operación fue cancelada
            this.Close(); // Cierra el formulario sin guardar cambios
        }
    }
}