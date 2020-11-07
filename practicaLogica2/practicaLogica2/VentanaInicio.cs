using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practicaLogica2
{
    public partial class VentanaInicio : Form
    {
        public VentanaInicio()
        {
            InitializeComponent();
        }

        private void entra(object sender, EventArgs e)
        {
            button2.Top -= 8;
        }

        private void sale(object sender, EventArgs e)
        {
            button2.Top += 8;
        }

        private void entra1(object sender, EventArgs e)
        {
            button1.Top -= 8;
        }

        private void sale1(object sender, EventArgs e)
        {
            button1.Top += 8;
        }

        private void entra2(object sender, EventArgs e)
        {
            button3.Top -= 8;
        }

        private void sale2(object sender, EventArgs e)
        {
            button3.Top += 8;
        }

        private void clickJugar(object sender, EventArgs e)
        {   
            ventanaLogin ventanaLogin = new ventanaLogin();
            ventanaLogin.Show();
            this.Hide();
        }
    }
}
