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
    public partial class Frm_GVendorsAdmin : Form
    {
        public Frm_GVendorsAdmin()
        {
            InitializeComponent();
            // Configuración esencial para que este formulario pueda ser incrustado como un control.
            this.TopLevel = false; // Indica que no es una ventana de nivel superior independiente.
            this.FormBorderStyle = FormBorderStyle.None; // Elimina el borde y la barra de título.
            this.Dock = DockStyle.Fill; // Hace que el formulario llene el control contenedor.

            // Asignar eventos a los botones
            ibtn_Add.Click += ibtn_Add_Click;
            ibtn_Modify.Click += ibtn_Modify_Click;
            ibtn_Delete.Click += ibtn_Delete_Click;
            ibtn_Buscar.Click += ibtn_Buscar_Click; // Asignar evento al botón buscar

            // Inicializar ComboBox de búsqueda (placeholder)
            cbx_Buscar.Items.Add("-- Seleccione --");
            cbx_Buscar.Items.Add("Nombre");
            cbx_Buscar.Items.Add("Apellido");
            cbx_Buscar.Items.Add("Número de Documento");
            cbx_Buscar.SelectedIndex = 0;
        }

        // Evento Load del formulario.
        private void Frm_GVendedoresAdmin_Load(object sender, EventArgs e)
        {
            // Lógica para cargar datos de vendedores en el DataGridView.
            LoadVendorsData();
        }

        // Método placeholder para cargar/recargar datos de vendedores.
        private void LoadVendorsData()
        {
            // --- Lógica para cargar datos de vendedores desde la capa BLL y llenar el DataGridView. ---
            // Por ahora, el DataGridView estará vacío o con columnas definidas.
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Apellido", typeof(string));
            dt.Columns.Add("Documento", typeof(string));
            dt.Columns.Add("Teléfono", typeof(string));
            // No se añaden filas de datos de prueba, solo las columnas.
            // Para probar:
            // dt.Rows.Add(1, "Juan", "Pérez", "123456789", "3001112233"); // [cite: 18, 19]
            // dt.Rows.Add(2, "María", "Gómez", "987654321", "3104445566"); // [cite: 18, 19]

            dgv_ListaVendedores.DataSource = dt; // Asignar el DataTable al DataGridView
        }

        // Evento Click del botón "Agregar" para abrir Frm_Add
        private void ibtn_Add_Click(object sender, EventArgs e)
        {
            Frm_Add frmAdd = new Frm_Add();
            DialogResult result = frmAdd.ShowDialog(); // Abre el formulario Frm_Add como un diálogo modal

            // Si el formulario Frm_Add se cerró con DialogResult.OK (indicando que se agregó algo)
            // if (result == DialogResult.OK)
            // {
            //    LoadVendorsData(); // Recargar la lista de vendedores si es necesario.
            // }
        }

        // Evento Click del botón "Modificar" para abrir Frm_ModifyV
        private void ibtn_Modify_Click(object sender, EventArgs e)
        {
            // Lógica para verificar si hay un vendedor seleccionado en el DataGridView
            if (dgv_ListaVendedores.SelectedRows.Count > 0)
            {
                // --- Lógica para pasar la información del vendedor seleccionado a Frm_ModifyV ---
                // Ejemplo:
                // int vendedorId = (int)dgv_ListaVendedores.SelectedRows[0].Cells["ID"].Value;
                // string nombre = dgv_ListaVendedores.SelectedRows[0].Cells["Nombre"].Value.ToString();
                // ... y pasar todos los datos necesarios al constructor de Frm_ModifyV

                Frm_ModifyV frmModifyV = new Frm_ModifyV(); // Si necesitas pasar datos, modifica el constructor de Frm_ModifyV
                DialogResult result = frmModifyV.ShowDialog(); // Abre el formulario Frm_ModifyV como un diálogo modal

                // Si el formulario Frm_ModifyV se cerró con DialogResult.OK
                // if (result == DialogResult.OK)
                // {
                //     LoadVendorsData(); // Recargar la lista de vendedores si es necesario.
                // }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un vendedor para modificar.", "Modificar Vendedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Evento Click del botón "Eliminar" (placeholder para la lógica de eliminar vendedor)
        private void ibtn_Delete_Click(object sender, EventArgs e)
        {
            if (dgv_ListaVendedores.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar el vendedor seleccionado?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    // --- Lógica placeholder para eliminar el vendedor seleccionado ---
                    // Ejemplo:
                    // int vendedorId = (int)dgv_ListaVendedores.SelectedRows[0].Cells["ID"].Value;
                    // BLL.VendedorManager.DeleteVendedor(vendedorId); // Llamada a la capa BLL

                    MessageBox.Show("Vendedor eliminado con éxito (Placeholder).", "Eliminar Vendedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Después de eliminar, podrías recargar la lista de vendedores:
                    // LoadVendorsData();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un vendedor para eliminar.", "Eliminar Vendedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Evento Click del botón "Buscar" (placeholder para la lógica de búsqueda)
        private void ibtn_Buscar_Click(object sender, EventArgs e)
        {
            // --- Lógica para buscar vendedores basada en el texto y el criterio de búsqueda. ---
            string searchText = tbx_Busqueda.Text;
            string searchCriteria = cbx_Buscar.SelectedItem?.ToString(); // Asumiendo que cbx_Buscar existe y tiene opciones

            if (cbx_Buscar.SelectedIndex == 0 || string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show("Por favor, seleccione un criterio de búsqueda y/o ingrese un texto.", "Búsqueda incompleta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadVendorsData(); // Recargar todos los vendedores si la búsqueda es inválida o vacía.
                return;
            }

            MessageBox.Show($"Lógica de búsqueda para '{searchText}' por '{searchCriteria}'.", "Buscar Vendedor (Placeholder)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Aquí llamarías a la capa BLL para filtrar los datos y actualizar el DataGridView.
            // Ejemplo: dgv_ListaVendedores.DataSource = BLL.VendedorManager.SearchVendors(searchText, searchCriteria);
        }
    }
}


//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace GUI
//{
//    // Frm_GVendedoresAdmin: Formulario para la gestión de vendedores.
//    // Está diseñado para ser incrustado dentro de otro formulario (Frm_MainAdmin).
//    public partial class Frm_GVendorsAdmin : Form
//    {
//        public Frm_GVendorsAdmin()
//        {
//            InitializeComponent();
//            // Configuración esencial para que este formulario pueda ser incrustado como un control.
//            this.TopLevel = false; // Indica que no es una ventana de nivel superior independiente.
//            this.FormBorderStyle = FormBorderStyle.None; // Elimina el borde y la barra de título.
//            this.Dock = DockStyle.Fill; // Hace que el formulario llene el control contenedor.

//        }

//        // Evento Load del formulario (sin lógica de carga de datos por ahora, según tu solicitud).
//        private void Frm_GVendedoresAdmin_Load(object sender, EventArgs e)
//        {
//            // Lógica para cargar datos de vendedores en el DataGridView, etc.
//            // Por ahora, solo es un placeholder.
//        }

//        // Evento Click del botón "Agregar" para abrir Frm_Add
//        private void ibtn_Add_Click(object sender, EventArgs e)
//        {
//            Frm_Add frmAdd = new Frm_Add();
//            frmAdd.ShowDialog(); // Abre el formulario Frm_Add como un diálogo modal
//            // Después de que Frm_Add se cierre, podrías recargar la lista de vendedores si es necesario.
//            // LoadVendorsData(); // Método placeholder para recargar datos
//        }

//        // Evento Click del botón "Modificar" para abrir Frm_ModifyV
//        private void ibtn_Modify_Click(object sender, EventArgs e)
//        {
//            // Lógica para verificar si hay un vendedor seleccionado en el DataGridView
//            if (dgv_ListaVendedores.SelectedRows.Count > 0)
//            {
//                // Aquí podrías pasar la información del vendedor seleccionado a Frm_ModifyV
//                // Ejemplo: int vendedorId = (int)dgv_ListaVendedores.SelectedRows[0].Cells["ID"].Value;
//                Frm_ModifyV frmModifyV = new Frm_ModifyV();
//                frmModifyV.ShowDialog(); // Abre el formulario Frm_ModifyV como un diálogo modal
//                // Después de que Frm_ModifyV se cierre, podrías recargar la lista de vendedores si es necesario.
//                // LoadVendorsData(); // Método placeholder para recargar datos
//            }
//            else
//            {
//                MessageBox.Show("Por favor, seleccione un vendedor para modificar.", "Modificar Vendedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            }
//        }

//        // Evento Click del botón "Eliminar" (placeholder para la lógica de eliminar vendedor)
//        private void ibtn_Delete_Click(object sender, EventArgs e)
//        {
//            if (dgv_ListaVendedores.SelectedRows.Count > 0)
//            {
//                DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar el vendedor seleccionado?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
//                if (result == DialogResult.Yes)
//                {
//                    // Lógica placeholder para eliminar el vendedor seleccionado
//                    MessageBox.Show("Lógica para eliminar el vendedor aquí.", "Eliminar Vendedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    // Después de eliminar, podrías recargar la lista de vendedores:
//                    // LoadVendorsData(); // Método placeholder para recargar datos
//                }
//            }
//            else
//            {
//                MessageBox.Show("Por favor, seleccione un vendedor para eliminar.", "Eliminar Vendedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            }
//        }

//        // Método placeholder para cargar/recargar datos de vendedores (si se necesita en el futuro)
//        private void LoadVendorsData()
//        {
//            // Lógica para cargar datos de vendedores desde la capa BLL y llenar el DataGridView.
//            // Por ahora, solo es un placeholder.
//            MessageBox.Show("Cargando datos de vendedores...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
//        }
//    }
//}
