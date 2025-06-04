namespace GUI
{
    partial class Frm_ClientsReport
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.ibtn_GenReport = new FontAwesome.Sharp.IconButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ibtn_OKCustomDate = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.cbx_DateFilter = new System.Windows.Forms.ComboBox();
            this.dtp_FFin = new System.Windows.Forms.DateTimePicker();
            this.dtp_FInicio = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dgv_ReportesVentxVend = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ReportesVentxVend)).BeginInit();
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
            this.label1.TabIndex = 21;
            this.label1.Text = "  Reporte de Clientes";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.panel2.Controls.Add(this.ibtn_GenReport);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(43, 475);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1064, 174);
            this.panel2.TabIndex = 24;
            // 
            // ibtn_GenReport
            // 
            this.ibtn_GenReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_GenReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtn_GenReport.FlatAppearance.BorderSize = 0;
            this.ibtn_GenReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.ibtn_GenReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_GenReport.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.ibtn_GenReport.ForeColor = System.Drawing.Color.White;
            this.ibtn_GenReport.IconChar = FontAwesome.Sharp.IconChar.FileExport;
            this.ibtn_GenReport.IconColor = System.Drawing.Color.White;
            this.ibtn_GenReport.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_GenReport.IconSize = 42;
            this.ibtn_GenReport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ibtn_GenReport.Location = new System.Drawing.Point(20, 54);
            this.ibtn_GenReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ibtn_GenReport.Name = "ibtn_GenReport";
            this.ibtn_GenReport.Size = new System.Drawing.Size(228, 95);
            this.ibtn_GenReport.TabIndex = 9;
            this.ibtn_GenReport.Text = "Generar";
            this.ibtn_GenReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtn_GenReport.UseVisualStyleBackColor = false;
            this.ibtn_GenReport.Click += new System.EventHandler(this.ibtn_GenReport_Click);
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
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.panel1.Controls.Add(this.ibtn_OKCustomDate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbx_DateFilter);
            this.panel1.Controls.Add(this.dtp_FFin);
            this.panel1.Controls.Add(this.dtp_FInicio);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dgv_ReportesVentxVend);
            this.panel1.Location = new System.Drawing.Point(43, 68);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1064, 381);
            this.panel1.TabIndex = 25;
            // 
            // ibtn_OKCustomDate
            // 
            this.ibtn_OKCustomDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ibtn_OKCustomDate.BackColor = System.Drawing.Color.Teal;
            this.ibtn_OKCustomDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtn_OKCustomDate.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.ibtn_OKCustomDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_OKCustomDate.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.ibtn_OKCustomDate.IconColor = System.Drawing.Color.White;
            this.ibtn_OKCustomDate.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_OKCustomDate.IconSize = 30;
            this.ibtn_OKCustomDate.Location = new System.Drawing.Point(995, 14);
            this.ibtn_OKCustomDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ibtn_OKCustomDate.Name = "ibtn_OKCustomDate";
            this.ibtn_OKCustomDate.Size = new System.Drawing.Size(48, 38);
            this.ibtn_OKCustomDate.TabIndex = 14;
            this.ibtn_OKCustomDate.UseVisualStyleBackColor = false;
            this.ibtn_OKCustomDate.Click += new System.EventHandler(this.ibtn_OKCustomDate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label2.Location = new System.Drawing.Point(18, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "Filtrar por:";
            // 
            // cbx_DateFilter
            // 
            this.cbx_DateFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_DateFilter.Font = new System.Drawing.Font("Tahoma", 11F);
            this.cbx_DateFilter.FormattingEnabled = true;
            this.cbx_DateFilter.Location = new System.Drawing.Point(21, 28);
            this.cbx_DateFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbx_DateFilter.Name = "cbx_DateFilter";
            this.cbx_DateFilter.Size = new System.Drawing.Size(251, 30);
            this.cbx_DateFilter.TabIndex = 13;
            // 
            // dtp_FFin
            // 
            this.dtp_FFin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtp_FFin.CustomFormat = "MMM dd, yyyy";
            this.dtp_FFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_FFin.Location = new System.Drawing.Point(805, 20);
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
            this.dtp_FInicio.Location = new System.Drawing.Point(591, 20);
            this.dtp_FInicio.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_FInicio.Name = "dtp_FInicio";
            this.dtp_FInicio.Size = new System.Drawing.Size(168, 22);
            this.dtp_FInicio.TabIndex = 12;
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
            this.dgv_ReportesVentxVend.Location = new System.Drawing.Point(21, 62);
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
            this.dgv_ReportesVentxVend.Size = new System.Drawing.Size(1022, 269);
            this.dgv_ReportesVentxVend.TabIndex = 6;
            // 
            // Frm_ClientsReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(1155, 674);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Name = "Frm_ClientsReport";
            this.Load += new System.EventHandler(this.Frm_ClientsReport_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ReportesVentxVend)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton ibtn_GenReport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtp_FFin;
        private System.Windows.Forms.DateTimePicker dtp_FInicio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv_ReportesVentxVend;
        private System.Windows.Forms.ComboBox cbx_DateFilter;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton ibtn_OKCustomDate;
    }
}