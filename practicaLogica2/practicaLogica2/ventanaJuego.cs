using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practicaLogica2
{
    public partial class ventanaJuego : Form
    {
        int xd = 11, xi = 11, yd = 1, yi = 1;       //coordenadas para dibujar la ficha
        public string nombre1, nombre2, nombre3, nombreJugador;  //nombres de los jugadores
        public LSL botones;                        
        int[] puntajes1 = { 0, 0, 0, 0 };           //puntajes totales de la partida
        int[] puntajesronda1 = { 0, 0, 0, 0 };      //puntajes de a ronda
        string[] jugadores;                         //arreglo con los nombres de los jugadores
        LSL fichas1; //lista de fichas
        LSL hugo1;   //listas de cada jugador
        LSL paco1;  
        LSL luis1;
        LSL usted1;
        LDL juego1;                         //lista del juego central (mesa)        
        int actual = 0;                     //variable que define los turnos
        LSL[] turnos1 = new LSL[4];          //lista con los jugadores, será recorrida por actual
        bool[] puede = { true, true, true, true };  //variable de referencia para el caso de nadie puede..
        Button[] buttons = new Button[7];    //lista de botones para acceder rápido a ellos  


        private void empezar(object sender, EventArgs e)
        {
            puede[0] = true;
            puede[1] = true;
            puede[2] = true;
            puede[3] = true;           
            fichas1 = new LSL();
            juego1 = new LDL();
            hugo1 = new LSL();
            paco1 = new LSL();
            luis1 = new LSL();
            usted1 = new LSL();
            turnos1[0] = hugo1;
            turnos1[1] = paco1;
            turnos1[2] = luis1;
            turnos1[3] = usted1;
            buttons[0] = button1;
            buttons[1] = button2;
            buttons[2] = button3;
            buttons[3] = button4;
            buttons[4] = button5;
            buttons[5] = button6;
            buttons[6] = button7;

            for (int i = 0; i < 7; i++)
            {
                for (int f = i; f < 7; f++)
                {
                    ficha x = new ficha(i, f);
                    fichas1.insertar(x);
                }
            }//agrego vaolres a las fichas  
            dialogos.Text = ("Repartiendo...");
            button8.Visible = false;
            this.Update();
            Repartir1(hugo1);//reparto piezas
            Repartir1(paco1);
            Repartir1(luis1);
            Repartir1(usted1);
            dialogos.Text = "";
            Imprimirlistajugadores();
            this.Update();
            Thread.Sleep(2000);

            Empieza1(hugo1);
            if (hugo1.length == 6)
            {
                Console.WriteLine(jugadores[0] + " empezó con el 6-6");
                dialogos.Text = (jugadores[0] + " empezó con el 6-6");
                actual = 1;
                bajart(1);
                pintarFichasPatos(hugo1,1);
                this.Update();
                Thread.Sleep(2000);
            }
            Empieza1(paco1);
            if (paco1.length == 6)
            {
                Console.WriteLine(jugadores[1] + " empezó con el 6-6");
                dialogos.Text = (jugadores[1] + " empezó con el 6-6");
                actual = 2;
                bajart(2);
                pintarFichasPatos(paco1, 2);
                this.Update();
                Thread.Sleep(2000);
            }
            Empieza1(luis1);
            if (luis1.length == 6)
            {
                Console.WriteLine(jugadores[2] + " empezó con el 6-6");
                dialogos.Text = (jugadores[0] + " empezó con el 6-6");
                actual = 3;
                bajart(3);
                pintarFichasPatos(luis1, 3);
                this.Update();
                Thread.Sleep(2000);
            }
            Empieza1(usted1);
            if (usted1.length == 6)
            {
                Console.WriteLine("Usted empezó con el 6-6");
                dialogos.Text = ("Usted empezó con el 6-6");
                actual = 0;
                botones = usted1;
                pintarBotones();
                this.Update();
                Thread.Sleep(2000);
            }

            Console.WriteLine("El juego queda así:");
            imprimirjuego(juego1);
            jugarOponente();
            botonesPosibles();
        }
        public ventanaJuego(string nombre1, string nombre2, string nombre3, string nombreJugador)
        {
            InitializeComponent();
            this.Show();            
            this.Update();            
            jugadores = new string[3];
            jugadores[0] = nombre1;
            jugadores[1] = nombre2;
            jugadores[2] = nombre3;
            label1.Text = nombre1;
            label2.Text = nombre2;
            label3.Text = nombre3;
            label4.Text = nombreJugador;
        }
        public void pintarFichasPatos(LSL lista, int pato)
        {
            this.Update();
            if (pato == 1)
            {
                Graphics h = pictureBox1.CreateGraphics();
                h.Clear(Color.White);
                Image ficha1 = Image.FromFile("ficha.png");
                ficha1.RotateFlip(RotateFlipType.Rotate90FlipNone);
                for (int i = 0; i < lista.length; i++)
                {
                    h.DrawImage(ficha1, 16, (i * 40));
                }
            }
            else if (pato == 2)
            {
                Graphics p = pictureBox2.CreateGraphics();
                p.Clear(Color.White);
                Image ficha = Image.FromFile("ficha.png");
                for (int i = 0; i < lista.length; i++)
                {
                    p.DrawImage(ficha, (i * 40), 16);
                }

            }
            else if (pato == 3)
            {
                Graphics l = pictureBox3.CreateGraphics();
                l.Clear(Color.White);
                Image ficha1 = Image.FromFile("ficha.png");
                ficha1.RotateFlip(RotateFlipType.Rotate90FlipNone);
                for (int i = 0; i < lista.length; i++)
                {
                    l.DrawImage(ficha1, 16, (i * 40));
                }
            }
            this.Update();
        }
        void pintarFichaJuego(int dato1, int dato2,bool comienzo)//acá está la magia
        {
            Graphics j = juego.CreateGraphics();
            Image i = Image.FromFile("fichas/fondoUp.png");
            Image d1 = Image.FromFile("fichas/" + dato1 + ".png");
            Image d2 = Image.FromFile("fichas/" + dato2 + ".png");

            if (comienzo == true)
            {
                if(yi == 1 && xi>2) //si está en el borde superior
                {
                    if(dato1 == dato2)  //si es doble
                    {
                        j.DrawImage(i, (xi-1) * 32, yi * 32 - 16);
                        j.DrawImage(d1, (xi-1) * 32, yi * 32 - 16);
                        j.DrawImage(d2, (xi-1) * 32, yi * 32 + 16);
                        xi -= 1;                        
                    }
                    else    //si no son iguales xd agria papisito
                    {
                        RotateFlipType r = RotateFlipType.Rotate90FlipNone;
                        i.RotateFlip(r);
                        j.DrawImage(i, (xi - 2) * 32, yi * 32);
                        j.DrawImage(d1, (xi - 2) * 32, yi * 32);
                        j.DrawImage(d2, (xi - 1) * 32, yi * 32);
                        xi -= 2;
                    }
                    if(xi <= 2)
                    {
                        yi += 1;
                    }
                    
                }
                else if(xi <= 2 && yi >= 2 && yi <= 7)//borde ziquierdo
                {
                    if(dato1 == dato2) 
                    {
                        RotateFlipType r = RotateFlipType.Rotate90FlipNone;
                        i.RotateFlip(r);
                        j.DrawImage(i, xi * 32-16, yi * 32);
                        j.DrawImage(d2, xi * 32-16, yi * 32);
                        j.DrawImage(d1, xi * 32+16, yi * 32);
                        yi +=1;
                    }
                    else
                    {
                        j.DrawImage(i, xi * 32, yi * 32);
                        j.DrawImage(d2, xi * 32, yi * 32 );
                        j.DrawImage(d1, xi * 32, (yi+1) * 32);
                        yi += 2;
                    }
                    if(yi > 7)
                    {
                        xi +=1;
                    }
                }
                else   //borde inferior
                {
                    yi--;
                    if (dato1 == dato2)
                    {
                        j.DrawImage(i, xi* 32, yi * 32 - 16);
                        j.DrawImage(d2, xi* 32, yi * 32 - 16);
                        j.DrawImage(d1, xi * 32, yi * 32 + 16);
                        xi +=1;
                    }
                    else
                    {
                        RotateFlipType r = RotateFlipType.Rotate90FlipNone;
                        i.RotateFlip(r);
                        j.DrawImage(i, xi* 32, yi * 32);
                        j.DrawImage(d2, xi * 32, yi * 32);
                        j.DrawImage(d1, (xi + 1) * 32, yi * 32);
                        xi += 2;
                    }
                    yi++;
                }

            }//dibujar al lado comienzo
            else 
            {
                if (yd == 1 && xd > 1)//si está en el borde superior
                {
                    if (dato1 == dato2)  //si es doble
                    {
                        j.DrawImage(i, xd * 32, yd * 32 - 16);
                        j.DrawImage(d1, xd * 32, yd * 32 - 16);
                        j.DrawImage(d2, xd * 32, yd * 32 + 16);
                        xd += 1;
                    }
                    else    //si no son iguales xd agria papisito
                    {
                        RotateFlipType r = RotateFlipType.Rotate90FlipNone;
                        i.RotateFlip(r);
                        j.DrawImage(i, xd * 32, yd * 32);
                        j.DrawImage(d1, xd * 32, yd * 32);
                        j.DrawImage(d2, (xd + 1) * 32, yd * 32);
                        xd += 2;
                    }
                    if (xd > 19)
                    {
                        yd++;
                        xd--;
                    }
                }
                else if (yd >= 2 && yd <= 7 && xd >= 19) //borde derecho
                {
                    
                    if(dato2 == dato1)
                    {
                        RotateFlipType r = RotateFlipType.Rotate90FlipNone;
                        i.RotateFlip(r);
                        j.DrawImage(i, xd * 32 - 16, yd * 32);
                        j.DrawImage(d1, xd * 32 - 16, yd * 32);
                        j.DrawImage(d2, xd * 32 + 16, yd * 32);
                        yd += 1;
                    }
                    else
                    {
                        j.DrawImage(i, xd * 32, yd * 32);
                        j.DrawImage(d1, xd * 32, yd * 32);
                        j.DrawImage(d2, xd * 32, (yd + 1) * 32);
                        yd += 2;
                    }
                    
                }
                else
                {
                    yd--;
                    if (dato2 == dato1)
                    {
                        j.DrawImage(i, (xd - 1) * 32, yd * 32 - 16);
                        j.DrawImage(d2, (xd - 1) * 32, yd * 32 - 16);
                        j.DrawImage(d1, (xd - 1) * 32, yd * 32 + 16);
                        xd -= 1;
                    }
                    else
                    {
                        RotateFlipType r = RotateFlipType.Rotate90FlipNone;
                        i.RotateFlip(r);
                        j.DrawImage(i, (xd - 2) * 32, yd * 32);
                        j.DrawImage(d2, (xd - 2) * 32, yd * 32);
                        j.DrawImage(d1, (xd - 1) * 32, yd * 32);
                        xd -= 2;
                    }
                    yd++;
                    
                }
            }//dibujar al lado final
        }
        public void pintarBotones()
        {
            button1.Image = null;
            button2.Image = null;
            button3.Image = null;
            button4.Image = null;
            button5.Image = null;
            button6.Image = null;
            button7.Image = null;
            this.Update();
            NodoSimple p = botones.primerNodo();
            int i = 1;
            do
            {
                ficha f = p.getDato();
                string d1, d2;
                d1 = Convert.ToString(f.getIzquierda());
                d2 = Convert.ToString(f.getDerecha());
                if (f.Izquierda > f.Derecha)
                {
                    f.intercambiar();
                }
                switch (i)
                {
                    case 1:
                        button1.Image = Image.FromFile("fichas/" + d1 + d2 + ".png");
                        Console.WriteLine("pintando un botón"); button1.Text = d1 + d2; break;
                        
                    case 2: button2.Image = Image.FromFile("fichas/" + d1 + d2 + ".png"); Console.WriteLine("pintando un botón"); button2.Text = d1 + d2; break;
                    case 3: button3.Image = Image.FromFile("fichas/" + d1 + d2 + ".png"); Console.WriteLine("pintando un botón"); button3.Text = d1 + d2; break;
                    case 4: button4.Image = Image.FromFile("fichas/" + d1 + d2 + ".png"); Console.WriteLine("pintando un botón"); button4.Text = d1 + d2; break;
                    case 5: button5.Image = Image.FromFile("fichas/" + d1 + d2 + ".png"); Console.WriteLine("pintando un botón"); button5.Text = d1 + d2; break;
                    case 6: button6.Image = Image.FromFile("fichas/" + d1 + d2 + ".png"); Console.WriteLine("pintando un botón"); button6.Text = d1 + d2; break;
                    case 7: button7.Image = Image.FromFile("fichas/" + d1 + d2 + ".png"); Console.WriteLine("pintando un botón"); button7.Text = d1 + d2; break;
                    default:
                        Console.WriteLine("pintando un Culo");
                        break;
                }
                p = p.getLiga();
                i++;
            } while (i <= botones.length);

        }
        public ficha elegir(LSL lista)
        {
            ficha f1 = (ficha)juego1.getPrimero().getDato();
            int comienzo = f1.Izquierda;
            f1 = (ficha)juego1.getUltimo().getDato();
            int final = f1.Derecha;

            int d1 = 0, d2 = 0, indice;
            while (button1.Focused == false || button2.Focused == false || button3.Focused == false ||
                button4.Focused == false || button5.Focused == false || button6.Focused == false ||
                button7.Focused == false)
            {
                Thread.Sleep(5000);
                Console.WriteLine("esperando botón");
            }
            Console.WriteLine("se escogió algo");
            Thread.Sleep(5000);
            return new ficha(d1, d2);
        }
        public void bajart(int pato)
        {
            
        }
        public void msg(string msg)
        {
            dialogos.Update();
            dialogos.Text = msg;
        }
        


        //métodos de pricnipal
        void imprimirlista1(LSL jugador)
        {
            NodoSimple p;
            p = jugador.primerNodo();
            while (p != null)
            {
                ficha f = p.getDato();
                Console.WriteLine(f.Izquierda + " " + f.Derecha);
                p = p.getLiga();
            }
        }
        void imprimirjuego(LDL juego)
        {
            NodoDoble p;
            p = juego.getPrimero();
            while (p != null)
            {
                ficha f = (ficha)p.getDato();
                Console.WriteLine(f.Izquierda + " " + f.Derecha);
                p = p.getld();
            }

        }
        void sumatoria1(int ganarposicion, LSL pierde1, LSL pierde2, LSL pierde3, int[] puntajes)
        {
            NodoSimple p = pierde1.primerNodo();
            while (p != null)
            {
                ficha f = p.getDato();
                puntajes[ganarposicion] += f.Izquierda + f.Derecha;
                p = p.getLiga();
            }
            p = pierde2.primerNodo();
            while (p != null)
            {
                ficha f = p.getDato();
                puntajes[ganarposicion] += f.Izquierda + f.Derecha;
                p = p.getLiga();
            }
            p = pierde3.primerNodo();
            while (p != null)
            {
                ficha f = p.getDato();
                puntajes[ganarposicion] += f.Izquierda + f.Derecha;
                p = p.getLiga();
            }
        }
        void sumatoriapersonal1(LSL jugador, int posicion)
        {
            NodoSimple p = jugador.primerNodo();
            while (p != null)
            {
                ficha f = p.getDato();
                puntajesronda1[posicion] += f.Izquierda + f.Derecha;
                p = p.getLiga();
            }
        }
        void Imprimirlistapuntajes()
        {
            Console.WriteLine("El puntaje de " + jugadores[0] + " es:" + puntajes1[0]);
            Console.WriteLine("El puntaje de " + jugadores[1] + " es:" + puntajes1[1]);
            Console.WriteLine("El puntaje de " + jugadores[2] + " es:" + puntajes1[2]);
            Console.WriteLine("El puntaje de usted es:" + puntajes1[3]);
        }
        void Imprimirlistajugadores()
        {            
            Console.WriteLine("Las fichas de " + jugadores[0] + " son:");
            imprimirlista1(hugo1);
            pintarFichasPatos(hugo1, 1);
            Console.WriteLine("Las fichas de " + jugadores[1] + " son:");
            imprimirlista1(paco1);
            pintarFichasPatos(paco1, 2);
            Console.WriteLine("Las fichas de " + jugadores[2] + " son:");
            imprimirlista1(luis1);
            pintarFichasPatos(luis1, 3);
            Console.WriteLine("Las fichas de usted son:");
            imprimirlista1(usted1);
            botones = usted1;
            pintarBotones();
        }
        void Repartir1(LSL persona)
        {
            for (int i = 0; i < 7; i++)
            {
                var rand = new Random();
                int nuevo = rand.Next(0, fichas1.length); //acá vamos
                NodoSimple p = fichas1.primerNodo();
                for (int k = 0; k < nuevo; k++)
                {
                    p = p.getLiga();
                }
                persona.insertar(p.getDato());
                fichas1.desconectar(p);
                Thread.Sleep(20);
            }            
        }
        void Empieza1(LSL jugador)
        {
            ficha f = new ficha(6, 6);
            if (jugador.existe(f))
            {
                juego1.insertarDerecha(f);
                NodoSimple p = jugador.primerNodo();
                while (p.getDato().Derecha != f.Derecha || p.getDato().Izquierda != f.Izquierda)
                {
                    p = p.getLiga();
                }
                jugador.desconectar(p);
                pintarFichaJuego(6, 6, true);
            }
        }
        public void jugarOponente()
        {            
            while (actual != 3)
            {
                if(puede[0]==false && puede[1] == false && puede[2] == false && puede[3] == false)
                {
                    MessageBox.Show("Nadie puede poner, el ganador será elegido por puntos", "Ronda terminada", MessageBoxButtons.OK);
                    sumarPorPuntos();
                    verJuegoTerminado();
                    if (puntajes1[0] > 101 || puntajes1[1] > 101 || puntajes1[2] > 101 || puntajes1[3] > 101)
                    {
                        break;
                    }
                    Graphics g = juego.CreateGraphics();
                    g.Clear(Color.DarkGreen);
                    xi = 11; xd = 11; yi = 1; yd = 1;
                    button8.Visible = true;
                    return;
                }
                                                       
                int comienzo = juego1.getPrimero().getDato().Izquierda;                
                int final = juego1.getUltimo().getDato().Derecha;
                bool ganador = false;
                bool encontrada = false;
                int i = 0;
                dialogos.Text = "Es el turno de:\n " + jugadores[actual];
                this.Update();
                Thread.Sleep(2000);

                ficha t = new ficha(final, comienzo);
                if (turnos1[actual].existe1(t))
                {
                    NodoSimple p = turnos1[actual].primerNodo();
                    while (encontrada == false && p!=null)
                    {
                        ficha a = p.getDato();
                        if (a.Izquierda == final)
                        {
                            juego1.insertarDerecha(a);
                            pueden();
                            pintarFichaJuego(a.Izquierda, a.Derecha, false);
                            Console.WriteLine(jugadores[actual] + " puso la ficha: " + a.Izquierda +
                                              " " + a.Derecha);
                            encontrada = true;
                            final = a.Derecha;
                            eliminarFichaDeOponente(p.getDato().Izquierda, p.getDato().Derecha);
                            
                            this.Update();
                            if (turnos1[actual].esVacia() == true)
                            {
                                pintarFichasPatos(turnos1[actual], actual + 1);
                                MessageBox.Show(jugadores[actual]+" ganó la ronda actual", "Ronda terminada", MessageBoxButtons.OK);
                                sumarPuntaje();
                                verJuegoTerminado();
                                Graphics g = juego.CreateGraphics();
                                g.Clear(Color.DarkGreen);
                                xi = 11; xd = 11; yi = 1; yd = 1;
                                button8.Visible = true;
                                return;
                                
                            }
                        }
                        else if (a.Derecha == comienzo)
                        {
                            juego1.insertarIzquierda(a);
                            pueden();
                            pintarFichaJuego(a.Izquierda, a.Derecha, true);
                            Console.WriteLine(jugadores[actual] + " puso la ficha: " +
                                                  a.Izquierda + " " + a.Derecha);
                            encontrada = true;
                            comienzo = a.Izquierda;
                            eliminarFichaDeOponente(p.getDato().Izquierda, p.getDato().Derecha);
                            this.Update();
                            if (turnos1[actual].esVacia() == true)
                            {
                                pintarFichasPatos(turnos1[actual], actual + 1);
                                MessageBox.Show(jugadores[actual] + " ganó la ronda actual", "Ronda terminada", MessageBoxButtons.OK);
                                sumarPuntaje();
                                verJuegoTerminado();
                                Graphics g = juego.CreateGraphics();
                                g.Clear(Color.DarkGreen);
                                xi = 11; xd = 11; yi = 1; yd = 1;
                                button8.Visible = true;
                                return;
                                //actualizar puntos, re construir juego xd agriaaa
                            }
                        }                        
                        i++;
                        p = p.getLiga();
                    }
                    //turnos1[actual].desconectar(p);                    
                                        
                    pintarFichasPatos(turnos1[actual], actual+1);
                    this.Update();                   
                }
                else
                {
                    t.Derecha = final;
                    t.Izquierda = comienzo;
                    if (turnos1[actual].existe1(t))
                    {
                        NodoSimple p = turnos1[actual].primerNodo();
                        while (encontrada == false && p!=null)
                        {
                            ficha a = p.getDato();
                            if (a.Derecha == final)
                            {
                                a.intercambiar();
                                juego1.insertarDerecha(a);
                                pueden();
                                pintarFichaJuego(a.Izquierda, a.Derecha, false);
                                Console.WriteLine(jugadores[actual] + " puso la ficha: " + a.Izquierda +
                                                  " " + a.Derecha);
                                encontrada = true;
                                final = a.Derecha;
                                eliminarFichaDeOponente(p.getDato().Izquierda, p.getDato().Derecha);
                                this.Update();
                                if (turnos1[actual].esVacia() == true)
                                {
                                    pintarFichasPatos(turnos1[actual], actual + 1);
                                    MessageBox.Show(jugadores[actual] + " ganó la ronda actual", "Ronda terminada", MessageBoxButtons.OK);
                                    sumarPuntaje();
                                    verJuegoTerminado();
                                    if (puntajes1[0] > 101 || puntajes1[1]>101 || puntajes1[2] > 101|| puntajes1[3] > 101)
                                    {
                                        break;
                                    }
                                    Graphics g = juego.CreateGraphics();
                                    g.Clear(Color.DarkGreen);
                                    xi = 11; xd = 11; yi = 1; yd = 1;
                                    button8.Visible = true;
                                    return;
                                    //actualizar puntos, re construir juego xd agriaaa
                                }
                            }
                            else if (a.Izquierda == comienzo)
                            {
                                a.intercambiar();
                                juego1.insertarIzquierda(a);
                                pueden();
                                pintarFichaJuego(a.Izquierda, a.Derecha, true);
                                Console.WriteLine(jugadores[actual] + " puso la ficha: " +
                                                      a.Izquierda + " " + a.Derecha);
                                encontrada = true;
                                comienzo = a.Izquierda;
                                eliminarFichaDeOponente(p.getDato().Izquierda, p.getDato().Derecha);
                                this.Update();
                                if (turnos1[actual].esVacia() == true)
                                {
                                    pintarFichasPatos(turnos1[actual], actual + 1);
                                    MessageBox.Show(jugadores[actual] + " ganó la ronda actual", "Ronda terminada", MessageBoxButtons.OK);
                                    sumarPuntaje();
                                    verJuegoTerminado();
                                    if (puntajes1[0] > 101 || puntajes1[1] > 101 || puntajes1[2] > 101 || puntajes1[3] > 101)
                                    {
                                        break;
                                    }

                                    Graphics g = juego.CreateGraphics();
                                    g.Clear(Color.DarkGreen);
                                    xi = 11; xd = 11; yi = 1; yd = 1;
                                    button8.Visible = true;
                                    return;
                                    //actualizar puntos, re construir juego xd agriaaa
                                }
                            }                            
                            i++;
                            p = p.getLiga();
                        }                        
                        
                        pintarFichasPatos(turnos1[actual], actual+1);
                        this.Update();
                    }
                    else
                    {
                        
                        puede[actual] = false;
                    }
                }
                actual++;                
            }
            botonesPosibles();
            dialogos.Text = "Es el turno de usted";

        }
        public void jugarJugador(int d1,int d2)
        {            
            ficha e = new ficha(d1, d2);
            ficha e1 = new ficha(d2, d1);
            if(usted1.existe(e))
            {
                NodoSimple p = usted1.primerNodo();
                while(p!=null)
                {
                    if(d1 == p.getDato().Izquierda && d2 == p.getDato().Derecha)
                    {
                        usted1.desconectar(p);break;
                    }
                    p = p.getLiga();
                }
            }
            else if(usted1.existe(e1))
            {
                NodoSimple p = usted1.primerNodo();
                while (p != null)
                {
                    if (d2 == p.getDato().Izquierda && d1 == p.getDato().Derecha)
                    {
                        usted1.desconectar(p); break;
                    }
                    p = p.getLiga();
                }
            }

            if (usted1.esVacia() == true)
            {
                MessageBox.Show("Usted ganó la ronda actual", "Ronda terminada", MessageBoxButtons.OK);
                sumarPuntaje();
                verJuegoTerminado();                
                Graphics g = juego.CreateGraphics();
                g.Clear(Color.DarkGreen);
                xi = 11;xd = 11;yi = 1;yd = 1;
                button8.Visible = true;
                return;
                //actualizar puntos, re construir juego xd agriaaa
            }
            this.Update();
            pintarBotones();
            actual = 0;
            pueden();
            jugarOponente();            
        }
        public void botonesPosibles()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            NodoSimple p = botones.primerNodo();            
            int i = 1;
            int c, f;
            c = juego1.getPrimero().getDato().Izquierda;
            f = juego1.getUltimo().getDato().Derecha;
            bool nimodo = false;
            do
            {
                ficha a = p.getDato();
                int d1 = a.Izquierda;
                int d2 = a.Derecha;
                
                if (d1 == c || d1 == f || d2 == c || d2 == f)
                {                    
                    nimodo = true;
                    switch (i)
                    {
                        case 1: button1.Enabled = true;break;
                        case 2: button2.Enabled = true; break;
                        case 3: button3.Enabled = true; break;
                        case 4: button4.Enabled = true; break;
                        case 5: button5.Enabled = true; break;
                        case 6: button6.Enabled = true; break;
                        case 7: button7.Enabled = true; break;
                        default:
                            break;
                    }
                }                
                p = p.getLiga();
                i++;
            } while (i <= botones.length);
            if(nimodo == false)
            {
                dialogos.Text = "No tiene fichas\ndisponibles";
                puede[3] = false;
                actual = 0;
                jugarOponente();
            }
        }
        public void eliminarFichaDeOponente(int d1, int d2)
        {
            ficha e = new ficha(d1, d2);
            ficha e1 = new ficha(d2, d1);
            if (turnos1[actual].existe(e))
            {
                NodoSimple p = turnos1[actual].primerNodo();
                while (p != null)
                {
                    if (d1 == p.getDato().Izquierda && d2 == p.getDato().Derecha)
                    {
                        turnos1[actual].desconectar(p); break;
                    }
                    p = p.getLiga();
                }
            }
            else if (turnos1[actual].existe(e1))
            {
                NodoSimple p = turnos1[actual].primerNodo();
                while (p != null)
                {
                    if (d2 == p.getDato().Izquierda && d1 == p.getDato().Derecha)
                    {
                        turnos1[actual].desconectar(p); break;
                    }
                    p = p.getLiga();
                }
            }
            imprimirlista1(turnos1[actual]);
            this.Update();
        }
        public void pueden()
        {
            puede[0] = true;
            puede[1] = true;
            puede[2] = true;
            puede[3] = true;
        }
        public void sumarPuntaje()
        {
            if (actual == 0)
            {
                sumatoria1(actual, turnos1[1], turnos1[2], turnos1[3], puntajes1);
            }
            else if (actual == 1)
            {
                sumatoria1(actual, turnos1[0], turnos1[2], turnos1[3], puntajes1);
            }
            else if (actual == 2)
            {
                sumatoria1(actual, turnos1[0], turnos1[1], turnos1[3], puntajes1);
            }
            else if(actual == 3)
            {
                sumatoria1(actual, turnos1[0], turnos1[1], turnos1[2], puntajes1);
            }
            dialogos.Text = (jugadores[0] + "   "+jugadores[1]+"   "+jugadores[2]+"   "+"Usted \n"+
                puntajes1[0] + "        " + puntajes1[1] + "        " + puntajes1[2] + "        " + puntajes1[3]);
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            //no hace nada pero no se puede borrar
        }

        public void sumarPorPuntos()
        {
            sumatoriapersonal1(hugo1, 0);
            sumatoriapersonal1(paco1, 0);
            sumatoriapersonal1(luis1, 0);
            sumatoriapersonal1(usted1, 0);
            int menor = 0;
            for(int i = 1; i <=3 ; i++)
            {
                if(puntajesronda1[i] < puntajesronda1[menor])
                {
                    menor = i;
                }
            }            
            for(int i = 0; i < 4; i++)
            {
                puntajes1[menor] += puntajesronda1[i] - puntajesronda1[menor];
            }

            msg(puntajes1[0] + "  " + puntajes1[1] + "  " + puntajes1[2] + "  " + puntajes1[3]);
        }
        public void verJuegoTerminado()
        {
            if (puntajes1[0] > 101)
            {                
                MessageBox.Show("PartidaTerminada, el ganador es " + jugadores[0]);
                this.Close();
                ventanaLogin v = new ventanaLogin();
                v.Show();
            }
            else if (puntajes1[1] > 101)
            {                
                MessageBox.Show("PartidaTerminada, el ganador es " + jugadores[1]);
                this.Close();
                ventanaLogin v = new ventanaLogin();
                v.Show();
                
            }
            else if (puntajes1[2] > 101)
            {
                MessageBox.Show("PartidaTerminada, el ganador es " + jugadores[2]);
                this.Close();
                ventanaLogin v = new ventanaLogin();
                v.Show();
                
            }
            else if (puntajes1[3] > 101)
            {
                MessageBox.Show("PartidaTerminada, el ganador es usted\nFelicitaciones!");
                this.Close();
                ventanaLogin v = new ventanaLogin();
                v.Show();                
            }
        }


        //eventos para la elección de la pieza del usuario
        private void button10_Click(object sender, EventArgs e)
        {
            button9.Visible = false;
            button10.Visible = false;
            apagarBotones();
            int d1 = Convert.ToInt32(Convert.ToString(button10.Text[0]));
            int d2 = Convert.ToInt32(Convert.ToString(button10.Text[1]));
            int comienzo = juego1.getPrimero().getDato().Izquierda;
            int final = juego1.getUltimo().getDato().Derecha;
            ficha f = new ficha(d1, d2);
            if (d1 == final)
            {
                juego1.insertarDerecha(f);
                pueden();
                pintarFichaJuego(d1, d2, false);
            }
            else if (d2 == final)
            {
                f.intercambiar();
                juego1.insertarDerecha(f);
                pueden();
                pintarFichaJuego(d2, d1, false);
            }
            this.Update();
            jugarJugador(d1, d2);     
        }
        private void button9_Click(object sender, EventArgs e)
        {
            button9.Visible = false;
            button10.Visible = false;
            apagarBotones();
            int d1 = Convert.ToInt32(Convert.ToString(button9.Text[0]));
            int d2 = Convert.ToInt32(Convert.ToString(button9.Text[1]));
            int comienzo = juego1.getPrimero().getDato().Izquierda;
            int final = juego1.getUltimo().getDato().Derecha;
            ficha f = new ficha(d1, d2);
            if (d2 == comienzo)
            {
                juego1.insertarIzquierda(f);
                pueden();
                pintarFichaJuego(d1, d2, true);
            }
            else if(d1 == comienzo)
            {
                f.intercambiar();
                juego1.insertarIzquierda(f);
                pueden();
                pintarFichaJuego(d2, d1, true);
            }
            this.Update();
            jugarJugador(d1,d2);
        }
        private void piezaElegida(object sender, EventArgs e)
        {
            Console.WriteLine("Entré");
            button9.Visible = false;
            button10.Visible = false;
            Button b=buttons[0];
            int i = 0;
            while(b.ContainsFocus == false && i < 7)
            {
                i++;
                b = buttons[i];
            }
            
            int d1, d2, comienzo, final;
            d1 = Convert.ToInt32(Convert.ToString(b.Text[0]));
            d2 = Convert.ToInt32(Convert.ToString(b.Text[1]));
            comienzo = juego1.getPrimero().getDato().Izquierda;
            final = juego1.getUltimo().getDato().Derecha;

            if(d1==comienzo || d2 == comienzo)
            {
                button9.Visible = true;
                button9.Text = b.Text;
            }
            if(d1==final || d2 == final)
            {
                button10.Visible = true;
                button10.Text = b.Text;
            }
        }
        public void apagarBotones()
        {
            for (int i= 0; i < buttons.Length; i++)
            {
                buttons[i].Enabled = false;
            }
        }
    }
}
