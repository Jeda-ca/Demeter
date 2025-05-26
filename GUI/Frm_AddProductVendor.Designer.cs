namespace GUI
{
    partial class Frm_AddProductVendor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AddProductVendor));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ibtn_Cancel = new FontAwesome.Sharp.IconButton();
            this.ibtn_Clear = new FontAwesome.Sharp.IconButton();
            this.ibtn_Add = new FontAwesome.Sharp.IconButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nud_Stock = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.cbx_UnMedida = new System.Windows.Forms.ComboBox();
            this.nud_Price = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbx_Category = new System.Windows.Forms.ComboBox();
            this.tbx_NumDoc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_Name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Stock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Price)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(992, 49);
            this.label1.TabIndex = 19;
            this.label1.Text = "Agregar Producto";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.groupBox3.Controls.Add(this.ibtn_Cancel);
            this.groupBox3.Controls.Add(this.ibtn_Clear);
            this.groupBox3.Controls.Add(this.ibtn_Add);
            this.groupBox3.Location = new System.Drawing.Point(22, 375);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(948, 106);
            this.groupBox3.TabIndex = 30;
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
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.groupBox1.Controls.Add(this.nud_Stock);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbx_UnMedida);
            this.groupBox1.Controls.Add(this.nud_Price);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbx_Category);
            this.groupBox1.Controls.Add(this.tbx_NumDoc);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbx_Name);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.groupBox1.Location = new System.Drawing.Point(22, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(948, 295);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información";
            // 
            // nud_Stock
            // 
            this.nud_Stock.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.nud_Stock.Location = new System.Drawing.Point(642, 150);
            this.nud_Stock.Name = "nud_Stock";
            this.nud_Stock.Size = new System.Drawing.Size(279, 30);
            this.nud_Stock.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(638, 33);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(279, 28);
            this.label6.TabIndex = 26;
            this.label6.Text = "Unidad de medida";
            // 
            // cbx_UnMedida
            // 
            this.cbx_UnMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_UnMedida.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_UnMedida.FormattingEnabled = true;
            this.cbx_UnMedida.Location = new System.Drawing.Point(642, 65);
            this.cbx_UnMedida.Margin = new System.Windows.Forms.Padding(4);
            this.cbx_UnMedida.Name = "cbx_UnMedida";
            this.cbx_UnMedida.Size = new System.Drawing.Size(277, 31);
            this.cbx_UnMedida.TabIndex = 25;
            // 
            // nud_Price
            // 
            this.nud_Price.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.nud_Price.Location = new System.Drawing.Point(642, 238);
            this.nud_Price.Name = "nud_Price";
            this.nud_Price.Size = new System.Drawing.Size(279, 30);
            this.nud_Price.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(642, 118);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(277, 28);
            this.label7.TabIndex = 23;
            this.label7.Text = "Stock";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 118);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(280, 28);
            this.label5.TabIndex = 22;
            this.label5.Text = "Descripción";
            // 
            // cbx_Category
            // 
            this.cbx_Category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Category.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_Category.FormattingEnabled = true;
            this.cbx_Category.Location = new System.Drawing.Point(338, 65);
            this.cbx_Category.Margin = new System.Windows.Forms.Padding(4);
            this.cbx_Category.Name = "cbx_Category";
            this.cbx_Category.Size = new System.Drawing.Size(275, 31);
            this.cbx_Category.TabIndex = 16;
            // 
            // tbx_NumDoc
            // 
            this.tbx_NumDoc.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_NumDoc.Location = new System.Drawing.Point(34, 150);
            this.tbx_NumDoc.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_NumDoc.Multiline = true;
            this.tbx_NumDoc.Name = "tbx_NumDoc";
            this.tbx_NumDoc.Size = new System.Drawing.Size(579, 118);
            this.tbx_NumDoc.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(334, 33);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(279, 28);
            this.label4.TabIndex = 21;
            this.label4.Text = "Categoría";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(642, 206);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(281, 28);
            this.label3.TabIndex = 20;
            this.label3.Text = "Precio";
            // 
            // tbx_Name
            // 
            this.tbx_Name.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Name.Location = new System.Drawing.Point(34, 65);
            this.tbx_Name.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_Name.Name = "tbx_Name";
            this.tbx_Name.Size = new System.Drawing.Size(277, 30);
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
            // Frm_AddProductVendor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(992, 495);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_AddProductVendor";
            this.Text = "Demeter";
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Stock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Price)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private FontAwesome.Sharp.IconButton ibtn_Cancel;
        private FontAwesome.Sharp.IconButton ibtn_Clear;
        private FontAwesome.Sharp.IconButton ibtn_Add;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nud_Stock;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbx_UnMedida;
        private System.Windows.Forms.NumericUpDown nud_Price;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbx_Category;
        private System.Windows.Forms.TextBox tbx_NumDoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbx_Name;
        private System.Windows.Forms.Label label2;
    }
}