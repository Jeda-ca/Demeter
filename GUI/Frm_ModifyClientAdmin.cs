using BLL.Interfaces;
using BLL.Services;
using ENTITY;
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
    public partial class Frm_ModifyClientAdmin : Form
    {
        private readonly IClienteService _clienteService;
        private readonly ITipoDocumentoService _tipoDocumentoService;
        private readonly Cliente _clienteAModificar;
        private readonly int _idAdminLogueado;

        public Frm_ModifyClientAdmin(Cliente cliente, int idAdminLogueado)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;

            _clienteAModificar = cliente ?? throw new ArgumentNullException(nameof(cliente));
            _idAdminLogueado = idAdminLogueado; // Se recibe pero no se usa directamente en este servicio de cliente

            try
            {
                _clienteService = new ClienteService();
                _tipoDocumentoService = new TipoDocumentoService();
                CargarTiposDocumento();
                LoadClientData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico al inicializar servicios: {ex.Message}", "Error de Inicialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (ibtn_Modify != null) ibtn_Modify.Enabled = false;
                if (ibtn_Clear != null) ibtn_Clear.Enabled = false;
            }
        }

        private void CargarTiposDocumento()
        {
            try
            {
                if (_tipoDocumentoService == null) { /* Manejar error */ return; }
                var tiposDocumento = _tipoDocumentoService.ObtenerTodos();

                if (cbx_TypeDoc != null)
                {
                    cbx_TypeDoc.DataSource = null;
                    cbx_TypeDoc.Items.Clear();
                    cbx_TypeDoc.DisplayMember = "Nombre";
                    cbx_TypeDoc.ValueMember = "IdTipoDocumento";
                    cbx_TypeDoc.DataSource = tiposDocumento.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar tipos de documento: {ex.Message}", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (cbx_TypeDoc != null) cbx_TypeDoc.Enabled = false;
            }
        }

        private void LoadClientData()
        {
            if (_clienteAModificar != null)
            {
                // Asegúrate que los nombres de los TextBox coincidan con tu .Designer.cs
                tbx_Name.Text = _clienteAModificar.Nombre;
                tbx_LastName.Text = _clienteAModificar.Apellido;
                tbx_NumDoc.Text = _clienteAModificar.NumeroDocumento;
                tbx_Cellphone.Text = _clienteAModificar.Telefono;
                tbx_Email.Text = _clienteAModificar.Correo; // tbx_Email es el TextBox para el correo

                if (cbx_TypeDoc.Items.Count > 0 && _clienteAModificar.TipoDocumentoId > 0)
                {
                    cbx_TypeDoc.SelectedValue = _clienteAModificar.TipoDocumentoId;
                }
            }
        }

        private void ibtn_Modify_Click(object sender, EventArgs e) // Botón "Guardar Cambios"
        {
            if (string.IsNullOrWhiteSpace(tbx_Name.Text) ||
                string.IsNullOrWhiteSpace(tbx_LastName.Text) ||
                cbx_TypeDoc.SelectedValue == null || !(cbx_TypeDoc.SelectedValue is int) || ((int)cbx_TypeDoc.SelectedValue) <= 0 ||
                string.IsNullOrWhiteSpace(tbx_NumDoc.Text) ||
                string.IsNullOrWhiteSpace(tbx_Email.Text)
                )
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios (Nombre, Apellido, Tipo y N° Documento, Email).", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _clienteAModificar.Nombre = tbx_Name.Text.Trim();
            _clienteAModificar.Apellido = tbx_LastName.Text.Trim();
            _clienteAModificar.TipoDocumentoId = (int)cbx_TypeDoc.SelectedValue;
            _clienteAModificar.NumeroDocumento = tbx_NumDoc.Text.Trim();
            _clienteAModificar.Telefono = string.IsNullOrWhiteSpace(tbx_Cellphone.Text) ? null : tbx_Cellphone.Text.Trim();
            _clienteAModificar.Correo = tbx_Email.Text.Trim();
            // El estado Activo no se modifica aquí, se hace desde el gestor principal.

            try
            {
                if (_clienteService == null) { MessageBox.Show("Servicio de clientes no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                // El idAdminLogueado no es usado por RegistrarOActualizarCliente, pero se mantiene por consistencia si se necesitara para auditoría.
                string resultado = _clienteService.RegistrarOActualizarCliente(_clienteAModificar, false); // false porque estamos actualizando

                MessageBox.Show(resultado, "Modificación de Cliente", MessageBoxButtons.OK,
                                resultado.ToLower().Contains("exitosamente") ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (resultado.ToLower().Contains("exitosamente"))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (ApplicationException appEx)
            {
                MessageBox.Show($"Error de aplicación: {appEx.Message}", "Error de Modificación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error inesperado: {ex.Message}", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibtn_Clear_Click(object sender, EventArgs e)
        {
            LoadClientData();
        }

        private void ibtn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}