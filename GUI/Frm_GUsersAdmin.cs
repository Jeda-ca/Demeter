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
    public partial class Frm_GUsersAdmin : Form
    {
        public Frm_GUsersAdmin()
        {
            InitializeComponent();

            // Configuración esencial para que este formulario pueda ser incrustado como un control:
            this.TopLevel = false; // Indica que no es una ventana de nivel superior independiente.
            this.FormBorderStyle = FormBorderStyle.None; // Elimina el borde y la barra de título.
            this.Dock = DockStyle.Fill; // Hace que el formulario llene el control contenedor.
        }
        private void Frm_GUsersAdmin_Load(object sender, EventArgs e) // Evento Load del formulario (sin lógica de carga de datos por ahora, según tu solicitud).
        {
            // Lógica para cargar datos de usuarios en el DataGridView, etc.
            // Por ahora, solo es un placeholder.
        }
    }
}
