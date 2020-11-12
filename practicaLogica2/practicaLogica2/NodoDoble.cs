using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicaLogica2
{
    class NodoDoble
    {
        private ficha dato;
        private NodoDoble li, ld;   //liga izquierda, liga derecha
        //constructor
        public NodoDoble(ficha dato)
        {
            this.dato = dato;
        }
        //getters and setters
        public ficha getDato()
        {
            return this.dato;
        }
        public NodoDoble getli()
        {
            return this.li;
        }
        public NodoDoble getld()
        {
            return this.ld;
        }
        public void setli(NodoDoble li)
        {
            this.li = li;
        }
        public void setld(NodoDoble ld)
        {
            this.ld = ld;
        }


    }
}
