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
using System.Windows.Media.Animation;

namespace GUI
{
    public partial class Frm_MainAdmin : Form
    {
        private int borderSize = 1; // Tamaño de borde de la ventana
        private Size formSize;

        private bool menuIsCollapsed = false; // Se define una variable que verifica el estado del menú

        // Se definen variables constantes para el tamaño del menú (panelMenu), el logo (pictureBoxLogo) y los iconos (IconButton)
        private const int PANEL_EXPANDED_WIDTH = 350;
        private const int PANEL_COLLAPSED_WIDTH = 80; // Se iguala al ancho del botón hamburguesa (btnMenu)

        private const int LOGO_EXPANDED_WIDTH = 350;
        private const int LOGO_EXPANDED_HEIGHT = 300;
        private const int LOGO_COLLAPSED_WIDTH = 80;
        private const int LOGO_COLLAPSED_HEIGHT = 80 * LOGO_EXPANDED_HEIGHT / LOGO_EXPANDED_WIDTH; // Regla de tres simple para mantener la proporción del logo

        private const int ICONBTN_EXPANDED_WIDTH = 350;
        private const int ICONBTN_COLLAPSED_WIDTH = PANEL_COLLAPSED_WIDTH;
        private const int ICONBTN_HEIGHT = 65;
        public Frm_MainAdmin()
        {
            InitializeComponent();
            this.Padding = new Padding(borderSize); // Se le asigna el tamaño del borde a la ventana
            //CollapseMenu(); // Se colapsa el menú al iniciar la aplicación (opcional)
        }

        // FORMA DE ARRASTRE DESDE LA BARRA DE TÍTULO PERSONALIZADA
        // Se declaran las funciones para mover la ventana, haciendo uso de metodos de la clase System.Runtime.InteropServices
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e) // Evento para mover la ventana desde el panelTitleBar
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // FORMA DE REDIMENSIONAR
        protected override void WndProc(ref Message m)
        {
            // Remove border and keep snap window --- Función Aero-snap
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

        // EVENTOS
        private void Frm_MainAdmin_Load(object sender, EventArgs e) // Evento para cargar el formulario (Frm_MainAdmin) con el tamaño de la ventana
        {
            formSize = this.ClientSize;
        }
        private void Frm_MainAdmin_Resize(object sender, EventArgs e) // Evento para ajustar la ventana del formulario (Frm_MainAdmin)
        {
            AdjustForm();
        }
        private void btnMenu_Click(object sender, EventArgs e) // Evento para colapsar el menú (btnMenu)
        {
            CollapseMenu();
        }
        private void btn_Minimized_Click(object sender, EventArgs e) // Evento para minimizar la ventana (btn_Maximized)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btn_Maximized_Click(object sender, EventArgs e) // Evento para maximizar la ventana (btn_Maximized)
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
        private void btn_Exit_Click(object sender, EventArgs e) // Evento para cerrar la aplicación (btn_Exit)
        {
            Application.Exit();
        }

        // MÉTODOS PRIVADOS
        private void AdjustForm() // Ajusta el tamaño de la ventana según el estado (maximizado o normal)
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
        private void CollapseMenu() // Colapsa el menú (panelMenu) y ajusta el tamaño de los controles dentro de él
        {
            menuIsCollapsed = !menuIsCollapsed; // Flag del estado del menú (colapsado o expandido)

            // 1) Aplica anchos constantes según el flag
            panelMenu.Width = menuIsCollapsed ? PANEL_COLLAPSED_WIDTH : PANEL_EXPANDED_WIDTH;

            // 2) Ajustar logo
            if (menuIsCollapsed) // Colapsado: logo cuadrado y centrado en X, en Dock=Top
            {
                pictureBoxLogo.Size = new Size( LOGO_COLLAPSED_WIDTH, LOGO_COLLAPSED_HEIGHT );
                pictureBoxLogo.Location = new Point( (PANEL_COLLAPSED_WIDTH - LOGO_COLLAPSED_WIDTH) / 2, btnMenu.Bottom + 5 );
                pictureBoxLogo.Dock = DockStyle.None;
                pictureBoxLogo.Visible = true;
            }
            else // Expandido: vuelve a diseño original
            {
                pictureBoxLogo.Size = new Size( LOGO_EXPANDED_WIDTH, LOGO_EXPANDED_HEIGHT );
                pictureBoxLogo.Location = new Point(0, 0);
                pictureBoxLogo.Dock = DockStyle.Top;
                pictureBoxLogo.Visible = true;
            }

            // 3) Ajustar hamburguesa (btnMenu)
            btnMenu.Size = new Size(80, 45);
            btnMenu.Location = new Point(0, 0);
            btnMenu.Dock = menuIsCollapsed ? DockStyle.Top : DockStyle.None; // Se deja en la esquina superior izquierda

            // 4) Ajustar cada IconButton
            foreach (IconButton ico in panelMenu.Controls.OfType<IconButton>())
            {
                if (ico == btnMenu) continue;

                // Se conserva Y original, solo cambian el ancho y X=0
                int originalY = ico.Location.Y;
                ico.Size = new Size( menuIsCollapsed ? ICONBTN_COLLAPSED_WIDTH : ICONBTN_EXPANDED_WIDTH, ICONBTN_HEIGHT );
                ico.Location = new Point(0, originalY);

                if (menuIsCollapsed)
                {
                    // Muestra solo el icono centrado
                    ico.TextImageRelation = TextImageRelation.Overlay;
                    ico.Text = "";
                    int pad = (PANEL_COLLAPSED_WIDTH - ico.IconSize) / 2;
                    ico.Padding = new Padding(pad, 0, 0, 0);
                }
                else
                {
                    // Muestra el icono junto al texto alineado a la izquierda
                    ico.TextImageRelation = TextImageRelation.ImageBeforeText;
                    ico.Text = "  " + ico.Tag;
                    ico.Padding = new Padding(10, 0, 0, 0);
                }

                ico.Refresh();
            }
        }
    }
}

