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
        public Frm_AddProductVendor()
        {
            InitializeComponent();
            // Configuración por defecto para un formulario de diálogo.
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Borde fijo para diálogos
            this.StartPosition = FormStartPosition.CenterParent; // Centrar respecto al padre

            // Inicializar ComboBox de Categoría (placeholder)
            cbx_Category.Items.Add("-- Seleccione --");
            cbx_Category.Items.Add("FRUTAS");
            cbx_Category.Items.Add("VERDURAS Y HORTALIZAS");
            cbx_Category.Items.Add("TUBÉRCULOS Y RAÍCES");
            cbx_Category.SelectedIndex = 0;

            // Inicializar ComboBox de Unidad de Medida (placeholder)
            cbx_UnMedida.Items.Add("-- Seleccione --");
            cbx_UnMedida.Items.Add("KILOGRAMO");
            cbx_UnMedida.Items.Add("UNIDAD");
            cbx_UnMedida.Items.Add("ATADO");
            cbx_UnMedida.SelectedIndex = 0;

            // Configurar NumericUpDowns
            nud_Price.DecimalPlaces = 2; // Permitir dos decimales para el precio
            nud_Price.Minimum = 0;
            nud_Price.Maximum = 999999999; // Valor máximo alto
            nud_Stock.Minimum = 0;
            nud_Stock.Maximum = 99999; // Valor máximo de stock
        }

        // Método para limpiar todos los campos del formulario
        private void ClearFormFields()
        {
            tbx_Name.Clear();
            tbx_NumDoc.Clear(); // Descripción
            nud_Price.Value = 0;
            nud_Stock.Value = 0;
            cbx_Category.SelectedIndex = 0;
            cbx_UnMedida.SelectedIndex = 0;
        }

        // Evento Click del botón "Agregar" (placeholder para la lógica de agregar producto)
        private void ibtn_Add_Click(object sender, EventArgs e)
        {
            // --- Lógica placeholder para agregar un nuevo producto ---
            string name = tbx_Name.Text;
            string description = tbx_NumDoc.Text; // Asumiendo tbx_NumDoc es el de descripción
            decimal price = nud_Price.Value;
            int stock = (int)nud_Stock.Value;
            string category = cbx_Category.SelectedIndex > 0 ? cbx_Category.SelectedItem.ToString() : string.Empty;
            string unit = cbx_UnMedida.SelectedIndex > 0 ? cbx_UnMedida.SelectedItem.ToString() : string.Empty;

            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description) ||
                cbx_Category.SelectedIndex == 0 || cbx_UnMedida.SelectedIndex == 0 ||
                price <= 0)
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios y asegure que el precio sea mayor a 0.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Aquí se llamaría a la capa BLL para agregar el producto.
            // Ejemplo: BLL.ProductManager.AddProduct(name, description, price, unit, category, stock, sellerId); // Necesitarías el sellerId del vendedor logueado

            MessageBox.Show($"Lógica para agregar nuevo producto:\nNombre: {name}\nPrecio: {price}\nStock: {stock}", "Agregar Producto (Placeholder)", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
