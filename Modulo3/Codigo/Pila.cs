using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbyssC
{
    public class Pila
    {
        //Variables
        public List<EP> pila = new List<EP>();

        //Metodos
        public virtual void Push(EP top)
        {
            pila.Add(top);
        }
        public virtual void Pop()
        {
            pila.RemoveAt(pila.Count - 1);
        }
        public virtual EP Top()
        {
            return pila.Last<EP>();
        }
        public virtual string Show()
        {
            string cadena = "";
            foreach(EP element in pila)
            {
                cadena += element.cadena;
            }
            return cadena;
        }
    }
}
