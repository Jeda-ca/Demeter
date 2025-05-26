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
    // Frm_MainBase: Clase base para los formularios principales (Admin y Vendedor).
    // Contiene la lógica común para el comportamiento de la ventana (redimensionamiento, arrastre,
    // botones de control de ventana) y la animación del menú lateral.
    public partial class Frm_MainBase : Form
    {
        // Campos para el tamaño del borde de la ventana y el tamaño actual del formulario.
        protected int borderSize = 1;
        protected Size formSize;

        // Bandera para controlar el estado colapsado/expandido del menú.
        protected bool menuIsCollapsed = false;

        // Constantes para las dimensiones del menú, logo e IconButtons en ambos estados.
        protected const int PANEL_EXPANDED_WIDTH = 350;
        protected const int PANEL_COLLAPSED_WIDTH = 80;

        protected const int LOGO_EXPANDED_WIDTH = 350;
        protected const int LOGO_EXPANDED_HEIGHT = 300;
        protected const int LOGO_COLLAPSED_WIDTH = 80;
        protected const int LOGO_COLLAPSED_HEIGHT = 80 * LOGO_EXPANDED_HEIGHT / LOGO_EXPANDED_WIDTH;

        // La altura de los IconButtons puede variar entre Admin y Vendedor,
        // por lo que se define aquí y se puede ajustar en las clases derivadas si es necesario.
        // Para el Admin es 65, para el Vendedor es 100.
        protected int ICONBTN_HEIGHT = 65;
        protected const int ICONBTN_EXPANDED_WIDTH = 350;
        protected const int ICONBTN_COLLAPSED_WIDTH = PANEL_COLLAPSED_WIDTH;

        // Constructor de la clase base.
        public Frm_MainBase()
        {
            InitializeComponent(); // Inicializa los componentes definidos en Frm_MainBase.Designer.cs
            this.Padding = new Padding(borderSize); // Asigna el tamaño del borde a la ventana.
            this.Load += Frm_MainBase_Load; // Suscribe el evento Load.
            this.Resize += Frm_MainBase_Resize; // Suscribe el evento Resize.
        }

        // --- EVENTOS COMUNES ---

        // Evento Load: Se ejecuta al cargar el formulario.
        private void Frm_MainBase_Load(object sender, EventArgs e)
        {
            formSize = this.ClientSize; // Guarda el tamaño inicial del cliente del formulario.
            OnFormLoad(sender, e); // Llama a un método virtual para que las clases derivadas puedan añadir su lógica.
        }

        // Evento Resize: Se ejecuta al redimensionar el formulario.
        private void Frm_MainBase_Resize(object sender, EventArgs e)
        {
            AdjustForm(); // Ajusta el formulario según su estado (maximizado/normal).
            OnFormResize(sender, e); // Llama a un método virtual para que las clases derivadas puedan añadir su lógica.
        }

        // Evento Click del botón de menú (hamburguesa): Inicia la animación de colapsado/expansión.
        protected void btnMenu_Click(object sender, EventArgs e)
        {
            menuIsCollapsed = !menuIsCollapsed; // Cambia el estado del menú.
            tim_PanelMenu.Start(); // Inicia el temporizador para la animación.
        }

        // Evento Tick del temporizador del menú: Controla la animación de expansión/colapso del panel del menú.
        protected void tim_PanelMenu_Tick(object sender, EventArgs e)
        {
            btnMenu.Enabled = false; // Deshabilita el botón de menú durante la animación.
            int targetWidth = menuIsCollapsed ? PANEL_COLLAPSED_WIDTH : PANEL_EXPANDED_WIDTH;
            int step = 90; // Velocidad de la animación (ajustable).

            if (panelMenu.Width < targetWidth) // Si el menú se está expandiendo
            {
                panelMenu.Width += step;
                if (panelMenu.Width >= targetWidth)
                {
                    panelMenu.Width = targetWidth; // Asegura que no exceda el ancho objetivo.
                    tim_PanelMenu.Stop(); // Detiene el temporizador.
                    AdjustControls(); // Ajusta los controles internos del menú al finalizar.
                }
            }
            else // Si el menú se está colapsando
            {
                panelMenu.Width -= step;
                if (panelMenu.Width <= targetWidth)
                {
                    panelMenu.Width = targetWidth; // Asegura que no sea menor que el ancho objetivo.
                    tim_PanelMenu.Stop(); // Detiene el temporizador.
                    AdjustControls(); // Ajusta los controles internos del menú al finalizar.
                }
            }
            if (tim_PanelMenu.Enabled == false) btnMenu.Enabled = true; // Habilita el botón al finalizar la animación.
        }

        // Evento Click del botón de minimizar.
        protected void btn_Minimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Evento Click del botón de maximizar/restaurar.
        protected void btn_Maximized_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        // Evento Click del botón de cerrar aplicación.
        protected void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Evento MouseDown para arrastrar la ventana desde la barra de título.
        protected void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        

        // --- MÉTODOS PROTECTED VIRTUALES (para ser sobrescritos por las clases derivadas) ---

        // Método virtual para lógica adicional en el evento Load de los formularios derivados.
        protected virtual void OnFormLoad(object sender, EventArgs e) { }

        // Método virtual para lógica adicional en el evento Resize de los formularios derivados.
        protected virtual void OnFormResize(object sender, EventArgs e) { }

        // Método virtual para cerrar sesión.
        protected virtual void CerrarSesion()
        {
            var result = MessageBox.Show(
                "¿Está seguro que desea cerrar sesión?",   // texto
                "Confirmar",                               // caption
                MessageBoxButtons.YesNo,                   // botones
                MessageBoxIcon.Question                    // icono
            );

            if (result == DialogResult.Yes)
            {
                MessageBox.Show(
                    "Se ha cerrado la sesión.",            // texto
                    "Adiós",                               // caption
                    MessageBoxButtons.OK,                  // botones
                    MessageBoxIcon.Information             // icono
                );
                this.Close();  // Cierra el formulario actual.
            }
        }

        // --- MÉTODOS PRIVADOS/PROTECTED COMUNES ---

        // Ajusta el padding del formulario al maximizar/restaurar.
        protected void AdjustForm()
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized:
                    this.Padding = new Padding(8, 8, 8, 0);
                    break;
                case FormWindowState.Normal:
                    if (this.Padding.Top != borderSize)
                    {
                        this.Padding = new Padding(borderSize);
                    }
                    break;
            }
        }

        // Ajusta el tamaño y la posición de los controles del menú (logo, botones)
        // según el estado colapsado/expandido del menú.
        protected void AdjustControls()
        {
            // Ajustar logo
            if (menuIsCollapsed)
            {
                pictureBoxLogo.Size = new Size(LOGO_COLLAPSED_WIDTH, LOGO_COLLAPSED_HEIGHT);
                pictureBoxLogo.Location = new Point((PANEL_COLLAPSED_WIDTH - LOGO_COLLAPSED_WIDTH) / 2, btnMenu.Bottom + 5);
                pictureBoxLogo.Dock = DockStyle.None;
            }
            else
            {
                pictureBoxLogo.Size = new Size(LOGO_EXPANDED_WIDTH, LOGO_EXPANDED_HEIGHT);
                pictureBoxLogo.Location = new Point(0, 0);
                pictureBoxLogo.Dock = DockStyle.Top;
            }

            // Ajustar botón hamburguesa
            btnMenu.Dock = menuIsCollapsed ? DockStyle.Top : DockStyle.None;

            // Ajustar IconButtons
            foreach (IconButton ico in panelMenu.Controls.OfType<IconButton>())
            {
                if (ico == btnMenu) continue; // Ignorar el propio botón de menú

                ico.Size = new Size(menuIsCollapsed ? ICONBTN_COLLAPSED_WIDTH : ICONBTN_EXPANDED_WIDTH, ICONBTN_HEIGHT);

                if (menuIsCollapsed)
                {
                    ico.Text = ""; // Ocultar texto
                    ico.Padding = new Padding((PANEL_COLLAPSED_WIDTH - ico.IconSize) / 2, 0, 0, 0); // Centrar icono
                }
                else
                {
                    ico.Text = "  " + ico.Tag; // Mostrar texto del Tag
                    ico.Padding = new Padding(10, 0, 0, 0); // Padding normal
                }
            }
        }

        // --- FUNCIONES PARA ARRASTRAR Y REDIMENSIONAR LA VENTANA ---

        // Importaciones de funciones de la API de Windows para mover la ventana.
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        protected extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        protected extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        // Sobreescritura del método WndProc para permitir el redimensionamiento personalizado de la ventana.
        protected override void WndProc(ref Message m)
        {
            // Remueve los bordes y mantiene el snap window --- Función Aero-snap
            const int WM_NCLBUTTONDOWN = 0x0083;

            if (m.Msg == WM_NCLBUTTONDOWN && m.WParam.ToInt32() == 1)
            {
                return;
            }

            const int WM_NCHITTEST = 0x0084; // Win32, Notificación de entrada del ratón: Determina que parte de la ventana corresponde a un punto, permite redimensionar el formulario.
            const int resizeAreaSize = 10;

            // Valores de Resize/WM_NCHITTEST
            const int HTCLIENT = 1; // Representa el área cliente de la ventana
            const int HTLEFT = 10; // Borde izquierdo de una ventana, permite redimensionar horizontalmente hacia la izquierda
            const int HTRIGHT = 11; // Borde derecho de una ventana, permite redimensionar horizontalmente hacia la derecha
            const int HTTOP = 12; // Borde superior horizontal de una ventana, permite redimensionar verticalmente hacia arriba
            const int HTTOPLEFT = 13; // Esquina superior izquierda del borde de una ventana, permite redimensionar diagonalmente hacia la izquierda
            const int HTTOPRIGHT = 14; // Esquina superior derecha del borde de una ventana, permite redimensionar diagonalmente hacia la derecha
            const int HTBOTTOM = 15; // Borde inferior horizontal de una ventana, permite redimensionar verticalmente hacia abajo
            const int HTBOTTOMLEFT = 16; // Esquina inferior izquierda del borde de una ventana, permite redimensionar diagonalmente hacia la izquierda
            const int HTBOTTOMRIGHT = 17; // Esquina inferior derecha del borde de una ventana, permite redimensionar diagonalmente hacia la derecha

            if (m.Msg == WM_NCHITTEST) // Redimensiona el tamaño de la ventana
            { // Si el mensaje de la ventana es WM_NCHITTEST
                base.WndProc(ref m);
                if (this.WindowState == FormWindowState.Normal) // Redimensionar el formulario si está en estado normal
                {
                    if ((int)m.Result == HTCLIENT) // Si el resultado del mensaje indica que el puntero del mouse está en el área del cliente de la ventana
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32()); // Obtiene las coordenadas del punto en pantalla (coordenadas X y Y del puntero)
                        Point clientPoint = this.PointToClient(screenPoint); // Convierte el punto de pantalla a coordenadas del cliente
                        if (clientPoint.Y <= resizeAreaSize) // Si el puntero está en la parte superior del formulario (dentro del área de redimensionamiento)
                        {
                            if (clientPoint.X <= resizeAreaSize) // Si el puntero está en la coordenada X=0 o menor que el tamaño del área de redimensionamiento (X=10)
                                m.Result = (IntPtr)HTTOPLEFT; // Redimensionar en diagonal hacia la izquierda
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize)) // Si el puntero está en la coordenada X=11 o menor que el ancho del formulario (X=ancho del formulario - área de redimensionamiento)
                                m.Result = (IntPtr)HTTOP; // Redimensionar verticalmente hacia arriba
                            else // Redimensionar en diagonal hacia la derecha
                                m.Result = (IntPtr)HTTOPRIGHT;
                        }
                        else if (clientPoint.Y <= (this.Size.Height - resizeAreaSize)) // Si el puntero está dentro del formulario en la coordenada Y (descontando el tamaño del área de redimensionamiento)
                        {
                            if (clientPoint.X <= resizeAreaSize) // Redimensionar horizontalmente hacia la izquierda
                                m.Result = (IntPtr)HTLEFT;
                            else if (clientPoint.X > (this.Width - resizeAreaSize)) // Redimensionar horizontalmente hacia la derecha
                                m.Result = (IntPtr)HTRIGHT;
                        }
                        else
                        {
                            if (clientPoint.X <= resizeAreaSize) // Redimensionar en diagonal hacia la izquierda
                                m.Result = (IntPtr)HTBOTTOMLEFT;
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize)) // Redimensionar verticalmente hacia abajo
                                m.Result = (IntPtr)HTBOTTOM;
                            else // Redimensionar en diagonal hacia la derecha
                                m.Result = (IntPtr)HTBOTTOMRIGHT;
                        }
                    }
                }
                return;
            }

            base.WndProc(ref m);
        }
    }
}
