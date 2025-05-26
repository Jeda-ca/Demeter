namespace GUI
{
    partial class Frm_ModifyVendorAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ModifyVendorAdmin));
            this.ibtn_Cancel = new FontAwesome.Sharp.IconButton();
            this.ibtn_Clear = new FontAwesome.Sharp.IconButton();
            this.ibtn_Modify = new FontAwesome.Sharp.IconButton();
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ibtn_Cancel
            // 
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
            this.ibtn_Cancel.TabIndex = 30;
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
            this.ibtn_Clear.TabIndex = 29;
            this.ibtn_Clear.Text = "Limpiar";
            this.ibtn_Clear.UseVisualStyleBackColor = false;
            this.ibtn_Clear.Click += new System.EventHandler(this.ibtn_Clear_Click);
            // 
            // ibtn_Modify
            // 
            this.ibtn_Modify.BackColor = System.Drawing.Color.Teal;
            this.ibtn_Modify.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ibtn_Modify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_Modify.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.ibtn_Modify.ForeColor = System.Drawing.SystemColors.Control;
            this.ibtn_Modify.IconChar = FontAwesome.Sharp.IconChar.None;
            this.ibtn_Modify.IconColor = System.Drawing.Color.Black;
            this.ibtn_Modify.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_Modify.Location = new System.Drawing.Point(34, 16);
            this.ibtn_Modify.Margin = new System.Windows.Forms.Padding(4);
            this.ibtn_Modify.Name = "ibtn_Modify";
            this.ibtn_Modify.Size = new System.Drawing.Size(155, 73);
            this.ibtn_Modify.TabIndex = 28;
            this.ibtn_Modify.Text = "Guardar cambios";
            this.ibtn_Modify.UseVisualStyleBackColor = false;
            this.ibtn_Modify.Click += new System.EventHandler(this.ibtn_Modify_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(992, 49);
            this.label1.TabIndex = 17;
            this.label1.Text = "Modificar Datos personales de Vendedor";
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
            this.groupBox1.Size = new System.Drawing.Size(948, 210);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información personal";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(657, 120);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(259, 28);
            this.label7.TabIndex = 23;
            this.label7.Text = "Teléfono";
            // 
            // tbx_Cellphone
            // 
            this.tbx_Cellphone.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Cellphone.Location = new System.Drawing.Point(661, 152);
            this.tbx_Cellphone.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_Cellphone.Name = "tbx_Cellphone";
            this.tbx_Cellphone.Size = new System.Drawing.Size(253, 30);
            this.tbx_Cellphone.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(374, 120);
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
            this.cbx_TypeDoc.Location = new System.Drawing.Point(34, 152);
            this.cbx_TypeDoc.Margin = new System.Windows.Forms.Padding(4);
            this.cbx_TypeDoc.Name = "cbx_TypeDoc";
            this.cbx_TypeDoc.Size = new System.Drawing.Size(301, 31);
            this.cbx_TypeDoc.TabIndex = 16;
            // 
            // tbx_NumDoc
            // 
            this.tbx_NumDoc.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_NumDoc.Location = new System.Drawing.Point(378, 152);
            this.tbx_NumDoc.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_NumDoc.Name = "tbx_NumDoc";
            this.tbx_NumDoc.Size = new System.Drawing.Size(239, 30);
            this.tbx_NumDoc.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 120);
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
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.groupBox3.Controls.Add(this.ibtn_Modify);
            this.groupBox3.Controls.Add(this.ibtn_Clear);
            this.groupBox3.Controls.Add(this.ibtn_Cancel);
            this.groupBox3.Location = new System.Drawing.Point(22, 284);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(948, 106);
            this.groupBox3.TabIndex = 49;
            this.groupBox3.TabStop = false;
            // 
            // Frm_ModifyVendorAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(992, 410);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_ModifyVendorAdmin";
            this.Text = "Demeter";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton ibtn_Cancel;
        private FontAwesome.Sharp.IconButton ibtn_Clear;
        private FontAwesome.Sharp.IconButton ibtn_Modify;
        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.GroupBox groupBox3;
    }
}