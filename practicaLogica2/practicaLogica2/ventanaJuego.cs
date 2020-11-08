using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practicaLogica2
{
    public partial class ventanaJuego : Form
    {
        int xd=11, xi=11, yd=1, yi=1;
        bool vd = false, vi = false;
        public string nombre1, nombre2, nombre3, nombreJugador;

        private void empezar(object sender, EventArgs e)
        {
            button8.Visible = false;
            pintarFichas();
            //prueba para fichas de jugador y de juego
            LSL jugador = new LSL();
            Random r = new Random();

            for (int i = 0; i < 7; i++)
            {
                int dato1, dato2;
                dato1 = r.Next(0, 7);
                dato2 = r.Next(0, 7);

                if(dato1 > dato2)
                {
                    int guardar = dato1;
                    dato1 = dato2;
                    dato2 = guardar;
                }

                Ficha f = new Ficha(dato1, dato2);
                jugador.insertar(f);
                //inserto las imagenes de los botones
                string d1, d2;
                d1 = Convert.ToString(dato1);
                d2 = Convert.ToString(dato2);
                //asignar imagenes
                switch (i)
                {
                    case 0: button1.Image = Image.FromFile("fichas/" + d1 + d2 + ".png"); break;
                    case 1: button2.Image = Image.FromFile("fichas/" + d1 + d2 + ".png"); break;
                    case 2: button3.Image = Image.FromFile("fichas/" + d1 + d2 + ".png"); break;
                    case 3: button4.Image = Image.FromFile("fichas/" + d1 + d2 + ".png"); break;
                    case 4: button5.Image = Image.FromFile("fichas/" + d1 + d2 + ".png"); break;
                    case 5: button6.Image = Image.FromFile("fichas/" + d1 + d2 + ".png"); break;
                    case 6: button7.Image = Image.FromFile("fichas/" + d1 + d2 + ".png"); break;
                    default: break;
                }
            }

        }

        public ventanaJuego(string nombre1, string nombre2, string nombre3, string nombreJugador)
        {
            InitializeComponent();
            label4.Text = nombre1;
            label1.Text = nombre2;
            label2.Text = nombre3;
            label3.Text = nombreJugador;
            pintarFichas();
            /*empezarJuego();creo que acá está listo para hacer el juego*/
        }
        void pintarFichas()
        {
            Graphics h = pictureBox1.CreateGraphics();
            Graphics p = pictureBox2.CreateGraphics();
            Graphics l = pictureBox3.CreateGraphics();
            Image ficha = Image.FromFile("ficha.png");
            Image ficha1 = Image.FromFile("ficha.png");
            ficha1.RotateFlip(RotateFlipType.Rotate90FlipNone);

            for (int i = 0; i < 7; i++)
            {
                h.DrawImage(ficha1, 16,(i * 40));
                l.DrawImage(ficha1, 16,(i * 40));
                p.DrawImage(ficha,(i * 40), 16);

            }
        }
        void pintarFichaJuego(int dato1, int dato2)
        {
            //pintar las fichas en el medio
        }

    }
}
