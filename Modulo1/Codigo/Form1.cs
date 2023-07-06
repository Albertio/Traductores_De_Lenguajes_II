using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbyssC
{
    public partial class Form1 : Form
    {
        //Tokens -> Orden 0 a 21 en este orden
        public string[] Identificador = new string[28];//LetrasNumeros < Nada de simbolos solo _
        public string[] Entero = new string[10];//Numeros
        public string[] Real = new string[11];//Numero con punto flotante
        public string[] Cadena = new string[1];//Todo entre comillas
        public string[] Tipo = new string[3];
        public string[] OpSuma = new string[2];
        public string[] OpMul = new string[2];
        public string[] OpRelac = new string[4];
        public string[] OpOr = new string[1];
        public string[] OpAnd = new string[1];
        public string[] OpNot = new string[1];
        public string[] OpIgualdad = new string[2];
        public string[] PuntoComa = new string[1];
        public string[] Coma = new string[1];
        public string[] ParentesisOpen = new string[1];
        public string[] ParentesisClose = new string[1];
        public string[] CorcheteOpen = new string[1];
        public string[] CorcheteClose = new string[1];
        public string[] Igual = new string[1];
        public string[] _if = new string[1];
        public string[] _while = new string[1];
        public string[] _return = new string[1];
        public string[] _else = new string[1];
        public string[] Terminal = new string[1];

        //Extras
        public string[] Separadores = new string[20];
        public string[] Resultados = new string[25];
        //Lexico
        public List<string> Lexico = new List<string>();
        public Form1()
        {
            Identificador = new string[28] {"a", "b", "c", "d", "e", "f", "g", 
                "h", "i", "j", "k", "l", "m", "n", "l", "o", "p", "q", "r", "s", "t",
                "u", "v", "w", "x", "y", "z", "_"};
            Entero = new string[10] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};
            Real = new string[11] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "."};
            Cadena = new string[1] {""};
            Tipo = new string[3] {"int", "float", "void"};
            OpSuma = new string[2] {"+", "-"};
            OpMul = new string[2] { "*", "/" };
            OpRelac = new string[4] { "<", "<=", ">", ">="};
            OpOr = new string[1] {"||"};
            OpAnd = new string[1] {"&&"};
            OpNot = new string[1] {"!"};
            OpIgualdad = new string[2] {"==", "!="};
            PuntoComa = new string[1] {";"};
            Coma = new string[1] {","};
            ParentesisOpen = new string[1] {"("};
            ParentesisClose = new string[1] {")"};
            CorcheteOpen = new string[1] {"{"};
            CorcheteClose = new string[1] {"}"};
            Igual = new string[1] {"="};
            _if = new string[1] {"if"};
            _while = new string[1] {"while"};
            _return = new string[1] {"return"};
            _else = new string[1] {"else"};
            Terminal = new string[1] {"$"};

            Resultados = new string[25] {"Identificador", "Entero", "Real", "Cadena",
                "Tipo", "OpSuma", "OpMul", "OpRelac", "OpOr", "OpAnd", "OpNot",
                "OpIgualdad", "PuntoComa", "Coma", "ParentesisOpen", "ParentesisClose",
                "CorcheteOpen", "CorcheteClose", "Igual", "_if", "_while", "_return",
                "_else", "_terminal", "ERROR"};
            Separadores = new string[20] {"\r", "\n", "\t", " ","+", "-", "*", "/", "<",
                ">", "(", ")", "{", "}", "=", "!", "|", "&", ",",";"};
            
            InitializeComponent();
        }

        private void Run_Click(object sender, EventArgs e)
        {
            Results.Text = "";
        }
        private void Compile_Click(object sender, EventArgs e)
        {
            Results.Text = "";
            //Fase 1: Analisis Lexico
            string text = console.Text; //Todo el texto en cuestion
            string word = ""; //Esta es la palabra que vamos a procesar
            int i = 0;
            while (i < text.Length)//Mientras quede texto por recorrer
            {
                if (Separadores.Contains<string>(text[i].ToString()))
                {
                    int x = -1;
                    if(word != " " && word != "\t" && word != "")
                    {
                        
                        x = AnalizadorLexico(word);
                    }
                    if (x > -1)
                    {
                        Lexico.Add(word);
                        Results.Text += word + " -> " + Resultados[x] + "\r\n";
                    }
                    word = text[i].ToString();
                    if (text[i] != ' ' && text[i] != '\t')
                    {
                        if (text[i] == '=' || text[i] == '!' ||
                            text[i] == '<' || text[i] == '>')
                        {
                            if(text[i+1] == '=')
                            {
                                word = text[i].ToString();
                                word += "=";
                                i++;
                            }
                        }
                        if(text[i] == '&')
                        {
                            if(text[i+1] == '&')
                            {
                                word = "&&";
                                i++;
                            }
                        }
                        if(text[i] == '|')
                        {
                            if(text[i+1] == '|')
                            {
                                word = "||";
                                i++;
                            }
                        }
                        x = AnalizadorLexico(word);
                    }
                    else
                    {
                        x = -1;
                    }

                    if (x > -1)
                    {
                        Lexico.Add(word);
                        Results.Text += word + " -> " + Resultados[x] + "\r\n";
                    }
                    word = "";
                }
                else if(i == text.Length - 1)
                {
                    word += text[i];
                    int x = -1;
                    if (word != " " && word != "\t" && word != "")
                    {
                        x = AnalizadorLexico(word);
                    }
                    if (x > -1)
                    {
                        Lexico.Add(word);
                        Results.Text += word + " -> " + Resultados[x] + "\r\n";
                    }
                }
                else
                {
                    word += text[i];
                }
                i++;
            }
        }
        public int AnalizadorLexico(string word)//Aqui nos encargamos de buscar a donde pertenece
        {
            /*
            if (Identificador.Contains<string>(word))
            {
                return 0;
            }
            */
            if (Entero.Contains<string>(word))
            {
                return 1;
            }
            if (Real.Contains<string>(word))
            {
                return 2;
            }
            if (Cadena.Contains<string>(word))
            {
                return 3;
            }
            if (Tipo.Contains<string>(word))
            {
                return 4;
            }
            if (OpSuma.Contains<string>(word))
            {
                return 5;
            }
            if (OpMul.Contains<string>(word))
            {
                return 6;
            }
            if (OpRelac.Contains<string>(word))
            {
                return 7;
            }
            if (OpOr.Contains<string>(word))
            {
                return 8;
            }
            if (OpAnd.Contains<string>(word))
            {
                return 9;
            }
            if (OpNot.Contains<string>(word))
            {
                return 10;
            }
            if (OpIgualdad.Contains<string>(word))
            {
                return 11;
            }
            if (PuntoComa.Contains<string>(word))
            {
                return 12;
            }
            if (Coma.Contains<string>(word))
            {
                return 13;
            }
            if (ParentesisOpen.Contains<string>(word))
            {
                return 14;
            }
            if (ParentesisClose.Contains<string>(word))
            {
                return 15;
            }
            if (CorcheteOpen.Contains<string>(word))
            {
                return 16;
            }
            if (CorcheteClose.Contains<string>(word))
            {
                return 17;
            }
            if(Igual.Contains<string>(word))
            {
                return 18;
            }
            if (_if.Contains<string>(word))
            {
                return 19;
            }
            if (_while.Contains<string>(word))
            {
                return 20;
            }
            if (_return.Contains<string>(word))
            {
                return 21;
            }
            if (_else.Contains<string>(word))
            {
                return 22;
            }
            if (Terminal.Contains<string>(word))
            {
                return 23;
            }

            //Excepciones Controladas
            if (Identificador.Contains<string>(word[0].ToString()))
            {
                return 0;
            }
            //Reales y Numeros
            int i = 0;
            int opc = 0;
            if(Real.Contains<string>(word[0].ToString()))
            {
                if (word[0] == '.')
                {
                    opc = 2;
                }
                else
                {
                    opc = 1;
                }
                i++;
                while (i < word.Length)
                {
                    
                    switch(opc)
                    {
                        case 1:
                            if (Entero.Contains<string>(word[i].ToString()))
                            {
                                opc = 1;
                            }
                            else if (word[i] == '.')
                            {
                                opc = 2;
                            }
                            else
                            {
                                opc = -1;
                            }
                            break;
                        case 2:
                            if (Entero.Contains<string>(word[i].ToString()))
                            {
                                opc = 2;
                            }
                            else
                            {
                                opc = -1;
                            }
                            break;
                        default:
                            break;
                    }
                    i++;
                }
                if(opc == -1)
                {
                    return 24;
                }
                if(opc == 1)
                {
                    return 1;
                }
                if(opc == 2)
                {
                    return 2;
                }
            }
            
            return -1;
        }
    }
}
