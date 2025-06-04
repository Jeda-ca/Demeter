using ENTITY;
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
    public partial class Frm_ViewSaleDetail : Form
    {
        private readonly Venta _ventaAMostrar;

        // Constructor que recibe el objeto Venta
        public Frm_ViewSaleDetail(Venta venta)
        {
            InitializeComponent();
            _ventaAMostrar = venta ?? throw new ArgumentNullException(nameof(venta));
            this.Text = $"Detalle de Venta - ID: {venta.IdVenta}"; // Título del formulario
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            // Configurar el botón de cerrar (asumiendo que tienes un botón llamado ibtn_Close)
            if (ibtn_Close != null)
            {
                ibtn_Close.Click += (sender, e) => this.Close();
            }
        }

        private void Frm_ViewSaleDetail_Load(object sender, EventArgs e)
        {
            if (_ventaAMostrar != null)
            {
                LoadSaleHeaderData();
                LoadSaleItemsDataGrid();
            }
            else
            {
                MessageBox.Show("No se proporcionó información de la venta para mostrar.", "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new MethodInvoker(this.Close));
            }
        }

        private void LoadSaleHeaderData()
        {
            // Asumiendo los nombres de tus TextBoxes del Frm_ViewSaleDetail.Designer.cs
            // Si los nombres son diferentes, ajústalos aquí.
            if (tbx_CodeVenta != null) tbx_CodeVenta.Text = _ventaAMostrar.IdVenta.ToString();
            if (tbx_DateVenta != null) tbx_DateVenta.Text = _ventaAMostrar.FechaOcurrencia.ToString("dd/MM/yyyy HH:mm");

            if (tbx_NumDoc != null && _ventaAMostrar.Cliente != null) tbx_NumDoc.Text = _ventaAMostrar.Cliente.NumeroDocumento;
            else if (tbx_NumDoc != null) tbx_NumDoc.Text = "N/A";

            if (tbx_NomClient != null && _ventaAMostrar.Cliente != null) tbx_NomClient.Text = $"{_ventaAMostrar.Cliente.Nombre} {_ventaAMostrar.Cliente.Apellido}";
            else if (tbx_NomClient != null) tbx_NomClient.Text = "N/A";

            // Para el vendedor, necesitarías cargar la información del vendedor si no viene en _ventaAMostrar.Vendedor
            // Por ahora, asumimos que Vendedor.CodigoVendedor y Vendedor.Nombre están disponibles.
            // Si no, tendrías que hacer una llamada a VendedorService.
            // Por ahora, usaré un placeholder si no está cargado.
            // En Frm_GSalesAdmin, el Vendedor se carga. En Frm_GSalesVendor, puede que no.
            if (groupBox2 != null && _ventaAMostrar.Vendedor != null) // Asumiendo que groupBox2 es para info de producto/vendedor
            {
                // Podrías tener un tbx_VendedorCode y tbx_VendedorName
                // Ejemplo:
                // tbx_VendedorCode.Text = _ventaAMostrar.Vendedor.CodigoVendedor;
                // tbx_VendedorName.Text = $"{_ventaAMostrar.Vendedor.Nombre} {_ventaAMostrar.Vendedor.Apellido}";
                // Por ahora, como no veo esos textboxes específicos para vendedor en tu designer, lo omito.
            }


            if (tbx_SubTVenta != null) tbx_SubTVenta.Text = _ventaAMostrar.Subtotal.ToString("C2", CultureInfo.CurrentCulture);

            // Para el tipo de descuento y valor del descuento general
            // Esto es un poco más complejo porque guardamos el monto final del descuento.
            // Podríamos inferir si fue porcentaje si el monto no es "redondo" o si tenemos más info.
            // Por simplicidad, mostraremos el monto y dejaremos el tipo como "Aplicado".
            if (tbx_TipoDesc != null) tbx_TipoDesc.Text = "Aplicado"; // O podrías intentar deducirlo si guardaras el tipo.
            if (tbx_DiscountValue != null) tbx_DiscountValue.Text = _ventaAMostrar.Descuento.ToString("N2", CultureInfo.InvariantCulture); // Valor del descuento
            if (lbl_DiscountTypeSuffix != null) lbl_DiscountTypeSuffix.Text = "$"; // Asumir monto fijo si no se guarda el tipo
            if (lbl_CalculatedDiscountAmount != null) lbl_CalculatedDiscountAmount.Text = _ventaAMostrar.Descuento.ToString("C2", CultureInfo.CurrentCulture);


            if (tbx_Total != null) tbx_Total.Text = _ventaAMostrar.Total.ToString("C2", CultureInfo.CurrentCulture);
            if (tbx_StateVenta != null && _ventaAMostrar.EstadoVenta != null) tbx_StateVenta.Text = _ventaAMostrar.EstadoVenta.Nombre;
            else if (tbx_StateVenta != null) tbx_StateVenta.Text = "N/A";

            if (tbx_Observaciones != null) tbx_Observaciones.Text = _ventaAMostrar.Observaciones;

            // Los campos tbx_Product, tbx_UniPrice, tbx_Quantity, tbx_SubTIItem son para el detalle de un ítem
            // y no para el encabezado de la venta, así que los dejaremos vacíos o los ocultarás si están en la sección de encabezado.
            // En tu Frm_ViewSaleDetail.Designer.cs, estos parecen estar en un groupBox2 "Información de producto".
            // Los limpiaremos ya que este formulario es para ver el detalle completo, no para editar un ítem.
            if (tbx_Product != null) tbx_Product.Clear();
            if (tbx_UniPrice != null) tbx_UniPrice.Clear();
            if (tbx_Quantity != null) tbx_Quantity.Clear();
            if (tbx_SubTIItem != null) tbx_SubTIItem.Clear();
        }

        private void LoadSaleItemsDataGrid()
        {
            if (dgv_SaleDetail == null) return;

            DataTable dtItems = new DataTable();
            // Columnas basadas en lo que se guarda en DetalleVenta y lo que se mostró en Frm_AddSaleVendor
            dtItems.Columns.Add("Producto", typeof(string));
            dtItems.Columns.Add("Cantidad", typeof(int));
            dtItems.Columns.Add("PrecioUnitario", typeof(decimal)); // Este sería el PrecioUnitario guardado en DetalleVenta
            dtItems.Columns.Add("SubtotalItem", typeof(decimal));  // Este sería el TotalLinea guardado en DetalleVenta

            if (_ventaAMostrar.DetallesVenta != null && _ventaAMostrar.DetallesVenta.Any())
            {
                foreach (var detalle in _ventaAMostrar.DetallesVenta)
                {
                    // Asumimos que la entidad Producto dentro de DetalleVenta se carga.
                    // Si no, necesitarías obtener el nombre del producto usando detalle.ProductoId y _productoService.
                    string nombreProducto = detalle.Producto?.Nombre ?? $"Producto ID: {detalle.ProductoId}";
                    dtItems.Rows.Add(
                        nombreProducto,
                        detalle.Cantidad,
                        detalle.PrecioUnitario, // El precio unitario con el que se vendió (podría ser el original o con descuento de ítem si se implementó así)
                        detalle.TotalLinea      // El subtotal de esta línea de detalle
                    );
                }
            }

            dgv_SaleDetail.DataSource = dtItems;

            // Ajustar formato de columnas si es necesario
            if (dgv_SaleDetail.Columns["PrecioUnitario"] != null)
            {
                dgv_SaleDetail.Columns["PrecioUnitario"].HeaderText = "Precio Unit.";
                dgv_SaleDetail.Columns["PrecioUnitario"].DefaultCellStyle.Format = "C2";
            }
            if (dgv_SaleDetail.Columns["SubtotalItem"] != null)
            {
                dgv_SaleDetail.Columns["SubtotalItem"].HeaderText = "Subtotal Ítem";
                dgv_SaleDetail.Columns["SubtotalItem"].DefaultCellStyle.Format = "C2";
            }
            if (dgv_SaleDetail.Columns["Producto"] != null) dgv_SaleDetail.Columns["Producto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
