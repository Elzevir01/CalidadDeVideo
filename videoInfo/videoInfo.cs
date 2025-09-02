using System;
using System.IO;
using System.Windows.Forms;
using MediaInfoDotNet;
using NReco.VideoInfo;
using NReco.VideoConverter;

using ExtensionMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using videoInfo.Properties;
using LiveCharts.Wpf;

//using System.Windows;
//using MessageBox = System.Windows.Forms.MessageBox;
//using SystemColors = System.Drawing.SystemColors;
//using Clipboard = System.Windows.Forms.Clipboard;

namespace videoInfo
{
    public partial class videoInfo : Form
    {
        OxPlotGaugeConf2 opg2;
        videos vid;
        FFProbe ffProbe;
        string[] archivos;
        string tipoPeso;
        int anchoAlto;
        string preInforme;

        Image[] frameVideo;
        TimeSpan[] frameTime;

        private double[] TimeSpanImage = { 0.25, 0.50, 0.75, 0.95 };

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

            // thumbnail

            //ingresar el thumbnail

            //TimeSpan[] timespan = vid.timeSpanArray();
            //TimeSpan tss = timespan[0];
            //= TimeSpan.FromSeconds(segundos).ToString(@"hh\:mm\:ss\:ffff");
            //vid.Thumbnail = thumbnail(fil, TimeSpanImage[1]);
           





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
            // esto se movio a el titulo de la ventana del programa
            //lblVDireccion.Text = vi.Direccion;
            this.Text = "Calidad de Video - "+vi.Direccion;
            var duracion = vi.Duracion.ToString(@"hh\:mm\:ss");
            lblVDuracion.Text = duracion;
            lblVDimensiones.Text = vi.toStringDimension(anchoAlto);
            lblVAspectRatio.Text = vi.Ratio();
            lblVBitRate.Text = Convert.ToString(vi.BitRate) + " kbps";
            lblVFrameRate.Text = Convert.ToString(vi.FrameRate) + " fps";
            lblVPeso.Text = Convert.ToString(vi.Peso) + " " + tipoPeso;

            //Carga Thumbnail
            //pBoxThumbNail.Image = vi.Thumbnail;
            pBoxThumbNail0.SizeMode = PictureBoxSizeMode.Zoom;

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

            //Mostrar los datos en graficos
            //
            opg2 = new OxPlotGaugeConf2();
            //bits = 0 FPS=1 Resolucion=2
            pvGaugeBits = opg2.GaugeConf(pvGaugeBits, vi.BitRate, 0, mayorConf( Convert.ToInt32(pr.ParametroBitRate()), vi.BitRate ),0 );
            pvGaugeFps = opg2.GaugeConf(pvGaugeFps, vi.FrameRate, 0 , mayorConf( Convert.ToInt32(pr.ParametroFrameRate()), vi.FrameRate ) ,1 );
            pvGaugeDimension = opg2.GaugeConf(pvGaugeDimension, vi.Alto, 0, mayorConf( Convert.ToInt32(pr.ParametroResolucion()), vi.Alto ),2 );
            //
            //gaugeBits.Value = vi.BitRate;
            //gaugeBits.From = 1000;
            //gaugeBits.To = Convert.ToInt32(pr.ParametroBitRate());
            //gaugeBits.FromColor = System.Windows.Media.Color.FromRgb(255, 0, 0);
            //gaugeBits.ToColor = System.Windows.Media.Color.FromRgb(0, 0,255);

            //gaugeFps.Value = vi.FrameRate;
            //gaugeFps.From = 1;
            //gaugeFps.To = Convert.ToInt32(pr.ParametroFrameRate());
            //gaugeFps.FromColor = System.Windows.Media.Color.FromRgb(255, 0, 0);
            //gaugeFps.ToColor = System.Windows.Media.Color.FromRgb(0, 0, 255);

            //gaugeDimension.Value = vi.Alto;
            //gaugeDimension.From = 144;
            //gaugeDimension.To = Convert.ToInt32(pr.ParametroResolucion());
            //gaugeDimension.FromColor = System.Windows.Media.Color.FromRgb(255, 0, 0);
            //gaugeDimension.ToColor = System.Windows.Media.Color.FromRgb(0, 0, 255);

