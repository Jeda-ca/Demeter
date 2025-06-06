﻿using BLL.Interfaces;
using BLL.Services;
using ENTITY;
using GUI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Frm_AddSaleVendor : Form
    {
        private readonly int _idUsuarioVendedorLogueado;
        private readonly int _idVendedorTabla;

        private readonly IVentaService _ventaService;
        private readonly IClienteService _clienteService;
        private readonly IProductoService _productoService;
        private readonly IEstadoVentaService _estadoVentaService;
        private readonly IVendedorService _vendedorService; // Para obtener datos del vendedor actual

        private DataTable saleDetailsDataTable;
        private Cliente _clienteSeleccionado = null;
        private int _stockDisponibleDelProductoSeleccionado = 0;

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
                this.BeginInvoke(new MethodInvoker(this.Close));
                return;
            }

            try
            {
                _ventaService = new VentaService();
                _clienteService = new ClienteService();
                _productoService = new ProductoService();
                _estadoVentaService = new EstadoVentaService();
                _vendedorService = new VendedorService(); // Inicializar servicio de vendedor

                InitializeSaleDetailsDataGridView();
                CargarEstadosVentaComboBox();
                ConfigurarTipoDescuentoComboBox();
                if (tbx_DateV != null) tbx_DateV.Text = DateTime.Now.ToShortDateString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico al inicializar servicios: {ex.Message}", "Error de Inicialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (ibtn_Register != null) ibtn_Register.Enabled = false;
            }
        }

        // Constructor por defecto para el diseñador (si es necesario, aunque es mejor evitarlo si se puede)
        public Frm_AddSaleVendor()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            // Valores por defecto o manejo para el modo diseño
            _idUsuarioVendedorLogueado = 0;
            _idVendedorTabla = 0;
            try
            {
                // Inicializaciones mínimas para que el diseñador no falle
                _estadoVentaService = new EstadoVentaService();
                InitializeSaleDetailsDataGridView();
                CargarEstadosVentaComboBox();
                ConfigurarTipoDescuentoComboBox();
                if (tbx_DateV != null) tbx_DateV.Text = DateTime.Now.ToShortDateString();
            }
            catch (Exception) { /* Silenciar para el diseñador */ }
        }


        private void InitializeSaleDetailsDataGridView()
        {
            saleDetailsDataTable = new DataTable();
            saleDetailsDataTable.Columns.Add("IdProducto", typeof(int));
            saleDetailsDataTable.Columns.Add("ProductoNombre", typeof(string));
            saleDetailsDataTable.Columns.Add("Cantidad", typeof(int));
            saleDetailsDataTable.Columns.Add("PrecioUnitario", typeof(decimal));
            saleDetailsDataTable.Columns.Add("SubtotalItem", typeof(decimal));

            if (dgv_SaleDetail != null)
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
                                .Where(e => e.Nombre.ToUpper() == "PENDIENTE" || e.Nombre.ToUpper() == "COMPLETADA")
                                .ToList();

                if (cbx_State != null)
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

        private void ConfigurarTipoDescuentoComboBox()
        {
            if (cbx_DiscountType != null)
            {
                cbx_DiscountType.Items.Clear();
                cbx_DiscountType.Items.Add("Monto Fijo ($)");
                cbx_DiscountType.Items.Add("Porcentaje (%)");
                cbx_DiscountType.SelectedIndex = 0;
                cbx_DiscountType.SelectedIndexChanged += Cbx_DiscountType_SelectedIndexChanged;
                ActualizarSufijoDescuento();
            }
            if (lbl_CalculatedDiscountAmount != null)
            {
                lbl_CalculatedDiscountAmount.Text = (0m).ToString("C2");
            }
        }

        private void Cbx_DiscountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarSufijoDescuento();
            if (tbx_DiscountValue != null)
            {
                tbx_DiscountValue.Clear();
            }
            CalculateSaleTotals();
        }

        private void ActualizarSufijoDescuento()
        {
            if (lbl_DiscountTypeSuffix != null && cbx_DiscountType != null)
            {
                if (cbx_DiscountType.SelectedItem?.ToString() == "Porcentaje (%)")
                {
                    lbl_DiscountTypeSuffix.Text = "%";
                }
                else
                {
                    lbl_DiscountTypeSuffix.Text = "$";
                }
            }
        }


        private void ibtn_DocClient_Click(object sender, EventArgs e)
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

        private void ibtn_NomProduct_Click(object sender, EventArgs e)
        {
            var itemsEnCarritoActual = new List<CarritoItemTemporal>();
            if (saleDetailsDataTable != null)
            {
                foreach (DataRow row in saleDetailsDataTable.Rows)
                {
                    itemsEnCarritoActual.Add(new CarritoItemTemporal
                    {
                        IdProducto = Convert.ToInt32(row["IdProducto"]),
                        Cantidad = Convert.ToInt32(row["Cantidad"])
                    });
                }
            }

            using (Frm_BusqProduct frmBusqProduct = new Frm_BusqProduct(_idVendedorTabla, itemsEnCarritoActual))
            {
                if (frmBusqProduct.ShowDialog() == DialogResult.OK)
                {
                    if (tbx_Product != null) tbx_Product.Text = frmBusqProduct.SelectedProductName;
                    if (tbx_UniPrice != null) tbx_UniPrice.Text = frmBusqProduct.SelectedProductPrice.ToString("N2", CultureInfo.InvariantCulture);
                    if (nud_Cantidad != null) nud_Cantidad.Value = 1;

                    tbx_Product.Tag = frmBusqProduct.SelectedProductId;
                    _stockDisponibleDelProductoSeleccionado = frmBusqProduct.SelectedProductStock;

                    CalculateSubtotalItem();
                }
            }
        }

        private void nud_Cantidad_ValueChanged(object sender, EventArgs e) { CalculateSubtotalItem(); }

        private void tbx_UniPrice_TextChanged(object sender, EventArgs e)
        {
            CalculateSubtotalItem();
        }

        private void CalculateSubtotalItem()
        {
            if (decimal.TryParse(tbx_UniPrice.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal unitPrice) && nud_Cantidad.Value > 0)
            {
                if (tbx_SubTIItem != null) tbx_SubTIItem.Text = (unitPrice * nud_Cantidad.Value).ToString("N2", CultureInfo.InvariantCulture);
            }
            else
            {
                if (tbx_SubTIItem != null) tbx_SubTIItem.Text = (0m).ToString("N2", CultureInfo.InvariantCulture);
            }
        }

        private void ibtn_AddDV_Click(object sender, EventArgs e)
        {
            if (tbx_Product.Tag == null || !(tbx_Product.Tag is int) || ((int)tbx_Product.Tag) <= 0)
            { MessageBox.Show("Por favor, busque y seleccione un producto válido.", "Producto no Seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            int cantidadDeseada = (int)nud_Cantidad.Value;

            if (cantidadDeseada <= 0)
            { MessageBox.Show("La cantidad debe ser mayor a cero.", "Cantidad Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (!decimal.TryParse(tbx_UniPrice.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal precioUnitario) || precioUnitario <= 0)
            { MessageBox.Show("Precio unitario no válido. Verifique el formato (ej: 24000.00).", "Precio Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            int idProducto = (int)tbx_Product.Tag;
            string nombreProducto = tbx_Product.Text;

            DataRow existingRow = null;
            foreach (DataRow row in saleDetailsDataTable.Rows)
            {
                if (Convert.ToInt32(row["IdProducto"]) == idProducto)
                {
                    existingRow = row;
                    break;
                }
            }

            int cantidadYaEnCarrito = existingRow != null ? Convert.ToInt32(existingRow["Cantidad"]) : 0;
            int cantidadTotalAIntentar = cantidadYaEnCarrito + cantidadDeseada;

            var productoInfo = _productoService.ObtenerProductoPorId(idProducto);
            if (productoInfo == null)
            {
                MessageBox.Show("No se pudo obtener la información del producto para validar stock.", "Error de Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int stockRealEnBD = productoInfo.Stock;

            if (cantidadTotalAIntentar > stockRealEnBD)
            {
                MessageBox.Show($"No puede agregar/actualizar a {cantidadTotalAIntentar} unidades de '{nombreProducto}'. Stock total en base de datos: {stockRealEnBD}. Ya tiene {cantidadYaEnCarrito} en el carrito.", "Stock Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (existingRow != null)
            {
                existingRow["Cantidad"] = cantidadTotalAIntentar;
                existingRow["SubtotalItem"] = (decimal)cantidadTotalAIntentar * precioUnitario;
            }
            else
            {
                decimal subtotalItem = cantidadDeseada * precioUnitario;
                saleDetailsDataTable.Rows.Add(idProducto, nombreProducto, cantidadDeseada, precioUnitario, subtotalItem);
            }

            CalculateSaleTotals();

            tbx_Product.Clear();
            tbx_UniPrice.Clear();
            nud_Cantidad.Value = 0;
            tbx_SubTIItem.Clear();
            tbx_Product.Tag = null;
            _stockDisponibleDelProductoSeleccionado = 0;
        }

        private void CalculateSaleTotals()
        {
            decimal currentSubtotalVenta = 0m;
            foreach (DataRow row in saleDetailsDataTable.Rows)
            {
                currentSubtotalVenta += Convert.ToDecimal(row["SubtotalItem"]);
            }

            decimal valorDescuentoInput = 0m;
            if (tbx_DiscountValue != null && decimal.TryParse(tbx_DiscountValue.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valInput))
            {
                valorDescuentoInput = valInput;
            }

            decimal descuentoCalculado = 0m;
            if (cbx_DiscountType != null && cbx_DiscountType.SelectedItem?.ToString() == "Porcentaje (%)")
            {
                if (valorDescuentoInput >= 0 && valorDescuentoInput <= 100)
                {
                    descuentoCalculado = currentSubtotalVenta * (valorDescuentoInput / 100m);
                }
                else if (valorDescuentoInput != 0)
                {
                    MessageBox.Show("El porcentaje de descuento debe estar entre 0 y 100.", "Porcentaje Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (tbx_DiscountValue != null) tbx_DiscountValue.Clear();
                    descuentoCalculado = 0;
                }
            }
            else
            {
                descuentoCalculado = valorDescuentoInput;
            }

            if (descuentoCalculado > currentSubtotalVenta && currentSubtotalVenta > 0)
            {
                MessageBox.Show("El descuento aplicado es mayor al subtotal de la venta. Se ajustará al subtotal.", "Descuento Excesivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                descuentoCalculado = currentSubtotalVenta;
                if (tbx_DiscountValue != null && cbx_DiscountType.SelectedItem?.ToString() == "Monto Fijo ($)")
                {
                    tbx_DiscountValue.Text = descuentoCalculado.ToString("N2", CultureInfo.InvariantCulture);
                }
            }
            else if (descuentoCalculado < 0)
            {
                MessageBox.Show("El descuento no puede ser negativo.", "Descuento Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                descuentoCalculado = 0;
                if (tbx_DiscountValue != null) tbx_DiscountValue.Clear();
            }

            if (lbl_CalculatedDiscountAmount != null)
            {
                lbl_CalculatedDiscountAmount.Text = descuentoCalculado.ToString("C2");
            }

            if (tbx_SubTVent != null) tbx_SubTVent.Text = currentSubtotalVenta.ToString("C2");
            if (tbx_Total != null) tbx_Total.Text = (currentSubtotalVenta - descuentoCalculado).ToString("C2");
        }

        private void tbx_DiscountValue_TextChanged(object sender, EventArgs e)
        {
            CalculateSaleTotals();
        }

        private void ibtn_Register_Click(object sender, EventArgs e)
        {
            if (_clienteSeleccionado == null)
            { MessageBox.Show("Por favor, seleccione un cliente.", "Cliente Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (saleDetailsDataTable.Rows.Count == 0)
            { MessageBox.Show("Debe agregar al menos un producto a la venta.", "Detalle Vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (cbx_State.SelectedValue == null || !(cbx_State.SelectedValue is int) || ((int)cbx_State.SelectedValue) <= 0)
            { MessageBox.Show("Por favor, seleccione un estado para la venta.", "Estado Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            decimal descuentoFinalAplicado = 0m;
            if (lbl_CalculatedDiscountAmount != null && decimal.TryParse(lbl_CalculatedDiscountAmount.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal descCalculado))
            {
                descuentoFinalAplicado = descCalculado;
            }

            Venta venta = new Venta // Crear una nueva instancia de Venta
            {
                FechaOcurrencia = DateTime.Parse(tbx_DateV.Text),
                ClienteId = _clienteSeleccionado.IdCliente,
                VendedorId = _idVendedorTabla, // Usar el ID de la tabla 'sellers'
                EstadoId = (int)cbx_State.SelectedValue,
                Observaciones = tbx_Observaciones.Text.Trim(),
                Descuento = descuentoFinalAplicado,
                DetallesVenta = new List<DetalleVenta>() // Inicializar la colección de detalles
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
            // Calcular Subtotal y Total aquí, justo antes de enviar al servicio
            venta.Subtotal = venta.DetallesVenta.Sum(d => d.TotalLinea);
            venta.Total = venta.Subtotal - venta.Descuento;


            try
            {
                if (_ventaService == null) { MessageBox.Show("Servicio de ventas no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                string resultado = _ventaService.RegistrarNuevaVenta(venta, _idVendedorTabla); // Pasar el IdVendedorTabla

                MessageBox.Show(resultado, "Registrar Venta", MessageBoxButtons.OK,
                                resultado.ToLower().Contains("exitosamente") ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (resultado.ToLower().Contains("exitosamente"))
                {

                    Venta ventaCompletaParaFactura = _ventaService.ObtenerVentaPorId(venta.IdVenta);

                    if (ventaCompletaParaFactura != null)
                    {
                        string nombreEmisor = SessionManager.CurrentUser?.NombreUsuario ?? "Vendedor Desconocido";
                        if (SessionManager.CurrentUser is Vendedor vend) // Para un nombre más amigable
                        {
                            nombreEmisor = $"{vend.Nombre} {vend.Apellido}".Trim();
                            if (string.IsNullOrWhiteSpace(nombreEmisor)) nombreEmisor = vend.NombreUsuario;
                        }

                        DialogResult dr = MessageBox.Show("Venta registrada exitosamente. ¿Desea generar el comprobante en PDF?",
                                                          "Generar Comprobante",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            ReportePdfExporter exporter = new ReportePdfExporter();
                            exporter.GenerarFacturaVentaPdf(ventaCompletaParaFactura, nombreEmisor);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo obtener la información completa de la venta para generar la factura.", "Error Factura", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    ResetSaleFormFields();
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error al registrar venta: {ex.Message}", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ResetSaleFormFields()
        {
            _clienteSeleccionado = null;
            if (tbx_NumDoc != null) tbx_NumDoc.Clear();
            if (tbx_NomClient != null) tbx_NomClient.Clear();

            if (tbx_Product != null)
            {
                tbx_Product.Clear();
                tbx_Product.Tag = null;
            }
            if (tbx_UniPrice != null) tbx_UniPrice.Clear();
            if (nud_Cantidad != null) nud_Cantidad.Value = 0;
            if (tbx_SubTIItem != null) tbx_SubTIItem.Clear();

            if (cbx_DiscountType != null && cbx_DiscountType.Items.Count > 0) cbx_DiscountType.SelectedIndex = 0;
            if (tbx_DiscountValue != null) tbx_DiscountValue.Clear();
            if (lbl_CalculatedDiscountAmount != null) lbl_CalculatedDiscountAmount.Text = (0m).ToString("C2");

            if (tbx_SubTVent != null) tbx_SubTVent.Clear();
            if (tbx_Total != null) tbx_Total.Clear();
            if (tbx_Observaciones != null) tbx_Observaciones.Clear();
            if (cbx_State != null && cbx_State.Items.Count > 0) cbx_State.SelectedIndex = 0;

            if (saleDetailsDataTable != null) saleDetailsDataTable.Clear();
            CalculateSaleTotals();
            _stockDisponibleDelProductoSeleccionado = 0;

            if (tbx_DateV != null) tbx_DateV.Text = DateTime.Now.ToShortDateString();
        }

        private void ibtn_Clear_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("¿Está seguro que desea limpiar todos los campos del formulario de venta?",
                                     "Confirmar Limpieza",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                ResetSaleFormFields();
            }
        }

        private void ibtn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}