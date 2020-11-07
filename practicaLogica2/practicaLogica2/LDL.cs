using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicaLogica2
{
    class LDL
    {
        private NodoDoble primero, ultimo;
        public LDL() { }
        //getters y setters
        public NodoDoble getPrimero()
        {
            return this.primero;
        }
        public NodoDoble getUltimo()
        {
            return this.ultimo;
        }
        public void setPrimero(NodoDoble primero)
        {
            this.primero = primero;
        }
        public void setUltimo(NodoDoble ultimo)
        {
            this.ultimo = ultimo;
        }

        //métodos de la clase

        public bool esVacia()
        {
            return primero == null;
        }
        public bool finDeRecorrido(NodoDoble p)
        {
            return p == null;
        }
        public void insertarDerecha(object dato)
        {
            NodoDoble x = new NodoDoble(dato);
            if(primero == null)  //si está vacía
            {
                primero = x;
                ultimo = x;
            }
            else
            {
                ultimo.setld(x);
                x.setli(ultimo);
                ultimo = x;
            }
        }
        public void insertarIzquierda(object dato)
        {
            NodoDoble x = new NodoDoble(dato);
            if(primero == null) //está vacía
            {
                primero = x;
                ultimo = x;
            }
            else
            {
                primero.setli(x);
                x.setld(primero);
                primero = x;
            }
        }
        public void desconectar(NodoDoble x)
        {
            if(primero == x)   //si se elimina el primero
            {
                if(primero == ultimo)   //si es el único dato
                {
                    primero = null;
                    ultimo = null;
                    x.setld(null);
                    x.setli(null);
                }
                else
                {                    
                    x.getld().setli(null);
                    primero = x.getld();
                    x.setld(null);
                }
            }
            else if(ultimo == x)
            {
                x.getli().setld(null);
                ultimo = x.getli();
                x.setli(null);
            }
            else
            {
                x.getli().setld(x.getld());
                x.getld().setli(x.getli());
                x.setld(null);
                x.setli(null);
            }
            
        }
    }
}
