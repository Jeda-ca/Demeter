namespace GUI
{
    partial class Frm_AddSaleVendor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AddSaleVendor));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ibtn_Cancel = new FontAwesome.Sharp.IconButton();
            this.ibtn_Clear = new FontAwesome.Sharp.IconButton();
            this.ibtn_Register = new FontAwesome.Sharp.IconButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ibtn_NomProduct = new FontAwesome.Sharp.IconButton();
            this.tbx_Product = new System.Windows.Forms.TextBox();
            this.tbx_UniPrice = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.nud_Cantidad = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbx_DateV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ibtn_DocClient = new FontAwesome.Sharp.IconButton();
            this.tbx_NomClient = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbx_NumDoc = new System.Windows.Forms.TextBox();
            this.tbx_SubTIItem = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbx_DiscountValue = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbx_SubTVent = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.ibtn_AddDV = new FontAwesome.Sharp.IconButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lbl_CalculatedDiscountAmount = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbx_DiscountType = new System.Windows.Forms.ComboBox();
            this.lbl_DiscountTypeSuffix = new System.Windows.Forms.Label();
            this.cbx_State = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbx_Total = new System.Windows.Forms.TextBox();
            this.dgv_SaleDetail = new System.Windows.Forms.DataGridView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tbx_Observaciones = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Cantidad)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SaleDetail)).BeginInit();
            this.groupBox6.SuspendLayout();
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
            this.label1.Size = new System.Drawing.Size(1464, 49);
            this.label1.TabIndex = 1;
            this.label1.Text = "Registrar Venta";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.groupBox3.Controls.Add(this.ibtn_Cancel);
            this.groupBox3.Controls.Add(this.ibtn_Clear);
            this.groupBox3.Controls.Add(this.ibtn_Register);
            this.groupBox3.Location = new System.Drawing.Point(952, 602);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(493, 102);
            this.groupBox3.TabIndex = 28;
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
            this.ibtn_Cancel.Location = new System.Drawing.Point(331, 16);
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
            this.ibtn_Clear.Location = new System.Drawing.Point(170, 16);
            this.ibtn_Clear.Margin = new System.Windows.Forms.Padding(4);
            this.ibtn_Clear.Name = "ibtn_Clear";
            this.ibtn_Clear.Size = new System.Drawing.Size(155, 73);
            this.ibtn_Clear.TabIndex = 6;
            this.ibtn_Clear.Text = "Limpiar";
            this.ibtn_Clear.UseVisualStyleBackColor = false;
            this.ibtn_Clear.Click += new System.EventHandler(this.ibtn_Clear_Click);
            // 
            // ibtn_Register
            // 
            this.ibtn_Register.BackColor = System.Drawing.Color.Teal;
            this.ibtn_Register.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ibtn_Register.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_Register.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.ibtn_Register.ForeColor = System.Drawing.SystemColors.Control;
            this.ibtn_Register.IconChar = FontAwesome.Sharp.IconChar.None;
            this.ibtn_Register.IconColor = System.Drawing.Color.Black;
            this.ibtn_Register.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_Register.Location = new System.Drawing.Point(7, 16);
            this.ibtn_Register.Margin = new System.Windows.Forms.Padding(4);
            this.ibtn_Register.Name = "ibtn_Register";
            this.ibtn_Register.Size = new System.Drawing.Size(155, 73);
            this.ibtn_Register.TabIndex = 5;
            this.ibtn_Register.Text = "Registrar";
            this.ibtn_Register.UseVisualStyleBackColor = false;
            this.ibtn_Register.Click += new System.EventHandler(this.ibtn_Register_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.ibtn_NomProduct);
            this.groupBox2.Controls.Add(this.tbx_Product);
            this.groupBox2.Controls.Add(this.tbx_UniPrice);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.groupBox2.Location = new System.Drawing.Point(952, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(493, 114);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Información de producto";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(297, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 28);
            this.label3.TabIndex = 30;
            this.label3.Text = "Precio unitario";
            // 
            // ibtn_NomProduct
            // 
            this.ibtn_NomProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            this.ibtn_NomProduct.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ibtn_NomProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_NomProduct.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.ibtn_NomProduct.IconColor = System.Drawing.Color.White;
            this.ibtn_NomProduct.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.ibtn_NomProduct.IconSize = 30;
            this.ibtn_NomProduct.Location = new System.Drawing.Point(249, 53);
            this.ibtn_NomProduct.Name = "ibtn_NomProduct";
            this.ibtn_NomProduct.Size = new System.Drawing.Size(45, 42);
            this.ibtn_NomProduct.TabIndex = 24;
            this.ibtn_NomProduct.UseVisualStyleBackColor = false;
            this.ibtn_NomProduct.Click += new System.EventHandler(this.ibtn_NomProduct_Click);
            // 
            // tbx_Product
            // 
            this.tbx_Product.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Product.Location = new System.Drawing.Point(34, 65);
            this.tbx_Product.Name = "tbx_Product";
            this.tbx_Product.Size = new System.Drawing.Size(208, 30);
            this.tbx_Product.TabIndex = 15;
            // 
            // tbx_UniPrice
            // 
            this.tbx_UniPrice.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_UniPrice.Location = new System.Drawing.Point(301, 65);
            this.tbx_UniPrice.Name = "tbx_UniPrice";
            this.tbx_UniPrice.ReadOnly = true;
            this.tbx_UniPrice.Size = new System.Drawing.Size(163, 30);
            this.tbx_UniPrice.TabIndex = 19;
            this.tbx_UniPrice.TextChanged += new System.EventHandler(this.tbx_UniPrice_TextChanged);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(30, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(244, 28);
            this.label10.TabIndex = 20;
            this.label10.Text = "Producto";
            // 
            // nud_Cantidad
            // 
            this.nud_Cantidad.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.nud_Cantidad.Location = new System.Drawing.Point(34, 69);
            this.nud_Cantidad.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nud_Cantidad.Name = "nud_Cantidad";
            this.nud_Cantidad.Size = new System.Drawing.Size(166, 30);
            this.nud_Cantidad.TabIndex = 33;
            this.nud_Cantidad.ValueChanged += new System.EventHandler(this.nud_Cantidad_ValueChanged);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 28);
            this.label5.TabIndex = 32;
            this.label5.Text = "Cantidad";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.groupBox1.Controls.Add(this.tbx_DateV);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.groupBox1.Location = new System.Drawing.Point(22, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 114);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información de la venta";
            // 
            // tbx_DateV
            // 
            this.tbx_DateV.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_DateV.Location = new System.Drawing.Point(34, 65);
            this.tbx_DateV.Name = "tbx_DateV";
            this.tbx_DateV.ReadOnly = true;
            this.tbx_DateV.Size = new System.Drawing.Size(220, 30);
            this.tbx_DateV.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 28);
            this.label2.TabIndex = 17;
            this.label2.Text = "Fecha";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(220, 28);
            this.label4.TabIndex = 21;
            this.label4.Text = "N° de documento";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.groupBox4.Controls.Add(this.ibtn_DocClient);
            this.groupBox4.Controls.Add(this.tbx_NomClient);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.tbx_NumDoc);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.groupBox4.Location = new System.Drawing.Point(302, 59);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(644, 114);
            this.groupBox4.TabIndex = 29;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Información del cliente";
            // 
            // ibtn_DocClient
            // 
            this.ibtn_DocClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            this.ibtn_DocClient.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ibtn_DocClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_DocClient.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.ibtn_DocClient.IconColor = System.Drawing.Color.White;
            this.ibtn_DocClient.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.ibtn_DocClient.IconSize = 30;
            this.ibtn_DocClient.Location = new System.Drawing.Point(260, 53);
            this.ibtn_DocClient.Name = "ibtn_DocClient";
            this.ibtn_DocClient.Size = new System.Drawing.Size(45, 42);
            this.ibtn_DocClient.TabIndex = 22;
            this.ibtn_DocClient.UseVisualStyleBackColor = false;
            this.ibtn_DocClient.Click += new System.EventHandler(this.ibtn_DocClient_Click);
            // 
            // tbx_NomClient
            // 
            this.tbx_NomClient.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_NomClient.Location = new System.Drawing.Point(327, 65);
            this.tbx_NomClient.Name = "tbx_NomClient";
            this.tbx_NomClient.ReadOnly = true;
            this.tbx_NomClient.Size = new System.Drawing.Size(300, 30);
            this.tbx_NomClient.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(323, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(304, 28);
            this.label8.TabIndex = 17;
            this.label8.Text = "Nombre";
            // 
            // tbx_NumDoc
            // 
            this.tbx_NumDoc.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_NumDoc.Location = new System.Drawing.Point(33, 65);
            this.tbx_NumDoc.Name = "tbx_NumDoc";
            this.tbx_NumDoc.Size = new System.Drawing.Size(216, 30);
            this.tbx_NumDoc.TabIndex = 18;
            // 
            // tbx_SubTIItem
            // 
            this.tbx_SubTIItem.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_SubTIItem.Location = new System.Drawing.Point(280, 69);
            this.tbx_SubTIItem.Name = "tbx_SubTIItem";
            this.tbx_SubTIItem.ReadOnly = true;
            this.tbx_SubTIItem.Size = new System.Drawing.Size(175, 30);
            this.tbx_SubTIItem.TabIndex = 37;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(276, 37);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(179, 28);
            this.label15.TabIndex = 38;
            this.label15.Text = "Subtotal item";
            // 
            // tbx_DiscountValue
            // 
            this.tbx_DiscountValue.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_DiscountValue.Location = new System.Drawing.Point(687, 236);
            this.tbx_DiscountValue.Name = "tbx_DiscountValue";
            this.tbx_DiscountValue.Size = new System.Drawing.Size(175, 30);
            this.tbx_DiscountValue.TabIndex = 39;
            this.tbx_DiscountValue.TextChanged += new System.EventHandler(this.tbx_DiscountValue_TextChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(683, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 28);
            this.label6.TabIndex = 40;
            this.label6.Text = "Descuento";
            // 
            // tbx_SubTVent
            // 
            this.tbx_SubTVent.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_SubTVent.Location = new System.Drawing.Point(687, 69);
            this.tbx_SubTVent.Name = "tbx_SubTVent";
            this.tbx_SubTVent.ReadOnly = true;
            this.tbx_SubTVent.Size = new System.Drawing.Size(175, 30);
            this.tbx_SubTVent.TabIndex = 41;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(683, 37);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(179, 28);
            this.label13.TabIndex = 42;
            this.label13.Text = "Subtotal venta";
            // 
            // ibtn_AddDV
            // 
            this.ibtn_AddDV.BackColor = System.Drawing.Color.DarkGreen;
            this.ibtn_AddDV.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ibtn_AddDV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_AddDV.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.ibtn_AddDV.IconColor = System.Drawing.Color.White;
            this.ibtn_AddDV.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.ibtn_AddDV.IconSize = 30;
            this.ibtn_AddDV.Location = new System.Drawing.Point(578, 56);
            this.ibtn_AddDV.Name = "ibtn_AddDV";
            this.ibtn_AddDV.Size = new System.Drawing.Size(74, 43);
            this.ibtn_AddDV.TabIndex = 36;
            this.ibtn_AddDV.UseVisualStyleBackColor = false;
            this.ibtn_AddDV.Click += new System.EventHandler(this.ibtn_AddDV_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right))); // Anclado a todos los lados
            this.groupBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.lbl_CalculatedDiscountAmount);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.cbx_DiscountType);
            this.groupBox5.Controls.Add(this.lbl_DiscountTypeSuffix);
            this.groupBox5.Controls.Add(this.cbx_State);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.tbx_Total);
            this.groupBox5.Controls.Add(this.ibtn_AddDV);
            this.groupBox5.Controls.Add(this.tbx_SubTVent);
            this.groupBox5.Controls.Add(this.dgv_SaleDetail);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.nud_Cantidad);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.tbx_SubTIItem);
            this.groupBox5.Controls.Add(this.tbx_DiscountValue);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.groupBox5.Location = new System.Drawing.Point(22, 179);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(924, 525);
            this.groupBox5.TabIndex = 29;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Detalle de venta";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(742, 463);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(176, 28);
            this.label12.TabIndex = 52;
            this.label12.Text = "Descuento aplicado";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_CalculatedDiscountAmount
            // 
            this.lbl_CalculatedDiscountAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_CalculatedDiscountAmount.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.lbl_CalculatedDiscountAmount.Location = new System.Drawing.Point(738, 491);
            this.lbl_CalculatedDiscountAmount.Name = "lbl_CalculatedDiscountAmount";
            this.lbl_CalculatedDiscountAmount.Size = new System.Drawing.Size(180, 21);
            this.lbl_CalculatedDiscountAmount.TabIndex = 51;
            this.lbl_CalculatedDiscountAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.label11.Location = new System.Drawing.Point(683, 120);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(138, 23);
            this.label11.TabIndex = 50;
            this.label11.Text = "Tipo descuento";
            // 
            // cbx_DiscountType
            // 
            this.cbx_DiscountType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_DiscountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_DiscountType.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_DiscountType.FormattingEnabled = true;
            this.cbx_DiscountType.Location = new System.Drawing.Point(687, 152);
            this.cbx_DiscountType.Name = "cbx_DiscountType";
            this.cbx_DiscountType.Size = new System.Drawing.Size(175, 32);
            this.cbx_DiscountType.TabIndex = 49;
            // 
            // lbl_DiscountTypeSuffix
            // 
            this.lbl_DiscountTypeSuffix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_DiscountTypeSuffix.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DiscountTypeSuffix.Location = new System.Drawing.Point(861, 233);
            this.lbl_DiscountTypeSuffix.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_DiscountTypeSuffix.Name = "lbl_DiscountTypeSuffix";
            this.lbl_DiscountTypeSuffix.Size = new System.Drawing.Size(23, 30);
            this.lbl_DiscountTypeSuffix.TabIndex = 48;
            this.lbl_DiscountTypeSuffix.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbx_State
            // 
            this.cbx_State.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_State.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_State.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_State.FormattingEnabled = true;
            this.cbx_State.Location = new System.Drawing.Point(687, 402);
            this.cbx_State.Name = "cbx_State";
            this.cbx_State.Size = new System.Drawing.Size(175, 32);
            this.cbx_State.TabIndex = 47;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(683, 370);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(179, 28);
            this.label9.TabIndex = 46;
            this.label9.Text = "Estado de venta";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(683, 287);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(179, 28);
            this.label7.TabIndex = 44;
            this.label7.Text = "Total a pagar";
            // 
            // tbx_Total
            // 
            this.tbx_Total.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_Total.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Total.Location = new System.Drawing.Point(687, 319);
            this.tbx_Total.Name = "tbx_Total";
            this.tbx_Total.ReadOnly = true;
            this.tbx_Total.Size = new System.Drawing.Size(175, 30);
            this.tbx_Total.TabIndex = 43;
            // 
            // dgv_SaleDetail
            // 
            this.dgv_SaleDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right))); // Anclado a todos los lados
            this.dgv_SaleDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_SaleDetail.Location = new System.Drawing.Point(34, 117);
            this.dgv_SaleDetail.Name = "dgv_SaleDetail";
            this.dgv_SaleDetail.RowHeadersWidth = 51;
            this.dgv_SaleDetail.RowTemplate.Height = 24;
            this.dgv_SaleDetail.Size = new System.Drawing.Size(618, 395);
            this.dgv_SaleDetail.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right))); // Anclado a Top, Bottom, Right
            this.groupBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.groupBox6.Controls.Add(this.tbx_Observaciones);
            this.groupBox6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.groupBox6.Location = new System.Drawing.Point(952, 179);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(493, 417);
            this.groupBox6.TabIndex = 30;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Observaciones";
            // 
            // tbx_Observaciones
            // 
            this.tbx_Observaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right))); // Anclado a todos los lados
            this.tbx_Observaciones.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Observaciones.Location = new System.Drawing.Point(34, 34);
            this.tbx_Observaciones.Multiline = true;
            this.tbx_Observaciones.Name = "tbx_Observaciones";
            this.tbx_Observaciones.Size = new System.Drawing.Size(430, 363);
            this.tbx_Observaciones.TabIndex = 14;
            // 
            // Frm_AddSaleVendor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(1464, 716);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_AddSaleVendor";
            this.Text = "Demeter";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable; // <-- CAMBIO CLAVE: Hacer el formulario redimensionable
            this.MaximizeBox = false; // Mantener el botón de maximizar deshabilitado
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Cantidad)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SaleDetail)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private FontAwesome.Sharp.IconButton ibtn_Cancel;
        private FontAwesome.Sharp.IconButton ibtn_Clear;
        private FontAwesome.Sharp.IconButton ibtn_Register;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbx_Product;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbx_UniPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbx_DateV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tbx_NomClient;
        private System.Windows.Forms.Label label8;
        private FontAwesome.Sharp.IconButton ibtn_DocClient;
        private System.Windows.Forms.TextBox tbx_NumDoc;
        private FontAwesome.Sharp.IconButton ibtn_NomProduct;
        private System.Windows.Forms.NumericUpDown nud_Cantidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbx_SubTIItem;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbx_SubTVent;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbx_DiscountValue;
        private System.Windows.Forms.Label label6;
        private FontAwesome.Sharp.IconButton ibtn_AddDV;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dgv_SaleDetail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbx_Total;
        private System.Windows.Forms.ComboBox cbx_State;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox tbx_Observaciones;
        private System.Windows.Forms.Label lbl_DiscountTypeSuffix;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbx_DiscountType;
        private System.Windows.Forms.Label lbl_CalculatedDiscountAmount;
        private System.Windows.Forms.Label label12;
    }
}