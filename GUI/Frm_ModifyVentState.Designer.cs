namespace GUI
{
    partial class Frm_ModifyVentState
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ModifyVentState));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbx_Date = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_Code = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_TotVent = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbx_VentState = new System.Windows.Forms.ComboBox();
            this.ibtn_Modify = new FontAwesome.Sharp.IconButton();
            this.ibtn_Cancel = new FontAwesome.Sharp.IconButton();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.groupBox3.Controls.Add(this.cbx_VentState);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.groupBox3.Location = new System.Drawing.Point(23, 192);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(341, 133);
            this.groupBox3.TabIndex = 53;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Estado de venta";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(800, 49);
            this.label1.TabIndex = 51;
            this.label1.Text = "Modificar Estado de venta";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(221)))));
            this.groupBox1.Controls.Add(this.tbx_TotVent);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbx_Code);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbx_Date);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(60)))), ((int)(((byte)(48)))));
            this.groupBox1.Location = new System.Drawing.Point(23, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(755, 122);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información de la venta";
            // 
            // tbx_Date
            // 
            this.tbx_Date.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Date.Location = new System.Drawing.Point(34, 65);
            this.tbx_Date.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_Date.Name = "tbx_Date";
            this.tbx_Date.ReadOnly = true;
            this.tbx_Date.Size = new System.Drawing.Size(225, 30);
            this.tbx_Date.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 28);
            this.label2.TabIndex = 17;
            this.label2.Text = "Fecha";
            // 
            // tbx_Code
            // 
            this.tbx_Code.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Code.Location = new System.Drawing.Point(273, 65);
            this.tbx_Code.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_Code.Name = "tbx_Code";
            this.tbx_Code.ReadOnly = true;
            this.tbx_Code.Size = new System.Drawing.Size(225, 30);
            this.tbx_Code.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(269, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(231, 28);
            this.label3.TabIndex = 19;
            this.label3.Text = "Código";
            // 
            // tbx_TotVent
            // 
            this.tbx_TotVent.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_TotVent.Location = new System.Drawing.Point(512, 65);
            this.tbx_TotVent.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_TotVent.Name = "tbx_TotVent";
            this.tbx_TotVent.ReadOnly = true;
            this.tbx_TotVent.Size = new System.Drawing.Size(225, 30);
            this.tbx_TotVent.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(508, 33);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(231, 28);
            this.label4.TabIndex = 21;
            this.label4.Text = "Total venta";
            // 
            // cbx_VentState
            // 
            this.cbx_VentState.FormattingEnabled = true;
            this.cbx_VentState.Location = new System.Drawing.Point(34, 60);
            this.cbx_VentState.Name = "cbx_VentState";
            this.cbx_VentState.Size = new System.Drawing.Size(258, 32);
            this.cbx_VentState.TabIndex = 0;
            // 
            // ibtn_Modify
            // 
            this.ibtn_Modify.BackColor = System.Drawing.Color.Teal;
            this.ibtn_Modify.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ibtn_Modify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_Modify.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.ibtn_Modify.ForeColor = System.Drawing.SystemColors.Control;
            this.ibtn_Modify.IconChar = FontAwesome.Sharp.IconChar.None;
            this.ibtn_Modify.IconColor = System.Drawing.Color.Black;
            this.ibtn_Modify.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_Modify.Location = new System.Drawing.Point(425, 252);
            this.ibtn_Modify.Margin = new System.Windows.Forms.Padding(4);
            this.ibtn_Modify.Name = "ibtn_Modify";
            this.ibtn_Modify.Size = new System.Drawing.Size(155, 73);
            this.ibtn_Modify.TabIndex = 42;
            this.ibtn_Modify.Text = "Guardar cambios";
            this.ibtn_Modify.UseVisualStyleBackColor = false;
            // 
            // ibtn_Cancel
            // 
            this.ibtn_Cancel.BackColor = System.Drawing.Color.Teal;
            this.ibtn_Cancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ibtn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ibtn_Cancel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.ibtn_Cancel.ForeColor = System.Drawing.SystemColors.Control;
            this.ibtn_Cancel.IconChar = FontAwesome.Sharp.IconChar.None;
            this.ibtn_Cancel.IconColor = System.Drawing.Color.Black;
            this.ibtn_Cancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtn_Cancel.Location = new System.Drawing.Point(623, 252);
            this.ibtn_Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.ibtn_Cancel.Name = "ibtn_Cancel";
            this.ibtn_Cancel.Size = new System.Drawing.Size(155, 73);
            this.ibtn_Cancel.TabIndex = 44;
            this.ibtn_Cancel.Text = "Cancelar";
            this.ibtn_Cancel.UseVisualStyleBackColor = false;
            // 
            // Frm_ModifyVentState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(800, 346);
            this.Controls.Add(this.ibtn_Modify);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ibtn_Cancel);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_ModifyVentState";
            this.Text = "Frm_ModifyVentState";
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private FontAwesome.Sharp.IconButton ibtn_Modify;
        private FontAwesome.Sharp.IconButton ibtn_Cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbx_Date;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbx_TotVent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbx_Code;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbx_VentState;
    }
}