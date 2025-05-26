using BLL.Interfaces;
using BLL.Services;
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
        private readonly IUsuarioService _usuarioService;
        private readonly ITipoDocumentoService _tipoDocumentoService;

        public Frm_RegisterAdmin()
        {
            InitializeComponent();
            try
            {
                _usuarioService = new UsuarioService();
                _tipoDocumentoService = new TipoDocumentoService();

                CargarTiposDocumento();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico al inicializar servicios: {ex.Message}\n\n{ex.StackTrace}", "Error de Inicialización", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (this.Controls.Find("btn_Ingresar", true).FirstOrDefault() is Button btn)
                {
                    btn.Enabled = false;
                }
            }
        }

        private void CargarTiposDocumento()
        {
            try
            {
                if (_tipoDocumentoService == null)
                {
                    MessageBox.Show("Servicio de tipos de documento no disponible.", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (comboBox1 != null) comboBox1.Enabled = false;
                    return;
                }
                var tiposDocumento = _tipoDocumentoService.ObtenerTodos();

                if (comboBox1 != null)
                {
                    comboBox1.DataSource = null;
                    comboBox1.Items.Clear();

                    comboBox1.DisplayMember = "Nombre";
                    comboBox1.ValueMember = "IdTipoDocumento";
                    comboBox1.DataSource = tiposDocumento.ToList();

                    // Si quieres un item por defecto como "-- Seleccione --" que no sea un valor válido:
                    // Comentado por ahora, ya que puede complicar la validación de SelectedValue.
                    // var listaConDefault = tiposDocumento.ToList();
                    // listaConDefault.Insert(0, new TipoDocumento { IdTipoDocumento = 0, Nombre = "-- Seleccione --" });
                    // comboBox1.DataSource = listaConDefault;
                    // comboBox1.SelectedIndex = 0;

                    if (comboBox1.Items.Count > 0)
                    {
                        comboBox1.SelectedIndex = 0; // O -1 para ninguna selección inicial si no quieres un valor por defecto
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar tipos de documento: {ex.Message}", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (comboBox1 != null) comboBox1.Enabled = false;
            }
        }

        private void RegistrarAdministrador()
        {
            // Asegúrate que los nombres de los controles aquí coincidan con tu Frm_RegisterAdmin.Designer.cs
            string nombre = textBox2.Text.Trim();
            string apellido = textBox3.Text.Trim();
            string numDoc = textBox4.Text.Trim();
            string telefono = textBox6.Text.Trim();
            string username = tbx_Username.Text.Trim();
            string password = tbx_Password.Text;
            string confirmPassword = textBox1.Text; // textBox1 es para confirmar contraseña

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) ||
                comboBox1.SelectedValue == null || !(comboBox1.SelectedValue is int) || ((int)comboBox1.SelectedValue) <= 0 || // Validación más robusta para ComboBox
                string.IsNullOrWhiteSpace(numDoc) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios. Asegúrese de seleccionar un tipo de documento válido.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error de Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int tipoDocId = (int)comboBox1.SelectedValue;

            var nuevoAdmin = new ENTITY.Administrador
            {
                Nombre = nombre,
                Apellido = apellido,
                TipoDocumentoId = tipoDocId,
                NumeroDocumento = numDoc,
                Telefono = string.IsNullOrWhiteSpace(telefono) ? null : telefono, // Permite teléfono opcional
                NombreUsuario = username,
                // FechaRegistro y RolId se asignarán en el servicio BLL
            };

            try
            {
                if (_usuarioService == null)
                {
                    MessageBox.Show("El servicio de usuario no está disponible.", "Error de Servicio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string resultado = _usuarioService.RegistrarNuevoAdministradorComoUsuario(nuevoAdmin, password);
                MessageBox.Show(resultado, "Registro de Administrador", MessageBoxButtons.OK,
                                resultado.ToLower().Contains("exitosamente") ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (resultado.ToLower().Contains("exitosamente"))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (ApplicationException appEx)
            {
                MessageBox.Show($"Error de aplicación durante el registro: {appEx.Message}", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error inesperado: {ex.Message}", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Event Handlers (Nombres deben coincidir con tu Frm_RegisterAdmin.Designer.cs) ---
        private void checkbx_showPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (tbx_Password != null) // tbx_Password es el campo de la contraseña principal
                tbx_Password.PasswordChar = checkbx_showPassword.Checked ? '\0' : '●';
        }

        private void checkbx2_showPassword_CheckedChanged(object sender, EventArgs e)
        {
            // textBox1 es el campo de confirmar contraseña
            if (textBox1 != null)
                textBox1.PasswordChar = checkbx2_showPassword.Checked ? '\0' : '●';
        }

        private void ibtn_Minimized_LogIn_Click(object sender, EventArgs e) // Asumo que este es el botón de minimizar
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ibtn_Exit_LogIn_Click(object sender, EventArgs e) // Asumo que este es el botón de cerrar/salir
        {
            this.Close();
        }

        private void btn_Ingresar_Click(object sender, EventArgs e) // Este es el botón "Registrar" en este formulario
        {
            RegistrarAdministrador();
        }

        private void lbl_SignIn_Click(object sender, EventArgs e) // Para volver al Login
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}