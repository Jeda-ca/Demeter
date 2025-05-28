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
    public partial class Frm_AddSaleVendor : Form
    {
        private readonly int _idUsuarioVendedorLogueado;
        private readonly int _idVendedorTabla; // PK de la tabla 'sellers'

        private readonly IVentaService _ventaService;
        private readonly IClienteService _clienteService; // Para buscar clientes
        private readonly IProductoService _productoService; // Para buscar productos
        private readonly IEstadoVentaService _estadoVentaService; // Para el ComboBox de estado

        private DataTable saleDetailsDataTable;
        private Cliente _clienteSeleccionado = null;

        public Frm_AddSaleVendor(int idUsuarioVendedor, int idVendedorTabla)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;

            _idUsuarioVendedorLogueado = idUsuarioVendedor;
            _idVendedorTabla = idVendedorTabla;

            if (_idUsuarioVendedorLogueado <= 0 || _idVendedorTabla <= 0)
            {
                MessageBox.Show("Error: Información de vendedor no válida.", "Error de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new MethodInvoker(this.Close)); // Cierra de forma segura
                return;
            }

            try
            {
                _ventaService = new VentaService();
                _clienteService = new ClienteService();
                _productoService = new ProductoService();
                _estadoVentaService = new EstadoVentaService();

                InitializeSaleDetailsDataGridView();
                CargarEstadosVentaComboBox();
                tbx_DateV.Text = DateTime.Now.ToShortDateString(); // Fecha actual por defecto
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico al inicializar servicios: {ex.Message}", "Error de Inicialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Deshabilitar controles si la inicialización falla
                if (ibtn_Register != null) ibtn_Register.Enabled = false;

            }
        }

        public Frm_AddSaleVendor()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            _idUsuarioVendedorLogueado = 0;
            _idVendedorTabla = 0;

            try
            {
                _ventaService = new VentaService();
                _clienteService = new ClienteService();
                _productoService = new ProductoService();
                _estadoVentaService = new EstadoVentaService();
                InitializeSaleDetailsDataGridView();
                CargarEstadosVentaComboBox();
                tbx_DateV.Text = DateTime.Now.ToShortDateString();
            }
            catch (Exception ex) { }
        }


        private void InitializeSaleDetailsDataGridView()
        {
            saleDetailsDataTable = new DataTable();
            saleDetailsDataTable.Columns.Add("IdProducto", typeof(int)); // Oculta
            saleDetailsDataTable.Columns.Add("ProductoNombre", typeof(string));
            saleDetailsDataTable.Columns.Add("Cantidad", typeof(int));
            saleDetailsDataTable.Columns.Add("PrecioUnitario", typeof(decimal));
            saleDetailsDataTable.Columns.Add("SubtotalItem", typeof(decimal));

            if (dgv_SaleDetail != null) // dgv_SaleDetail es tu DataGridView
            {
                dgv_SaleDetail.DataSource = saleDetailsDataTable;
                if (dgv_SaleDetail.Columns["IdProducto"] != null) dgv_SaleDetail.Columns["IdProducto"].Visible = false;
                if (dgv_SaleDetail.Columns["PrecioUnitario"] != null) dgv_SaleDetail.Columns["PrecioUnitario"].DefaultCellStyle.Format = "C2";
                if (dgv_SaleDetail.Columns["SubtotalItem"] != null) dgv_SaleDetail.Columns["SubtotalItem"].DefaultCellStyle.Format = "C2";
            }
        }

        private void CargarEstadosVentaComboBox()
        {
            try
            {
                if (_estadoVentaService == null) { return; }
                var estados = _estadoVentaService.ObtenerTodos()
                                .Where(e => e.Nombre.ToUpper() == "PENDIENTE" || e.Nombre.ToUpper() == "COMPLETADA") // Solo permitir estos al crear
                                .ToList();

                if (cbx_State != null) // cbx_State es tu ComboBox para el estado de la venta
                {
                    cbx_State.DataSource = null;
                    cbx_State.Items.Clear();
                    cbx_State.DisplayMember = "Nombre";
                    cbx_State.ValueMember = "IdEstado";

                    var listaConDefault = new List<EstadoVenta> { new EstadoVenta { IdEstado = 0, Nombre = "-- Seleccione Estado --" } };
                    listaConDefault.AddRange(estados);
                    cbx_State.DataSource = listaConDefault;
                    cbx_State.SelectedIndex = 0;
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error al cargar estados de venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ibtn_DocClient_Click(object sender, EventArgs e) // Buscar Cliente
        {
            using (Frm_BusqClient frmBusqClient = new Frm_BusqClient())
            {
                if (frmBusqClient.ShowDialog() == DialogResult.OK)
                {
                    if (_clienteService == null) { MessageBox.Show("Servicio de clientes no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                    _clienteSeleccionado = _clienteService.ObtenerClientePorId(frmBusqClient.SelectedClientId);
                    if (_clienteSeleccionado != null)
                    {
                        if (tbx_NumDoc != null) tbx_NumDoc.Text = _clienteSeleccionado.NumeroDocumento;
                        if (tbx_NomClient != null) tbx_NomClient.Text = $"{_clienteSeleccionado.Nombre} {_clienteSeleccionado.Apellido}";
                    }
                    else
                    {
                        MessageBox.Show("No se pudo cargar la información del cliente seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (tbx_NumDoc != null) tbx_NumDoc.Clear();
                        if (tbx_NomClient != null) tbx_NomClient.Clear();
                    }
                }
            }
        }

        private void ibtn_NomProduct_Click(object sender, EventArgs e) // Buscar Producto
        {
            // Frm_BusqProduct podría necesitar el IdVendedorTabla para mostrar solo productos de ese vendedor
            using (Frm_BusqProduct frmBusqProduct = new Frm_BusqProduct(_idVendedorTabla))
            {
                if (frmBusqProduct.ShowDialog() == DialogResult.OK)
                {
                    if (tbx_Product != null) tbx_Product.Text = frmBusqProduct.SelectedProductName;
                    if (tbx_UniPrice != null) tbx_UniPrice.Text = frmBusqProduct.SelectedProductPrice.ToString("N2"); // Mostrar como número
                    if (nud_Cantidad != null) nud_Cantidad.Value = 1; // Cantidad por defecto
                    // Guardar el ID del producto seleccionado para usarlo al agregar al detalle
                    tbx_Product.Tag = frmBusqProduct.SelectedProductId;
                    CalculateSubtotalItem();
                }
            }
        }

        private void nud_Cantidad_ValueChanged(object sender, EventArgs e) { CalculateSubtotalItem(); }
        private void tbx_UniPrice_TextChanged(object sender, EventArgs e) { CalculateSubtotalItem(); } // Si fuera editable

        private void CalculateSubtotalItem()
        {
            if (decimal.TryParse(tbx_UniPrice.Text, out decimal unitPrice) && nud_Cantidad.Value > 0)
            {
                if (tbx_SubTIItem != null) tbx_SubTIItem.Text = (unitPrice * nud_Cantidad.Value).ToString("N2");
            }
            else
            {
                if (tbx_SubTIItem != null) tbx_SubTIItem.Text = "0.00";
            }
        }

        private void ibtn_AddDV_Click(object sender, EventArgs e) // Agregar al Detalle de Venta
        {
            if (tbx_Product.Tag == null || !(tbx_Product.Tag is int) || ((int)tbx_Product.Tag) <= 0)
            { MessageBox.Show("Por favor, busque y seleccione un producto válido.", "Producto no Seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (nud_Cantidad.Value <= 0)
            { MessageBox.Show("La cantidad debe ser mayor a cero.", "Cantidad Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!decimal.TryParse(tbx_UniPrice.Text, out decimal precioUnitario) || precioUnitario <= 0)
            { MessageBox.Show("Precio unitario no válido.", "Precio Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            int idProducto = (int)tbx_Product.Tag;
            string nombreProducto = tbx_Product.Text;
            int cantidad = (int)nud_Cantidad.Value;
            decimal subtotalItem = cantidad * precioUnitario;

            saleDetailsDataTable.Rows.Add(idProducto, nombreProducto, cantidad, precioUnitario, subtotalItem);
            CalculateSaleTotals();

            // Limpiar campos para nuevo producto
            tbx_Product.Clear();
            tbx_UniPrice.Clear();
            nud_Cantidad.Value = 0;
            tbx_SubTIItem.Clear();
            tbx_Product.Tag = null;
        }

        private void CalculateSaleTotals()
        {
            decimal currentSubtotalVenta = 0m;
            foreach (DataRow row in saleDetailsDataTable.Rows)
            {
                currentSubtotalVenta += Convert.ToDecimal(row["SubtotalItem"]);
            }

            decimal descuento = 0m;
            if (tbx_Desc != null && decimal.TryParse(tbx_Desc.Text, out decimal descVal))
            {
                descuento = descVal;
            }

            if (tbx_SubTVent != null) tbx_SubTVent.Text = currentSubtotalVenta.ToString("C2");
            if (tbx_Total != null) tbx_Total.Text = (currentSubtotalVenta - descuento).ToString("C2");
        }

        private void tbx_Desc_TextChanged(object sender, EventArgs e) { CalculateSaleTotals(); }

        private void ibtn_Register_Click(object sender, EventArgs e)
        {
            if (_clienteSeleccionado == null)
            { MessageBox.Show("Por favor, seleccione un cliente.", "Cliente Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (saleDetailsDataTable.Rows.Count == 0)
            { MessageBox.Show("Debe agregar al menos un producto a la venta.", "Detalle Vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (cbx_State.SelectedValue == null || !(cbx_State.SelectedValue is int) || ((int)cbx_State.SelectedValue) <= 0)
            { MessageBox.Show("Por favor, seleccione un estado para la venta.", "Estado Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            var venta = new Venta
            {
                FechaOcurrencia = DateTime.Parse(tbx_DateV.Text), // O DateTime.Now si no es editable
                ClienteId = _clienteSeleccionado.IdCliente,
                VendedorId = _idVendedorTabla, // PK de la tabla sellers
                EstadoId = (int)cbx_State.SelectedValue,
                Observaciones = tbx_Observaciones.Text.Trim(),
                Descuento = decimal.TryParse(tbx_Desc.Text, out decimal desc) ? desc : 0m,
                // Subtotal y Total se calcularán en el servicio o se pueden pasar desde aquí
            };

            foreach (DataRow row in saleDetailsDataTable.Rows)
            {
                venta.DetallesVenta.Add(new DetalleVenta
                {
                    ProductoId = Convert.ToInt32(row["IdProducto"]),
                    Cantidad = Convert.ToInt32(row["Cantidad"]),
                    PrecioUnitario = Convert.ToDecimal(row["PrecioUnitario"]),
                    TotalLinea = Convert.ToDecimal(row["SubtotalItem"])
                });
            }

            try
            {
                if (_ventaService == null) { MessageBox.Show("Servicio de ventas no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                string resultado = _ventaService.RegistrarNuevaVenta(venta, _idVendedorTabla); // Se pasa IdVendedorTabla

                MessageBox.Show(resultado, "Registrar Venta", MessageBoxButtons.OK,
                                resultado.ToLower().Contains("exitosamente") ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (resultado.ToLower().Contains("exitosamente"))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error al registrar venta: {ex.Message}", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ibtn_Clear_Click(object sender, EventArgs e)
        {
            _clienteSeleccionado = null;
            if (tbx_NumDoc != null) tbx_NumDoc.Clear();
            if (tbx_NomClient != null) tbx_NomClient.Clear();
            if (tbx_Product != null) tbx_Product.Clear();
            if (tbx_UniPrice != null) tbx_UniPrice.Clear();
            if (nud_Cantidad != null) nud_Cantidad.Value = 0;
            if (tbx_SubTIItem != null) tbx_SubTIItem.Clear();
            if (tbx_Desc != null) tbx_Desc.Clear();
            if (tbx_SubTVent != null) tbx_SubTVent.Clear();
            if (tbx_Total != null) tbx_Total.Clear();
            if (tbx_Observaciones != null) tbx_Observaciones.Clear();
            if (cbx_State.Items.Count > 0) cbx_State.SelectedIndex = 0;
            saleDetailsDataTable.Clear();
            CalculateSaleTotals();
        }

        private void ibtn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}