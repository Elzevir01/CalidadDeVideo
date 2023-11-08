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
//using System.Configuration;

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


            txtBitRateV1.Text = bitratev1;
            txtFrameRateV1.Text = frameratev1;
            txtResolucionV1.Text = resolucionv1;
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

        private void label4_Click(object sender, EventArgs e)
        {

        }
        
        private void txtCopyV1_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtBitRateV1_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtCopyV2_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtCopyV3_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtCopyV4_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtBitRateV2_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtBitRateV3_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtBitRateV4_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtFrameRateV1_TextChanged(object sender, EventArgs e)
        {
        }
        

        private void txtCopyFrameV1_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtCopyFrameV2_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtCopyFrameV3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCopyFrameV4_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtFrameRateV2_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtFrameRateV3_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtFrameRateV4_TextChanged(object sender, EventArgs e)
        {
        }
        
        private void txtResolucionV1_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtResolucionV2_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtResolucionV3_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtResolucionV4_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtCopyResolucionV1_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtCopyResolucionV2_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtCopyResolucionV3_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtCopyResolucionV4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
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

        private void txtBitRateV2_Leave(object sender, EventArgs e)
        {
        }

        private void txtBitRateV3_Leave(object sender, EventArgs e)
        {
        }

        private void txtBitRateV4_Leave(object sender, EventArgs e)
        {
        }

        private void txtBitRateV1_Leave(object sender, EventArgs e)
        {
        }

        private void txtFrameRateV1_Leave(object sender, EventArgs e)
        {
        }

        private void txtFrameRateV2_Leave(object sender, EventArgs e)
        {
        }

        private void txtFrameRateV3_Leave(object sender, EventArgs e)
        {
        }

        private void txtFrameRateV4_Leave(object sender, EventArgs e)
        {
        }

        private void txtResolucionV1_Leave(object sender, EventArgs e)
        {
        }

        private void txtResolucionV2_Leave(object sender, EventArgs e)
        {
        }

        private void txtResolucionV3_Leave(object sender, EventArgs e)
        {
        }

        private void txtResolucionV4_Leave(object sender, EventArgs e)
        {
        }
    }
}
