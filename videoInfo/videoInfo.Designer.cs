namespace videoInfo
{
    partial class videoInfo
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(videoInfo));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnConfigurar = new System.Windows.Forms.Button();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.panelGeneral = new System.Windows.Forms.Panel();
            this.btnRegenerarTexto = new System.Windows.Forms.Button();
            this.btnCopiar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.rTxtInforme = new System.Windows.Forms.RichTextBox();
            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.lblAbrirArrastrar = new System.Windows.Forms.Label();
            this.lblC1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblC2 = new System.Windows.Forms.Label();
            this.lblCGeneral = new System.Windows.Forms.Label();
            this.lblGeneral = new System.Windows.Forms.Label();
            this.lblVBitRate = new System.Windows.Forms.Label();
            this.lblCBitRate = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblVAspectRatio = new System.Windows.Forms.Label();
            this.lblCAspectRatio = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblBitRate = new System.Windows.Forms.Label();
            this.lblVPeso = new System.Windows.Forms.Label();
            this.lblVFrameRate = new System.Windows.Forms.Label();
            this.lblVDimensiones = new System.Windows.Forms.Label();
            this.lblVDuracion = new System.Windows.Forms.Label();
            this.lblVDireccion = new System.Windows.Forms.Label();
            this.lblVNombre = new System.Windows.Forms.Label();
            this.lblCPeso = new System.Windows.Forms.Label();
            this.lblCFrameRate = new System.Windows.Forms.Label();
            this.lblCDimensiones = new System.Windows.Forms.Label();
            this.lblCDuracion = new System.Windows.Forms.Label();
            this.lblCDireccion = new System.Windows.Forms.Label();
            this.lblCNombre = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDivisor = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDimension = new System.Windows.Forms.Label();
            this.lblDuracion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panelGeneral.SuspendLayout();
            this.grpDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(588, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirVideoToolStripMenuItem,
            this.cerrarToolStripMenuItem});
            this.archivoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // abrirVideoToolStripMenuItem
            // 
            this.abrirVideoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("abrirVideoToolStripMenuItem.Image")));
            this.abrirVideoToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.abrirVideoToolStripMenuItem.Name = "abrirVideoToolStripMenuItem";
            this.abrirVideoToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.abrirVideoToolStripMenuItem.Text = "Abrir Video";
            this.abrirVideoToolStripMenuItem.Click += new System.EventHandler(this.abrirVideoToolStripMenuItem_Click);
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cerrarToolStripMenuItem.Image")));
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.cerrarToolStripMenuItem.Text = "Cerrar";
            this.cerrarToolStripMenuItem.Click += new System.EventHandler(this.cerrarToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // acercaToolStripMenuItem
            // 
            this.acercaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("acercaToolStripMenuItem.Image")));
            this.acercaToolStripMenuItem.Name = "acercaToolStripMenuItem";
            this.acercaToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.acercaToolStripMenuItem.Text = "Acerca de Calidad de Video";
            this.acercaToolStripMenuItem.Click += new System.EventHandler(this.acercaToolStripMenuItem_Click);
            // 
            // btnConfigurar
            // 
            this.btnConfigurar.Image = ((System.Drawing.Image)(resources.GetObject("btnConfigurar.Image")));
            this.btnConfigurar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfigurar.Location = new System.Drawing.Point(479, 6);
            this.btnConfigurar.Name = "btnConfigurar";
            this.btnConfigurar.Size = new System.Drawing.Size(97, 37);
            this.btnConfigurar.TabIndex = 8;
            this.btnConfigurar.Text = "Configurar";
            this.btnConfigurar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfigurar.UseVisualStyleBackColor = true;
            this.btnConfigurar.Click += new System.EventHandler(this.btnConfigurar_Click);
            // 
            // btnAbrir
            // 
            this.btnAbrir.Image = ((System.Drawing.Image)(resources.GetObject("btnAbrir.Image")));
            this.btnAbrir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbrir.Location = new System.Drawing.Point(230, 6);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(100, 37);
            this.btnAbrir.TabIndex = 0;
            this.btnAbrir.Text = "Abrir Video";
            this.btnAbrir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // panelGeneral
            // 
            this.panelGeneral.Controls.Add(this.btnRegenerarTexto);
            this.panelGeneral.Controls.Add(this.btnCopiar);
            this.panelGeneral.Controls.Add(this.label10);
            this.panelGeneral.Controls.Add(this.rTxtInforme);
            this.panelGeneral.Controls.Add(this.grpDatos);
            this.panelGeneral.Controls.Add(this.btnAbrir);
            this.panelGeneral.Controls.Add(this.btnConfigurar);
            this.panelGeneral.Location = new System.Drawing.Point(0, 27);
            this.panelGeneral.Name = "panelGeneral";
            this.panelGeneral.Size = new System.Drawing.Size(588, 396);
            this.panelGeneral.TabIndex = 12;
            this.panelGeneral.DragLeave += new System.EventHandler(this.panelGeneral_DragLeave);
            this.panelGeneral.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGeneral_Paint);
            // 
            // btnRegenerarTexto
            // 
            this.btnRegenerarTexto.Image = ((System.Drawing.Image)(resources.GetObject("btnRegenerarTexto.Image")));
            this.btnRegenerarTexto.Location = new System.Drawing.Point(12, 312);
            this.btnRegenerarTexto.Name = "btnRegenerarTexto";
            this.btnRegenerarTexto.Size = new System.Drawing.Size(76, 67);
            this.btnRegenerarTexto.TabIndex = 13;
            this.btnRegenerarTexto.Text = "Recargar";
            this.btnRegenerarTexto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRegenerarTexto.UseVisualStyleBackColor = true;
            this.btnRegenerarTexto.Click += new System.EventHandler(this.btnRegenerarTexto_Click_1);
            // 
            // btnCopiar
            // 
            this.btnCopiar.Image = global::videoInfo.Properties.Resources.portapapeles;
            this.btnCopiar.Location = new System.Drawing.Point(502, 314);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(75, 65);
            this.btnCopiar.TabIndex = 12;
            this.btnCopiar.Text = "Copiar Texto";
            this.btnCopiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCopiar.UseVisualStyleBackColor = true;
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click_1);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(101, 296);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Pre Informe:";
            // 
            // rTxtInforme
            // 
            this.rTxtInforme.Location = new System.Drawing.Point(94, 312);
            this.rTxtInforme.Name = "rTxtInforme";
            this.rTxtInforme.Size = new System.Drawing.Size(402, 67);
            this.rTxtInforme.TabIndex = 10;
            this.rTxtInforme.Text = "";
            // 
            // grpDatos
            // 
            this.grpDatos.BackColor = System.Drawing.SystemColors.MenuBar;
            this.grpDatos.Controls.Add(this.lblAbrirArrastrar);
            this.grpDatos.Controls.Add(this.lblC1);
            this.grpDatos.Controls.Add(this.label12);
            this.grpDatos.Controls.Add(this.lblC2);
            this.grpDatos.Controls.Add(this.lblCGeneral);
            this.grpDatos.Controls.Add(this.lblGeneral);
            this.grpDatos.Controls.Add(this.lblVBitRate);
            this.grpDatos.Controls.Add(this.lblCBitRate);
            this.grpDatos.Controls.Add(this.label17);
            this.grpDatos.Controls.Add(this.label18);
            this.grpDatos.Controls.Add(this.lblVAspectRatio);
            this.grpDatos.Controls.Add(this.lblCAspectRatio);
            this.grpDatos.Controls.Add(this.label13);
            this.grpDatos.Controls.Add(this.lblBitRate);
            this.grpDatos.Controls.Add(this.lblVPeso);
            this.grpDatos.Controls.Add(this.lblVFrameRate);
            this.grpDatos.Controls.Add(this.lblVDimensiones);
            this.grpDatos.Controls.Add(this.lblVDuracion);
            this.grpDatos.Controls.Add(this.lblVDireccion);
            this.grpDatos.Controls.Add(this.lblVNombre);
            this.grpDatos.Controls.Add(this.lblCPeso);
            this.grpDatos.Controls.Add(this.lblCFrameRate);
            this.grpDatos.Controls.Add(this.lblCDimensiones);
            this.grpDatos.Controls.Add(this.lblCDuracion);
            this.grpDatos.Controls.Add(this.lblCDireccion);
            this.grpDatos.Controls.Add(this.lblCNombre);
            this.grpDatos.Controls.Add(this.label9);
            this.grpDatos.Controls.Add(this.label8);
            this.grpDatos.Controls.Add(this.label7);
            this.grpDatos.Controls.Add(this.label6);
            this.grpDatos.Controls.Add(this.label3);
            this.grpDatos.Controls.Add(this.lblDivisor);
            this.grpDatos.Controls.Add(this.label4);
            this.grpDatos.Controls.Add(this.label5);
            this.grpDatos.Controls.Add(this.lblDimension);
            this.grpDatos.Controls.Add(this.lblDuracion);
            this.grpDatos.Controls.Add(this.label2);
            this.grpDatos.Controls.Add(this.lblNombre);
            this.grpDatos.Location = new System.Drawing.Point(11, 45);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Size = new System.Drawing.Size(565, 244);
            this.grpDatos.TabIndex = 9;
            this.grpDatos.TabStop = false;
            this.grpDatos.Text = "Info de Video";
            // 
            // lblAbrirArrastrar
            // 
            this.lblAbrirArrastrar.AutoSize = true;
            this.lblAbrirArrastrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbrirArrastrar.Location = new System.Drawing.Point(57, 108);
            this.lblAbrirArrastrar.Name = "lblAbrirArrastrar";
            this.lblAbrirArrastrar.Size = new System.Drawing.Size(468, 31);
            this.lblAbrirArrastrar.TabIndex = 9;
            this.lblAbrirArrastrar.Text = "Abrir o Arrastrar archivo de video aqui";
            // 
            // lblC1
            // 
            this.lblC1.AutoSize = true;
            this.lblC1.Location = new System.Drawing.Point(436, 123);
            this.lblC1.Name = "lblC1";
            this.lblC1.Size = new System.Drawing.Size(45, 13);
            this.lblC1.TabIndex = 48;
            this.lblC1.Text = "Calidad:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(436, 168);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 47;
            this.label12.Text = "Calidad:";
            // 
            // lblC2
            // 
            this.lblC2.AutoSize = true;
            this.lblC2.Location = new System.Drawing.Point(436, 146);
            this.lblC2.Name = "lblC2";
            this.lblC2.Size = new System.Drawing.Size(45, 13);
            this.lblC2.TabIndex = 6;
            this.lblC2.Text = "Calidad:";
            // 
            // lblCGeneral
            // 
            this.lblCGeneral.AutoSize = true;
            this.lblCGeneral.Location = new System.Drawing.Point(487, 220);
            this.lblCGeneral.Name = "lblCGeneral";
            this.lblCGeneral.Size = new System.Drawing.Size(10, 13);
            this.lblCGeneral.TabIndex = 46;
            this.lblCGeneral.Text = "-";
            // 
            // lblGeneral
            // 
            this.lblGeneral.AutoSize = true;
            this.lblGeneral.Location = new System.Drawing.Point(389, 220);
            this.lblGeneral.Name = "lblGeneral";
            this.lblGeneral.Size = new System.Drawing.Size(92, 13);
            this.lblGeneral.TabIndex = 45;
            this.lblGeneral.Text = "Calidad Promedio:";
            // 
            // lblVBitRate
            // 
            this.lblVBitRate.AutoSize = true;
            this.lblVBitRate.Location = new System.Drawing.Point(161, 146);
            this.lblVBitRate.Name = "lblVBitRate";
            this.lblVBitRate.Size = new System.Drawing.Size(10, 13);
            this.lblVBitRate.TabIndex = 44;
            this.lblVBitRate.Text = "-";
            // 
            // lblCBitRate
            // 
            this.lblCBitRate.AutoSize = true;
            this.lblCBitRate.Location = new System.Drawing.Point(487, 146);
            this.lblCBitRate.Name = "lblCBitRate";
            this.lblCBitRate.Size = new System.Drawing.Size(10, 13);
            this.lblCBitRate.TabIndex = 43;
            this.lblCBitRate.Text = "-";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(140, 146);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(13, 13);
            this.label17.TabIndex = 42;
            this.label17.Text = "=";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(20, 146);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(69, 13);
            this.label18.TabIndex = 41;
            this.label18.Text = "Taza de Bits:";
            // 
            // lblVAspectRatio
            // 
            this.lblVAspectRatio.AutoSize = true;
            this.lblVAspectRatio.Location = new System.Drawing.Point(161, 101);
            this.lblVAspectRatio.Name = "lblVAspectRatio";
            this.lblVAspectRatio.Size = new System.Drawing.Size(10, 13);
            this.lblVAspectRatio.TabIndex = 40;
            this.lblVAspectRatio.Text = "-";
            // 
            // lblCAspectRatio
            // 
            this.lblCAspectRatio.AutoSize = true;
            this.lblCAspectRatio.Location = new System.Drawing.Point(487, 101);
            this.lblCAspectRatio.Name = "lblCAspectRatio";
            this.lblCAspectRatio.Size = new System.Drawing.Size(0, 13);
            this.lblCAspectRatio.TabIndex = 39;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(140, 101);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(13, 13);
            this.label13.TabIndex = 38;
            this.label13.Text = "=";
            // 
            // lblBitRate
            // 
            this.lblBitRate.AutoSize = true;
            this.lblBitRate.Location = new System.Drawing.Point(20, 101);
            this.lblBitRate.Name = "lblBitRate";
            this.lblBitRate.Size = new System.Drawing.Size(108, 13);
            this.lblBitRate.TabIndex = 37;
            this.lblBitRate.Text = "Relación de aspecto:";
            // 
            // lblVPeso
            // 
            this.lblVPeso.AutoSize = true;
            this.lblVPeso.Location = new System.Drawing.Point(161, 187);
            this.lblVPeso.Name = "lblVPeso";
            this.lblVPeso.Size = new System.Drawing.Size(10, 13);
            this.lblVPeso.TabIndex = 36;
            this.lblVPeso.Text = "-";
            // 
            // lblVFrameRate
            // 
            this.lblVFrameRate.AutoSize = true;
            this.lblVFrameRate.Location = new System.Drawing.Point(161, 168);
            this.lblVFrameRate.Name = "lblVFrameRate";
            this.lblVFrameRate.Size = new System.Drawing.Size(10, 13);
            this.lblVFrameRate.TabIndex = 35;
            this.lblVFrameRate.Text = "-";
            // 
            // lblVDimensiones
            // 
            this.lblVDimensiones.AutoSize = true;
            this.lblVDimensiones.Location = new System.Drawing.Point(161, 123);
            this.lblVDimensiones.Name = "lblVDimensiones";
            this.lblVDimensiones.Size = new System.Drawing.Size(10, 13);
            this.lblVDimensiones.TabIndex = 34;
            this.lblVDimensiones.Text = "-";
            // 
            // lblVDuracion
            // 
            this.lblVDuracion.AutoSize = true;
            this.lblVDuracion.Location = new System.Drawing.Point(161, 79);
            this.lblVDuracion.Name = "lblVDuracion";
            this.lblVDuracion.Size = new System.Drawing.Size(10, 13);
            this.lblVDuracion.TabIndex = 33;
            this.lblVDuracion.Text = "-";
            // 
            // lblVDireccion
            // 
            this.lblVDireccion.AutoSize = true;
            this.lblVDireccion.Location = new System.Drawing.Point(161, 56);
            this.lblVDireccion.Name = "lblVDireccion";
            this.lblVDireccion.Size = new System.Drawing.Size(10, 13);
            this.lblVDireccion.TabIndex = 32;
            this.lblVDireccion.Text = "-";
            // 
            // lblVNombre
            // 
            this.lblVNombre.AutoSize = true;
            this.lblVNombre.Location = new System.Drawing.Point(161, 33);
            this.lblVNombre.Name = "lblVNombre";
            this.lblVNombre.Size = new System.Drawing.Size(10, 13);
            this.lblVNombre.TabIndex = 31;
            this.lblVNombre.Text = "-";
            // 
            // lblCPeso
            // 
            this.lblCPeso.AutoSize = true;
            this.lblCPeso.Location = new System.Drawing.Point(541, 16);
            this.lblCPeso.Name = "lblCPeso";
            this.lblCPeso.Size = new System.Drawing.Size(10, 13);
            this.lblCPeso.TabIndex = 30;
            this.lblCPeso.Text = "-";
            // 
            // lblCFrameRate
            // 
            this.lblCFrameRate.AutoSize = true;
            this.lblCFrameRate.Location = new System.Drawing.Point(487, 168);
            this.lblCFrameRate.Name = "lblCFrameRate";
            this.lblCFrameRate.Size = new System.Drawing.Size(10, 13);
            this.lblCFrameRate.TabIndex = 29;
            this.lblCFrameRate.Text = "-";
            // 
            // lblCDimensiones
            // 
            this.lblCDimensiones.AutoSize = true;
            this.lblCDimensiones.Location = new System.Drawing.Point(487, 123);
            this.lblCDimensiones.Name = "lblCDimensiones";
            this.lblCDimensiones.Size = new System.Drawing.Size(10, 13);
            this.lblCDimensiones.TabIndex = 28;
            this.lblCDimensiones.Text = "-";
            // 
            // lblCDuracion
            // 
            this.lblCDuracion.AutoSize = true;
            this.lblCDuracion.Location = new System.Drawing.Point(487, 79);
            this.lblCDuracion.Name = "lblCDuracion";
            this.lblCDuracion.Size = new System.Drawing.Size(10, 13);
            this.lblCDuracion.TabIndex = 27;
            this.lblCDuracion.Text = " ";
            // 
            // lblCDireccion
            // 
            this.lblCDireccion.AutoSize = true;
            this.lblCDireccion.Location = new System.Drawing.Point(487, 56);
            this.lblCDireccion.Name = "lblCDireccion";
            this.lblCDireccion.Size = new System.Drawing.Size(10, 13);
            this.lblCDireccion.TabIndex = 26;
            this.lblCDireccion.Text = " ";
            // 
            // lblCNombre
            // 
            this.lblCNombre.AutoSize = true;
            this.lblCNombre.Location = new System.Drawing.Point(487, 33);
            this.lblCNombre.Name = "lblCNombre";
            this.lblCNombre.Size = new System.Drawing.Size(10, 13);
            this.lblCNombre.TabIndex = 25;
            this.lblCNombre.Text = " ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(140, 187);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "=";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(140, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "=";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(140, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "=";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(140, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "=";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(140, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "=";
            // 
            // lblDivisor
            // 
            this.lblDivisor.AutoSize = true;
            this.lblDivisor.Location = new System.Drawing.Point(140, 34);
            this.lblDivisor.Name = "lblDivisor";
            this.lblDivisor.Size = new System.Drawing.Size(13, 13);
            this.lblDivisor.TabIndex = 19;
            this.lblDivisor.Text = "=";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Peso:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Fotogramas/Segundo:";
            // 
            // lblDimension
            // 
            this.lblDimension.AutoSize = true;
            this.lblDimension.Location = new System.Drawing.Point(20, 123);
            this.lblDimension.Name = "lblDimension";
            this.lblDimension.Size = new System.Drawing.Size(70, 13);
            this.lblDimension.TabIndex = 15;
            this.lblDimension.Text = "Dimensiones:";
            // 
            // lblDuracion
            // 
            this.lblDuracion.AutoSize = true;
            this.lblDuracion.Location = new System.Drawing.Point(20, 79);
            this.lblDuracion.Name = "lblDuracion";
            this.lblDuracion.Size = new System.Drawing.Size(53, 13);
            this.lblDuracion.TabIndex = 14;
            this.lblDuracion.Text = "Duracion:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Direccion:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(20, 34);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 12;
            this.lblNombre.Text = "Nombre:";
            // 
            // videoInfo
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 424);
            this.Controls.Add(this.panelGeneral);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "videoInfo";
            this.Text = "Calidad de Video";
            this.Load += new System.EventHandler(this.videoInfo_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.videoInfo_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.videoInfo_DragEnter);
            this.DragLeave += new System.EventHandler(this.videoInfo_DragLeave);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelGeneral.ResumeLayout(false);
            this.panelGeneral.PerformLayout();
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnConfigurar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirVideoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaToolStripMenuItem;
        private System.Windows.Forms.Panel panelGeneral;
        private System.Windows.Forms.Button btnRegenerarTexto;
        private System.Windows.Forms.Button btnCopiar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox rTxtInforme;
        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.Label lblAbrirArrastrar;
        private System.Windows.Forms.Label lblC1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblC2;
        private System.Windows.Forms.Label lblCGeneral;
        private System.Windows.Forms.Label lblGeneral;
        private System.Windows.Forms.Label lblVBitRate;
        private System.Windows.Forms.Label lblCBitRate;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblVAspectRatio;
        private System.Windows.Forms.Label lblCAspectRatio;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblBitRate;
        private System.Windows.Forms.Label lblVPeso;
        private System.Windows.Forms.Label lblVFrameRate;
        private System.Windows.Forms.Label lblVDimensiones;
        private System.Windows.Forms.Label lblVDuracion;
        private System.Windows.Forms.Label lblVDireccion;
        private System.Windows.Forms.Label lblVNombre;
        private System.Windows.Forms.Label lblCPeso;
        private System.Windows.Forms.Label lblCFrameRate;
        private System.Windows.Forms.Label lblCDimensiones;
        private System.Windows.Forms.Label lblCDuracion;
        private System.Windows.Forms.Label lblCDireccion;
        private System.Windows.Forms.Label lblCNombre;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDivisor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDimension;
        private System.Windows.Forms.Label lblDuracion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNombre;
    }
}

