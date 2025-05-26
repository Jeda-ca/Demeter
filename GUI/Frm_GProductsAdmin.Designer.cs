namespace GUI
{
    partial class Frm_GProductsAdmin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.ibtn_Clear = new FontAwesome.Sharp.IconButton();
            this.ibtn_Buscar = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgv_ListaCategorías = new System.Windows.Forms.DataGridView();
            this.tbx_Busqueda = new System.Windows.Forms.TextBox();
            this.cbx_FiltroV = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ibtn_Delete = new FontAwesome.Sharp.IconButton();
            this.ibtn_ModifyInfo = new FontAwesome.Sharp.IconButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListaCategorías)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.ibtn_Clear);
            this.panel1.Controls.Add(this.ibtn_Buscar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dgv_ListaCategorías);
            this.panel1.Controls.Add(this.tbx_Busqueda);
            this.panel1.Controls.Add(this.cbx_FiltroV);
            this.panel1.Location = new System.Drawing.Point(43, 68);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1064, 307);
            this.panel1.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label4.Location = new System.Drawing.Point(17, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 21);
            this.label4.TabIndex = 10;
            this.label4.Text = "Lista de productos";
            // 
            // ibtn_Clear
            // 
            this.ibtn_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ibtn_Clear.BackColor = System.Drawing.Color.Salmon;
            this.ibtn_Clear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtn_Clear.FlatAppearance.BorderSize = 0;
            this.ibtn_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_Clear.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.ibtn_Clear.ForeColor = System.Drawing.Color.White;
            this.ibtn_Clear.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.ibtn_Clear.IconColor = System.Drawing.Color.White;
            this.ibtn_Clear.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.ibtn_Clear.IconSize = 30;
            this.ibtn_Clear.Location = new System.Drawing.Point(1004, 45);
            this.ibtn_Clear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ibtn_Clear.Name = "ibtn_Clear";
            this.ibtn_Clear.Size = new System.Drawing.Size(39, 32);
            this.ibtn_Clear.TabIndex = 9;
            this.ibtn_Clear.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.ibtn_Clear.UseVisualStyleBackColor = false;
            this.ibtn_Clear.Click += new System.EventHandler(this.ibtn_Clear_Click);
            // 
            // ibtn_Buscar
            // 
            this.ibtn_Buscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ibtn_Buscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            this.ibtn_Buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtn_Buscar.FlatAppearance.BorderSize = 0;
            this.ibtn_Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_Buscar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.ibtn_Buscar.ForeColor = System.Drawing.Color.White;
            this.ibtn_Buscar.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.ibtn_Buscar.IconColor = System.Drawing.Color.White;
            this.ibtn_Buscar.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.ibtn_Buscar.IconSize = 23;
            this.ibtn_Buscar.Location = new System.Drawing.Point(862, 45);
            this.ibtn_Buscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ibtn_Buscar.Name = "ibtn_Buscar";
            this.ibtn_Buscar.Size = new System.Drawing.Size(133, 33);
            this.ibtn_Buscar.TabIndex = 5;
            this.ibtn_Buscar.Text = "Buscar";
            this.ibtn_Buscar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.ibtn_Buscar.UseVisualStyleBackColor = false;
            this.ibtn_Buscar.Click += new System.EventHandler(this.ibtn_Buscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label2.Location = new System.Drawing.Point(17, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Filtrar por:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label5.Location = new System.Drawing.Point(17, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1026, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "Si no se encuentra lo que necesita, lo más seguro es que no se encuentra registra" +
    "do en el sistema";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgv_ListaCategorías
            // 
            this.dgv_ListaCategorías.AllowUserToAddRows = false;
            this.dgv_ListaCategorías.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 10F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.dgv_ListaCategorías.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_ListaCategorías.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_ListaCategorías.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ListaCategorías.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgv_ListaCategorías.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_ListaCategorías.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_ListaCategorías.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ListaCategorías.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_ListaCategorías.ColumnHeadersHeight = 30;
            this.dgv_ListaCategorías.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(203)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ListaCategorías.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_ListaCategorías.EnableHeadersVisualStyles = false;
            this.dgv_ListaCategorías.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.dgv_ListaCategorías.Location = new System.Drawing.Point(21, 122);
            this.dgv_ListaCategorías.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_ListaCategorías.Name = "dgv_ListaCategorías";
            this.dgv_ListaCategorías.ReadOnly = true;
            this.dgv_ListaCategorías.RowHeadersVisible = false;
            this.dgv_ListaCategorías.RowHeadersWidth = 51;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(203)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.dgv_ListaCategorías.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_ListaCategorías.RowTemplate.Height = 24;
            this.dgv_ListaCategorías.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ListaCategorías.Size = new System.Drawing.Size(1022, 135);
            this.dgv_ListaCategorías.TabIndex = 6;
            // 
            // tbx_Busqueda
            // 
            this.tbx_Busqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_Busqueda.Font = new System.Drawing.Font("Tahoma", 12F);
            this.tbx_Busqueda.Location = new System.Drawing.Point(336, 45);
            this.tbx_Busqueda.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbx_Busqueda.Name = "tbx_Busqueda";
            this.tbx_Busqueda.Size = new System.Drawing.Size(527, 32);
            this.tbx_Busqueda.TabIndex = 4;
            // 
            // cbx_FiltroV
            // 
            this.cbx_FiltroV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_FiltroV.Font = new System.Drawing.Font("Tahoma", 11F);
            this.cbx_FiltroV.FormattingEnabled = true;
            this.cbx_FiltroV.Location = new System.Drawing.Point(21, 45);
            this.cbx_FiltroV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbx_FiltroV.Name = "cbx_FiltroV";
            this.cbx_FiltroV.Size = new System.Drawing.Size(288, 30);
            this.cbx_FiltroV.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1155, 50);
            this.label1.TabIndex = 17;
            this.label1.Text = "  Gestor de Productos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.panel2.Controls.Add(this.ibtn_Delete);
            this.panel2.Controls.Add(this.ibtn_ModifyInfo);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(43, 393);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1064, 202);
            this.panel2.TabIndex = 21;
            // 
            // ibtn_Delete
            // 
            this.ibtn_Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_Delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtn_Delete.FlatAppearance.BorderSize = 0;
            this.ibtn_Delete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.ibtn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_Delete.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.ibtn_Delete.ForeColor = System.Drawing.Color.White;
            this.ibtn_Delete.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.ibtn_Delete.IconColor = System.Drawing.Color.White;
            this.ibtn_Delete.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.ibtn_Delete.IconSize = 32;
            this.ibtn_Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ibtn_Delete.Location = new System.Drawing.Point(374, 54);
            this.ibtn_Delete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ibtn_Delete.Name = "ibtn_Delete";
            this.ibtn_Delete.Size = new System.Drawing.Size(228, 95);
            this.ibtn_Delete.TabIndex = 8;
            this.ibtn_Delete.Text = "Eliminar";
            this.ibtn_Delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtn_Delete.UseVisualStyleBackColor = false;
            this.ibtn_Delete.Click += new System.EventHandler(this.ibtn_Delete_Click);
            // 
            // ibtn_ModifyInfo
            // 
            this.ibtn_ModifyInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_ModifyInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtn_ModifyInfo.FlatAppearance.BorderSize = 0;
            this.ibtn_ModifyInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.ibtn_ModifyInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_ModifyInfo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.ibtn_ModifyInfo.ForeColor = System.Drawing.Color.White;
            this.ibtn_ModifyInfo.IconChar = FontAwesome.Sharp.IconChar.FileSignature;
            this.ibtn_ModifyInfo.IconColor = System.Drawing.Color.White;
            this.ibtn_ModifyInfo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_ModifyInfo.IconSize = 38;
            this.ibtn_ModifyInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ibtn_ModifyInfo.Location = new System.Drawing.Point(21, 54);
            this.ibtn_ModifyInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ibtn_ModifyInfo.Name = "ibtn_ModifyInfo";
            this.ibtn_ModifyInfo.Size = new System.Drawing.Size(228, 95);
            this.ibtn_ModifyInfo.TabIndex = 7;
            this.ibtn_ModifyInfo.Text = "Modificar información";
            this.ibtn_ModifyInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtn_ModifyInfo.UseVisualStyleBackColor = false;
            this.ibtn_ModifyInfo.Click += new System.EventHandler(this.ibtn_ModifyInfo_Click);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1064, 37);
            this.label3.TabIndex = 0;
            this.label3.Text = "Controles de gestión";
            // 
            // Frm_GProductsAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(1155, 618);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "Frm_GProductsAdmin";
            this.Text = "Frm_GProductsAdmin";
            this.Load += new System.EventHandler(this.Frm_GProductsAdmin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListaCategorías)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private FontAwesome.Sharp.IconButton ibtn_Clear;
        private FontAwesome.Sharp.IconButton ibtn_Buscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv_ListaCategorías;
        private System.Windows.Forms.TextBox tbx_Busqueda;
        private System.Windows.Forms.ComboBox cbx_FiltroV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton ibtn_Delete;
        private FontAwesome.Sharp.IconButton ibtn_ModifyInfo;
        private System.Windows.Forms.Label label3;
    }
}