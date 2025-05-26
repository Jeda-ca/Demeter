namespace GUI
{
    partial class Frm_RegisterAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_RegisterAdmin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_SignIn = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkbx_showPassword = new System.Windows.Forms.CheckBox();
            this.tbx_Username = new System.Windows.Forms.TextBox();
            this.tbx_Password = new System.Windows.Forms.TextBox();
            this.btn_Ingresar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ibtn_Minimized_LogIn = new FontAwesome.Sharp.IconButton();
            this.ibtn_Exit_LogIn = new FontAwesome.Sharp.IconButton();
            this.checkbx2_showPassword = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.iconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.iconPictureBox4 = new FontAwesome.Sharp.IconPictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.iconPictureBox5 = new FontAwesome.Sharp.IconPictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.iconPictureBox6 = new FontAwesome.Sharp.IconPictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.iconPictureBox7 = new FontAwesome.Sharp.IconPictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.iconPictureBox8 = new FontAwesome.Sharp.IconPictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.iconPictureBox9 = new FontAwesome.Sharp.IconPictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox9)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.panel1.Controls.Add(this.lbl_SignIn);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 710);
            this.panel1.TabIndex = 14;
            // 
            // lbl_SignIn
            // 
            this.lbl_SignIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_SignIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_SignIn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SignIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(98)))));
            this.lbl_SignIn.Location = new System.Drawing.Point(3, 647);
            this.lbl_SignIn.Name = "lbl_SignIn";
            this.lbl_SignIn.Size = new System.Drawing.Size(256, 47);
            this.lbl_SignIn.TabIndex = 7;
            this.lbl_SignIn.Text = "Inicie sesión con su cuenta";
            this.lbl_SignIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_SignIn.Click += new System.EventHandler(this.lbl_SignIn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GUI.Properties.Resources.LogoDemeter;
            this.pictureBox1.Location = new System.Drawing.Point(31, 94);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label5.Location = new System.Drawing.Point(36, 296);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(191, 62);
            this.label5.TabIndex = 4;
            this.label5.Text = "Bienvenido/a a Demeter";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkbx_showPassword
            // 
            this.checkbx_showPassword.AutoSize = true;
            this.checkbx_showPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkbx_showPassword.Location = new System.Drawing.Point(348, 535);
            this.checkbx_showPassword.Margin = new System.Windows.Forms.Padding(2);
            this.checkbx_showPassword.Name = "checkbx_showPassword";
            this.checkbx_showPassword.Size = new System.Drawing.Size(160, 22);
            this.checkbx_showPassword.TabIndex = 20;
            this.checkbx_showPassword.Text = "Mostrar contraseña";
            this.checkbx_showPassword.UseVisualStyleBackColor = true;
            this.checkbx_showPassword.Click += new System.EventHandler(this.checkbx_showPassword_CheckedChanged);
            // 
            // tbx_Username
            // 
            this.tbx_Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Username.Location = new System.Drawing.Point(348, 421);
            this.tbx_Username.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_Username.Name = "tbx_Username";
            this.tbx_Username.Size = new System.Drawing.Size(293, 32);
            this.tbx_Username.TabIndex = 17;
            // 
            // tbx_Password
            // 
            this.tbx_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Password.Location = new System.Drawing.Point(348, 501);
            this.tbx_Password.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_Password.Name = "tbx_Password";
            this.tbx_Password.PasswordChar = '●';
            this.tbx_Password.Size = new System.Drawing.Size(293, 32);
            this.tbx_Password.TabIndex = 18;
            // 
            // btn_Ingresar
            // 
            this.btn_Ingresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.btn_Ingresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Ingresar.FlatAppearance.BorderSize = 0;
            this.btn_Ingresar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.btn_Ingresar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.btn_Ingresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Ingresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Ingresar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Ingresar.Location = new System.Drawing.Point(866, 647);
            this.btn_Ingresar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Ingresar.Name = "btn_Ingresar";
            this.btn_Ingresar.Size = new System.Drawing.Size(144, 44);
            this.btn_Ingresar.TabIndex = 21;
            this.btn_Ingresar.Text = "Ingresar";
            this.btn_Ingresar.UseVisualStyleBackColor = false;
            this.btn_Ingresar.Click += new System.EventHandler(this.btn_Ingresar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(343, 471);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 24);
            this.label4.TabIndex = 19;
            this.label4.Text = "Contraseña";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(343, 391);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 24);
            this.label3.TabIndex = 16;
            this.label3.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(266, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(329, 52);
            this.label2.TabIndex = 15;
            this.label2.Text = "Registro Admin";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            this.iconPictureBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Key;
            this.iconPictureBox2.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 35;
            this.iconPictureBox2.Location = new System.Drawing.Point(312, 500);
            this.iconPictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(35, 35);
            this.iconPictureBox2.TabIndex = 24;
            this.iconPictureBox2.TabStop = false;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            this.iconPictureBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            this.iconPictureBox1.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconPictureBox1.IconSize = 35;
            this.iconPictureBox1.Location = new System.Drawing.Point(312, 419);
            this.iconPictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(35, 35);
            this.iconPictureBox1.TabIndex = 23;
            this.iconPictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ibtn_Minimized_LogIn);
            this.panel2.Controls.Add(this.ibtn_Exit_LogIn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(291, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(764, 40);
            this.panel2.TabIndex = 25;
            // 
            // ibtn_Minimized_LogIn
            // 
            this.ibtn_Minimized_LogIn.Dock = System.Windows.Forms.DockStyle.Right;
            this.ibtn_Minimized_LogIn.FlatAppearance.BorderSize = 0;
            this.ibtn_Minimized_LogIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_Minimized_LogIn.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.ibtn_Minimized_LogIn.IconColor = System.Drawing.Color.Black;
            this.ibtn_Minimized_LogIn.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.ibtn_Minimized_LogIn.IconSize = 22;
            this.ibtn_Minimized_LogIn.Location = new System.Drawing.Point(674, 0);
            this.ibtn_Minimized_LogIn.Margin = new System.Windows.Forms.Padding(2);
            this.ibtn_Minimized_LogIn.Name = "ibtn_Minimized_LogIn";
            this.ibtn_Minimized_LogIn.Size = new System.Drawing.Size(45, 40);
            this.ibtn_Minimized_LogIn.TabIndex = 11;
            this.ibtn_Minimized_LogIn.UseVisualStyleBackColor = true;
            this.ibtn_Minimized_LogIn.Click += new System.EventHandler(this.ibtn_Minimized_LogIn_Click);
            // 
            // ibtn_Exit_LogIn
            // 
            this.ibtn_Exit_LogIn.Dock = System.Windows.Forms.DockStyle.Right;
            this.ibtn_Exit_LogIn.FlatAppearance.BorderSize = 0;
            this.ibtn_Exit_LogIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_Exit_LogIn.IconChar = FontAwesome.Sharp.IconChar.X;
            this.ibtn_Exit_LogIn.IconColor = System.Drawing.Color.Black;
            this.ibtn_Exit_LogIn.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.ibtn_Exit_LogIn.IconSize = 22;
            this.ibtn_Exit_LogIn.Location = new System.Drawing.Point(719, 0);
            this.ibtn_Exit_LogIn.Margin = new System.Windows.Forms.Padding(2);
            this.ibtn_Exit_LogIn.Name = "ibtn_Exit_LogIn";
            this.ibtn_Exit_LogIn.Size = new System.Drawing.Size(45, 40);
            this.ibtn_Exit_LogIn.TabIndex = 10;
            this.ibtn_Exit_LogIn.UseVisualStyleBackColor = true;
            this.ibtn_Exit_LogIn.Click += new System.EventHandler(this.ibtn_Exit_LogIn_Click);
            // 
            // checkbx2_showPassword
            // 
            this.checkbx2_showPassword.AutoSize = true;
            this.checkbx2_showPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkbx2_showPassword.Location = new System.Drawing.Point(717, 535);
            this.checkbx2_showPassword.Margin = new System.Windows.Forms.Padding(2);
            this.checkbx2_showPassword.Name = "checkbx2_showPassword";
            this.checkbx2_showPassword.Size = new System.Drawing.Size(160, 22);
            this.checkbx2_showPassword.TabIndex = 28;
            this.checkbx2_showPassword.Text = "Mostrar contraseña";
            this.checkbx2_showPassword.UseVisualStyleBackColor = true;
            this.checkbx2_showPassword.Click += new System.EventHandler(this.checkbx2_showPassword_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(717, 501);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '●';
            this.textBox1.Size = new System.Drawing.Size(293, 32);
            this.textBox1.TabIndex = 26;
            // 
            // iconPictureBox3
            // 
            this.iconPictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            this.iconPictureBox3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.Key;
            this.iconPictureBox3.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox3.IconSize = 35;
            this.iconPictureBox3.Location = new System.Drawing.Point(681, 500);
            this.iconPictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.iconPictureBox3.Name = "iconPictureBox3";
            this.iconPictureBox3.Size = new System.Drawing.Size(35, 35);
            this.iconPictureBox3.TabIndex = 29;
            this.iconPictureBox3.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(712, 471);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(194, 24);
            this.label6.TabIndex = 27;
            this.label6.Text = "Confirmar contaseña";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(345, 149);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(293, 32);
            this.textBox2.TabIndex = 31;
            // 
            // iconPictureBox4
            // 
            this.iconPictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            this.iconPictureBox4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.FileSignature;
            this.iconPictureBox4.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox4.IconSize = 35;
            this.iconPictureBox4.Location = new System.Drawing.Point(309, 147);
            this.iconPictureBox4.Margin = new System.Windows.Forms.Padding(4);
            this.iconPictureBox4.Name = "iconPictureBox4";
            this.iconPictureBox4.Size = new System.Drawing.Size(35, 35);
            this.iconPictureBox4.TabIndex = 32;
            this.iconPictureBox4.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(340, 119);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 24);
            this.label1.TabIndex = 30;
            this.label1.Text = "Nombre";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(717, 149);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(293, 32);
            this.textBox3.TabIndex = 34;
            // 
            // iconPictureBox5
            // 
            this.iconPictureBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            this.iconPictureBox5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox5.IconChar = FontAwesome.Sharp.IconChar.FileSignature;
            this.iconPictureBox5.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox5.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox5.IconSize = 35;
            this.iconPictureBox5.Location = new System.Drawing.Point(681, 147);
            this.iconPictureBox5.Margin = new System.Windows.Forms.Padding(4);
            this.iconPictureBox5.Name = "iconPictureBox5";
            this.iconPictureBox5.Size = new System.Drawing.Size(35, 35);
            this.iconPictureBox5.TabIndex = 35;
            this.iconPictureBox5.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(712, 119);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 24);
            this.label7.TabIndex = 33;
            this.label7.Text = "Apellido";
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(717, 235);
            this.textBox4.Margin = new System.Windows.Forms.Padding(2);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(293, 32);
            this.textBox4.TabIndex = 40;
            // 
            // iconPictureBox6
            // 
            this.iconPictureBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            this.iconPictureBox6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox6.IconChar = FontAwesome.Sharp.IconChar.IdCard;
            this.iconPictureBox6.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox6.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconPictureBox6.IconSize = 35;
            this.iconPictureBox6.Location = new System.Drawing.Point(681, 233);
            this.iconPictureBox6.Margin = new System.Windows.Forms.Padding(4);
            this.iconPictureBox6.Name = "iconPictureBox6";
            this.iconPictureBox6.Size = new System.Drawing.Size(35, 35);
            this.iconPictureBox6.TabIndex = 41;
            this.iconPictureBox6.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(712, 205);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 24);
            this.label8.TabIndex = 39;
            this.label8.Text = "N° documento";
            // 
            // iconPictureBox7
            // 
            this.iconPictureBox7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            this.iconPictureBox7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox7.IconChar = FontAwesome.Sharp.IconChar.IdCard;
            this.iconPictureBox7.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox7.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconPictureBox7.IconSize = 35;
            this.iconPictureBox7.Location = new System.Drawing.Point(309, 233);
            this.iconPictureBox7.Margin = new System.Windows.Forms.Padding(4);
            this.iconPictureBox7.Name = "iconPictureBox7";
            this.iconPictureBox7.Size = new System.Drawing.Size(35, 35);
            this.iconPictureBox7.TabIndex = 38;
            this.iconPictureBox7.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(340, 205);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(182, 24);
            this.label9.TabIndex = 36;
            this.label9.Text = "Tipo de documento";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(345, 233);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(293, 34);
            this.comboBox1.TabIndex = 42;
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(717, 323);
            this.textBox5.Margin = new System.Windows.Forms.Padding(2);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(293, 30);
            this.textBox5.TabIndex = 47;
            this.textBox5.Text = "Administrador";
            // 
            // iconPictureBox8
            // 
            this.iconPictureBox8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            this.iconPictureBox8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox8.IconChar = FontAwesome.Sharp.IconChar.Dice;
            this.iconPictureBox8.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox8.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox8.IconSize = 35;
            this.iconPictureBox8.Location = new System.Drawing.Point(681, 321);
            this.iconPictureBox8.Margin = new System.Windows.Forms.Padding(4);
            this.iconPictureBox8.Name = "iconPictureBox8";
            this.iconPictureBox8.Size = new System.Drawing.Size(35, 35);
            this.iconPictureBox8.TabIndex = 48;
            this.iconPictureBox8.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(712, 293);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 24);
            this.label10.TabIndex = 46;
            this.label10.Text = "Rol";
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(345, 323);
            this.textBox6.Margin = new System.Windows.Forms.Padding(2);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(293, 32);
            this.textBox6.TabIndex = 44;
            // 
            // iconPictureBox9
            // 
            this.iconPictureBox9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            this.iconPictureBox9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox9.IconChar = FontAwesome.Sharp.IconChar.Phone;
            this.iconPictureBox9.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox9.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox9.IconSize = 35;
            this.iconPictureBox9.Location = new System.Drawing.Point(309, 321);
            this.iconPictureBox9.Margin = new System.Windows.Forms.Padding(4);
            this.iconPictureBox9.Name = "iconPictureBox9";
            this.iconPictureBox9.Size = new System.Drawing.Size(35, 35);
            this.iconPictureBox9.TabIndex = 45;
            this.iconPictureBox9.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(340, 293);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 24);
            this.label11.TabIndex = 43;
            this.label11.Text = "Telefono";
            // 
            // Frm_RegisterAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(1055, 710);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.iconPictureBox8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.iconPictureBox9);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.iconPictureBox6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.iconPictureBox7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.iconPictureBox5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.iconPictureBox4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkbx2_showPassword);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.iconPictureBox3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkbx_showPassword);
            this.Controls.Add(this.tbx_Username);
            this.Controls.Add(this.tbx_Password);
            this.Controls.Add(this.iconPictureBox2);
            this.Controls.Add(this.iconPictureBox1);
            this.Controls.Add(this.btn_Ingresar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_RegisterAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_RegisterAdmin";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox9)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkbx_showPassword;
        private System.Windows.Forms.TextBox tbx_Username;
        private System.Windows.Forms.TextBox tbx_Password;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Button btn_Ingresar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton ibtn_Minimized_LogIn;
        private FontAwesome.Sharp.IconButton ibtn_Exit_LogIn;
        private System.Windows.Forms.Label lbl_SignIn;
        private System.Windows.Forms.CheckBox checkbx2_showPassword;
        private System.Windows.Forms.TextBox textBox1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox3;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox4;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox6;
        private System.Windows.Forms.Label label8;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox5;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox6;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox9;
        private System.Windows.Forms.Label label11;
    }
}