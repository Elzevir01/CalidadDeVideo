using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace videoInfo
{
    internal class videos
    {
        private string nombre;
        private string direccion;
        private int frameRate;
        private int bitRate;
        private int alto;
        private int ancho;
        private long peso;
        private TimeSpan duracion;

        //private Image[] thumbnail;
        //private TimeSpan[] thimbTimeSpan;
       


        
        

        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int FrameRate { get => frameRate; set => frameRate = value; }
        public int BitRate { get => bitRate; set => bitRate = value; }
        public int Alto { get => alto; set => alto = value; }
        public int Ancho { get => ancho; set => ancho = value; }
        public long Peso { get => peso; set => peso = value; }
        public TimeSpan Duracion { get => duracion; set => duracion = value; }



        public videos()
        {

        }
        public videos(string nombre, string direccion, int frameRate, int bitRate, int alto, int ancho, int peso, TimeSpan duracion)
        {
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.FrameRate = frameRate;
            this.BitRate = bitRate;
            this.Alto = alto;
            this.Ancho = ancho;
            this.Peso = peso;
            this.Duracion = duracion;
           
        }
        //
        public string Ratio()


        {
            string ratio;
            //16:9
            if (ancho / 16 == alto / 9)
            {
                ratio = "16:9";
            }else if(ancho / 4 == alto / 3)
            {
                ratio = "4:3";
            }else if(ancho / 3 == alto / 2)
            {
                ratio = "3:2";
            }
            else if (ancho / 21 == alto / 9)
            {
                ratio = "21:9";
            }
            else
            {
                ratio = "personalizado";
            }


            return ratio;
        }
        public string Calidad169()
        {
            string calidad= "";
            

            if (Ratio() == "16:9")
            {
                switch (alto)
                {
                    case 720:
                        calidad = "HD";
                        break;
                    case 1080:
                        calidad = "Full HD";
                        break;
                    case 2160:
                        calidad = "4K (Ultra HD)";
                        break;
                    case 1440:
                        calidad = "2K (Quad HD)";
                        break;
                    case 4320:
                        calidad = "8K";
                        break;
                    default:
                        calidad = "";
                        break;

                }
            }

            return calidad;
        }

        public string resolucionDimension(int anchoAlto)
        {
            return ancho + " x " + alto+" "+Calidad169();
        }
        
        public string toStringDimension(int anchoAlto)
        {
            string dime = "";

            dime = Convert.ToString(ancho) + "px (Ancho) X " + Convert.ToString(alto) + "px (Alto) " + Calidad169();

            return dime;
        }
        public string PreInforme(string CalidadPromedio, int anchoAlto)
        {
            string informe = "";
            string inicio = "Que en cuanto a la calidad del material filmico, nos encontramos con un video";
            string tamanioText = " de tamaño "+ toStringDimension(anchoAlto);
            string framerateText= "";// = ", con un promedio de "+frameRate+" fotogramas por segundo(FPS)";
            string bitrateText = "";

            if (frameRate > 1)
                framerateText =  ", con un promedio de " + frameRate + " fotogramas por segundo(FPS)";
            else
                framerateText = "";

            if (bitRate > 1)
                bitrateText = ", un flujo de datos de aproximadamente " + bitRate + " kbps";
            else
                bitrateText = "";

            string final = ". Estos valores anuncian una "+ CalidadPromedio + " calidad del material para la compulsa.";


            informe = inicio+tamanioText+framerateText+bitrateText+final;

            return informe;
        }
        



    }
}
