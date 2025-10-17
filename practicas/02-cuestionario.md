## 15 Preguntas de Investigación y Desarrollo (I+D)

1.  **Análisis de la Indexación:** Justifique desde el punto de vista del cálculo de direcciones de memoria por qué la **Indexación Basada en Cero** es la convención más eficiente para los arrays en DAW y en lenguajes como C, en comparación con la Indexación Basada en Uno. ¿Qué representa el índice 0 en la fórmula matemática utilizada para calcular la dirección de un elemento $A[i]$?.

2.  **Eficiencia Algorítmica de Arrays:** Explique cómo la propiedad de **Contigüidad en Memoria** de los arrays garantiza que el acceso a cualquier elemento sea en **tiempo constante $O(1)$**. ¿Qué impacto tiene esta eficiencia en el rendimiento general de operaciones como la búsqueda lineal?.

3.  **Inmutabilidad y Diseño:** Dado que el tamaño de un array es **inmutable** en DAW, justifique por qué la solución para aumentar o reducir su tamaño es explícitamente **crear un array nuevo y copiar los datos**. Explique la justificación didáctica de esta mecánica en términos de la gestión de memoria contigua por parte del sistema operativo.

4.  **Gestión de Referencias:** Los arrays son **tipos de referencia** en DAW, lo que implica que pasar un array a una función crea una dependencia. Si un array contiene tipos primitivos (como `int`), ¿por qué es obligatoria la técnica de **Clonación Profunda Manual** para garantizar que la copia sea totalmente independiente del array original?.

5.  **Modelos de Matrices:** Compare el **Array Escalonado** (*Jagged Array*), utilizado por DAW, con el **Array Rectangular**. Justifique la elección del Array Escalonado por parte de DAW en términos de **flexibilidad** (respecto a la longitud de las filas) y **optimización de la memoria**.

6.  **Rendimiento en Matrices:** Las matrices en DAW se almacenan por **Filas** (*Row-Major Order*). Explique por qué esta organización hace que sea **más eficiente** iterar primero sobre el índice de la fila y luego sobre el de la columna (matriz\[i]\[j]), en relación con la memoria **caché del procesador**.

7.  **Doble Referencia y Clonación:** Las matrices son **doblemente tipos de referencia** (array de arrays). Diseñe un argumento para convencer a otro programador sobre el peligro de la **Copia Superficial Engañosa**. ¿Por qué modificar un valor en la matriz copiada sigue afectando al original si solo se clonó la dimensión exterior?.

8.  **Doble Búfer y Consistencia:** En simulaciones de propagación de estado (como el juego de la piedra), ¿por qué es esencial utilizar la técnica de **Doble Búfer** para la consistencia de los datos, en lugar de intentar leer y escribir sobre la misma matriz simultáneamente?.

9.  **Análisis del Rendimiento del Swap:** Justifique la extrema eficiencia del **Mecanismo de Intercambio (Swap)** en el Doble Búfer, indicando su complejidad algorítmica $O(1)$. Compare esto con la complejidad que implicaría **copiar el valor de cada celda** para actualizar el búfer ($O(n^2)$) y explique por qué la clonación repetida es insostenible en simulaciones grandes.

10. **Impacto de la Inmutabilidad en Strings:** Explique el concepto de **inmutabilidad** de las cadenas de texto en DAW. ¿Qué implicación de rendimiento tiene esta característica cuando se utiliza el operador de concatenación `+` repetidamente dentro de un bucle, resultando en una complejidad $O(n^2)$?.

11. **Diseño de Manipulación de Texto:** ¿En qué contexto de manipulación de cadenas la clase **StringBuilder** se convierte en una práctica obligatoria?. Explique conceptualmente por qué `.Append()` opera en tiempo lineal $O(n)$, a diferencia del operador `+`.

12. **Algoritmos de Ordenación $O(n^2)$:** Compare y contraste los algoritmos **Bubble Sort** y **Selection Sort**. Si el coste de realizar un **intercambio** (*swap*) de datos en memoria fuera excepcionalmente alto, ¿cuál de los dos algoritmos sería preferible y por qué, basándose en la métrica que cada uno optimiza?.

13. **Casos de Uso de la Inserción:** Aunque **Insertion Sort** tiene una complejidad promedio de $O(n^2)$, justifique por qué se recomienda su uso en el **mejor caso** (datos casi ordenados) y cuál es su complejidad algorítmica en ese escenario. ¿Por qué esta característica lo hace útil para la actualización incremental de listas?.

14. **Precondición de Búsqueda Binaria:** La **Búsqueda Binaria** ofrece una eficiencia superior de $O(\log n)$. Sin embargo, exige una **precondición** obligatoria. Si se debe buscar repetidamente en un array inicialmente desordenado, discuta la estrategia más eficiente: ¿aplicar Búsqueda Lineal siempre ($O(n)$) o pagar el costo inicial de ordenar ($O(n \log n)$ o $O(n^2)$) para luego aplicar Búsqueda Binaria?.

15. **Validación con Expresiones Regulares:** Al validar un formato de datos (como un DNI o un teléfono) utilizando el método `.IsMatch(cadena)` de la clase `Regex`, ¿por qué es fundamental **anclar** el patrón usando los metacaracteres `^` (inicio de cadena) y `$` (fin de cadena)?. ¿Qué riesgo existe si se omite el anclaje?.