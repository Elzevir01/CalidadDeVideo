using System;
using System.IO;
using System.Windows.Forms;
using MediaInfoDotNet;
using NReco.VideoInfo;

using ExtensionMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Collections.Generic;

namespace videoInfo
{
    public partial class videoInfo : Form
    {
        videos vid;
        FFProbe ffProbe;
        string[] archivos;
        string tipoPeso;

        string preInforme;

        PruebaDeCalidad pr;




        public videoInfo()
        {
            InitializeComponent();

        }

        private void videoInfo_Load(object sender, EventArgs e)
        {
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

                //if (openFileDialog.FileName != null | openFileDialog.FileName != "")
                //{
                FileInfo fileInfo;

                    if (File.Exists(openFileDialog.FileName))//File.Exists(fileInfo.FullName)
                {
                        fileInfo = new FileInfo(openFileDialog.FileName);
                        VideoInfoO(fileInfo);

                    }
                //}
            }catch (Exception e)
            {
                
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        }




        private videos VideoInfoO(FileInfo fil)
        {
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
                    calidadLbl(false);
                }
                else
                {
                    vid.BitRate = (Convert.ToInt32(fileMediaStr.bitRate)) / 1000;
                    calidadLbl(true);

                }
                vid.FrameRate = Convert.ToInt32(fileMediaStr.frameRate);

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
            catch(Exception e){
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            

            


            return vid;
        }
        private void MostrarInfVideos(videos vi)
        {
            habilitarBotones(false);
            //inicializar clase de PruebaDeCalidad
            pr = new PruebaDeCalidad();
            //Mostrar info de video
            lblVNombre.Text = vi.Nombre;
            lblVDireccion.Text = vi.Direccion;
            var duracion = vi.Duracion.ToString(@"hh\:mm\:ss");
            lblVDuracion.Text = duracion;
            lblVDimensiones.Text = vi.toStringDimension();
            lblVAspectRatio.Text = vi.Ratio();
            lblVBitRate.Text = Convert.ToString(vi.BitRate)+ " kbps";
            lblVFrameRate.Text = Convert.ToString(vi.FrameRate) + " fps";
            lblVPeso.Text = Convert.ToString(vi.Peso) + " "+ tipoPeso ;

            //Mostrar evaluacion de video
            lblCDimensiones.Text = Convert.ToString(pr.CalidadIndividual(pr.CalidadResolucion(vi.Alto)));
            lblCBitRate.Text = Convert.ToString(pr.CalidadIndividual(pr.CalidadBitRate(vi.BitRate)));
            lblCFrameRate.Text = Convert.ToString(pr.CalidadIndividual(pr.CalidadFrameRate(vi.FrameRate)));

            //Carga el texto de informe
            preInforme = "";
            preInforme = vi.PreInforme(pr.CalidadPromedioDeVideo(vi.BitRate, vi.FrameRate, vi.Alto));
            lblCGeneral.Text = pr.CalidadPromedioDeVideo(vi.BitRate,vi.FrameRate, vi.Alto);
            rTxtInforme.Clear();
            rTxtInforme.Text = preInforme;

            habilitarBotones(true);
            this.Cursor = Cursors.Default;
        }

        private void videoInfo_DragDrop(object sender, DragEventArgs e)
        {
            //Cargar datos de video arrastrando el archivo al programa
            archivos = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            var fileInfo = new FileInfo(archivos[0]);

            //*.mp4;*.wmv;*.mov;*.mp4;*.flv;*.avi;*.webm;*.mkv;*.f4v;*.dav;*.usm;*.asf"
            List<string> formatos = new List<string> {"mp4","wmv", "mov", "flv", "avi", "webm", "mkv", "f4v", "dav", "usm", "asf"};
            if ( formatos.Contains(ultimosTres(fileInfo.Name)) ) {
                VideoInfoO(fileInfo);
            }
            else
            {
                MessageBox.Show("Solo archivos de video", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void videoInfo_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
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
            rTxtInforme.Text =preInforme;
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
        public void calidadLbl(bool x)
        {
            lblVBitRate.Visible = x;
            lblCBitRate.Visible = x;

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
    }
}
