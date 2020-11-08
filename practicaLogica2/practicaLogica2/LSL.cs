using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicaLogica2
{
    public class LSL
    {
        private NodoSimple primero, ultimo;        

        //Método Constructor
        public LSL() { }
        //getters y setters
        public NodoSimple primerNodo()
        {
            return this.primero;
        }
        public NodoSimple ultimoNodo()
        {
            return this.ultimo;
        }
        public void setPrimero(NodoSimple primero)
        {
            this.primero = primero;
        }
        public void setUltimo(NodoSimple ultimo)
        {
            this.ultimo = ultimo;
        }
        //métodos de la clase
        public bool esVacia()
        {
            return primero == null;
        }
        public bool finDeRecorrido(NodoSimple p)
        {
            return p == null;
        }
        public void insertar(object dato)  // sólo al final
        {
            NodoSimple x = new NodoSimple(dato);
            if(primero == null)
            {
                primero = x;
                ultimo = x;
            }
            else
            {
                ultimo.setLiga(x);
                ultimo = x;
            }
        }
        public void desconectar(NodoSimple x)
        {
            if(primero == x)                  //si se elimina el primero
            {
                if (ultimo == primero)       //si es el único
                {
                    primero = null;
                    ultimo = null;
                    return;
                }
                else
                {
                    primero = x.getLiga();
                    x.setLiga(null);
                    return;
                }                
            }
            else
            {
                NodoSimple p, y;
                p = primero;
                y = null;
                while (!finDeRecorrido(p) && p!=x)
                {
                    y = p;
                    p = p.getLiga();
                }
                y.setLiga(p.getLiga());                
                if (ultimo == p)
                {
                    ultimo = y;
                }
                p.setLiga(null);
            }                                             
                   
        }
        public int length()
        {
            if(primero == null)
            {
                return 0;
            }
            else
            {
                NodoSimple p = primero;
                int vueltas = 0;
                while (!finDeRecorrido(p))
                {
                    p = p.getLiga();
                    vueltas++;
                }
                return vueltas;
            }
        }
    }
}
