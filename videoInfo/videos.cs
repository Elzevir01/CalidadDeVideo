using System;
using System.Collections.Generic;
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

        public string resolucionDimension()
        {
            return ancho + " x " + alto+" "+Calidad169();
        }
        public string CalidadPromedioDeVideo()
        {
            string calidad = "";

            double puntuacion;
            puntuacion = (CalidadBitRate() + CalidadFrameRate() + CalidadResolucion()) / 3;
            if (puntuacion >= 80)
                calidad = "Muy Buena";
            if (puntuacion >= 60 && puntuacion < 80)
                calidad = "Buena";
            if (puntuacion >= 40 && puntuacion < 60)
                calidad = "Aceptable";
            if (puntuacion >= 20 && puntuacion < 40)
                calidad = "Mala";
            if (puntuacion < 20 )
                calidad = "Muy Mala";
            if (calidad == "")
                calidad = "Sin Determinar";

            return calidad;
        }
        public string CalidadIndividual(int calidadDe)
        {
            string calidad = "";

            
            if (calidadDe >= 80)
                calidad = "Muy Buena";
            if (calidadDe >= 60 && calidadDe < 80)
                calidad = "Buena";
            if (calidadDe >= 40 && calidadDe < 60)
                calidad = "Aceptable";
            if (calidadDe >= 20 && calidadDe < 40)
                calidad = "Mala";
            if (calidadDe < 20)
                calidad = "Muy Mala";
            if (calidad == "")
                calidad = "Sin Determinar";

            return calidad;
        }
        public int CalidadFrameRate()
        {
            int frame=0;

            if (frameRate > 90)
                frame = 100;
            if (frameRate >= 60 && frameRate < 90)
                frame = 75;
            if (frameRate >= 24 && frameRate < 60)
                frame = 50;
            if (frameRate >= 10 && frameRate < 24)
                frame = 25;
            if (frameRate < 10)
                frame = 0;

            return frame;
        }
        public int CalidadBitRate()
        {
            int bit = 0;

            if (bitRate >= 4000)
                bit = 100;
            if (bitRate >= 2500 && bitRate < 4000)
                bit = 75;
            if (bitRate >= 1000 && bitRate < 2500)
                bit = 50;
            if (bitRate >= 500 && bitRate < 1000)
                bit = 25;
            if (bitRate < 500)
                bit = 0;

            return bit;
        }
        public int CalidadResolucion()
        {
            int res=0;

            if (alto >= 1080)
                res = 100;
            if (Alto >= 720 && alto < 1080)
                res = 75;
            if (alto >= 480 && alto < 720)
                res = 50;
            if (alto >= 240 && alto < 480)
                res = 25;
            if (alto < 240)
                res = 0;

            return res;
        }
        public string toStringDimension()
        {
            string dime = "";

            dime = Convert.ToString(ancho) + "x" + Convert.ToString(alto) + "px " + Calidad169();

            return dime;
        }
        public string PreInforme()
        {
            string informe = "";
            string inicio = "Que en cuanto a la calidad del material filmico, nos encontramos con un video";
            string tamanioText = "de tamaño "+ toStringDimension();
            string framerateText = ", con un promedio de "+frameRate+" fotogramas por segundo(FPS)";
            string bitrateText = "";

            if (bitRate > 1)
                bitrateText = ", un flujo de datos de aproximadamente " + bitRate + " kbps";
            else
                bitrateText = "";

            string final = ". Estos valores anuncian una "+ CalidadPromedioDeVideo() + " calidad del material para la compulsa.";


            informe = inicio+tamanioText+framerateText+bitrateText+final;

            return informe;
        }



    }
}
