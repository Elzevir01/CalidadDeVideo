using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videoInfo
{
    internal class PruebaDeCalidad
    {
        //Datos traidos de App.config
        int bitratev1 = Convert.ToInt32(ConfigurationManager.AppSettings["bitrate-v1"]);
        int frameratev1 = Convert.ToInt32(ConfigurationManager.AppSettings["framerate-v1"]);
        int resolucionv1 = Convert.ToInt32(ConfigurationManager.AppSettings["resolucion-v1"]);

        public int CalidadBitRate(int bitRate)
        {
            //determina entre 1 a 100 usando regla de tres simple el valor 
            int bit = 0;
            int valorMaximo = 100;

            bit = (bitRate * valorMaximo) / bitratev1;

            return bit;
        }
        public int CalidadResolucion(int resolucionAlto)
        {
            //determina entre 1 a 100 usando regla de tres simple el valor 
            int res = 0;
            int valorMaximo = 100;

            res = (resolucionAlto * valorMaximo) / resolucionv1;

            return res;
        }
        public int CalidadFrameRate(int frameRate)
        {
            //determina entre 1 a 100 usando regla de tres simple el valor 
            int frame = 0;
            int valorMaximo = 100;

            frame = (frameRate * valorMaximo) / frameratev1;

            return frame;
        }
        public string CalidadIndividual(int calidadDe)
        {
            //usando una clasificacion numerica de 0 a 100 determinar en texto la calidad de este
            string calidad = "";
            if (calidadDe < 25)
                calidad = "Muy Mala";
            if (calidadDe >= 25)
                calidad = "Mala";
            if (calidadDe >= 50)
                calidad = "Aceptable";
            if (calidadDe >= 75)
                calidad = "Buena";
            if (calidadDe >=100)
                calidad = "Muy Buena";


            return calidad;
        }
        public string CalidadPromedioDeVideo(int bitrate, int framerate, int resolucion)
        {
            string calidad = "";
            int cantidadCalidad=0;
            //contar cuantos datos se pudieron traer del video
            if (CalidadBitRate(bitrate) > 0)
                cantidadCalidad++;
            if (CalidadFrameRate(framerate) > 0)
                cantidadCalidad++;
            if (CalidadResolucion(resolucion) > 0)
                cantidadCalidad++;
            //promediar este valor, darle una puntuacion y colocarlo en texto
            double puntuacion;
            puntuacion = (CalidadBitRate(bitrate) + CalidadFrameRate(framerate) + CalidadResolucion(resolucion)) / cantidadCalidad;
            
            calidad = CalidadIndividual(Convert.ToInt16(puntuacion));
            return calidad;
        }

    }
    
}
