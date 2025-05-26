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
    public partial class Frm_AddVendorAdmin : Form
    {
        public Frm_AddVendorAdmin()
        {
            InitializeComponent();

            // Inicializar ComboBox de Tipo de Documento (placeholder)
            //cbx_TypeDoc.Items.Add("-- Seleccione --");
            cbx_TypeDoc.SelectedIndex = 0; // Seleccionar la opción por defecto
        }

        // EVENTOS
        private void ibtn_Add_Click(object sender, EventArgs e) // Evento Click del botón "Agregar" (placeholder para la lógica de agregar)
        {
            AddNewVendor();
        }
        private void ibtn_Clear_Click(object sender, EventArgs e) // Evento Click del botón "Limpiar"
        {
            ClearFormFields();
        }
        private void ibtn_Cancel_Click(object sender, EventArgs e) // Evento Click del botón "Cancelar"
        {
            this.Close(); // Cierra el formulario sin realizar ninguna acción de guardado
        }

        // MÉTODOS PRIVADOS
        private void AddNewVendor() //Placehlder para agregar un nuevo vendedor
        {
            // --- Lógica placeholder para agregar un nuevo registro (Vendedor, Cliente, etc.) ---
            // Aquí deberías recopilar los datos de los campos de texto y combobox.
            string nombre = tbx_Name.Text;
            string apellido = tbx_LastName.Text;
            string tipoDoc = cbx_TypeDoc.SelectedIndex > 0 ? cbx_TypeDoc.SelectedItem.ToString() : string.Empty;
            string numDoc = tbx_NumDoc.Text;
            string telefono = tbx_Cellphone.Text;
            string nomUsuario = tbx_Username.Text;
            string contrasena = tbx_Password.Text;
            // string email = ""; // Si Frm_Add fuera también para clientes y tuviera tbx_Email

            // Validaciones básicas (pueden ser más robustas)
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) || cbx_TypeDoc.SelectedIndex == 0 || string.IsNullOrWhiteSpace(numDoc) || string.IsNullOrWhiteSpace(nomUsuario) || string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Aquí se llamaría a la capa BLL para guardar el nuevo registro en la base de datos.
            // Ejemplo: BLL.PersonaManager.AddPersona(nombre, apellido, tipoDoc, numDoc, telefono);
            // Si es un vendedor: BLL.VendedorManager.AddVendedor(personaId, ...);
            // Si es un cliente: BLL.ClienteManager.AddCliente(personaId, email, ...);

            MessageBox.Show($"Lógica para agregar nuevo registro:\nNombre: {nombre}\nApellido: {apellido}\nTipo Doc: {tipoDoc}\nNum Doc: {numDoc}\nTeléfono: {telefono}", "Agregar (Placeholder)", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Después de agregar con éxito, podrías cerrar el formulario o limpiar los campos:
            // this.DialogResult = DialogResult.OK; // Indica éxito al formulario padre

            this.Close(); // Cierra el formulario actual (después de agregar el registro)
            // ClearFormFields();
        }
        private void ClearFormFields() // Método para limpiar todos los TextBox y ComboBox del formulario
        {
            tbx_Name.Clear();
            tbx_LastName.Clear();
            cbx_TypeDoc.SelectedIndex = 0; // Vuelve a la opción por defecto
            tbx_NumDoc.Clear();
            tbx_Cellphone.Clear();
            tbx_Username.Clear();
            tbx_Password.Clear();
            // Si este formulario se usa para clientes, también limpiar tbx_Email
            // if (this.Controls.ContainsKey("tbx_Email")) { tbx_Email.Clear(); } // Ejemplo de cómo manejar si el campo existe
        }
    }
}