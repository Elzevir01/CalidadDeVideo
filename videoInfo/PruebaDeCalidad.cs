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

        string calidad0 = ConfigurationManager.AppSettings["calidad0"];
        string calidad1 = ConfigurationManager.AppSettings["calidad1"];
        string calidad2 = ConfigurationManager.AppSettings["calidad2"];
        string calidad3 = ConfigurationManager.AppSettings["calidad3"];
        string calidad4 = ConfigurationManager.AppSettings["calidad4"];

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
                calidad = calidad0;
            if (calidadDe >= 25)
                calidad = calidad1;
            if (calidadDe >= 50)
                calidad = calidad2;
            if (calidadDe >= 75)
                calidad = calidad3;
            if (calidadDe >=100)
                calidad = calidad4;


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
        //bitratev1 = Convert.ToInt32(ConfigurationManager.AppSettings["bitrate-v1"]);
        //int frameratev1 = Convert.ToInt32(ConfigurationManager.AppSettings["framerate-v1"]);
        //int resolucionv1

        public int ParametroBitRate()
        {
            return bitratev1;
        }
        public int ParametroFrameRate()
        {
            return frameratev1;
        }
        public int ParametroResolucion()
        {
            return resolucionv1;
        }

        public double CalidadPromedioDouble(int bitrate, int framerate, int resolucion)
        {
            double calidad = 0;
            int cantidadCalidad = 0;
            //contar cuantos datos se pudieron traer del video
            //if (CalidadBitRate(bitrate) > 0)
            //    cantidadCalidad++;
            //if (CalidadFrameRate(framerate) > 0)
            //    cantidadCalidad++;
            //if (CalidadResolucion(resolucion) > 0)
            //    cantidadCalidad++;
            if (Calidad(bitrate,bitratev1) > 0)
                cantidadCalidad++;
            if (Calidad(framerate, frameratev1) > 0)
                cantidadCalidad++;
            if (Calidad(resolucion, resolucionv1) > 0)
                cantidadCalidad++;
            //promediar este valor, darle una puntuacion y colocarlo en texto
            double puntuacion;
            //puntuacion = (CalidadBitRate(bitrate) + CalidadFrameRate(framerate) + CalidadResolucion(resolucion)) / cantidadCalidad;
            puntuacion = (Calidad(bitrate, bitratev1) + Calidad(framerate, frameratev1) + Calidad(resolucion, resolucionv1)) / cantidadCalidad;

            calidad = puntuacion;
            return calidad;
        }
        public int Calidad(int item, int conf)//30 ?? //60
        {
            //determina entre 1 a 100 usando regla de tres simple el valor 
            if (item > conf) return (item * 100) / item;
            else return (item * 100) / conf;
        
        }

    }
    
}
