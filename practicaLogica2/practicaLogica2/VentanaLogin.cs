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
    public partial class ventanaLogin : Form
    {
        public ventanaLogin()
        {
            InitializeComponent();
        }

        private void comenzar(object sender, EventArgs e)
        {

            this.Close();
            ventanaJuego ventana = new ventanaJuego(textBox2.Text, textBox3.Text, textBox4.Text, textBox1.Text);
            ventana.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            VentanaInicio v = new VentanaInicio();
            v.Show();            
        }
    }
}
