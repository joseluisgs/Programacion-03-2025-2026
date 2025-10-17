
## Cuestionario Tipo Test: Aplicación de Estructuras de Almacenamiento (50 Preguntas)

- [Cuestionario Tipo Test: Aplicación de Estructuras de Almacenamiento (50 Preguntas)](#cuestionario-tipo-test-aplicación-de-estructuras-de-almacenamiento-50-preguntas)
  - [I. Arrays Unidimensionales (Vectores)](#i-arrays-unidimensionales-vectores)
  - [II. Arrays Multidimensionales (Matrices)](#ii-arrays-multidimensionales-matrices)
  - [III. Cadenas de Texto (Strings)](#iii-cadenas-de-texto-strings)
  - [IV. Expresiones Regulares (Regex)](#iv-expresiones-regulares-regex)
  - [V. Algoritmos de Ordenación y Búsqueda](#v-algoritmos-de-ordenación-y-búsqueda)


### I. Arrays Unidimensionales (Vectores)

1. ¿Cuál de las siguientes **NO** es una característica clave de los arrays en el lenguaje DAW?
    A) Contigüidad en Memoria.
    B) Homogeneidad (todos los elementos del mismo tipo).
    C) Tamaño Mutable después de la creación.
    D) Acceso a elementos en tiempo constante $O(1)$.

2. La Indexación Basada en Cero es el estándar en DAW. ¿Qué representa el índice 0 según el fundamento de este enfoque?
    A) La posición ordinal (el primer elemento).
    B) La Dirección Base más el tamaño del tipo de dato.
    C) El desplazamiento (*offset*) cero desde la dirección de inicio del array.
    D) Una convención puramente matemática, como en Fortran.

3. Si en DAW se intenta acceder a una posición de un array que es negativa o igual/mayor a su tamaño, ¿qué excepción de tiempo de ejecución se genera?
    A) `NullReferenceException`.
    B) `StackOverflowException`.
    C) `ArrayIndexOutOfBoundsException`.
    D) `SystemError`.

4. Si un array de tipo `int[]` se crea solo con su tamaño (`new int;`), ¿cuál es el valor por defecto que se almacena automáticamente en cada posición?
    A) `null`.
    B) `""` (Cadena vacía).
    C) `0`.
    D) `-1`.

5. Un array de tipo anulable (`T?[]`) se inicializa, por defecto, con qué valor en todas sus posiciones.
    A) El valor por defecto del tipo base `T`.
    B) `false`.
    C) `0`.
    D) `null`.

6. La inmutabilidad del tamaño de los arrays en DAW implica que, si se necesita un tamaño diferente, ¿cuál es la única solución que debe aplicar el programador?
    A) Usar la propiedad `.Resize()`.
    B) Crear un nuevo array y copiar los elementos existentes.
    C) Modificar el índice de la última posición.
    D) Convertir el array a un tipo `List`.

7. Para recorrer un array cuando se necesita **modificar** los elementos o si se requiere conocer el **índice (i)** de la posición actual, ¿qué tipo de bucle se recomienda utilizar?
    A) `while`.
    B) `foreach`.
    C) `do-while`.
    D) `for`.

8. ¿Por qué se considera que los arrays son **tipos de referencia** en DAW?
    A) Porque almacenan directamente los datos.
    B) Porque la variable almacena la dirección de memoria donde se encuentran los datos.
    C) Porque su tamaño es inmutable.
    D) Porque todos sus elementos deben ser del mismo tipo.

9. Cuando se pasa un array a una función en DAW, se pasa una copia de la dirección de memoria (referencia). Si se modifican los elementos dentro de la función, ¿qué efecto tiene sobre el array original?
    A) El array original no se modifica porque se usa el paso por valor.
    B) El array original se modifica porque ambas variables apuntan al mismo sitio.
    C) Solo se modifica el tamaño del array original.
    D) Se produce un `ArrayIndexOutOfBoundsException`.

10. ¿Qué se debe hacer para obtener un array **completamente independiente** de otro, rompiendo la referencia?
    A) Aplicar una Copia por Referencia (`var arrayB = arrayA;`).
    B) Clonar manualmente el contenido elemento por elemento (Copia Profunda).
    C) Comparar ambos arrays con el operador `==`.
    D) Usar un bucle `foreach`.

11. ¿Qué compara el operador de igualdad (`==`) cuando se utiliza para comparar dos variables que contienen arrays en DAW?
    A) Si tienen el mismo contenido (Igualdad).
    B) Si apuntan a la misma dirección de memoria (Identidad).
    C) Si tienen la misma longitud.
    D) El tiempo de acceso $O(1)$.

