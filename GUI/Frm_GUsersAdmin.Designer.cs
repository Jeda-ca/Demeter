namespace GUI
{
    partial class Frm_GUsersAdmin
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
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ibtn_Asignar = new FontAwesome.Sharp.IconButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbx_State = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbx_NameUser = new System.Windows.Forms.TextBox();
            this.tbx_PassUser = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbx_CodUser = new System.Windows.Forms.TextBox();
            this.tbx_NDoc = new System.Windows.Forms.TextBox();
            this.tbx_Nombre = new System.Windows.Forms.TextBox();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.ibtn_Buscar = new FontAwesome.Sharp.IconButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dgv_ListaUsuarios = new System.Windows.Forms.DataGridView();
            this.tbx_Busqueda = new System.Windows.Forms.TextBox();
            this.cbx_Buscar = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListaUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(866, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "  Gestor de Usuarios";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.ibtn_Asignar);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Location = new System.Drawing.Point(32, 276);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(798, 304);
            this.panel2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label3.Location = new System.Drawing.Point(13, 38);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "Ingrese la información  ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label11.Location = new System.Drawing.Point(6, 0);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(177, 19);
            this.label11.TabIndex = 10;
            this.label11.Text = "Asignar credenciales";
            // 
            // ibtn_Asignar
            // 
            this.ibtn_Asignar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_Asignar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtn_Asignar.FlatAppearance.BorderSize = 0;
            this.ibtn_Asignar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_Asignar.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ibtn_Asignar.ForeColor = System.Drawing.Color.White;
            this.ibtn_Asignar.IconChar = FontAwesome.Sharp.IconChar.UserCheck;
            this.ibtn_Asignar.IconColor = System.Drawing.Color.White;
            this.ibtn_Asignar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_Asignar.IconSize = 33;
            this.ibtn_Asignar.Location = new System.Drawing.Point(542, 203);
            this.ibtn_Asignar.Margin = new System.Windows.Forms.Padding(2);
            this.ibtn_Asignar.Name = "ibtn_Asignar";
            this.ibtn_Asignar.Size = new System.Drawing.Size(117, 49);
            this.ibtn_Asignar.TabIndex = 7;
            this.ibtn_Asignar.Text = "  Asignar";
            this.ibtn_Asignar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtn_Asignar.UseVisualStyleBackColor = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbx_State);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 10F);
            this.groupBox3.Location = new System.Drawing.Point(542, 67);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(244, 98);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Estado de cuenta";
            // 
            // cbx_State
            // 
            this.cbx_State.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cbx_State.Location = new System.Drawing.Point(16, 40);
            this.cbx_State.Margin = new System.Windows.Forms.Padding(2);
            this.cbx_State.Name = "cbx_State";
            this.cbx_State.Size = new System.Drawing.Size(191, 24);
            this.cbx_State.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tbx_NameUser);
            this.groupBox2.Controls.Add(this.tbx_PassUser);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.groupBox2.Location = new System.Drawing.Point(279, 67);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(244, 203);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cuenta / Credenciales";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label12.Location = new System.Drawing.Point(15, 30);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 14);
            this.label12.TabIndex = 6;
            this.label12.Text = "Nombre de usuario";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label6.Location = new System.Drawing.Point(15, 95);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 14);
            this.label6.TabIndex = 5;
            this.label6.Text = "Contraseña";
            // 
            // tbx_NameUser
            // 
            this.tbx_NameUser.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tbx_NameUser.Location = new System.Drawing.Point(18, 49);
            this.tbx_NameUser.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_NameUser.Name = "tbx_NameUser";
            this.tbx_NameUser.Size = new System.Drawing.Size(189, 24);
            this.tbx_NameUser.TabIndex = 1;
            // 
            // tbx_PassUser
            // 
            this.tbx_PassUser.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tbx_PassUser.Location = new System.Drawing.Point(18, 117);
            this.tbx_PassUser.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_PassUser.Name = "tbx_PassUser";
            this.tbx_PassUser.Size = new System.Drawing.Size(189, 24);
            this.tbx_PassUser.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbx_CodUser);
            this.groupBox1.Controls.Add(this.tbx_NDoc);
            this.groupBox1.Controls.Add(this.tbx_Nombre);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.groupBox1.Location = new System.Drawing.Point(14, 67);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(244, 203);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info. del usuario";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label9.Location = new System.Drawing.Point(16, 144);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 14);
            this.label9.TabIndex = 6;
            this.label9.Text = "No. documento";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label8.Location = new System.Drawing.Point(17, 84);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 14);
            this.label8.TabIndex = 5;
            this.label8.Text = "Nombre";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label7.Location = new System.Drawing.Point(16, 26);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 14);
            this.label7.TabIndex = 4;
            this.label7.Text = "Código de usuario";
            // 
            // tbx_CodUser
            // 
            this.tbx_CodUser.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tbx_CodUser.Location = new System.Drawing.Point(18, 44);
            this.tbx_CodUser.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_CodUser.Name = "tbx_CodUser";
            this.tbx_CodUser.Size = new System.Drawing.Size(189, 24);
            this.tbx_CodUser.TabIndex = 1;
            // 
            // tbx_NDoc
            // 
            this.tbx_NDoc.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tbx_NDoc.Location = new System.Drawing.Point(18, 161);
            this.tbx_NDoc.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_NDoc.Name = "tbx_NDoc";
            this.tbx_NDoc.ReadOnly = true;
            this.tbx_NDoc.Size = new System.Drawing.Size(189, 24);
            this.tbx_NDoc.TabIndex = 2;
            // 
            // tbx_Nombre
            // 
            this.tbx_Nombre.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tbx_Nombre.Location = new System.Drawing.Point(18, 100);
            this.tbx_Nombre.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_Nombre.Name = "tbx_Nombre";
            this.tbx_Nombre.ReadOnly = true;
            this.tbx_Nombre.Size = new System.Drawing.Size(189, 24);
            this.tbx_Nombre.TabIndex = 3;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ibtn_Buscar);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.dgv_ListaUsuarios);
            this.panel1.Controls.Add(this.tbx_Busqueda);
            this.panel1.Controls.Add(this.cbx_Buscar);
            this.panel1.Location = new System.Drawing.Point(32, 55);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 201);
            this.panel1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label2.Location = new System.Drawing.Point(13, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "Buscar por:";
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
            this.ibtn_Buscar.Location = new System.Drawing.Point(682, 40);
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
            this.label5.Location = new System.Drawing.Point(13, 170);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(769, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Si no se encuentra el usuario que necesita, lo más seguro es que no se encuentra " +
    "registrado";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label4.Location = new System.Drawing.Point(13, 99);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Lista de usuarios";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label10.Location = new System.Drawing.Point(6, -1);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(152, 19);
            this.label10.TabIndex = 3;
            this.label10.Text = "Consultar usuario";
            // 
            // dgv_ListaUsuarios
            // 
            this.dgv_ListaUsuarios.AllowUserToAddRows = false;
            this.dgv_ListaUsuarios.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgv_ListaUsuarios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ListaUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_ListaUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ListaUsuarios.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgv_ListaUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_ListaUsuarios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_ListaUsuarios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ListaUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_ListaUsuarios.ColumnHeadersHeight = 30;
            this.dgv_ListaUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(203)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ListaUsuarios.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_ListaUsuarios.EnableHeadersVisualStyles = false;
            this.dgv_ListaUsuarios.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.dgv_ListaUsuarios.Location = new System.Drawing.Point(16, 122);
            this.dgv_ListaUsuarios.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_ListaUsuarios.Name = "dgv_ListaUsuarios";
            this.dgv_ListaUsuarios.ReadOnly = true;
            this.dgv_ListaUsuarios.RowHeadersVisible = false;
            this.dgv_ListaUsuarios.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(203)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.dgv_ListaUsuarios.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_ListaUsuarios.RowTemplate.Height = 24;
            this.dgv_ListaUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ListaUsuarios.Size = new System.Drawing.Size(766, 32);
            this.dgv_ListaUsuarios.TabIndex = 2;
            // 
            // tbx_Busqueda
            // 
            this.tbx_Busqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_Busqueda.Font = new System.Drawing.Font("Tahoma", 12F);
            this.tbx_Busqueda.Location = new System.Drawing.Point(232, 50);
            this.tbx_Busqueda.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_Busqueda.Name = "tbx_Busqueda";
            this.tbx_Busqueda.Size = new System.Drawing.Size(443, 27);
            this.tbx_Busqueda.TabIndex = 1;
            // 
            // cbx_Buscar
            // 
            this.cbx_Buscar.Font = new System.Drawing.Font("Tahoma", 11F);
            this.cbx_Buscar.FormattingEnabled = true;
            this.cbx_Buscar.Location = new System.Drawing.Point(16, 50);
            this.cbx_Buscar.Margin = new System.Windows.Forms.Padding(2);
            this.cbx_Buscar.Name = "cbx_Buscar";
            this.cbx_Buscar.Size = new System.Drawing.Size(205, 26);
            this.cbx_Buscar.TabIndex = 0;
            // 
            // Frm_GUsersAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(866, 595);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Frm_GUsersAdmin";
            this.Text = "Frm_GUsersAdmin";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListaUsuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.TextBox tbx_Nombre;
        private System.Windows.Forms.TextBox tbx_NDoc;
        private System.Windows.Forms.TextBox tbx_CodUser;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbx_PassUser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbx_State;
        private System.Windows.Forms.TextBox tbx_NameUser;
        private FontAwesome.Sharp.IconButton ibtn_Asignar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton ibtn_Buscar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgv_ListaUsuarios;
        private System.Windows.Forms.TextBox tbx_Busqueda;
        private System.Windows.Forms.ComboBox cbx_Buscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label6;
    }
}