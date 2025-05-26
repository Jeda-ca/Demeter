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
        // Propiedad para almacenar el ID de la categoría que se está modificando.
        public int CategoryId { get; private set; }

        public Frm_ModifyCategoryAdmin()
        {
            InitializeComponent();
            // Configuración por defecto para un formulario de diálogo.
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Borde fijo para diálogos
            this.StartPosition = FormStartPosition.CenterParent; // Centrar respecto al padre
        }

        // Constructor para recibir información de la categoría (opcional, si necesitas precargar campos).
        public Frm_ModifyCategoryAdmin(int categoryId, string categoryName) : this()
        {
            CategoryId = categoryId;
            tbx_Name.Text = categoryName;
        }

        // Método para precargar la información de la categoría (si no se usa el constructor con parámetros).
        public void SetCategoryInfo(int categoryId, string categoryName)
        {
            CategoryId = categoryId;
            tbx_Name.Text = categoryName;
        }

        // Método para limpiar todos los TextBox del formulario
        private void ClearFormFields()
        {
            tbx_Name.Clear();
        }

        // Evento Click del botón "Guardar cambios" (placeholder para la lógica de modificar categoría)
        private void ibtn_Modify_Click(object sender, EventArgs e)
        {
            // --- Lógica placeholder para modificar una categoría existente ---
            string newCategoryName = tbx_Name.Text;

            if (string.IsNullOrWhiteSpace(newCategoryName))
            {
                MessageBox.Show("Por favor, ingrese el nuevo nombre de la categoría.", "Campo Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Aquí se llamaría a la capa BLL para modificar la categoría.
            // Ejemplo: BLL.CategoryManager.UpdateCategory(CategoryId, newCategoryName);

            MessageBox.Show($"Lógica para modificar categoría ID: {CategoryId} a '{newCategoryName}'.", "Modificar Categoría (Placeholder)", MessageBoxButtons.OK, MessageBoxIcon.Information);

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