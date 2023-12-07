using System;
using System.IO;
using System.Windows.Forms;
using MediaInfoDotNet;
using NReco.VideoInfo;

using ExtensionMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using videoInfo.Properties;

namespace videoInfo
{
    public partial class videoInfo : Form
    {
        videos vid;
        FFProbe ffProbe;
        string[] archivos;
        string tipoPeso;
        int anchoAlto;
        string preInforme;

        PruebaDeCalidad pr;




        public videoInfo()
        {
            InitializeComponent();

        }

        private void videoInfo_Load(object sender, EventArgs e)
        {
            //iniciar con el contenido invisible
            datosVisibles(false);
            calidadFrameRate(false);
            calidadBitRate(false);
        }

        private void grpDatos_Enter(object sender, EventArgs e)
        {

        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            OpenFileDialogForm();
        }

        private void OpenFileDialogForm()
        {
            try
            {
                //Abrir cuadro de dialogode busqueda de archivo de video
                openFileDialog.Title = "Abrir video";
                openFileDialog.Filter = "Archivos de Video|*.mp4;*.wmv;*.mov;*.mp4;*.flv;*.avi;*.webm;*.mkv;*.f4v;*.dav;*.usm;*.asf";
                openFileDialog.DefaultExt = "video";
                openFileDialog.FileName = "";
                openFileDialog.ShowDialog();

                
                FileInfo fileInfo;

                if (File.Exists(openFileDialog.FileName))
                {
                    fileInfo = new FileInfo(openFileDialog.FileName);
                    VideoInfoO(fileInfo);

                }
               
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }




        private videos VideoInfoO(FileInfo fil)
        {
            //Deshabilitar todos los botones
            habilitarBotones(false);
            this.Cursor = Cursors.WaitCursor;

            try
            {
                //inicializar objeto de la clase videos
                vid = new videos();

                //peso del archivo
                long fileSizeInBytes = fil.Length;

                //MediaInfoDotNet
                var MediaFile = new MediaFile(fil.FullName);
                var fileMediaStr = MediaFile.Video[0];
                //NReco.VideoInfo
                ffProbe = new FFProbe();


                //ingresar datos al objeto videos
                vid.Nombre = fil.Name;
                vid.Direccion = fil.FullName;

                //en algunos formatos mediaInfo no captura el tiempo, en caso de formato USM usar NReco
                if (fileMediaStr.Duration < 1 && ultimosTres(fil.Name) != "usm")
                {
                    var fileNReco = ffProbe.GetMediaInfo(fil.FullName);
                    vid.Duracion = fileNReco.Duration;
                }
                else
                {
                    vid.Duracion = TimeSpan.FromMilliseconds(fileMediaStr.Duration);
                }
                vid.Ancho = fileMediaStr.width;
                vid.Alto = fileMediaStr.height;

                if (fileMediaStr.bitRate == null | fileMediaStr.bitRate == "")
                {

                    vid.BitRate = 0;
                    calidadBitRate(false);
                }
                else
                {
                    vid.BitRate = (Convert.ToInt32(fileMediaStr.bitRate)) / 1000;
                    calidadBitRate(true);

                }
                //si hay bitrate o no
                if (fileMediaStr.frameRate != 0)
                {
                    vid.FrameRate = Convert.ToInt32(fileMediaStr.frameRate);
                    calidadFrameRate(true);
                }
                else
                {
                    /////////////////////////////////////////////////////////////////
                    calidadFrameRate(false);
                }

                //Especificar la escala de peso del archivo MB o KB
                if (fileSizeInBytes > 1048576)
                {
                    tipoPeso = "MB";
                    vid.Peso = (fileSizeInBytes / 1048576);
                }
                else
                {
                    tipoPeso = "KB";
                    vid.Peso = fileSizeInBytes / 1048;
                }
                MostrarInfVideos(vid);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }






            return vid;
        }
        private void MostrarInfVideos(videos vi)
        {
            //si es horizontal o vertical se utilizara 
            if (vi.Alto < vi.Ancho)
                anchoAlto = vi.Alto;
            else
                anchoAlto = vi.Ancho;

            habilitarBotones(false);
            //inicializar clase de PruebaDeCalidad
            pr = new PruebaDeCalidad();

            //Mostrar info de video
            lblVNombre.Text = vi.Nombre;
            lblVDireccion.Text = vi.Direccion;
            var duracion = vi.Duracion.ToString(@"hh\:mm\:ss");
            lblVDuracion.Text = duracion;
            lblVDimensiones.Text = vi.toStringDimension(anchoAlto);
            lblVAspectRatio.Text = vi.Ratio();
            lblVBitRate.Text = Convert.ToString(vi.BitRate) + " kbps";
            lblVFrameRate.Text = Convert.ToString(vi.FrameRate) + " fps";
            lblVPeso.Text = Convert.ToString(vi.Peso) + " " + tipoPeso;

            //Mostrar evaluacion de video
            lblCDimensiones.Text = Convert.ToString(pr.CalidadIndividual(pr.CalidadResolucion(anchoAlto)));
            lblCBitRate.Text = Convert.ToString(pr.CalidadIndividual(pr.CalidadBitRate(vi.BitRate)));
            lblCFrameRate.Text = Convert.ToString(pr.CalidadIndividual(pr.CalidadFrameRate(vi.FrameRate)));

            //Carga el texto de informe
            preInforme = "";
            preInforme = vi.PreInforme(pr.CalidadPromedioDeVideo(vi.BitRate, vi.FrameRate, vi.Alto), anchoAlto);
            lblCGeneral.Text = pr.CalidadPromedioDeVideo(vi.BitRate, vi.FrameRate, vi.Alto);
            rTxtInforme.Clear();
            rTxtInforme.Text = preInforme;

            //habilitar botones y cursor por defecto
            datosVisibles(true);
            habilitarBotones(true);
            this.Cursor = Cursors.Default;
        }

        private void videoInfo_DragDrop(object sender, DragEventArgs e)
        {
            //Cargar datos de video arrastrando el archivo al programa
            archivos = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            var fileInfo = new FileInfo(archivos[0]);

            //*.mp4;*.wmv;*.mov;*.mp4;*.flv;*.avi;*.webm;*.mkv;*.f4v;*.dav;*.usm;*.asf"
            List<string> formatos = new List<string> { "mp4", "wmv", "mov", "flv", "avi", "webm", "mkv", "f4v", "dav", "usm", "asf" };
            if (formatos.Contains(ultimosTres(fileInfo.Name)))
            {
                VideoInfoO(fileInfo);
            }
            else
            {
                MessageBox.Show("Solo archivos de video", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            colorSystema();

        }

        private void videoInfo_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
            //cambiar color cuando arrastro
            cambioDeColor();
            ///////////////////////////////////////////////////////////////////////////
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            //copiar texto a porta papeles
            if (rTxtInforme.Text != "")
                Clipboard.SetDataObject(rTxtInforme.Text);
            else
                rTxtInforme.Text = "";
        }

        private void btnRegenerarTexto_Click(object sender, EventArgs e)
        {
            //mostrar de nuevo el segmento de informe
            rTxtInforme.Clear();
            rTxtInforme.Text = preInforme;
        }
        public string ultimosTres(string archivo)
        {
            string ultimosTres = archivo;
            int longitud = archivo.Length;

            if (longitud >= 3)
            {
                ultimosTres = archivo.Substring(longitud - 3);

            }
            return ultimosTres;
        }

        private void btnConfigurar_Click(object sender, EventArgs e)
        {
            var settingsform = new settingsForm();
            settingsform.ShowDialog();

        }
        public void calidadBitRate(bool x)
        {
            lblVBitRate.Visible = x;
            lblCBitRate.Visible = x;

        }
        public void calidadFrameRate(bool x)
        {
            lblVFrameRate.Visible = x;
            lblCFrameRate.Visible = x;

        }
        public void habilitarBotones(bool x)
        {
            btnAbrir.Enabled = x;
            btnConfigurar.Enabled = x;
            btnRegenerarTexto.Enabled = x;
            btnCopiar.Enabled = x;
        }

        private void abrirVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialogForm();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void acercaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var creditos = new Creditos();
            creditos.ShowDialog();

        }
        private void datosVisibles(bool x)
        {
            lblBitRate.Visible = x;
            lblBitRate.Visible = x;
            lblDuracion.Visible = x;
            lblNombre.Visible = x;
            lblDivisor.Visible = x;
            lblGeneral.Visible = x;
            lblDimension.Visible = x;
            lblC1.Visible = x;

            //labels C
            lblC2.Visible = x;
            lblCAspectRatio.Visible = x;
            //lblCBitRate.Visible = x;
            lblCDimensiones.Visible = x;
            lblCDireccion.Visible = x;
            lblCDuracion.Visible = x;
            //lblCFrameRate.Visible = x;
            lblCGeneral.Visible = x;
            lblCPeso.Visible = x;
            lblCNombre.Visible = x;
            //labels sin nombre
            label10.Visible = x;
            label18.Visible = x;
            label2.Visible = x;
            label3.Visible = x;
            label4.Visible = x;
            label5.Visible = x;
            label6.Visible = x;
            label7.Visible = x;
            label8.Visible = x;
            label9.Visible = x;
            label10.Visible = x;
            label12.Visible = x;
            label13.Visible = x;
            label17.Visible = x;
            label18.Visible = x;
            //labels V
            lblVAspectRatio.Visible = x;
            //lblVBitRate.Visible = x;
            lblVDimensiones.Visible = x;
            lblVDireccion.Visible = x;
            lblVDuracion.Visible = x;
            //lblVFrameRate.Visible = x;
            lblVNombre.Visible = x;
            lblVPeso.Visible = x;

            //botones
            btnCopiar.Enabled = x;
            btnRegenerarTexto.Enabled = x;
            rTxtInforme.Enabled = x;
            
            //contrario
            // mensaje abrir o arrastrar sera visible cuando el resto no
            lblAbrirArrastrar.Visible = !x;
        }

        private void grpDatos_DragOver(object sender, DragEventArgs e)
        {
            //grpDatos.BackColor = System.Drawing.Color.Black;
        }

        private void videoInfo_DragLeave(object sender, EventArgs e)
        {
            //abandonar el arrastrado de video y colocar colores por defecto
            colorSystema();
        }
        
        private void panelGeneral_DragLeave(object sender, EventArgs e)
        {
            //abandonar el arrastrado de video y colocar colores por defecto
            colorSystema();
        }

        
        private void cambioDeColor()
        {
            //cambia todo aceleste para mostrar interaccion con el objeto arrastrado
            grpDatos.BackColor = Color.SkyBlue;
            panelGeneral.BackColor = Color.SkyBlue;
            btnAbrir.BackColor = Color.SkyBlue;
            btnConfigurar.BackColor = Color.SkyBlue;
            btnCopiar.BackColor = Color.SkyBlue;
            btnRegenerarTexto.BackColor = Color.SkyBlue;

        }

        
        private void colorSystema()
        {
            //regresa todo a color por defecto, SystemColors.Control
            grpDatos.BackColor = SystemColors.Control;
            panelGeneral.BackColor = SystemColors.Control;
            btnAbrir.BackColor = SystemColors.Control;
            btnConfigurar.BackColor = SystemColors.Control;
            btnCopiar.BackColor = SystemColors.Control;
            btnRegenerarTexto.BackColor = SystemColors.Control;
        }

        private void panelGeneral_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRegenerarTexto_Click_1(object sender, EventArgs e)
        {
            //mostrar de nuevo el segmento de informe
            rTxtInforme.Clear();
            rTxtInforme.Text = preInforme;
        }

        private async void btnCopiar_Click_1(object sender, EventArgs e)
        {

            //copiar texto a porta papeles
            if (rTxtInforme.Text != "")
                Clipboard.SetDataObject(preInforme);
            else
                rTxtInforme.Text = "";

            //cambiar de color copiar
            btnCopiar.BackColor = Color.LightGreen;
            btnCopiar.TextAlign = ContentAlignment.MiddleCenter;
            btnCopiar.Text = "COPIADO!";
            btnCopiar.Image = null;
            //regresar a estado original el boton copiar
            await Task.Delay(800);
            btnCopiar.BackColor = SystemColors.Control;
            btnCopiar.Text = "Copiar Texto";
            btnCopiar.TextAlign = ContentAlignment.BottomCenter;
            btnCopiar.Image = Resources.portapapeles;
        }
    }
}
