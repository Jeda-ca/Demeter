namespace GUI
{
    partial class Frm_MainBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_MainBase));
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.btn_Minimized = new FontAwesome.Sharp.IconButton();
            this.btn_Maximized = new FontAwesome.Sharp.IconButton();
            this.btn_Exit = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnMenu = new FontAwesome.Sharp.IconButton();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.tim_PanelMenu = new System.Windows.Forms.Timer(this.components);
            this.panelContent = new System.Windows.Forms.Panel(); // Panel para el contenido específico de cada formulario hijo
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
            this.label1.Text = "Demeter - Sesión Base"; // Texto por defecto, será sobrescrito.
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.panelMenu.Controls.Add(this.btnMenu);
            this.panelMenu.Controls.Add(this.pictureBoxLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 41);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(350, 959); // Altura inicial
            this.panelMenu.TabIndex = 1;
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
            this.pictureBoxLogo.Image = global::GUI.Properties.Resources.LogoDemeter_removebg_preview; // Asumiendo que esta imagen está en Resources
            this.pictureBoxLogo.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(350, 300);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // tim_PanelMenu
            // 
            this.tim_PanelMenu.Interval = 10;
            this.tim_PanelMenu.Tick += new System.EventHandler(this.tim_PanelMenu_Tick);
            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(350, 41); // Posición inicial, se ajustará con el Dock
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1250, 959); // Tamaño inicial
            this.panelContent.TabIndex = 2;
            // 
            // Frm_MainBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.ClientSize = new System.Drawing.Size(1600, 1000);
            this.Controls.Add(this.panelContent); // Añadir el panel de contenido
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelTitleBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_MainBase";
            this.Text = "Demeter - Base";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized; // Inicia maximizado por defecto
            this.panelTitleBar.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        // Controles protegidos para acceso desde las clases derivadas
        protected System.Windows.Forms.Panel panelTitleBar;
        protected FontAwesome.Sharp.IconButton btn_Minimized;
        protected FontAwesome.Sharp.IconButton btn_Maximized;
        protected FontAwesome.Sharp.IconButton btn_Exit;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Panel panelMenu;
        protected FontAwesome.Sharp.IconButton btnMenu;
        protected System.Windows.Forms.PictureBox pictureBoxLogo;
        protected System.Windows.Forms.Timer tim_PanelMenu;
        protected System.Windows.Forms.Panel panelContent; // Panel de contenido para las clases hijas
    }
}
