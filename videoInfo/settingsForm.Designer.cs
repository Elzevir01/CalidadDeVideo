namespace videoInfo
{
    partial class settingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settingsForm));
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label50 = new System.Windows.Forms.Label();
            this.txtResolucionV1 = new System.Windows.Forms.TextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label29 = new System.Windows.Forms.Label();
            this.txtFrameRateV1 = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtBitRateV1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rchTextBox = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(335, 274);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 23);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(5, 274);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 23);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(5, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 200);
            this.panel1.TabIndex = 30;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label50);
            this.groupBox3.Controls.Add(this.txtResolucionV1);
            this.groupBox3.Controls.Add(this.label63);
            this.groupBox3.Location = new System.Drawing.Point(3, 135);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(424, 57);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Clasificacion del Video en base a Pixeles de alto";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(193, 30);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(42, 13);
            this.label50.TabIndex = 11;
            this.label50.Text = "px(Alto)";
            // 
            // txtResolucionV1
            // 
            this.txtResolucionV1.Location = new System.Drawing.Point(129, 23);
            this.txtResolucionV1.Name = "txtResolucionV1";
            this.txtResolucionV1.Size = new System.Drawing.Size(59, 20);
            this.txtResolucionV1.TabIndex = 3;
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(18, 30);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(99, 13);
            this.label63.TabIndex = 5;
            this.label63.Text = "Valor de referencia:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label29);
            this.groupBox2.Controls.Add(this.txtFrameRateV1);
            this.groupBox2.Controls.Add(this.label42);
            this.groupBox2.Location = new System.Drawing.Point(3, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(424, 60);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Clasificacion del Video en base a FrameRate";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(193, 30);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(21, 13);
            this.label29.TabIndex = 11;
            this.label29.Text = "fps";
            // 
            // txtFrameRateV1
            // 
            this.txtFrameRateV1.Location = new System.Drawing.Point(129, 23);
            this.txtFrameRateV1.Name = "txtFrameRateV1";
            this.txtFrameRateV1.Size = new System.Drawing.Size(59, 20);
            this.txtFrameRateV1.TabIndex = 3;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(18, 30);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(99, 13);
            this.label42.TabIndex = 5;
            this.label42.Text = "Valor de referencia:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtBitRateV1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 60);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Clasificacion del Video en base a BitRate";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(193, 30);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 11;
            this.label14.Text = "kbp/s";
            // 
            // txtBitRateV1
            // 
            this.txtBitRateV1.Location = new System.Drawing.Point(129, 23);
            this.txtBitRateV1.Name = "txtBitRateV1";
            this.txtBitRateV1.Size = new System.Drawing.Size(59, 20);
            this.txtBitRateV1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Valor de referencia:";
            // 
            // rchTextBox
            // 
            this.rchTextBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.rchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rchTextBox.Location = new System.Drawing.Point(5, 12);
            this.rchTextBox.Name = "rchTextBox";
            this.rchTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rchTextBox.Size = new System.Drawing.Size(427, 47);
            this.rchTextBox.TabIndex = 32;
            this.rchTextBox.Text = resources.GetString("rchTextBox.Text");
            // 
            // settingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 303);
            this.Controls.Add(this.rchTextBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "settingsForm";
            this.Text = "Configuracion de valores de calidad";
            this.Load += new System.EventHandler(this.settingsForm_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.TextBox txtResolucionV1;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtFrameRateV1;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtBitRateV1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rchTextBox;
    }
}