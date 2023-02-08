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

        //Sintactico
        public int[,] LR = new int[95, 46]
            {{0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-3,1,2,3,4,0,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-3,0,7,3,4,0,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,-5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,-6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,-8,10,11,0,0,0,0,0,0,0,0,0,0,0,0,0,9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,12,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 13,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,15,0,0,0,0,0,0,0,0,0,0,-11,0,0,0,0,0,0,0,0,0,0,0,0,0,0,14,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { -7,0,0,0,-7,0,0,0,0,0,0,0,0,0,0,0,0,-7,0,-7,-7,-7,0,-7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,-8,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,16,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,17,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 18,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,-9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,20,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,19,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,22,0,-13,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,21,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,-10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 27,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,-16,0,28,29,30,0,0,0,0,0,25,0,0,0,0,0,23,24,0,26,0,0,0,0,0,0,31,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-12,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,32,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,33,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 27,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,-16,0,28,29,30,0,0,0,0,0,25,0,0,0,0,0,34,24,0,26,0,0,0,0,0,0,31,0,0},
            { -18,0,0,0,-18,0,0,0,0,0,0,0,0,0,0,0,0,-18,0,-18,-18,-18,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { -19,0,0,0,-19,0,0,0,0,0,0,0,0,0,0,0,0,-19,0,-19,-19,-19,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,36,0,0,0,35,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,37,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,38,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 46,47,48,49,0,42,0,0,0,0,43,0,-30,0,41,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,39,0,0,44,45,0,40},
            { 0,0,0,0,0,0,0,0,0,0,0,0,50,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 51,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,-15,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-15,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-17,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 46,47,48,49,0,42,0,0,0,0,43,0,0,0,41,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,44,45,0,52 },
            { 46,47,48,49,0,42,0,0,0,0,43,0,0,0,41,-32,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,53,0,44,45,0,54 },
            { 46,47,48,49,0,42,0,0,0,0,43,0,0,0,41,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,44,45,0,55 },
            { 46,47,48,49,0,42,0,0,0,0,43,0,0,0,41,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,44,45,0,56 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,57,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,59,58,60,63,62,0,61,-31,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 46,47,48,49,0,42,0,0,0,0,43,0,0,0,41,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,44,45,0,64},
            { 46,47,48,49,0,42,0,0,0,0,43,0,0,0,41,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,44,45,0,65},
            { 46,47,48,49,0,42,0,0,0,0,43,0,0,0,41,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,44,45,0,66},
            { 0,0,0,0,0,-53,-53,-53,-53,-53,0,-53,-53,-53,0,-53,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,-36,-36,-36,-36,-36,0,-36,-36,-36,0,-36,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,-37,-37,-37,-37,-37,0,-37,-37,-37,36,-37,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,-38,-38,-38,-38,-38,0,-38,-38,-38,0,-38,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,-39,-39,-39,-39,-39,0,-39,-39,-39,0,-39,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,-40,-40,-40,-40,-40,0,-40,-40,-40,0,-40,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { -26,0,0,0,-26,0,0,0,0,0,0,0,0,0,0,0,0,-26,0,-26,-26,-26,-26,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,22,0,-13,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,67,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,59,58,60,63,62,0,61,68,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,69,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,59,58,60,63,62,0,61,0,71,0,-34,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,70,0,0,0,0},
            { 0,0,0,0,0,59,58,60,63,62,0,61,0,0,0,72,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,59,58,60,63,62,0,61,0,0,0,73,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { -25,0,0,0,-25,0,0,0,0,0,0,0,0,0,0,0,0,-25,0,-25,-25,-25,-25,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 46,47,48,49,0,42,0,0,0,0,43,0,0,0,41,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,44,45,0,74 },
            { 46,47,48,49,0,42,0,0,0,0,43,0,0,0,41,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,44,45,0,75 },
            { 46,47,48,49,0,42,0,0,0,0,43,0,0,0,41,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,44,45,0,76 },
            { 46,47,48,49,0,42,0,0,0,0,43,0,0,0,41,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,44,45,0,77 },
            { 46,47,48,49,0,42,0,0,0,0,43,0,0,0,41,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,44,45,0,78 },
            { 46,47,48,49,0,42,0,0,0,0,43,0,0,0,41,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,44,45,0,79 },
            { 0,0,0,0,0,59,58,60,63,62,0,61,0,0,0,80,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,-45,-45,-45,-45,-45,0,-45,-45,-45,0,-45,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,-46,-46,-46,-46,-46,0,-46,-46,-46,0,-46,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-14,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { -22,0,0,0,-22,0,0,0,0,0,0,0,0,0,0,0,0,-22,0,-22,-22,-22,-22,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,-41,-41,-41,-41,-41,0,-41,-41,-41,0,-41,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-33,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 46,47,48,49,0,42,0,0,0,0,43,0,0,0,41,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,44,45,0,81 },
            { 27,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,85,0,0,28,29,30,0,0,0,0,0,0,0,0,0,0,0,0,0,0,83,0,84,0,0,0,0,31,82,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,85,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,86,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,-47,-47,-47,-47,-47,0,-47,-47,-47,0,-47,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,-48,58,-48,-48,-48,0,-48,-48,-48,0,-48,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,59,58,-49,-49,-49,0,-49,-49,-49,0,-49,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,59,58,60,-50,-50,0,-50,-50,-50,0,-50,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,59,58,60,-51,-51,0,61,-51,-51,0,-51,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,59,58,60,-52,62,0,61,-52,-52,0,-52,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,-44,-44,-44,-44,-44,0,-44,-44,-44,0,-44,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,59,58,60,63,62,0,61,0,71,0,-34,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,87,0,0,0,0 },
            { -27,0,0,0,-27,0,0,0,0,0,0,0,0,0,0,0,0,-27,0,-27,-27,-27,89,0,0,0,0,0,0,0,0,0,0,0,0,0,0,88,0,0,0,0,0,0,0,0 },
            { -42,0,0,0,-42,0,0,0,0,0,0,0,0,0,0,0,0,-42,0,-42,-42,-42,-42,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { -43,0,0,0,-43,0,0,0,0,0,0,0,0,0,0,0,0,-43,0,-43,-43,-43,-43,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 27,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-20,0,28,29,30,0,0,0,0,0,0,0,0,0,0,0,0,0,90,91,0,0,0,0,0,0,31,0,0 },
            { -24,0,0,0,-24,0,0,0,0,0,0,0,0,0,0,0,0,-24,0,-24,-24,-24,-24,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-35,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { -23,0,0,0,-23,0,0,0,0,0,0,0,0,0,0,0,0,-23,0,-23,-23,-23,-23,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 27,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,85,0,0,28,29,30,0,0,0,0,0,0,0,0,0,0,0,0,0,0,83,0,84,0,0,0,0,31,92,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,93,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 27,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-20,0,28,29,30,0,0,0,0,0,0,0,0,0,0,0,0,0,94,91,0,0,0,0,0,0,31,0,0 },
            { -28,0,0,0,-28,0,0,0,0,0,0,0,0,0,0,0,0,-28,0,-28,-28,-28,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { -29,0,0,0,-29,0,0,0,0,0,0,0,0,0,0,0,0,-29,0,-29,-29,-29,-29,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-21,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0} };
        public Pila pila;
        public string[] MensajesError = new string[24];
        public string[] resultados = new string[10];
        string programa;

        //Semantico
        public Semantico semantico;
        public bool error;

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

            Resultados = new string[25] {"identificador", "entero", "real", "cadena",
                "tipo", "opSuma", "opMul", "opRelac", "opOr", "opAnd", "opNot",
                "opIgualdad", "puntoComa", "coma", "parentesisOpen", "parentesisClose",
                "corcheteOpen", "corcheteClose", "igual", "_if", "_while", "_return",
                "_else", "_terminal", "ERROR"};
            Separadores = new string[20] {"\r", "\n", "\t", " ","+", "-", "*", "/", "<", ">", "(", ")", "{", "}", "=", "!", "|", "&", ",",";"};

            MensajesError = new string[24] {"identificador", "entero", "real", "cadena",
                               "tipo", "opSum", "opMul", "opRela",
                               "opOr", "opAnd", "opNot", "opIgualdad",
                               ";", ",", "(", ")", "{", "}", "=", "if", "while", "return", "else", "$"};
            resultados = new string[10]{
                "reservadas","aritmeticos","logicos","identificador",
                "hexadecimal","float","Int","arreglo", "simbolo", "no_identificado"};

            programa = "";
            semantico = new Semantico();
            InitializeComponent();
        }

        private void Run_Click(object sender, EventArgs e)
        {
            Results.Text = "";
        }
        private void Compile_Click(object sender, EventArgs e)
        {
            error = false;
            Results.Text = "";
            Results_Console.Text = "";
            Results_Sintactico.Text = "";
            Results_Semantico.Text = "";
            Lexico = new List<string>();
            semantico = new Semantico();
            //Fase 1: Analisis Lexico
            #region Lexico
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
                        Lexico.Add(word + ":" + Resultados[x] + ":" + x.ToString());
                        Results.Text += word + " -> " + Resultados[x] + "\r\n";
                    }
                    if (text[i] != ' ' && text[i] != '\t')
                    {
                        if (i + 1 < text.Length)
                        {
                            word = text[i].ToString();
                            if (word == "=" || word == "&" || word == "|")
                            {
                                if(word == text[i + 1].ToString())
                                {
                                    i++;
                                    word += text[i].ToString();
                                }
                            }
                            else if(word == "!")
                            {
                                if("=" == text[i + 1].ToString())
                                {
                                    i++;
                                    word += "=";
                                }
                            }
                            x = AnalizadorLexico(word);
                        }
                        else
                        {
                            x = AnalizadorLexico(text[i].ToString());
                        }
                        
                    }
                    else
                    {
                        x = -1;
                    }
                    
                    if (x > -1)
                    {
                        Lexico.Add(text[i].ToString() + ":" + Resultados[x] + ":" + x.ToString());
                        Results.Text += text[i] + " -> " + Resultados[x] + "\r\n";
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
                        Lexico.Add(word + ":" + Resultados[x] + ":" + x.ToString());
                        Results.Text += word + " -> " + Resultados[x] + "\r\n";
                    }
                }
                else
                {
                    word += text[i];
                }
                i++;
            }
            Lexico.Add("$:Reservadas:23");
            i = 0;
            programa = "";
            while(i < Lexico.Count)
            {
                programa += Lexico[i] + " ";
                Results_Sintactico.Text += Lexico[i] + "\r\n";
                i++;
            }
            #endregion
            //Fase 2: Analisis Sintactico
            #region Sintactico
            pila = new Pila();
            AnalizadorSintactico(programa);
            #endregion
            //Fase 3. Analisis Semantico
            #region Semantico
            if (!error)
            {
                AnalizadorSemantico(Lexico);
            }
            #endregion
            //Fase 4. Codigo Objeto
            #region Ejecutar
            if(!error)
            {
                Ejecucion();
            }
            #endregion
        }
        public int AnalizadorLexico(string word)//Aqui nos encargamos de buscar a donde pertenece
        {
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
        public void AnalizadorSintactico(string programa)
        {
            int fila, columna;
            pila.Push(new EP("$"));
            pila.Push(new EP("0"));

            //El numero que está en el tope de la fila + el número del identificador
            //int|Reservadas|4 main|Identificador|0 (|Simbolo|14 )|Simbolo|15 {|Simbolo|16 }|Simbolo|17
            EP elemento;
            Results_Sintactico.Text += "\r\n" + "-----Analisis----" + "\r\n\r\n";
            int i = 0, j, control, accion = 0;
            char c;
            string data = "", tipo = "0", token = "";
            bool llave = false, parcing = true;
            while (parcing)
            {
                c = programa[i];

                switch (c)
                {
                    case ' ':
                        {
                            j = 0;
                            control = 0;
                            llave = false;

                            while (j < data.Length)
                            {

                                if (control == 1 && llave == false)
                                {
                                    llave = true;
                                    token = data.Substring(0, j - 1);
                                }
                                if (control == 2)
                                {
                                    tipo = data.Substring(j, data.Length - j);
                                    break;
                                }
                                if (data[j] == ':')
                                {
                                    control++;
                                }
                                j++;
                            }
                            //Aplicar el algoritmo
                            fila = Int32.Parse(pila.Top().cadena);

                            columna = Int32.Parse(tipo);

                            accion = LR[fila, columna];
                            if (token != "$")
                            {
                                //Results_Sintactico.Text += accion.ToString() + "\r\n";
                            }
                            if (accion < 0)
                            {
                                //Results_Sintactico.Text += accion.ToString() + "\r\n";
                                switch (accion)
                                {
                                    case -1:
                                        //Results_Console.Text += "Analisis sintactico completado con satisfaccion" + "\r\n";
                                        parcing = false;
                                        i--;
                                        break;
                                    case -2:
                                        //R1
                                        PopPila(1);
                                        fila = Int32.Parse(pila.Top().cadena);
                                        elemento = new EP("<programa>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;

                                        accion = LR[fila, 24];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());
                                        
                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;

                                        i--;
                                        break;
                                    case -3:
                                        //R2
                                        PopPila(0);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<Definiciones>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 25];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;
                                        break;

                                    case -4:
                                        //R3
                                        PopPila(2);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<Definiciones>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 25];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());
                                       
                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;

                                    case -5:
                                        //R4
                                        PopPila(1);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<Definicion>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 26];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;
                                        break;

                                    case -6:
                                        //R5

                                        PopPila(1);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<Definicion>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 26];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;
                                        break;

                                    case -7:
                                        //R6
                                        PopPila(4);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<DefVar>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 27];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;
                                        break;

                                    case -8:
                                        //R7

                                        PopPila(0);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<ListaVar>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 28];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;
                                        break;

                                    case -9:
                                        //R8
                                        PopPila(3);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<ListaVar>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 28];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;
                                        break;

                                    case -10:
                                        //R9
                                        PopPila(6);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<DefFunc>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 29];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;

                                    case -11:
                                        //R10

                                        PopPila(0);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<Parametros>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 30];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;
                                        break;

                                    case -12:
                                        //R11
                                        PopPila(3);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<Parametros>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 30];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;
                                        break;

                                    case -13:
                                        //R12
                                        PopPila(0);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<ListaParam>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 31];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;
                                        break;

                                    case -14:
                                        //R13
                                        PopPila(4);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<ListaParam>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 31];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;
                                        break;

                                    case -15:
                                        //R14

                                        PopPila(3);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<BloqFunc>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 32];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;

                                    case -16:
                                        //R15
                                        PopPila(0);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<DefLocales>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 33];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;


                                    case -17:
                                        //R16
                                        PopPila(2);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<DefLocales>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 33];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;


                                    case -18:
                                        //R17
                                        PopPila(1);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<DefLocal>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 34];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;

                                    case -19:
                                        //R18
                                        i--;
                                        PopPila(1);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<DefLocal>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 34];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;


                                    case -20:
                                        //R19
                                        PopPila(0);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<Sentencias>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 35];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;
                                    case -21:
                                        //R20
                                        PopPila(2);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<Sentencias>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 35];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;


                                    case -22:
                                        //R21
                                        PopPila(4);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<Sentencia>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 36];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;

                                    case -23:
                                        //R22
                                        PopPila(6);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<Sentencia>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 36];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;

                                    case -24:
                                        //R23
                                        PopPila(5);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<Sentencia>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 36];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;

                                    case -25:
                                        //R24
                                        PopPila(3);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<Sentencia>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 36];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;

                                    case -26:
                                        //R25
                                        PopPila(2);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<Sentencia>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 36];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;
                                    case -27:
                                        //R26
                                        PopPila(0);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<Otro>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 37];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;

                                    case -28:
                                        //R27
                                        PopPila(2);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<Otro>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 37];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;

                                    case -29:
                                        //R28
                                        PopPila(3);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<Bloque>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 38];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;

                                    case -30:
                                        //R29
                                        PopPila(0);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<ValorRegresa>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 39];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;

                                    case -31:
                                        //R30
                                        PopPila(1);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<ValorRegresa>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 39];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;

                                    case -32:
                                        //R31
                                        PopPila(0);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<Argumentos>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 40];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;

                                    case -33:
                                        //R32
                                        PopPila(2);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<Argumentos>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 40];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;

                                    case -34:
                                        //R33
                                        PopPila(0);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<ListaArgumentos>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 41];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;

                                    case -35:
                                        //R34
                                        PopPila(3);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<ListaArgumentos>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 41];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;

                                    case -36:
                                        //R35
                                        PopPila(1);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<Termino>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 42];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;

                                    case -37:
                                        //R36

                                        PopPila(1);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<Termino>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 42];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;

                                    case -38:
                                        //R37
                                        PopPila(1);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<Termino>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 42];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;

                                    case -39:
                                        //R38
                                        PopPila(1);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<Termino>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 42];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;

                                    case -40:
                                        //R39
                                        PopPila(1);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<Termino>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 42];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;

                                    case -41:
                                        //R40
                                        PopPila(4);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<LlamadaFunc>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 43];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;

                                    case -42:
                                        //R41
                                        PopPila(1);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<SentenciaBloque>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 44];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;

                                    case -43:
                                        //R42
                                        PopPila(1);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<SentenciaBloque>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 44];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;

                                    case -44:
                                        //R43
                                        PopPila(3);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<Expresion>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 45];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;

                                    case -45:
                                        //R44
                                        PopPila(2);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<Expresion>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 45];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;

                                    case -46:
                                        //R45
                                        PopPila(2);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<Expresion>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 45];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;

                                    case -47:
                                        PopPila(3);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<Expresion>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 45];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;

                                    case -48:
                                        //R47
                                        PopPila(3);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<Expresion>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 45];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;

                                    case -49:
                                        //R48

                                        PopPila(3);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<Expresion>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 45];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;

                                    case -50:
                                        //R49
                                        PopPila(3);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<Expresion>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 45];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;

                                    case -51:
                                        //R50
                                        PopPila(3);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<Expresion>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 45];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;

                                    case -52:
                                        //R51
                                        PopPila(3);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<Expresion>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 45];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;

                                    case -53:
                                        //R52
                                        PopPila(1);

                                        fila = Int32.Parse(pila.Top().cadena);

                                        elemento = new EP("<Expresion>");

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        accion = LR[fila, 45];
                                        //Results_Sintactico.Text += accion.ToString();
                                        elemento = new EP(accion.ToString());

                                        pila.Push(elemento);
                                        //Results_Sintactico.Text += elemento.cadena;
                                        i--;

                                        break;
                                    default:
                                        break;

                                }


                            }
                            else if (accion == 0)
                            {
                                error = true;
                                ErroresSintacticos(columna);
                                parcing = false;

                            }
                            else
                            {
                                elemento = new EP(token);
                                pila.Push(elemento);
                                elemento = new EP(accion.ToString());
                                pila.Push(elemento);
                            }

                            data = "";
                            Results_Sintactico.Text += pila.Show() + "\r\n";
                            break;
                        }
                    default:
                        {
                            data += c;
                            break;
                        }
                }
                i++;
            }
        }
        public void AnalizadorSemantico(List<string> programa)
        {
            //Comprobar todo lo que esta definido
            Results_Semantico.Text = "---Definiciones---" + "\r\n";

            int i = 0;
            string variable;
            string valor;
            string element;
            while (i < programa.Count)
            {
                variable = "";
                valor = "0";
                element = programa[i];
                //int definido
                if (element == "int:tipo:4")
                {
                    foreach (char caracter in programa[i + 1])
                    {
                        if (caracter == ':')
                        {
                            break;
                        }
                        else
                        {
                            variable += caracter;
                        }
                    }
                    if (programa[i + 2][0] == '(')
                    {
                        valor = "<Funcion>";
                    }
                    if(semantico.FindInt(variable) > -1 || semantico.FindFloat(variable) > -1)
                    {
                        Results_Console.Text +="'" + variable + "' -> was defined before" + "\r\n";
                    }
                    else
                    {
                        Results_Semantico.Text += "int" + " " + variable + " = " + valor + "\r\n";
                        semantico.AddDefinido(variable, "int", valor);
                    }
                    
                }
                //float definido
                if (element == "float:tipo:4")
                {
                    foreach (char caracter in programa[i + 1])
                    {
                        if (caracter == ':')
                        {
                            break;
                        }
                        else
                        {
                            variable += caracter;
                        }
                    }
                    if (programa[i + 2][0] == '(')
                    {
                        valor = "<Funcion>";
                    }
                    if (semantico.FindFloat(variable) > -1 || semantico.FindInt(variable) > -1)
                    {
                        Results_Console.Text += "'" + variable + "' -> was defined before" + "\r\n";
                    }
                    else
                    {
                        Results_Semantico.Text += "float" + " " + variable + " = " + valor + "\r\n";
                        semantico.AddDefinido(variable, "float", valor);
                    }
                    
                }
                if (element == "void:tipo:4")
                {
                    foreach (char caracter in programa[i + 1])
                    {
                        if (caracter == ':')
                        {
                            break;
                        }
                        else
                        {
                            variable += caracter;
                        }
                    }
                    if (programa[i + 2][0] == '(')
                    {
                        valor = "<Funcion>";
                    }
                    if (semantico.FindVoid(variable) > -1 || semantico.FindVoid(variable) > -1)
                    {
                        Results_Console.Text += "'" + variable + "' -> was defined before" + "\r\n";
                    }
                    else
                    {
                        Results_Semantico.Text += "void" + " " + variable + " = " + valor + "\r\n";
                        semantico.AddDefinido(variable, "void", valor);
                    }
                }
                i++;
            }

            //Comprobar que todo lo usado esta definido
            i = 0;
            while (i < programa.Count)
            {
                variable = "";
                element = programa[i];

                if (element.Contains("identificador"))
                {
                    foreach (char caracter in element)
                    {
                        if (caracter == ':')
                        {
                            break;
                        }
                        else
                        {
                            variable += caracter;
                        }
                    }
                    if (semantico.FindInt(variable) == -1 && semantico.FindFloat(variable) == -1 && semantico.FindVoid(variable) == -1)
                    {
                        Results_Console.Text += " ' " + variable + " ' " + " -> No Definida" + "\r\n";
                        error = true;
                    }
                }
                i++;
            }
            if (error)
            {
                Results_Console.Text += "Analisis Semantico Fallido" + "\r\n";
                return;
            }
            //Comprobar que todo lo que se usa y esta definido se esta operando correctamente
            i = 0;
            string tipo;
            string variable2;
            int entero = 0;
            float flotante = 0;
            while (i < programa.Count)
            {
                variable = "";
                element = programa[i];

                if (element.Contains("identificador"))
                {
                    //Operacion inminente
                    if(programa[i + 1] == "=:igual:18")
                    {
                        //Variable tras =
                        foreach (char caracter in element)
                        {
                            if (caracter == ':')
                            {
                                break;
                            }
                            else
                            {
                                variable += caracter;
                            }
                        }
                        if (semantico.FindInt(variable) > -1)
                        {
                            tipo = "int";
                        }
                        else
                        {
                            tipo = "float";
                        }
                        do
                        {
                            variable2 = "";
                            i++;
                            i++;
                            foreach (char caracter in programa[i])
                            {
                                if (caracter == ':')
                                {
                                    break;
                                }
                                else
                                {
                                    variable2 += caracter;
                                }
                            }
                            if (tipo == "int")
                            {
                                if(Int32.TryParse(variable2, out entero))
                                {
                                    
                                }
                                else if(semantico.FindInt(variable2) == -1)
                                {
                                    Results_Console.Text += " ' " + variable2 + " ' " + " -> Incoherencia de tipo" + "\r\n";
                                    error = true;
                                }
                            }
                            else
                            {
                                if (float.TryParse(variable2,out flotante))
                                {

                                }
                                else if (semantico.FindFloat(variable2) == -1)
                                {
                                    Results_Console.Text += " ' " + variable2 + " ' " + " -> Incoherencia de tipo" + "\r\n";
                                    error = true;
                                }
                            }
                            
                        } while (programa[i + 1] != ";:puntoComa:12");
                    }
                    else if (programa[i + 1] == "=:opIgualdad:11")
                    {
                        //Variable tras =
                        foreach (char caracter in element)
                        {
                            if (caracter == ':')
                            {
                                break;
                            }
                            else
                            {
                                variable += caracter;
                            }
                        }
                        if (semantico.FindInt(variable) > -1)
                        {
                            tipo = "int";
                        }
                        else
                        {
                            tipo = "float";
                        }
                        do
                        {
                            variable2 = "";
                            i++;
                            i++;
                            foreach (char caracter in programa[i])
                            {
                                if (caracter == ':')
                                {
                                    break;
                                }
                                else
                                {
                                    variable2 += caracter;
                                }
                            }
                            if (tipo == "int")
                            {
                                if (Int32.TryParse(variable2, out entero))
                                {

                                }
                                else if (semantico.FindInt(variable2) == -1)
                                {
                                    Results_Console.Text += " ' " + variable2 + " ' " + " -> Incoherencia de tipo" + "\r\n";
                                    error = true;
                                }
                            }
                            else
                            {
                                if (float.TryParse(variable2, out flotante))
                                {

                                }
                                else if (semantico.FindFloat(variable2) == -1)
                                {
                                    Results_Console.Text += " ' " + variable2 + " ' " + " -> Incoherencia de tipo" + "\r\n";
                                    error = true;
                                }
                            }

                        } while (programa[i + 1] != "):parentesisClose:15");
                    }
                }
                i++;
            }
            if(!error)
            {
                Results_Console.Text += "Analisis Semantico Completado con Exito!" + "\r\n";
            }
            else
            {
                Results_Console.Text += "Analisis Semantico Fallido!" + "\r\n";
            }

        }
        public void Ejecucion()
        {

        }
        public void PopPila(int tokens)
        {
            int PopTokens, i = 0;
            PopTokens = tokens * 2;
            while(i<PopTokens)
            {
                pila.Pop();
                i++;
            }
        }
        public void ErroresSintacticos(int error)
        {
            Results_Console.Text += "Error sintactico, analisis fallido: " + error.ToString() + "\r\n";
            string msgError = "";
            if(error< 4)
            {
                msgError = ";";
            }
            else if(error< 12)
            {
                msgError = "Variable";
            }
            else if (error == 23)
            {
                msgError = "}";
            }
            Results_Console.Text += "Syntax Error ' " + MensajesError[error] + " '" + "\r\n";
            Results_Console.Text += "Se esperaba -> ' " + msgError + " '";
        }
    }
}
