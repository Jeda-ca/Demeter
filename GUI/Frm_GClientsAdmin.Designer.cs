namespace GUI
{
    partial class Frm_GClientsAdmin
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
            this.ibtn_Buscar = new FontAwesome.Sharp.IconButton();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.ibtn_ModifyInfo = new FontAwesome.Sharp.IconButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ibtn_Delete = new FontAwesome.Sharp.IconButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_ListaClientes = new System.Windows.Forms.DataGridView();
            this.tbx_Busqueda = new System.Windows.Forms.TextBox();
            this.cbx_Buscar = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListaClientes)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // ibtn_ModifyInfo
            // 
            this.ibtn_ModifyInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_ModifyInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtn_ModifyInfo.FlatAppearance.BorderSize = 0;
            this.ibtn_ModifyInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.ibtn_ModifyInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_ModifyInfo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.ibtn_ModifyInfo.ForeColor = System.Drawing.Color.White;
            this.ibtn_ModifyInfo.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.ibtn_ModifyInfo.IconColor = System.Drawing.Color.White;
            this.ibtn_ModifyInfo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_ModifyInfo.IconSize = 33;
            this.ibtn_ModifyInfo.Location = new System.Drawing.Point(16, 44);
            this.ibtn_ModifyInfo.Margin = new System.Windows.Forms.Padding(2);
            this.ibtn_ModifyInfo.Name = "ibtn_ModifyInfo";
            this.ibtn_ModifyInfo.Size = new System.Drawing.Size(167, 67);
            this.ibtn_ModifyInfo.TabIndex = 7;
            this.ibtn_ModifyInfo.Text = " Modificar información";
            this.ibtn_ModifyInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtn_ModifyInfo.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(798, 30);
            this.label3.TabIndex = 0;
            this.label3.Text = "Controles de gestión";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.panel2.Controls.Add(this.ibtn_Delete);
            this.panel2.Controls.Add(this.ibtn_ModifyInfo);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(32, 345);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(798, 164);
            this.panel2.TabIndex = 9;
            // 
            // ibtn_Delete
            // 
            this.ibtn_Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.ibtn_Delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ibtn_Delete.FlatAppearance.BorderSize = 0;
            this.ibtn_Delete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            this.ibtn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_Delete.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.ibtn_Delete.ForeColor = System.Drawing.Color.White;
            this.ibtn_Delete.IconChar = FontAwesome.Sharp.IconChar.CircleXmark;
            this.ibtn_Delete.IconColor = System.Drawing.Color.White;
            this.ibtn_Delete.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.ibtn_Delete.IconSize = 33;
            this.ibtn_Delete.Location = new System.Drawing.Point(316, 44);
            this.ibtn_Delete.Margin = new System.Windows.Forms.Padding(2);
            this.ibtn_Delete.Name = "ibtn_Delete";
            this.ibtn_Delete.Size = new System.Drawing.Size(167, 67);
            this.ibtn_Delete.TabIndex = 8;
            this.ibtn_Delete.Text = " Eliminar";
            this.ibtn_Delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ibtn_Delete.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label5.Location = new System.Drawing.Point(13, 239);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(769, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Si no se encuentra el cliente que necesita, lo más seguro es que no se encuentra " +
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
            this.label4.Size = new System.Drawing.Size(116, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Lista de clientes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label2.Location = new System.Drawing.Point(6, -1);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Consultar cliente";
            // 
            // dgv_ListaClientes
            // 
            this.dgv_ListaClientes.AllowUserToAddRows = false;
            this.dgv_ListaClientes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgv_ListaClientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ListaClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_ListaClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ListaClientes.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgv_ListaClientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_ListaClientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_ListaClientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(54)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ListaClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_ListaClientes.ColumnHeadersHeight = 30;
            this.dgv_ListaClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(203)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ListaClientes.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_ListaClientes.EnableHeadersVisualStyles = false;
            this.dgv_ListaClientes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(82)))), ((int)(((byte)(72)))));
            this.dgv_ListaClientes.Location = new System.Drawing.Point(16, 122);
            this.dgv_ListaClientes.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_ListaClientes.Name = "dgv_ListaClientes";
            this.dgv_ListaClientes.ReadOnly = true;
            this.dgv_ListaClientes.RowHeadersVisible = false;
            this.dgv_ListaClientes.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(203)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.dgv_ListaClientes.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_ListaClientes.RowTemplate.Height = 24;
            this.dgv_ListaClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ListaClientes.Size = new System.Drawing.Size(766, 101);
            this.dgv_ListaClientes.TabIndex = 2;
            // 
            // tbx_Busqueda
            // 
            this.tbx_Busqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_Busqueda.Font = new System.Drawing.Font("Tahoma", 12F);
            this.tbx_Busqueda.Location = new System.Drawing.Point(235, 50);
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
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.ibtn_Buscar);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dgv_ListaClientes);
            this.panel1.Controls.Add(this.tbx_Busqueda);
            this.panel1.Controls.Add(this.cbx_Buscar);
            this.panel1.Location = new System.Drawing.Point(32, 55);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 270);
            this.panel1.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label6.Location = new System.Drawing.Point(13, 30);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 14);
            this.label6.TabIndex = 8;
            this.label6.Text = "Buscar por:";
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
            this.label1.TabIndex = 7;
            this.label1.Text = "  Gestor de Clientes";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // Frm_GClientsAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(866, 521);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Frm_GClientsAdmin";
            this.Text = "Frm_GClientsAdmin";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListaClientes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton ibtn_Buscar;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton ibtn_Delete;
        private FontAwesome.Sharp.IconButton ibtn_ModifyInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_ListaClientes;
        private System.Windows.Forms.TextBox tbx_Busqueda;
        private System.Windows.Forms.ComboBox cbx_Buscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
    }
}