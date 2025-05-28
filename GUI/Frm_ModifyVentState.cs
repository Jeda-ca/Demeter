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
    public partial class Frm_ModifyVentState : Form
    {
        private readonly IVentaService _ventaService;
        private readonly IEstadoVentaService _estadoVentaService; // Usar el servicio
        private readonly Venta _ventaAModificar;
        private readonly int _idAdminLogueado;

        public Frm_ModifyVentState(Venta venta, int idAdminLogueado)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;

            _ventaAModificar = venta ?? throw new ArgumentNullException(nameof(venta));
            _idAdminLogueado = idAdminLogueado;

            try
            {
                _ventaService = new VentaService();
                _estadoVentaService = new EstadoVentaService(); // Instanciar el servicio
                LoadSaleData();
                CargarEstadosVentaComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico al inicializar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (ibtn_Modify != null) ibtn_Modify.Enabled = false;
            }
        }

        private void LoadSaleData()
        {
            if (_ventaAModificar != null)
            {
                if (tbx_Date != null) tbx_Date.Text = _ventaAModificar.FechaOcurrencia.ToShortDateString();
                if (tbx_Code != null) tbx_Code.Text = _ventaAModificar.IdVenta.ToString();
                if (tbx_TotVent != null) tbx_TotVent.Text = _ventaAModificar.Total.ToString("C");
            }
        }

        private void CargarEstadosVentaComboBox()
        {
            try
            {
                if (_estadoVentaService == null)
                {
                    MessageBox.Show("Servicio de estados de venta no disponible.", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (cbx_VentState != null) cbx_VentState.Enabled = false;
                    return;
                }
                var estados = _estadoVentaService.ObtenerTodos().ToList();

                if (cbx_VentState != null)
                {
                    cbx_VentState.DataSource = null;
                    cbx_VentState.Items.Clear();
                    cbx_VentState.DisplayMember = "Nombre";
                    cbx_VentState.ValueMember = "IdEstado";
                    cbx_VentState.DataSource = estados;

                    if (_ventaAModificar != null && _ventaAModificar.EstadoId > 0 && estados.Any(e => e.IdEstado == _ventaAModificar.EstadoId))
                    {
                        cbx_VentState.SelectedValue = _ventaAModificar.EstadoId;
                    }
                    else if (cbx_VentState.Items.Count > 0)
                    {
                        cbx_VentState.SelectedIndex = 0; // O -1 para ninguna selección si no hay estado actual
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar estados de venta: {ex.Message}", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (cbx_VentState != null) cbx_VentState.Enabled = false;
            }
        }

        private void ibtn_Modify_Click(object sender, EventArgs e)
        {
            if (cbx_VentState.SelectedValue == null || !(cbx_VentState.SelectedValue is int) || ((int)cbx_VentState.SelectedValue) <= 0)
            {
                MessageBox.Show("Por favor, seleccione un nuevo estado válido para la venta.", "Estado Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int nuevoEstadoId = (int)cbx_VentState.SelectedValue;
            string nuevoEstadoNombre = (cbx_VentState.SelectedItem as EstadoVenta)?.Nombre ?? "Desconocido";

            if (_ventaAModificar.EstadoId == nuevoEstadoId)
            {
                MessageBox.Show("El estado seleccionado es el mismo que el actual. No se realizaron cambios.", "Sin Cambios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            if (nuevoEstadoNombre.ToUpper() == "CANCELADA")
            {
                DialogResult confirmCancel = MessageBox.Show($"Está a punto de cambiar el estado a CANCELADA. Esto también intentará revertir el stock de los productos involucrados.\n¿Desea continuar?", "Confirmar Cancelación", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (confirmCancel == DialogResult.OK)
                {
                    string motivo = $"Estado cambiado a CANCELADA por Admin ID: {_idAdminLogueado} el {DateTime.Now.ToString("g")}";
                    string resultadoCancelacion = _ventaService.CancelarVenta(_ventaAModificar.IdVenta, motivo);
                    MessageBox.Show(resultadoCancelacion, "Cancelar Venta", MessageBoxButtons.OK,
                                   resultadoCancelacion.ToLower().Contains("exitosa") ? MessageBoxIcon.Information : MessageBoxIcon.Error); // "exitosamente" o "exitosa"
                    if (resultadoCancelacion.ToLower().Contains("exitosa"))
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                return;
            }

            _ventaAModificar.EstadoId = nuevoEstadoId;
            _ventaAModificar.Observaciones = (_ventaAModificar.Observaciones ?? "") + $"\nEstado actualizado a '{nuevoEstadoNombre}' por Admin ID: {_idAdminLogueado} el {DateTime.Now.ToString("g")}";

            try
            {
                if (_ventaService == null) { MessageBox.Show("Servicio de ventas no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                bool actualizado = _ventaService.ActualizarVenta(_ventaAModificar);

                string resultado = actualizado ? $"Estado de la venta ID {_ventaAModificar.IdVenta} actualizado a '{nuevoEstadoNombre}'."
                                             : "No se pudo actualizar el estado de la venta.";

                MessageBox.Show(resultado, "Modificación de Estado", MessageBoxButtons.OK,
                                actualizado ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (actualizado)
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

        private void ibtn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}