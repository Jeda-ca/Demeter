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
    public partial class Frm_GProductsVendor : Form
    {
        public Frm_GProductsVendor()
        {
            InitializeComponent();
            // Configuración esencial para que este formulario pueda ser incrustado como un control.
            this.TopLevel = false; // Indica que no es una ventana de nivel superior independiente.
            this.FormBorderStyle = FormBorderStyle.None; // Elimina el borde y la barra de título.
            this.Dock = DockStyle.Fill; // Hace que el formulario llene el control contenedor.

            // Inicializar ComboBox de filtro (placeholder)
            cbx_FiltroV.Items.Add("-- Seleccione --");
            cbx_FiltroV.Items.Add("Nombre");
            cbx_FiltroV.Items.Add("Categoría");
            cbx_FiltroV.Items.Add("Stock Bajo");
            cbx_FiltroV.SelectedIndex = 0;
        }

        // Evento Load del formulario.
        private void Frm_GProductsVendor_Load(object sender, EventArgs e)
        {
            LoadProductsData(); // Carga los datos iniciales al cargar el formulario.
        }

        // Método placeholder para cargar/recargar datos de productos.
        private void LoadProductsData()
        {
            // --- Lógica para cargar datos de productos desde la capa BLL y llenar el DataGridView. ---
            // Por ahora, el DataGridView estará vacío o con columnas definidas.
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Categoría", typeof(string));
            dt.Columns.Add("Precio", typeof(decimal));
            dt.Columns.Add("Stock", typeof(int));
            // No se añaden filas de datos de prueba.
            // Para probar:
            // dt.Rows.Add(1, "Manzana", "FRUTAS", 2500.00m, 50); // DATOS DE PRUEBA
            // dt.Rows.Add(2, "Lechuga", "VERDURAS", 1200.00m, 15); // DATOS DE PRUEBA

            dgv_ListaCategorías.DataSource = dt; // Asignar el DataTable al DataGridView
        }

        // Evento Click del botón "Agregar" para abrir Frm_AddProductVendor
        private void ibtn_Add_Click(object sender, EventArgs e)
        {
            // Lógica para abrir un formulario de agregar producto.
            Frm_AddProductVendor frmAddProduct = new Frm_AddProductVendor();
            DialogResult result = frmAddProduct.ShowDialog(); // Abre el formulario como un diálogo modal

            // Si el formulario se cerró con DialogResult.OK (indicando que se agregó algo)
            // if (result == DialogResult.OK)
            // {
            //    LoadProductsData(); // Recargar la lista de productos si es necesario.
            // }
        }

        // Evento Click del botón "Modificar" para abrir Frm_ModifyProductAdmin_Vendor
        private void ibtn_Modify_Click(object sender, EventArgs e)
        {
            // Lógica para verificar si hay un producto seleccionado y abrir el formulario de modificación.
            if (dgv_ListaCategorías.SelectedRows.Count > 0)
            {
                // --- Lógica para pasar la información del producto seleccionado a Frm_ModifyProductAdmin_Vendor ---
                // Ejemplo:
                // int productId = (int)dgv_ListaCategorías.SelectedRows[0].Cells["ID"].Value;
                // string productName = dgv_ListaCategorías.SelectedRows[0].Cells["Nombre"].Value.ToString();
                // string productDescription = dgv_ListaCategorías.SelectedRows[0].Cells["Descripción"].Value.ToString(); // Asumiendo que esta columna existe
                // decimal productPrice = (decimal)dgv_ListaCategorías.SelectedRows[0].Cells["Precio"].Value;
                // string productUnit = dgv_ListaCategorías.SelectedRows[0].Cells["Unidad Medida"].Value.ToString(); // Asumiendo que esta columna existe
                // string productCategory = dgv_ListaCategorías.SelectedRows[0].Cells["Categoría"].Value.ToString();
                // int productStock = (int)dgv_ListaCategorías.SelectedRows[0].Cells["Stock"].Value;

                // Frm_ModifyProductAdmin_Vendor frmModifyProduct = new Frm_ModifyProductAdmin_Vendor(productId, productName, productDescription, productPrice, productUnit, productCategory, productStock);
                Frm_ModifyProductAdmin_Vendor frmModifyProduct = new Frm_ModifyProductAdmin_Vendor(); // Si no pasas datos en el constructor, usa el método SetProductInfo
                // frmModifyProduct.SetProductInfo(productId, productName, productDescription, productPrice, productUnit, productCategory, productStock); // Si necesitas pasar datos
                DialogResult result = frmModifyProduct.ShowDialog();

                // Si el formulario se cerró con DialogResult.OK
                // if (result == DialogResult.OK)
                // {
                //     LoadProductsData(); // Recargar la lista de productos si es necesario.
                // }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un producto para modificar.", "Modificar Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Evento Click del botón "Buscar" (placeholder para la lógica de búsqueda)
        private void ibtn_Buscar_Click(object sender, EventArgs e)
        {
            // --- Lógica para buscar productos basada en el texto y el criterio de búsqueda. ---
            string searchText = tbx_Busqueda.Text;
            string searchCriteria = cbx_FiltroV.SelectedItem?.ToString();

            if (cbx_FiltroV.SelectedIndex == 0 || (searchCriteria != "Stock Bajo" && string.IsNullOrWhiteSpace(searchText)))
            {
                MessageBox.Show("Por favor, seleccione un criterio de búsqueda y/o ingrese un texto (a menos que sea 'Stock Bajo').", "Búsqueda incompleta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadProductsData(); // Recargar todos los productos si la búsqueda es inválida o vacía.
                return;
            }

            MessageBox.Show($"Lógica de búsqueda para '{searchText}' por '{searchCriteria}'.", "Buscar Producto (Placeholder)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Aquí llamarías a la capa BLL para filtrar los datos y actualizar el DataGridView.
            // Ejemplo: dgv_ListaCategorías.DataSource = BLL.ProductManager.SearchProducts(searchText, searchCriteria);
        }

        // Evento Click del botón "Limpiar"
        private void ibtn_Clear_Click(object sender, EventArgs e)
        {
            tbx_Busqueda.Clear();
            cbx_FiltroV.SelectedIndex = 0;
            LoadProductsData(); // Recargar todos los productos al limpiar la búsqueda.
            MessageBox.Show("Campos de búsqueda limpiados.", "Limpiar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}