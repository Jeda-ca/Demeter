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
    public partial class Frm_ModifyVendorAdmin : Form
    {
        private readonly IVendedorService _vendedorService;
        private readonly ITipoDocumentoService _tipoDocumentoService;
        private readonly Vendedor _vendedorAModificar;
        private readonly int _idAdminLogueado;

        public Frm_ModifyVendorAdmin(Vendedor vendedor, int idAdminLogueado)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;

            _vendedorAModificar = vendedor ?? throw new ArgumentNullException(nameof(vendedor));
            _idAdminLogueado = idAdminLogueado;

            try
            {
                _vendedorService = new VendedorService();
                _tipoDocumentoService = new TipoDocumentoService();
                CargarTiposDocumento();
                LoadVendorData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico al inicializar servicios: {ex.Message}", "Error de Inicialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Deshabilitar controles
                ibtn_Modify.Enabled = false;
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
                cbx_TypeDoc.DataSource = tiposDocumento.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar tipos de documento: {ex.Message}", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbx_TypeDoc.Enabled = false;
            }
        }

        private void LoadVendorData()
        {
            if (_vendedorAModificar != null)
            {
                tbx_Name.Text = _vendedorAModificar.Nombre;
                tbx_LastName.Text = _vendedorAModificar.Apellido;
                tbx_NumDoc.Text = _vendedorAModificar.NumeroDocumento;
                tbx_Cellphone.Text = _vendedorAModificar.Telefono;
                // tbx_Username y tbx_Password no se cargan aquí, ya que la modificación de credenciales es otra funcionalidad.
                // El código de vendedor tampoco se modifica generalmente.

                if (cbx_TypeDoc.Items.Count > 0)
                {
                    cbx_TypeDoc.SelectedValue = _vendedorAModificar.TipoDocumentoId;
                }
            }
        }

        private void ibtn_Modify_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(tbx_Name.Text) ||
                string.IsNullOrWhiteSpace(tbx_LastName.Text) ||
                cbx_TypeDoc.SelectedValue == null || !(cbx_TypeDoc.SelectedValue is int) || ((int)cbx_TypeDoc.SelectedValue) <= 0 ||
                string.IsNullOrWhiteSpace(tbx_NumDoc.Text))
            {
                MessageBox.Show("Los campos Nombre, Apellido, Tipo y Número de Documento son obligatorios.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Actualizar la entidad _vendedorAModificar con los datos del formulario
            _vendedorAModificar.Nombre = tbx_Name.Text.Trim();
            _vendedorAModificar.Apellido = tbx_LastName.Text.Trim();
            _vendedorAModificar.TipoDocumentoId = (int)cbx_TypeDoc.SelectedValue;
            _vendedorAModificar.NumeroDocumento = tbx_NumDoc.Text.Trim();
            _vendedorAModificar.Telefono = string.IsNullOrWhiteSpace(tbx_Cellphone.Text) ? null : tbx_Cellphone.Text.Trim();
            // No se actualiza NombreUsuario, HashContrasena, CodigoVendedor ni RolId aquí.
            // El estado Activo se maneja por separado.

            try
            {
                if (_vendedorService == null)
                {
                    MessageBox.Show("El servicio de vendedor no está disponible.", "Error de Servicio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // El ID del admin que modifica se pasa al servicio.
                string resultado = _vendedorService.ModificarVendedor(_vendedorAModificar, _idAdminLogueado);
                MessageBox.Show(resultado, "Modificación de Vendedor", MessageBoxButtons.OK,
                                resultado.ToLower().Contains("exitosamente") ? MessageBoxIcon.Information : MessageBoxIcon.Information);

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
            // Recargar los datos originales del vendedor en lugar de limpiar todo
            LoadVendorData();
        }

        private void ibtn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}