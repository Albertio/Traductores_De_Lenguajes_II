# Traductores_De_Lenguajes_II
Repositorio Creado para entregar las tareas correspondientes a la materia de traductores de lenguajes 2

Modulo 1. Analizador Lexico

Se realiza un interfaz temporal para mostrar todo lo respectivo:

![alt tag](https://github.com/Albertio/Traductores_De_Lenguajes_II/blob/main/ProyectoFinal/Imagenes/4.png)

Se realizan diccionarios para cada uno de los tipos de datos establecidos en la actividad, es decir, arreglos con los elementos especificos que pueden o deben contener una palabra en cuestion para ser considerada de algun tipo posible, los tipos a usar son los siguientes:

Identificador - Entero - Real - Cadena - Tipo - OpSuma - OpMul - OpRelac - OpOr - OpAnd - OpNot - OpIgualdad - PuntoComa - Coma - ParentesisOpen - ParentesisClose - CorcheteOpen - CorcheteClose - Igual - _if - _while - _return - _else - _terminal.

Todos estos estan definidos en la tabla de la actividad como simbolos lexicos para ser reconocidos:

![alt tag](https://github.com/Albertio/Traductores_De_Lenguajes_II/blob/main/ProyectoFinal/Imagenes/1.png)

El entorno en el que se trabajara es C#, siendo precisos en la parte de Windows Form, pues, de esta manera podemos desarrollar una interfaz mas agradable para el usuario y mostrar los resultados se hace mas sencillo.

Para realizar las validaciones de Identificadores, Entero y Real se realizaron 2 automatas que se usaron para la actividad anterior, ademas de eso para el resto de validaciones realizamos un sistema de discriminacion que separa las palabras por distintos tipos de separadores comunes y ademas se usan algunos de los mismo simbolos, pues, en muchas ocasiones estos se encuentran unidos a numeros u otros operadores.

En seguida se muestran los automatas:

Numeros Flotantes:

![alt tag](https://github.com/Albertio/Traductores_De_Lenguajes_II/blob/main/ProyectoFinal/Imagenes/2.png)

Identificadores:

![alt tag](https://github.com/Albertio/Traductores_De_Lenguajes_II/blob/main/ProyectoFinal/Imagenes/3.png)

Ahora, tras tener todo listo pasamos a la parte de codificacion.

Para ello se muestra a detalle lo realizado en la carpeta:

<a href="https://github.com/Albertio/Traductores_De_Lenguajes_II/tree/main/Modulo1">Modulo 1</a>

Los resultados del Analisis Lexico:
El codigo que se va a probar:

int main()
{
	while(numero ==1)
	{
	}
	flotante = 2.5;
	error = 123nombre;
	return 0;
}

![alt tag](https://github.com/Albertio/Traductores_De_Lenguajes_II/blob/main/ProyectoFinal/Imagenes/5.png)


Modulo 2. Analizador Sintactico

Para realizar el analisis sintactico y mas adelante poder realizar un analisis semantico, se deben realizar un par de clases nuevas, asi como hacer clases que heredan del objeto que se almacenara en nuestra pila.

Es decir, para esta práctica sera necesario crear una clase ElementoPila (EP) y modificaras la clase pila para que acepte objetos de este tipo en lugar de enteros.

Necesitaras crear 3 clases más, las cuales heredan de ElementoPila, las clases son:
- Terminal -> (que llamaremos T)
- No terminal -> (que llamaremos NT)
- Estado -> (que llamaremos E)

Entonces para esta actividad sera necesario hacer uso de una tabla de una analizador sintactico LR:

![alt tag](https://github.com/Albertio/Traductores_De_Lenguajes_II/blob/main/ProyectoFinal/Imagenes/6.png)

*Nota: considerar que lo mostrado aqui solo es una parte de la tabla

Ademas de esto, se debera crear un automata para que se haga el analisis sintactico de manera similar a como se realizaria a mano.

Para comenzar a trabajar e implementar los nuevos metodos y algoritmos se modifica el interfaz para hacer un poco de espacio extra para el analisis sintactico.

![alt tag](https://github.com/Albertio/Traductores_De_Lenguajes_II/blob/main/ProyectoFinal/Imagenes/7.png)

Para ver mas detalles y el proceso de codificacion consultar la carpeta:

<a href="https://github.com/Albertio/Traductores_De_Lenguajes_II/tree/main/Modulo2">Modulo 2</a>

Para finalizar, comprobamos las entradas y salidas de nuestro analizador sintactico, asi como el estado de la pila durante todo el proceso de analisis.

Comprobacion:

![alt tag](https://github.com/Albertio/Traductores_De_Lenguajes_II/blob/main/ProyectoFinal/Imagenes/8.png)

Contenido en la pila:

![alt tag](https://github.com/Albertio/Traductores_De_Lenguajes_II/blob/main/ProyectoFinal/Imagenes/9.png)

*Observamos un analisis exitoso, sin errores ni problemas, lo que deberia ser siempre que una entrada no contenga errores como los siguientes.

Modulo 3. Analizador Semantico


Modulo 4. Codigo Objeto




