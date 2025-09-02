using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using OxyPlot.WindowsForms;
using System;
using System.Linq;

namespace videoInfo
{
    internal class OxPlotGaugeConf2
    {
        // bits = 0, fps = 1, resolucion = 2
        double[] ticksResolucion = {0, 144, 240, 360, 480, 720, 1080 };
        double[] tickFPS = { 0, 15, 30, 45, 60, 90, 120, 280 };
        double[] tickBits = {0, 2000, 4000, 6000, 8000, 10000, 12000, 14000, 16000, 18000, 20000 };

        public PlotView GaugeConf(PlotView plotView, double valor, double minimo, double maximo, int tptk)
        {
            var model = new PlotModel();

            // Serie: barra horizontal
            var barSeries = new BarSeries
            {
                IsStacked = false,
                FillColor = OxyColors.DodgerBlue,
                BarWidth = 1.0,
                StrokeThickness = 0,//0 son borde //1 borde
                LabelPlacement = LabelPlacement.Inside,
                LabelFormatString = "{0:0}",
                TextColor = OxyColors.White,
                FontWeight = 700
                /////

            };
            barSeries.Items.Add(new BarItem { Value = valor });
            //barSeries.Items.Add(new BarItem { Value = valor, CategoryIndex = 0 });
            model.Series.Add(barSeries);

            // Eje vertical: una categoría para que no “crezca” en alto
            model.Axes.Add(new CategoryAxis
            {
                Position = AxisPosition.Left,
                IsAxisVisible = false,
                //Minimum = -0.5,
                //Maximum = 0.5
                Minimum = -0.5,   // categoría empieza en 0
                Maximum = 0.5  // termina en 1
            });

            // Eje horizontal con ticks personalizados
            var ticks = tipoTick(tptk);
            int majorStep = ComputeMajorStepFromTicks(ticks);

            var ejeX = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Minimum = minimo,          // p.ej. 144 para resolución
                Maximum = maximo,          // p.ej. 1080 para resolución
                MajorStep = majorStep,     // asegura que 144, 240, 360, ... caigan en major ticks
                MinorStep = double.NaN,
                TickStyle = TickStyle.Outside,   //TickStyle.None,// oculta TODAS las marcas (evita “ticks sin números”)
                MajorGridlineStyle = LineStyle.Solid, // opcional: sin líneas de grilla
                MinorGridlineStyle = LineStyle.None,
                MinorTickSize = 0,
               
                // Etiquetas SOLO en tus ticks
                LabelFormatter = v =>
                {
                    // redondeo a entero porque tus ticks son enteros
                    var r = Math.Round(v);
                    return ticks.Any(t => Math.Abs(r - t) < 1e-9) ? r.ToString("0") : string.Empty;
                },

                IsPanEnabled = false,
                IsZoomEnabled = false
            };

            /////// elimina padding
            //model.Padding = new OxyThickness(0);        // elimina padding
            //model.PlotMargins = new OxyThickness(0);    // elimina márgenes internos
            //////
            //var categoryAxis = new CategoryAxis
            //{
            //    Position = AxisPosition.Left,
               
            //    Labels = { stringTitle(tptk)} // 👈 nombres de las filas
            //};
            //model.Axes.Add(categoryAxis);


            model.Axes.Add(ejeX);

            plotView.Model = model;
            // plotView.InvalidatePlot(true); // opcional en WinForms
            return plotView;
        }

        public double[] tipoTick(int tck)
        {
            if (tck == 0) return tickBits;
            else if (tck == 1) return tickFPS;
            else return ticksResolucion;
        }
        public string stringTitle(int tck)
        {
            if (tck == 0) return "Taza de Bits";
            else if (tck == 1) return "Fotos por Segundo";
            else return "Pixeles de Alto";
        }

        // Calcula un MajorStep que “contenga” a todos los ticks (MCD de las diferencias)
        private static int ComputeMajorStepFromTicks(double[] ticks)
        {
            var diffs = ticks
                .OrderBy(x => x)
                .Select((t, i) => i == 0 ? 0 : (int)Math.Round(t - ticks[i - 1]))
                .Skip(1) // salteo el 0 inicial
                .Select(Math.Abs)
                .ToArray();

            int Gcd(int a, int b)
            {
                a = Math.Abs(a); b = Math.Abs(b);
                while (b != 0) { int t = a % b; a = b; b = t; }
                return a == 0 ? 1 : a;
            }

            int g = 0;
            foreach (var d in diffs) g = Gcd(g, d);
            return g == 0 ? 1 : g;
        }
    }
}

