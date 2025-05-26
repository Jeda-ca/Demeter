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
    public partial class Frm_ModifyClient : Form
    {
        public Frm_ModifyClient()
        {
            InitializeComponent();
            // Asignar eventos a los botones
            ibtn_Clear.Click += ibtn_Clear_Click;
            ibtn_Modify.Click += ibtn_Modify_Click;
            ibtn_Cancel.Click += ibtn_Cancel_Click;

            // Inicializar ComboBox de Tipo de Documento (placeholder)
            cbx_TypeDoc.Items.Add("-- Seleccione --"); // [cite: 18, 19]
            cbx_TypeDoc.Items.Add("Cédula de Ciudadanía"); // [cite: 18, 19]
            cbx_TypeDoc.Items.Add("NIT"); // [cite: 18, 19]
            cbx_TypeDoc.Items.Add("Cédula de Extranjería"); // [cite: 18, 19]
            cbx_TypeDoc.Items.Add("Pasaporte"); // [cite: 18, 19]
            cbx_TypeDoc.SelectedIndex = 0; // Seleccionar la opción por defecto [cite: 18, 19]
        }

        // Método para limpiar todos los TextBox y ComboBox del formulario
        private void ClearFormFields()
        {
            tbx_Name.Clear();
            tbx_LastName.Clear();
            cbx_TypeDoc.SelectedIndex = 0; // Vuelve a la opción por defecto
            tbx_NumDoc.Clear();
            tbx_Cellphone.Clear();
            tbx_Email.Clear(); // Campo específico de cliente
        }

        // Evento Click del botón "Limpiar"
        private void ibtn_Clear_Click(object sender, EventArgs e)
        {
            ClearFormFields();
        }

        // Evento Click del botón "Modificar" (placeholder para la lógica de modificar cliente)
        private void ibtn_Modify_Click(object sender, EventArgs e)
        {
            // --- Lógica placeholder para modificar un cliente existente ---
            // Aquí deberías recopilar los datos de los campos de texto y combobox.
            string nombre = tbx_Name.Text;
            string apellido = tbx_LastName.Text;
            string tipoDoc = cbx_TypeDoc.SelectedIndex > 0 ? cbx_TypeDoc.SelectedItem.ToString() : string.Empty;
            string numDoc = tbx_NumDoc.Text;
            string telefono = tbx_Cellphone.Text;
            string email = tbx_Email.Text;

            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) || cbx_TypeDoc.SelectedIndex == 0 || string.IsNullOrWhiteSpace(numDoc) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Aquí se llamaría a la capa BLL para modificar el cliente en la base de datos.
            // Ejemplo: BLL.ClienteManager.UpdateCliente(idCliente, nombre, apellido, tipoDoc, numDoc, telefono, email);

            MessageBox.Show($"Lógica para modificar cliente:\nNombre: {nombre}\nApellido: {apellido}\nTipo Doc: {tipoDoc}\nNum Doc: {numDoc}\nTeléfono: {telefono}\nEmail: {email}", "Modificar Cliente (Placeholder)", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Después de modificar con éxito, podrías cerrar el formulario:
            // this.DialogResult = DialogResult.OK; // Indica éxito al formulario padre
            this.Close();
        }

        // Evento Click del botón "Cancelar"
        private void ibtn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario sin realizar ninguna acción de guardado
        }
    }
}