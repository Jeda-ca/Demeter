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
    public partial class Frm_GProductsAdmin : Form
    {
        public Frm_GProductsAdmin()
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
            cbx_FiltroV.Items.Add("Vendedor");
            cbx_FiltroV.Items.Add("Stock Bajo");
            cbx_FiltroV.SelectedIndex = 0;
        }

        // Evento Load del formulario.
        private void Frm_GProductsAdmin_Load(object sender, EventArgs e)
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
            dt.Columns.Add("Descripción", typeof(string));
            dt.Columns.Add("Precio", typeof(decimal));
            dt.Columns.Add("Unidad Medida", typeof(string));
            dt.Columns.Add("Categoría", typeof(string));
            dt.Columns.Add("Stock", typeof(int));
            dt.Columns.Add("Vendedor", typeof(string));
            // No se añaden filas de datos de prueba.
            // Para probar:
            // dt.Rows.Add(1, "Manzana", "Roja y dulce", 2500.00m, "UNIDAD", "FRUTAS", 50, "Vendedor 1"); // DATOS DE PRUEBA
            // dt.Rows.Add(2, "Lechuga", "Fresca y orgánica", 1200.00m, "UNIDAD", "VERDURAS", 15, "Vendedor 2"); // DATOS DE PRUEBA

            dgv_ListaCategorías.DataSource = dt; // Asignar el DataTable al DataGridView
        }

        // Evento Click del botón "Modificar información" para abrir Frm_ModifyProductAdmin_Vendor
        private void ibtn_ModifyInfo_Click(object sender, EventArgs e)
        {
            if (dgv_ListaCategorías.SelectedRows.Count > 0)
            {
                // --- Lógica para pasar la información del producto seleccionado a Frm_ModifyProductAdmin_Vendor ---
                // Ejemplo:
                // int productId = (int)dgv_ListaCategorías.SelectedRows[0].Cells["ID"].Value;
                // string productName = dgv_ListaCategorías.SelectedRows[0].Cells["Nombre"].Value.ToString();
                // ... y pasar todos los datos necesarios al constructor de Frm_ModifyProductAdmin_Vendor

                Frm_ModifyProductAdmin_Vendor frmModifyProduct = new Frm_ModifyProductAdmin_Vendor();
                // frmModifyProduct.SetProductInfo(productId, productName, ...); // Si necesitas pasar datos
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

        // Evento Click del botón "Eliminar" (placeholder para la lógica de eliminar producto)
        private void ibtn_Delete_Click(object sender, EventArgs e)
        {
            if (dgv_ListaCategorías.SelectedRows.Count > 0)
            {
                DialogResult confirmResult = MessageBox.Show("¿Está seguro que desea eliminar el producto seleccionado?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    // --- Lógica placeholder para eliminar el producto seleccionado ---
                    // Ejemplo: int productId = (int)dgv_ListaCategorías.SelectedRows[0].Cells["ID"].Value;
                    // BLL.ProductManager.DeleteProduct(productId);

                    MessageBox.Show("Producto eliminado con éxito (Placeholder).", "Producto Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProductsData(); // Recargar los datos después de la eliminación
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un producto para eliminar.", "Eliminar Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
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