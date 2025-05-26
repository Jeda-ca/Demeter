using System;
using System.Linq;
using System.Windows.Forms;
using BLL.Interfaces;
using BLL.Services;
using ENTITY;

namespace GUI
{
    public partial class Frm_AddVendorAdmin : Form
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ITipoDocumentoService _tipoDocumentoService;
        private readonly int _idAdminLogueado; // Para consistencia, aunque el servicio actual no lo use directamente para AddVendor

        public Frm_AddVendorAdmin(int idAdminLogueado)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;

            _idAdminLogueado = idAdminLogueado;

            try
            {
                _usuarioService = new UsuarioService();
                _tipoDocumentoService = new TipoDocumentoService();
                CargarTiposDocumento();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico al inicializar servicios: {ex.Message}", "Error de Inicialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Deshabilitar controles si falla la inicialización
                ibtn_Add.Enabled = false;
                ibtn_Clear.Enabled = false;
            }
        }

        private void CargarTiposDocumento()
        {
            try
            {
                if (_tipoDocumentoService == null)
                {
                    MessageBox.Show("Servicio de tipos de documento no disponible.", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbx_TypeDoc.Enabled = false;
                    return;
                }
                var tiposDocumento = _tipoDocumentoService.ObtenerTodos();

                cbx_TypeDoc.DataSource = null;
                cbx_TypeDoc.Items.Clear();

                cbx_TypeDoc.DisplayMember = "Nombre";
                cbx_TypeDoc.ValueMember = "IdTipoDocumento";

                // Crear una lista que incluya el item por defecto "--Seleccione una opción--"
                var listaConDefault = tiposDocumento.ToList();
                listaConDefault.Insert(0, new TipoDocumento { IdTipoDocumento = 0, Nombre = "-- Seleccione una opción --" });

                cbx_TypeDoc.DataSource = listaConDefault;
                cbx_TypeDoc.SelectedIndex = 0; // Seleccionar el item por defecto
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar tipos de documento: {ex.Message}", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbx_TypeDoc.Enabled = false;
            }
        }

        private void ibtn_Add_Click(object sender, EventArgs e)
        {
            AddNewVendor();
        }

        private void ibtn_Clear_Click(object sender, EventArgs e)
        {
            ClearFormFields();
        }

        private void ibtn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AddNewVendor()
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(tbx_Name.Text) ||
                string.IsNullOrWhiteSpace(tbx_LastName.Text) ||
                cbx_TypeDoc.SelectedValue == null || !(cbx_TypeDoc.SelectedValue is int) || ((int)cbx_TypeDoc.SelectedValue) <= 0 ||
                string.IsNullOrWhiteSpace(tbx_NumDoc.Text) ||
                string.IsNullOrWhiteSpace(tbx_Username.Text) ||
                string.IsNullOrWhiteSpace(tbx_Password.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios: Nombre, Apellido, Tipo y Número de Documento, Nombre de Usuario y Contraseña.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nuevoVendedor = new Vendedor
            {
                Nombre = tbx_Name.Text.Trim(),
                Apellido = tbx_LastName.Text.Trim(),
                TipoDocumentoId = (int)cbx_TypeDoc.SelectedValue,
                NumeroDocumento = tbx_NumDoc.Text.Trim(),
                Telefono = string.IsNullOrWhiteSpace(tbx_Cellphone.Text) ? null : tbx_Cellphone.Text.Trim(),
                NombreUsuario = tbx_Username.Text.Trim(),
                // El CodigoVendedor y HashContrasena se generan/asignan en el servicio
                // FechaRegistro y RolId también se asignan en el servicio
            };
            string contrasena = tbx_Password.Text; // No trimear contraseña

            try
            {
                if (_usuarioService == null)
                {
                    MessageBox.Show("El servicio de usuario no está disponible.", "Error de Servicio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string resultado = _usuarioService.RegistrarNuevoVendedorComoUsuario(nuevoVendedor, contrasena);
                MessageBox.Show(resultado, "Registro de Vendedor", MessageBoxButtons.OK,
                                resultado.ToLower().Contains("exitosamente") ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (resultado.ToLower().Contains("exitosamente"))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (ApplicationException appEx)
            {
                MessageBox.Show($"Error de aplicación: {appEx.Message}", "Error de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error inesperado: {ex.Message}", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFormFields()
        {
            tbx_Name.Clear();
            tbx_LastName.Clear();
            if (cbx_TypeDoc.Items.Count > 0) cbx_TypeDoc.SelectedIndex = 0;
            tbx_NumDoc.Clear();
            tbx_Cellphone.Clear();
            tbx_Username.Clear();
            tbx_Password.Clear();
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
//    public partial class Frm_AddVendorAdmin : Form
//    {
//        public Frm_AddVendorAdmin()
//        {
//            InitializeComponent();

//            // Inicializar ComboBox de Tipo de Documento (placeholder)
//            //cbx_TypeDoc.Items.Add("-- Seleccione --");
//            cbx_TypeDoc.SelectedIndex = 0; // Seleccionar la opción por defecto
//        }

//        // EVENTOS
//        private void ibtn_Add_Click(object sender, EventArgs e) // Evento Click del botón "Agregar" (placeholder para la lógica de agregar)
//        {
//            AddNewVendor();
//        }
//        private void ibtn_Clear_Click(object sender, EventArgs e) // Evento Click del botón "Limpiar"
//        {
//            ClearFormFields();
//        }
//        private void ibtn_Cancel_Click(object sender, EventArgs e) // Evento Click del botón "Cancelar"
//        {
//            this.Close(); // Cierra el formulario sin realizar ninguna acción de guardado
//        }

//        // MÉTODOS PRIVADOS
//        private void AddNewVendor() //Placehlder para agregar un nuevo vendedor
//        {
//            // --- Lógica placeholder para agregar un nuevo registro (Vendedor, Cliente, etc.) ---
//            // Aquí deberías recopilar los datos de los campos de texto y combobox.
//            string nombre = tbx_Name.Text;
//            string apellido = tbx_LastName.Text;
//            string tipoDoc = cbx_TypeDoc.SelectedIndex > 0 ? cbx_TypeDoc.SelectedItem.ToString() : string.Empty;
//            string numDoc = tbx_NumDoc.Text;
//            string telefono = tbx_Cellphone.Text;
//            string nomUsuario = tbx_Username.Text;
//            string contrasena = tbx_Password.Text;
//            // string email = ""; // Si Frm_Add fuera también para clientes y tuviera tbx_Email

//            // Validaciones básicas (pueden ser más robustas)
//            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) || cbx_TypeDoc.SelectedIndex == 0 || string.IsNullOrWhiteSpace(numDoc) || string.IsNullOrWhiteSpace(nomUsuario) || string.IsNullOrWhiteSpace(contrasena))
//            {
//                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            // Aquí se llamaría a la capa BLL para guardar el nuevo registro en la base de datos.
//            // Ejemplo: BLL.PersonaManager.AddPersona(nombre, apellido, tipoDoc, numDoc, telefono);
//            // Si es un vendedor: BLL.VendedorManager.AddVendedor(personaId, ...);
//            // Si es un cliente: BLL.ClienteManager.AddCliente(personaId, email, ...);

//            MessageBox.Show($"Lógica para agregar nuevo registro:\nNombre: {nombre}\nApellido: {apellido}\nTipo Doc: {tipoDoc}\nNum Doc: {numDoc}\nTeléfono: {telefono}", "Agregar (Placeholder)", MessageBoxButtons.OK, MessageBoxIcon.Information);

//            // Después de agregar con éxito, podrías cerrar el formulario o limpiar los campos:
//            // this.DialogResult = DialogResult.OK; // Indica éxito al formulario padre

//            this.Close(); // Cierra el formulario actual (después de agregar el registro)
//            // ClearFormFields();
//        }
//        private void ClearFormFields() // Método para limpiar todos los TextBox y ComboBox del formulario
//        {
//            tbx_Name.Clear();
//            tbx_LastName.Clear();
//            cbx_TypeDoc.SelectedIndex = 0; // Vuelve a la opción por defecto
//            tbx_NumDoc.Clear();
//            tbx_Cellphone.Clear();
//            tbx_Username.Clear();
//            tbx_Password.Clear();
//            // Si este formulario se usa para clientes, también limpiar tbx_Email
//            // if (this.Controls.ContainsKey("tbx_Email")) { tbx_Email.Clear(); } // Ejemplo de cómo manejar si el campo existe
//        }
//    }
//}