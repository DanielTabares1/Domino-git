using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace practicaLogica2
{
    public class LSL
    {
        private NodoSimple primero, ultimo;
        public int length = 0;

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
        public void insertar(ficha dato)  // sólo al final
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
            length += 1;
        }
        public void desconectar(NodoSimple x)
        {
            if(primero == x)                  //si se elimina el primero
            {                
                if(ultimo == primero)       //si es el único
                {
                    primero = null;
                    ultimo = null;
                    length -= 1;
                    return;
                }
                else
                {                    
                    primero = x.getLiga();
                    x.setLiga(null);
                    length -= 1;
                    return;
                }                
            }
            else
            {                
                NodoSimple p, y;
                p = primero;
                y = null;
                while (!finDeRecorrido(p) && p != x)
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
            length -= 1;               
        }
        public void removeAt(int indice)
        {
            NodoSimple p = primero;
            for (int i = 0; i < indice; i++)
            {
                p = p.getLiga();
            }
            desconectar(p);
        }
        public void pintarLSL()
        {
            NodoSimple p;
            p = primerNodo();
            while (!finDeRecorrido(p))
            {
                Console.Write(p.getDato().Izquierda+"|"+p.getDato().Derecha+" ");
                p = p.getLiga();
            }            
        }
        public bool existe(ficha d)
        {
            ficha buscada = d;
            NodoSimple p = primero;
            while(p!= null)
            {
                ficha f = p.getDato();
                if(buscada.Izquierda == f.Izquierda && buscada.Derecha == f.Derecha)
                {
                    return true;
                }
                p = p.getLiga();
            }
            return false;
        }
        public bool existe1(ficha d)
        {            
            NodoSimple p = primero;
            while (!finDeRecorrido(p))
            {
                ficha f = p.getDato();
                if (d.Izquierda == f.Izquierda || d.Derecha == f.Derecha)
                {
                    return true;
                }
                p = p.getLiga();
            }
            return false;
        }        
        public int indexOf(ficha f)
        {            
            NodoSimple p = primero;
            int indice = 0;
            while(!finDeRecorrido(p) && p.getDato().Izquierda != f.Izquierda &&
                p.getDato().Derecha != f.Derecha)
            {
                p = p.getLiga();
                indice++;
            }
            if (indice >= length)
            {
                return -1;
            }
            return indice;
        }        
    }
}
