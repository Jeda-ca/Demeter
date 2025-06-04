namespace GUI
{
    partial class Frm_GSalesAdmin
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
            this.ibtn_Clear = new FontAwesome.Sharp.IconButton();
            this.ibtn_Buscar = new FontAwesome.Sharp.IconButton();
            this.tbx_Busqueda = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panelFiltro = new System.Windows.Forms.Panel();
            this.dtp_FFin = new System.Windows.Forms.DateTimePicker();
            this.dtp_FInicio = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cbx_FiltroV = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgv_ListaVentas = new System.Windows.Forms.DataGridView();
            this.cbx_TipoV = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ibtn_AdminAddSale = new FontAwesome.Sharp.IconButton();
            this.ibtn_CancelVenta = new FontAwesome.Sharp.IconButton();
            this.ibtn_StatusVenta = new FontAwesome.Sharp.IconButton();
            this.panel1.SuspendLayout();
            this.panelFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListaVentas)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.panel1.Controls.Add(this.ibtn_Clear);
            this.panel1.Controls.Add(this.ibtn_Buscar);
            this.panel1.Controls.Add(this.tbx_Busqueda);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.panelFiltro);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dgv_ListaVentas);
            this.panel1.Controls.Add(this.cbx_TipoV);
            this.panel1.Location = new System.Drawing.Point(43, 68);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1064, 338);
            this.panel1.TabIndex = 11;
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
            this.ibtn_Clear.Location = new System.Drawing.Point(1004, 128);
            this.ibtn_Clear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ibtn_Clear.Name = "ibtn_Clear";
            this.ibtn_Clear.Size = new System.Drawing.Size(39, 32);
            this.ibtn_Clear.TabIndex = 15;
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
            this.ibtn_Buscar.Location = new System.Drawing.Point(862, 128);
            this.ibtn_Buscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ibtn_Buscar.Name = "ibtn_Buscar";
            this.ibtn_Buscar.Size = new System.Drawing.Size(133, 33);
            this.ibtn_Buscar.TabIndex = 14;
            this.ibtn_Buscar.Text = "Buscar";
            this.ibtn_Buscar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.ibtn_Buscar.UseVisualStyleBackColor = false;
            this.ibtn_Buscar.Click += new System.EventHandler(this.ibtn_Buscar_Click);
            // 
            // tbx_Busqueda
            // 
            this.tbx_Busqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_Busqueda.Font = new System.Drawing.Font("Tahoma", 12F);
            this.tbx_Busqueda.Location = new System.Drawing.Point(21, 128);
            this.tbx_Busqueda.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbx_Busqueda.Name = "tbx_Busqueda";
            this.tbx_Busqueda.Size = new System.Drawing.Size(843, 32);
            this.tbx_Busqueda.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label10.Location = new System.Drawing.Point(8, -1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(169, 24);
            this.label10.TabIndex = 9;
            this.label10.Text = "Consultar venta";
            // 
            // panelFiltro
            // 
            this.panelFiltro.Controls.Add(this.dtp_FFin);
            this.panelFiltro.Controls.Add(this.dtp_FInicio);
            this.panelFiltro.Controls.Add(this.label3);
            this.panelFiltro.Controls.Add(this.cbx_FiltroV);
            this.panelFiltro.Location = new System.Drawing.Point(379, 26);
            this.panelFiltro.Margin = new System.Windows.Forms.Padding(4);
            this.panelFiltro.Name = "panelFiltro";
            this.panelFiltro.Size = new System.Drawing.Size(685, 76);
            this.panelFiltro.TabIndex = 0;
            this.panelFiltro.Visible = false;
            // 
            // dtp_FFin
            // 
            this.dtp_FFin.CustomFormat = "MMM dd, yyyy";
            this.dtp_FFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_FFin.Location = new System.Drawing.Point(508, 31);
            this.dtp_FFin.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_FFin.Name = "dtp_FFin";
            this.dtp_FFin.Size = new System.Drawing.Size(168, 22);
            this.dtp_FFin.TabIndex = 2;
            this.dtp_FFin.Visible = false;
            // 
            // dtp_FInicio
            // 
            this.dtp_FInicio.CustomFormat = "MMM dd, yyyy";
            this.dtp_FInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_FInicio.Location = new System.Drawing.Point(305, 31);
            this.dtp_FInicio.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_FInicio.Name = "dtp_FInicio";
            this.dtp_FInicio.Size = new System.Drawing.Size(168, 22);
            this.dtp_FInicio.TabIndex = 2;
            this.dtp_FInicio.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label3.Location = new System.Drawing.Point(5, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 18);
            this.label3.TabIndex = 11;
            this.label3.Text = "Filtrar por:";
            // 
            // cbx_FiltroV
            // 
            this.cbx_FiltroV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_FiltroV.Font = new System.Drawing.Font("Tahoma", 11F);
            this.cbx_FiltroV.FormattingEnabled = true;
            this.cbx_FiltroV.Location = new System.Drawing.Point(9, 31);
            this.cbx_FiltroV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbx_FiltroV.Name = "cbx_FiltroV";
            this.cbx_FiltroV.Size = new System.Drawing.Size(263, 30);
            this.cbx_FiltroV.TabIndex = 1;
            this.cbx_FiltroV.SelectedIndexChanged += new System.EventHandler(this.cbx_FiltroReport_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label2.Location = new System.Drawing.Point(17, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Buscar por:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label5.Location = new System.Drawing.Point(17, 300);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1026, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "Si no se encuentra lo que necesita, lo más seguro es que no se encuentra registra" +
    "do en el sistema";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgv_ListaVentas
            // 
            this.dgv_ListaVentas.AllowUserToAddRows = false;
            this.dgv_ListaVentas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgv_ListaVentas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ListaVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_ListaVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ListaVentas.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgv_ListaVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_ListaVentas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_ListaVentas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ListaVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_ListaVentas.ColumnHeadersHeight = 30;
            this.dgv_ListaVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(203)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ListaVentas.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_ListaVentas.EnableHeadersVisualStyles = false;
            this.dgv_ListaVentas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.dgv_ListaVentas.Location = new System.Drawing.Point(21, 185);
            this.dgv_ListaVentas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_ListaVentas.Name = "dgv_ListaVentas";
            this.dgv_ListaVentas.ReadOnly = true;
            this.dgv_ListaVentas.RowHeadersVisible = false;
            this.dgv_ListaVentas.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(203)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.dgv_ListaVentas.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_ListaVentas.RowTemplate.Height = 24;
            this.dgv_ListaVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ListaVentas.Size = new System.Drawing.Size(1022, 103);
            this.dgv_ListaVentas.TabIndex = 6;
            // 
            // cbx_TipoV
            // 
            this.cbx_TipoV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_TipoV.Font = new System.Drawing.Font("Tahoma", 11F);
            this.cbx_TipoV.FormattingEnabled = true;
            this.cbx_TipoV.Location = new System.Drawing.Point(21, 61);
            this.cbx_TipoV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbx_TipoV.Name = "cbx_TipoV";
            this.cbx_TipoV.Size = new System.Drawing.Size(320, 30);
            this.cbx_TipoV.TabIndex = 0;
            this.cbx_TipoV.SelectedIndexChanged += new System.EventHandler(this.cbx_TipoReport_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1155, 50);
            this.label1.TabIndex = 13;
            this.label1.Text = "  Gestor de Ventas";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1064, 37);
            this.label4.TabIndex = 0;
            this.label4.Text = "Controles de gestión";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.panel2.Controls.Add(this.ibtn_AdminAddSale);
            this.panel2.Controls.Add(this.ibtn_CancelVenta);
            this.panel2.Controls.Add(this.ibtn_StatusVenta);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(43, 425);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1064, 202);
            this.panel2.TabIndex = 12;
            // 
            // ibtn_AdminAddSale
            // 
            this.ibtn_AdminAddSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_AdminAddSale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtn_AdminAddSale.FlatAppearance.BorderSize = 0;
            this.ibtn_AdminAddSale.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.ibtn_AdminAddSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_AdminAddSale.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.ibtn_AdminAddSale.ForeColor = System.Drawing.Color.White;
            this.ibtn_AdminAddSale.IconChar = FontAwesome.Sharp.IconChar.SquareCheck;
            this.ibtn_AdminAddSale.IconColor = System.Drawing.Color.White;
            this.ibtn_AdminAddSale.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.ibtn_AdminAddSale.IconSize = 33;
            this.ibtn_AdminAddSale.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ibtn_AdminAddSale.Location = new System.Drawing.Point(21, 54);
            this.ibtn_AdminAddSale.Name = "ibtn_AdminAddSale";
            this.ibtn_AdminAddSale.Size = new System.Drawing.Size(228, 95);
            this.ibtn_AdminAddSale.TabIndex = 10;
            this.ibtn_AdminAddSale.Text = "Registrar nueva venta";
            this.ibtn_AdminAddSale.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtn_AdminAddSale.UseVisualStyleBackColor = false;
            this.ibtn_AdminAddSale.Click += new System.EventHandler(this.ibtn_AdminAddSale_Click);
            // 
            // ibtn_CancelVenta
            // 
            this.ibtn_CancelVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_CancelVenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtn_CancelVenta.FlatAppearance.BorderSize = 0;
            this.ibtn_CancelVenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.ibtn_CancelVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_CancelVenta.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.ibtn_CancelVenta.ForeColor = System.Drawing.Color.White;
            this.ibtn_CancelVenta.IconChar = FontAwesome.Sharp.IconChar.Ban;
            this.ibtn_CancelVenta.IconColor = System.Drawing.Color.White;
            this.ibtn_CancelVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_CancelVenta.IconSize = 33;
            this.ibtn_CancelVenta.Location = new System.Drawing.Point(726, 54);
            this.ibtn_CancelVenta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ibtn_CancelVenta.Name = "ibtn_CancelVenta";
            this.ibtn_CancelVenta.Size = new System.Drawing.Size(228, 95);
            this.ibtn_CancelVenta.TabIndex = 8;
            this.ibtn_CancelVenta.Text = "  Cancelar venta";
            this.ibtn_CancelVenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtn_CancelVenta.UseVisualStyleBackColor = false;
            this.ibtn_CancelVenta.Click += new System.EventHandler(this.ibtn_CancelVenta_Click);
            // 
            // ibtn_StatusVenta
            // 
            this.ibtn_StatusVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_StatusVenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtn_StatusVenta.FlatAppearance.BorderSize = 0;
            this.ibtn_StatusVenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.ibtn_StatusVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_StatusVenta.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.ibtn_StatusVenta.ForeColor = System.Drawing.Color.White;
            this.ibtn_StatusVenta.IconChar = FontAwesome.Sharp.IconChar.ArrowRotateBackward;
            this.ibtn_StatusVenta.IconColor = System.Drawing.Color.White;
            this.ibtn_StatusVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_StatusVenta.IconSize = 33;
            this.ibtn_StatusVenta.Location = new System.Drawing.Point(373, 54);
            this.ibtn_StatusVenta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ibtn_StatusVenta.Name = "ibtn_StatusVenta";
            this.ibtn_StatusVenta.Size = new System.Drawing.Size(228, 95);
            this.ibtn_StatusVenta.TabIndex = 7;
            this.ibtn_StatusVenta.Text = "  Modificar estado de venta";
            this.ibtn_StatusVenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtn_StatusVenta.UseVisualStyleBackColor = false;
            this.ibtn_StatusVenta.Click += new System.EventHandler(this.ibtn_StatusVenta_Click);
            // 
            // Frm_GSalesAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(1155, 648);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_GSalesAdmin";
            this.Text = "Frm_GSalesAdmin";
            this.Load += new System.EventHandler(this.Frm_GSalesAdmin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelFiltro.ResumeLayout(false);
            this.panelFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListaVentas)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelFiltro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbx_FiltroV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv_ListaVentas;
        private System.Windows.Forms.ComboBox cbx_TipoV;
        private System.Windows.Forms.DateTimePicker dtp_FFin;
        private System.Windows.Forms.DateTimePicker dtp_FInicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private FontAwesome.Sharp.IconButton ibtn_StatusVenta;
        private FontAwesome.Sharp.IconButton ibtn_CancelVenta;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton ibtn_Clear;
        private FontAwesome.Sharp.IconButton ibtn_Buscar;
        private System.Windows.Forms.TextBox tbx_Busqueda;
        private FontAwesome.Sharp.IconButton ibtn_AdminAddSale;
    }
}


