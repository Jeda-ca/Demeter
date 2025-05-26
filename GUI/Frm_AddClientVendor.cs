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
    public partial class Frm_AddClientVendor : Form
    {
        public Frm_AddClientVendor()
        {
            InitializeComponent();
            // Configuración por defecto para un formulario de diálogo.
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Borde fijo para diálogos
            this.StartPosition = FormStartPosition.CenterParent; // Centrar respecto al padre

            // Inicializar ComboBox de Tipo de Documento (placeholder)
            cbx_TypeDoc.Items.Add("-- Seleccione --");
            cbx_TypeDoc.Items.Add("Cédula de Ciudadanía");
            cbx_TypeDoc.Items.Add("NIT");
            cbx_TypeDoc.Items.Add("Cédula de Extranjería");
            cbx_TypeDoc.Items.Add("Pasaporte");
            cbx_TypeDoc.SelectedIndex = 0; // Seleccionar la opción por defecto
        }

        // Método para limpiar todos los TextBox y ComboBox del formulario
        private void ClearFormFields()
        {
            tbx_Name.Clear();
            tbx_LastName.Clear();
            cbx_TypeDoc.SelectedIndex = 0; // Vuelve a la opción por defecto
            tbx_NumDoc.Clear();
            tbx_Cellphone.Clear();
            textBox1.Clear(); // Campo de Email (asumiendo textBox1 es el de email)
        }

        // Evento Click del botón "Agregar" (placeholder para la lógica de agregar cliente)
        private void ibtn_Add_Click(object sender, EventArgs e)
        {
            // --- Lógica placeholder para agregar un nuevo cliente ---
            // Recopilar datos de los campos
            string nombre = tbx_Name.Text;
            string apellido = tbx_LastName.Text;
            string tipoDoc = cbx_TypeDoc.SelectedIndex > 0 ? cbx_TypeDoc.SelectedItem.ToString() : string.Empty;
            string numDoc = tbx_NumDoc.Text;
            string telefono = tbx_Cellphone.Text;
            string email = textBox1.Text; // Asumiendo textBox1 es el de email

            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) ||
                cbx_TypeDoc.SelectedIndex == 0 || string.IsNullOrWhiteSpace(numDoc) ||
                string.IsNullOrWhiteSpace(telefono) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Aquí se llamaría a la capa BLL para registrar al nuevo cliente.
            // Ejemplo: BLL.ClientManager.AddClient(nombre, apellido, tipoDoc, numDoc, telefono, email, sellerId); // Necesitarías el sellerId del vendedor logueado

            MessageBox.Show($"Lógica para registrar nuevo cliente:\nNombre: {nombre} {apellido}\nDocumento: {numDoc}\nEmail: {email}", "Registrar Cliente (Placeholder)", MessageBoxButtons.OK, MessageBoxIcon.Information);

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