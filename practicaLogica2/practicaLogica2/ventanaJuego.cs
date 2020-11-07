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
    public partial class ventanaJuego : Form
    {
        public string nombre1, nombre2, nombre3, nombreJugador;
        
        public ventanaJuego(string nombre1, string nombre2, string nombre3, string nombreJugador)
        {
            InitializeComponent();
            label4.Text = nombre1;
            label1.Text = nombre2;
            label2.Text = nombre3;
            label3.Text = nombreJugador;
            Graphics g = juego.CreateGraphics();  
            /*empezarJuego();creo que acá está listo para hacer el juego*/
        }

    }
}