12. ¿Qué requisito fundamental debe cumplir un vector para que se pueda aplicar eficientemente el algoritmo de **Búsqueda Binaria**?
    A) Que no contenga elementos repetidos.
    B) Que sea un array escalonado.
    C) Que el vector esté previamente ordenado.
    D) Que se haya calculado la media de sus elementos.

13. ¿Qué significa que un vector de números sea **capicúa**?
    A) Que la suma de sus elementos es cero.
    B) Que el orden de sus elementos es el mismo de izquierda a derecha que de derecha a izquierda.
    C) Que todos sus elementos son pares.
    D) Que se ha invertido su orden.

### II. Arrays Multidimensionales (Matrices)

14. En el contexto de arrays multidimensionales, ¿cuántos índices se necesitan para poder identificar un elemento en un array bidimensional (matriz)?
    A) Uno (la posición lineal).
    B) Dos (fila y columna).
    C) Tres (base, fila y columna).
    D) Uno (usando la propiedad `.Length`).

15. El modelo de matrices utilizado en DAW se llama Array Escalonado (*Jagged Array*). ¿Cuál es la principal propiedad que este modelo permite?
    A) Que todas las filas tengan exactamente la misma longitud.
    B) Que cada sub-array (fila) pueda tener una longitud diferente.
    C) El almacenamiento por columnas (*Column-Major Order*).
    D) El uso obligatorio de `null` en todas las posiciones.

16. La matriz en DAW se almacena en memoria usando el orden por filas (*Row-Major Order*). ¿Por qué es más eficiente recorrer los datos iterando primero sobre el índice de la fila?
    A) Porque garantiza que todas las filas tengan el mismo tamaño.
    B) Porque los datos de una fila están contiguos en la memoria caché del procesador.
    C) Porque la complejidad es $O(1)$.
    D) Porque el modelo de Array Escalonado lo obliga.

17. ¿Qué significa **Transponer una matriz** $A$ de orden $N \times N$?
    A) Calcular su determinante.
    B) Intercambiar los elementos de la diagonal principal.
    C) Intercambiar las filas por las columnas y viceversa ($A_{i,j} = B_{j,i}$).
    D) Girarla 90 grados en el sentido de las agujas del reloj.

18. En una matriz $A$ de orden $N \times N$, ¿cuál es la condición que debe cumplirse para que se considere **simétrica**?
    A) $A_{i,j} = A_{i,i}$.
    B) $A_{i,j} = A_{j,i}$ para todo $i, j$.
    C) La suma de sus elementos debe ser cero.
    D) El determinante debe ser positivo.

19. ¿Por qué se considera que una **Copia Superficial Engañosa** de una matriz es peligrosa, incluso si el array exterior es nuevo?
    A) Porque el tamaño se vuelve mutable.
    B) Porque las referencias a las filas internas (sub-arrays) siguen siendo compartidas, y modificar una fila afecta a ambas matrices.
    C) Porque genera una `ArrayIndexOutOfBoundsException`.
    D) Porque el Doble Búfer no funciona correctamente.

20. ¿Qué técnica es necesaria para lograr la **Clonación Profunda** y garantizar la independencia total entre la matriz original y la copia?
    A) Clonar el array exterior y los arrays internos de forma manual.
    B) Usar el operador `==`.
    C) Utilizar la técnica de Doble Búfer.
    D) Declarar la matriz como un tipo anulable.

21. ¿Cuál es el propósito del **Búfer de Escritura (Back Buffer)** en la técnica de Doble Búfer?
    A) La matriz que se está leyendo o mostrando en pantalla.
    B) La matriz donde se aplican todas las modificaciones y cálculos de la siguiente iteración.
    C) El array que contiene los índices.
    D) El elemento pivote de la simulación.

22. El **Mecanismo de Intercambio (Swap)** de referencias en el Doble Búfer es crucial por su eficiencia. ¿Cuál es su complejidad algorítmica y qué significa?
    A) $O(n^2)$, es lenta.
    B) $O(n \log n)$, es linealítmica.
    C) $O(n)$, depende del tamaño de la matriz.
    D) $O(1)$ (Constante), es instantánea.

23. ¿Cuál es el objetivo didáctico al realizar un ejercicio de permutación de filas o columnas en una matriz?
    A) Demostrar que el acceso es $O(1)$.
    B) Mostrar la manipulación de las referencias internas que componen el Array Escalonado.
    C) Mostrar el uso de la inmutabilidad del tamaño.
    D) Implementar una función que calcule la media.

