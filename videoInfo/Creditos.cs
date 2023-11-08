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
    }
}
