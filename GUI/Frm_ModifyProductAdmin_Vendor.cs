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
        // Propiedad para almacenar el ID del producto que se está modificando.
        public int ProductId { get; private set; }

        public Frm_ModifyProductAdmin_Vendor()
        {
            InitializeComponent();
            // Configuración por defecto para un formulario de diálogo.
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Borde fijo para diálogos
            this.StartPosition = FormStartPosition.CenterParent; // Centrar respecto al padre

            // Asignar eventos a los botones
            ibtn_Modify.Click += ibtn_Modify_Click;
            ibtn_Clear.Click += ibtn_Clear_Click;
            ibtn_Cancel.Click += ibtn_Cancel_Click;

            // Inicializar ComboBox de Categoría (placeholder)
            cbx_Category.Items.Add("-- Seleccione --");
            cbx_Category.Items.Add("FRUTAS");
            cbx_Category.Items.Add("VERDURAS Y HORTALIZAS");
            cbx_Category.Items.Add("TUBÉRCULOS Y RAÍCES");
            cbx_Category.SelectedIndex = 0;

            // Inicializar ComboBox de Unidad de Medida (placeholder)
            cbx_UdMedida.Items.Add("-- Seleccione --");
            cbx_UdMedida.Items.Add("KILOGRAMO");
            cbx_UdMedida.Items.Add("UNIDAD");
            cbx_UdMedida.Items.Add("ATADO");
            cbx_UdMedida.SelectedIndex = 0;

            // Configurar NumericUpDowns
            nud_Price.DecimalPlaces = 2; // Permitir dos decimales para el precio
            nud_Price.Minimum = 0;
            nud_Price.Maximum = 999999999; // Valor máximo alto
            nud_Stock.Minimum = 0;
            nud_Stock.Maximum = 99999; // Valor máximo de stock
        }

        // Constructor para recibir información del producto (opcional, si necesitas precargar campos).
        public Frm_ModifyProductAdmin_Vendor(int productId, string name, string description, decimal price, string unit, string category, int stock) : this()
        {
            ProductId = productId;
            tbx_Name.Text = name;
            tbx_NumDoc.Text = description; // Asumiendo tbx_NumDoc es el de descripción
            nud_Price.Value = price;
            nud_Stock.Value = stock;

            int unitIndex = cbx_UdMedida.FindStringExact(unit);
            if (unitIndex != -1) cbx_UdMedida.SelectedIndex = unitIndex;
            else cbx_UdMedida.SelectedIndex = 0;

            int categoryIndex = cbx_Category.FindStringExact(category);
            if (categoryIndex != -1) cbx_Category.SelectedIndex = categoryIndex;
            else cbx_Category.SelectedIndex = 0;
        }

        // Método para precargar la información del producto (si no se usa el constructor con parámetros).
        public void SetProductInfo(int productId, string name, string description, decimal price, string unit, string category, int stock)
        {
            ProductId = productId;
            tbx_Name.Text = name;
            tbx_NumDoc.Text = description; // Asumiendo tbx_NumDoc es el de descripción
            nud_Price.Value = price;
            nud_Stock.Value = stock;

            int unitIndex = cbx_UdMedida.FindStringExact(unit);
            if (unitIndex != -1) cbx_UdMedida.SelectedIndex = unitIndex;
            else cbx_UdMedida.SelectedIndex = 0;

            int categoryIndex = cbx_Category.FindStringExact(category);
            if (categoryIndex != -1) cbx_Category.SelectedIndex = categoryIndex;
            else cbx_Category.SelectedIndex = 0;
        }

        // Método para limpiar todos los campos del formulario
        private void ClearFormFields()
        {
            tbx_Name.Clear();
            tbx_NumDoc.Clear(); // Descripción
            nud_Price.Value = 0;
            nud_Stock.Value = 0;
            cbx_Category.SelectedIndex = 0;
            cbx_UdMedida.SelectedIndex = 0;
        }

        // Evento Click del botón "Guardar cambios" (placeholder para la lógica de modificar producto)
        private void ibtn_Modify_Click(object sender, EventArgs e)
        {
            // --- Lógica placeholder para modificar un producto existente ---
            string name = tbx_Name.Text;
            string description = tbx_NumDoc.Text; // Descripción
            decimal price = nud_Price.Value;
            int stock = (int)nud_Stock.Value;
            string category = cbx_Category.SelectedIndex > 0 ? cbx_Category.SelectedItem.ToString() : string.Empty;
            string unit = cbx_UdMedida.SelectedIndex > 0 ? cbx_UdMedida.SelectedItem.ToString() : string.Empty;

            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description) ||
                cbx_Category.SelectedIndex == 0 || cbx_UdMedida.SelectedIndex == 0 ||
                price <= 0)
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios y asegure que el precio sea mayor a 0.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Aquí se llamaría a la capa BLL para modificar el producto.
            // Ejemplo: BLL.ProductManager.UpdateProduct(ProductId, name, description, price, unit, category, stock);

            MessageBox.Show($"Lógica para modificar producto ID: {ProductId}:\nNombre: {name}\nPrecio: {price}\nStock: {stock}", "Modificar Producto (Placeholder)", MessageBoxButtons.OK, MessageBoxIcon.Information);

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