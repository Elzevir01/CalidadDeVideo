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

            /*txtBitRateV2.KeyPress += txtBitRateV1_KeyPress;
            txtBitRateV3.KeyPress += txtBitRateV1_KeyPress;
            txtBitRateV4.KeyPress += txtBitRateV1_KeyPress;
            txtCopyV1.KeyPress += txtBitRateV1_KeyPress;
            txtCopyV2.KeyPress += txtBitRateV1_KeyPress;
            txtCopyV3.KeyPress += txtBitRateV1_KeyPress;
            txtCopyV4.KeyPress += txtBitRateV1_KeyPress;
            txtFrameRateV1.KeyPress += txtBitRateV1_KeyPress;
            txtFrameRateV2.KeyPress += txtBitRateV1_KeyPress;
            txtFrameRateV3.KeyPress += txtBitRateV1_KeyPress;
            txtFrameRateV4.KeyPress += txtBitRateV1_KeyPress;
            txtCopyFrameV1.KeyPress += txtBitRateV1_KeyPress;
            txtCopyFrameV2.KeyPress += txtBitRateV1_KeyPress;
            txtCopyFrameV3.KeyPress += txtBitRateV1_KeyPress;
            txtCopyFrameV4.KeyPress += txtBitRateV1_KeyPress;
            txtResolucionV1.KeyPress += txtBitRateV1_KeyPress;
            txtResolucionV2.KeyPress += txtBitRateV1_KeyPress;
            txtResolucionV3.KeyPress += txtBitRateV1_KeyPress;
            txtResolucionV4.KeyPress += txtBitRateV1_KeyPress;
            txtCopyResolucionV1.KeyPress += txtBitRateV1_KeyPress;
            txtCopyResolucionV2.KeyPress += txtBitRateV1_KeyPress;
            txtCopyResolucionV3.KeyPress += txtBitRateV1_KeyPress;
            txtCopyResolucionV4.KeyPress += txtBitRateV1_KeyPress;
            */
        }

        private void settingsForm_Load(object sender, EventArgs e)
        {
           
            string bitratev1 = ConfigurationManager.AppSettings["bitrate-v1"];
            /*string bitratev2 = ConfigurationManager.AppSettings["bitrate-v2"];
            string bitratev3 = ConfigurationManager.AppSettings["bitrate-v3"];
            string bitratev4 = ConfigurationManager.AppSettings["bitrate-v4"];*/

            string frameratev1 = ConfigurationManager.AppSettings["framerate-v1"];
            /*string frameratev2 = ConfigurationManager.AppSettings["framerate-v2"];
            string frameratev3 = ConfigurationManager.AppSettings["framerate-v3"];
            string frameratev4 = ConfigurationManager.AppSettings["framerate-v4"];*/

            string resolucionv1 = ConfigurationManager.AppSettings["resolucion-v1"];
            /*string resolucionv2 = ConfigurationManager.AppSettings["resolucion-v2"];
            string resolucionv3 = ConfigurationManager.AppSettings["resolucion-v3"];
            string resolucionv4 = ConfigurationManager.AppSettings["resolucion-v4"];*/

            txtBitRateV1.Text = bitratev1;
            /*txtBitRateV2.Text = bitratev2;
            txtBitRateV3.Text = bitratev3;
            txtBitRateV4.Text = bitratev4;*/

            txtFrameRateV1.Text = frameratev1;
            /*txtFrameRateV2.Text = frameratev2;
            txtFrameRateV3.Text = frameratev3;
            txtFrameRateV4.Text = frameratev4;*/

            txtResolucionV1.Text = resolucionv1;
            /*txtResolucionV2.Text = resolucionv2;
            txtResolucionV3.Text = resolucionv3;
            txtResolucionV4.Text = resolucionv4;*/

            //rchTextBox.Text = "Estos valores representan una calidad un tope de calidad, a partir de estos , la calidad se considerara como 'Muy Buena' calidad.";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Configuration config;
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings["bitrate-v1"].Value = txtBitRateV1.Text;
            /*config.AppSettings.Settings["bitrate-v2"].Value = txtBitRateV2.Text;
            config.AppSettings.Settings["bitrate-v3"].Value = txtBitRateV3.Text;
            config.AppSettings.Settings["bitrate-v4"].Value = txtBitRateV4.Text;*/

            config.AppSettings.Settings["resolucion-v1"].Value = txtResolucionV1.Text;
            /*config.AppSettings.Settings["resolucion-v2"].Value = txtResolucionV2.Text;
            config.AppSettings.Settings["resolucion-v3"].Value = txtResolucionV3.Text;
            config.AppSettings.Settings["resolucion-v4"].Value = txtResolucionV4.Text;*/

            config.AppSettings.Settings["framerate-v1"].Value = txtFrameRateV1.Text;
            /*config.AppSettings.Settings["framerate-v2"].Value = txtFrameRateV2.Text;
            config.AppSettings.Settings["framerate-v3"].Value = txtFrameRateV3.Text;
            config.AppSettings.Settings["framerate-v4"].Value = txtFrameRateV4.Text;*/

            // Guarda los cambios en el archivo de configuración
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        
        private void txtCopyV1_TextChanged(object sender, EventArgs e)
        {
           // txtBitRateV1.Text = txtCopyV1.Text;
        }

        private void txtBitRateV1_TextChanged(object sender, EventArgs e)
        {
            //txtCopyV1.Text = txtBitRateV1.Text;
        }

        private void txtCopyV2_TextChanged(object sender, EventArgs e)
        {
            //txtBitRateV2.Text = txtCopyV2.Text;
        }

        private void txtCopyV3_TextChanged(object sender, EventArgs e)
        {
            //txtBitRateV3.Text = txtCopyV3.Text;
        }

        private void txtCopyV4_TextChanged(object sender, EventArgs e)
        {
            //txtBitRateV4.Text = txtCopyV4.Text;
        }

        private void txtBitRateV2_TextChanged(object sender, EventArgs e)
        {
            //txtCopyV2.Text = txtBitRateV2.Text;
            //if(txtBitRateV3.Text != "")
            //validarNumero(txtBitRateV2,txtBitRateV1,txtBitRateV3);


        }

        private void txtBitRateV3_TextChanged(object sender, EventArgs e)
        {
            //txtCopyV3.Text = txtBitRateV3.Text;
        }

        private void txtBitRateV4_TextChanged(object sender, EventArgs e)
        {
            //txtCopyV4.Text = txtBitRateV4.Text;
        }

        private void txtFrameRateV1_TextChanged(object sender, EventArgs e)
        {
            //txtCopyFrameV1.Text = txtFrameRateV1.Text;
        }
        

        private void txtCopyFrameV1_TextChanged(object sender, EventArgs e)
        {
            //txtFrameRateV1.Text = txtCopyFrameV1.Text;
        }

        private void txtCopyFrameV2_TextChanged(object sender, EventArgs e)
        {
            //txtFrameRateV2.Text = txtCopyFrameV2.Text;
        }

        private void txtCopyFrameV3_TextChanged(object sender, EventArgs e)
        {
            //txtFrameRateV3.Text = txtCopyFrameV3.Text;

        }

        private void txtCopyFrameV4_TextChanged(object sender, EventArgs e)
        {
            //txtFrameRateV4.Text = txtCopyFrameV4.Text;
        }

        private void txtFrameRateV2_TextChanged(object sender, EventArgs e)
        {
            //txtCopyFrameV2.Text = txtFrameRateV2.Text;
        }

        private void txtFrameRateV3_TextChanged(object sender, EventArgs e)
        {
            //txtCopyFrameV3.Text = txtFrameRateV3.Text;
        }

        private void txtFrameRateV4_TextChanged(object sender, EventArgs e)
        {
            //txtCopyFrameV4.Text = txtFrameRateV4.Text;
        }
        
        private void txtResolucionV1_TextChanged(object sender, EventArgs e)
        {
             //txtCopyResolucionV1.Text=txtResolucionV1.Text;
        }

        private void txtResolucionV2_TextChanged(object sender, EventArgs e)
        {
            //txtCopyResolucionV2.Text = txtResolucionV2.Text ;
        }

        private void txtResolucionV3_TextChanged(object sender, EventArgs e)
        {
            //txtCopyResolucionV3.Text=txtResolucionV3.Text;
        }

        private void txtResolucionV4_TextChanged(object sender, EventArgs e)
        {
            //txtCopyResolucionV4.Text = txtResolucionV4.Text;
        }

        private void txtCopyResolucionV1_TextChanged(object sender, EventArgs e)
        {
             //txtResolucionV1.Text = txtCopyResolucionV1.Text;
        }

        private void txtCopyResolucionV2_TextChanged(object sender, EventArgs e)
        {
            //txtResolucionV2.Text = txtCopyResolucionV2.Text;
        }

        private void txtCopyResolucionV3_TextChanged(object sender, EventArgs e)
        {
            //txtResolucionV3.Text = txtCopyResolucionV3.Text;
        }

        private void txtCopyResolucionV4_TextChanged(object sender, EventArgs e)
        {
            //txtResolucionV4.Text = txtCopyResolucionV4.Text;

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
            // Verifica si la tecla presionada es un número o una tecla de control (como Backspace)
           /* if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Si no es un número ni una tecla de control, no permite que se ingrese en el TextBox
                e.Handled = true;
            }*/
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
            //validarNumero(txtBitRateV2,txtBitRateV1, txtBitRateV3);
        }

        private void txtBitRateV3_Leave(object sender, EventArgs e)
        {
            //validarNumero(txtBitRateV3, txtBitRateV2, txtBitRateV4);
        }

        private void txtBitRateV4_Leave(object sender, EventArgs e)
        {
            //validarNumero(txtBitRateV4, txtBitRateV3, null);
        }

        private void txtBitRateV1_Leave(object sender, EventArgs e)
        {
            //validarNumero(txtBitRateV1, null, txtBitRateV2);
        }

        private void txtFrameRateV1_Leave(object sender, EventArgs e)
        {
            //validarNumero(txtFrameRateV1, null, txtFrameRateV2);
        }

        private void txtFrameRateV2_Leave(object sender, EventArgs e)
        {
            //validarNumero(txtFrameRateV2, txtFrameRateV1, txtFrameRateV3);
        }

        private void txtFrameRateV3_Leave(object sender, EventArgs e)
        {
            //validarNumero(txtFrameRateV3, txtFrameRateV2, txtFrameRateV4);
        }

        private void txtFrameRateV4_Leave(object sender, EventArgs e)
        {
            //validarNumero(txtFrameRateV4, txtFrameRateV3, null);
        }

        private void txtResolucionV1_Leave(object sender, EventArgs e)
        {
            //validarNumero(txtResolucionV1, null, txtResolucionV2);
        }

        private void txtResolucionV2_Leave(object sender, EventArgs e)
        {
            //validarNumero(txtResolucionV2, txtResolucionV1, txtResolucionV3);
        }

        private void txtResolucionV3_Leave(object sender, EventArgs e)
        {
            //validarNumero(txtResolucionV3, txtResolucionV2, txtResolucionV4);
        }

        private void txtResolucionV4_Leave(object sender, EventArgs e)
        {
            //validarNumero(txtResolucionV4, txtResolucionV3, null);
        }
    }
}
