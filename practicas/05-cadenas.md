## 20 Ejercicios de Aplicación: Cadenas de Texto y Expresiones Regulares



### I. Manipulación y Lógica de Cadenas (Strings)

1.  **Comparación de Cadenas y Longitud:** Solicite dos cadenas de texto al usuario por teclado y realice las siguientes comparaciones: a) Determine si son iguales en contenido; b) Compare sus longitudes; c) Determine cuál es alfabéticamente anterior.
2.  **Inversión y Normalización:** Solicite una cadena al usuario, e implemente un programa que: a) **Invierta el orden** de la cadena; b) Convierta la cadena resultante a **mayúsculas**.
3.  **Detección de Palíndromo:** Realice un programa que, dada una palabra, determine si es **palíndromo**.
4.  **Contador de Vocales:** Dada una cadena de texto, implemente una función que muestre por pantalla la **cantidad total de vocales** que contiene.
5.  **Frecuencia de Carácter Específico:** Solicite una cadena y un carácter. El programa debe verificar y mostrar **cuántas veces se repite el carácter** en la cadena.

6.  **Búsqueda y Conteo de Subcadenas:** Solicite al usuario una cadena en la que buscará (el texto) y otra que será la cadena buscada (el patrón). El programa debe indicar **cuántas veces aparece la segunda cadena en la primera**.
7.  **Palabra de Mayor Longitud (Uso de Split):** Implemente un programa que lea una frase y, **utilizando el método `Split`** para separar las palabras, encuentre la **palabra de mayor longitud**. El programa debe imprimir tanto la palabra como el número de caracteres de la misma.
8.  **Formato de Datos Estructurales:** Pida un número telefónico en formato de cadena (ej., `34555332211`) y conviértalo a un **formato estándar** de presentación más legible, por ejemplo, `(+34)-555-332211`.
9.  **Frecuencia de Vocales e Histograma:** Escriba un programa que calcule la **frecuencia de aparición de las vocales** de un texto proporcionado por el usuario y presente el resultado en forma de **histograma**.

### II. Algoritmos de Cifrado y Eficiencia

10. **Implementación de la Clave del César:** Implemente el algoritmo de cifrado "La clave del César", asegurando la conversión a **mayúsculas** y el reemplazo de letras y dígitos según las reglas.
11. **Conteo de Palabras (Uso de Split):** Escribir un programa que cuente el **número de palabras** en un texto. Este ejercicio debe resolverse mediante el **uso obligatorio del método `Split(delimitador)`** para separar la cadena de texto en un array de palabras.
12. **Comparación de Rendimiento (StringBuilder vs. +):** Cree un módulo que demuestre la **ineficiencia** de la **concatenación `+`** repetitiva ($O(n^2)$) frente al uso de la clase **`StringBuilder`** ($O(n)$).
13. **Normalización y Limpieza de Entrada:** Solicite una cadena de entrada al usuario y aplique **`.Trim()`** para eliminar espacios iniciales y finales y **`.ToLower()`**, crucial para la validación de entradas.

### III. Juegos Didácticos

14. **Juego del Ahorcado:** Realice el juego del ahorcado, pidiendo una palabra y dando al segundo usuario un máximo de **7 intentos** para adivinarla.
15. **Juego del Lingo (Retroalimentación):** Implemente el juego del Lingo, donde se adivinan palabras de 5 letras, indicando si una letra está en el sitio exacto (rosa) o solo en la palabra (amarillo).

### IV. Expresiones Regulares (Regex) y Validación

16. **Validación Numérica con Regex:** Utilice las **expresiones regulares** para comprobar que una cadena es un **número entero positivo correcto** (utilizando `\d` y `+`).
17. **Validación de Identificador (DNI):** Utilice **`Regex.IsMatch()`** para validar el formato básico de DNI (8 dígitos y 1 letra mayúscula), **anclando el patrón** con `^` y `$` para validar la cadena completa.
18. **Validación de Correo Electrónico:** Desarrolle un patrón de expresión regular que verifique si una cadena cumple con el formato básico de **correo electrónico**.
19. **Extracción de Números de Teléfono:** Dada una cadena de texto larga, use **`Regex.Matches()`** para encontrar y extraer todas las secuencias que coincidan con un patrón de **número telefónico**.
20. **Extracción de Fechas o URLs:** Implemente un módulo que, dado un texto, utilice la clase `Regex` para extraer todas las **fechas** en formato DD/MM/AAAA o todas las **URLs** que empiecen por `http://` o `https://`.