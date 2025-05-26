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
    public partial class Frm_GCategoriesAdmin : Form
    {
        public Frm_GCategoriesAdmin()
        {
            InitializeComponent();
            // Configuración esencial para que este formulario pueda ser incrustado como un control.
            this.TopLevel = false; // Indica que no es una ventana de nivel superior independiente.
            this.FormBorderStyle = FormBorderStyle.None; // Elimina el borde y la barra de título.
            this.Dock = DockStyle.Fill; // Hace que el formulario llene el control contenedor.

            // Inicializar ComboBox de filtro (placeholder)
            cbx_FiltroV.Items.Add("-- Seleccione --");
            cbx_FiltroV.Items.Add("Nombre");
            cbx_FiltroV.SelectedIndex = 0;
        }

        // Evento Load del formulario.
        private void Frm_GCategoriesAdmin_Load(object sender, EventArgs e)
        {
            LoadCategoriesData(); // Carga los datos iniciales al cargar el formulario.
        }

        // Método placeholder para cargar/recargar datos de categorías.
        private void LoadCategoriesData()
        {
            // --- Lógica para cargar datos de categorías desde la capa BLL y llenar el DataGridView. ---
            // Por ahora, el DataGridView estará vacío o con columnas definidas.
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Nombre", typeof(string));
            // No se añaden filas de datos de prueba.
            // Para probar:
            // dt.Rows.Add(1, "FRUTAS"); // DATOS DE PRUEBA
            // dt.Rows.Add(2, "VERDURAS Y HORTALIZAS"); // DATOS DE PRUEBA

            dgv_ListaProductos.DataSource = dt; // Asignar el DataTable al DataGridView
        }

        // Evento Click del botón "Agregar" para abrir Frm_AddCategoryAdmin
        private void ibtn_Add_Click(object sender, EventArgs e)
        {
            Frm_AddCategoryAdmin frmAddCategory = new Frm_AddCategoryAdmin();
            DialogResult result = frmAddCategory.ShowDialog(); // Abre el formulario como un diálogo modal

            // Si el formulario se cerró con DialogResult.OK (indicando que se agregó algo)
            // if (result == DialogResult.OK)
            // {
            //    LoadCategoriesData(); // Recargar la lista de categorías si es necesario.
            // }
        }

        // Evento Click del botón "Modificar información" para abrir Frm_ModifyCategoryAdmin
        private void ibtn_ModifyInfo_Click(object sender, EventArgs e)
        {
            if (dgv_ListaProductos.SelectedRows.Count > 0)
            {
                // --- Lógica para pasar la información de la categoría seleccionada a Frm_ModifyCategoryAdmin ---
                // Ejemplo:
                // int categoryId = (int)dgv_ListaProductos.SelectedRows[0].Cells["ID"].Value;
                // string categoryName = dgv_ListaProductos.SelectedRows[0].Cells["Nombre"].Value.ToString();

                Frm_ModifyCategoryAdmin frmModifyCategory = new Frm_ModifyCategoryAdmin();
                // frmModifyCategory.SetCategoryInfo(categoryId, categoryName); // Si necesitas pasar datos
                DialogResult result = frmModifyCategory.ShowDialog();

                // Si el formulario se cerró con DialogResult.OK
                // if (result == DialogResult.OK)
                // {
                //     LoadCategoriesData(); // Recargar la lista de categorías si es necesario.
                // }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una categoría para modificar.", "Modificar Categoría", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Evento Click del botón "Eliminar" (placeholder para la lógica de eliminar categoría)
        private void ibtn_Delete_Click(object sender, EventArgs e)
        {
            if (dgv_ListaProductos.SelectedRows.Count > 0)
            {
                DialogResult confirmResult = MessageBox.Show("¿Está seguro que desea eliminar la categoría seleccionada?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    // --- Lógica placeholder para eliminar la categoría seleccionada ---
                    // Ejemplo: int categoryId = (int)dgv_ListaProductos.SelectedRows[0].Cells["ID"].Value;
                    // BLL.CategoryManager.DeleteCategory(categoryId);

                    MessageBox.Show("Categoría eliminada con éxito (Placeholder).", "Categoría Eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCategoriesData(); // Recargar los datos después de la eliminación
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una categoría para eliminar.", "Eliminar Categoría", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Evento Click del botón "Buscar" (placeholder para la lógica de búsqueda)
        private void ibtn_Buscar_Click(object sender, EventArgs e)
        {
            // --- Lógica para buscar categorías basada en el texto y el criterio de búsqueda. ---
            string searchText = tbx_Busqueda.Text;
            string searchCriteria = cbx_FiltroV.SelectedItem?.ToString();

            if (cbx_FiltroV.SelectedIndex == 0 || string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show("Por favor, seleccione un criterio de búsqueda y/o ingrese un texto.", "Búsqueda incompleta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadCategoriesData(); // Recargar todas las categorías si la búsqueda es inválida o vacía.
                return;
            }

            MessageBox.Show($"Lógica de búsqueda para '{searchText}' por '{searchCriteria}'.", "Buscar Categoría (Placeholder)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Aquí llamarías a la capa BLL para filtrar los datos y actualizar el DataGridView.
            // Ejemplo: dgv_ListaProductos.DataSource = BLL.CategoryManager.SearchCategories(searchText, searchCriteria);
        }

        // Evento Click del botón "Limpiar" (asumiendo iconButton1 es el de limpiar)
        private void ibtn_Clear_Click(object sender, EventArgs e)
        {
            tbx_Busqueda.Clear();
            cbx_FiltroV.SelectedIndex = 0;
            LoadCategoriesData(); // Recargar todas las categorías al limpiar la búsqueda.
            MessageBox.Show("Campos de búsqueda limpiados.", "Limpiar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}