using System;
using System.IO;
using System.Windows.Forms;
using MediaInfoDotNet;
using NReco.VideoInfo;

using ExtensionMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;


namespace videoInfo
{
    public partial class videoInfo : Form
    {
        videos vid;
        FFProbe ffProbe;
        string[] archivos;
        string tipoPeso;
        

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
            //Abrir cuadro de dialogode busqueda de archivo de video
            //OpenFileDialog dialog = new OpenFileDialog();
            openFileDialog.Title = "Abrir video";
            openFileDialog.Filter = "Archivos de Video|*.mp4;*.wmv;*.mov;*.mp4;*.flv;*.avi;*.webm;*.mkv;*.f4v;*.dav;*.usm;*.asf";
            openFileDialog.DefaultExt = "video";
            openFileDialog.FileName = "";
            openFileDialog.ShowDialog();

            FileInfo fileInfo = new FileInfo(openFileDialog.FileName);

            if (File.Exists(fileInfo.FullName))
            {
                VideoInfoO(fileInfo);

            }
        }




        private videos VideoInfoO(FileInfo fil)
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
            //problema con usm
            var fileNReco = ffProbe.GetMediaInfo(fil.FullName);

            //ingresar datos al objeto videos
            vid.Nombre = fil.Name;
            vid.Direccion = fil.FullName;
            if (fileMediaStr.Duration == null | fileMediaStr.Duration <1)
            {
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
                vid.BitRate = 0; ;
            }
            else
            {
                vid.BitRate = (Convert.ToInt32(fileMediaStr.bitRate)) / 1000;
                
            }
            vid.FrameRate = Convert.ToInt32(fileMediaStr.frameRate);
            if (fileSizeInBytes> 1048576) {
                tipoPeso = "MB";
                vid.Peso = (fileSizeInBytes / 1048576);
            }
            else
            {
                tipoPeso = "KB";
                vid.Peso = fileSizeInBytes/1048;
            }
            MostrarInfVideos(vid);

            


            return vid;
        }
        private void MostrarInfVideos(videos vi)
        {
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
            lblCDimensiones.Text = vi.CalidadIndividual(vi.CalidadResolucion());
            lblCBitRate.Text = vi.CalidadIndividual(vi.CalidadBitRate());
            lblCFrameRate.Text = vi.CalidadIndividual(vi.CalidadFrameRate());

            lblCGeneral.Text = vi.CalidadPromedioDeVideo();

            rTxtInforme.Text = "";
            rTxtInforme.Text = vi.PreInforme();

        }
        public void FfmpegBitRate(FileInfo fil)
        {
           

        }

        private void videoInfo_DragDrop(object sender, DragEventArgs e)
        {
            //Cargar datos de video arrastrando el archivo al programa
            archivos = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            var fileInfo = new FileInfo(archivos[0]);

            VideoInfoO(fileInfo);


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
                rTxtInforme.Text = "No text selected in textBox1";
        }

        private void btnRegenerarTexto_Click(object sender, EventArgs e)
        {
            //mostrar de nuevo el segmento de informe
            rTxtInforme.Text = vid.PreInforme();
        }
    }
}
