using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace videoInfo
{
    public partial class Creditos : Form
    {
        public Creditos()
        {
            InitializeComponent();
        }

        private void lblGitHub_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Elzevir01");
        }

        private void label1_Click(object sender, EventArgs e)
        {
            string emailTo = "elzevir01@protonmail.com"; // Dirección de correo del destinatario
            string subject = "Asunto del correo"; // Asunto del correo

            // Abre el cliente de correo electrónico con la dirección de correo predefinida y el asunto
            System.Diagnostics.Process.Start("mailto:" + emailTo + "?subject=" + subject);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.flaticon.es/icono-gratis/email_3178158");
        }

        private void label7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.flaticon.es/icono-gratis/github_2111432");
        }

        private void label8_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.flaticon.es/icono-gratis/engranaje-de-ajuste_11820272");
        }

        private void label9_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.flaticon.es/icono-gratis/portapapeles_4632391");
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.flaticon.es/icono-gratis/actualizar_4067815");
        }

        private void label10_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.flaticon.es/icono-gratis/carpeta_2522061");
        }

        private void label13_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.flaticon.es/icono-gratis/boton-web-de-ayuda_18436");

        }

        private void label14_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.flaticon.es/icono-gratis/cerrar-sesion_4400828");

        }
    }
}
