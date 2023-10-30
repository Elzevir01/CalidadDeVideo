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
        int bitratev2 = Convert.ToInt32(ConfigurationManager.AppSettings["bitrate-v2"]);
        int bitratev3 = Convert.ToInt32(ConfigurationManager.AppSettings["bitrate-v3"]);
        int bitratev4 = Convert.ToInt32(ConfigurationManager.AppSettings["bitrate-v4"]);

        int frameratev1 = Convert.ToInt32(ConfigurationManager.AppSettings["framerate-v1"]);
        int frameratev2 = Convert.ToInt32(ConfigurationManager.AppSettings["framerate-v2"]);
        int frameratev3 = Convert.ToInt32(ConfigurationManager.AppSettings["framerate-v3"]);
        int frameratev4 = Convert.ToInt32(ConfigurationManager.AppSettings["framerate-v4"]);

        int resolucionv1 = Convert.ToInt32(ConfigurationManager.AppSettings["resolucion-v1"]);
        int resolucionv2 = Convert.ToInt32(ConfigurationManager.AppSettings["resolucion-v2"]);
        int resolucionv3 = Convert.ToInt32(ConfigurationManager.AppSettings["resolucion-v3"]);
        int resolucionv4 = Convert.ToInt32(ConfigurationManager.AppSettings["resolucion-v4"]);

        public int CalidadBitRate(int bitRate)
        {
            int bit = 0;

            if (bitRate >= bitratev1)
                bit = 100;
            if (bitRate >= bitratev2 && bitRate < bitratev1)
                bit = 75;
            if (bitRate >= bitratev3 && bitRate < bitratev2)
                bit = 50;
            if (bitRate >= bitratev4 && bitRate < bitratev3)
                bit = 25;
            if (bitRate < bitratev4)
                bit = 0;

            return bit;
        }
        public int CalidadResolucion(int resolucionAlto)
        {
            int res = 0;

            if (resolucionAlto >= resolucionv1)
                res = 100;
            if (resolucionAlto >= resolucionv2 && resolucionAlto < resolucionv1)
                res = 75;
            if (resolucionAlto >= resolucionv3 && resolucionAlto < resolucionv2)
                res = 50;
            if (resolucionAlto >= resolucionv4 && resolucionAlto < resolucionv3)
                res = 25;
            if (resolucionAlto < resolucionv4)
                res = 0;

            return res;
        }
        public int CalidadFrameRate(int frameRate)
        {
            int frame = 0;

            if (frameRate >= frameratev1)
                frame = 100;
            if (frameRate >= frameratev2 && frameRate < frameratev1)
                frame = 75;
            if (frameRate >= frameratev3 && frameRate < frameratev2)
                frame = 50;
            if (frameRate >= frameratev4 && frameRate < frameratev3)
                frame = 25;
            if (frameRate < frameratev4)
                frame = 0;

            return frame;
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
        public string CalidadPromedioDeVideo(int bitrate, int framerate, int resolucion)
        {
            string calidad = "";
            int cantidadCalidad=0;

            if (CalidadBitRate(bitrate) > 0)
                cantidadCalidad++;
            if (CalidadFrameRate(framerate) > 0)
                cantidadCalidad++;
            if (CalidadResolucion(resolucion) > 0)
                cantidadCalidad++;

            double puntuacion;
            puntuacion = (CalidadBitRate(bitrate) + CalidadFrameRate(framerate) + CalidadResolucion(resolucion)) / cantidadCalidad;
            if (puntuacion >= 80)
                calidad = "Muy Buena";
            if (puntuacion >= 60 && puntuacion < 80)
                calidad = "Buena";
            if (puntuacion >= 40 && puntuacion < 60)
                calidad = "Aceptable";
            if (puntuacion >= 20 && puntuacion < 40)
                calidad = "Mala";
            if (puntuacion < 20)
                calidad = "Muy Mala";
            if (calidad == "")
                calidad = "Sin Determinar";

            return calidad;
        }

    }
    
}
