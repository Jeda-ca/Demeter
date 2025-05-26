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
    public partial class Frm_RegisterAdmin : Form
    {
        public Frm_RegisterAdmin()
        {
            InitializeComponent();
            
            // Inicializar ComboBox de Tipo de Documento (placeholder)
            comboBox1.Items.Add("-- Seleccione --");
            comboBox1.Items.Add("Cédula de Ciudadanía");
            comboBox1.Items.Add("NIT");
            comboBox1.Items.Add("Cédula de Extranjería");
            comboBox1.Items.Add("Pasaporte");
            comboBox1.SelectedIndex = 0; // Seleccionar la opción por defecto
        }

        // EVENTOS
        private void checkbx_showPassword_CheckedChanged(object sender, EventArgs e) // Evento para mostrar/ocultar la contraseña principal
        {
            tbx_Password.PasswordChar = checkbx_showPassword.Checked ? '\0' : '●';
        }

        private void checkbx2_showPassword_CheckedChanged(object sender, EventArgs e) // Evento para mostrar/ocultar la contraseña de confirmación
        {
            textBox1.PasswordChar = checkbx2_showPassword.Checked ? '\0' : '●'; // Asumiendo textBox1 es el de confirmar contraseña
        }

        private void ibtn_Minimized_LogIn_Click(object sender, EventArgs e) // Evento para minimizar la ventana
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ibtn_Exit_LogIn_Click(object sender, EventArgs e) // Evento para cerrar la aplicación
        {
            Application.Exit();
        }

        private void btn_Ingresar_Click(object sender, EventArgs e) // Evento para el botón "Registrar"
        {
            RegistrarAdministrador();
        }

        private void lbl_SignIn_Click(object sender, EventArgs e) // Evento para volver al formulario de Login
        {
            this.Close(); // Cierra el formulario de registro y vuelve al Login (manejado por AppContext)
        }

        // MÉTODOS PRIVADOS
        private void RegistrarAdministrador()
        {
            // --- Lógica placeholder para registrar un nuevo administrador ---
            // Recopilar datos de los campos
            string nombre = textBox2.Text; // Nombre
            string apellido = textBox3.Text; // Apellido
            string tipoDoc = comboBox1.SelectedIndex > 0 ? comboBox1.SelectedItem.ToString() : string.Empty; // Tipo de documento
            string numDoc = textBox4.Text; // Número de documento
            string telefono = textBox6.Text; // Teléfono
            string username = tbx_Username.Text; // Nombre de usuario
            string password = tbx_Password.Text; // Contraseña
            string confirmPassword = textBox1.Text; // Confirmar contraseña

            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) ||
                comboBox1.SelectedIndex == 0 || string.IsNullOrWhiteSpace(numDoc) ||
                string.IsNullOrWhiteSpace(telefono) || string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error de Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Aquí se llamaría a la capa BLL para registrar al nuevo administrador.
            // Ejemplo: BLL.AdminManager.RegisterAdmin(nombre, apellido, tipoDoc, numDoc, telefono, username, password);

            MessageBox.Show($"Lógica para registrar nuevo administrador:\nNombre: {nombre}\nUsuario: {username}", "Registro de Administrador (Placeholder)", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Si el registro es exitoso, podrías cerrar el formulario y volver al login.
            this.DialogResult = DialogResult.OK; // Opcional: para indicar éxito al formulario padre
            this.Close();
        }
    }
}