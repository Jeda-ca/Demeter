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
            this.tbx_Desc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbx_SubTVent = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.ibtn_AddDV = new FontAwesome.Sharp.IconButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.tbx_Total = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbx_State = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tbx_Observaciones = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Cantidad)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.label1.Size = new System.Drawing.Size(1376, 49);
            this.label1.TabIndex = 1;
            this.label1.Text = "Registrar Venta";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.groupBox3.Controls.Add(this.ibtn_Cancel);
            this.groupBox3.Controls.Add(this.ibtn_Clear);
            this.groupBox3.Controls.Add(this.ibtn_Register);
            this.groupBox3.Location = new System.Drawing.Point(864, 425);
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
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.ibtn_NomProduct);
            this.groupBox2.Controls.Add(this.tbx_Product);
            this.groupBox2.Controls.Add(this.tbx_UniPrice);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.groupBox2.Location = new System.Drawing.Point(864, 59);
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
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
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
            // 
            // tbx_Product
            // 
            this.tbx_Product.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Product.Location = new System.Drawing.Point(34, 65);
            this.tbx_Product.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_Product.Name = "tbx_Product";
            this.tbx_Product.Size = new System.Drawing.Size(208, 30);
            this.tbx_Product.TabIndex = 15;
            // 
            // tbx_UniPrice
            // 
            this.tbx_UniPrice.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_UniPrice.Location = new System.Drawing.Point(301, 65);
            this.tbx_UniPrice.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_UniPrice.Name = "tbx_UniPrice";
            this.tbx_UniPrice.ReadOnly = true;
            this.tbx_UniPrice.Size = new System.Drawing.Size(163, 30);
            this.tbx_UniPrice.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(30, 33);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(244, 28);
            this.label10.TabIndex = 20;
            this.label10.Text = "Producto";
            // 
            // nud_Cantidad
            // 
            this.nud_Cantidad.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.nud_Cantidad.Location = new System.Drawing.Point(34, 69);
            this.nud_Cantidad.Name = "nud_Cantidad";
            this.nud_Cantidad.Size = new System.Drawing.Size(166, 30);
            this.nud_Cantidad.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 37);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
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
            this.tbx_DateV.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_DateV.Name = "tbx_DateV";
            this.tbx_DateV.ReadOnly = true;
            this.tbx_DateV.Size = new System.Drawing.Size(220, 30);
            this.tbx_DateV.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 28);
            this.label2.TabIndex = 17;
            this.label2.Text = "Fecha";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 33);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
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
            this.groupBox4.Size = new System.Drawing.Size(556, 114);
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
            this.ibtn_DocClient.Location = new System.Drawing.Point(216, 53);
            this.ibtn_DocClient.Name = "ibtn_DocClient";
            this.ibtn_DocClient.Size = new System.Drawing.Size(45, 42);
            this.ibtn_DocClient.TabIndex = 22;
            this.ibtn_DocClient.UseVisualStyleBackColor = false;
            // 
            // tbx_NomClient
            // 
            this.tbx_NomClient.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_NomClient.Location = new System.Drawing.Point(272, 65);
            this.tbx_NomClient.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_NomClient.Name = "tbx_NomClient";
            this.tbx_NomClient.ReadOnly = true;
            this.tbx_NomClient.Size = new System.Drawing.Size(268, 30);
            this.tbx_NomClient.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(268, 33);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(272, 28);
            this.label8.TabIndex = 17;
            this.label8.Text = "Nombre";
            // 
            // tbx_NumDoc
            // 
            this.tbx_NumDoc.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_NumDoc.Location = new System.Drawing.Point(33, 65);
            this.tbx_NumDoc.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_NumDoc.Name = "tbx_NumDoc";
            this.tbx_NumDoc.Size = new System.Drawing.Size(176, 30);
            this.tbx_NumDoc.TabIndex = 18;
            // 
            // tbx_SubTIItem
            // 
            this.tbx_SubTIItem.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_SubTIItem.Location = new System.Drawing.Point(221, 69);
            this.tbx_SubTIItem.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_SubTIItem.Name = "tbx_SubTIItem";
            this.tbx_SubTIItem.ReadOnly = true;
            this.tbx_SubTIItem.Size = new System.Drawing.Size(175, 30);
            this.tbx_SubTIItem.TabIndex = 37;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(217, 37);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(179, 28);
            this.label15.TabIndex = 38;
            this.label15.Text = "Subtotal item";
            // 
            // tbx_Desc
            // 
            this.tbx_Desc.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Desc.Location = new System.Drawing.Point(588, 144);
            this.tbx_Desc.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_Desc.Name = "tbx_Desc";
            this.tbx_Desc.Size = new System.Drawing.Size(175, 30);
            this.tbx_Desc.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(584, 112);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 28);
            this.label6.TabIndex = 40;
            this.label6.Text = "Descuento";
            // 
            // tbx_SubTVent
            // 
            this.tbx_SubTVent.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_SubTVent.Location = new System.Drawing.Point(588, 69);
            this.tbx_SubTVent.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_SubTVent.Name = "tbx_SubTVent";
            this.tbx_SubTVent.ReadOnly = true;
            this.tbx_SubTVent.Size = new System.Drawing.Size(175, 30);
            this.tbx_SubTVent.TabIndex = 41;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(584, 37);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
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
            this.ibtn_AddDV.Location = new System.Drawing.Point(467, 61);
            this.ibtn_AddDV.Name = "ibtn_AddDV";
            this.ibtn_AddDV.Size = new System.Drawing.Size(74, 43);
            this.ibtn_AddDV.TabIndex = 36;
            this.ibtn_AddDV.UseVisualStyleBackColor = false;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.groupBox5.Controls.Add(this.cbx_State);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.tbx_Total);
            this.groupBox5.Controls.Add(this.ibtn_AddDV);
            this.groupBox5.Controls.Add(this.tbx_SubTVent);
            this.groupBox5.Controls.Add(this.dataGridView1);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.nud_Cantidad);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.tbx_SubTIItem);
            this.groupBox5.Controls.Add(this.tbx_Desc);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.groupBox5.Location = new System.Drawing.Point(22, 179);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(836, 348);
            this.groupBox5.TabIndex = 29;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Detalle de venta";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(34, 117);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(507, 218);
            this.dataGridView1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(584, 192);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(179, 28);
            this.label7.TabIndex = 44;
            this.label7.Text = "Total a pagar";
            // 
            // tbx_Total
            // 
            this.tbx_Total.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Total.Location = new System.Drawing.Point(588, 224);
            this.tbx_Total.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_Total.Name = "tbx_Total";
            this.tbx_Total.ReadOnly = true;
            this.tbx_Total.Size = new System.Drawing.Size(175, 30);
            this.tbx_Total.TabIndex = 43;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(584, 273);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(179, 28);
            this.label9.TabIndex = 46;
            this.label9.Text = "Estado de venta";
            // 
            // cbx_State
            // 
            this.cbx_State.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_State.FormattingEnabled = true;
            this.cbx_State.Location = new System.Drawing.Point(588, 305);
            this.cbx_State.Name = "cbx_State";
            this.cbx_State.Size = new System.Drawing.Size(175, 32);
            this.cbx_State.TabIndex = 47;
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.groupBox6.Controls.Add(this.tbx_Observaciones);
            this.groupBox6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.groupBox6.Location = new System.Drawing.Point(864, 179);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(493, 240);
            this.groupBox6.TabIndex = 30;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Observaciones";
            // 
            // tbx_Observaciones
            // 
            this.tbx_Observaciones.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Observaciones.Location = new System.Drawing.Point(34, 34);
            this.tbx_Observaciones.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_Observaciones.Multiline = true;
            this.tbx_Observaciones.Name = "tbx_Observaciones";
            this.tbx_Observaciones.Size = new System.Drawing.Size(430, 186);
            this.tbx_Observaciones.TabIndex = 14;
            // 
            // Frm_AddSaleVendor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(1376, 549);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.TextBox tbx_Desc;
        private System.Windows.Forms.Label label6;
        private FontAwesome.Sharp.IconButton ibtn_AddDV;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbx_Total;
        private System.Windows.Forms.ComboBox cbx_State;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox tbx_Observaciones;
    }
}