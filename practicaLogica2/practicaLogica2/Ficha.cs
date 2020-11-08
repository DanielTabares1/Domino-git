using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicaLogica2
{
    public class ficha
    {
        //Atributos
        public int Izquierda, Derecha;
        //constructor
        
        public ficha(int Izquierda, int Derecha)
        {
            this.Izquierda = Izquierda;
            this.Derecha = Derecha;
        }
        //getters y setters
        public int getIzquierda()
        {
            return this.Izquierda;
        }
        public int getDerecha()
        {
            return this.Derecha;
        }
        public void setIzquierda(int dato1)
        {
            this.Izquierda = dato1;
        }
        public void setDerecha(int dato2)
        {
            this.Derecha = dato2;
        }
        public void intercambiar()
        {
            int guardar = Derecha;
            Derecha = Izquierda;
            Izquierda = guardar;
        }

        
    }
}
