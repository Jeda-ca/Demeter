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
            this.tbx_Username = new System.Windows.Forms.TextBox();
            this.tbx_Password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbx_showPassword = new System.Windows.Forms.CheckBox();
            this.btn_Ingresar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ibtn_Minimized_LogIn = new FontAwesome.Sharp.IconButton();
            this.ibtn_Exit_LogIn = new FontAwesome.Sharp.IconButton();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 400);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GUI.Properties.Resources.LogoDemeter;
            this.pictureBox1.Location = new System.Drawing.Point(25, 75);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 160);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label5.Location = new System.Drawing.Point(29, 237);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 50);
            this.label5.TabIndex = 4;
            this.label5.Text = "Bienvenido/a a Demeter";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(297, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Inicie sesión";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(265, 139);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Usuario";
            // 
            // tbx_Username
            // 
            this.tbx_Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Username.Location = new System.Drawing.Point(269, 163);
            this.tbx_Username.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_Username.Name = "tbx_Username";
            this.tbx_Username.Size = new System.Drawing.Size(235, 27);
            this.tbx_Username.TabIndex = 4;
            // 
            // tbx_Password
            // 
            this.tbx_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Password.Location = new System.Drawing.Point(269, 232);
            this.tbx_Password.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_Password.Name = "tbx_Password";
            this.tbx_Password.PasswordChar = '●';
            this.tbx_Password.Size = new System.Drawing.Size(235, 27);
            this.tbx_Password.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(265, 208);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Contraseña";
            // 
            // cbx_showPassword
            // 
            this.cbx_showPassword.AutoSize = true;
            this.cbx_showPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_showPassword.Location = new System.Drawing.Point(269, 259);
            this.cbx_showPassword.Margin = new System.Windows.Forms.Padding(2);
            this.cbx_showPassword.Name = "cbx_showPassword";
            this.cbx_showPassword.Size = new System.Drawing.Size(132, 19);
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
            this.btn_Ingresar.Location = new System.Drawing.Point(269, 314);
            this.btn_Ingresar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Ingresar.Name = "btn_Ingresar";
            this.btn_Ingresar.Size = new System.Drawing.Size(115, 35);
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
            this.panel2.Location = new System.Drawing.Point(210, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(330, 32);
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
            this.ibtn_Minimized_LogIn.Location = new System.Drawing.Point(258, 0);
            this.ibtn_Minimized_LogIn.Margin = new System.Windows.Forms.Padding(2);
            this.ibtn_Minimized_LogIn.Name = "ibtn_Minimized_LogIn";
            this.ibtn_Minimized_LogIn.Size = new System.Drawing.Size(36, 32);
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
            this.ibtn_Exit_LogIn.Location = new System.Drawing.Point(294, 0);
            this.ibtn_Exit_LogIn.Margin = new System.Windows.Forms.Padding(2);
            this.ibtn_Exit_LogIn.Name = "ibtn_Exit_LogIn";
            this.ibtn_Exit_LogIn.Size = new System.Drawing.Size(36, 32);
            this.ibtn_Exit_LogIn.TabIndex = 10;
            this.ibtn_Exit_LogIn.UseVisualStyleBackColor = true;
            this.ibtn_Exit_LogIn.Click += new System.EventHandler(this.ibtn_Exit_LogIn_Click);
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            this.iconPictureBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            this.iconPictureBox1.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 28;
            this.iconPictureBox1.Location = new System.Drawing.Point(240, 162);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(28, 28);
            this.iconPictureBox1.TabIndex = 12;
            this.iconPictureBox1.TabStop = false;
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            this.iconPictureBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Key;
            this.iconPictureBox2.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 28;
            this.iconPictureBox2.Location = new System.Drawing.Point(240, 231);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(28, 28);
            this.iconPictureBox2.TabIndex = 13;
            this.iconPictureBox2.TabStop = false;
            // 
            // Frm_Login
            // 
            this.AcceptButton = this.btn_Ingresar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(540, 400);
            this.Controls.Add(this.cbx_showPassword);
            this.Controls.Add(this.tbx_Username);
            this.Controls.Add(this.tbx_Password);
            this.Controls.Add(this.iconPictureBox2);
            this.Controls.Add(this.iconPictureBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btn_Ingresar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Frm_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbx_Username;
        private System.Windows.Forms.TextBox tbx_Password;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbx_showPassword;
        private System.Windows.Forms.Button btn_Ingresar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton ibtn_Exit_LogIn;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton ibtn_Minimized_LogIn;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
    }
}

