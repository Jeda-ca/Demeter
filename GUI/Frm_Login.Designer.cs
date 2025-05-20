namespace GUI
{
    partial class Frm_Login
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Login));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBx_Username = new System.Windows.Forms.TextBox();
            this.txtBx_Password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbx_showPassword = new System.Windows.Forms.CheckBox();
            this.btn_Ingresar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ibtn_Minimized_LogIn = new FontAwesome.Sharp.IconButton();
            this.ibtn_Exit_LogIn = new FontAwesome.Sharp.IconButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(263, 500);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GUI.Properties.Resources.LogoDemeter;
            this.pictureBox1.Location = new System.Drawing.Point(31, 94);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label5.Location = new System.Drawing.Point(36, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(191, 63);
            this.label5.TabIndex = 4;
            this.label5.Text = "Bienvenido/a a Demeter";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(371, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 37);
            this.label2.TabIndex = 2;
            this.label2.Text = "Inicie sesión";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(312, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Usuario";
            // 
            // txtBx_Username
            // 
            this.txtBx_Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBx_Username.Location = new System.Drawing.Point(316, 207);
            this.txtBx_Username.Name = "txtBx_Username";
            this.txtBx_Username.Size = new System.Drawing.Size(300, 32);
            this.txtBx_Username.TabIndex = 4;
            // 
            // txtBx_Password
            // 
            this.txtBx_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBx_Password.Location = new System.Drawing.Point(316, 294);
            this.txtBx_Password.Name = "txtBx_Password";
            this.txtBx_Password.PasswordChar = '●';
            this.txtBx_Password.Size = new System.Drawing.Size(300, 32);
            this.txtBx_Password.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(312, 264);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Contraseña";
            // 
            // cbx_showPassword
            // 
            this.cbx_showPassword.AutoSize = true;
            this.cbx_showPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_showPassword.Location = new System.Drawing.Point(317, 328);
            this.cbx_showPassword.Name = "cbx_showPassword";
            this.cbx_showPassword.Size = new System.Drawing.Size(160, 22);
            this.cbx_showPassword.TabIndex = 8;
            this.cbx_showPassword.Text = "Mostrar contraseña";
            this.cbx_showPassword.UseVisualStyleBackColor = true;
            this.cbx_showPassword.CheckedChanged += new System.EventHandler(this.cbx_showPassword_CheckedChanged);
            // 
            // btn_Ingresar
            // 
            this.btn_Ingresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.btn_Ingresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Ingresar.FlatAppearance.BorderSize = 0;
            this.btn_Ingresar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.btn_Ingresar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.btn_Ingresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Ingresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Ingresar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Ingresar.Location = new System.Drawing.Point(316, 391);
            this.btn_Ingresar.Name = "btn_Ingresar";
            this.btn_Ingresar.Size = new System.Drawing.Size(144, 44);
            this.btn_Ingresar.TabIndex = 9;
            this.btn_Ingresar.Text = "Ingresar";
            this.btn_Ingresar.UseVisualStyleBackColor = false;
            this.btn_Ingresar.Click += new System.EventHandler(this.btn_Ingresar_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ibtn_Minimized_LogIn);
            this.panel2.Controls.Add(this.ibtn_Exit_LogIn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(263, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(412, 40);
            this.panel2.TabIndex = 11;
            // 
            // ibtn_Minimized_LogIn
            // 
            this.ibtn_Minimized_LogIn.Dock = System.Windows.Forms.DockStyle.Right;
            this.ibtn_Minimized_LogIn.FlatAppearance.BorderSize = 0;
            this.ibtn_Minimized_LogIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_Minimized_LogIn.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.ibtn_Minimized_LogIn.IconColor = System.Drawing.Color.Black;
            this.ibtn_Minimized_LogIn.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.ibtn_Minimized_LogIn.IconSize = 22;
            this.ibtn_Minimized_LogIn.Location = new System.Drawing.Point(322, 0);
            this.ibtn_Minimized_LogIn.Name = "ibtn_Minimized_LogIn";
            this.ibtn_Minimized_LogIn.Size = new System.Drawing.Size(45, 40);
            this.ibtn_Minimized_LogIn.TabIndex = 11;
            this.ibtn_Minimized_LogIn.UseVisualStyleBackColor = true;
            this.ibtn_Minimized_LogIn.Click += new System.EventHandler(this.ibtn_Minimized_LogIn_Click);
            // 
            // ibtn_Exit_LogIn
            // 
            this.ibtn_Exit_LogIn.Dock = System.Windows.Forms.DockStyle.Right;
            this.ibtn_Exit_LogIn.FlatAppearance.BorderSize = 0;
            this.ibtn_Exit_LogIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_Exit_LogIn.IconChar = FontAwesome.Sharp.IconChar.X;
            this.ibtn_Exit_LogIn.IconColor = System.Drawing.Color.Black;
            this.ibtn_Exit_LogIn.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.ibtn_Exit_LogIn.IconSize = 22;
            this.ibtn_Exit_LogIn.Location = new System.Drawing.Point(367, 0);
            this.ibtn_Exit_LogIn.Name = "ibtn_Exit_LogIn";
            this.ibtn_Exit_LogIn.Size = new System.Drawing.Size(45, 40);
            this.ibtn_Exit_LogIn.TabIndex = 10;
            this.ibtn_Exit_LogIn.UseVisualStyleBackColor = true;
            this.ibtn_Exit_LogIn.Click += new System.EventHandler(this.ibtn_Exit_LogIn_Click);
            // 
            // Frm_Login
            // 
            this.AcceptButton = this.btn_Ingresar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(675, 500);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btn_Ingresar);
            this.Controls.Add(this.cbx_showPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBx_Password);
            this.Controls.Add(this.txtBx_Username);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBx_Username;
        private System.Windows.Forms.TextBox txtBx_Password;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbx_showPassword;
        private System.Windows.Forms.Button btn_Ingresar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton ibtn_Exit_LogIn;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton ibtn_Minimized_LogIn;
    }
}

