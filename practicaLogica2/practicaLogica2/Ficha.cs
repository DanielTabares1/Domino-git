using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicaLogica2
{
    public class Ficha
    {
        //Atributos
        private int dato1, dato2;
        //constructor
        public Ficha(int dato1,int dato2)
        {
            this.dato1 = dato1;
            this.dato2 = dato2;
        }
        //getters y setters
        public int getDato1()
        {
            return this.dato1;
        }
        public int getDato2()
        {
            return this.dato2;
        }
        public void setDato1(int dato1)
        {
            this.dato1 = dato1;
        }
        public void setDato2(int dato2)
        {
            this.dato2 = dato2;
        }

        
    }
}
