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
    public partial class Frm_GUsersAdmin : Form
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IRolService _rolService; // Para el filtro por rol
        private readonly int _idAdminLogueado;
        private Usuario _usuarioSeleccionadoParaModificar = null; // Para guardar el usuario seleccionado

        public Frm_GUsersAdmin(int idAdminLogueado)
        {
            InitializeComponent();
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            _idAdminLogueado = idAdminLogueado;

            if (_idAdminLogueado <= 0)
            {
                MessageBox.Show("Error: ID de administrador no válido.", "Error de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new MethodInvoker(this.Close));
                return;
            }

            try
            {
                _usuarioService = new UsuarioService();
                _rolService = new RolService();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico al inicializar servicios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Deshabilitar controles
                if (ibtn_Buscar != null) ibtn_Buscar.Enabled = false;
                if (ibtn_Cambio != null) ibtn_Cambio.Enabled = false; // Botón para realizar cambio de credenciales
                if (cbx_Buscar != null) cbx_Buscar.Enabled = false;
            }
        }

        private void Frm_GUsersAdmin_Load(object sender, EventArgs e)
        {
            if (_idAdminLogueado > 0 && _usuarioService != null && _rolService != null)
            {
                CargarFiltrosComboBox();
                LoadUsersData();
                // Evento para cuando cambia la selección en la grilla
                if (dgv_ListaUsuarios != null)
                {
                    dgv_ListaUsuarios.SelectionChanged += Dgv_ListaUsuarios_SelectionChanged;
                }
            }
        }

        private void CargarFiltrosComboBox()
        {
            if (cbx_Buscar == null) return; // cbx_Buscar es el ComboBox principal de criterios
            cbx_Buscar.Items.Clear();
            cbx_Buscar.Items.Add("-- Seleccione Criterio --");
            cbx_Buscar.Items.Add("Rol");
            cbx_Buscar.Items.Add("Username");
            cbx_Buscar.Items.Add("Nombre Completo");
            cbx_Buscar.SelectedIndex = 0;
        }

        private void LoadUsersData(IEnumerable<Usuario> usuarios = null)
        {
            try
            {
                if (_usuarioService == null) { MessageBox.Show("Servicio de usuarios no inicializado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                if (usuarios == null)
                {
                    usuarios = _usuarioService.ObtenerTodosLosUsuariosDelSistema();
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("IdUsuario", typeof(int)); // Para uso interno
                dt.Columns.Add("NombreCompleto", typeof(string));
                dt.Columns.Add("Username", typeof(string));
                dt.Columns.Add("Rol", typeof(string));
                dt.Columns.Add("Estado", typeof(string)); // Añadido para ver si está activo

                foreach (var usuario in usuarios.OrderBy(u => u.NombreUsuario))
                {
                    dt.Rows.Add(
                        usuario.IdUsuario,
                        $"{usuario.Nombre} {usuario.Apellido}",
                        usuario.NombreUsuario,
                        usuario.Rol?.Nombre ?? "N/A", // Asume que la entidad Usuario tiene Rol poblado
                        usuario.Activo ? "Activo" : "Inactivo"
                    );
                }

                if (dgv_ListaUsuarios != null) // dgv_ListaUsuarios es tu DataGridView
                {
                    dgv_ListaUsuarios.SelectionChanged -= Dgv_ListaUsuarios_SelectionChanged; // Desuscribir temporalmente
                    dgv_ListaUsuarios.DataSource = dt;
                    if (dgv_ListaUsuarios.Columns["IdUsuario"] != null) dgv_ListaUsuarios.Columns["IdUsuario"].Visible = false;
                    dgv_ListaUsuarios.SelectionChanged += Dgv_ListaUsuarios_SelectionChanged; // Volver a suscribir
                    if (dgv_ListaUsuarios.Rows.Count > 0) dgv_ListaUsuarios.ClearSelection(); // Limpiar selección inicial
                    _usuarioSeleccionadoParaModificar = null; // Limpiar selección
                    LimpiarCamposCredenciales();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos de usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Dgv_ListaUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_ListaUsuarios.SelectedRows.Count > 0)
            {
                try
                {
                    int idUsuarioSeleccionado = Convert.ToInt32(dgv_ListaUsuarios.SelectedRows[0].Cells["IdUsuario"].Value);
                    _usuarioSeleccionadoParaModificar = _usuarioService.ObtenerUsuarioPorId(idUsuarioSeleccionado);

                    if (_usuarioSeleccionadoParaModificar != null)
                    {
                        // tbx_NameUser es el TextBox para el nuevo nombre de usuario
                        // tbx_PassUser es el TextBox para la nueva contraseña
                        if (tbx_NameUser != null) tbx_NameUser.Text = _usuarioSeleccionadoParaModificar.NombreUsuario;
                        if (tbx_PassUser != null) tbx_PassUser.Clear(); // No mostrar la contraseña actual
                    }
                    else
                    {
                        LimpiarCamposCredenciales();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al seleccionar usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimpiarCamposCredenciales();
                }
            }
            else
            {
                _usuarioSeleccionadoParaModificar = null;
                LimpiarCamposCredenciales();
            }
        }

        private void LimpiarCamposCredenciales()
        {
            if (tbx_NameUser != null) tbx_NameUser.Clear();
            if (tbx_PassUser != null) tbx_PassUser.Clear();
        }

        private void ibtn_Buscar_Click(object sender, EventArgs e)
        {
            string criterio = cbx_Buscar.SelectedItem?.ToString();
            string textoBusqueda = tbx_Busqueda.Text.Trim(); // tbx_Busqueda es el TextBox para el texto a buscar
            IEnumerable<Usuario> usuariosFiltrados = new List<Usuario>();

            if (_usuarioService == null) { MessageBox.Show("Servicio de usuarios no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            if (string.IsNullOrEmpty(criterio) || criterio == "-- Seleccione Criterio --")
            {
                if (string.IsNullOrWhiteSpace(textoBusqueda)) LoadUsersData(); // Carga todos si no hay criterio ni texto
                else criterio = "Nombre Completo"; // Búsqueda por defecto si hay texto
            }

            try
            {
                var todosLosUsuarios = _usuarioService.ObtenerTodosLosUsuariosDelSistema();

                switch (criterio)
                {
                    case "Rol":
                        if (!string.IsNullOrWhiteSpace(textoBusqueda))
                            usuariosFiltrados = todosLosUsuarios.Where(u => u.Rol?.Nombre.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0);
                        else { LoadUsersData(); return; }
                        break;
                    case "Username":
                        if (!string.IsNullOrWhiteSpace(textoBusqueda))
                            usuariosFiltrados = todosLosUsuarios.Where(u => u.NombreUsuario.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0);
                        else { LoadUsersData(); return; }
                        break;
                    case "Nombre Completo":
                        if (!string.IsNullOrWhiteSpace(textoBusqueda))
                            usuariosFiltrados = todosLosUsuarios.Where(u =>
                                (u.Nombre + " " + u.Apellido).IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                u.Nombre.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                u.Apellido.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0
                            );
                        else { LoadUsersData(); return; }
                        break;
                    default:
                        usuariosFiltrados = todosLosUsuarios;
                        break;
                }
                LoadUsersData(usuariosFiltrados);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ibtn_Cambio es el botón para "Realizar cambio" de credenciales
        private void ibtn_Cambio_Click(object sender, EventArgs e)
        {
            if (_usuarioSeleccionadoParaModificar == null)
            {
                MessageBox.Show("Por favor, seleccione un usuario de la lista para modificar sus credenciales.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nuevoUsername = tbx_NameUser.Text.Trim();
            string nuevaPassword = tbx_PassUser.Text; // No trimear contraseña

            if (string.IsNullOrWhiteSpace(nuevoUsername) && string.IsNullOrWhiteSpace(nuevaPassword))
            {
                MessageBox.Show("Debe ingresar un nuevo nombre de usuario o una nueva contraseña.", "Datos Insuficientes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(nuevoUsername)) // Si no se cambia el username, usar el actual
            {
                nuevoUsername = _usuarioSeleccionadoParaModificar.NombreUsuario;
            }


            // Opcional: Añadir un campo para confirmar la nueva contraseña
            // if (nuevaPassword != tbx_ConfirmPassword.Text) { MessageBox.Show("Las nuevas contraseñas no coinciden."); return; }

            try
            {
                if (_usuarioService == null) { MessageBox.Show("Servicio de usuarios no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                string resultado = _usuarioService.ModificarDatosBasicosUsuario(_usuarioSeleccionadoParaModificar.IdUsuario, nuevoUsername, nuevaPassword);

                MessageBox.Show(resultado, "Actualizar Credenciales", MessageBoxButtons.OK,
                                resultado.ToLower().Contains("actualizados") ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (resultado.ToLower().Contains("actualizados"))
                {
                    LoadUsersData(); // Recargar para ver cambios y limpiar selección
                }
            }
            catch (ApplicationException appEx)
            {
                MessageBox.Show($"Error de aplicación: {appEx.Message}", "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error inesperado: {ex.Message}", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}