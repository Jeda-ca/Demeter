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
        // DataTable para almacenar los detalles de la venta temporalmente.
        private DataTable saleDetailsDataTable;

        public Frm_AddSaleVendor()
        {
            InitializeComponent();
            // Configuración por defecto para un formulario de diálogo.
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Borde fijo para diálogos
            this.StartPosition = FormStartPosition.CenterParent; // Centrar respecto al padre

            // Inicializar la fecha de la venta al día actual
            tbx_DateV.Text = DateTime.Now.ToShortDateString();

            // Inicializar ComboBox de estados de venta (para el estado final de la venta)
            cbx_State.Items.Add("-- Seleccione un estado --");
            cbx_State.Items.Add("PENDIENTE");
            cbx_State.Items.Add("COMPLETADA");
            cbx_State.Items.Add("CANCELADA");
            cbx_State.SelectedIndex = 0; // Seleccionar la opción por defecto

            // Inicializar el DataGridView para el detalle de la venta
            InitializeSaleDetailsDataGridView();
        }

        // Método para inicializar el DataGridView de detalles de venta
        private void InitializeSaleDetailsDataGridView()
        {
            saleDetailsDataTable = new DataTable();
            saleDetailsDataTable.Columns.Add("ID Producto", typeof(int));
            saleDetailsDataTable.Columns.Add("Producto", typeof(string));
            saleDetailsDataTable.Columns.Add("Cantidad", typeof(int));
            saleDetailsDataTable.Columns.Add("Precio Unitario", typeof(decimal));
            saleDetailsDataTable.Columns.Add("Subtotal Item", typeof(decimal));

            dgv_SaleDetail.DataSource = saleDetailsDataTable;

            // Opcional: Configurar estilos de columnas si es necesario
            dgv_SaleDetail.Columns["ID Producto"].Visible = false; // Ocultar ID si no es relevante para el usuario
            dgv_SaleDetail.Columns["Precio Unitario"].DefaultCellStyle.Format = "C"; // Formato de moneda
            dgv_SaleDetail.Columns["Subtotal Item"].DefaultCellStyle.Format = "C"; // Formato de moneda
        }

        // Método para limpiar todos los campos del formulario
        private void ClearFormFields()
        {
            tbx_NumDoc.Clear(); // Documento Cliente
            tbx_NomClient.Clear(); // Nombre Cliente
            tbx_Product.Clear(); // Producto
            tbx_UniPrice.Clear(); // Precio Unitario
            nud_Cantidad.Value = 0; // Cantidad
            tbx_SubTIItem.Clear(); // Subtotal Item
            tbx_Desc.Clear(); // Descuento
            tbx_SubTVent.Clear(); // Subtotal Venta
            tbx_Total.Clear(); // Total Venta
            tbx_Observaciones.Clear(); // Observaciones
            cbx_State.SelectedIndex = 0; // Estado de venta

            saleDetailsDataTable.Clear(); // Limpiar el DataGridView de detalles
        }

        // Evento Click del botón "Registrar" (placeholder para la lógica de registrar venta)
        private void ibtn_Register_Click(object sender, EventArgs e)
        {
            // --- Lógica placeholder para registrar una nueva venta ---
            // Validaciones básicas (pueden ser más robustas)
            if (string.IsNullOrWhiteSpace(tbx_NomClient.Text) || saleDetailsDataTable.Rows.Count == 0 || cbx_State.SelectedIndex == 0)
            {
                MessageBox.Show("Por favor, complete la información del cliente, añada productos a la venta y seleccione un estado.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Recopilar datos de la venta
            DateTime fechaVenta = DateTime.Parse(tbx_DateV.Text); // Convertir la fecha
            // int clientId = /* Obtener ID del cliente */;
            // int sellerId = /* Obtener ID del vendedor logueado */;
            decimal subtotalVenta = decimal.Parse(tbx_SubTVent.Text, System.Globalization.NumberStyles.Currency);
            decimal descuento = string.IsNullOrWhiteSpace(tbx_Desc.Text) ? 0m : decimal.Parse(tbx_Desc.Text);
            decimal totalVenta = decimal.Parse(tbx_Total.Text, System.Globalization.NumberStyles.Currency);
            string estadoVenta = cbx_State.SelectedItem.ToString();
            string observaciones = tbx_Observaciones.Text;

            // Aquí se llamaría a la capa BLL para registrar la venta y sus detalles.
            // Ejemplo: BLL.SalesManager.RegisterSale(fechaVenta, subtotalVenta, descuento, totalVenta, estadoVenta, observaciones, clientId, sellerId, saleDetailsDataTable);

            MessageBox.Show($"Lógica para registrar nueva venta:\nCliente: {tbx_NomClient.Text}\nTotal: {tbx_Total.Text}\nEstado: {estadoVenta}\nItems: {saleDetailsDataTable.Rows.Count}", "Registrar Venta (Placeholder)", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK; // Indica que la operación fue exitosa
            this.Close(); // Cierra el formulario
        }

        // Evento Click del botón "Limpiar"
        private void ibtn_Clear_Click(object sender, EventArgs e)
        {
            ClearFormFields();
        }

        // Evento Click del botón "Cancelar"
        private void ibtn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Indica que la operación fue cancelada
            this.Close(); // Cierra el formulario sin guardar cambios
        }

        // Evento Click del botón "Buscar Cliente" (ibtn_DocClient)
        private void ibtn_DocClient_Click(object sender, EventArgs e)
        {
            // Lógica para abrir el formulario de búsqueda de clientes (Frm_BusqClient)
            Frm_BusqClient frmBusqClient = new Frm_BusqClient();
            DialogResult result = frmBusqClient.ShowDialog();

            if (result == DialogResult.OK)
            {
                // --- Lógica para obtener el cliente seleccionado de Frm_BusqClient ---
                // Asumiendo que Frm_BusqClient tiene propiedades públicas para el cliente seleccionado
                // Ejemplo:
                // int selectedClientId = frmBusqClient.SelectedClientId;
                // string selectedClientDoc = frmBusqClient.SelectedClientDocument;
                // string selectedClientName = frmBusqClient.SelectedClientName;

                // Asignar los datos del cliente a los TextBoxes
                // tbx_NumDoc.Text = selectedClientDoc;
                // tbx_NomClient.Text = selectedClientName;
                MessageBox.Show("Cliente seleccionado (Placeholder).", "Buscar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbx_NumDoc.Text = "123456789"; // Ejemplo visual
                tbx_NomClient.Text = "Juan Pérez"; // Ejemplo visual
            }
        }

        // Evento Click del botón "Buscar Producto" (ibtn_NomProduct)
        private void ibtn_NomProduct_Click(object sender, EventArgs e)
        {
            // Lógica para abrir el formulario de búsqueda de productos (Frm_BusqProduct)
            Frm_BusqProduct frmBusqProduct = new Frm_BusqProduct();
            DialogResult result = frmBusqProduct.ShowDialog();

            if (result == DialogResult.OK)
            {
                // --- Lógica para obtener el producto seleccionado de Frm_BusqProduct ---
                // Asumiendo que Frm_BusqProduct tiene propiedades públicas para el producto seleccionado
                // Ejemplo:
                // int selectedProductId = frmBusqProduct.SelectedProductId;
                // string selectedProductName = frmBusqProduct.SelectedProductName;
                // decimal selectedProductPrice = frmBusqProduct.SelectedProductPrice;

                // Asignar los datos del producto a los TextBoxes
                // tbx_Product.Text = selectedProductName;
                // tbx_UniPrice.Text = selectedProductPrice.ToString("C"); // Formato de moneda
                MessageBox.Show("Producto seleccionado (Placeholder).", "Buscar Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbx_Product.Text = "Tomate Chonto"; // Ejemplo visual
                tbx_UniPrice.Text = "2800.00"; // Ejemplo visual
                nud_Cantidad.Value = 1; // Cantidad por defecto
                CalculateSubtotalItem(); // Recalcular subtotal del item
            }
        }

        // Evento Click del botón "Añadir Detalle de Venta" (ibtn_AddDV)
        private void ibtn_AddDV_Click(object sender, EventArgs e)
        {
            // --- Lógica para añadir un producto al detalle de la venta ---
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(tbx_Product.Text) || nud_Cantidad.Value <= 0 || string.IsNullOrWhiteSpace(tbx_UniPrice.Text))
            {
                MessageBox.Show("Por favor, seleccione un producto y especifique una cantidad válida.", "Detalle Incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener datos del producto y cantidad
            // int productId = /* Obtener ID del producto */;
            string productName = tbx_Product.Text;
            int quantity = (int)nud_Cantidad.Value;
            decimal unitPrice = decimal.Parse(tbx_UniPrice.Text);
            decimal subtotalItem = decimal.Parse(tbx_SubTIItem.Text);

            // Añadir fila al DataTable de detalles de venta
            saleDetailsDataTable.Rows.Add(/*productId,*/ productName, quantity, unitPrice, subtotalItem);

            // Recalcular totales de la venta
            CalculateSaleTotals();

            // Limpiar campos de producto para el siguiente detalle
            tbx_Product.Clear();
            tbx_UniPrice.Clear();
            nud_Cantidad.Value = 0;
            tbx_SubTIItem.Clear();
            MessageBox.Show("Producto añadido al detalle de venta (Placeholder).", "Detalle Añadido", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Método para calcular el subtotal de un item (cantidad * precio unitario)
        private void CalculateSubtotalItem()
        {
            if (decimal.TryParse(tbx_UniPrice.Text, out decimal unitPrice) && nud_Cantidad.Value > 0)
            {
                tbx_SubTIItem.Text = (unitPrice * nud_Cantidad.Value).ToString("N2"); // Formato numérico
            }
            else
            {
                tbx_SubTIItem.Text = "0.00";
            }
        }

        // Evento ValueChanged del NumericUpDown de Cantidad
        private void nud_Cantidad_ValueChanged(object sender, EventArgs e)
        {
            CalculateSubtotalItem();
        }

        // Evento TextChanged del TextBox de Precio Unitario (si no es de solo lectura)
        private void tbx_UniPrice_TextChanged(object sender, EventArgs e)
        {
            CalculateSubtotalItem();
        }

        // Método para calcular el subtotal y total de la venta
        private void CalculateSaleTotals()
        {
            decimal currentSubtotal = 0m;
            foreach (DataRow row in saleDetailsDataTable.Rows)
            {
                currentSubtotal += (decimal)row["Subtotal Item"];
            }

            decimal discount = string.IsNullOrWhiteSpace(tbx_Desc.Text) ? 0m : decimal.Parse(tbx_Desc.Text);

            tbx_SubTVent.Text = currentSubtotal.ToString("C"); // Subtotal de la venta
            tbx_Total.Text = (currentSubtotal - discount).ToString("C"); // Total de la venta
        }

        // Evento TextChanged del TextBox de Descuento
        private void tbx_Desc_TextChanged(object sender, EventArgs e)
        {
            CalculateSaleTotals(); // Recalcular totales al cambiar el descuento
        }
    }
}