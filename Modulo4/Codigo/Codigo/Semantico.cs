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

        List<string> voidFuncion = new List<string>();
        List<List<string>> voidParametros = new List<List<string>>();

        List<string> intFuncion = new List<string>();
        List<List<string>> intParametros = new List<List<string>>();
        
        List<string> floatFuncion = new List<string>();
        List<List<string>> floatParametros = new List<List<string>>();

        public Semantico()
        {

        }
        public void AddDefinido(string cadena, string tipo, string valor, bool funcion, List<string> parametros)
        {
            if(tipo == "int")
            {
                intDefined.Add(cadena);
                intValue.Add(valor);
            }
            else if(tipo == "float")
            {
                floatDefined.Add(cadena);
                floatValue.Add(valor);
            }
            if(funcion)
            {
                if (tipo == "void")
                {
                    voidFuncion.Add(cadena);
                    voidParametros.Add(parametros);
                }
                if(tipo == "int")
                {
                    intFuncion.Add(cadena);
                    intParametros.Add(parametros);
                }
                if(tipo == "float")
                {
                    floatFuncion.Add(cadena);
                    floatParametros.Add(parametros);
                }
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

        public int FindVoidFunction(string cadena)
        {
            int i = 0;
            while (i < voidFuncion.Count)
            {
                if (voidFuncion[i] == cadena)
                {
                    return i;
                }
                i++;
            }

            return -1;
        }
        public int FindIntFunction(string cadena)
        {
            int i = 0;
            while (i < intFuncion.Count)
            {
                if (intFuncion[i] == cadena)
                {
                    return i;
                }
                i++;
            }

            return -1;
        }
        public int FindFloatFunction(string cadena)
        {
            int i = 0;
            while (i < floatFuncion.Count)
            {
                if (floatFuncion[i] == cadena)
                {
                    return i;
                }
                i++;
            }

            return -1;
        }
        public List<string> ParametrosVoidFuncion(int posicion)
        {
            return voidParametros[posicion];
        }
        public List<string> ParametrosIntFuncion(int posicion)
        {
            return intParametros[posicion];
        }
        public List<string> ParametrosFloatFuncion(int posicion)
        {
            return floatParametros[posicion];
        }
    }
}
