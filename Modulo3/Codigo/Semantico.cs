using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbyssC
{
    public class Semantico
    {
        List<string> intDefined = new List<string>();
        List<string> intValue = new List<string>();

        List<string> floatDefined = new List<string>();
        List<string> floatValue = new List<string>();

        public Semantico()
        {

        }
        public void AddDefinido(string cadena, string tipo, string valor)
        {
            if(tipo == "int")
            {
                intDefined.Add(cadena);
                intValue.Add(valor);
            }
            else
            {
                floatDefined.Add(cadena);
                floatValue.Add(valor);
            }
        }
        public int FindInt(string cadena)
        {
            int i = 0;
            while(i < intDefined.Count)
            {
                if(intDefined[i] == cadena)
                {
                    return i;
                }
                i++;
            }

            return -1;
        }
        public int FindFloat(string cadena)
        {
            int i = 0;
            while (i < floatDefined.Count)
            {
                if (floatDefined[i] == cadena)
                {
                    return i;
                }
                i++;
            }

            return -1;
        }
    }
}
