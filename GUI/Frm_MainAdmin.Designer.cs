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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_MainAdmin));
            this.ibtn_CerrarSesion = new FontAwesome.Sharp.IconButton();
            this.ibtn_Usuarios = new FontAwesome.Sharp.IconButton();
            this.ibtn_Ventas = new FontAwesome.Sharp.IconButton();
            this.ibtn_Vendedores = new FontAwesome.Sharp.IconButton();
            this.ibtn_Clientes = new FontAwesome.Sharp.IconButton();
            this.ibtn_Dashboard = new FontAwesome.Sharp.IconButton();
            this.ibtn_Reportes = new FontAwesome.Sharp.IconButton();
            this.panelTitleBar.SuspendLayout();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.Size = new System.Drawing.Size(1534, 33);
            // 
            // btn_Minimized
            // 
            this.btn_Minimized.FlatAppearance.BorderSize = 0;
            this.btn_Minimized.Location = new System.Drawing.Point(1426, 0);
            // 
            // btn_Maximized
            // 
            this.btn_Maximized.FlatAppearance.BorderSize = 0;
            this.btn_Maximized.Location = new System.Drawing.Point(1462, 0);
            // 
            // btn_Exit
            // 
            this.btn_Exit.FlatAppearance.BorderSize = 0;
            this.btn_Exit.Location = new System.Drawing.Point(1498, 0);
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.ibtn_CerrarSesion);
            this.panelMenu.Controls.Add(this.ibtn_Dashboard);
            this.panelMenu.Controls.Add(this.ibtn_Clientes);
            this.panelMenu.Controls.Add(this.ibtn_Vendedores);
            this.panelMenu.Controls.Add(this.ibtn_Ventas);
            this.panelMenu.Controls.Add(this.ibtn_Usuarios);
            this.panelMenu.Controls.Add(this.ibtn_Reportes);
            this.panelMenu.Size = new System.Drawing.Size(280, 849);
            this.panelMenu.Controls.SetChildIndex(this.ibtn_Reportes, 0);
            this.panelMenu.Controls.SetChildIndex(this.ibtn_Usuarios, 0);
            this.panelMenu.Controls.SetChildIndex(this.ibtn_Ventas, 0);
            this.panelMenu.Controls.SetChildIndex(this.ibtn_Vendedores, 0);
            this.panelMenu.Controls.SetChildIndex(this.ibtn_Clientes, 0);
            this.panelMenu.Controls.SetChildIndex(this.ibtn_Dashboard, 0);
            this.panelMenu.Controls.SetChildIndex(this.pictureBoxLogo, 0);
            this.panelMenu.Controls.SetChildIndex(this.btnMenu, 0);
            this.panelMenu.Controls.SetChildIndex(this.ibtn_CerrarSesion, 0);
            // 
            // btnMenu
            // 
            this.btnMenu.FlatAppearance.BorderSize = 0;
            // 
            // panelContent
            // 
            this.panelContent.Size = new System.Drawing.Size(1254, 849);
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
            this.ibtn_CerrarSesion.Location = new System.Drawing.Point(0, 797);
            this.ibtn_CerrarSesion.Margin = new System.Windows.Forms.Padding(2);
            this.ibtn_CerrarSesion.Name = "ibtn_CerrarSesion";
            this.ibtn_CerrarSesion.Size = new System.Drawing.Size(280, 52);
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
            this.ibtn_Usuarios.IconChar = FontAwesome.Sharp.IconChar.UserGroup;
            this.ibtn_Usuarios.IconColor = System.Drawing.Color.White;
            this.ibtn_Usuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_Usuarios.IconSize = 38;
            this.ibtn_Usuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtn_Usuarios.Location = new System.Drawing.Point(0, 471);
            this.ibtn_Usuarios.Margin = new System.Windows.Forms.Padding(2);
            this.ibtn_Usuarios.Name = "ibtn_Usuarios";
            this.ibtn_Usuarios.Size = new System.Drawing.Size(280, 52);
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
            this.ibtn_Ventas.Location = new System.Drawing.Point(0, 415);
            this.ibtn_Ventas.Margin = new System.Windows.Forms.Padding(2);
            this.ibtn_Ventas.Name = "ibtn_Ventas";
            this.ibtn_Ventas.Size = new System.Drawing.Size(280, 52);
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
            this.ibtn_Vendedores.Location = new System.Drawing.Point(0, 359);
            this.ibtn_Vendedores.Margin = new System.Windows.Forms.Padding(2);
            this.ibtn_Vendedores.Name = "ibtn_Vendedores";
            this.ibtn_Vendedores.Size = new System.Drawing.Size(280, 52);
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
            this.ibtn_Clientes.IconChar = FontAwesome.Sharp.IconChar.UsersGear;
            this.ibtn_Clientes.IconColor = System.Drawing.Color.White;
            this.ibtn_Clientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_Clientes.IconSize = 38;
            this.ibtn_Clientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtn_Clientes.Location = new System.Drawing.Point(0, 303);
            this.ibtn_Clientes.Margin = new System.Windows.Forms.Padding(2);
            this.ibtn_Clientes.Name = "ibtn_Clientes";
            this.ibtn_Clientes.Size = new System.Drawing.Size(280, 52);
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
            this.ibtn_Dashboard.Location = new System.Drawing.Point(0, 247);
            this.ibtn_Dashboard.Margin = new System.Windows.Forms.Padding(2);
            this.ibtn_Dashboard.Name = "ibtn_Dashboard";
            this.ibtn_Dashboard.Size = new System.Drawing.Size(280, 52);
            this.ibtn_Dashboard.TabIndex = 15;
            this.ibtn_Dashboard.Tag = "DASHBOARD";
            this.ibtn_Dashboard.Text = "DASHBOARD";
            this.ibtn_Dashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtn_Dashboard.UseVisualStyleBackColor = false;
            this.ibtn_Dashboard.Click += new System.EventHandler(this.ibtn_Dashboard_Click_1);
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
            this.ibtn_Reportes.Location = new System.Drawing.Point(0, 527);
            this.ibtn_Reportes.Margin = new System.Windows.Forms.Padding(2);
            this.ibtn_Reportes.Name = "ibtn_Reportes";
            this.ibtn_Reportes.Size = new System.Drawing.Size(280, 52);
            this.ibtn_Reportes.TabIndex = 21;
            this.ibtn_Reportes.Tag = "REPORTES";
            this.ibtn_Reportes.Text = "REPORTES";
            this.ibtn_Reportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtn_Reportes.UseVisualStyleBackColor = false;
            this.ibtn_Reportes.Click += new System.EventHandler(this.ibtn_Reportes_Click);
            // 
            // Frm_MainAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.ClientSize = new System.Drawing.Size(1536, 884);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "Frm_MainAdmin";
            this.Text = "MainAdmin";
            this.panelTitleBar.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
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
    }
}
