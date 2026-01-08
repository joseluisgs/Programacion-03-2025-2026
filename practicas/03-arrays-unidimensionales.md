## 20 Ejercicios de Aplicación con Arrays Unidimensionales

- [20 Ejercicios de Aplicación con Arrays Unidimensionales](#20-ejercicios-de-aplicación-con-arrays-unidimensionales)
  - [I. Algoritmos Fundamentales y Análisis](#i-algoritmos-fundamentales-y-análisis)
  - [II. Manipulación y Lógica de Vectores](#ii-manipulación-y-lógica-de-vectores)
  - [III. Conceptos Avanzados y Juegos](#iii-conceptos-avanzados-y-juegos)
  - [IV. Ejercicios de Desarrollo y Clonación](#iv-ejercicios-de-desarrollo-y-clonación)
  - [V. Desarrollo Contextual y Gestión de Memoria Dinámica (Acordeón)](#v-desarrollo-contextual-y-gestión-de-memoria-dinámica-acordeón)


### I. Algoritmos Fundamentales y Análisis

1.  **Impresión y Análisis Básico:** Dado un vector de números enteros, obtenga funciones que permitan: a) **imprimir el vector**; b) calcular el **máximo** del vector; c) calcular el **mínimo** del vector; y d) calcular la **media** del vector.
2.  **Algoritmo de Ordenación por Burbuja (Bubble Sort):** Implemente el algoritmo de ordenación por burbuja (Bubble Sort) sobre un vector de números enteros.
3.  **Algoritmo de Ordenación por Selección (Selection Sort):** Implemente el algoritmo de ordenación por selección (Selection Sort) sobre un vector de números enteros.
4.  **Algoritmo de Ordenación por Inserción (Insertion Sort):** Implemente el algoritmo de ordenación por inserción (Insertion Sort) sobre un vector de números enteros.
5.  **Búsqueda Lineal:** Implemente una función para realizar la **búsqueda de un elemento de manera lineal** en un vector.
6.  **Búsqueda Binaria Recursiva:** Implemente una función que realice la **búsqueda de un elemento de manera binaria recursiva**, teniendo en cuenta la precondición de que el vector debe estar ordenado.
7.  **Operaciones de Vectores Físicos:** Realice un programa que dados dos vectores sea capaz de realizar las operaciones de vectores de física: **suma, resta y producto escalar**.

### II. Manipulación y Lógica de Vectores

8.  **Inversión del Orden:** Desarrolle un programa que **invierta el orden de un vector**.
9.  **Comprobación Capicúa:** Realice un programa que dado un vector de números, determine si es **capicúa**.
10. **Generación de Secuencia (Suma Simple):** Realice un programa que pida un valor entero, lo coloque en la primera posición de un vector e inicie el resto de elementos **sumando uno al anterior** (Ejemplo: si se introduce 9, la secuencia es 9, 10, 11, 12, 13...).
11. **Generación de Secuencia (Suma por Índice):** Repita el ejercicio anterior de forma que se inicie el primer elemento, y el resto de componentes del vector sean **el anterior más el índice actual** (Ejemplo: si se introduce 2, el resto es 2, 3, 5, 8, 12, 17...).
12. **Generación de la Primitiva:** Realice un programa que nos sirva para generar la **combinación de la primitiva, sin repetir un número**.

### III. Conceptos Avanzados y Juegos

13. **Juego: ¿Dónde está la mosca? (Vector):** Implemente la versión del juego de la mosca para un vector. La mosca es un valor oculto en una posición. Si el jugador golpea una casilla adyacente a la mosca, **la mosca revolotea y se sitúa en otra casilla**; si no es adyacente, permanece en su posición.
14. **Juego: Simulación de Onda (Piedra en el Río):** Simule el lanzamiento de una piedra a un río (vector). Pida posición e intensidad. La intensidad se almacena en esa casilla y las **adyacentes irán simulando las ondas con números que se van decrementando** hasta que el río vuelva a estar en calma (todo a cero).
15. **Juego: El Buscaminas (Vector):** Realice el juego del Buscaminas con un vector de 20 casillas. Coloque 6 minas y genere las pistas, donde cada casilla destapada (sin mina) indica **cuántas minas hay adyacentes a esa posición**.
16. **Juego: Barquitos Clásico (Vector):** Implemente el juego de los barquitos con un vector de 20 posiciones, utilizando solo submarinos (barcos de una casilla). El sistema debe llevar **dos paneles para cada jugador** (uno para su flota y otro para sus tiradas).
17. **Juego: El Número de Pivote:** Genere un vector de 20 números aleatorios. Pida al usuario una posición de pivote y realice los siguientes cálculos: la **suma de todos los elementos a la izquierda y a la derecha** del pivote; y cuente cuántos elementos a la izquierda/derecha son **mayores y menores** que el pivote.
18. **Juego: El Juego de las Parejas (Vector):** Inicie un vector (de dimensión par) y coloque al azar parejas de números. El panel se oculta y el jugador destapa de 2 en 2, buscando que los números coincidan.

### IV. Ejercicios de Desarrollo y Clonación

19. **Análisis de Posiciones Pares/Impares:** Dado un vector de números enteros, calcule la **suma y la media de los números ubicados en posiciones pares** (índice 0, 2, 4...) y la suma y media de los números ubicados en **posiciones impares** (índice 1, 3, 5...). (Inventado, basado en la necesidad de iterar con el índice y aplicar lógica de paridad, similar a las tareas de matriz).
20. **Simulación de Cambio de Tamaño (Clonación Profunda):** Escriba una función que simule el aumento de tamaño de un array unidimensional. La función debe crear un **nuevo array** con 5 posiciones adicionales y realizar la **clonación manual (copia profunda)** del contenido del array original al nuevo, demostrando así la inmutabilidad del tamaño en DAW.

### V. Desarrollo Contextual y Gestión de Memoria Dinámica (Acordeón)

21.  **Campeonato de Tiro al Blanco:**
    Simule un campeonato de tiros a una diana entre dos jugadores, Jugador A y Jugador B. Las puntuaciones de cada jugador se almacenan en dos vectores unidimensionales de la misma longitud.
    Implemente un programa que:
    a) Calcule la **puntuación total** de cada jugador (suma de todos los elementos del vector).
    b) Determine el **ganador** del campeonato.
    c) Encuentre la **ronda con mayor diferencia** de puntuación (a favor o en contra) y muestre la posición (índice) donde ocurrió.

