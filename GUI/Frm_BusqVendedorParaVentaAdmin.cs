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
    public partial class Frm_BusqVendedorParaVentaAdmin : Form
    {
        public int SelectedSellerIdTabla { get; private set; } // PK de la tabla 'sellers'
        public int SelectedSellerUserId { get; private set; }  // PK de la tabla 'users'
        public string SelectedSellerCode { get; private set; }
        public string SelectedSellerName { get; private set; }

        private readonly IVendedorService _vendedorService;

        public Frm_BusqVendedorParaVentaAdmin()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;

            try
            {
                _vendedorService = new VendedorService();
                InitializeControls();
                LoadSellersData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar búsqueda de vendedores: {ex.Message}", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (ibtn_Buscar != null) ibtn_Buscar.Enabled = false;
                if (ibtn_OK != null) ibtn_OK.Enabled = false;
                if (ibtn_Clear != null) ibtn_Clear.Enabled = false;
            }
        }

        private void InitializeControls()
        {
            if (dgv_Sellers != null) dgv_Sellers.CellDoubleClick += dgv_Sellers_CellDoubleClick;

            if (cbx_Busq != null)
            {
                cbx_Busq.Items.Clear();
                cbx_Busq.Items.Add("-- Seleccione Criterio --");
                cbx_Busq.Items.Add("Código Vendedor");
                cbx_Busq.Items.Add("Nombre o Apellido");
                cbx_Busq.Items.Add("Número de Documento");
                cbx_Busq.SelectedIndex = 0;
            }
        }

        private void LoadSellersData(IEnumerable<Vendedor> vendedores = null)
        {
            try
            {
                if (_vendedorService == null)
                {
                    MessageBox.Show("Servicio de vendedores no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (dgv_Sellers != null) dgv_Sellers.DataSource = null;
                    return;
                }

                if (vendedores == null)
                {
                    // Cargar solo vendedores ACTIVOS
                    vendedores = _vendedorService.ObtenerTodosLosVendedores().Where(v => v.Activo).ToList();
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("IdVendedorTabla", typeof(int)); // PK de la tabla 'sellers'
                dt.Columns.Add("IdUsuario", typeof(int));     // PK de la tabla 'users'
                dt.Columns.Add("CodigoVendedor", typeof(string));
                dt.Columns.Add("NombreCompleto", typeof(string));
                dt.Columns.Add("NumeroDocumento", typeof(string));

                foreach (var vendedor in vendedores.OrderBy(v => v.Apellido).ThenBy(v => v.Nombre))
                {
                    dt.Rows.Add(
                        vendedor.IdVendedor, // PK de la tabla 'sellers'
                        vendedor.IdUsuario,  // PK de la tabla 'users'
                        vendedor.CodigoVendedor,
                        $"{vendedor.Nombre} {vendedor.Apellido}",
                        vendedor.NumeroDocumento
                    );
                }

                if (dgv_Sellers != null)
                {
                    dgv_Sellers.DataSource = dt;
                    if (dgv_Sellers.Columns["IdVendedorTabla"] != null) dgv_Sellers.Columns["IdVendedorTabla"].Visible = false;
                    if (dgv_Sellers.Columns["IdUsuario"] != null) dgv_Sellers.Columns["IdUsuario"].Visible = false;
                    if (dgv_Sellers.Columns["NombreCompleto"] != null) dgv_Sellers.Columns["NombreCompleto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar vendedores: {ex.Message}", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dgv_Sellers != null) dgv_Sellers.DataSource = null;
            }
        }

        private void ibtn_Buscar_Click(object sender, EventArgs e)
        {
            if (_vendedorService == null) { MessageBox.Show("Servicio de vendedores no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            string searchText = tbx_Busq.Text.Trim();
            string searchCriteria = cbx_Busq.SelectedItem?.ToString();
            IEnumerable<Vendedor> vendedoresFiltrados = new List<Vendedor>();

            if (cbx_Busq.SelectedIndex == 0 || string.IsNullOrWhiteSpace(searchText))
            {
                LoadSellersData(); // Carga todos los activos
                return;
            }

            try
            {
                var todosLosVendedoresActivos = _vendedorService.ObtenerTodosLosVendedores().Where(v => v.Activo);

                switch (searchCriteria)
                {
                    case "Código Vendedor":
                        Vendedor vendedorPorCodigo = _vendedorService.ObtenerVendedorPorCodigo(searchText);
                        if (vendedorPorCodigo != null && vendedorPorCodigo.Activo)
                        {
                            vendedoresFiltrados = new List<Vendedor> { vendedorPorCodigo };
                        }
                        break;
                    case "Nombre o Apellido":
                        vendedoresFiltrados = todosLosVendedoresActivos.Where(v =>
                            (v.Nombre.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                             v.Apellido.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                        ).ToList();
                        break;
                    case "Número de Documento":
                        // Asume que el servicio puede buscar por número de documento en todos los tipos
                        // o ajusta según tu implementación de ITipoDocumentoService si es necesario
                        vendedoresFiltrados = todosLosVendedoresActivos.Where(v => v.NumeroDocumento.Contains(searchText)).ToList();
                        break;
                    default:
                        vendedoresFiltrados = todosLosVendedoresActivos.ToList();
                        break;
                }
                LoadSellersData(vendedoresFiltrados);

                if (!vendedoresFiltrados.Any())
                {
                    MessageBox.Show("No se encontraron vendedores que coincidan con la búsqueda.", "Búsqueda sin Resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar vendedores: {ex.Message}", "Error de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ibtn_Clear_Click(object sender, EventArgs e)
        {
            if (tbx_Busq != null) tbx_Busq.Clear();
            if (cbx_Busq != null && cbx_Busq.Items.Count > 0) cbx_Busq.SelectedIndex = 0;
            LoadSellersData();
        }

        private void ibtn_OK_Click(object sender, EventArgs e)
        {
            SelectSellerAndClose();
        }

        private void dgv_Sellers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectSellerAndClose();
            }
        }

        private void SelectSellerAndClose()
        {
            if (dgv_Sellers.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow selectedRow = dgv_Sellers.SelectedRows[0];
                    SelectedSellerIdTabla = Convert.ToInt32(selectedRow.Cells["IdVendedorTabla"].Value);
                    SelectedSellerUserId = Convert.ToInt32(selectedRow.Cells["IdUsuario"].Value);
                    SelectedSellerCode = selectedRow.Cells["CodigoVendedor"].Value.ToString();
                    SelectedSellerName = selectedRow.Cells["NombreCompleto"].Value.ToString();

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al seleccionar vendedor: {ex.Message}", "Error de Selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un vendedor de la lista.", "No hay selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}