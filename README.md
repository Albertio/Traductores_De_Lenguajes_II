# Traductores_De_Lenguajes_II
Repositorio Creado para entregar las tareas correspondientes a la materia de traductores de lenguajes 2
Introduccion.
Se realizan diccionarios para cada uno de los tipos de datos establecidos en la actividad, es decir, arreglos con los elementos especificos que pueden o deben contener una palabra en cuestion para ser considerada de algun tipo posible, los tipos a usar son los siguientes:

Identificador - Entero - Real - Cadena - Tipo - OpSuma - OpMul - OpRelac - OpOr - OpAnd - OpNot - OpIgualdad - PuntoComa - Coma - ParentesisOpen - ParentesisClose - CorcheteOpen - CorcheteClose - Igual - _if - _while - _return - _else - _terminal.

Todos estos estan definidos en la tabla de la actividad como simbolos lexicos para ser reconocidos:



El entorno en el que se trabajara es C#, siendo precisos en la parte de Windows Form, pues, de esta manera podemos desarrollar una interfaz mas agradable para el usuario y mostrar los resultados se hace mas sencillo.

Para realizar las validaciones de Identificadores, Entero y Real se realizaron 2 automatas que se usaron para la actividad anterior, ademas de eso para el resto de validaciones realizamos un sistema de discriminacion que separa las palabras por distintos tipos de separadores comunes y ademas se usan algunos de los mismo simbolos, pues, en muchas ocasiones estos se encuentran unidos a numeros u otros operadores.



En seguida se muestran los automatas:

Numeros Flotantes:


Identificadores:



Ahora, tras tener todo listo pasamos a la parte de codificacion.


Desarrollo.
Para comenzar, realizamos la interfaz del programa que nos ayudara a ingresar la informacion y tambien mostrar los resultados para poder comprobar que todo lo que haremos es correcto o incorrecto dependiendo cual sea el caso.

Enseguida, se hacen todos los diccionarios que nos facilitaran la busqueda y comprobacion y ademas se les coloca sus respectivos valores, se hace a manera de arreglo simple, pues, no es necesario incrementar los tamaños de los arreglos en tiempo de ejecucion, aunque posteriormente sera necesario realizar arreglos dinamicos para almacenar informacion.
Interfaz:

Codigo:



Tras esto se llena cada arreglo como se aclaro anteriormente con algunas modificaciones menores que normalmente veriamos normales en algunos lenguajes de programacion como la integracion de «_» a los identificadores que es algo bastante comun.




Como se observa hay un arreglo adicional el cual sera el encargado de mostrar los resultados correspondientes en cada uno de nuestros casos de validacion, esto se hace pensando a futuro pues, acostumbro hacerlo de esta manera para mas adelante, segun sea el caso, modificar los textos que muestra y optimizar el debuggin.

Ademas de lo anterior se crea un arreglo nuevo, que sera el responsable de separar las palabras para nosotros, esto con la finalidad de identificar comienzos y finales de palabras.


Tras las definicion de diccionarios comenzamos con programar la accion de un boton de ejecucion para procesar el texto del usuario y poder saber que ingreso, un codigo bastante simple y sin mucha complejidad, recorremos el texto ingresado en la espera de un separados mientras guardamos lo que vamos leyendo, y en caso de encontrar separados significa que hay que procesar nuestra palabra y el separador por separado para poder regresar que tipos de datos son:


       
Se puede ver que el retorno de AnalizadorLexico es un numero, el cual es proporcional a la posicion de un elemento en nuestro arreglo de Resultados.

Al entrar dentro del procesamiento Lexico se hace una comparacion de cada arreglo con la palabra en cuestion, para los Enteros, Reales e Identificadores la simple comparacion no es una manera fiable por lo que se usan los automatas.


Los automatas:


Se hace de esta manera para que al termino del procesamiento de la palabra completa tengamos 3 casos posibles, opc = 1, donde la palabra es un Entero, opc = 2, donde la palabra es un Real y por ultimo opc = -1, donde la palabra no es ninguno de los 2 y en general, no es nada aceptable, es decir, es un ERROR.


Ademas retornamos su valor correspondiente en el arreglo de Resultados e incluimos el error como un elemento mas.

Conclusiones.
Para finalizar la realizacion del Analizador Lexico realizamos la prueba de un par de codigos basicos para ver si el programa es capaz de disernir entre todos los elementos que yo escriba y ademas el programa sea capaz de identificar.

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

Pantalla pre-comprobacion:


Comprobacion:


Podemos apreciar que efectivamente funciona y es capaz de diferenciar incluso los Igual asingativos de los igual comparativos, ademas de identificar un error y diferenciar los tipos de numero Real de Entero asi como los respectivos identificadores.
