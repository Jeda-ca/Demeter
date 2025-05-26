namespace GUI
{
    partial class Frm_AddVendorAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AddVendorAdmin));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbx_Cellphone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbx_TypeDoc = new System.Windows.Forms.ComboBox();
            this.tbx_NumDoc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbx_LastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_Name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbx_Password = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbx_Username = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ibtn_Cancel = new FontAwesome.Sharp.IconButton();
            this.ibtn_Clear = new FontAwesome.Sharp.IconButton();
            this.ibtn_Add = new FontAwesome.Sharp.IconButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(992, 49);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registrar Vendedor";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbx_Cellphone);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbx_TypeDoc);
            this.groupBox1.Controls.Add(this.tbx_NumDoc);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbx_LastName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbx_Name);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.groupBox1.Location = new System.Drawing.Point(22, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(948, 208);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información personal";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(657, 118);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(259, 28);
            this.label7.TabIndex = 23;
            this.label7.Text = "Teléfono";
            // 
            // tbx_Cellphone
            // 
            this.tbx_Cellphone.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Cellphone.Location = new System.Drawing.Point(661, 150);
            this.tbx_Cellphone.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_Cellphone.Name = "tbx_Cellphone";
            this.tbx_Cellphone.Size = new System.Drawing.Size(253, 30);
            this.tbx_Cellphone.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(374, 118);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(244, 28);
            this.label5.TabIndex = 22;
            this.label5.Text = "N° documento";
            // 
            // cbx_TypeDoc
            // 
            this.cbx_TypeDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_TypeDoc.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_TypeDoc.FormattingEnabled = true;
            this.cbx_TypeDoc.Items.AddRange(new object[] {
            "--Seleccione una opción--",
            "C.C",
            "C.E"});
            this.cbx_TypeDoc.Location = new System.Drawing.Point(34, 150);
            this.cbx_TypeDoc.Margin = new System.Windows.Forms.Padding(4);
            this.cbx_TypeDoc.Name = "cbx_TypeDoc";
            this.cbx_TypeDoc.Size = new System.Drawing.Size(301, 31);
            this.cbx_TypeDoc.TabIndex = 16;
            // 
            // tbx_NumDoc
            // 
            this.tbx_NumDoc.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_NumDoc.Location = new System.Drawing.Point(378, 150);
            this.tbx_NumDoc.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_NumDoc.Name = "tbx_NumDoc";
            this.tbx_NumDoc.Size = new System.Drawing.Size(239, 30);
            this.tbx_NumDoc.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 118);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(244, 28);
            this.label4.TabIndex = 21;
            this.label4.Text = "Tipo de documento";
            // 
            // tbx_LastName
            // 
            this.tbx_LastName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_LastName.Location = new System.Drawing.Point(481, 65);
            this.tbx_LastName.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_LastName.Name = "tbx_LastName";
            this.tbx_LastName.Size = new System.Drawing.Size(433, 30);
            this.tbx_LastName.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(477, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(439, 28);
            this.label3.TabIndex = 20;
            this.label3.Text = "Apellido";
            // 
            // tbx_Name
            // 
            this.tbx_Name.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Name.Location = new System.Drawing.Point(34, 65);
            this.tbx_Name.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_Name.Name = "tbx_Name";
            this.tbx_Name.Size = new System.Drawing.Size(433, 30);
            this.tbx_Name.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(439, 28);
            this.label2.TabIndex = 17;
            this.label2.Text = "Nombre";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.groupBox2.Controls.Add(this.tbx_Password);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.tbx_Username);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.groupBox2.Location = new System.Drawing.Point(22, 284);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(948, 131);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Credenciales de Usuario";
            // 
            // tbx_Password
            // 
            this.tbx_Password.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Password.Location = new System.Drawing.Point(378, 65);
            this.tbx_Password.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_Password.Name = "tbx_Password";
            this.tbx_Password.Size = new System.Drawing.Size(300, 30);
            this.tbx_Password.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(374, 33);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(304, 28);
            this.label10.TabIndex = 20;
            this.label10.Text = "Contraseña";
            // 
            // tbx_Username
            // 
            this.tbx_Username.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Username.Location = new System.Drawing.Point(34, 65);
            this.tbx_Username.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_Username.Name = "tbx_Username";
            this.tbx_Username.Size = new System.Drawing.Size(300, 30);
            this.tbx_Username.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(30, 33);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(304, 28);
            this.label11.TabIndex = 17;
            this.label11.Text = "Nombre ";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.groupBox3.Controls.Add(this.ibtn_Cancel);
            this.groupBox3.Controls.Add(this.ibtn_Clear);
            this.groupBox3.Controls.Add(this.ibtn_Add);
            this.groupBox3.Location = new System.Drawing.Point(22, 440);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(948, 106);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            // 
            // ibtn_Cancel
            // 
            this.ibtn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ibtn_Cancel.BackColor = System.Drawing.Color.Teal;
            this.ibtn_Cancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ibtn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_Cancel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.ibtn_Cancel.ForeColor = System.Drawing.SystemColors.Control;
            this.ibtn_Cancel.IconChar = FontAwesome.Sharp.IconChar.None;
            this.ibtn_Cancel.IconColor = System.Drawing.Color.Black;
            this.ibtn_Cancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_Cancel.Location = new System.Drawing.Point(761, 16);
            this.ibtn_Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.ibtn_Cancel.Name = "ibtn_Cancel";
            this.ibtn_Cancel.Size = new System.Drawing.Size(155, 73);
            this.ibtn_Cancel.TabIndex = 7;
            this.ibtn_Cancel.Text = "Cancelar";
            this.ibtn_Cancel.UseVisualStyleBackColor = false;
            this.ibtn_Cancel.Click += new System.EventHandler(this.ibtn_Cancel_Click);
            // 
            // ibtn_Clear
            // 
            this.ibtn_Clear.BackColor = System.Drawing.Color.Teal;
            this.ibtn_Clear.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ibtn_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_Clear.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.ibtn_Clear.ForeColor = System.Drawing.SystemColors.Control;
            this.ibtn_Clear.IconChar = FontAwesome.Sharp.IconChar.None;
            this.ibtn_Clear.IconColor = System.Drawing.Color.Black;
            this.ibtn_Clear.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_Clear.Location = new System.Drawing.Point(263, 16);
            this.ibtn_Clear.Margin = new System.Windows.Forms.Padding(4);
            this.ibtn_Clear.Name = "ibtn_Clear";
            this.ibtn_Clear.Size = new System.Drawing.Size(155, 73);
            this.ibtn_Clear.TabIndex = 6;
            this.ibtn_Clear.Text = "Limpiar";
            this.ibtn_Clear.UseVisualStyleBackColor = false;
            this.ibtn_Clear.Click += new System.EventHandler(this.ibtn_Clear_Click);
            // 
            // ibtn_Add
            // 
            this.ibtn_Add.BackColor = System.Drawing.Color.Teal;
            this.ibtn_Add.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ibtn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_Add.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.ibtn_Add.ForeColor = System.Drawing.SystemColors.Control;
            this.ibtn_Add.IconChar = FontAwesome.Sharp.IconChar.None;
            this.ibtn_Add.IconColor = System.Drawing.Color.Black;
            this.ibtn_Add.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_Add.Location = new System.Drawing.Point(33, 16);
            this.ibtn_Add.Margin = new System.Windows.Forms.Padding(4);
            this.ibtn_Add.Name = "ibtn_Add";
            this.ibtn_Add.Size = new System.Drawing.Size(155, 73);
            this.ibtn_Add.TabIndex = 5;
            this.ibtn_Add.Text = "Agregar";
            this.ibtn_Add.UseVisualStyleBackColor = false;
            this.ibtn_Add.Click += new System.EventHandler(this.ibtn_Add_Click);
            // 
            // Frm_AddVendorAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(992, 574);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_AddVendorAdmin";
            this.Text = "Demeter";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton ibtn_Add;
        private FontAwesome.Sharp.IconButton ibtn_Clear;
        private FontAwesome.Sharp.IconButton ibtn_Cancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbx_Cellphone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbx_TypeDoc;
        private System.Windows.Forms.TextBox tbx_NumDoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbx_LastName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbx_Name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbx_Password;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbx_Username;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}