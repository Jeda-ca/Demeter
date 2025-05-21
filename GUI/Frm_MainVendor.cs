using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    // Frm_MainVendor: Formulario principal para el rol de Vendedor.
    // Hereda de Frm_MainBase para reutilizar la lógica común de la ventana y el menú.
    public partial class Frm_MainVendor : Frm_MainBase
    {
        public Frm_MainVendor()
        {
            InitializeComponent(); // Inicializa los componentes específicos de Frm_MainVendor.Designer.cs
            // Establece el texto de la barra de título, heredado de Frm_MainBase
            label1.Text = "Demeter - Sesión de Vendedor";
            // Ajusta la altura de los botones para el vendedor (ahora 80)
            ICONBTN_HEIGHT = 80; // Sobrescribe el valor por defecto de la clase base a 80.
        }

        // --- EVENTOS ESPECÍFICOS DE Frm_MainVendor ---

        // Sobrescribe el método OnFormLoad de la clase base para añadir lógica específica
        protected override void OnFormLoad(object sender, EventArgs e)
        {
            // Lógica específica del vendedor al cargar el formulario, si la hay.
            // Asegúrate de llamar a AdjustControls() aquí si no se llama automáticamente
            // después de que el menú se expande/colapsa al inicio, para asegurar el layout correcto.
            // AdjustControls(); // Descomentar si es necesario para un ajuste inicial.
        }

        // Sobrescribe el método OnFormResize de la clase base para añadir lógica específica
        protected override void OnFormResize(object sender, EventArgs e)
        {
            // Lógica específica del vendedor al redimensionar el formulario, si la hay.
        }

        // Evento Click para el botón de Cerrar Sesión.
        private void ibtn_Signout_Click(object sender, EventArgs e)
        {
            CerrarSesion(); // Llama al método CerrarSesion de la clase base.
        }

        // Los eventos para btn_Minimized_Click, btn_Maximized_Click, btn_Exit_Click,
        // btnMenu_Click, tim_PanelMenu_Tick y panelTitleBar_MouseDown
        // ya están definidos y manejados en Frm_MainBase.
    }
}
