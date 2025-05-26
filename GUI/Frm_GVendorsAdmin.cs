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
    public partial class Frm_GVendorsAdmin : Form
    {
        private readonly IVendedorService _vendedorService;
        private readonly IUsuarioService _usuarioService;
        private readonly int _idAdminLogueado;

        public Frm_GVendorsAdmin(int idAdminLogueado)
        {
            InitializeComponent();
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            _idAdminLogueado = idAdminLogueado;

            if (_idAdminLogueado <= 0)
            {
                MessageBox.Show("Error: ID de administrador no válido. No se pueden realizar operaciones.", "Error de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BeginInvoke(new MethodInvoker(this.Close));
                return;
            }

            try
            {
                _vendedorService = new VendedorService();
                _usuarioService = new UsuarioService();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico al inicializar servicios: {ex.Message}", "Error de Inicialización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ibtn_Add.Enabled = false;
                ibtn_Modify.Enabled = false;
                ibtn_Delete.Enabled = false;
                ibtn_Buscar.Enabled = false;
            }
        }

        private void Frm_GVendorsAdmin_Load(object sender, EventArgs e)
        {
            if (_idAdminLogueado > 0)
            {
                CargarFiltrosComboBox();
                LoadVendorsData(true); // Cargar solo activos por defecto
            }
        }

        private void CargarFiltrosComboBox()
        {
            cbx_Buscar.Items.Clear();
            cbx_Buscar.Items.Add("-- Seleccione Criterio --");
            cbx_Buscar.Items.Add("Código Vendedor");
            cbx_Buscar.Items.Add("Nombre o Apellido");
            cbx_Buscar.Items.Add("Número de Documento");
            cbx_Buscar.Items.Add("Estado (Activo/Inactivo)"); // Este filtro permitirá ver inactivos
            cbx_Buscar.SelectedIndex = 0;
        }

        // Modificado para aceptar un parámetro que indique si se filtran solo activos
        private void LoadVendorsData(bool soloActivos = false)
        {
            try
            {
                if (_vendedorService == null) return;

                IEnumerable<Vendedor> vendedores;
                if (soloActivos)
                {
                    // Asumiendo que VendedorService tiene o puede tener un método para esto,
                    // o filtramos aquí. Por simplicidad, filtramos aquí por ahora.
                    // Idealmente, VendedorService tendría ObtenerVendedoresActivos().
                    vendedores = _vendedorService.ObtenerTodosLosVendedores().Where(v => v.Activo).ToList();
                }
                else
                {
                    vendedores = _vendedorService.ObtenerTodosLosVendedores().ToList();
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("IdVendedor", typeof(int));
                dt.Columns.Add("IdUsuario", typeof(int));
                dt.Columns.Add("CodigoVendedor", typeof(string));
                dt.Columns.Add("NombreCompleto", typeof(string));
                dt.Columns.Add("TipoDocumento", typeof(string));
                dt.Columns.Add("NumeroDocumento", typeof(string));
                dt.Columns.Add("Telefono", typeof(string));
                dt.Columns.Add("Estado", typeof(string)); // Se mantiene para claridad si se buscan inactivos

                foreach (var vendedor in vendedores)
                {
                    dt.Rows.Add(
                        vendedor.IdVendedor,
                        vendedor.IdUsuario,
                        vendedor.CodigoVendedor,
                        $"{vendedor.Nombre} {vendedor.Apellido}",
                        vendedor.TipoDocumento?.Nombre,
                        vendedor.NumeroDocumento,
                        vendedor.Telefono,
                        vendedor.Activo ? "Activo" : "Inactivo"
                    );
                }

                dgv_ListaVendedores.DataSource = dt;

                if (dgv_ListaVendedores.Columns["IdVendedor"] != null)
                    dgv_ListaVendedores.Columns["IdVendedor"].Visible = false;
                if (dgv_ListaVendedores.Columns["IdUsuario"] != null)
                    dgv_ListaVendedores.Columns["IdUsuario"].Visible = false;

                // Ocultar la columna Estado si solo estamos mostrando activos por defecto
                // y no se ha realizado una búsqueda específica por estado.
                if (soloActivos && (cbx_Buscar.SelectedItem?.ToString() != "Estado (Activo/Inactivo)"))
                {
                    if (dgv_ListaVendedores.Columns["Estado"] != null)
                        dgv_ListaVendedores.Columns["Estado"].Visible = false;
                }
                else
                {
                    if (dgv_ListaVendedores.Columns["Estado"] != null)
                        dgv_ListaVendedores.Columns["Estado"].Visible = true;
                }


            }
            catch (ApplicationException appEx)
            {
                MessageBox.Show(appEx.Message, "Error de Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos de vendedores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibtn_Add_Click(object sender, EventArgs e)
        {
            using (Frm_AddVendorAdmin frmAdd = new Frm_AddVendorAdmin(_idAdminLogueado))
            {
                if (frmAdd.ShowDialog() == DialogResult.OK)
                {
                    LoadVendorsData(true); // Recargar solo activos
                }
            }
        }

        private void ibtn_Modify_Click(object sender, EventArgs e)
        {
            if (dgv_ListaVendedores.SelectedRows.Count > 0)
            {
                try
                {
                    int idVendedorSeleccionado = Convert.ToInt32(dgv_ListaVendedores.SelectedRows[0].Cells["IdVendedor"].Value);
                    if (_vendedorService == null) { MessageBox.Show("Servicio no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                    Vendedor vendedorAModificar = _vendedorService.ObtenerVendedorPorId(idVendedorSeleccionado);

                    if (vendedorAModificar != null)
                    {
                        using (Frm_ModifyVendorAdmin frmModify = new Frm_ModifyVendorAdmin(vendedorAModificar, _idAdminLogueado))
                        {
                            if (frmModify.ShowDialog() == DialogResult.OK)
                            {
                                LoadVendorsData(true); // Recargar solo activos
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo encontrar el vendedor seleccionado para modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al preparar modificación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un vendedor de la lista para modificar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ibtn_Delete_Click(object sender, EventArgs e) // Realmente cambia el estado Activo/Inactivo
        {
            if (dgv_ListaVendedores.SelectedRows.Count > 0)
            {
                try
                {
                    int idVendedor = Convert.ToInt32(dgv_ListaVendedores.SelectedRows[0].Cells["IdVendedor"].Value);
                    string nombreVendedor = dgv_ListaVendedores.SelectedRows[0].Cells["NombreCompleto"].Value.ToString();
                    string estadoActualStr = dgv_ListaVendedores.SelectedRows[0].Cells["Estado"].Value.ToString();
                    bool estaActivo = estadoActualStr.Equals("Activo", StringComparison.OrdinalIgnoreCase);

                    string accion = estaActivo ? "inactivar" : "reactivar";
                    DialogResult confirmacion = MessageBox.Show($"¿Está seguro que desea {accion} al vendedor '{nombreVendedor}'?", $"Confirmar {accion}", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirmacion == DialogResult.Yes)
                    {
                        if (_vendedorService == null) { MessageBox.Show("Servicio no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                        string resultado = _vendedorService.CambiarEstadoActividadVendedor(idVendedor, !estaActivo, _idAdminLogueado);
                        MessageBox.Show(resultado, "Cambio de Estado", MessageBoxButtons.OK,
                                        resultado.ToLower().Contains("exitosamente") || resultado.ToLower().Contains("cambiado") ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                        LoadVendorsData(true); // Recargar solo activos después de cambiar estado
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cambiar estado del vendedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un vendedor de la lista.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ibtn_Buscar_Click(object sender, EventArgs e)
        {
            string criterio = cbx_Buscar.SelectedItem?.ToString();
            string textoBusqueda = tbx_Busqueda.Text.Trim();
            IEnumerable<Vendedor> vendedoresFiltradosResultado = new List<Vendedor>();

            if (string.IsNullOrEmpty(criterio) || criterio == "-- Seleccione Criterio --")
            {
                LoadVendorsData(true); // Carga solo activos si no hay criterio específico
                return;
            }
            if (_vendedorService == null) { MessageBox.Show("Servicio no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            bool mostrarColumnaEstado = false;

            try
            {
                var todosLosVendedores = _vendedorService.ObtenerTodosLosVendedores(); // Obtener todos para filtrar en memoria

                switch (criterio)
                {
                    case "Código Vendedor":
                        if (!string.IsNullOrWhiteSpace(textoBusqueda))
                        {
                            // La búsqueda por código debe ser exacta y puede incluir activos o inactivos
                            Vendedor vendedorPorCodigo = todosLosVendedores.FirstOrDefault(v => v.CodigoVendedor.Equals(textoBusqueda, StringComparison.OrdinalIgnoreCase));
                            if (vendedorPorCodigo != null) vendedoresFiltradosResultado = new List<Vendedor> { vendedorPorCodigo };
                            mostrarColumnaEstado = true; // Mostrar estado si se busca por código
                        }
                        else { LoadVendorsData(true); return; }
                        break;
                    case "Nombre o Apellido":
                        if (!string.IsNullOrWhiteSpace(textoBusqueda))
                            vendedoresFiltradosResultado = todosLosVendedores.Where(v =>
                                (v.Nombre.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                 v.Apellido.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0) && v.Activo // Por defecto busca activos
                            ).ToList();
                        else { LoadVendorsData(true); return; }
                        break;
                    case "Número de Documento":
                        if (!string.IsNullOrWhiteSpace(textoBusqueda))
                            vendedoresFiltradosResultado = todosLosVendedores.Where(v => v.NumeroDocumento.Contains(textoBusqueda) && v.Activo).ToList();
                        else { LoadVendorsData(true); return; }
                        break;
                    case "Estado (Activo/Inactivo)":
                        mostrarColumnaEstado = true;
                        if (textoBusqueda.Equals("Activo", StringComparison.OrdinalIgnoreCase))
                            vendedoresFiltradosResultado = todosLosVendedores.Where(v => v.Activo).ToList();
                        else if (textoBusqueda.Equals("Inactivo", StringComparison.OrdinalIgnoreCase))
                            vendedoresFiltradosResultado = todosLosVendedores.Where(v => !v.Activo).ToList();
                        else if (string.IsNullOrWhiteSpace(textoBusqueda)) // Si el texto está vacío pero el filtro es Estado, mostrar todos.
                            vendedoresFiltradosResultado = todosLosVendedores.ToList();
                        else
                        {
                            MessageBox.Show("Para filtrar por estado, ingrese 'Activo', 'Inactivo' o deje el campo vacío para ver todos.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadVendorsData(true); return;
                        }
                        break;
                    default:
                        vendedoresFiltradosResultado = todosLosVendedores.Where(v => v.Activo).ToList(); // Por defecto, solo activos
                        break;
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("IdVendedor", typeof(int));
                dt.Columns.Add("IdUsuario", typeof(int));
                dt.Columns.Add("CodigoVendedor", typeof(string));
                dt.Columns.Add("NombreCompleto", typeof(string));
                dt.Columns.Add("TipoDocumento", typeof(string));
                dt.Columns.Add("NumeroDocumento", typeof(string));
                dt.Columns.Add("Telefono", typeof(string));
                dt.Columns.Add("Estado", typeof(string));

                foreach (var vendedor in vendedoresFiltradosResultado)
                {
                    dt.Rows.Add(
                        vendedor.IdVendedor,
                        vendedor.IdUsuario,
                        vendedor.CodigoVendedor,
                        $"{vendedor.Nombre} {vendedor.Apellido}",
                        vendedor.TipoDocumento?.Nombre,
                        vendedor.NumeroDocumento,
                        vendedor.Telefono,
                        vendedor.Activo ? "Activo" : "Inactivo"
                    );
                }
                dgv_ListaVendedores.DataSource = dt;
                if (dgv_ListaVendedores.Columns["IdVendedor"] != null)
                    dgv_ListaVendedores.Columns["IdVendedor"].Visible = false;
                if (dgv_ListaVendedores.Columns["IdUsuario"] != null)
                    dgv_ListaVendedores.Columns["IdUsuario"].Visible = false;

                if (dgv_ListaVendedores.Columns["Estado"] != null)
                    dgv_ListaVendedores.Columns["Estado"].Visible = mostrarColumnaEstado;


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar vendedores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibtn_Clear_Click(object sender, EventArgs e)
        {
            tbx_Busqueda.Clear();
            cbx_Buscar.SelectedIndex = 0;

            MessageBox.Show("Campos de búsqueda limpiados.", "Limpiar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}