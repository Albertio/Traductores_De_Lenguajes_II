# Traductores_De_Lenguajes_II
Repositorio Creado para entregar las tareas correspondientes a la materia de traductores de lenguajes 2

<a href="https://github.com/Albertio/Traductores_De_Lenguajes_II/tree/main/Modulo1">Modulo 1. Analizador Lexico</a>

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

<a href="https://github.com/Albertio/Traductores_De_Lenguajes_II/tree/main/Modulo1">Carpeta de Modulo 1</a>

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


<a href="https://github.com/Albertio/Traductores_De_Lenguajes_II/tree/main/Modulo2">Modulo 2. Analizador Sintactico</a>

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

Tras esto es necesario tener en cuenta las siguientes reglas asi como haber desarrollado las reducciones correspondientes a la longitud en palabras que se aplicaran a nuestra pila para ser procesadas y podernos desplazar por nuestra tabla LR:

![alt tag](https://github.com/Albertio/Traductores_De_Lenguajes_II/blob/main/ProyectoFinal/Imagenes/10.png)

Ademas de tener bien en cuenta asi como integrar a nuestro algoritmo la tabla LR de la que ya se ha hablado con anterioridad:

![alt tag](https://github.com/Albertio/Traductores_De_Lenguajes_II/blob/main/ProyectoFinal/Imagenes/11.png)

Tras definir todo lo anterior para realizar la validacion de los componentes en nuestra pila y su posterior almacenamiento para procesar los resultados en lo que en el futuro sera el analizador semantico, simplemente observamos los resultados para comprobar el funcionamiento.

Entonces para finalizar, comprobamos las entradas y salidas de nuestro analizador sintactico, asi como el estado de la pila durante todo el proceso de analisis.

Comprobacion:

![alt tag](https://github.com/Albertio/Traductores_De_Lenguajes_II/blob/main/ProyectoFinal/Imagenes/8.png)

Contenido en la pila:

![alt tag](https://github.com/Albertio/Traductores_De_Lenguajes_II/blob/main/ProyectoFinal/Imagenes/9.png)

*Observamos un analisis exitoso, sin errores ni problemas, lo que deberia ser siempre que una entrada no contenga errores como los siguientes.

Para ver mas detalles y el proceso de codificacion consultar la carpeta:

<a href="https://github.com/Albertio/Traductores_De_Lenguajes_II/tree/main/Modulo2">Carpeta de Modulo 2</a>

<a href="https://github.com/Albertio/Traductores_De_Lenguajes_II/tree/main/Modulo3">Modulo 3. Analizador Semantico</a>
El desarrollo de un analizador semántico implica varias etapas y consideraciones importantes. A continuación, se describe el proceso general para crear un analizador semántico:

Definir las reglas semánticas: Antes de comenzar a implementar el analizador semántico, es esencial comprender las reglas semánticas del lenguaje de programación en el que se trabajará. Por fortuna se aclaro desde un comienzo que estas reglas seran ni mas ni menos lo mas similar posible al lenguaje de programacion "c".

Obtener el árbol sintáctico: El analizador semántico se basa en el árbol sintáctico generado por el analizador sintáctico.
Por lo que es de vital importancia que a este punto nuestro analizador sintactico funciones satisfactoriamente, de lo contrario, podriamos encontrarnos con problemas no deseados.

Diseñar las estructuras de datos: Para llevar a cabo las comprobaciones semánticas, es necesario diseñar las estructuras de datos adecuadas para almacenar información relevante sobre el código fuente. Esto puede incluir tablas de símbolos para variables y funciones, tablas de tipos, pilas de alcance, entre otros. Estas estructuras ayudarán a realizar verificaciones coherentes y eficientes.

Implementar las comprobaciones semánticas: En esta etapa, se implementan las reglas semánticas definidas anteriormente. Se recorre el árbol sintáctico y se aplican las comprobaciones correspondientes a cada nodo. Por ejemplo, se pueden verificar las asignaciones de tipos, la declaración y el uso correcto de variables, la resolución de nombres, la herencia adecuada, etc.

Manejar errores semánticos: Durante el análisis semántico, es posible encontrar errores en el código fuente que violen las reglas semánticas. En esta etapa, se deben manejar estos errores de manera apropiada, generando mensajes de error descriptivos para ayudar al programador a corregir los problemas detectados.

Realizar pruebas y depuración: Una vez implementado el analizador semántico, es esencial realizar pruebas exhaustivas para verificar su correcto funcionamiento. Se deben realizar pruebas con casos de prueba representativos que cubran diversas situaciones semánticas, incluyendo tanto escenarios válidos como inválidos. Además, se deben depurar posibles errores y realizar mejoras si es necesario.

Enseguida vemos un par de pruebas:
*Un error por incoherencia de tipo*
![alt tag](https://github.com/Albertio/Traductores_De_Lenguajes_II/blob/main/ProyectoFinal/Imagenes/12.png)
*El error se resuelve si colocamos el tipo correcto*
![alt tag](https://github.com/Albertio/Traductores_De_Lenguajes_II/blob/main/ProyectoFinal/Imagenes/13.png)
*Incoherencia de tipo entre variables*
![alt tag](https://github.com/Albertio/Traductores_De_Lenguajes_II/blob/main/ProyectoFinal/Imagenes/14.png)
*Incoherencia por omision de definicion*
![alt tag](https://github.com/Albertio/Traductores_De_Lenguajes_II/blob/main/ProyectoFinal/Imagenes/15.png)

Cada punto asi como mas muestras de codigos son posibles encontrarlas dentro de la carpeta correspondiente al Modulo 3:

<a href="https://github.com/Albertio/Traductores_De_Lenguajes_II/tree/main/Modulo3">Carpeta de Modulo 3</a>

Modulo 4. Codigo Objeto

El desarrollo de la fase de generación de código objeto implica varias tareas clave.

Diseño de la representación intermedia: Antes de comenzar a generar el código objeto, es necesario diseñar una representación intermedia adecuada. Esta representación puede ser un árbol de sintaxis abstracta, un código de tres direcciones, un grafo de flujo de control u otra estructura que capture la semántica del programa de manera eficiente. Esta representación intermedia servirá como base para generar el código objeto.

Traducción de construcciones de alto nivel a instrucciones de bajo nivel: En esta etapa, se implementan reglas y algoritmos para traducir las construcciones de alto nivel del lenguaje de programación en instrucciones de bajo nivel específicas de la arquitectura de la máquina objetivo. Esto puede incluir la asignación de registros, la gestión de la memoria, la generación de instrucciones aritméticas y lógicas, entre otros aspectos.

Gestión de la memoria: Durante la generación de código objeto, se deben tomar decisiones sobre la asignación y el uso eficiente de la memoria. Esto incluye la asignación de registros para variables, el manejo de la pila de llamadas y la gestión de datos estáticos. También es necesario considerar aspectos como el acceso a la memoria y la alineación de datos.

Optimización de código: En esta etapa, se pueden aplicar técnicas de optimización para mejorar la eficiencia y el rendimiento del código objeto generado. Esto puede implicar la eliminación de código redundante, la reorganización de instrucciones para minimizar saltos condicionales, la propagación de constantes, la fusión de instrucciones, entre otras técnicas.

Resolución de referencias: Durante la generación de código objeto, es posible que se hagan referencias a símbolos externos, como funciones o variables definidas en otros módulos o bibliotecas. En esta etapa, se debe implementar la resolución de referencias para asegurar que estas referencias se enlacen correctamente durante el proceso de enlace final.


Para finalizar se invita a ver los resultados asi como una documentacion mas extensa en su carpeta correspondiente:

<a href="https://github.com/Albertio/Traductores_De_Lenguajes_II/tree/main/Modulo4">Modulo 4</a>
