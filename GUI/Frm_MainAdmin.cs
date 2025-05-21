using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices; // Ya no es necesario aquí, se movió a Frm_MainBase
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    // Frm_MainAdmin: Formulario principal para el rol de Administrador.
    // Hereda de Frm_MainBase para reutilizar la lógica común de la ventana y el menú.
    public partial class Frm_MainAdmin : Frm_MainBase
    {
        public Frm_MainAdmin()
        {
            InitializeComponent(); // Inicializa los componentes específicos de Frm_MainAdmin.Designer.cs
            // Establece el texto de la barra de título, heredado de Frm_MainBase
            label1.Text = "Demeter - Sesión de Administrador";
            // Ajusta la altura de los botones si es diferente a la base (en este caso, la base tiene 65 por defecto)
            // ICONBTN_HEIGHT = 65; // No es necesario si ya es el valor por defecto en la base.
        }

        // --- EVENTOS ESPECÍFICOS DE Frm_MainAdmin ---

        // Sobrescribe el método OnFormLoad de la clase base para añadir lógica específica
        protected override void OnFormLoad(object sender, EventArgs e)
        {
            // Lógica específica del administrador al cargar el formulario, si la hay.
            // Por ejemplo, cargar datos iniciales para el dashboard.
            // formSize ya se establece en la base.
        }

        // Sobrescribe el método OnFormResize de la clase base para añadir lógica específica
        protected override void OnFormResize(object sender, EventArgs e)
        {
            // Lógica específica del administrador al redimensionar el formulario, si la hay.
            // AdjustForm() ya se llama en la base.
        }

        // Evento Click para el botón de Cerrar Sesión.
        private void ibtn_CerrarSesion_Click(object sender, EventArgs e)
        {
            CerrarSesion(); // Llama al método CerrarSesion de la clase base.
        }

        // Los eventos para btn_Minimized_Click, btn_Maximized_Click, btn_Exit_Click,
        // btnMenu_Click, tim_PanelMenu_Tick y panelTitleBar_MouseDown
        // ya están definidos y manejados en Frm_MainBase.
    }
}
