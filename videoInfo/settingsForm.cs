using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace videoInfo
{
    public partial class settingsForm : Form
    {
        public settingsForm()
        {
            InitializeComponent();

            txtFrameRateV1.KeyPress += txtBitRateV1_KeyPress;
            txtResolucionV1.KeyPress += txtBitRateV1_KeyPress;
            txtBitRateV1.KeyPress += txtBitRateV1_KeyPress;

            
        }

        private void settingsForm_Load(object sender, EventArgs e)
        {
           
            string bitratev1 = ConfigurationManager.AppSettings["bitrate-v1"];
            string frameratev1 = ConfigurationManager.AppSettings["framerate-v1"];
            string resolucionv1 = ConfigurationManager.AppSettings["resolucion-v1"];

            string calidad0 = ConfigurationManager.AppSettings["calidad0"];
            string calidad1 = ConfigurationManager.AppSettings["calidad1"];
            string calidad2 = ConfigurationManager.AppSettings["calidad2"];
            string calidad3 = ConfigurationManager.AppSettings["calidad3"];
            string calidad4 = ConfigurationManager.AppSettings["calidad4"];



            txtBitRateV1.Text = bitratev1;
            txtFrameRateV1.Text = frameratev1;
            txtResolucionV1.Text = resolucionv1;

            txtCalidad0.Text = calidad0;
            txtCalidad1.Text = calidad1;
            txtCalidad2.Text = calidad2;
            txtCalidad3.Text = calidad3;
            txtCalidad4.Text = calidad4;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            //Guarda los datos en App.Config
            Configuration config;
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings["bitrate-v1"].Value = txtBitRateV1.Text;
            config.AppSettings.Settings["resolucion-v1"].Value = txtResolucionV1.Text;
            config.AppSettings.Settings["framerate-v1"].Value = txtFrameRateV1.Text;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            MessageBox.Show("Datos guardados", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();


        }

        
        public void soloNumeros(KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es un número o una tecla de control (como Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Si no es un número ni una tecla de control, no permite que se ingrese en el TextBox
                e.Handled = true;
            }
        }
        
        private void txtBitRateV1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //soloNumeros(e);
            // Verifica si la tecla presionada es un número o una tecla de control (como Backspace)
           if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Si no es un número ni una tecla de control, no permite que se ingrese en el TextBox
                e.Handled = true;
            }
        }
        private void validarNumero(TextBox txtActual, TextBox txtSup, TextBox txtInf)
        {
            int ac=0;
            int sp;
            int inf;

            if(txtActual !=null)
             ac = Convert.ToInt32(txtActual.Text);

            if (txtSup != null)
            {
                sp = Convert.ToInt32(txtSup.Text);
            }
            else { sp = Convert.ToInt32(txtActual.Text)*100; }


            if (txtInf != null  )
            {
                inf = Convert.ToInt32(txtInf.Text);
            }
            else {
                inf = 0;
            }


            if (Convert.ToInt32(ac) >= Convert.ToInt32(sp))
            {
                txtActual.Text = Convert.ToString(sp - 1);
            }

            if (Convert.ToInt32(ac) <= Convert.ToInt32(inf))
            {
                txtActual.Text = Convert.ToString(inf + 1);
            }
        }

       
    }
}
