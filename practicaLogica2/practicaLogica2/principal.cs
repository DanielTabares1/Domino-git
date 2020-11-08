using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicaLogica2
{
    class principal
    {
        public static void principal1()
        {
            // Create a list of fichas.
            LSL fichas1 = new LSL();
            //List<ficha> fichas = new List<ficha>();  
            // Add fichas to the list.

            for (int i = 0; i < 7; i++)
            {
                for (int f = i; f < 7; f++)
                {
                    ficha x = new ficha(i, f);
                    fichas1.insertar(x);                    
                }
            }

            /*for (int i = 0; i < 7; i++)    
            {
                for (int f = i; f < 7; f++)
                {
                    fichas.Add(new ficha { Izquierda = i, Derecha = f });
                }
            }*/

            int[] puntajes1 = { 0, 0, 0, 0 };
            int[] puntajesronda1 = { 0, 0, 0, 0 };

            //List<int> puntajes = new List<int> { 0, 0, 0, 0 };
            //List<int> puntajesronda = new List<int> { 0, 0, 0, 0 };

            void imprimirlista1(LSL jugador)
            {
                NodoSimple p;
                p = jugador.primerNodo();
                while (p != null)
                {
                    ficha f = (ficha)p.getDato();
                    Console.WriteLine(f.Izquierda + " " + f.Derecha);
                }
                p = p.getLiga();
            }
            void imprimirjuego(LDL juego)
            {
                NodoDoble p;
                p = juego.getPrimero();
                while (p != null)
                {
                    ficha f = (ficha)p.getDato();
                    Console.WriteLine(f.Izquierda + " " + f.Derecha);
                }
                p = p.getld();
            }
            /*void imprimirlista(List<ficha> jugador)
            {
                foreach (ficha f in jugador)
                {
                    Console.WriteLine((f.Izquierda).ToString() + (f.Derecha).ToString());
                }
            }*/
            void sumatoria1(int ganarposicion, LSL pierde1, LSL pierde2, LSL pierde3,
                int[] puntajes)
            {
                NodoSimple p = pierde1.primerNodo();
                while (p != null)
                {
                    ficha f = (ficha)p.getDato();
                    puntajes[ganarposicion] += f.Izquierda + f.Derecha;
                    p = p.getLiga();
                }
                p = pierde2.primerNodo();
                while (p != null)
                {
                    ficha f = (ficha)p.getDato();
                    puntajes[ganarposicion] += f.Izquierda + f.Derecha;
                    p = p.getLiga();
                }
                p = pierde3.primerNodo();
                while (p != null)
                {
                    ficha f = (ficha)p.getDato();
                    puntajes[ganarposicion] += f.Izquierda + f.Derecha;
                    p = p.getLiga();
                }

                
            }
            /*void sumatoria(int ganarposicion, List<ficha> pierde1, List<ficha> pierde2, List<ficha> pierde3,
                List<int> puntajes)
            {
                foreach (ficha f in pierde1)
                {
                    puntajes[ganarposicion] += f.Izquierda + f.Derecha;
                }

                foreach (ficha f in pierde2)
                {
                    puntajes[ganarposicion] += f.Izquierda + f.Derecha;
                }

                foreach (ficha f in pierde3)
                {
                    puntajes[ganarposicion] += f.Izquierda + f.Derecha;
                }
            }*/

            void sumatoriapersonal1(LSL jugador, int posicion)
            {
                NodoSimple p = jugador.primerNodo();
                while(p!= null)
                {
                    ficha f = (ficha)p.getDato();
                    puntajesronda1[posicion] += f.Izquierda + f.Derecha;
                    p = p.getLiga();
                }
            }
            /*void sumatoriapersonal(List<ficha> jugador, int posicion)
            {
                foreach (ficha f in jugador)
                {
                    puntajesronda[posicion] += f.Izquierda + f.Derecha;
                }
            }*/

            string jugador0 = "Hugo";
            string jugador1 = "Paco";
            string jugador2 = "Luis";
            Console.WriteLine("Por defecto los nombres son Hugo, Paco y Luis.");
            Console.WriteLine(
                "¿Desea cambiar los nombres de los jugadores?, en caso afirmativo digite 'si', de lo contrario digite cualquier cosa:");
            string cambiarnombres = (Console.ReadLine());
            if (cambiarnombres == "si")
            {
                Console.WriteLine("Ingrese los tres nombres separados por enter:");
                jugador0 = (Console.ReadLine());
                jugador1 = (Console.ReadLine());
                jugador2 = (Console.ReadLine());
            }

            //Ahora creamos el metodo "Repartir", el cual toma 7 objetos aleatoriamente de la lista "fichas", los reparte a la persona y los elimina de la lista de fichas.


            string[] jugadores = { jugador0, jugador1, jugador2 };

            void Imprimirlistapuntajes()
            {
                Console.WriteLine("El puntaje de " + jugador0 + " es:" + puntajes1[0]);
                Console.WriteLine("El puntaje de " + jugador1 + " es:" + puntajes1[1]);
                Console.WriteLine("El puntaje de " + jugador2 + " es:" + puntajes1[2]);
                Console.WriteLine("El puntaje de usted es:" + puntajes1[3]);
            }


            while (puntajes1[0] < 101 && puntajes1[1] < 101 && puntajes1[2] < 101 && puntajes1[3] < 101)
            {
                fichas1 = new LSL();
                // Add fichas to the list.
                for (int i = 0; i < 7; i++)
                {
                    for (int f = i; f < 7; f++)
                    {
                        ficha x = new ficha(i, f);
                        fichas1.insertar(x);                        
                    }
                }

                LSL hugo1 = new LSL();
                LSL paco1 = new LSL();
                LSL luis1 = new LSL();
                LSL usted1 = new LSL();
                /*List<ficha> hugo = new List<ficha>();
                List<ficha> paco = new List<ficha>();
                List<ficha> luis = new List<ficha>();
                List<ficha> usted = new List<ficha>();*/

                void Imprimirlistajugadores()
                {
                    Console.WriteLine("Las fichas de " + jugador0 + " son:");
                    imprimirlista1(hugo1);
                    Console.WriteLine("Las fichas de " + jugador1 + " son:");
                    imprimirlista1(paco1);
                    Console.WriteLine("Las fichas de " + jugador2 + " son:");
                    imprimirlista1(luis1);
                    Console.WriteLine("Las fichas de usted son:");
                    imprimirlista1(usted1);
                }

                void Repartir1(LSL persona)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        var rand = new Random();
                        int nuevo = rand.Next(0, fichas1.length); //acá vamos
                        NodoSimple p = fichas1.primerNodo();
                        for(int k = 0; k < nuevo; k++)
                        {
                            p = p.getLiga();
                        }
                        persona.insertar(p);
                        fichas1.desconectar(p);                        
                    }
                }
                /*void Repartir(List<ficha> persona)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        var rand = new Random();
                        int nuevo = rand.Next(0, (fichas.Count));
                        persona.Add(fichas.ElementAt(nuevo));
                        fichas.RemoveAt(nuevo);
                    }
                }*/

                Repartir1(hugo1);
                Repartir1(paco1);
                Repartir1(luis1);
                Repartir1(usted1);
                Imprimirlistajugadores();
                LDL juego1 = new LDL();
                LSL posible1 = new LSL();
                //List<ficha> juego = new List<ficha>();
                //List<ficha> posible = new List<ficha>();
                int actual = 0;
                LSL[] turnos1 = { hugo1, paco1, luis1, usted1 };
                //List<ficha>[] turnos = new List<ficha>[4] { hugo, paco, luis, usted };
                bool[] puede = { true, true, true, true };
                //List<bool> puede = new List<bool> { true, true, true, true };

                //Creamos el metodo que determina quien tiene el 6,6 y debe empezar.
                void Empieza1(LSL jugador)
                {
                    ficha f = new ficha(6, 6);
                    if (jugador.existe(f))
                    {
                        juego1.insertarDerecha(f);
                        NodoSimple p = jugador.primerNodo();
                        while (!p.getDato().Equals(f))
                        {
                            p = p.getLiga();
                        }
                        jugador.desconectar(p);                        
                    }
                }
                /*void Empieza(List<ficha> jugador)
                {
                    if (jugador.Exists(x => (x.Derecha == 6 && x.Izquierda == 6)))
                    {
                        juego.Add(new ficha { Derecha = 6, Izquierda = 6 });
                        jugador.RemoveAll(x => (x.Derecha == 6 && x.Izquierda == 6));
                    }
                }*/

                Empieza1(hugo1);
                if (hugo1.length == 6)
                {
                    Console.WriteLine(jugador0 + " empezó con el 6-6");
                    actual = 1;
                }

                Empieza1(paco1);
                if (paco1.length == 6)
                {
                    Console.WriteLine(jugador1 + " empezó con el 6-6");
                    actual = 2;
                }

                Empieza1(luis1);
                if (luis1.length == 6)
                {
                    Console.WriteLine(jugador2 + " empezó con el 6-6");
                    actual = 3;
                }

                Empieza1(usted1);
                if (usted1.length == 6)
                {
                    Console.WriteLine("Usted empezó con el 6-6");
                    actual = 0;
                }

                Console.WriteLine("El juego queda así:");
                imprimirjuego(juego1);


                ficha f1 = (ficha)juego1.getPrimero().getDato();
                int comienzo = f1.Izquierda;
                f1 = (ficha)juego1.getUltimo().getDato();
                int final = f1.Derecha;
                //int comienzo = juego1[0].Izquierda;
                //int final = juego[juego.Count - 1].Derecha;
                bool ganador = false;


                while ((puede[0] || puede[1] || puede[2] || puede[3]) &&
                       (hugo1.length > 0 && paco1.length > 0 && luis1.length > 0 && usted1.length > 0))
                {
                    Imprimirlistajugadores();
                    if (actual != 3)
                    {
                        bool encontrada = false;
                        int i = 0;

                        Console.WriteLine("Es el turno de: " + jugadores[actual]);
                        Console.WriteLine("Por la derecha puede poner fichas que tengan: " + comienzo);
                        Console.WriteLine("Por la izquierda puede poner fichas que tengan: " + final);

                        ficha e = new ficha(final, comienzo);
                        if (turnos1[actual].existe1(e))
                        {
                            NodoSimple p = turnos1[actual].primerNodo();
                            while(encontrada == false && i < (turnos1[actual].length - 1))
                            {
                                ficha a = (ficha)p.getDato();
                                if(a.Izquierda == final)
                                {
                                    juego1.insertarDerecha(a);
                                    Console.WriteLine(jugadores[actual] + " puso la ficha: " + a.Izquierda +
                                                      " " + a.Derecha);
                                    encontrada = true;
                                    final = a.Derecha;
                                    
                                }

                                else if(a.Derecha == comienzo)
                                {
                                    juego1.insertarIzquierda(a);
                                    Console.WriteLine(jugadores[actual] + " puso la ficha: " +
                                                          a.Izquierda + " " + a.Derecha);
                                    encontrada = true;
                                    comienzo = a.Izquierda;
                                }
                                i++;
                                p = p.getLiga();
                            }
                            turnos1[actual].desconectar(p);
                            Console.WriteLine("El juego esta así:");
                            imprimirjuego(juego1);

                            if (turnos1[actual].length > 1)
                            {                                
                                puede[0] = true;
                                puede[1] = true;
                                puede[2] = true;
                                puede[3] = true;
                            }
                            else
                            {
                                puede[actual] = false;
                                Console.WriteLine("El jugador " + jugadores[actual] + " ganó (dominó) esta ronda.");
                                if (actual == 0)
                                {
                                    sumatoria1(actual, turnos1[1], turnos1[2], turnos1[3], puntajes1);
                                }

                                if (actual == 1)
                                {
                                    sumatoria1(actual, turnos1[0], turnos1[2], turnos1[3], puntajes1);
                                }

                                if (actual == 2)
                                {
                                    sumatoria1(actual, turnos1[0], turnos1[1], turnos1[3], puntajes1);
                                }
                                Imprimirlistapuntajes();
                                ganador = true;
                            }
                        }
                        else
                        {
                            e.Derecha = final;
                            e.Izquierda = comienzo;
                            if (turnos1[actual].existe1(e))
                            {
                                NodoSimple p = turnos1[actual].primerNodo();
                                while (encontrada == false && i < (turnos1[actual].length - 1))
                                {
                                    ficha a = (ficha)p.getDato();
                                    if (a.Derecha == final)
                                    {
                                        a.intercambiar();
                                        juego1.insertarDerecha(a);
                                        Console.WriteLine(jugadores[actual] + " puso la ficha: " + a.Izquierda +
                                                          " " + a.Derecha);
                                        encontrada = true;
                                        final = a.Derecha;
                                    }
                                    else if (a.Izquierda == comienzo)
                                    {
                                        a.intercambiar();
                                        juego1.insertarIzquierda(a);
                                        Console.WriteLine(jugadores[actual] + " puso la ficha: " +
                                                              a.Izquierda + " " + a.Derecha);
                                        encontrada = true;
                                        comienzo = a.Izquierda;
                                    }
                                    i++;
                                    p = p.getLiga();
                                }
                                turnos1[actual].desconectar(p);
                                Console.WriteLine("El juego esta así:");
                                imprimirjuego(juego1);

                                if (turnos1[actual].length > 1)
                                {
                                    puede[0] = true;
                                    puede[1] = true;
                                    puede[2] = true;
                                    puede[3] = true;
                                }
                                else
                                {
                                    puede[actual] = false;
                                    Console.WriteLine("El jugador " + jugadores[actual] + " ganó (dominó) esta ronda.");
                                    if (actual == 0)
                                    {
                                        sumatoria1(actual, turnos1[1], turnos1[2], turnos1[3], puntajes1);
                                    }

                                    if (actual == 1)
                                    {
                                        sumatoria1(actual, turnos1[0], turnos1[2], turnos1[3], puntajes1);
                                    }

                                    if (actual == 2)
                                    {
                                        sumatoria1(actual, turnos1[0], turnos1[1], turnos1[3], puntajes1);
                                    }
                                    Imprimirlistapuntajes();
                                    ganador = true;
                                }
                            }
                            else
                            {
                                Console.WriteLine("El jugador no tiene fichas para poner");
                                Console.WriteLine("El juego esta así:");
                                imprimirjuego(juego1);
                                puede[actual] = false;
                            }                       

                        }


                        /*if (turnos1[actual].existe(x => (x.Izquierda == final || x.Derecha == comienzo)))//vieja
                        {
                            while (encontrada == false && i < (turnos[actual].Count - 1))
                            {
                                if ((turnos[actual][i].Izquierda) == final)
                                {
                                    juego.Add(new ficha
                                    { Izquierda = turnos[actual][i].Izquierda, Derecha = turnos[actual][i].Derecha });
                                    Console.WriteLine(jugadores[actual] + " puso la ficha: " + turnos[actual][i].Izquierda +
                                                      " " + turnos[actual][i].Derecha);
                                    encontrada = true;
                                    final = turnos[actual][i].Derecha;
                                }
                                else
                                {
                                    if ((turnos[actual][i].Derecha) == comienzo)
                                    {
                                        juego.Insert(0,
                                            new ficha
                                            {
                                                Izquierda = turnos[actual][i].Izquierda,
                                                Derecha = turnos[actual][i].Derecha
                                            });
                                        Console.WriteLine(jugadores[actual] + " puso la ficha: " +
                                                          turnos[actual][i].Izquierda + " " + turnos[actual][i].Derecha);
                                        encontrada = true;
                                        comienzo = turnos[actual][i].Izquierda;
                                    }
                                }

                                i = i + 1;
                            } //borrar

                            if (turnos[actual].Count > 1)
                            {
                                turnos[actual].RemoveAt(i - 1);
                                Console.WriteLine("El juego esta así:");
                                imprimirlista(juego);
                                puede[0] = true;
                                puede[1] = true;
                                puede[2] = true;
                                puede[3] = true;
                            }
                            else
                            {
                                if ((turnos[actual][0].Izquierda) == final)
                                {
                                    juego.Add(new ficha
                                    { Izquierda = turnos[actual][0].Izquierda, Derecha = turnos[actual][0].Derecha });
                                }

                                if ((turnos[actual][0].Derecha) == comienzo)
                                {
                                    juego.Insert(0,
                                        new ficha
                                        {
                                            Izquierda = turnos[actual][0].Izquierda,
                                            Derecha = turnos[actual][0].Derecha
                                        });
                                }

                                Console.WriteLine(jugadores[actual] + " puso la ficha: " + turnos[actual][0].Izquierda +
                                                  " " + turnos[actual][0].Derecha);
                                Console.WriteLine("El juego esta así:");
                                imprimirlista(juego);
                                turnos[actual].Clear();
                                puede[actual] = false;
                                Console.WriteLine("El jugador " + jugadores[actual] + " ganó (dominó) esta ronda.");
                                if (actual == 0)
                                {
                                    sumatoria(actual, turnos[1], turnos[2], turnos[3], puntajes);
                                }

                                if (actual == 1)
                                {
                                    sumatoria(actual, turnos[0], turnos[2], turnos[3], puntajes);
                                }

                                if (actual == 2)
                                {
                                    sumatoria(actual, turnos[0], turnos[1], turnos[3], puntajes);
                                }

                                Imprimirlistapuntajes();
                                ganador = true;
                            }
                        }
                        else
                        {
                            if (turnos[actual].Exists(x => (x.Izquierda == comienzo || x.Derecha == final)))
                            {
                                while (encontrada == false && i < (turnos[actual].Count - 1))
                                {
                                    if ((turnos[actual][i].Derecha) == final)
                                    {
                                        juego.Add(new ficha
                                        { Izquierda = turnos[actual][i].Derecha, Derecha = turnos[actual][i].Izquierda });
                                        Console.WriteLine(jugadores[actual] + " puso la ficha: " +
                                                          turnos[actual][i].Derecha + " " + turnos[actual][i].Izquierda);
                                        encontrada = true;
                                        final = turnos[actual][i].Izquierda;
                                    }
                                    else
                                    {
                                        if ((turnos[actual][i].Izquierda) == comienzo)
                                        {
                                            juego.Insert(0,
                                                new ficha
                                                {
                                                    Izquierda = turnos[actual][i].Derecha,
                                                    Derecha = turnos[actual][i].Izquierda
                                                });
                                            Console.WriteLine(jugadores[actual] + " puso la ficha: " +
                                                              turnos[actual][i].Derecha + " " +
                                                              turnos[actual][i].Izquierda);
                                            encontrada = true;
                                            comienzo = turnos[actual][i].Derecha;
                                        }
                                    }

                                    i = i + 1;
                                }

                                if (turnos[actual].Count > 1)
                                {
                                    turnos[actual].RemoveAt(i - 1);
                                    Console.WriteLine("El juego esta así:");
                                    imprimirlista(juego);
                                    puede[0] = true;
                                    puede[1] = true;
                                    puede[2] = true;
                                    puede[3] = true;
                                }
                                else
                                {
                                    if ((turnos[actual][0].Derecha) == final)
                                    {
                                        juego.Add(new ficha
                                        { Izquierda = turnos[actual][i].Derecha, Derecha = turnos[actual][i].Izquierda });
                                    }
                                    else
                                    {
                                        if ((turnos[actual][i].Izquierda) == comienzo)
                                        {
                                            juego.Insert(0,
                                                new ficha
                                                {
                                                    Izquierda = turnos[actual][i].Derecha,
                                                    Derecha = turnos[actual][i].Izquierda
                                                });
                                        }
                                    }

                                    Console.WriteLine(jugadores[actual] + " puso la ficha: " + turnos[actual][i].Derecha +
                                                      " " + turnos[actual][i].Izquierda);
                                    Console.WriteLine("El juego esta así:");
                                    imprimirlista(juego);
                                    turnos[actual].Clear();
                                    puede[actual] = false;
                                    Console.WriteLine("El jugador " + jugadores[actual] + " ganó (dominó) esta ronda.");
                                    if (actual == 0)
                                    {
                                        sumatoria(actual, turnos[1], turnos[2], turnos[3], puntajes);
                                    }

                                    if (actual == 1)
                                    {
                                        sumatoria(actual, turnos[0], turnos[2], turnos[3], puntajes);
                                    }

                                    if (actual == 2)
                                    {
                                        sumatoria(actual, turnos[0], turnos[1], turnos[3], puntajes);
                                    }

                                    Imprimirlistapuntajes();
                                    ganador = true;
                                }
                            }
                            else
                            {
                                Console.WriteLine("El jugador no tiene fichas para poner");
                                Console.WriteLine("El juego esta así:");
                                imprimirlista(juego);
                                puede[actual] = false;
                            }
                        }*/

                        actual += 1;
                    }

                    if ((actual == 3) && (hugo1.length > 0 && paco1.length > 0 && luis1.length > 0))
                    {
                        Console.WriteLine("El juego esta así:");
                        imprimirjuego(juego1);
                        Imprimirlistajugadores();

                        bool encontrada = false;
                        Console.WriteLine("Es el turno de: Usted");
                        Console.WriteLine("Por la derecha puede poner fichas que tengan: " + comienzo);
                        Console.WriteLine("Por la izquierda puede poner fichas que tengan: " + final);
                        ficha e = new ficha(final, comienzo);
                        ficha e1 = new ficha(comienzo, final);
                        if(turnos1[actual].existe1(e) || turnos1[actual].existe1(e1))
                        {
                            int i = 0;
                            NodoSimple p = turnos1[actual].primerNodo();
                            while (i < (turnos1[actual].length))
                            {
                                ficha a = (ficha)p.getDato();
                                if(a.Izquierda == final || a.Derecha == comienzo)
                                {
                                    posible1.insertar(a);
                                }
                                i = i + 1;                               

                            }
                            i = 0;
                            while(i < (turnos1[actual].length))
                            {
                                ficha a = (ficha)p.getDato();
                                a.intercambiar();
                                if (a.Izquierda == final || a.Derecha == comienzo)
                                {
                                    if (posible1.existe(a) == false)
                                    {
                                        posible1.insertar(a);
                                    }                                    
                                }
                                i = i + 1;
                            }

                            Console.WriteLine("Sus opciones son las siguientes:");
                            imprimirlista1(posible1);
                            Console.WriteLine("Ingrese su elección de ficha con cada numero separado por enter");
                            while(encontrada == false)
                            {
                                int posibleizquierda = Convert.ToInt32(Console.ReadLine());
                                int posiblederecha = Convert.ToInt32(Console.ReadLine());
                               
                                ficha b = new ficha(posibleizquierda, posiblederecha);
                                if (posible1.existe(b))
                                {
                                    while(encontrada == false)
                                    {
                                        if(posibleizquierda == final)
                                        {
                                            juego1.insertarDerecha(b);
                                            Console.WriteLine("Usted puso la ficha: " + posibleizquierda + " " +
                                                                  posiblederecha);
                                            final = posiblederecha;
                                            encontrada = true;
                                            NodoSimple q = usted1.primerNodo();
                                            for (i = 0; i < usted1.length; i++)
                                            {
                                                ficha q1 = (ficha)q.getDato();
                                                if (q.getDato().Equals(b))
                                                {
                                                    usted1.desconectar(q);
                                                }
                                                else 
                                                {
                                                    q1.intercambiar();
                                                    if (q1.Equals(b))
                                                    {
                                                        usted1.desconectar(q);
                                                    }
                                                } 
                                            }
                                        }
                                        else if(posiblederecha == comienzo)
                                        {
                                            juego1.insertarIzquierda(b);
                                            Console.WriteLine("Usted puso la ficha: " + posibleizquierda + " " +
                                                                  posiblederecha);
                                            encontrada = true;
                                            comienzo = posiblederecha;
                                            NodoSimple q = usted1.primerNodo();
                                            for (i = 0; i < usted1.length; i++)
                                            {
                                                ficha q1 = (ficha)q.getDato();
                                                if (q.getDato().Equals(b))
                                                {
                                                    usted1.desconectar(q);
                                                }
                                                else
                                                {
                                                    q1.intercambiar();
                                                    if (q1.Equals(b))
                                                    {
                                                        usted1.desconectar(q);
                                                    }
                                                }
                                            }                                            

                                        }
                                        i = i + 1;
                                    }
                                    posible1.setPrimero(null);
                                    posible1.setUltimo(null);
                                }
                                else
                                {
                                    Console.WriteLine(
                                        "Su elección es invalida, ingrese de nuevo la ficha, cada numero separado por enter");
                                }
                                
                            }

                            Console.WriteLine("El juego esta así:");
                            imprimirjuego(juego1);
                            puede[0] = true;
                            puede[1] = true;
                            puede[2] = true;
                            puede[3] = true;

                            if (turnos1[actual].length == 0)
                            {
                                Console.WriteLine("Usted ganó (dominó) esta ronda.");
                                sumatoria1(actual, turnos1[0], turnos1[1], turnos1[2], puntajes1);
                                Imprimirlistapuntajes();
                                ganador = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("El jugador no tiene fichas para poner");
                        }
                        puede[actual] = false;
                        actual = 0;

                        /*if ((turnos[actual].Exists(x => (x.Izquierda == final || x.Derecha == comienzo))) ||
                            (turnos[actual].Exists(x => (x.Izquierda == comienzo || x.Derecha == final))))
                        {
                            int i = 0;
                            while (i < (turnos[actual].Count))
                            {
                                if ((turnos[actual][i].Izquierda) == final || (turnos[actual][i].Derecha) == comienzo)
                                {
                                    posible.Add(new ficha
                                    { Izquierda = turnos[actual][i].Izquierda, Derecha = turnos[actual][i].Derecha });
                                }

                                i = i + 1;
                            }

                            i = 0;
                            while (i < (turnos[actual].Count))
                            {
                                if (((turnos[actual][i].Derecha) == final || (turnos[actual][i].Izquierda) == comienzo))
                                {
                                    if ((posible.Exists(x =>
                                        (x.Derecha == turnos[actual][i].Derecha &&
                                         x.Izquierda == turnos[actual][i].Izquierda))) == false)
                                    {
                                        posible.Add(new ficha
                                        { Izquierda = turnos[actual][i].Derecha, Derecha = turnos[actual][i].Izquierda });
                                    }
                                }

                                i = i + 1;
                            }

                            Console.WriteLine("Sus opciones son las siguientes:");
                            imprimirlista(posible);
                            Console.WriteLine("Ingrese su elección de ficha con cada numero separado por enter");
                            while (encontrada == false)
                            {
                                int posibleizquierda = Convert.ToInt32(Console.ReadLine());
                                int posiblederecha = Convert.ToInt32(Console.ReadLine());
                                if (posible.Exists(x => (x.Izquierda == posibleizquierda && x.Derecha == posiblederecha)))
                                {
                                    while ((encontrada == false))
                                    {
                                        if ((posibleizquierda) == final)
                                        {
                                            juego.Add(new ficha { Izquierda = posibleizquierda, Derecha = posiblederecha });
                                            Console.WriteLine("Usted puso la ficha: " + posibleizquierda + " " +
                                                              posiblederecha);
                                            final = posiblederecha;
                                            encontrada = true;
                                            for (int j = 0; j < usted.Count; j++)
                                            {
                                                if ((usted[j].Izquierda) == posiblederecha &&
                                                    (usted[j].Derecha) == posibleizquierda)
                                                {
                                                    usted.RemoveAt(j);
                                                }
                                                else
                                                {
                                                    if ((usted[j].Izquierda) == posibleizquierda &&
                                                        (usted[j].Derecha) == posiblederecha)
                                                    {
                                                        usted.RemoveAt(j);
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if ((posiblederecha) == comienzo)
                                            {
                                                juego.Insert(0,
                                                    new ficha { Izquierda = posibleizquierda, Derecha = posiblederecha });
                                                Console.WriteLine("Usted puso la ficha: " + posibleizquierda + " " +
                                                                  posiblederecha);
                                                encontrada = true;
                                                comienzo = posiblederecha;
                                                for (int j = 0; j < usted.Count; j++)
                                                {
                                                    if ((usted[j].Izquierda) == posibleizquierda &&
                                                        (usted[j].Derecha) == posiblederecha)
                                                    {
                                                        usted.RemoveAt(j);
                                                    }
                                                    else
                                                    {
                                                        if ((usted[j].Derecha) == posibleizquierda &&
                                                            (usted[j].Izquierda) == posiblederecha)
                                                        {
                                                            usted.RemoveAt(j);
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        i = i + 1;
                                    }

                                    posible.Clear();
                                }
                                else
                                {
                                    Console.WriteLine(
                                        "Su elección es invalida, ingrese de nuevo la ficha, cada numero separado por enter");
                                }
                            }

                            Console.WriteLine("El juego esta así:");
                            imprimirlista(juego);
                            puede[0] = true;
                            puede[1] = true;
                            puede[2] = true;
                            puede[3] = true;
                            if (turnos[actual].Count == 0)
                            {
                                Console.WriteLine("Usted ganó (dominó) esta ronda.");
                                sumatoria(actual, turnos[0], turnos[1], turnos[2], puntajes);
                                Imprimirlistapuntajes();
                                ganador = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("El jugador no tiene fichas para poner");
                        }

                        puede[actual] = false;
                        actual = 0;*/
                    }
                }

                if ((puede[0] == false) && (puede[1] == false) && (puede[2] == false) && (puede[3] == false) &&
                    (ganador == false))
                {
                    Console.WriteLine("Ninguno tiene fichas para continuar el juego.");
                    sumatoriapersonal1(hugo1, 0);
                    sumatoriapersonal1(paco1, 1);
                    sumatoriapersonal1(luis1, 2);
                    sumatoriapersonal1(usted1, 3);
                    if (puntajesronda1[0] < puntajesronda1[1] && puntajesronda1[0] < puntajesronda1[2] &&
                        puntajesronda1[0] < puntajesronda1[3])
                    {
                        Console.WriteLine("El jugador " + jugadores[0] +
                                          " ganó esta ronda por tener menos puntos que los otros.");
                        puntajesronda1[0] = (puntajesronda1[1] - puntajesronda1[0]) + (puntajesronda1[2] - puntajesronda1[0]) +
                                           (puntajesronda1[3] - puntajesronda1[0]);
                        puntajes1[0] += puntajesronda1[0];
                        Imprimirlistapuntajes();
                    }

                    if (puntajesronda1[1] < puntajesronda1[0] && puntajesronda1[1] < puntajesronda1[2] &&
                        puntajesronda1[1] < puntajesronda1[3])
                    {
                        Console.WriteLine("El jugador " + jugadores[1] +
                                          " ganó esta ronda por tener menos puntos que los otros.");
                        puntajesronda1[1] = (puntajesronda1[0] - puntajesronda1[1]) + (puntajesronda1[2] - puntajesronda1[1]) +
                                           (puntajesronda1[3] - puntajesronda1[1]);
                        puntajes1[1] += puntajesronda1[1];
                    }
                    else
                    {
                        if (puntajesronda1[2] < puntajesronda1[0] && puntajesronda1[2] < puntajesronda1[1] &&
                            puntajesronda1[2] < puntajesronda1[3])
                        {
                            Console.WriteLine("El jugador " + jugadores[2] +
                                              " ganó esta ronda por tener menos puntos que los otros.");
                            puntajesronda1[2] = (puntajesronda1[0] - puntajesronda1[2]) + (puntajesronda1[1] - puntajesronda1[2]) +
                                               (puntajesronda1[3] - puntajesronda1[2]);
                            puntajes1[2] += puntajesronda1[2];
                        }
                        else
                        {
                            if (puntajesronda1[2] < puntajesronda1[0] && puntajesronda1[2] < puntajesronda1[1] &&
                                puntajesronda1[2] < puntajesronda1[3])
                            {
                                Console.WriteLine("El jugador " + jugadores[2] +
                                                  " ganó esta ronda por tener menos puntos que los otros.");
                                puntajesronda1[2] = (puntajesronda1[0] - puntajesronda1[2]) + (puntajesronda1[1] - puntajesronda1[2]) +
                                                   (puntajesronda1[3] - puntajesronda1[2]);
                                puntajes1[2] += puntajesronda1[2];
                            }
                            else
                            {
                                if (puntajesronda1[3] < puntajesronda1[0] && puntajesronda1[3] < puntajesronda1[1] &&
                                    puntajesronda1[3] < puntajesronda1[2])
                                {
                                    Console.WriteLine("Usted ganó esta ronda por tener menos puntos que los otros.");
                                    puntajesronda1[3] = (puntajesronda1[0] - puntajesronda1[3]) + (puntajesronda1[1] - puntajesronda1[3]) +
                                                       (puntajesronda1[2] - puntajesronda1[3]);
                                    puntajes1[3] += puntajesronda1[3];
                                }

                            }
                        }
                    }
                    Imprimirlistapuntajes();
                }
                if (puntajes1[0] > 100)
                {
                    Console.WriteLine(jugadores[0] + " ganó la partida pues alcanzó 101 puntos.");
                }
                else
                {
                    if (puntajes1[1] > 100)
                    {
                        Console.WriteLine(jugadores[1] + " ganó la partida pues alcanzó 101 puntos.");
                    }
                    else
                    {
                        if (puntajes1[2] > 100)
                        {
                            Console.WriteLine(jugadores[2] + " ganó la partida pues alcanzó 101 puntos.");
                        }
                        else
                        {
                            if (puntajes1[3] > 100)
                            {
                                Console.WriteLine("Usted ganó la partida pues alcanzó 101 puntos.");
                            }
                            else
                            {
                                Console.WriteLine("Se terminó la ronda, oprima cualquier tecla para continuar la partida.");
                                Console.ReadLine();
                            }
                        }
                    }
                }
            }           
        }
    }
}
