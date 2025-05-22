namespace GUI
{
    partial class Frm_Add
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Add));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_Name = new System.Windows.Forms.TextBox();
            this.tbx_LastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_NumDoc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbx_TypeDoc = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbx_Cellphone = new System.Windows.Forms.TextBox();
            this.ibtn_Cancel = new FontAwesome.Sharp.IconButton();
            this.ibtn_Clear = new FontAwesome.Sharp.IconButton();
            this.ibtn_Add = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(701, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Agregar Vendedor";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(329, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre";
            // 
            // tbx_Name
            // 
            this.tbx_Name.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Name.Location = new System.Drawing.Point(18, 83);
            this.tbx_Name.Name = "tbx_Name";
            this.tbx_Name.Size = new System.Drawing.Size(326, 26);
            this.tbx_Name.TabIndex = 3;
            // 
            // tbx_LastName
            // 
            this.tbx_LastName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_LastName.Location = new System.Drawing.Point(353, 83);
            this.tbx_LastName.Name = "tbx_LastName";
            this.tbx_LastName.Size = new System.Drawing.Size(326, 26);
            this.tbx_LastName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(350, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(329, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Apellido";
            // 
            // tbx_NumDoc
            // 
            this.tbx_NumDoc.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_NumDoc.Location = new System.Drawing.Point(276, 152);
            this.tbx_NumDoc.Name = "tbx_NumDoc";
            this.tbx_NumDoc.Size = new System.Drawing.Size(180, 26);
            this.tbx_NumDoc.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tipo de documento";
            // 
            // cbx_TypeDoc
            // 
            this.cbx_TypeDoc.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_TypeDoc.FormattingEnabled = true;
            this.cbx_TypeDoc.Location = new System.Drawing.Point(18, 152);
            this.cbx_TypeDoc.Name = "cbx_TypeDoc";
            this.cbx_TypeDoc.Size = new System.Drawing.Size(227, 26);
            this.cbx_TypeDoc.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(273, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(183, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "N° documento";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(485, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(194, 23);
            this.label7.TabIndex = 13;
            this.label7.Text = "Teléfono";
            // 
            // tbx_Cellphone
            // 
            this.tbx_Cellphone.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Cellphone.Location = new System.Drawing.Point(488, 152);
            this.tbx_Cellphone.Name = "tbx_Cellphone";
            this.tbx_Cellphone.Size = new System.Drawing.Size(191, 26);
            this.tbx_Cellphone.TabIndex = 12;
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
            this.ibtn_Cancel.Location = new System.Drawing.Point(488, 223);
            this.ibtn_Cancel.Name = "ibtn_Cancel";
            this.ibtn_Cancel.Size = new System.Drawing.Size(116, 59);
            this.ibtn_Cancel.TabIndex = 16;
            this.ibtn_Cancel.Text = "Cancelar";
            this.ibtn_Cancel.UseVisualStyleBackColor = false;
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
            this.ibtn_Clear.Location = new System.Drawing.Point(309, 223);
            this.ibtn_Clear.Name = "ibtn_Clear";
            this.ibtn_Clear.Size = new System.Drawing.Size(116, 59);
            this.ibtn_Clear.TabIndex = 15;
            this.ibtn_Clear.Text = "Limpiar";
            this.ibtn_Clear.UseVisualStyleBackColor = false;
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
            this.ibtn_Add.Location = new System.Drawing.Point(129, 223);
            this.ibtn_Add.Name = "ibtn_Add";
            this.ibtn_Add.Size = new System.Drawing.Size(116, 59);
            this.ibtn_Add.TabIndex = 14;
            this.ibtn_Add.Text = "Agregar";
            this.ibtn_Add.UseVisualStyleBackColor = false;
            // 
            // Frm_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.ClientSize = new System.Drawing.Size(701, 318);
            this.Controls.Add(this.ibtn_Cancel);
            this.Controls.Add(this.ibtn_Clear);
            this.Controls.Add(this.ibtn_Add);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbx_Cellphone);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbx_TypeDoc);
            this.Controls.Add(this.tbx_NumDoc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbx_LastName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbx_Name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Add";
            this.Text = "Frm_Add";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbx_Name;
        private System.Windows.Forms.TextBox tbx_LastName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbx_NumDoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbx_TypeDoc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbx_Cellphone;
        private FontAwesome.Sharp.IconButton ibtn_Add;
        private FontAwesome.Sharp.IconButton ibtn_Clear;
        private FontAwesome.Sharp.IconButton ibtn_Cancel;
    }
}