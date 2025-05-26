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
    public partial class Frm_BusqProduct : Form
    {
        // Propiedades para devolver el producto seleccionado
        public int SelectedProductId { get; private set; }
        public string SelectedProductName { get; private set; }
        public decimal SelectedProductPrice { get; private set; }
        public int SelectedProductStock { get; private set; } // Opcional: si necesitas el stock

        public Frm_BusqProduct()
        {
            InitializeComponent();
            // Configuración por defecto para un formulario de diálogo.
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Borde fijo para diálogos
            this.StartPosition = FormStartPosition.CenterParent; // Centrar respecto al padre

            dgv_Product.CellDoubleClick += dgv_Product_CellDoubleClick; // Para seleccionar con doble clic

            // Inicializar ComboBox de búsqueda
            cbx_Busq.Items.Add("-- Seleccione --");
            cbx_Busq.Items.Add("Nombre");
            cbx_Busq.Items.Add("Categoría");
            cbx_Busq.Items.Add("Stock Bajo"); // Opcional: si quieres buscar productos con bajo stock
            cbx_Busq.SelectedIndex = 0;

            LoadProductsData(); // Cargar datos iniciales al abrir el formulario
        }

        // Método placeholder para cargar/recargar datos de productos.
        private void LoadProductsData()
        {
            // --- Lógica para cargar datos de productos desde la capa BLL y llenar el DataGridView. ---
            // Por ahora, el DataGridView estará vacío o con columnas definidas.
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Precio", typeof(decimal));
            dt.Columns.Add("Stock", typeof(int));
            dt.Columns.Add("Categoría", typeof(string));
            // No se añaden filas de datos de prueba.
            // Para probar:
            // dt.Rows.Add(1, "Manzana", 2500.00m, 50, "FRUTAS"); // DATOS DE PRUEBA
            // dt.Rows.Add(2, "Lechuga", 1200.00m, 15, "VERDURAS"); // DATOS DE PRUEBA

            dgv_Product.DataSource = dt; // Asignar el DataTable al DataGridView
        }

        // Evento Click del botón "Buscar".
        private void ibtn_Buscar_Click(object sender, EventArgs e)
        {
            // --- Lógica para buscar productos basada en el texto y el criterio de búsqueda. ---
            string searchText = tbx_Busq.Text;
            string searchCriteria = cbx_Busq.SelectedItem?.ToString();

            if (cbx_Busq.SelectedIndex == 0 || (searchCriteria != "Stock Bajo" && string.IsNullOrWhiteSpace(searchText)))
            {
                MessageBox.Show("Por favor, seleccione un criterio de búsqueda y/o ingrese un texto (a menos que sea 'Stock Bajo').", "Búsqueda incompleta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadProductsData(); // Recargar todos los productos si la búsqueda es inválida o vacía.
                return;
            }

            MessageBox.Show($"Lógica de búsqueda para '{searchText}' por '{searchCriteria}'.", "Buscar Producto (Placeholder)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Aquí llamarías a la capa BLL para filtrar los datos y actualizar el DataGridView.
            // Ejemplo: dgv_Product.DataSource = BLL.ProductManager.SearchProducts(searchText, searchCriteria);
        }

        // Evento Click del botón "Limpiar".
        private void ibtn_Clear_Click(object sender, EventArgs e)
        {
            tbx_Busq.Clear();
            cbx_Busq.SelectedIndex = 0;
            LoadProductsData(); // Recargar todos los productos al limpiar la búsqueda.
            MessageBox.Show("Campos de búsqueda limpiados.", "Limpiar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Evento Click del botón "OK" para seleccionar el producto.
        private void ibtn_OK_Click(object sender, EventArgs e)
        {
            SelectProductAndClose();
        }

        // Evento DoubleClick en una celda del DataGridView para seleccionar el producto.
        private void dgv_Product_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Asegurarse de que no sea el encabezado
            {
                SelectProductAndClose();
            }
        }

        // Método auxiliar para seleccionar el producto y cerrar el formulario.
        private void SelectProductAndClose()
        {
            if (dgv_Product.SelectedRows.Count > 0)
            {
                // --- Lógica para obtener los datos del producto de la fila seleccionada ---
                // Ejemplo:
                // SelectedProductId = (int)dgv_Product.SelectedRows[0].Cells["ID"].Value;
                // SelectedProductName = dgv_Product.SelectedRows[0].Cells["Nombre"].Value.ToString();
                // SelectedProductPrice = (decimal)dgv_Product.SelectedRows[0].Cells["Precio"].Value;
                // SelectedProductStock = (int)dgv_Product.SelectedRows[0].Cells["Stock"].Value;

                MessageBox.Show("Producto seleccionado con éxito (Placeholder).", "Selección Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Indica que se seleccionó un producto
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un producto de la lista.", "No hay selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}