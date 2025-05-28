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
    public partial class Frm_AddClientVendor : Form
    {
        private readonly int _idUsuarioVendedor;
        private readonly IClienteService _clienteService;
        private readonly ITipoDocumentoService _tipoDocumentoService;

        public Frm_AddClientVendor(int idUsuarioVendedor)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;

            _idUsuarioVendedor = idUsuarioVendedor;

            try
            {
                _clienteService = new ClienteService();
                _tipoDocumentoService = new TipoDocumentoService();
                CargarTiposDocumento();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar servicios: {ex.Message}", "Error de Inicialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (this.Controls.Find("ibtn_Add", true).FirstOrDefault() is Button btnAdd) btnAdd.Enabled = false;
            }
        }

        public Frm_AddClientVendor()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            _idUsuarioVendedor = 0;
            try
            {
                _clienteService = new ClienteService();
                _tipoDocumentoService = new TipoDocumentoService();
                CargarTiposDocumento();
            }
            catch (Exception ex) { }
        }


        private void CargarTiposDocumento()
        {
            try
            {
                if (_tipoDocumentoService == null) { MessageBox.Show("Servicio de tipos de documento no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                var tiposDocumento = _tipoDocumentoService.ObtenerTodos().ToList();

                // cbx_TypeDoc es el ComboBox para Tipo de Documento
                if (cbx_TypeDoc != null)
                {
                    cbx_TypeDoc.DataSource = null;
                    cbx_TypeDoc.Items.Clear();
                    cbx_TypeDoc.DisplayMember = "Nombre";
                    cbx_TypeDoc.ValueMember = "IdTipoDocumento";

                    var listaConDefault = tiposDocumento;
                    listaConDefault.Insert(0, new TipoDocumento { IdTipoDocumento = 0, Nombre = "-- Seleccione --" });
                    cbx_TypeDoc.DataSource = listaConDefault;
                    cbx_TypeDoc.SelectedIndex = 0;
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error al cargar tipos de documento: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ibtn_Add_Click(object sender, EventArgs e)
        {
            string nombre = tbx_Name.Text.Trim();
            string apellido = tbx_LastName.Text.Trim();
            string numDoc = tbx_NumDoc.Text.Trim();
            string telefono = tbx_Cellphone.Text.Trim();
            string email = textBox1.Text.Trim(); // textBox1 es el de Email en Frm_AddClientVendor.Designer.cs

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) ||
                cbx_TypeDoc.SelectedValue == null || !(cbx_TypeDoc.SelectedValue is int) || ((int)cbx_TypeDoc.SelectedValue) <= 0 ||
                string.IsNullOrWhiteSpace(numDoc) ||
                string.IsNullOrWhiteSpace(email) )
            {
                MessageBox.Show("Nombre, Apellido, Tipo y N° Documento, y Email son obligatorios.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Generar código de cliente
            string codigoCliente = $"CLI-{DateTime.Now.Ticks.ToString().Substring(10)}";

            var nuevoCliente = new Cliente
            {
                Nombre = nombre,
                Apellido = apellido,
                TipoDocumentoId = (int)cbx_TypeDoc.SelectedValue,
                NumeroDocumento = numDoc,
                Telefono = string.IsNullOrWhiteSpace(telefono) ? null : telefono,
                Correo = email,
                CodigoCliente = codigoCliente,
            };

            try
            {
                if (_clienteService == null) { MessageBox.Show("Servicio de clientes no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                string resultado = _clienteService.RegistrarOActualizarCliente(nuevoCliente, true); // true porque es nuevo

                MessageBox.Show(resultado, "Registrar Cliente", MessageBoxButtons.OK,
                                resultado.ToLower().Contains("exitosamente") ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (resultado.ToLower().Contains("exitosamente"))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibtn_Clear_Click(object sender, EventArgs e)
        {
            tbx_Name.Clear();
            tbx_LastName.Clear();
            if (cbx_TypeDoc.Items.Count > 0) cbx_TypeDoc.SelectedIndex = 0;
            tbx_NumDoc.Clear();
            tbx_Cellphone.Clear();
            if (textBox1 != null) textBox1.Clear(); // Email
        }

        private void ibtn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}