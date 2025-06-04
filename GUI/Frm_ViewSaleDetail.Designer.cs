namespace GUI
{
    partial class Frm_ViewSaleDetail
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
            this.label12 = new System.Windows.Forms.Label();
            this.lbl_CalculatedDiscountAmount = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbl_DiscountTypeSuffix = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbx_Total = new System.Windows.Forms.TextBox();
            this.dgv_SaleDetail = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tbx_Observaciones = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbx_SubTIItem = new System.Windows.Forms.TextBox();
            this.tbx_DiscountValue = new System.Windows.Forms.TextBox();
            this.tbx_SubTVenta = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_Product = new System.Windows.Forms.TextBox();
            this.tbx_UniPrice = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbx_DateVenta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbx_NomClient = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbx_NumDoc = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tbx_CodeVenta = new System.Windows.Forms.TextBox();
            this.tbx_Quantity = new System.Windows.Forms.TextBox();
            this.tbx_TipoDesc = new System.Windows.Forms.TextBox();
            this.ibtn_Close = new FontAwesome.Sharp.IconButton();
            this.tbx_StateVenta = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SaleDetail)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(915, 464);
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
            this.lbl_CalculatedDiscountAmount.Location = new System.Drawing.Point(911, 492);
            this.lbl_CalculatedDiscountAmount.Name = "lbl_CalculatedDiscountAmount";
            this.lbl_CalculatedDiscountAmount.Size = new System.Drawing.Size(180, 21);
            this.lbl_CalculatedDiscountAmount.TabIndex = 51;
            this.lbl_CalculatedDiscountAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.label11.Location = new System.Drawing.Point(856, 116);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(138, 23);
            this.label11.TabIndex = 50;
            this.label11.Text = "Tipo descuento";
            // 
            // lbl_DiscountTypeSuffix
            // 
            this.lbl_DiscountTypeSuffix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_DiscountTypeSuffix.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DiscountTypeSuffix.Location = new System.Drawing.Point(1034, 229);
            this.lbl_DiscountTypeSuffix.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_DiscountTypeSuffix.Name = "lbl_DiscountTypeSuffix";
            this.lbl_DiscountTypeSuffix.Size = new System.Drawing.Size(23, 30);
            this.lbl_DiscountTypeSuffix.TabIndex = 48;
            this.lbl_DiscountTypeSuffix.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(856, 368);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(179, 28);
            this.label9.TabIndex = 46;
            this.label9.Text = "Estado de venta";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(856, 286);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(179, 27);
            this.label7.TabIndex = 44;
            this.label7.Text = "Total a pagar";
            // 
            // tbx_Total
            // 
            this.tbx_Total.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_Total.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Total.Location = new System.Drawing.Point(860, 317);
            this.tbx_Total.Name = "tbx_Total";
            this.tbx_Total.ReadOnly = true;
            this.tbx_Total.Size = new System.Drawing.Size(175, 30);
            this.tbx_Total.TabIndex = 43;
            // 
            // dgv_SaleDetail
            // 
            this.dgv_SaleDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_SaleDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_SaleDetail.Location = new System.Drawing.Point(35, 44);
            this.dgv_SaleDetail.Name = "dgv_SaleDetail";
            this.dgv_SaleDetail.RowHeadersWidth = 51;
            this.dgv_SaleDetail.RowTemplate.Height = 24;
            this.dgv_SaleDetail.Size = new System.Drawing.Size(790, 469);
            this.dgv_SaleDetail.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(223, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 28);
            this.label5.TabIndex = 32;
            this.label5.Text = "Cantidad";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(856, 33);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(179, 28);
            this.label13.TabIndex = 42;
            this.label13.Text = "Subtotal venta";
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.groupBox6.Controls.Add(this.tbx_Observaciones);
            this.groupBox6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.groupBox6.Location = new System.Drawing.Point(1125, 339);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(381, 289);
            this.groupBox6.TabIndex = 37;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Observaciones";
            // 
            // tbx_Observaciones
            // 
            this.tbx_Observaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_Observaciones.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Observaciones.Location = new System.Drawing.Point(35, 30);
            this.tbx_Observaciones.Multiline = true;
            this.tbx_Observaciones.Name = "tbx_Observaciones";
            this.tbx_Observaciones.ReadOnly = true;
            this.tbx_Observaciones.Size = new System.Drawing.Size(318, 235);
            this.tbx_Observaciones.TabIndex = 14;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(31, 188);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(179, 28);
            this.label15.TabIndex = 38;
            this.label15.Text = "Subtotal item";
            // 
            // tbx_SubTIItem
            // 
            this.tbx_SubTIItem.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_SubTIItem.Location = new System.Drawing.Point(35, 220);
            this.tbx_SubTIItem.Name = "tbx_SubTIItem";
            this.tbx_SubTIItem.ReadOnly = true;
            this.tbx_SubTIItem.Size = new System.Drawing.Size(175, 30);
            this.tbx_SubTIItem.TabIndex = 37;
            // 
            // tbx_DiscountValue
            // 
            this.tbx_DiscountValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_DiscountValue.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_DiscountValue.Location = new System.Drawing.Point(860, 231);
            this.tbx_DiscountValue.Name = "tbx_DiscountValue";
            this.tbx_DiscountValue.ReadOnly = true;
            this.tbx_DiscountValue.Size = new System.Drawing.Size(175, 30);
            this.tbx_DiscountValue.TabIndex = 39;
            // 
            // tbx_SubTVenta
            // 
            this.tbx_SubTVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_SubTVenta.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_SubTVenta.Location = new System.Drawing.Point(860, 65);
            this.tbx_SubTVenta.Name = "tbx_SubTVenta";
            this.tbx_SubTVenta.ReadOnly = true;
            this.tbx_SubTVenta.Size = new System.Drawing.Size(175, 30);
            this.tbx_SubTVenta.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(856, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 27);
            this.label6.TabIndex = 40;
            this.label6.Text = "Descuento";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbx_Product);
            this.groupBox2.Controls.Add(this.tbx_Quantity);
            this.groupBox2.Controls.Add(this.tbx_UniPrice);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.tbx_SubTIItem);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.groupBox2.Location = new System.Drawing.Point(1125, 61);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(381, 270);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Información de producto";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 28);
            this.label3.TabIndex = 30;
            this.label3.Text = "Precio unitario";
            // 
            // tbx_Product
            // 
            this.tbx_Product.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Product.Location = new System.Drawing.Point(35, 61);
            this.tbx_Product.Name = "tbx_Product";
            this.tbx_Product.ReadOnly = true;
            this.tbx_Product.Size = new System.Drawing.Size(208, 30);
            this.tbx_Product.TabIndex = 15;
            // 
            // tbx_UniPrice
            // 
            this.tbx_UniPrice.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_UniPrice.Location = new System.Drawing.Point(35, 141);
            this.tbx_UniPrice.Name = "tbx_UniPrice";
            this.tbx_UniPrice.ReadOnly = true;
            this.tbx_UniPrice.Size = new System.Drawing.Size(163, 30);
            this.tbx_UniPrice.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(31, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(244, 28);
            this.label10.TabIndex = 20;
            this.label10.Text = "Producto";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.tbx_CodeVenta);
            this.groupBox1.Controls.Add(this.tbx_DateVenta);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.groupBox1.Location = new System.Drawing.Point(23, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 114);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información de la venta";
            // 
            // tbx_DateVenta
            // 
            this.tbx_DateVenta.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_DateVenta.Location = new System.Drawing.Point(35, 61);
            this.tbx_DateVenta.Name = "tbx_DateVenta";
            this.tbx_DateVenta.ReadOnly = true;
            this.tbx_DateVenta.Size = new System.Drawing.Size(220, 30);
            this.tbx_DateVenta.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 28);
            this.label2.TabIndex = 17;
            this.label2.Text = "Fecha";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.groupBox4.Controls.Add(this.tbx_NomClient);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.tbx_NumDoc);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.groupBox4.Location = new System.Drawing.Point(563, 61);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(556, 114);
            this.groupBox4.TabIndex = 35;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Información del cliente";
            // 
            // tbx_NomClient
            // 
            this.tbx_NomClient.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_NomClient.Location = new System.Drawing.Point(284, 61);
            this.tbx_NomClient.Name = "tbx_NomClient";
            this.tbx_NomClient.ReadOnly = true;
            this.tbx_NomClient.Size = new System.Drawing.Size(240, 30);
            this.tbx_NomClient.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(280, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(224, 28);
            this.label8.TabIndex = 17;
            this.label8.Text = "Nombre";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(220, 28);
            this.label4.TabIndex = 21;
            this.label4.Text = "N° de documento";
            // 
            // tbx_NumDoc
            // 
            this.tbx_NumDoc.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_NumDoc.Location = new System.Drawing.Point(34, 61);
            this.tbx_NumDoc.Name = "tbx_NumDoc";
            this.tbx_NumDoc.ReadOnly = true;
            this.tbx_NumDoc.Size = new System.Drawing.Size(220, 30);
            this.tbx_NumDoc.TabIndex = 18;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.groupBox5.Controls.Add(this.tbx_StateVenta);
            this.groupBox5.Controls.Add(this.tbx_TipoDesc);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.lbl_CalculatedDiscountAmount);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.lbl_DiscountTypeSuffix);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.tbx_Total);
            this.groupBox5.Controls.Add(this.tbx_SubTVenta);
            this.groupBox5.Controls.Add(this.dgv_SaleDetail);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.tbx_DiscountValue);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.groupBox5.Location = new System.Drawing.Point(23, 181);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1096, 530);
            this.groupBox5.TabIndex = 36;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Detalle de venta";
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
            this.label1.Size = new System.Drawing.Size(1524, 49);
            this.label1.TabIndex = 31;
            this.label1.Text = "Detalles de la Venta";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(277, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(220, 28);
            this.label14.TabIndex = 23;
            this.label14.Text = "Código venta";
            // 
            // tbx_CodeVenta
            // 
            this.tbx_CodeVenta.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_CodeVenta.Location = new System.Drawing.Point(281, 61);
            this.tbx_CodeVenta.Name = "tbx_CodeVenta";
            this.tbx_CodeVenta.ReadOnly = true;
            this.tbx_CodeVenta.Size = new System.Drawing.Size(220, 30);
            this.tbx_CodeVenta.TabIndex = 22;
            // 
            // tbx_Quantity
            // 
            this.tbx_Quantity.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Quantity.Location = new System.Drawing.Point(227, 141);
            this.tbx_Quantity.Name = "tbx_Quantity";
            this.tbx_Quantity.ReadOnly = true;
            this.tbx_Quantity.Size = new System.Drawing.Size(123, 30);
            this.tbx_Quantity.TabIndex = 53;
            // 
            // tbx_TipoDesc
            // 
            this.tbx_TipoDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_TipoDesc.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_TipoDesc.Location = new System.Drawing.Point(860, 148);
            this.tbx_TipoDesc.Name = "tbx_TipoDesc";
            this.tbx_TipoDesc.ReadOnly = true;
            this.tbx_TipoDesc.Size = new System.Drawing.Size(175, 30);
            this.tbx_TipoDesc.TabIndex = 54;
            // 
            // ibtn_Close
            // 
            this.ibtn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ibtn_Close.BackColor = System.Drawing.Color.Teal;
            this.ibtn_Close.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ibtn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_Close.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.ibtn_Close.ForeColor = System.Drawing.SystemColors.Control;
            this.ibtn_Close.IconChar = FontAwesome.Sharp.IconChar.None;
            this.ibtn_Close.IconColor = System.Drawing.Color.Black;
            this.ibtn_Close.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_Close.Location = new System.Drawing.Point(1351, 638);
            this.ibtn_Close.Margin = new System.Windows.Forms.Padding(4);
            this.ibtn_Close.Name = "ibtn_Close";
            this.ibtn_Close.Size = new System.Drawing.Size(155, 73);
            this.ibtn_Close.TabIndex = 38;
            this.ibtn_Close.Text = "Cerrar";
            this.ibtn_Close.UseVisualStyleBackColor = false;
            // 
            // tbx_StateVenta
            // 
            this.tbx_StateVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_StateVenta.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_StateVenta.Location = new System.Drawing.Point(860, 399);
            this.tbx_StateVenta.Name = "tbx_StateVenta";
            this.tbx_StateVenta.ReadOnly = true;
            this.tbx_StateVenta.Size = new System.Drawing.Size(175, 30);
            this.tbx_StateVenta.TabIndex = 55;
            // 
            // Frm_ViewSaleDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(1524, 721);
            this.Controls.Add(this.ibtn_Close);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.label1);
            this.Name = "Frm_ViewSaleDetail";
            this.Text = "Frm_ViewSaleDetail";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SaleDetail)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbl_CalculatedDiscountAmount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbl_DiscountTypeSuffix;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbx_Total;
        private System.Windows.Forms.DataGridView dgv_SaleDetail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox tbx_Observaciones;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbx_SubTIItem;
        private System.Windows.Forms.TextBox tbx_DiscountValue;
        private System.Windows.Forms.TextBox tbx_SubTVenta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbx_Product;
        private System.Windows.Forms.TextBox tbx_UniPrice;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbx_DateVenta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tbx_NomClient;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbx_NumDoc;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbx_CodeVenta;
        private System.Windows.Forms.TextBox tbx_Quantity;
        private System.Windows.Forms.TextBox tbx_TipoDesc;
        private System.Windows.Forms.TextBox tbx_StateVenta;
        private FontAwesome.Sharp.IconButton ibtn_Close;
    }
}