namespace GUI
{
    partial class Frm_InventoryByVendorReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtp_FFin = new System.Windows.Forms.DateTimePicker();
            this.dtp_FInicio = new System.Windows.Forms.DateTimePicker();
            this.ibtn_Clear = new FontAwesome.Sharp.IconButton();
            this.ibtn_Buscar = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgv_ReportesVentxVend = new System.Windows.Forms.DataGridView();
            this.tbx_Busqueda = new System.Windows.Forms.TextBox();
            this.cbx_FiltroV = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ibtn_Add = new FontAwesome.Sharp.IconButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ReportesVentxVend)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1155, 50);
            this.label1.TabIndex = 19;
            this.label1.Text = "  Reporte de Inventario x Vendedor";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.panel1.Controls.Add(this.dtp_FFin);
            this.panel1.Controls.Add(this.dtp_FInicio);
            this.panel1.Controls.Add(this.ibtn_Clear);
            this.panel1.Controls.Add(this.ibtn_Buscar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dgv_ReportesVentxVend);
            this.panel1.Controls.Add(this.tbx_Busqueda);
            this.panel1.Controls.Add(this.cbx_FiltroV);
            this.panel1.Location = new System.Drawing.Point(43, 68);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1064, 381);
            this.panel1.TabIndex = 20;
            // 
            // dtp_FFin
            // 
            this.dtp_FFin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtp_FFin.CustomFormat = "MMM dd, yyyy";
            this.dtp_FFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_FFin.Location = new System.Drawing.Point(875, 56);
            this.dtp_FFin.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_FFin.Name = "dtp_FFin";
            this.dtp_FFin.Size = new System.Drawing.Size(168, 22);
            this.dtp_FFin.TabIndex = 11;
            // 
            // dtp_FInicio
            // 
            this.dtp_FInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtp_FInicio.CustomFormat = "MMM dd, yyyy";
            this.dtp_FInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_FInicio.Location = new System.Drawing.Point(875, 22);
            this.dtp_FInicio.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_FInicio.Name = "dtp_FInicio";
            this.dtp_FInicio.Size = new System.Drawing.Size(168, 22);
            this.dtp_FInicio.TabIndex = 12;
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
            this.ibtn_Clear.Location = new System.Drawing.Point(819, 45);
            this.ibtn_Clear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ibtn_Clear.Name = "ibtn_Clear";
            this.ibtn_Clear.Size = new System.Drawing.Size(39, 32);
            this.ibtn_Clear.TabIndex = 9;
            this.ibtn_Clear.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.ibtn_Clear.UseVisualStyleBackColor = false;
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
            this.ibtn_Buscar.Location = new System.Drawing.Point(677, 45);
            this.ibtn_Buscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ibtn_Buscar.Name = "ibtn_Buscar";
            this.ibtn_Buscar.Size = new System.Drawing.Size(133, 33);
            this.ibtn_Buscar.TabIndex = 5;
            this.ibtn_Buscar.Text = "Buscar";
            this.ibtn_Buscar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.ibtn_Buscar.UseVisualStyleBackColor = false;
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
            this.label5.Location = new System.Drawing.Point(17, 343);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1026, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "Si no se encuentra lo que necesita, lo más seguro es que no se encuentra registra" +
    "do en el sistema";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgv_ReportesVentxVend
            // 
            this.dgv_ReportesVentxVend.AllowUserToAddRows = false;
            this.dgv_ReportesVentxVend.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgv_ReportesVentxVend.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ReportesVentxVend.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_ReportesVentxVend.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ReportesVentxVend.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgv_ReportesVentxVend.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_ReportesVentxVend.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_ReportesVentxVend.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ReportesVentxVend.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_ReportesVentxVend.ColumnHeadersHeight = 30;
            this.dgv_ReportesVentxVend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(203)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ReportesVentxVend.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_ReportesVentxVend.EnableHeadersVisualStyles = false;
            this.dgv_ReportesVentxVend.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.dgv_ReportesVentxVend.Location = new System.Drawing.Point(21, 103);
            this.dgv_ReportesVentxVend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_ReportesVentxVend.Name = "dgv_ReportesVentxVend";
            this.dgv_ReportesVentxVend.ReadOnly = true;
            this.dgv_ReportesVentxVend.RowHeadersVisible = false;
            this.dgv_ReportesVentxVend.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(203)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.dgv_ReportesVentxVend.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_ReportesVentxVend.RowTemplate.Height = 24;
            this.dgv_ReportesVentxVend.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ReportesVentxVend.Size = new System.Drawing.Size(1022, 228);
            this.dgv_ReportesVentxVend.TabIndex = 6;
            // 
            // tbx_Busqueda
            // 
            this.tbx_Busqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_Busqueda.Font = new System.Drawing.Font("Tahoma", 12F);
            this.tbx_Busqueda.Location = new System.Drawing.Point(299, 45);
            this.tbx_Busqueda.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbx_Busqueda.Name = "tbx_Busqueda";
            this.tbx_Busqueda.Size = new System.Drawing.Size(381, 32);
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
            this.cbx_FiltroV.Size = new System.Drawing.Size(251, 30);
            this.cbx_FiltroV.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.panel2.Controls.Add(this.ibtn_Add);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(43, 476);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1064, 174);
            this.panel2.TabIndex = 23;
            // 
            // ibtn_Add
            // 
            this.ibtn_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_Add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtn_Add.FlatAppearance.BorderSize = 0;
            this.ibtn_Add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.ibtn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_Add.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.ibtn_Add.ForeColor = System.Drawing.Color.White;
            this.ibtn_Add.IconChar = FontAwesome.Sharp.IconChar.FileExport;
            this.ibtn_Add.IconColor = System.Drawing.Color.White;
            this.ibtn_Add.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_Add.IconSize = 42;
            this.ibtn_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ibtn_Add.Location = new System.Drawing.Point(20, 54);
            this.ibtn_Add.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ibtn_Add.Name = "ibtn_Add";
            this.ibtn_Add.Size = new System.Drawing.Size(228, 95);
            this.ibtn_Add.TabIndex = 9;
            this.ibtn_Add.Text = "Generar";
            this.ibtn_Add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtn_Add.UseVisualStyleBackColor = false;
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
            this.label3.Text = "Generar reporte";
            // 
            // Frm_InventoryByVendorReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(1155, 674);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "Frm_InventoryByVendorReport";
            this.Load += new System.EventHandler(this.Frm_InventoryByVendorReport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ReportesVentxVend)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtp_FFin;
        private System.Windows.Forms.DateTimePicker dtp_FInicio;
        private FontAwesome.Sharp.IconButton ibtn_Clear;
        private FontAwesome.Sharp.IconButton ibtn_Buscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv_ReportesVentxVend;
        private System.Windows.Forms.TextBox tbx_Busqueda;
        private System.Windows.Forms.ComboBox cbx_FiltroV;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton ibtn_Add;
        private System.Windows.Forms.Label label3;
    }
}