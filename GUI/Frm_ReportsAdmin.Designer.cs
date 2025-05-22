namespace GUI
{
    partial class Frm_ReportsAdmin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelFiltro = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cbx_FiltroReport = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ibtn_Buscar = new FontAwesome.Sharp.IconButton();
            this.label5 = new System.Windows.Forms.Label();
            this.dgv_Reportes = new System.Windows.Forms.DataGridView();
            this.tbx_BusqReport = new System.Windows.Forms.TextBox();
            this.cbx_TipoReport = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panelFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Reportes)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.panel1.Controls.Add(this.panelFiltro);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ibtn_Buscar);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dgv_Reportes);
            this.panel1.Controls.Add(this.tbx_BusqReport);
            this.panel1.Controls.Add(this.cbx_TipoReport);
            this.panel1.Location = new System.Drawing.Point(11, 11);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(844, 573);
            this.panel1.TabIndex = 10;
            // 
            // panelFiltro
            // 
            this.panelFiltro.Controls.Add(this.label3);
            this.panelFiltro.Controls.Add(this.cbx_FiltroReport);
            this.panelFiltro.Location = new System.Drawing.Point(289, 44);
            this.panelFiltro.Name = "panelFiltro";
            this.panelFiltro.Size = new System.Drawing.Size(213, 62);
            this.panelFiltro.TabIndex = 0;
            this.panelFiltro.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label3.Location = new System.Drawing.Point(4, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "Filtrar por:";
            // 
            // cbx_FiltroReport
            // 
            this.cbx_FiltroReport.Font = new System.Drawing.Font("Tahoma", 11F);
            this.cbx_FiltroReport.FormattingEnabled = true;
            this.cbx_FiltroReport.Location = new System.Drawing.Point(7, 25);
            this.cbx_FiltroReport.Margin = new System.Windows.Forms.Padding(2);
            this.cbx_FiltroReport.Name = "cbx_FiltroReport";
            this.cbx_FiltroReport.Size = new System.Drawing.Size(198, 26);
            this.cbx_FiltroReport.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(844, 41);
            this.label1.TabIndex = 9;
            this.label1.Text = "Reportes";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label2.Location = new System.Drawing.Point(13, 56);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tipo:";
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
            this.ibtn_Buscar.IconSize = 20;
            this.ibtn_Buscar.Location = new System.Drawing.Point(728, 102);
            this.ibtn_Buscar.Margin = new System.Windows.Forms.Padding(2);
            this.ibtn_Buscar.Name = "ibtn_Buscar";
            this.ibtn_Buscar.Size = new System.Drawing.Size(100, 36);
            this.ibtn_Buscar.TabIndex = 6;
            this.ibtn_Buscar.Text = "Buscar";
            this.ibtn_Buscar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.ibtn_Buscar.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label5.Location = new System.Drawing.Point(13, 542);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(815, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Si no se encuentra lo que necesita, lo más seguro es que no se encuentra registra" +
    "do en el sistema";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgv_Reportes
            // 
            this.dgv_Reportes.AllowUserToAddRows = false;
            this.dgv_Reportes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgv_Reportes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Reportes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Reportes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Reportes.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgv_Reportes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Reportes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_Reportes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Reportes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Reportes.ColumnHeadersHeight = 30;
            this.dgv_Reportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(203)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Reportes.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Reportes.EnableHeadersVisualStyles = false;
            this.dgv_Reportes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.dgv_Reportes.Location = new System.Drawing.Point(16, 150);
            this.dgv_Reportes.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_Reportes.Name = "dgv_Reportes";
            this.dgv_Reportes.ReadOnly = true;
            this.dgv_Reportes.RowHeadersVisible = false;
            this.dgv_Reportes.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(203)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.dgv_Reportes.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_Reportes.RowTemplate.Height = 24;
            this.dgv_Reportes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Reportes.Size = new System.Drawing.Size(812, 382);
            this.dgv_Reportes.TabIndex = 2;
            // 
            // tbx_BusqReport
            // 
            this.tbx_BusqReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_BusqReport.Font = new System.Drawing.Font("Tahoma", 12F);
            this.tbx_BusqReport.Location = new System.Drawing.Point(16, 111);
            this.tbx_BusqReport.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_BusqReport.Name = "tbx_BusqReport";
            this.tbx_BusqReport.Size = new System.Drawing.Size(708, 27);
            this.tbx_BusqReport.TabIndex = 1;
            // 
            // cbx_TipoReport
            // 
            this.cbx_TipoReport.Font = new System.Drawing.Font("Tahoma", 11F);
            this.cbx_TipoReport.FormattingEnabled = true;
            this.cbx_TipoReport.Location = new System.Drawing.Point(16, 72);
            this.cbx_TipoReport.Margin = new System.Windows.Forms.Padding(2);
            this.cbx_TipoReport.Name = "cbx_TipoReport";
            this.cbx_TipoReport.Size = new System.Drawing.Size(241, 26);
            this.cbx_TipoReport.TabIndex = 0;
            this.cbx_TipoReport.SelectedIndexChanged += new System.EventHandler(this.cbx_TipoReport_SelectedIndexChanged);
            // 
            // Frm_ReportsAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(866, 595);
            this.Controls.Add(this.panel1);
            this.Name = "Frm_ReportsAdmin";
            this.Text = "Frm_ReportsAdmin";
            this.Load += new System.EventHandler(this.Frm_Reports_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelFiltro.ResumeLayout(false);
            this.panelFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Reportes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton ibtn_Buscar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv_Reportes;
        private System.Windows.Forms.TextBox tbx_BusqReport;
        private System.Windows.Forms.ComboBox cbx_TipoReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbx_FiltroReport;
        private System.Windows.Forms.Panel panelFiltro;
    }
}


//namespace GUI
//{
//    partial class Frm_Reports
//    {
//        /// <summary>
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        /// Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        /// <summary>
//        /// Required method for Designer support - do not modify
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
//            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
//            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
//            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
//            this.panel1 = new System.Windows.Forms.Panel();
//            this.label3 = new System.Windows.Forms.Label();
//            this.cbx_FiltroReport = new System.Windows.Forms.ComboBox();
//            this.label1 = new System.Windows.Forms.Label();
//            this.label2 = new System.Windows.Forms.Label();
//            this.ibtn_Buscar = new FontAwesome.Sharp.IconButton();
//            this.label5 = new System.Windows.Forms.Label();
//            this.dgv_Reportes = new System.Windows.Forms.DataGridView();
//            this.tbx_BusqReport = new System.Windows.Forms.TextBox();
//            this.cbx_TipoReport = new System.Windows.Forms.ComboBox();
//            this.panelFiltro = new System.Windows.Forms.Panel();
//            this.panel1.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.dgv_Reportes)).BeginInit();
//            this.panelFiltro.SuspendLayout();
//            this.SuspendLayout();
//            // 
//            // panel1
//            // 
//            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
//            | System.Windows.Forms.AnchorStyles.Left) 
//            | System.Windows.Forms.AnchorStyles.Right)));
//            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
//            this.panel1.Controls.Add(this.panelFiltro);
//            this.panel1.Controls.Add(this.label1);
//            this.panel1.Controls.Add(this.label2);
//            this.panel1.Controls.Add(this.ibtn_Buscar);
//            this.panel1.Controls.Add(this.label5);
//            this.panel1.Controls.Add(this.dgv_Reportes);
//            this.panel1.Controls.Add(this.tbx_BusqReport);
//            this.panel1.Controls.Add(this.cbx_TipoReport);
//            this.panel1.Location = new System.Drawing.Point(11, 11);
//            this.panel1.Margin = new System.Windows.Forms.Padding(2);
//            this.panel1.Name = "panel1";
//            this.panel1.Size = new System.Drawing.Size(844, 573);
//            this.panel1.TabIndex = 10;
//            // 
//            // label3
//            // 
//            this.label3.AutoSize = true;
//            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
//            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
//            this.label3.Location = new System.Drawing.Point(4, 9);
//            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
//            this.label3.Name = "label3";
//            this.label3.Size = new System.Drawing.Size(71, 14);
//            this.label3.TabIndex = 11;
//            this.label3.Text = "Filtrar por:";
//            // 
//            // cbx_FiltroReport
//            // 
//            this.cbx_FiltroReport.Font = new System.Drawing.Font("Tahoma", 11F);
//            this.cbx_FiltroReport.FormattingEnabled = true;
//            this.cbx_FiltroReport.Location = new System.Drawing.Point(7, 25);
//            this.cbx_FiltroReport.Margin = new System.Windows.Forms.Padding(2);
//            this.cbx_FiltroReport.Name = "cbx_FiltroReport";
//            this.cbx_FiltroReport.Size = new System.Drawing.Size(198, 26);
//            this.cbx_FiltroReport.TabIndex = 10;
//            // 
//            // label1
//            // 
//            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
//            this.label1.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
//            this.label1.Location = new System.Drawing.Point(0, 0);
//            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
//            this.label1.Name = "label1";
//            this.label1.Size = new System.Drawing.Size(844, 41);
//            this.label1.TabIndex = 9;
//            this.label1.Text = "  Reportes";
//            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
//            // 
//            // label2
//            // 
//            this.label2.AutoSize = true;
//            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
//            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
//            this.label2.Location = new System.Drawing.Point(13, 56);
//            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
//            this.label2.Name = "label2";
//            this.label2.Size = new System.Drawing.Size(37, 14);
//            this.label2.TabIndex = 8;
//            this.label2.Text = "Tipo:";
//            // 
//            // ibtn_Buscar
//            // 
//            this.ibtn_Buscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
//            this.ibtn_Buscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
//            this.ibtn_Buscar.Cursor = System.Windows.Forms.Cursors.Hand;
//            this.ibtn_Buscar.FlatAppearance.BorderSize = 0;
//            this.ibtn_Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.ibtn_Buscar.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
//            this.ibtn_Buscar.ForeColor = System.Drawing.Color.White;
//            this.ibtn_Buscar.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
//            this.ibtn_Buscar.IconColor = System.Drawing.Color.White;
//            this.ibtn_Buscar.IconFont = FontAwesome.Sharp.IconFont.Solid;
//            this.ibtn_Buscar.IconSize = 20;
//            this.ibtn_Buscar.Location = new System.Drawing.Point(728, 102);
//            this.ibtn_Buscar.Margin = new System.Windows.Forms.Padding(2);
//            this.ibtn_Buscar.Name = "ibtn_Buscar";
//            this.ibtn_Buscar.Size = new System.Drawing.Size(100, 36);
//            this.ibtn_Buscar.TabIndex = 6;
//            this.ibtn_Buscar.Text = "Buscar";
//            this.ibtn_Buscar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
//            this.ibtn_Buscar.UseVisualStyleBackColor = false;
//            // 
//            // label5
//            // 
//            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
//            | System.Windows.Forms.AnchorStyles.Right)));
//            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
//            this.label5.Location = new System.Drawing.Point(13, 542);
//            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
//            this.label5.Name = "label5";
//            this.label5.Size = new System.Drawing.Size(815, 20);
//            this.label5.TabIndex = 5;
//            this.label5.Text = "Si no se encuentra lo que necesita, lo más seguro es que no se encuentra registra" +
//    "do en el sistema";
//            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
//            // 
//            // dgv_Reportes
//            // 
//            this.dgv_Reportes.AllowUserToAddRows = false;
//            this.dgv_Reportes.AllowUserToDeleteRows = false;
//            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 10F);
//            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
//            this.dgv_Reportes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
//            this.dgv_Reportes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
//            | System.Windows.Forms.AnchorStyles.Left) 
//            | System.Windows.Forms.AnchorStyles.Right)));
//            this.dgv_Reportes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
//            this.dgv_Reportes.BackgroundColor = System.Drawing.Color.LightBlue;
//            this.dgv_Reportes.BorderStyle = System.Windows.Forms.BorderStyle.None;
//            this.dgv_Reportes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
//            this.dgv_Reportes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
//            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
//            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
//            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
//            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
//            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
//            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
//            this.dgv_Reportes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
//            this.dgv_Reportes.ColumnHeadersHeight = 30;
//            this.dgv_Reportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
//            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
//            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
//            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
//            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(203)))), ((int)(((byte)(91)))));
//            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
//            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
//            this.dgv_Reportes.DefaultCellStyle = dataGridViewCellStyle3;
//            this.dgv_Reportes.EnableHeadersVisualStyles = false;
//            this.dgv_Reportes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
//            this.dgv_Reportes.Location = new System.Drawing.Point(16, 150);
//            this.dgv_Reportes.Margin = new System.Windows.Forms.Padding(2);
//            this.dgv_Reportes.Name = "dgv_Reportes";
//            this.dgv_Reportes.ReadOnly = true;
//            this.dgv_Reportes.RowHeadersVisible = false;
//            this.dgv_Reportes.RowHeadersWidth = 51;
//            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
//            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
//            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(203)))), ((int)(((byte)(91)))));
//            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
//            this.dgv_Reportes.RowsDefaultCellStyle = dataGridViewCellStyle4;
//            this.dgv_Reportes.RowTemplate.Height = 24;
//            this.dgv_Reportes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
//            this.dgv_Reportes.Size = new System.Drawing.Size(812, 382);
//            this.dgv_Reportes.TabIndex = 2;
//            // 
//            // tbx_BusqReport
//            // 
//            this.tbx_BusqReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
//            | System.Windows.Forms.AnchorStyles.Right)));
//            this.tbx_BusqReport.Font = new System.Drawing.Font("Tahoma", 12F);
//            this.tbx_BusqReport.Location = new System.Drawing.Point(16, 111);
//            this.tbx_BusqReport.Margin = new System.Windows.Forms.Padding(2);
//            this.tbx_BusqReport.Name = "tbx_BusqReport";
//            this.tbx_BusqReport.Size = new System.Drawing.Size(708, 27);
//            this.tbx_BusqReport.TabIndex = 1;
//            // 
//            // cbx_TipoReport
//            // 
//            this.cbx_TipoReport.Font = new System.Drawing.Font("Tahoma", 11F);
//            this.cbx_TipoReport.FormattingEnabled = true;
//            this.cbx_TipoReport.Location = new System.Drawing.Point(16, 72);
//            this.cbx_TipoReport.Margin = new System.Windows.Forms.Padding(2);
//            this.cbx_TipoReport.Name = "cbx_TipoReport";
//            this.cbx_TipoReport.Size = new System.Drawing.Size(241, 26);
//            this.cbx_TipoReport.TabIndex = 0;
//            // 
//            // panelFiltro
//            // 
//            this.panelFiltro.Controls.Add(this.label3);
//            this.panelFiltro.Controls.Add(this.cbx_FiltroReport);
//            this.panelFiltro.Location = new System.Drawing.Point(289, 44);
//            this.panelFiltro.Name = "panelFiltro";
//            this.panelFiltro.Size = new System.Drawing.Size(213, 62);
//            this.panelFiltro.TabIndex = 0;
//            // 
//            // Frm_Reports
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
//            this.ClientSize = new System.Drawing.Size(866, 595);
//            this.Controls.Add(this.panel1);
//            this.Name = "Frm_Reports";
//            this.Text = "Frm_Reports";
//            this.panel1.ResumeLayout(false);
//            this.panel1.PerformLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.dgv_Reportes)).EndInit();
//            this.panelFiltro.ResumeLayout(false);
//            this.panelFiltro.PerformLayout();
//            this.ResumeLayout(false);

//        }

//        #endregion

//        private System.Windows.Forms.Panel panel1;
//        private System.Windows.Forms.Label label2;
//        private FontAwesome.Sharp.IconButton ibtn_Buscar;
//        private System.Windows.Forms.Label label5;
//        private System.Windows.Forms.DataGridView dgv_Reportes;
//        private System.Windows.Forms.TextBox tbx_BusqReport;
//        private System.Windows.Forms.ComboBox cbx_TipoReport;
//        private System.Windows.Forms.Label label1;
//        private System.Windows.Forms.Label label3;
//        private System.Windows.Forms.ComboBox cbx_FiltroReport;
//        private System.Windows.Forms.Panel panelFiltro;
//    }
//}