24. En el contexto de ejercicios de matrices, la tarea de **Girar una matriz 90º** en el sentido de las agujas del reloj es un ejemplo de:
    A) Operación de suma de diagonales.
    B) Transformación espacial y manipulación de índices.
    C) Uso de la Búsqueda Binaria.
    D) Definición de una matriz simétrica.

25. El ejercicio del juego de **"Barquitos clásico"** con un vector o matriz requiere, lógicamente, llevar dos paneles para cada jugador. ¿Qué representa cada panel?
    A) Solo uno para la flota y uno para los resultados finales.
    B) Uno para su flota (sus barcos) y otro para sus tiradas (registrando los disparos al enemigo).
    C) Uno para el índice y otro para el valor.
    D) El Front Buffer y el Back Buffer.

### III. Cadenas de Texto (Strings)

26. ¿Qué implica la **Inmutabilidad** de las cadenas de texto en DAW?
    A) Que la cadena original se modifica en memoria.
    B) Que la cadena puede ser alterada por cualquier método.
    C) Que cualquier método que parezca modificar la cadena en realidad devuelve una nueva cadena.
    D) Que el operador `==` compara referencias.

27. Aunque los strings son tipos de referencia, ¿por qué el operador de igualdad (`==`) realiza una comparación de valor (contenido)?
    A) Porque el compilador lo prohíbe.
    B) Para simplificar la programación, permitiendo comparar si dos cadenas son iguales en contenido.
    C) Porque el acceso es $O(1)$.
    D) Para garantizar la inmutabilidad.

28. En lenguajes simplificados como DAW, ¿cómo se representa un carácter individual (`char`)?
    A) Como un tipo primitivo `char`.
    B) Como un objeto `Character`.
    C) Como una cadena (`string`) de longitud 1.
    D) Como un `int` (código ASCII).

29. ¿Qué hace el método esencial de limpieza `.Trim()` de una cadena?
    A) Convierte la cadena a mayúsculas.
    B) Elimina los espacios en blanco, tabulaciones y saltos de línea del inicio y final de la cadena.
    C) Extrae una subcadena.
    D) Reemplaza todas las vocales.

30. ¿Qué método o propiedad se utiliza para contar la cantidad de caracteres que tiene una cadena?
    A) `.Count()`.
    B) `.Length`.
    C) `.Size()`.
    D) `.Index()`.

31. Si se usa el operador `+` para concatenar repetitivamente una cadena dentro de un bucle, ¿por qué se degrada el rendimiento a una complejidad $O(n^2)$?
    A) Porque el compilador lo optimiza.
    B) Porque en cada concatenación se crea una nueva cadena en memoria.
    C) Porque se utiliza la Indexación Basada en Uno.
    D) Porque el algoritmo es recursivo.

32. ¿Qué clase en DAW está diseñada específicamente para construir cadenas mutables de forma eficiente, realizando la operación de anexión en tiempo lineal ($O(n)$)?
    A) `StringBuilter`.
    B) `ArrayString`.
    C) `Regex`.
    D) `StringBuilder`.

33. ¿Cuándo se utiliza el método `.ToString()` sobre una instancia de `StringBuilder`?
    A) Solo al inicio del bucle.
    B) Cuando se desea agregar un nuevo valor.
    C) Solo al final, para convertir el contenido mutable en una cadena `string` inmutable y final.
    D) Siempre que se usa el método `.Append()`.

34. ¿Qué operación realiza el juego "La clave del César"?
    A) Busca la palabra más larga.
    B) Reemplaza cada letra por la que sigue en el abecedario (y 9 por 0, Z por A).
    C) Comprueba si una cadena está incluida en otra.
    D) Cuenta el número de palabras en un texto.

35. ¿Cuál es el método de la clase `string` más adecuado para extraer una porción de la cadena a partir de un índice de inicio dado?
    A) `.Replace()`.
    B) `.IndexOf()`.
    C) `.Contains()`.
    D) `.Substring()`.

36. El juego del Ahorcado establece un límite de intentos. ¿Cuántos intentos se conceden al usuario?
    A) 5 intentos.
    B) 7 intentos.
    C) 10 intentos.
    D) Un número ilimitado.

### IV. Expresiones Regulares (Regex)

37. ¿Qué es una Expresión Regular (*Regex*) en esencia?
    A) Una función para concatenar strings de forma eficiente.
    B) Un patrón o lenguaje de programación en miniatura para describir y encontrar estructuras de texto.
    C) Un algoritmo de ordenación $O(n \log n)$.
    D) Una forma de convertir arrays a strings.