22.  **Gestión de Resultados de Partidas:**
    Una liga de videojuegos registra las puntuaciones de un equipo en un vector de enteros anulables (`int?[]`). Los valores `null` representan partidas que fueron abandonadas o no jugadas (por lo tanto, no se cuentan para la media). El valor 0 es una partida jugada y perdida.
    Diseñe una función que:
    a) Calcule el **promedio de puntuación** solo de aquellas partidas que tienen un valor válido (es decir, **ignorando** los `null`).
    b) Devuelva un **nuevo vector compacto** que contenga solo las puntuaciones válidas, eliminando las entradas `null`.

23.  **El Almacén de Datos Elástico:**
    Implemente un programa que simule un sistema de almacenamiento de datos elástico utilizando un vector. Este vector debe dimensionarse automáticamente (simulando el efecto "acordeón") mediante la **creación y clonación** de un nuevo array.
    El programa debe tener un **menú interactivo** con opciones para:
    a) **Añadir** un nuevo número entero al final.
    b) **Borrar** un número entero por índice.
    c) **Mostrar** estado (capacidad total, elementos ocupados, porcentaje de ocupación).
    *   **Regla de Expansión (Añadir):** Si al añadir un elemento la ocupación del vector supera el **90%**, el sistema debe crear un **nuevo vector con un 50% de capacidad adicional** y copiar todos los datos.
    *   **Regla de Reducción (Borrar):** Si al borrar un elemento la ocupación del vector cae por debajo del **25%**, el sistema debe crear un **nuevo vector con el doble de capacidad del número de elementos actuales**, reduciendo así el desperdicio de memoria.


24.  **Historial de Errores con Nulos y Acordeón:**
    Una aplicación de servidor registra códigos de error en un vector de cadenas anulables (`string?[]`).
    a) Permita añadir un nuevo código de error. Si la capacidad está llena, expanda el vector en 5 posiciones (Acordeón).
    b) Permita **eliminar por contenido** (ej. eliminar "ERROR-404"). La posición liberada debe rellenarse con `null`.
    c) Implemente una función que recorra el vector para **"compactar"** la lista: mueva todos los valores válidos al principio, dejando los `null` al final.

25.  **Análisis de la Racha:**
    Dado un vector de números binarios (0 o 1), donde 1 representa un éxito y 0 un fallo, implemente un algoritmo que determine la **longitud de la racha máxima** de éxitos (secuencia contigua de 1s).
    *Ejemplo: En el vector {1, 0, 1, 1, 1, 0, 1, 1}, la racha máxima es 3.*

