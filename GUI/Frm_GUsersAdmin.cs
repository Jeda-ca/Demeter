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
    public partial class Frm_GUsersAdmin : Form
    {
        public Frm_GUsersAdmin()
        {
            InitializeComponent();
            // Configuración esencial para que este formulario pueda ser incrustado como un control.
            this.TopLevel = false; // Indica que no es una ventana de nivel superior independiente.
            this.FormBorderStyle = FormBorderStyle.None; // Elimina el borde y la barra de título.
            this.Dock = DockStyle.Fill; // Hace que el formulario llene el control contenedor.

            // Inicializar ComboBox de búsqueda (placeholder)
            cbx_Buscar.Items.Add("-- Seleccione --");
            cbx_Buscar.Items.Add("Nombre completo");
            cbx_Buscar.Items.Add("Usuario");
            cbx_Buscar.Items.Add("Rol");
            cbx_Buscar.SelectedIndex = 0;
        }

        // Evento Load del formulario.
        private void Frm_GUsersAdmin_Load(object sender, EventArgs e)
        {
            // Lógica para cargar datos de usuarios en el DataGridView.
            LoadUsersData();
        }

        // Método placeholder para cargar/recargar datos de usuarios.
        private void LoadUsersData()
        {
            // --- Lógica para cargar datos de usuarios desde la capa BLL y llenar el DataGridView. ---
            // Por ahora, el DataGridView estará vacío o con columnas definidas.
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Nombre completo", typeof(string));
            dt.Columns.Add("Usuario", typeof(string));
            dt.Columns.Add("Rol", typeof(string));
            // No se añaden filas de datos de prueba.
            // Para probar:
            // dt.Rows.Add(1, "Admin Demeter", "admin_demeter", "Admin"); // DATOS DE PRUEBA
            // dt.Rows.Add(2, "Carlos Vargas", "cvargas_vende", "Vendedor"); // DATOS DE PRUEBA

            dgv_ListaUsuarios.DataSource = dt; // Asignar el DataTable al DataGridView
        }

        // Evento Click del botón "Buscar" (placeholder para la lógica de búsqueda)
        private void ibtn_Buscar_Click(object sender, EventArgs e)
        {
            // --- Lógica para buscar usuarios basada en el texto y el criterio de búsqueda. ---
            string searchText = tbx_Busqueda.Text;
            string searchCriteria = cbx_Buscar.SelectedItem?.ToString(); // Asumiendo que cbx_Buscar existe y tiene opciones

            if (cbx_Buscar.SelectedIndex == 0 || string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show("Por favor, seleccione un criterio de búsqueda y/o ingrese un texto.", "Búsqueda incompleta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadUsersData(); // Recargar todos los usuarios si la búsqueda es inválida o vacía.
                return;
            }

            MessageBox.Show($"Lógica de búsqueda para '{searchText}' por '{searchCriteria}'.", "Buscar Usuario (Placeholder)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Aquí llamarías a la capa BLL para filtrar los datos y actualizar el DataGridView.
            // Ejemplo: dgv_ListaUsuarios.DataSource = BLL.UserManager.SearchUsers(searchText, searchCriteria);
        }

        // Evento Click del botón "Realizar cambio" (ibtn_Cambio) para guardar credenciales.
        private void ibtn_Cambio_Click(object sender, EventArgs e)
        {
            // Lógica para obtener el usuario seleccionado del DataGridView
            if (dgv_ListaUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un usuario para modificar sus credenciales.", "Usuario no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Aquí se obtendría el ID del usuario seleccionado
            // int userId = (int)dgv_ListaUsuarios.SelectedRows[0].Cells["ID"].Value;

            string newUsername = tbx_NameUser.Text; // Asumiendo tbx_NameUser es el TextBox para el nuevo nombre de usuario
            string newPassword = tbx_PassUser.Text; // Asumiendo tbx_PassUser es el TextBox para la nueva contraseña

            // Validaciones básicas (pueden ser más robustas)
            if (string.IsNullOrWhiteSpace(newUsername) || string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("Por favor, ingrese el nuevo nombre de usuario y contraseña.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- Lógica placeholder para guardar los cambios de credenciales en la base de datos ---
            // Aquí se llamaría a la capa BLL para actualizar las credenciales del usuario.
            // Ejemplo: BLL.UserManager.UpdateUserCredentials(userId, newUsername, newPassword);

            MessageBox.Show($"Lógica para guardar cambios de credenciales para el usuario: '{newUsername}'.", "Guardar Credenciales (Placeholder)", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Opcional: Limpiar los campos después de guardar
            tbx_NameUser.Clear();
            tbx_PassUser.Clear();
            LoadUsersData(); // Recargar la lista de usuarios para reflejar los cambios
        }
    }
}