            gaugePromedio.From = 0;
            gaugePromedio.To = 100;
            gaugePromedio.Value = pr.CalidadPromedioDouble(vi.BitRate, vi.FrameRate, vi.Alto);
            gaugePromedio.FromColor = System.Windows.Media.Color.FromRgb(255, 0, 0);
            gaugePromedio.ToColor = System.Windows.Media.Color.FromRgb(0, 0, 255);
            //mostrar thumbnail y timespan


            //timespan 0
            frameTime = new TimeSpan[4];
            frameTime = timeSpanArray(vi.Duracion);
            lblTimeStamp0.Text = frameTime[0].ToString(@"hh\:mm\:ss");//(@"hh\:mm\:ss\:ffff"
            lblTimeStamp1.Text = frameTime[1].ToString(@"hh\:mm\:ss");
            lblTimeStamp2.Text = frameTime[2].ToString(@"hh\:mm\:ss");
            lblTimeStamp3.Text = frameTime[3].ToString(@"hh\:mm\:ss");
            //lblTimeStamp4.Text = frameTime[4].ToString(@"hh\:mm\:ss");


            frameVideo = new Image[4];
            frameVideo = Thumbnail(vi.Direccion, frameTime);
            pBoxThumbNail0.Image = frameVideo[0];
            pBoxThumbNail1.Image = frameVideo[1];
            pBoxThumbNail2.Image = frameVideo[2];
            pBoxThumbNail3.Image = frameVideo[3];
            //pBoxThumbNail4.Image = frameVideo[4];
        }

        private void videoInfo_DragDrop(object sender, DragEventArgs e)
        {
            //Cargar datos de video arrastrando el archivo al programa
            archivos = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            var fileInfo = new FileInfo(archivos[0]);

            //*.mp4;*.wmv;*.mov;*.mp4;*.flv;*.avi;*.webm;*.mkv;*.f4v;*.dav;*.usm;*.asf"
            List<string> formatos = new List<string> { "mp4", "wmv", "WMV", "mov", "flv", "avi", "webm", "mkv", "f4v", "dav", "usm", "asf" };
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
            lblVDuracion.Visible = x;
            //lblVFrameRate.Visible = x;
            lblVNombre.Visible = x;
            lblVPeso.Visible = x;

            //botones
            btnCopiar.Enabled = x;
            btnRegenerarTexto.Enabled = x;
            rTxtInforme.Enabled = x;

            //graficos

            gaugePromedio.Visible = x;

            //screencap
            lblTimeStamp0.Visible = x;
            lblTimeStamp1.Visible = x;
            lblTimeStamp2.Visible = x;
            lblTimeStamp3.Visible = x;

            

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
            pvGaugeBits.BackColor = Color.SkyBlue;
            pvGaugeFps.BackColor = Color.SkyBlue;
            pvGaugeDimension.BackColor = Color.SkyBlue;

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
            pvGaugeBits.BackColor = SystemColors.Control;
            pvGaugeFps.BackColor = SystemColors.Control;
            pvGaugeDimension.BackColor = SystemColors.Control;
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

        private void lblAbrirArrastrar_Click(object sender, EventArgs e)
        {

        }

        // Crear el thumbnail con NRECO
        private Image[] Thumbnail(string direccion, TimeSpan[] tiempo)//FileInfo fil, TimeSpan[] tiempo
        {

            //variable FFMpegConverter
            var ffMpeg = new FFMpegConverter();

            Image[] fv = new Image[4];

            for (int i = 0; i < 4; i++)
            {
                // Guardar la captura en memoria (stream)
                using (var ms = new MemoryStream())
                {
                    // Extraer en formato PNG ( el numero son los segundos que obtiene la caputura)
                    ffMpeg.GetVideoThumbnail(direccion, ms, (float)tiempo[i].TotalSeconds);

                    // Regresar al inicio del stream
                    ms.Position = 0;


                    fv[i] = Image.FromStream(ms);

                }
                frameVideo = fv;
               

            }
            return frameVideo;
        }
        // obtiene 5 timespan de diferentes porcentajes->requiere la duracion del video
        public TimeSpan[] timeSpanArray(TimeSpan duracion)
        {
            TimeSpan[] tsa = new TimeSpan[4];
            for (int i = 0; i < 4; i++)
            {
                tsa[i] = TimeSpan.FromTicks((long)(duracion.Ticks * TimeSpanImage[i] )); //*timespan img
            }

            return tsa;
        }
        public int mayorConf(int conf, int maximo )
        {
            if (maximo > conf) return maximo;
            else return conf;
        }

    }
}