26.  **Control de Inventario Desorganizado:**
    En un almacén, el inventario se registra en un array de cadenas anulables (`string?[]`), donde `null` significa que el espacio está físicamente vacío, y `""` (cadena vacía) significa que el producto fue retirado pero la etiqueta sigue puesta.
    Implemente una función de **búsqueda lineal** que reciba un nombre de producto (cadena) y devuelva su índice, pero con las siguientes precondiciones:
    a) Si se busca la cadena `"ESPACIO VACÍO"`, la función debe encontrar solo las posiciones con valor **`null`**.
    b) Si se busca una cadena de producto, la función debe **ignorar** las posiciones que contienen `""` o `null`.
    c) Si el array contiene elementos `null`, la función debe usar el **operador de coalescencia de nulidad (`??`)** para garantizar que nunca se intenta llamar a un método (`.Equals()`) en un valor nulo, evitando así una excepción.

27.  **Presupuesto Histórico:**
    Un módulo de contabilidad almacena el presupuesto mensual en un array (`decimal[]`).
    Escriba un programa que demuestre los peligros del **Paso por Referencia**:
    a) Cree un `presupuestoActual`.
    b) Cree una función llamada `simularCambio(arrayPresupuesto)` que modifique el último elemento del array pasado como argumento.
    c) Invoque `simularCambio` pasando:
        1. Una **copia superficial** (`var historial = presupuestoActual;`) y muestre cómo se arruina el historial.
        2. Una **copia profunda/clonación manual** (creando un nuevo array y copiando valores) y muestre cómo el original permanece inalterado.

28.  **Intercalado de Turnos:**
    Dadas dos listas de tareas (`string[]`): una lista de Tareas Prioritarias (P) y una lista de Tareas Secundarias (S), cree un tercer vector $C$ que intercale las tareas, asegurando que por cada dos tareas prioritarias haya una secundaria.
    *Ejemplo: $P=\{P_1, P_2, P_3, P_4\}$ y $S=\{S_1, S_2\}$. El resultado es $C=\{P_1, P_2, S_1, P_3, P_4, S_2\}$.*

29.  **Distribución de Tropas:**
    Simule la distribución de tropas en un flanco utilizando un vector de enteros (`int[]`) de longitud 3: [Flanco Izquierdo, Centro, Flanco Derecho].
    Implemente una función que reciba el vector de tropas y un valor de refuerzo $R$, y realice una **rotación cíclica a la izquierda** de $R$ posiciones. Esto simula el movimiento de tropas del flanco izquierdo al derecho, afectando la disposición del centro.
    *Ejemplo: ` {1000, 500, 2000}` y $R=1$ resulta en ` {500, 2000, 1000}`.*

30. Control de Calidad de Inventario (Manejo de Nulos y Cadenas Vacías):

Una fábrica utiliza un **vector de cadenas anulables** (`string?[]`) para registrar el resultado de las inspecciones de calidad de sus productos.

**Definición de Estados:**

*   El valor **`null`** representa un producto que **no ha sido inspeccionado** (ausencia de registro).
*   La **cadena vacía (`""`)** representa un producto que fue inspeccionado y **explícitamente rechazado** (registro de rechazo).
*   Cualquier otra cadena ("OK", "Defecto-A", etc.) es un resultado válido de inspección.

**Vector de Datos de Ejemplo (Inicialización del `inventario`):**

Para la implementación, considere el siguiente vector de cadenas anulables, donde el valor por defecto de los tipos anulables es `null`:

```charp
var inventario = string?[] { 
    null, 
    "OK", 
    "", 
    "Defecto-A", 
    null, 
    "OK", 
    "", 
    "Defecto-B", 
    "OK", 
    null 
};
```

Implemente un programa que realice las siguientes tareas:

a) **Conteo de Estados:** Determine y muestre:
    *   El número total de productos **no inspeccionados** (`null`).
    *   El número total de productos **rechazados explícitamente** (`""`).

b) **Normalización y Filtrado:** Cree y devuelva un **nuevo vector de cadenas** que contenga **solo** los resultados de inspección válidos (es decir, excluyendo tanto los `null` como las cadenas vacías `""`). Recuerde que los *arrays* en DAW tienen un tamaño fijo, por lo que la simulación de filtrado requiere crear un nuevo *array*.

c) **Presentación de Informe:** Imprima el vector original utilizando el **operador de coalescencia de nulidad (`??`)** para que, en lugar de mostrar `null`, se muestre la etiqueta `"[PENDIENTE]"`.
**Ejemplo de Salida Esperada:**

```
Productos no inspeccionados: 3
Productos rechazados explícitamente: 2
Resultados de inspección válidos: [ "OK", "Defecto-A", "OK", "Defecto-B", "OK" ]
Informe de Inventario:
[0]: [PENDIENTE]
[1]: OK
[2]: [RECHAZADO]
[3]: Defecto-A
[4]: [PENDIENTE]
[5]: OK
[6]: [RECHAZADO]
[7]: Defecto-B
[8]: OK
[9]: [PENDIENTE]
```