38. En Regex, ¿cuál es el término genérico para los símbolos especiales (como `\d` o `+`) que definen la regla de búsqueda?
    A) Constantes.
    B) Literales.
    C) Metacaracteres.
    D) Delimitadores.

39. Si un patrón Regex usa `\d+`, ¿qué significa la combinación?
    A) Cero o más caracteres de palabra.
    B) Exactamente un dígito.
    C) Una o más veces un dígito (uno o más dígitos).
    D) Un carácter cualquiera seguido de una palabra.

40. Para validar un formato de datos (ej. un DNI) usando `.IsMatch()`, ¿qué dos metacaracteres se deben utilizar para **anclar** el patrón y asegurar que se valide la cadena completa, y no solo una subcadena?
    A) `.` y `*`.
    B) `(` y `)`.
    C) `^` (inicio de cadena) y `$` (fin de cadena).
    D) `\w` y `\s`.

41. ¿Qué método de la clase `Regex` se utiliza para comprobar si el patrón se encuentra **en alguna parte** de la cadena, devolviendo un valor booleano?
    A) `.Replace(cadena, nuevo)`.
    B) `.IsMatch(cadena)`.
    C) `.Match(cadena)`.
    D) `.Matches(cadena)`.

### V. Algoritmos de Ordenación y Búsqueda

42. ¿Cuál de los siguientes algoritmos de ordenación $O(n^2)$ realiza el **mínimo número de intercambios** (*swaps*), lo que es una ventaja si la escritura a memoria es costosa?
    A) Algoritmo de Burbuja (*Bubble Sort*).
    B) Algoritmo de Inserción (*Insertion Sort*).
    C) Algoritmo de Selección (*Selection Sort*).
    D) Algoritmo QuickSort.

43. ¿Cuál de los algoritmos $O(n^2)$ (Burbuja, Selección, Inserción) ofrece el mejor rendimiento en el **mejor caso ($O(n)$)**, especialmente si el array ya está casi ordenado?
    A) Algoritmo de Selección.
    B) Algoritmo de Burbuja.
    C) Algoritmo de Inserción.
    D) Algoritmo Shell Sort.

44. El algoritmo **QuickSort** es un método de "Divide y Vencerás". ¿Qué elemento utiliza para reordenar el array de manera que todos los menores queden a la izquierda y los mayores a la derecha?
    A) La mediana.
    B) El elemento pivote.
    C) El índice central.
    D) Un búfer auxiliar.

45. ¿Cuál es la complejidad algorítmica del algoritmo QuickSort en el **caso promedio**, lo que lo convierte en el más rápido para propósito general en grandes conjuntos de datos?
    A) $O(n^2)$.
    B) $O(n)$.
    C) $O(n \log n)$.
    D) $O(1)$.

46. ¿Qué mejora aplica el algoritmo **Shell Sort** al Insertion Sort, permitiendo que elementos desordenados se muevan rápidamente a través de la lista?
    A) Usa un elemento pivote.
    B) Compara y realiza intercambios entre elementos separados por un **intervalo (*gap*)** mayor a 1.
    C) Es un algoritmo estable.
    D) Es inherentemente recursivo.

47. La **Búsqueda Lineal o Secuencial** no requiere ninguna precondición, pero en el peor caso (elemento al final o ausente), ¿cuál es su complejidad?
    A) $O(\log n)$ (Logarítmica).
    B) $O(n^2)$ (Cuadrática).
    C) $O(n)$ (Lineal).
    D) $O(1)$ (Constante).

48. ¿Cuál es la **precondición** obligatoria para poder utilizar el algoritmo de Búsqueda Binaria o Dicotómica?
    A) Que la colección no sea recursiva.
    B) Que la colección esté previamente ordenada.
    C) Que la colección contenga solo tipos de referencia.
    D) Que el elemento clave sea un número entero.

49. En la Búsqueda Binaria, si el dato buscado es **menor** que el elemento central del vector, ¿en qué sub-espacio se debe continuar el proceso de forma recursiva (o iterativa)?
    A) En la mitad derecha del vector.
    B) En la mitad izquierda del vector.
    C) En todo el vector, sin dividirlo.
    D) El algoritmo se detiene.

50. En el juego del "Número de pivote", una vez que el usuario elige la posición del pivote, ¿qué dos cálculos específicos se deben realizar con respecto a los elementos situados a la izquierda de esa posición?
    A) Solo la media del vector completo.
    B) La suma de todos los elementos a la izquierda y el número de elementos que son mayores y menores que el pivote.
    C) La ordenación por burbuja y el cálculo del determinante.
    D) La clonación del vector y la comprobación de nulidad.