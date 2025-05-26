namespace GUI
{
    partial class Frm_MainAdmin : Frm_MainBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_MainAdmin));
            this.ibtn_CerrarSesion = new FontAwesome.Sharp.IconButton();
            this.ibtn_Usuarios = new FontAwesome.Sharp.IconButton();
            this.ibtn_Ventas = new FontAwesome.Sharp.IconButton();
            this.ibtn_Vendedores = new FontAwesome.Sharp.IconButton();
            this.ibtn_Clientes = new FontAwesome.Sharp.IconButton();
            this.ibtn_Dashboard = new FontAwesome.Sharp.IconButton();
            this.ibtn_Reportes = new FontAwesome.Sharp.IconButton();
            this.ddm_Reportes = new RJCodeAdvance.RJControls.RJDropdownMenu(this.components);
            this.ventas = new System.Windows.Forms.ToolStripMenuItem();
            this.Ventas_general = new System.Windows.Forms.ToolStripMenuItem();
            this.Ventas_porVendedor = new System.Windows.Forms.ToolStripMenuItem();
            this.inventario = new System.Windows.Forms.ToolStripMenuItem();
            this.Inventario_general = new System.Windows.Forms.ToolStripMenuItem();
            this.Inventario_porVendedor = new System.Windows.Forms.ToolStripMenuItem();
            this.vendedores = new System.Windows.Forms.ToolStripMenuItem();
            this.clientes = new System.Windows.Forms.ToolStripMenuItem();
            this.ibtn_Manten = new FontAwesome.Sharp.IconButton();
            this.ddm_Mantenimiento = new RJCodeAdvance.RJControls.RJDropdownMenu(this.components);
            this.categoria = new System.Windows.Forms.ToolStripMenuItem();
            this.producto = new System.Windows.Forms.ToolStripMenuItem();
            this.panelTitleBar.SuspendLayout();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.ddm_Reportes.SuspendLayout();
            this.ddm_Mantenimiento.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.Margin = new System.Windows.Forms.Padding(4);
            this.panelTitleBar.Size = new System.Drawing.Size(1940, 41);
            // 
            // btn_Minimized
            // 
            this.btn_Minimized.FlatAppearance.BorderSize = 0;
            this.btn_Minimized.Location = new System.Drawing.Point(1805, 0);
            this.btn_Minimized.Margin = new System.Windows.Forms.Padding(4);
            // 
            // btn_Maximized
            // 
            this.btn_Maximized.FlatAppearance.BorderSize = 0;
            this.btn_Maximized.Location = new System.Drawing.Point(1850, 0);
            this.btn_Maximized.Margin = new System.Windows.Forms.Padding(4);
            // 
            // btn_Exit
            // 
            this.btn_Exit.FlatAppearance.BorderSize = 0;
            this.btn_Exit.Location = new System.Drawing.Point(1895, 0);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(4);
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.ibtn_Manten);
            this.panelMenu.Controls.Add(this.ibtn_CerrarSesion);
            this.panelMenu.Controls.Add(this.ibtn_Dashboard);
            this.panelMenu.Controls.Add(this.ibtn_Clientes);
            this.panelMenu.Controls.Add(this.ibtn_Vendedores);
            this.panelMenu.Controls.Add(this.ibtn_Ventas);
            this.panelMenu.Controls.Add(this.ibtn_Usuarios);
            this.panelMenu.Controls.Add(this.ibtn_Reportes);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(4);
            this.panelMenu.Size = new System.Drawing.Size(350, 1059);
            this.panelMenu.Controls.SetChildIndex(this.ibtn_Reportes, 0);
            this.panelMenu.Controls.SetChildIndex(this.ibtn_Usuarios, 0);
            this.panelMenu.Controls.SetChildIndex(this.ibtn_Ventas, 0);
            this.panelMenu.Controls.SetChildIndex(this.ibtn_Vendedores, 0);
            this.panelMenu.Controls.SetChildIndex(this.ibtn_Clientes, 0);
            this.panelMenu.Controls.SetChildIndex(this.ibtn_Dashboard, 0);
            this.panelMenu.Controls.SetChildIndex(this.pictureBoxLogo, 0);
            this.panelMenu.Controls.SetChildIndex(this.btnMenu, 0);
            this.panelMenu.Controls.SetChildIndex(this.ibtn_CerrarSesion, 0);
            this.panelMenu.Controls.SetChildIndex(this.ibtn_Manten, 0);
            // 
            // btnMenu
            // 
            this.btnMenu.FlatAppearance.BorderSize = 0;
            // 
            // panelContent
            // 
            this.panelContent.Margin = new System.Windows.Forms.Padding(4);
            this.panelContent.Size = new System.Drawing.Size(1590, 1059);
            // 
            // ibtn_CerrarSesion
            // 
            this.ibtn_CerrarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_CerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtn_CerrarSesion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ibtn_CerrarSesion.FlatAppearance.BorderSize = 0;
            this.ibtn_CerrarSesion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_CerrarSesion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.ibtn_CerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_CerrarSesion.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibtn_CerrarSesion.ForeColor = System.Drawing.SystemColors.Control;
            this.ibtn_CerrarSesion.IconChar = FontAwesome.Sharp.IconChar.SignOut;
            this.ibtn_CerrarSesion.IconColor = System.Drawing.Color.White;
            this.ibtn_CerrarSesion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_CerrarSesion.IconSize = 38;
            this.ibtn_CerrarSesion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtn_CerrarSesion.Location = new System.Drawing.Point(0, 994);
            this.ibtn_CerrarSesion.Margin = new System.Windows.Forms.Padding(2);
            this.ibtn_CerrarSesion.Name = "ibtn_CerrarSesion";
            this.ibtn_CerrarSesion.Size = new System.Drawing.Size(350, 65);
            this.ibtn_CerrarSesion.TabIndex = 20;
            this.ibtn_CerrarSesion.Tag = "CERRAR SESIÓN";
            this.ibtn_CerrarSesion.Text = "CERRAR SESIÓN";
            this.ibtn_CerrarSesion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtn_CerrarSesion.UseVisualStyleBackColor = false;
            this.ibtn_CerrarSesion.Click += new System.EventHandler(this.ibtn_CerrarSesion_Click);
            // 
            // ibtn_Usuarios
            // 
            this.ibtn_Usuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_Usuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtn_Usuarios.FlatAppearance.BorderSize = 0;
            this.ibtn_Usuarios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_Usuarios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.ibtn_Usuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_Usuarios.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibtn_Usuarios.ForeColor = System.Drawing.SystemColors.Control;
            this.ibtn_Usuarios.IconChar = FontAwesome.Sharp.IconChar.UserGear;
            this.ibtn_Usuarios.IconColor = System.Drawing.Color.White;
            this.ibtn_Usuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_Usuarios.IconSize = 38;
            this.ibtn_Usuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtn_Usuarios.Location = new System.Drawing.Point(0, 659);
            this.ibtn_Usuarios.Margin = new System.Windows.Forms.Padding(2);
            this.ibtn_Usuarios.Name = "ibtn_Usuarios";
            this.ibtn_Usuarios.Size = new System.Drawing.Size(350, 65);
            this.ibtn_Usuarios.TabIndex = 19;
            this.ibtn_Usuarios.Tag = "GESTOR DE USUARIOS";
            this.ibtn_Usuarios.Text = "GESTOR DE USUARIOS";
            this.ibtn_Usuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtn_Usuarios.UseVisualStyleBackColor = false;
            this.ibtn_Usuarios.Click += new System.EventHandler(this.ibtn_Usuarios_Click);
            // 
            // ibtn_Ventas
            // 
            this.ibtn_Ventas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_Ventas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtn_Ventas.FlatAppearance.BorderSize = 0;
            this.ibtn_Ventas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_Ventas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.ibtn_Ventas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_Ventas.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibtn_Ventas.ForeColor = System.Drawing.SystemColors.Control;
            this.ibtn_Ventas.IconChar = FontAwesome.Sharp.IconChar.MoneyBillWheat;
            this.ibtn_Ventas.IconColor = System.Drawing.Color.White;
            this.ibtn_Ventas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_Ventas.IconSize = 38;
            this.ibtn_Ventas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtn_Ventas.Location = new System.Drawing.Point(0, 519);
            this.ibtn_Ventas.Margin = new System.Windows.Forms.Padding(2);
            this.ibtn_Ventas.Name = "ibtn_Ventas";
            this.ibtn_Ventas.Size = new System.Drawing.Size(350, 65);
            this.ibtn_Ventas.TabIndex = 18;
            this.ibtn_Ventas.Tag = "GESTOR DE VENTAS";
            this.ibtn_Ventas.Text = "GESTOR DE VENTAS";
            this.ibtn_Ventas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtn_Ventas.UseVisualStyleBackColor = false;
            this.ibtn_Ventas.Click += new System.EventHandler(this.ibtn_Ventas_Click);
            // 
            // ibtn_Vendedores
            // 
            this.ibtn_Vendedores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_Vendedores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtn_Vendedores.FlatAppearance.BorderSize = 0;
            this.ibtn_Vendedores.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_Vendedores.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.ibtn_Vendedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_Vendedores.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibtn_Vendedores.ForeColor = System.Drawing.SystemColors.Control;
            this.ibtn_Vendedores.IconChar = FontAwesome.Sharp.IconChar.Tractor;
            this.ibtn_Vendedores.IconColor = System.Drawing.Color.White;
            this.ibtn_Vendedores.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_Vendedores.IconSize = 38;
            this.ibtn_Vendedores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtn_Vendedores.Location = new System.Drawing.Point(0, 449);
            this.ibtn_Vendedores.Margin = new System.Windows.Forms.Padding(2);
            this.ibtn_Vendedores.Name = "ibtn_Vendedores";
            this.ibtn_Vendedores.Size = new System.Drawing.Size(350, 65);
            this.ibtn_Vendedores.TabIndex = 17;
            this.ibtn_Vendedores.Tag = "GESTOR DE VENDEDORES";
            this.ibtn_Vendedores.Text = "GESTOR DE VENDEDORES";
            this.ibtn_Vendedores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtn_Vendedores.UseVisualStyleBackColor = false;
            this.ibtn_Vendedores.Click += new System.EventHandler(this.ibtn_Vendedores_Click);
            // 
            // ibtn_Clientes
            // 
            this.ibtn_Clientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_Clientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtn_Clientes.FlatAppearance.BorderSize = 0;
            this.ibtn_Clientes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_Clientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.ibtn_Clientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_Clientes.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibtn_Clientes.ForeColor = System.Drawing.SystemColors.Control;
            this.ibtn_Clientes.IconChar = FontAwesome.Sharp.IconChar.UsersLine;
            this.ibtn_Clientes.IconColor = System.Drawing.Color.White;
            this.ibtn_Clientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_Clientes.IconSize = 38;
            this.ibtn_Clientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtn_Clientes.Location = new System.Drawing.Point(0, 379);
            this.ibtn_Clientes.Margin = new System.Windows.Forms.Padding(2);
            this.ibtn_Clientes.Name = "ibtn_Clientes";
            this.ibtn_Clientes.Size = new System.Drawing.Size(350, 65);
            this.ibtn_Clientes.TabIndex = 16;
            this.ibtn_Clientes.Tag = "GESTOR DE CLIENTES";
            this.ibtn_Clientes.Text = "GESTOR DE CLIENTES";
            this.ibtn_Clientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtn_Clientes.UseVisualStyleBackColor = false;
            this.ibtn_Clientes.Click += new System.EventHandler(this.ibtn_Clientes_Click);
            // 
            // ibtn_Dashboard
            // 
            this.ibtn_Dashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_Dashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtn_Dashboard.FlatAppearance.BorderSize = 0;
            this.ibtn_Dashboard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_Dashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.ibtn_Dashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_Dashboard.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibtn_Dashboard.ForeColor = System.Drawing.SystemColors.Control;
            this.ibtn_Dashboard.IconChar = FontAwesome.Sharp.IconChar.Gauge;
            this.ibtn_Dashboard.IconColor = System.Drawing.Color.White;
            this.ibtn_Dashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_Dashboard.IconSize = 38;
            this.ibtn_Dashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtn_Dashboard.Location = new System.Drawing.Point(0, 309);
            this.ibtn_Dashboard.Margin = new System.Windows.Forms.Padding(2);
            this.ibtn_Dashboard.Name = "ibtn_Dashboard";
            this.ibtn_Dashboard.Size = new System.Drawing.Size(350, 65);
            this.ibtn_Dashboard.TabIndex = 15;
            this.ibtn_Dashboard.Tag = "DASHBOARD";
            this.ibtn_Dashboard.Text = "DASHBOARD";
            this.ibtn_Dashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtn_Dashboard.UseVisualStyleBackColor = false;
            this.ibtn_Dashboard.Click += new System.EventHandler(this.ibtn_Dashboard_Click);
            // 
            // ibtn_Reportes
            // 
            this.ibtn_Reportes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_Reportes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtn_Reportes.FlatAppearance.BorderSize = 0;
            this.ibtn_Reportes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_Reportes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.ibtn_Reportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_Reportes.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibtn_Reportes.ForeColor = System.Drawing.SystemColors.Control;
            this.ibtn_Reportes.IconChar = FontAwesome.Sharp.IconChar.FileInvoice;
            this.ibtn_Reportes.IconColor = System.Drawing.Color.White;
            this.ibtn_Reportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_Reportes.IconSize = 38;
            this.ibtn_Reportes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtn_Reportes.Location = new System.Drawing.Point(0, 729);
            this.ibtn_Reportes.Margin = new System.Windows.Forms.Padding(2);
            this.ibtn_Reportes.Name = "ibtn_Reportes";
            this.ibtn_Reportes.Size = new System.Drawing.Size(350, 65);
            this.ibtn_Reportes.TabIndex = 21;
            this.ibtn_Reportes.Tag = "REPORTES";
            this.ibtn_Reportes.Text = "REPORTES";
            this.ibtn_Reportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtn_Reportes.UseVisualStyleBackColor = false;
            this.ibtn_Reportes.Click += new System.EventHandler(this.ibtn_Reportes_Click);
            // 
            // ddm_Reportes
            // 
            this.ddm_Reportes.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ddm_Reportes.IsMainMenu = false;
            this.ddm_Reportes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ventas,
            this.inventario,
            this.vendedores,
            this.clientes});
            this.ddm_Reportes.MenuItemHeight = 65;
            this.ddm_Reportes.MenuItemTextColor = System.Drawing.Color.Empty;
            this.ddm_Reportes.Name = "ddm_Reportes";
            this.ddm_Reportes.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ddm_Reportes.Size = new System.Drawing.Size(157, 100);
            // 
            // ventas
            // 
            this.ventas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Ventas_general,
            this.Ventas_porVendedor});
            this.ventas.Name = "ventas";
            this.ventas.Size = new System.Drawing.Size(156, 24);
            this.ventas.Text = "Ventas";
            // 
            // Ventas_general
            // 
            this.Ventas_general.Name = "Ventas_general";
            this.Ventas_general.Size = new System.Drawing.Size(180, 26);
            this.Ventas_general.Text = "General";
            this.Ventas_general.Click += new System.EventHandler(this.Ventas_general_Click);
            // 
            // Ventas_porVendedor
            // 
            this.Ventas_porVendedor.Name = "Ventas_porVendedor";
            this.Ventas_porVendedor.Size = new System.Drawing.Size(180, 26);
            this.Ventas_porVendedor.Text = "Por vendedor";
            this.Ventas_porVendedor.Click += new System.EventHandler(this.Ventas_porVendedor_Click);
            // 
            // inventario
            // 
            this.inventario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Inventario_general,
            this.Inventario_porVendedor});
            this.inventario.Name = "inventario";
            this.inventario.Size = new System.Drawing.Size(156, 24);
            this.inventario.Text = "Inventario";
            // 
            // Inventario_general
            // 
            this.Inventario_general.Name = "Inventario_general";
            this.Inventario_general.Size = new System.Drawing.Size(180, 26);
            this.Inventario_general.Text = "General";
            this.Inventario_general.Click += new System.EventHandler(this.Inventario_general_Click);
            // 
            // Inventario_porVendedor
            // 
            this.Inventario_porVendedor.Name = "Inventario_porVendedor";
            this.Inventario_porVendedor.Size = new System.Drawing.Size(180, 26);
            this.Inventario_porVendedor.Text = "Por vendedor";
            this.Inventario_porVendedor.Click += new System.EventHandler(this.Inventario_porVendedor_Click);
            // 
            // vendedores
            // 
            this.vendedores.Name = "vendedores";
            this.vendedores.Size = new System.Drawing.Size(156, 24);
            this.vendedores.Text = "Vendedores";
            this.vendedores.Click += new System.EventHandler(this.vendedores_Click);
            // 
            // clientes
            // 
            this.clientes.Name = "clientes";
            this.clientes.Size = new System.Drawing.Size(156, 24);
            this.clientes.Text = "Clientes";
            this.clientes.Click += new System.EventHandler(this.clientes_Click);
            // 
            // ibtn_Manten
            // 
            this.ibtn_Manten.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_Manten.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtn_Manten.FlatAppearance.BorderSize = 0;
            this.ibtn_Manten.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_Manten.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.ibtn_Manten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_Manten.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibtn_Manten.ForeColor = System.Drawing.SystemColors.Control;
            this.ibtn_Manten.IconChar = FontAwesome.Sharp.IconChar.ScrewdriverWrench;
            this.ibtn_Manten.IconColor = System.Drawing.Color.White;
            this.ibtn_Manten.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_Manten.IconSize = 38;
            this.ibtn_Manten.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtn_Manten.Location = new System.Drawing.Point(0, 589);
            this.ibtn_Manten.Margin = new System.Windows.Forms.Padding(2);
            this.ibtn_Manten.Name = "ibtn_Manten";
            this.ibtn_Manten.Size = new System.Drawing.Size(350, 65);
            this.ibtn_Manten.TabIndex = 22;
            this.ibtn_Manten.Tag = "MANTENIMIENTO";
            this.ibtn_Manten.Text = "MANTENIMIENTO";
            this.ibtn_Manten.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtn_Manten.UseVisualStyleBackColor = false;
            this.ibtn_Manten.Click += new System.EventHandler(this.ibtn_Manten_Click);
            // 
            // ddm_Mantenimiento
            // 
            this.ddm_Mantenimiento.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ddm_Mantenimiento.IsMainMenu = false;
            this.ddm_Mantenimiento.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.categoria,
            this.producto});
            this.ddm_Mantenimiento.MenuItemHeight = 65;
            this.ddm_Mantenimiento.MenuItemTextColor = System.Drawing.Color.Empty;
            this.ddm_Mantenimiento.Name = "ddm_Mantenimiento";
            this.ddm_Mantenimiento.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ddm_Mantenimiento.Size = new System.Drawing.Size(144, 52);
            // 
            // categoria
            // 
            this.categoria.Name = "categoria";
            this.categoria.Size = new System.Drawing.Size(143, 24);
            this.categoria.Text = "Categoría";
            this.categoria.Click += new System.EventHandler(this.categoria_Click);
            // 
            // producto
            // 
            this.producto.Name = "producto";
            this.producto.Size = new System.Drawing.Size(143, 24);
            this.producto.Text = "Producto";
            this.producto.Click += new System.EventHandler(this.producto_Click);
            // 
            // Frm_MainAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.ClientSize = new System.Drawing.Size(1942, 1102);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_MainAdmin";
            this.Text = "MainAdmin";
            this.Controls.SetChildIndex(this.panelTitleBar, 0);
            this.Controls.SetChildIndex(this.panelMenu, 0);
            this.Controls.SetChildIndex(this.panelContent, 0);
            this.panelTitleBar.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ddm_Reportes.ResumeLayout(false);
            this.ddm_Mantenimiento.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton ibtn_Ventas;
        private FontAwesome.Sharp.IconButton ibtn_Vendedores;
        private FontAwesome.Sharp.IconButton ibtn_Clientes;
        private FontAwesome.Sharp.IconButton ibtn_Dashboard;
        private FontAwesome.Sharp.IconButton ibtn_Usuarios;
        private FontAwesome.Sharp.IconButton ibtn_CerrarSesion;
        private FontAwesome.Sharp.IconButton ibtn_Reportes;
        private RJCodeAdvance.RJControls.RJDropdownMenu ddm_Reportes;
        private System.Windows.Forms.ToolStripMenuItem ventas;
        private System.Windows.Forms.ToolStripMenuItem Ventas_general;
        private System.Windows.Forms.ToolStripMenuItem Ventas_porVendedor;
        private System.Windows.Forms.ToolStripMenuItem inventario;
        private System.Windows.Forms.ToolStripMenuItem Inventario_general;
        private System.Windows.Forms.ToolStripMenuItem Inventario_porVendedor;
        private System.Windows.Forms.ToolStripMenuItem vendedores;
        private System.Windows.Forms.ToolStripMenuItem clientes;
        private FontAwesome.Sharp.IconButton ibtn_Manten;
        private RJCodeAdvance.RJControls.RJDropdownMenu ddm_Mantenimiento;
        private System.Windows.Forms.ToolStripMenuItem categoria;
        private System.Windows.Forms.ToolStripMenuItem producto;
    }
}