//namespace GUI
//{
//    partial class Frm_GVentsAdmin
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
//            this.panelFiltro = new System.Windows.Forms.Panel();
//            this.label3 = new System.Windows.Forms.Label();
//            this.cbx_FiltroReport = new System.Windows.Forms.ComboBox();
//            this.label1 = new System.Windows.Forms.Label();
//            this.label2 = new System.Windows.Forms.Label();
//            this.label5 = new System.Windows.Forms.Label();
//            this.dgv_Reportes = new System.Windows.Forms.DataGridView();
//            this.tbx_BusqReport = new System.Windows.Forms.TextBox();
//            this.cbx_TipoReport = new System.Windows.Forms.ComboBox();
//            this.ibtn_Buscar = new FontAwesome.Sharp.IconButton();
//            this.dtp_FInicio = new System.Windows.Forms.DateTimePicker();
//            this.dtp_FFin = new System.Windows.Forms.DateTimePicker();
//            this.panel1.SuspendLayout();
//            this.panelFiltro.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.dgv_Reportes)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // panel1
//            // 
//            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
//            | System.Windows.Forms.AnchorStyles.Left) 
//            | System.Windows.Forms.AnchorStyles.Right)));
//            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
//            this.panel1.Controls.Add(this.ibtn_Buscar);
//            this.panel1.Controls.Add(this.panelFiltro);
//            this.panel1.Controls.Add(this.label1);
//            this.panel1.Controls.Add(this.label2);
//            this.panel1.Controls.Add(this.label5);
//            this.panel1.Controls.Add(this.dgv_Reportes);
//            this.panel1.Controls.Add(this.tbx_BusqReport);
//            this.panel1.Controls.Add(this.cbx_TipoReport);
//            this.panel1.Location = new System.Drawing.Point(11, 11);
//            this.panel1.Margin = new System.Windows.Forms.Padding(2);
//            this.panel1.Name = "panel1";
//            this.panel1.Size = new System.Drawing.Size(844, 573);
//            this.panel1.TabIndex = 11;
//            // 
//            // panelFiltro
//            // 
//            this.panelFiltro.Controls.Add(this.dtp_FFin);
//            this.panelFiltro.Controls.Add(this.dtp_FInicio);
//            this.panelFiltro.Controls.Add(this.label3);
//            this.panelFiltro.Controls.Add(this.cbx_FiltroReport);
//            this.panelFiltro.Location = new System.Drawing.Point(289, 41);
//            this.panelFiltro.Name = "panelFiltro";
//            this.panelFiltro.Size = new System.Drawing.Size(539, 62);
//            this.panelFiltro.TabIndex = 0;
//            this.panelFiltro.Visible = false;
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
//            this.label1.Text = "  Gestor de Ventas";
//            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
//            // 
//            // label2
//            // 
//            this.label2.AutoSize = true;
//            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
//            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
//            this.label2.Location = new System.Drawing.Point(13, 53);
//            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
//            this.label2.Name = "label2";
//            this.label2.Size = new System.Drawing.Size(37, 14);
//            this.label2.TabIndex = 8;
//            this.label2.Text = "Tipo:";
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
//            this.cbx_TipoReport.Location = new System.Drawing.Point(16, 69);
//            this.cbx_TipoReport.Margin = new System.Windows.Forms.Padding(2);
//            this.cbx_TipoReport.Name = "cbx_TipoReport";
//            this.cbx_TipoReport.Size = new System.Drawing.Size(241, 26);
//            this.cbx_TipoReport.TabIndex = 0;
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
//            // dtp_FInicio
//            // 
//            this.dtp_FInicio.CustomFormat = "MMM dd, yyyy";
//            this.dtp_FInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
//            this.dtp_FInicio.Location = new System.Drawing.Point(229, 25);
//            this.dtp_FInicio.Name = "dtp_FInicio";
//            this.dtp_FInicio.Size = new System.Drawing.Size(127, 20);
//            this.dtp_FInicio.TabIndex = 12;
//            // 
//            // dtp_FFin
//            // 
//            this.dtp_FFin.CustomFormat = "MMM dd, yyyy";
//            this.dtp_FFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
//            this.dtp_FFin.Location = new System.Drawing.Point(381, 25);
//            this.dtp_FFin.Name = "dtp_FFin";
//            this.dtp_FFin.Size = new System.Drawing.Size(127, 20);
//            this.dtp_FFin.TabIndex = 13;
//            // 
//            // Frm_GVentsAdmin
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
//            this.ClientSize = new System.Drawing.Size(866, 595);
//            this.Controls.Add(this.panel1);
//            this.Name = "Frm_GVentsAdmin";
//            this.Text = "Frm_GVentsAdmin";
//            this.panel1.ResumeLayout(false);
//            this.panel1.PerformLayout();
//            this.panelFiltro.ResumeLayout(false);
//            this.panelFiltro.PerformLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.dgv_Reportes)).EndInit();
//            this.ResumeLayout(false);

//        }

//        #endregion

//        private System.Windows.Forms.Panel panel1;
//        private System.Windows.Forms.Panel panelFiltro;
//        private System.Windows.Forms.Label label3;
//        private System.Windows.Forms.ComboBox cbx_FiltroReport;
//        private System.Windows.Forms.Label label1;
//        private System.Windows.Forms.Label label2;
//        private FontAwesome.Sharp.IconButton ibtn_Buscar;
//        private System.Windows.Forms.Label label5;
//        private System.Windows.Forms.DataGridView dgv_Reportes;
//        private System.Windows.Forms.TextBox tbx_BusqReport;
//        private System.Windows.Forms.ComboBox cbx_TipoReport;
//        private System.Windows.Forms.DateTimePicker dtp_FFin;
//        private System.Windows.Forms.DateTimePicker dtp_FInicio;
//    }
//}