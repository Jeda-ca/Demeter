﻿namespace GUI
{
    partial class Frm_DashboardAdmin
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblVentas = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.iconPictureBox5 = new FontAwesome.Sharp.IconPictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblGanancias = new System.Windows.Forms.Label();
            this.iconPictureBox6 = new FontAwesome.Sharp.IconPictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chart_IngresoPorFecha = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart_Top10Products = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel4 = new System.Windows.Forms.Panel();
            this.iconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.lblProductos = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblVendedores = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblClientes = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgv_PBajoStock = new System.Windows.Forms.DataGridView();
            this.label21 = new System.Windows.Forms.Label();
            this.ibtn_OKCustomDate = new FontAwesome.Sharp.IconButton();
            this.ibtn_CustomDate = new FontAwesome.Sharp.IconButton();
            this.ibtn_Today = new FontAwesome.Sharp.IconButton();
            this.ibtn_7Days = new FontAwesome.Sharp.IconButton();
            this.ibtn_30Days = new FontAwesome.Sharp.IconButton();
            this.ibtn_ThisMonth = new FontAwesome.Sharp.IconButton();
            this.iconPictureBox4 = new FontAwesome.Sharp.IconPictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox5)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_IngresoPorFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Top10Products)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PBajoStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dashboard";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpStartDate.CustomFormat = "MMM dd, yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(268, 42);
            this.dtpStartDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(135, 22);
            this.dtpStartDate.TabIndex = 1;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpEndDate.CustomFormat = "MMM dd, yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(421, 42);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(135, 22);
            this.dtpEndDate.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.panel1.Controls.Add(this.lblVentas);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.iconPictureBox5);
            this.panel1.Location = new System.Drawing.Point(12, 91);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1012, 75);
            this.panel1.TabIndex = 9;
            // 
            // lblVentas
            // 
            this.lblVentas.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVentas.ForeColor = System.Drawing.Color.White;
            this.lblVentas.Location = new System.Drawing.Point(91, 27);
            this.lblVentas.Name = "lblVentas";
            this.lblVentas.Size = new System.Drawing.Size(160, 33);
            this.lblVentas.TabIndex = 1;
            this.lblVentas.Text = "0000";
            this.lblVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(80, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ventas";
            // 
            // iconPictureBox5
            // 
            this.iconPictureBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            this.iconPictureBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(133)))), ((int)(((byte)(201)))));
            this.iconPictureBox5.IconChar = FontAwesome.Sharp.IconChar.CashRegister;
            this.iconPictureBox5.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(133)))), ((int)(((byte)(201)))));
            this.iconPictureBox5.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox5.IconSize = 75;
            this.iconPictureBox5.Location = new System.Drawing.Point(0, 0);
            this.iconPictureBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.iconPictureBox5.Name = "iconPictureBox5";
            this.iconPictureBox5.Size = new System.Drawing.Size(75, 75);
            this.iconPictureBox5.TabIndex = 14;
            this.iconPictureBox5.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.panel3.Controls.Add(this.lblGanancias);
            this.panel3.Controls.Add(this.iconPictureBox6);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(125, 91);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1012, 75);
            this.panel3.TabIndex = 10;
            // 
            // lblGanancias
            // 
            this.lblGanancias.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGanancias.ForeColor = System.Drawing.Color.White;
            this.lblGanancias.Location = new System.Drawing.Point(93, 27);
            this.lblGanancias.Name = "lblGanancias";
            this.lblGanancias.Size = new System.Drawing.Size(411, 33);
            this.lblGanancias.TabIndex = 1;
            this.lblGanancias.Text = "0000";
            this.lblGanancias.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // iconPictureBox6
            // 
            this.iconPictureBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            this.iconPictureBox6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.iconPictureBox6.IconChar = FontAwesome.Sharp.IconChar.MoneyBillTrendUp;
            this.iconPictureBox6.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.iconPictureBox6.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox6.IconSize = 75;
            this.iconPictureBox6.Location = new System.Drawing.Point(-3, 0);
            this.iconPictureBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.iconPictureBox6.Name = "iconPictureBox6";
            this.iconPictureBox6.Size = new System.Drawing.Size(75, 75);
            this.iconPictureBox6.TabIndex = 17;
            this.iconPictureBox6.TabStop = false;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(77, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 32);
            this.label7.TabIndex = 0;
            this.label7.Text = "Ganancias";
            // 
            // chart_IngresoPorFecha
            // 
            this.chart_IngresoPorFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart_IngresoPorFecha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.chart_IngresoPorFecha.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            this.chart_IngresoPorFecha.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.chart_IngresoPorFecha.ChartAreas.Add(chartArea1);
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Name = "Legend1";
            this.chart_IngresoPorFecha.Legends.Add(legend1);
            this.chart_IngresoPorFecha.Location = new System.Drawing.Point(12, 172);
            this.chart_IngresoPorFecha.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart_IngresoPorFecha.Name = "chart_IngresoPorFecha";
            this.chart_IngresoPorFecha.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart_IngresoPorFecha.Series.Add(series1);
            this.chart_IngresoPorFecha.Size = new System.Drawing.Size(681, 338);
            this.chart_IngresoPorFecha.TabIndex = 11;
            this.chart_IngresoPorFecha.Text = "chart1";
            title1.Alignment = System.Drawing.ContentAlignment.TopLeft;
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            title1.Name = "Title1";
            title1.Text = "Ingreso bruto x Fecha";
            this.chart_IngresoPorFecha.Titles.Add(title1);
            // 
            // chart_Top10Products
            // 
            this.chart_Top10Products.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart_Top10Products.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.chart_Top10Products.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            this.chart_Top10Products.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.Name = "ChartArea1";
            this.chart_Top10Products.ChartAreas.Add(chartArea2);
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend2.Name = "Legend1";
            this.chart_Top10Products.Legends.Add(legend2);
            this.chart_Top10Products.Location = new System.Drawing.Point(699, 172);
            this.chart_Top10Products.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart_Top10Products.Name = "chart_Top10Products";
            this.chart_Top10Products.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            series2.IsValueShownAsLabel = true;
            series2.LabelForeColor = System.Drawing.Color.White;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart_Top10Products.Series.Add(series2);
            this.chart_Top10Products.Size = new System.Drawing.Size(469, 594);
            this.chart_Top10Products.TabIndex = 12;
            this.chart_Top10Products.Text = "chart2";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            title2.Name = "Title1";
            title2.Text = "Top 10 productos más vendidos";
            this.chart_Top10Products.Titles.Add(title2);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.panel4.Controls.Add(this.iconPictureBox3);
            this.panel4.Controls.Add(this.iconPictureBox2);
            this.panel4.Controls.Add(this.iconPictureBox1);
            this.panel4.Controls.Add(this.lblProductos);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.lblVendedores);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.lblClientes);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Location = new System.Drawing.Point(12, 517);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(218, 249);
            this.panel4.TabIndex = 10;
            // 
            // iconPictureBox3
            // 
            this.iconPictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.BoxesStacked;
            this.iconPictureBox3.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.iconPictureBox3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox3.IconSize = 60;
            this.iconPictureBox3.Location = new System.Drawing.Point(15, 170);
            this.iconPictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.iconPictureBox3.Name = "iconPictureBox3";
            this.iconPictureBox3.Size = new System.Drawing.Size(60, 60);
            this.iconPictureBox3.TabIndex = 9;
            this.iconPictureBox3.TabStop = false;
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(203)))), ((int)(((byte)(91)))));
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Tractor;
            this.iconPictureBox2.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(203)))), ((int)(((byte)(91)))));
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 60;
            this.iconPictureBox2.Location = new System.Drawing.Point(15, 101);
            this.iconPictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(60, 60);
            this.iconPictureBox2.TabIndex = 8;
            this.iconPictureBox2.TabStop = false;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.PeopleGroup;
            this.iconPictureBox1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 60;
            this.iconPictureBox1.Location = new System.Drawing.Point(15, 32);
            this.iconPictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(60, 60);
            this.iconPictureBox1.TabIndex = 7;
            this.iconPictureBox1.TabStop = false;
            // 
            // lblProductos
            // 
            this.lblProductos.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            this.lblProductos.Location = new System.Drawing.Point(77, 197);
            this.lblProductos.Name = "lblProductos";
            this.lblProductos.Size = new System.Drawing.Size(93, 33);
            this.lblProductos.TabIndex = 6;
            this.lblProductos.Text = "78";
            this.lblProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label16.Location = new System.Drawing.Point(77, 164);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(123, 33);
            this.label16.TabIndex = 5;
            this.label16.Text = "Productos";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVendedores
            // 
            this.lblVendedores.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendedores.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            this.lblVendedores.Location = new System.Drawing.Point(77, 128);
            this.lblVendedores.Name = "lblVendedores";
            this.lblVendedores.Size = new System.Drawing.Size(93, 33);
            this.lblVendedores.TabIndex = 4;
            this.lblVendedores.Text = "18";
            this.lblVendedores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label14.Location = new System.Drawing.Point(77, 95);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(123, 33);
            this.label14.TabIndex = 3;
            this.label14.Text = "Vendedores";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblClientes
            // 
            this.lblClientes.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            this.lblClientes.Location = new System.Drawing.Point(77, 59);
            this.lblClientes.Name = "lblClientes";
            this.lblClientes.Size = new System.Drawing.Size(93, 33);
            this.lblClientes.TabIndex = 2;
            this.lblClientes.Text = "20";
            this.lblClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label8.Location = new System.Drawing.Point(77, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 33);
            this.label8.TabIndex = 1;
            this.label8.Text = "Clientes";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(218, 30);
            this.label9.TabIndex = 0;
            this.label9.Text = "Contadores";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.panel5.Controls.Add(this.dgv_PBajoStock);
            this.panel5.Controls.Add(this.label21);
            this.panel5.Location = new System.Drawing.Point(236, 517);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(457, 233);
            this.panel5.TabIndex = 11;
            // 
            // dgv_PBajoStock
            // 
            this.dgv_PBajoStock.AllowUserToAddRows = false;
            this.dgv_PBajoStock.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dgv_PBajoStock.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_PBajoStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_PBajoStock.BackgroundColor = System.Drawing.Color.CadetBlue;
            this.dgv_PBajoStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_PBajoStock.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_PBajoStock.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_PBajoStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_PBajoStock.ColumnHeadersHeight = 30;
            this.dgv_PBajoStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(203)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_PBajoStock.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_PBajoStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_PBajoStock.EnableHeadersVisualStyles = false;
            this.dgv_PBajoStock.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.dgv_PBajoStock.Location = new System.Drawing.Point(0, 30);
            this.dgv_PBajoStock.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_PBajoStock.Name = "dgv_PBajoStock";
            this.dgv_PBajoStock.ReadOnly = true;
            this.dgv_PBajoStock.RowHeadersVisible = false;
            this.dgv_PBajoStock.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(203)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.dgv_PBajoStock.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_PBajoStock.RowTemplate.Height = 24;
            this.dgv_PBajoStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_PBajoStock.Size = new System.Drawing.Size(457, 203);
            this.dgv_PBajoStock.TabIndex = 1;
            // 
            // label21
            // 
            this.label21.Dock = System.Windows.Forms.DockStyle.Top;
            this.label21.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label21.Location = new System.Drawing.Point(0, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(457, 30);
            this.label21.TabIndex = 0;
            this.label21.Text = "Productos con bajo Stock";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ibtn_OKCustomDate
            // 
            this.ibtn_OKCustomDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ibtn_OKCustomDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ibtn_OKCustomDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtn_OKCustomDate.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.ibtn_OKCustomDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_OKCustomDate.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.ibtn_OKCustomDate.IconColor = System.Drawing.Color.White;
            this.ibtn_OKCustomDate.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_OKCustomDate.IconSize = 30;
            this.ibtn_OKCustomDate.Location = new System.Drawing.Point(563, 11);
            this.ibtn_OKCustomDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ibtn_OKCustomDate.Name = "ibtn_OKCustomDate";
            this.ibtn_OKCustomDate.Size = new System.Drawing.Size(48, 60);
            this.ibtn_OKCustomDate.TabIndex = 8;
            this.ibtn_OKCustomDate.UseVisualStyleBackColor = false;
            this.ibtn_OKCustomDate.Click += new System.EventHandler(this.ibtn_OKCustomDate_Click);
            // 
            // ibtn_CustomDate
            // 
            this.ibtn_CustomDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ibtn_CustomDate.BackColor = System.Drawing.Color.Teal;
            this.ibtn_CustomDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtn_CustomDate.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.ibtn_CustomDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_CustomDate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ibtn_CustomDate.ForeColor = System.Drawing.Color.White;
            this.ibtn_CustomDate.IconChar = FontAwesome.Sharp.IconChar.None;
            this.ibtn_CustomDate.IconColor = System.Drawing.Color.Black;
            this.ibtn_CustomDate.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_CustomDate.Location = new System.Drawing.Point(612, 11);
            this.ibtn_CustomDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ibtn_CustomDate.Name = "ibtn_CustomDate";
            this.ibtn_CustomDate.Size = new System.Drawing.Size(149, 60);
            this.ibtn_CustomDate.TabIndex = 7;
            this.ibtn_CustomDate.Text = "Fecha personalizada";
            this.ibtn_CustomDate.UseVisualStyleBackColor = false;
            this.ibtn_CustomDate.Click += new System.EventHandler(this.ibtn_CustomDate_Click);
            // 
            // ibtn_Today
            // 
            this.ibtn_Today.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ibtn_Today.BackColor = System.Drawing.Color.Teal;
            this.ibtn_Today.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtn_Today.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.ibtn_Today.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_Today.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ibtn_Today.ForeColor = System.Drawing.Color.White;
            this.ibtn_Today.IconChar = FontAwesome.Sharp.IconChar.None;
            this.ibtn_Today.IconColor = System.Drawing.Color.Black;
            this.ibtn_Today.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_Today.Location = new System.Drawing.Point(763, 11);
            this.ibtn_Today.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ibtn_Today.Name = "ibtn_Today";
            this.ibtn_Today.Size = new System.Drawing.Size(83, 60);
            this.ibtn_Today.TabIndex = 6;
            this.ibtn_Today.Text = "Hoy";
            this.ibtn_Today.UseVisualStyleBackColor = false;
            this.ibtn_Today.Click += new System.EventHandler(this.ibtn_Today_Click);
            // 
            // ibtn_7Days
            // 
            this.ibtn_7Days.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ibtn_7Days.BackColor = System.Drawing.Color.Teal;
            this.ibtn_7Days.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtn_7Days.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.ibtn_7Days.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_7Days.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ibtn_7Days.ForeColor = System.Drawing.Color.White;
            this.ibtn_7Days.IconChar = FontAwesome.Sharp.IconChar.None;
            this.ibtn_7Days.IconColor = System.Drawing.Color.Black;
            this.ibtn_7Days.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_7Days.Location = new System.Drawing.Point(845, 11);
            this.ibtn_7Days.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ibtn_7Days.Name = "ibtn_7Days";
            this.ibtn_7Days.Size = new System.Drawing.Size(99, 60);
            this.ibtn_7Days.TabIndex = 5;
            this.ibtn_7Days.Text = "Últ. 7 días";
            this.ibtn_7Days.UseVisualStyleBackColor = false;
            this.ibtn_7Days.Click += new System.EventHandler(this.ibtn_7Days_Click);
            // 
            // ibtn_30Days
            // 
            this.ibtn_30Days.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ibtn_30Days.BackColor = System.Drawing.Color.Teal;
            this.ibtn_30Days.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtn_30Days.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.ibtn_30Days.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_30Days.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ibtn_30Days.ForeColor = System.Drawing.Color.White;
            this.ibtn_30Days.IconChar = FontAwesome.Sharp.IconChar.None;
            this.ibtn_30Days.IconColor = System.Drawing.Color.Black;
            this.ibtn_30Days.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_30Days.Location = new System.Drawing.Point(943, 11);
            this.ibtn_30Days.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ibtn_30Days.Name = "ibtn_30Days";
            this.ibtn_30Days.Size = new System.Drawing.Size(100, 60);
            this.ibtn_30Days.TabIndex = 4;
            this.ibtn_30Days.Text = "Últ. 30 días";
            this.ibtn_30Days.UseVisualStyleBackColor = false;
            this.ibtn_30Days.Click += new System.EventHandler(this.ibtn_30Days_Click);
            // 
            // ibtn_ThisMonth
            // 
            this.ibtn_ThisMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ibtn_ThisMonth.BackColor = System.Drawing.Color.Teal;
            this.ibtn_ThisMonth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtn_ThisMonth.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.ibtn_ThisMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_ThisMonth.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ibtn_ThisMonth.ForeColor = System.Drawing.Color.White;
            this.ibtn_ThisMonth.IconChar = FontAwesome.Sharp.IconChar.None;
            this.ibtn_ThisMonth.IconColor = System.Drawing.Color.Black;
            this.ibtn_ThisMonth.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_ThisMonth.Location = new System.Drawing.Point(1043, 11);
            this.ibtn_ThisMonth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ibtn_ThisMonth.Name = "ibtn_ThisMonth";
            this.ibtn_ThisMonth.Size = new System.Drawing.Size(100, 60);
            this.ibtn_ThisMonth.TabIndex = 3;
            this.ibtn_ThisMonth.Text = "Este mes";
            this.ibtn_ThisMonth.UseVisualStyleBackColor = false;
            this.ibtn_ThisMonth.Click += new System.EventHandler(this.ibtn_ThisMonth_Click);
            // 
            // iconPictureBox4
            // 
            this.iconPictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconPictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            this.iconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.CalendarAlt;
            this.iconPictureBox4.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            this.iconPictureBox4.IconFont = FontAwesome.Sharp.IconFont.Regular;
            this.iconPictureBox4.IconSize = 37;
            this.iconPictureBox4.Location = new System.Drawing.Point(217, 30);
            this.iconPictureBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.iconPictureBox4.Name = "iconPictureBox4";
            this.iconPictureBox4.Size = new System.Drawing.Size(45, 37);
            this.iconPictureBox4.TabIndex = 13;
            this.iconPictureBox4.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "F. Inicial";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(420, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "F. Final";
            // 
            // Frm_DashboardAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(1155, 779);
            this.Controls.Add(this.chart_Top10Products);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.iconPictureBox4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.chart_IngresoPorFecha);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ibtn_OKCustomDate);
            this.Controls.Add(this.ibtn_CustomDate);
            this.Controls.Add(this.ibtn_Today);
            this.Controls.Add(this.ibtn_7Days);
            this.Controls.Add(this.ibtn_30Days);
            this.Controls.Add(this.ibtn_ThisMonth);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Frm_DashboardAdmin";
            this.Text = "Frm_DashboardAdmin";
            this.Load += new System.EventHandler(this.Frm_DashboardAdmin_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox5)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_IngresoPorFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Top10Products)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PBajoStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private FontAwesome.Sharp.IconButton ibtn_ThisMonth;
        private FontAwesome.Sharp.IconButton ibtn_30Days;
        private FontAwesome.Sharp.IconButton ibtn_7Days;
        private FontAwesome.Sharp.IconButton ibtn_Today;
        private FontAwesome.Sharp.IconButton ibtn_CustomDate;
        private FontAwesome.Sharp.IconButton ibtn_OKCustomDate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblVentas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblGanancias;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_IngresoPorFecha;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Top10Products;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblProductos;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblVendedores;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblClientes;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DataGridView dgv_PBajoStock;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox4;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox5;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
