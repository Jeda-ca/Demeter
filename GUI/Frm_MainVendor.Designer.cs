namespace GUI
{
    partial class Frm_MainVendor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_MainVendor));
            this.label1 = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.ibtn_Signout = new FontAwesome.Sharp.IconButton();
            this.ibtn_Clientes = new FontAwesome.Sharp.IconButton();
            this.ibtn_Ventas = new FontAwesome.Sharp.IconButton();
            this.ibtn_Productos = new FontAwesome.Sharp.IconButton();
            this.btnMenu = new FontAwesome.Sharp.IconButton();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.btn_Minimized = new FontAwesome.Sharp.IconButton();
            this.btn_Maximized = new FontAwesome.Sharp.IconButton();
            this.btn_Exit = new FontAwesome.Sharp.IconButton();
            this.panelVendorContenido = new System.Windows.Forms.Panel();
            this.tim_PanelMenu = new System.Windows.Forms.Timer(this.components);
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.panelTitleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label1.Size = new System.Drawing.Size(347, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Demeter - Sesión de Vendedor";
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.panelMenu.Controls.Add(this.ibtn_Signout);
            this.panelMenu.Controls.Add(this.ibtn_Clientes);
            this.panelMenu.Controls.Add(this.ibtn_Ventas);
            this.panelMenu.Controls.Add(this.ibtn_Productos);
            this.panelMenu.Controls.Add(this.btnMenu);
            this.panelMenu.Controls.Add(this.pictureBoxLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 41);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(350, 959);
            this.panelMenu.TabIndex = 3;
            // 
            // ibtn_Signout
            // 
            this.ibtn_Signout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_Signout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ibtn_Signout.FlatAppearance.BorderSize = 0;
            this.ibtn_Signout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_Signout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.ibtn_Signout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_Signout.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibtn_Signout.ForeColor = System.Drawing.SystemColors.Control;
            this.ibtn_Signout.IconChar = FontAwesome.Sharp.IconChar.SignOut;
            this.ibtn_Signout.IconColor = System.Drawing.Color.White;
            this.ibtn_Signout.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_Signout.IconSize = 38;
            this.ibtn_Signout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtn_Signout.Location = new System.Drawing.Point(0, 894);
            this.ibtn_Signout.Name = "ibtn_Signout";
            this.ibtn_Signout.Size = new System.Drawing.Size(350, 65);
            this.ibtn_Signout.TabIndex = 20;
            this.ibtn_Signout.Tag = "CERRAR SESIÓN";
            this.ibtn_Signout.Text = "CERRAR SESIÓN";
            this.ibtn_Signout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtn_Signout.UseVisualStyleBackColor = false;
            this.ibtn_Signout.Click += new System.EventHandler(this.ibtn_Signout_Click);
            // 
            // ibtn_Clientes
            // 
            this.ibtn_Clientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
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
            this.ibtn_Clientes.Location = new System.Drawing.Point(0, 519);
            this.ibtn_Clientes.Name = "ibtn_Clientes";
            this.ibtn_Clientes.Size = new System.Drawing.Size(350, 100);
            this.ibtn_Clientes.TabIndex = 17;
            this.ibtn_Clientes.Tag = "GESTOR DE CLIENTES";
            this.ibtn_Clientes.Text = "GESTOR DE CLIENTES";
            this.ibtn_Clientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtn_Clientes.UseVisualStyleBackColor = false;
            // 
            // ibtn_Ventas
            // 
            this.ibtn_Ventas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_Ventas.FlatAppearance.BorderSize = 0;
            this.ibtn_Ventas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_Ventas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.ibtn_Ventas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_Ventas.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibtn_Ventas.ForeColor = System.Drawing.SystemColors.Control;
            this.ibtn_Ventas.IconChar = FontAwesome.Sharp.IconChar.HandHoldingUsd;
            this.ibtn_Ventas.IconColor = System.Drawing.Color.White;
            this.ibtn_Ventas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_Ventas.IconSize = 38;
            this.ibtn_Ventas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtn_Ventas.Location = new System.Drawing.Point(0, 414);
            this.ibtn_Ventas.Name = "ibtn_Ventas";
            this.ibtn_Ventas.Size = new System.Drawing.Size(350, 100);
            this.ibtn_Ventas.TabIndex = 16;
            this.ibtn_Ventas.Tag = "GESTOR DE VENTAS";
            this.ibtn_Ventas.Text = "GESTOR DE VENTAS";
            this.ibtn_Ventas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtn_Ventas.UseVisualStyleBackColor = false;
            // 
            // ibtn_Productos
            // 
            this.ibtn_Productos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_Productos.FlatAppearance.BorderSize = 0;
            this.ibtn_Productos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_Productos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.ibtn_Productos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_Productos.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibtn_Productos.ForeColor = System.Drawing.SystemColors.Control;
            this.ibtn_Productos.IconChar = FontAwesome.Sharp.IconChar.WheatAwn;
            this.ibtn_Productos.IconColor = System.Drawing.Color.White;
            this.ibtn_Productos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_Productos.IconSize = 38;
            this.ibtn_Productos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtn_Productos.Location = new System.Drawing.Point(0, 309);
            this.ibtn_Productos.Name = "ibtn_Productos";
            this.ibtn_Productos.Size = new System.Drawing.Size(350, 100);
            this.ibtn_Productos.TabIndex = 15;
            this.ibtn_Productos.Tag = "GESTOR DE PRODUCTOS";
            this.ibtn_Productos.Text = "GESTOR DE PRODUCTOS";
            this.ibtn_Productos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtn_Productos.UseVisualStyleBackColor = false;
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.IconChar = FontAwesome.Sharp.IconChar.BarsStaggered;
            this.btnMenu.IconColor = System.Drawing.SystemColors.Control;
            this.btnMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMenu.IconSize = 38;
            this.btnMenu.Location = new System.Drawing.Point(0, 0);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(80, 45);
            this.btnMenu.TabIndex = 6;
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = global::GUI.Properties.Resources.LogoDemeter_removebg_preview;
            this.pictureBoxLogo.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(350, 300);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.panelTitleBar.Controls.Add(this.btn_Minimized);
            this.panelTitleBar.Controls.Add(this.btn_Maximized);
            this.panelTitleBar.Controls.Add(this.btn_Exit);
            this.panelTitleBar.Controls.Add(this.label1);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(0, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(1600, 41);
            this.panelTitleBar.TabIndex = 2;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // btn_Minimized
            // 
            this.btn_Minimized.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.btn_Minimized.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Minimized.FlatAppearance.BorderSize = 0;
            this.btn_Minimized.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Minimized.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.btn_Minimized.IconColor = System.Drawing.Color.White;
            this.btn_Minimized.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btn_Minimized.IconSize = 25;
            this.btn_Minimized.Location = new System.Drawing.Point(1465, 0);
            this.btn_Minimized.Name = "btn_Minimized";
            this.btn_Minimized.Size = new System.Drawing.Size(45, 41);
            this.btn_Minimized.TabIndex = 3;
            this.btn_Minimized.UseVisualStyleBackColor = false;
            this.btn_Minimized.Click += new System.EventHandler(this.btn_Minimized_Click);
            // 
            // btn_Maximized
            // 
            this.btn_Maximized.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.btn_Maximized.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Maximized.FlatAppearance.BorderSize = 0;
            this.btn_Maximized.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Maximized.IconChar = FontAwesome.Sharp.IconChar.Expand;
            this.btn_Maximized.IconColor = System.Drawing.Color.White;
            this.btn_Maximized.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_Maximized.IconSize = 25;
            this.btn_Maximized.Location = new System.Drawing.Point(1510, 0);
            this.btn_Maximized.Name = "btn_Maximized";
            this.btn_Maximized.Size = new System.Drawing.Size(45, 41);
            this.btn_Maximized.TabIndex = 2;
            this.btn_Maximized.UseVisualStyleBackColor = false;
            this.btn_Maximized.Click += new System.EventHandler(this.btn_Maximized_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.btn_Exit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Exit.FlatAppearance.BorderSize = 0;
            this.btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Exit.IconChar = FontAwesome.Sharp.IconChar.X;
            this.btn_Exit.IconColor = System.Drawing.Color.White;
            this.btn_Exit.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btn_Exit.IconSize = 25;
            this.btn_Exit.Location = new System.Drawing.Point(1555, 0);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(45, 41);
            this.btn_Exit.TabIndex = 1;
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // panelVendorContenido
            // 
            this.panelVendorContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelVendorContenido.Location = new System.Drawing.Point(350, 41);
            this.panelVendorContenido.Name = "panelVendorContenido";
            this.panelVendorContenido.Size = new System.Drawing.Size(1250, 959);
            this.panelVendorContenido.TabIndex = 4;
            // 
            // tim_PanelMenu
            // 
            this.tim_PanelMenu.Interval = 10;
            this.tim_PanelMenu.Tick += new System.EventHandler(this.tim_PanelMenu_Tick);
            // 
            // Frm_MainVendor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.ClientSize = new System.Drawing.Size(1600, 1000);
            this.Controls.Add(this.panelVendorContenido);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelTitleBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_MainVendor";
            this.Text = "MainVendor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_MainVendor_Load);
            this.Resize += new System.EventHandler(this.Frm_MainVendor_Resize);
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.panelTitleBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton btn_Minimized;
        private FontAwesome.Sharp.IconButton btn_Maximized;
        private FontAwesome.Sharp.IconButton btn_Exit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelMenu;
        private FontAwesome.Sharp.IconButton ibtn_Signout;
        private FontAwesome.Sharp.IconButton ibtn_Clientes;
        private FontAwesome.Sharp.IconButton ibtn_Ventas;
        private FontAwesome.Sharp.IconButton ibtn_Productos;
        private FontAwesome.Sharp.IconButton btnMenu;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Panel panelVendorContenido;
        private System.Windows.Forms.Timer tim_PanelMenu;
    }
}