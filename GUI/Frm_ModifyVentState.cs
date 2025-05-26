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
        // Propiedad para almacenar el ID de la venta que se está modificando.
        // Puedes añadir más propiedades si necesitas pasar más datos (ej. estado actual).
        public int SaleId { get; private set; }

        public Frm_ModifyVentState()
        {
            InitializeComponent();
            // Configuración por defecto para un formulario de diálogo.
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Borde fijo para diálogos
            this.StartPosition = FormStartPosition.CenterParent; // Centrar respecto al padre

            // Asignar eventos a los botones.
            ibtn_Modify.Click += ibtn_Modify_Click;
            ibtn_Cancel.Click += ibtn_Cancel_Click;

            // Inicializar ComboBox de estados de venta.
            cbx_VentState.Items.Add("-- Seleccione un estado --");
            cbx_VentState.Items.Add("PENDIENTE");
            cbx_VentState.Items.Add("COMPLETADA");
            cbx_VentState.Items.Add("CANCELADA");
            cbx_VentState.SelectedIndex = 0; // Seleccionar la opción por defecto
        }

        // Constructor para recibir información de la venta (opcional, si necesitas precargar campos).
        public Frm_ModifyVentState(int saleId, DateTime saleDate, decimal saleTotal, string currentStatus) : this()
        {
            SaleId = saleId;
            tbx_Date.Text = saleDate.ToShortDateString(); // Asumiendo formato de fecha corta
            tbx_Code.Text = saleId.ToString(); // Usar el ID como código de ejemplo
            tbx_TotVent.Text = saleTotal.ToString("C"); // Formato de moneda

            // Seleccionar el estado actual en el ComboBox.
            int index = cbx_VentState.FindStringExact(currentStatus);
            if (index != -1)
            {
                cbx_VentState.SelectedIndex = index;
            }
            else
            {
                cbx_VentState.SelectedIndex = 0; // Si no encuentra el estado, selecciona el por defecto
            }
        }

        // Método para precargar la información de la venta (si no se usa el constructor con parámetros).
        public void SetSaleInfo(int saleId, DateTime saleDate, decimal saleTotal, string currentStatus)
        {
            SaleId = saleId;
            tbx_Date.Text = saleDate.ToShortDateString();
            tbx_Code.Text = saleId.ToString();
            tbx_TotVent.Text = saleTotal.ToString("C");

            int index = cbx_VentState.FindStringExact(currentStatus);
            if (index != -1)
            {
                cbx_VentState.SelectedIndex = index;
            }
            else
            {
                cbx_VentState.SelectedIndex = 0;
            }
        }

        // Evento Click del botón "Guardar cambios".
        private void ibtn_Modify_Click(object sender, EventArgs e)
        {
            // --- Lógica placeholder para guardar los cambios de estado de la venta ---
            string newStatus = cbx_VentState.SelectedItem?.ToString();

            if (cbx_VentState.SelectedIndex == 0)
            {
                MessageBox.Show("Por favor, seleccione un estado de venta válido.", "Estado Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show($"Lógica para modificar el estado de la venta ID: {SaleId} a '{newStatus}'.", "Guardar Cambios (Placeholder)", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Aquí se llamaría a la capa BLL para actualizar el estado de la venta.
            // Ejemplo: BLL.SalesManager.UpdateSaleStatus(SaleId, newStatus);

            this.DialogResult = DialogResult.OK; // Indica que la operación fue exitosa
            this.Close(); // Cierra el formulario
        }

        // Evento Click del botón "Cancelar".
        private void ibtn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Indica que la operación fue cancelada
            this.Close(); // Cierra el formulario sin guardar cambios
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
//    public partial class Frm_ModifyVentState : Form
//    {
//        public Frm_ModifyVentState()
//        {
//            InitializeComponent();
//        }
//    }
//}
