namespace GUI
{
    partial class Frm_MainAdmin
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
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.ibtn_Signout = new FontAwesome.Sharp.IconButton();
            this.ibtn_Users = new FontAwesome.Sharp.IconButton();
            this.ibtn_Vents = new FontAwesome.Sharp.IconButton();
            this.ibtn_Vendedores = new FontAwesome.Sharp.IconButton();
            this.ibtn_Clients = new FontAwesome.Sharp.IconButton();
            this.ibtn_Dashboard = new FontAwesome.Sharp.IconButton();
            this.ibtn_Reports = new FontAwesome.Sharp.IconButton();
            this.btnMenu = new FontAwesome.Sharp.IconButton();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.btn_Minimized = new FontAwesome.Sharp.IconButton();
            this.btn_Maximized = new FontAwesome.Sharp.IconButton();
            this.btn_Exit = new FontAwesome.Sharp.IconButton();
            this.panelTitleBar.SuspendLayout();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
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
            this.panelTitleBar.TabIndex = 0;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
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
            this.label1.Text = "Demeter - Sesión de Administrador";
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.panelMenu.Controls.Add(this.ibtn_Signout);
            this.panelMenu.Controls.Add(this.ibtn_Users);
            this.panelMenu.Controls.Add(this.ibtn_Vents);
            this.panelMenu.Controls.Add(this.ibtn_Vendedores);
            this.panelMenu.Controls.Add(this.ibtn_Clients);
            this.panelMenu.Controls.Add(this.ibtn_Dashboard);
            this.panelMenu.Controls.Add(this.ibtn_Reports);
            this.panelMenu.Controls.Add(this.btnMenu);
            this.panelMenu.Controls.Add(this.pictureBoxLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 41);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(350, 959);
            this.panelMenu.TabIndex = 1;
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
            // 
            // ibtn_Users
            // 
            this.ibtn_Users.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_Users.FlatAppearance.BorderSize = 0;
            this.ibtn_Users.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_Users.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.ibtn_Users.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_Users.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibtn_Users.ForeColor = System.Drawing.SystemColors.Control;
            this.ibtn_Users.IconChar = FontAwesome.Sharp.IconChar.UserGroup;
            this.ibtn_Users.IconColor = System.Drawing.Color.White;
            this.ibtn_Users.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_Users.IconSize = 38;
            this.ibtn_Users.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtn_Users.Location = new System.Drawing.Point(0, 589);
            this.ibtn_Users.Name = "ibtn_Users";
            this.ibtn_Users.Size = new System.Drawing.Size(350, 65);
            this.ibtn_Users.TabIndex = 19;
            this.ibtn_Users.Tag = "GESTOR DE USUARIOS";
            this.ibtn_Users.Text = "GESTOR DE USUARIOS";
            this.ibtn_Users.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtn_Users.UseVisualStyleBackColor = false;
            // 
            // ibtn_Vents
            // 
            this.ibtn_Vents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_Vents.FlatAppearance.BorderSize = 0;
            this.ibtn_Vents.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_Vents.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.ibtn_Vents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_Vents.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibtn_Vents.ForeColor = System.Drawing.SystemColors.Control;
            this.ibtn_Vents.IconChar = FontAwesome.Sharp.IconChar.MoneyBillWheat;
            this.ibtn_Vents.IconColor = System.Drawing.Color.White;
            this.ibtn_Vents.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_Vents.IconSize = 38;
            this.ibtn_Vents.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtn_Vents.Location = new System.Drawing.Point(0, 519);
            this.ibtn_Vents.Name = "ibtn_Vents";
            this.ibtn_Vents.Size = new System.Drawing.Size(350, 65);
            this.ibtn_Vents.TabIndex = 18;
            this.ibtn_Vents.Tag = "GESTOR DE VENTAS";
            this.ibtn_Vents.Text = "GESTOR DE VENTAS";
            this.ibtn_Vents.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtn_Vents.UseVisualStyleBackColor = false;
            // 
            // ibtn_Vendedores
            // 
            this.ibtn_Vendedores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
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
            this.ibtn_Vendedores.Name = "ibtn_Vendedores";
            this.ibtn_Vendedores.Size = new System.Drawing.Size(350, 65);
            this.ibtn_Vendedores.TabIndex = 17;
            this.ibtn_Vendedores.Tag = "GESTOR DE VENDEDORES";
            this.ibtn_Vendedores.Text = "GESTOR DE VENDEDORES";
            this.ibtn_Vendedores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtn_Vendedores.UseVisualStyleBackColor = false;
            // 
            // ibtn_Clients
            // 
            this.ibtn_Clients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_Clients.FlatAppearance.BorderSize = 0;
            this.ibtn_Clients.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_Clients.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.ibtn_Clients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_Clients.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibtn_Clients.ForeColor = System.Drawing.SystemColors.Control;
            this.ibtn_Clients.IconChar = FontAwesome.Sharp.IconChar.UsersGear;
            this.ibtn_Clients.IconColor = System.Drawing.Color.White;
            this.ibtn_Clients.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_Clients.IconSize = 38;
            this.ibtn_Clients.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtn_Clients.Location = new System.Drawing.Point(0, 379);
            this.ibtn_Clients.Name = "ibtn_Clients";
            this.ibtn_Clients.Size = new System.Drawing.Size(350, 65);
            this.ibtn_Clients.TabIndex = 16;
            this.ibtn_Clients.Tag = "GESTOR DE CLIENTES";
            this.ibtn_Clients.Text = "GESTOR DE CLIENTES";
            this.ibtn_Clients.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtn_Clients.UseVisualStyleBackColor = false;
            // 
            // ibtn_Dashboard
            // 
            this.ibtn_Dashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
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
            this.ibtn_Dashboard.Name = "ibtn_Dashboard";
            this.ibtn_Dashboard.Size = new System.Drawing.Size(350, 65);
            this.ibtn_Dashboard.TabIndex = 15;
            this.ibtn_Dashboard.Tag = "DASHBOARD";
            this.ibtn_Dashboard.Text = "DASHBOARD";
            this.ibtn_Dashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtn_Dashboard.UseVisualStyleBackColor = false;
            // 
            // ibtn_Reports
            // 
            this.ibtn_Reports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_Reports.FlatAppearance.BorderSize = 0;
            this.ibtn_Reports.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_Reports.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.ibtn_Reports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_Reports.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibtn_Reports.ForeColor = System.Drawing.SystemColors.Control;
            this.ibtn_Reports.IconChar = FontAwesome.Sharp.IconChar.FileInvoice;
            this.ibtn_Reports.IconColor = System.Drawing.Color.White;
            this.ibtn_Reports.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_Reports.IconSize = 38;
            this.ibtn_Reports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ibtn_Reports.Location = new System.Drawing.Point(0, 659);
            this.ibtn_Reports.Name = "ibtn_Reports";
            this.ibtn_Reports.Size = new System.Drawing.Size(350, 65);
            this.ibtn_Reports.TabIndex = 21;
            this.ibtn_Reports.Tag = "REPORTES";
            this.ibtn_Reports.Text = "REPORTES";
            this.ibtn_Reports.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtn_Reports.UseVisualStyleBackColor = false;
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
            // Frm_MainAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.ClientSize = new System.Drawing.Size(1600, 1000);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelTitleBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_MainAdmin";
            this.Text = "MainAdmin";
            this.Load += new System.EventHandler(this.Frm_MainAdmin_Load);
            this.Resize += new System.EventHandler(this.Frm_MainAdmin_Resize);
            this.panelTitleBar.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private FontAwesome.Sharp.IconButton btnMenu;
        private System.Windows.Forms.Panel panelMenu;
        private FontAwesome.Sharp.IconButton ibtn_Vents;
        private FontAwesome.Sharp.IconButton ibtn_Vendedores;
        private FontAwesome.Sharp.IconButton ibtn_Clients;
        private FontAwesome.Sharp.IconButton ibtn_Dashboard;
        private FontAwesome.Sharp.IconButton ibtn_Users;
        private FontAwesome.Sharp.IconButton ibtn_Signout;
        private FontAwesome.Sharp.IconButton ibtn_Reports;
        private FontAwesome.Sharp.IconButton btn_Maximized;
        private FontAwesome.Sharp.IconButton btn_Exit;
        private FontAwesome.Sharp.IconButton btn_Minimized;
    }
}