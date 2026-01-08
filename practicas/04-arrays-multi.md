## 20 Ejercicios de Aplicación con Arrays Multidimensionales (Matrices)

- [20 Ejercicios de Aplicación con Arrays Multidimensionales (Matrices)](#20-ejercicios-de-aplicación-con-arrays-multidimensionales-matrices)
  - [I. Operaciones Básicas y Análisis](#i-operaciones-básicas-y-análisis)
  - [II. Transformaciones y Lógica](#ii-transformaciones-y-lógica)
  - [III. Álgebra Lineal (Matrices Cuadradas)](#iii-álgebra-lineal-matrices-cuadradas)
  - [IV. Juegos de Simulación y Adyacencia](#iv-juegos-de-simulación-y-adyacencia)
  - [V. Ejercicios de Propagación de Estado (Doble Búfer Implícito)](#v-ejercicios-de-propagación-de-estado-doble-búfer-implícito)
  - [VI. Simulaciones](#vi-simulaciones)


### I. Operaciones Básicas y Análisis

1.  **Análisis Básico de Matriz:** Dada una matriz de números enteros, obtenga funciones que permitan: imprimir la matriz, calcular el **máximo**, el **mínimo** y la **media** de todos sus elementos, y buscar si un elemento existe en dicha matriz.
2.  **Análisis de Paridad (Números y Posiciones):** Dada una matriz de dimensión $N \times N$ de números enteros, escribir un programa que calcule la **suma y media de los números pares**, la suma y media de los números impares, la suma y media de los números en **posiciones pares**, y la suma y media de los números en **posiciones impares**.
3.  **Máximos por Fila:** Escribir un programa que lea una matriz de enteros de dimensión $N \times N$. Posteriormente, debe calcular el **valor máximo de cada fila** y, finalmente, obtener la **media de esos máximos**.
4.  **Suma de Diagonales:** Leer una matriz de $N \times N$ elementos enteros y calcular la **suma de los elementos de las dos diagonales** principales de la matriz.
5.  **Extracción de Sumas a Vectores:** Leer una matriz de $N \times N$ elementos enteros y calcular la **suma de cada una de sus filas y columnas**, dejando dichos resultados en dos vectores separados: uno para las filas y otro para las columnas.

### II. Transformaciones y Lógica

6.  **Transposición de Matriz (Matriz Auxiliar):** Implemente una función para **transponer la matriz $A$** (intercambiar filas por columnas, $A_{i,j} = B_{j,i}$) y guardar el resultado en una matriz auxiliar $B$.
7.  **Transposición In Situ:** Repita el ejercicio de transposición (Ejercicio 6), pero esta vez dejando el resultado en la **misma matriz $A$**, sin utilizar una matriz auxiliar $B$. Esto requiere un manejo cuidadoso de los índices.
8.  **Rotación Espacial:** Dada una matriz $A$ de orden $N \times N$, implemente una función para **girarla 90 grados en el sentido de las agujas del reloj** y guardar el resultado en la matriz $B$.
9.  **Comprobación de Simetría:** Escribir un programa que lea una matriz $A$ de dimensión $N \times N$ y compruebe si es o no **simétrica** ($A_{i,j} = A_{j,i}$).
10. **Permutación de Filas y Columnas:** Escribir un programa que lea una matriz $A$ de dimensión $N \times N$ y permita permutar dos filas que se piden al usuario. **Generalice el ejercicio para que también se puedan permutar dos columnas**.

### III. Álgebra Lineal (Matrices Cuadradas)

11. **Operaciones de Álgebra Lineal (Básicas):** Realizar un programa que, dadas dos matrices cuadradas de hasta $3 \times 3$, sea capaz de hallar la **suma** y la **resta** de ambas.
12. **Multiplicación de Matrices:** Extienda el ejercicio anterior para calcular la **multiplicación** de las dos matrices dadas.

### IV. Juegos de Simulación y Adyacencia

13. **Juego: ¿Dónde está la mosca? (Matriz $N \times M$):** Implemente la versión **generalizada del problema de la mosca para una matriz $N \times M$ con $K$ moscas**. La lógica es: si el jugador golpea una casilla adyacente a cualquier mosca, esta **revolotea y se sitúa en otra casilla**. Todos los parámetros ($N, M, K$) se deben pedir por teclado.
14. **Juego: Buscaminas (Matriz):** Realizar el juego del **Buscaminas** con una matriz $N \times M$. El ordenador debe colocar $K$ minas y generar las pistas correspondientes, donde cada casilla destapada sin mina indica **cuántas minas hay adyacentes a esa posición**.
15. **Juego: Barquitos Clásico (Matriz Bidimensional):** Implementar el juego de los barquitos para dos jugadores utilizando un tablero bidimensional (matriz). El programa debe gestionar **dos paneles por jugador** (uno para su flota y otro para sus tiradas). Debe contemplar que los barcos no pueden estar colocados de forma adyacente.
16. **Juego: Ajedrez (Movimientos):** Iniciar el tablero de ajedrez. Solicitar al usuario la posición en la que poner una pieza y qué pieza. Posteriormente, **mostrar en el tablero los movimientos que puede hacer esa pieza** (Torre, Alfil, Dama o Caballo) desde esa posición.
17. **Juego: Las Parejas (Matriz):** Generalice el juego de las parejas para una matriz de $N \times M$ (siendo el número total de casillas par). Se colocan al azar pares de números, y el jugador destapa de 2 en 2, buscando coincidencias.

### V. Ejercicios de Propagación de Estado (Doble Búfer Implícito)

18. **Simulación de Onda (Piedra en el Lago - Versión A):** Simular el lanzamiento de una piedra a un lago (matriz). Al lanzarse, la ola debe **expandirse en todas las direcciones** (horizontales, verticales y diagonales). La simulación debe detenerse cuando el lago vuelva a estar en calma (todo a cero).
19. **Simulación de Onda (Piedra en el Lago - Versión B):** Simular el lanzamiento de una piedra a un lago (matriz). En esta versión, la ola se debe generar a partir de la piedra **en circunvalaciones**.
20. **Simulación Avanzada de Crecimiento (I+D):** Diseñar un módulo que simule un proceso de crecimiento o propagación de estado en una matriz (ej., un incendio, o propagación de infección). El módulo debe requerir explícitamente el uso de **dos matrices idénticas (Doble Búfer)** para garantizar que la siguiente generación de estados se calcule sobre la base de la matriz actual consistente. El módulo debe implementar el **mecanismo de Intercambio (Swap)** de las referencias para asegurar que la actualización de estado sea $O(1)$.

### VI. Simulaciones
21. **Simulación de Exploración en Marte con la Sonda "Ares IX"**:
El equipo de exploración marciana de la Tierra ha desplegado la sonda **"Ares IX"** en la peligrosa **Meseta de Tharsis** de Marte para buscar depósitos de minerales raros antes de una gran tormenta de polvo.

**1. El Área de Búsqueda:**
El área de búsqueda se modela como una **matriz bidimensional (un "mapa")** donde:
* La dimensión del mapa será especificada por un parámetro de entrada **$N$** (número de filas) y **$M$** (número de columnas), donde **$N$** y **$M$** siempre estarán entre **$8$** y **$12$**.
* Cada celda (posición) del mapa puede contener o no un depósito mineral.
* Si contiene un depósito, este tendrá un **valor económico (peso)** seleccionado aleatoriamente entre **$50$** y **$150$** unidades (representando la riqueza del depósito).

**2. Los Depósitos Minerales:**
* El número total de depósitos minerales posibles en el mapa se especifica en otro parámetro de entrada, con un valor total entre **$10$** y **$20$** depósitos. (Se deben distribuir aleatoriamente en el mapa).

**3. Operación de la Sonda y Riesgos:**
* La sonda **"Ares IX"** comienza en la posición **(0, 0)** y debe moverse por las celdas del mapa buscando minerales.
* En cada celda, la sonda consume **$2$** unidades de **Energía** por movimiento.
* **Riesgo de Destrucción por Tormenta:** Antes de cada movimiento, hay una **probabilidad del $10\%$** de que una tormenta eléctrica golpee el área, **destruyendo la sonda** y poniendo fin a la misión.
* **Intentar Recolección:** Si la sonda llega a una celda con un depósito, tiene una **probabilidad del $60\%$** de poder recolectarlo exitosamente. Si lo logra, el depósito se añade a su inventario.
* **Límite de Tiempo:** La misión tiene un límite máximo de **$60$** unidades de **Energía** total para operar (el tiempo se agota al gastar la energía).

**4. Reglas de Movimiento:**
La sonda deberá moverse de forma **aleatoria** a una de sus **celdas adyacentes** (Norte, Sur, Este, Oeste), siempre y cuando no se salga de los límites de la matriz.

**5. Objetivo:**
La sonda deberá intentar **recolectar tantos depósitos como sea posible** hasta que agote su energía o sea destruida por la tormenta.

**6. Resultados y Salida:**
Al finalizar la misión, el programa debe mostrar:
* Por cada ciclo de movimiento:
  * La posición actual de la sonda.
  * La cantidad de energía restante.
  * El estado del mapa (con los depósitos recolectados marcados).
* El **número total de depósitos recolectados**.
* El **valor total acumulado** de los depósitos recolectados.
* El **número de movimientos realizados**.
* El **estado final de la sonda** (si fue destruida por la tormenta o si se quedó sin energía).
* El **mapa final** mostrando las posiciones de los depósitos recolectados y los que quedaron sin recolectar.

22.  **Brote Viral en una Ciudad por el Z-Virus**:
¿El terror se ha apoderado de la ciudad tras la aparición del nuevo Z-Virus!. Debemos simular la propagación de un virus en una población humana usando una cuadrícula y la técnica de **doble *buffer*** para manejar la actualización de estados a través del tiempo. El objetivo es determinar si la humanidad logra sobrevivir **10 segundos** al brote.


**1. Parámetros Iniciales del Escenario**

La simulación se llevará a cabo en una ciudad modelada como una matriz. Se deben utilizar los siguientes parámetros fijos:

1.  **Dimensión ($N$):** El mapa es de **$20 \times 20$** celdas ($400$ celdas totales).
2.  **Población Inicial:**
    * **$85\%$** de las celdas iniciales serán ocupadas por un **Humano ($\text{H}$)**.
    * **$5\%$** de las celdas iniciales serán ocupadas por un **Infectado ($\text{I}$)**.
    * El **$10\%$** restante se inicializará como **Vacío ($\text{V}$)**.



**2. Estructura de Datos y Codificación de Estados**

La ciudad se modela con dos matrices bidimensionales del mismo tamaño (Doble *Buffer*). Se deben usar los siguientes **códigos numéricos** en las celdas para representar el estado:

|        Estado         |        Símbolo        |    Código    |                                     Descripción                                     |
| :-------------------: | :-------------------: | :----------: | :---------------------------------------------------------------------------------: |
|       **Vacío**       |      $\text{V}$       | $\mathbf{0}$ |                                  Celda desocupada.                                  |
|      **Humano**       |      $\text{H}$       | $\mathbf{1}$ |                                    Persona sana.                                    |
| **Infectado (Nuevo)** | $\text{I}_{\text{0}}$ | $\mathbf{2}$ |      Infectado que acaba de ser contagiado o está en su primer ciclo de vida.       |
| **Infectado (Viejo)** | $\text{I}_{\text{1}}$ | $\mathbf{3}$ | Infectado que sobrevivió un ciclo y **morirá por inanición en el siguiente ciclo**. |

***

**Implementación del Doble *Buffer***

El proceso central debe utilizar **dos matrices (Buffer A y Buffer B)**. Para avanzar de un ciclo $t$ a $t+1$:

1.  El **Buffer A** contiene el estado en el tiempo $t$.
2.  El **Buffer B** se calcula examinando **solamente** el Buffer A.
3.  Al finalizar los cálculos, el Buffer B se convierte en la nueva Matriz A para el siguiente ciclo.

***

**4. Reglas de Transición y Propagación (Lógica de la Simulación)**

La simulación avanza en **ciclos de tiempo (segundos)**. Para determinar el nuevo estado en la Matriz B, se aplica la siguiente lógica a **cada celda**, mirando sus **cuatro vecinos adyacentes** (Norte, Sur, Este, Oeste) en la **Matriz A**:

* **A. Si la Celda Está Vacía ($\mathbf{0}$ o $\text{V}$)**
  * **Regla:** Permanece **Vacía ($\mathbf{0}$)**.

* **B. Si la Celda Es un Humano Sano ($\mathbf{1}$ o $\text{H}$)**
  * **Contagio:** Si el humano tiene al menos **un vecino** que sea un **Infectado** (código $\mathbf{2}$ o $\mathbf{3}$), se contagia inmediatamente.
    * **Nuevo Estado:** **Infectado (Nuevo)** ($\mathbf{2}$).
  * **Supervivencia:** Si **ninguno** de sus vecinos es un Infectado.
    * **Nuevo Estado:** Permanece **Humano Sano** ($\mathbf{1}$).

* **C. Si la Celda Es un Infectado (Nuevo) ($\mathbf{2}$ o $\text{I}_{\text{0}}$)**
  * **Envejecimiento:** El infectado usa su primer segundo de vida (un ciclo).
    * **Nuevo Estado:** Pasa a ser **Infectado (Viejo)** ($\mathbf{3}$).

* **D. Si la Celda Es un Infectado (Viejo) ($\mathbf{3}$ o $\text{I}_{\text{1}}$)**
  * **Muerte por Inanición:** Ha agotado sus dos segundos de vida (dos ciclos).
    * **Nuevo Estado:** El infectado muere y la celda pasa a estar **Vacía ($\mathbf{0}$)**.

***

**Requisitos de Implementación y Finalización**

1.  **Inicialización:** Calcular la cantidad exacta de $\text{H}$ e $\text{I}$ a partir de los porcentajes y distribuirlos **aleatoriamente** en la Matriz A.
2.  **Bucle de Simulación:** Ejecutar el bucle principal hasta que se cumpla la condición de fin.
3.  **Visualización:** En cada ciclo, mostrar claramente el estado actual del mapa y el conteo de $\mathbf{H}$, $\mathbf{I}_{\text{0}}$ e $\mathbf{I}_{\text{1}}$.
4.  **Condiciones de Fin:** La simulación debe terminar inmediatamente si se cumple alguna de estas condiciones:
    * **Victoria Humana:** El conteo de Infectados ($\mathbf{2}$ y $\mathbf{3}$) es cero.
    * **Victoria del Virus:** El conteo de Humanos ($\mathbf{1}$) es cero.
    * **Límite de Tiempo:** Se alcanza el **Ciclo 10**.
5.  **Resultado Final:** Imprimir el resultado final indicando la condición de fin y el número de ciclo en que ocurrió (o "10 segundos" si terminó por tiempo).
    * *Ejemplo:* **"EXTINCIÓN...** El virus consumió a la humanidad en $\mathbf{Y}$ segundos."
  

¡Excelente idea! Especificar los códigos numéricos exactos para los estados temporales simplifica la implementación para el alumnado.

Aquí tienes el enunciado completo y final del ejercicio, con todos los códigos de matriz bien definidos.

---

1.  **Pokemon: Expedición al Bosque de Viridian**:

Simular el viaje de un Entrenador Pokémon a través del Bosque Viridian. El objetivo es recolectar la mayor cantidad de Puntos de Batalla (PB) en un tiempo límite, implementando la técnica de **Doble *Buffer*** para la simulación del entorno.

**Parámetros Iniciales del Escenario**

1.  **Dimensión ($N$):** El mapa es de **$15 \times 15$** celdas.
2.  **Tiempo Límite:** La expedición tiene un límite de **20 Ciclos de Tiempo** (movimientos).
3.  **Puntuación:**
    * **Pokémon Raro ($\text{R}$):** Otorga un valor aleatorio de **150 a 250 PB**.
    * **Pokémon Común ($\text{C}$):** Otorga un valor aleatorio de **50 a 100 PB**.
4.  **Probabilidad de Batalla:** Si el Entrenador encuentra un Pokémon, tiene un **$70\%$ de probabilidad** de ganar la batalla y capturarlo.
5.  **Posición Inicial:** El Entrenador comienza en la celda **(0, 0)**.

***

**Estructura de Datos y Codificación de Estados**

La simulación usa dos matrices ($15 \times 15$). Los estados de las celdas se codifican con los siguientes **valores enteros**:

|          Estado          |        Símbolo        | Código Numérico |                           Descripción y Vida Útil                           |
| :----------------------: | :-------------------: | :-------------: | :-------------------------------------------------------------------------: |
|     **Pasto Vacío**      |      $\text{P}$       |  $\mathbf{0}$   |                          Zona segura, no hay nada.                          |
| **Pokémon Raro (Nuevo)** | $\text{R}_{\text{0}}$ |  $\mathbf{1}$   |  Acaba de aparecer. Tiene **dos ciclos de vida** restantes antes de huir.   |
| **Pokémon Raro (Viejo)** | $\text{R}_{\text{1}}$ |  $\mathbf{10}$  | Ya usó un ciclo de vida. **Huye en el siguiente ciclo** si no es capturado. |
|    **Pokémon Común**     |      $\text{C}$       |  $\mathbf{2}$   |      Ha aparecido. **Huye en el siguiente ciclo** si no es capturado.       |
|    **Agujero Trampa**    |      $\text{T}$       |  $\mathbf{-1}$  |                          Un obstáculo permanente.                           |

* **Inicialización:** El **$90\%$** del mapa será **Pasto Vacío ($\mathbf{0}$)**. El **$10\%$** restante se distribuirá aleatoriamente entre $\mathbf{1}$, $\mathbf{2}$ y $\mathbf{-1}$.

***

**3. Mecánicas del Juego y Reglas de Transición**

El bucle principal debe manejar el movimiento del Entrenador y la actualización del entorno (Doble *Buffer*).

* **Acciones del Entrenador (Al llegar a la celda)**

1.  **Pasto Vacío ($\mathbf{0}$):** No pasa nada. El ciclo termina.
2.  **Pokémon ($\mathbf{1}, \mathbf{10}, \mathbf{2}$):** Ocurre una batalla.
    * Con **$70\%$ de probabilidad**, el Entrenador gana y suma los PB.
    * **La celda donde ocurrió la batalla se convierte en Pasto Vacío ($\mathbf{0}$) en la Matriz B.**
3.  **Trampa ($\mathbf{-1}$):** El Entrenador queda atrapado. El contador de **tiempo** se decrementa en **3 ciclos**.
    * **La celda de la trampa se convierte en Pasto Vacío ($\mathbf{0}$) en la Matriz B** (la trampa se desactiva tras ser usada).

* **B. Reglas del Entorno (Doble *Buffer*)**

Al finalizar cada ciclo de tiempo, la **Matriz A** se utiliza para calcular la **Matriz B**, actualizando el movimiento y la huida de los Pokémon (excepto en la celda donde estuvo el Entrenador, que ya fue actualizada en el paso A).

|         Estado en $t$ (Matriz A)          |     Nuevo Estado en $t+1$ (Matriz B)      |                       Descripción                       |
| :---------------------------------------: | :---------------------------------------: | :-----------------------------------------------------: |
|       **$\mathbf{0}$ ($\text{P}$)**       |       **$\mathbf{0}$ ($\text{P}$)**       |                    Permanece vacío.                     |
| **$\mathbf{1}$ ($\text{R}_{\text{0}}$)**  | **$\mathbf{10}$ ($\text{R}_{\text{1}}$)** |        El Pokémon Raro envejece (primer ciclo).         |
| **$\mathbf{10}$ ($\text{R}_{\text{1}}$)** |       **$\mathbf{0}$ ($\text{P}$)**       | El Pokémon Raro huye (fin de su vida útil de 2 ciclos). |
|       **$\mathbf{2}$ ($\text{C}$)**       |       **$\mathbf{0}$ ($\text{P}$)**       | El Pokémon Común huye (fin de su vida útil de 1 ciclo). |
|      **$\mathbf{-1}$ ($\text{T}$)**       |      **$\mathbf{-1}$ ($\text{T}$)**       |        Si no fue activada, la trampa permanece.         |

***

**Requisitos de Implementación y Finalización**

1.  **Inicialización:** Crear las matrices iniciales, calcular las cantidades exactas de $\text{R}$, $\text{C}$ y $\text{T}$ y distribuirlas **aleatoriamente**.
2.  **Bucle Principal:** Implementar el bucle que maneja los **20 ciclos de tiempo**, permitiendo al alumno elegir la dirección de movimiento (N, S, E, O) en cada paso.
3.  **Estado:** En cada ciclo, mostrar la posición actual del Entrenador, el tiempo restante y el total de PB acumulados, y estado del mapa.
4.  **Finalización:** La simulación termina cuando el contador de tiempo llega a cero.
5.  **Resultado Final:** Imprimir un resumen de la expedición, incluyendo:
    * El **Total de Puntos de Batalla (PB)** recolectados.
    * El número de **Pokémon Comunes y Raros capturados**.
    * El estado final: "**¡Éxito!** El Entrenador regresó justo a tiempo." o "**¡Trampa!** El tiempo se agotó antes de regresar." (si el tiempo es 0 y el entrenador no está en (0,0)).