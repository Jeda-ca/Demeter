namespace GUI
{
    partial class Frm_MainVendor : Frm_MainBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_MainVendor));
            this.ibtn_Signout = new FontAwesome.Sharp.IconButton();
            this.ibtn_Clientes = new FontAwesome.Sharp.IconButton();
            this.ibtn_Ventas = new FontAwesome.Sharp.IconButton();
            this.ibtn_Productos = new FontAwesome.Sharp.IconButton();
            this.ibtn_Dashboard = new FontAwesome.Sharp.IconButton();
            this.panelTitleBar.SuspendLayout();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.Margin = new System.Windows.Forms.Padding(4);
            this.panelTitleBar.Size = new System.Drawing.Size(1910, 41);
            // 
            // btn_Minimized
            // 
            this.btn_Minimized.FlatAppearance.BorderSize = 0;
            this.btn_Minimized.Location = new System.Drawing.Point(1775, 0);
            this.btn_Minimized.Margin = new System.Windows.Forms.Padding(4);
            // 
            // btn_Maximized
            // 
            this.btn_Maximized.FlatAppearance.BorderSize = 0;
            this.btn_Maximized.Location = new System.Drawing.Point(1820, 0);
            this.btn_Maximized.Margin = new System.Windows.Forms.Padding(4);
            // 
            // btn_Exit
            // 
            this.btn_Exit.FlatAppearance.BorderSize = 0;
            this.btn_Exit.Location = new System.Drawing.Point(1865, 0);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(4);
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.ibtn_Dashboard);
            this.panelMenu.Controls.Add(this.ibtn_Productos);
            this.panelMenu.Controls.Add(this.ibtn_Ventas);
            this.panelMenu.Controls.Add(this.ibtn_Clientes);
            this.panelMenu.Controls.Add(this.ibtn_Signout);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(4);
            this.panelMenu.Size = new System.Drawing.Size(350, 1059);
            this.panelMenu.Controls.SetChildIndex(this.ibtn_Signout, 0);
            this.panelMenu.Controls.SetChildIndex(this.ibtn_Clientes, 0);
            this.panelMenu.Controls.SetChildIndex(this.ibtn_Ventas, 0);
            this.panelMenu.Controls.SetChildIndex(this.ibtn_Productos, 0);
            this.panelMenu.Controls.SetChildIndex(this.ibtn_Dashboard, 0);
            this.panelMenu.Controls.SetChildIndex(this.pictureBoxLogo, 0);
            this.panelMenu.Controls.SetChildIndex(this.btnMenu, 0);
            // 
            // btnMenu
            // 
            this.btnMenu.FlatAppearance.BorderSize = 0;
            // 
            // panelContent
            // 
            this.panelContent.Margin = new System.Windows.Forms.Padding(4);
            this.panelContent.Size = new System.Drawing.Size(1560, 1059);
            this.panelContent.TabIndex = 4;
            // 
            // ibtn_Signout
            // 
            this.ibtn_Signout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_Signout.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.ibtn_Signout.Location = new System.Drawing.Point(0, 979);
            this.ibtn_Signout.Margin = new System.Windows.Forms.Padding(2);
            this.ibtn_Signout.Name = "ibtn_Signout";
            this.ibtn_Signout.Size = new System.Drawing.Size(350, 80);
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
            this.ibtn_Clientes.Location = new System.Drawing.Point(0, 549);
            this.ibtn_Clientes.Margin = new System.Windows.Forms.Padding(2);
            this.ibtn_Clientes.Name = "ibtn_Clientes";
            this.ibtn_Clientes.Size = new System.Drawing.Size(350, 80);
            this.ibtn_Clientes.TabIndex = 17;
            this.ibtn_Clientes.Tag = "GESTOR DE CLIENTES";
            this.ibtn_Clientes.Text = "GESTOR DE CLIENTES";
            this.ibtn_Clientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtn_Clientes.UseVisualStyleBackColor = false;
            this.ibtn_Clientes.Click += new System.EventHandler(this.ibtn_Clientes_Click);
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
            this.ibtn_Ventas.IconChar = FontAwesome.Sharp.IconChar.HandHoldingUsd;
            this.ibtn_Ventas.IconColor = System.Drawing.Color.White;
            this.ibtn_Ventas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_Ventas.IconSize = 38;
            this.ibtn_Ventas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtn_Ventas.Location = new System.Drawing.Point(0, 469);
            this.ibtn_Ventas.Margin = new System.Windows.Forms.Padding(2);
            this.ibtn_Ventas.Name = "ibtn_Ventas";
            this.ibtn_Ventas.Size = new System.Drawing.Size(350, 80);
            this.ibtn_Ventas.TabIndex = 16;
            this.ibtn_Ventas.Tag = "GESTOR DE VENTAS";
            this.ibtn_Ventas.Text = "GESTOR DE VENTAS";
            this.ibtn_Ventas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtn_Ventas.UseVisualStyleBackColor = false;
            this.ibtn_Ventas.Click += new System.EventHandler(this.ibtn_Ventas_Click);
            // 
            // ibtn_Productos
            // 
            this.ibtn_Productos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_Productos.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.ibtn_Productos.Location = new System.Drawing.Point(0, 389);
            this.ibtn_Productos.Margin = new System.Windows.Forms.Padding(2);
            this.ibtn_Productos.Name = "ibtn_Productos";
            this.ibtn_Productos.Size = new System.Drawing.Size(350, 80);
            this.ibtn_Productos.TabIndex = 15;
            this.ibtn_Productos.Tag = "GESTOR DE PRODUCTOS";
            this.ibtn_Productos.Text = "GESTOR DE PRODUCTOS";
            this.ibtn_Productos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtn_Productos.UseVisualStyleBackColor = false;
            this.ibtn_Productos.Click += new System.EventHandler(this.ibtn_Productos_Click);
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
            this.ibtn_Dashboard.Size = new System.Drawing.Size(350, 80);
            this.ibtn_Dashboard.TabIndex = 14;
            this.ibtn_Dashboard.Tag = "DASHBOARD";
            this.ibtn_Dashboard.Text = "DASHBOARD";
            this.ibtn_Dashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtn_Dashboard.UseVisualStyleBackColor = false;
            this.ibtn_Dashboard.Click += new System.EventHandler(this.ibtn_Dashboard_Click);
            // 
            // Frm_MainVendor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.ClientSize = new System.Drawing.Size(1912, 1102);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_MainVendor";
            this.Text = "MainVendor";
            this.panelTitleBar.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton ibtn_Signout;
        private FontAwesome.Sharp.IconButton ibtn_Clientes;
        private FontAwesome.Sharp.IconButton ibtn_Ventas;
        private FontAwesome.Sharp.IconButton ibtn_Productos;
        private FontAwesome.Sharp.IconButton ibtn_Dashboard; // Declaración del nuevo botón
    }
}
