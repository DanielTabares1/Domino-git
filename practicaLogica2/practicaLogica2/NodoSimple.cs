using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicaLogica2
{
    public class NodoSimple
    {
        private object dato;
        private NodoSimple liga;

        public NodoSimple(object dato)          //Constructor
        {
            this.dato = dato;
        }
        public object getDato()                 //getters
        {
            return this.dato;
        }
        public NodoSimple getLiga()
        {
            return this.liga;
        }
        public void setLiga(NodoSimple liga)         //setter
        {
            this.liga = liga;
        }
    }
}
