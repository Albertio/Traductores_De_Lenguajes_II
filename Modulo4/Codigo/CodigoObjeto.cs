using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbyssC
{
    public class CodigoObjeto
    {
        public string Run(string cCode)
        {
            string assemblyCode = ConvertCToAssembly(cCode);

            Console.WriteLine(assemblyCode);
            return (assemblyCode);
        }

        static string ConvertCToAssembly(string cCode)
        {
            string[] lines = cCode.Split('\n');
            string assemblyCode = "";

            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();

                if (trimmedLine.StartsWith("#include"))
                {
                    // Directiva de inclusión, puedes manejarla según tus necesidades
                    // Aquí simplemente la ignoramos
                    continue;
                }
                else if (trimmedLine.StartsWith("int main()"))
                {
                    // Encabezado de la función principal
                    assemblyCode += "section .text\n";
                    assemblyCode += "global _start\n";
                    assemblyCode += "_start:\n";
                    continue;
                }
                else if (trimmedLine.StartsWith("int "))
                {
                    // Declaración de variable
                    string[] tokens = trimmedLine.Split(' ');
                    string variableName = tokens[1].TrimEnd(';');
                    assemblyCode += $"    mov dword [{variableName}], 0\n";
                }
                else if (trimmedLine.StartsWith("return"))
                {
                    // Sentencia de retorno
                    assemblyCode += "    mov eax, 1\n";
                    assemblyCode += "    xor ebx, ebx\n";
                    assemblyCode += "    int 0x80\n";
                }
            }

            return assemblyCode;
        }

        static string GetFormatString(string printfLine)
        {
            int startIndex = printfLine.IndexOf('"') + 1;
            int endIndex = printfLine.LastIndexOf('"');
            return printfLine.Substring(startIndex, endIndex - startIndex);
        }
    }
}