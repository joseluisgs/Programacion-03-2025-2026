using Math; // Requerido para usar Math.Random

// ====================================================================
// SIMULADOR DE INFECCIÓN - LENGUAJE DAW
// IMPLEMENTACIÓN CON DOBLE BÚFER Y SWAP DE PUNTEROS O(1)
// ====================================================================


/*
Tenemos una simulación de infección en una matriz 2D donde las células pueden estar en tres estados:
- LIBRE: No hay célula en esa posición.
- SANA: Célula sana que puede infectarse.
- INFECTADA: Célula infectada que no puede infectarse.

El programa simula la propagación de la infección en el tablero durante un tiempo máximo.
Un célula infectada puede infectar a otras células adyacentes (arriba, abajo, izquierda, derecha) que estén
sanas con una probabilidad del 20% incluídas las diagonales.

La simulación termina cuando se alcanza el tiempo máximo o no hay más células sanas en el tablero.
*/

// --------------------------------------------------------------------
// CONSTANTES Y TIPOS DE LA SIMULACIÓN
// --------------------------------------------------------------------
const int DIMENSION = 5;
const int NUM_SANOS_INICIAL = 8;
const int TIEMPO_MAXIMO = 10;

// Estados de la simulación usando ENUM para mejor legibilidad y tipado
enum TipoCelda {
    LIBRE,      // Posición sin célula
    SANA,       // Célula sana
    INFECTADA   // Célula infectada
}

// --------------------------------------------------------------------
// BLOQUE PRINCIPAL (Main)
// --------------------------------------------------------------------
Main {
    writeLine("Simulador de Infección con Doble Buffer (DAW)");
    writeLine("=============================================");

    // Inicialización del tablero principal
    var matrizInicial = crearTablero(DIMENSION, NUM_SANOS_INICIAL);
    writeLine("Tablero inicial:");
    mostrarTablero(matrizInicial); // Ya no requiere DIMENSION
    
    // NOTA: Para el análisis del alumno, se comenta la versión ineficiente:
    // sinDobleBuffer(matrizInicial);

    // Ejecución de la simulación con Doble Búfer (Versión Correcta y Coherente)
    ejecutarSimulacion(matrizInicial);

    writeLine("¡FIN DE LA SIMULACIÓN!");
}

// --------------------------------------------------------------------
// LÓGICA DE SIMULACIÓN - VERSIÓN DOBLE BÚFER (O(1) SWAP)
// --------------------------------------------------------------------

/**
 * Lanza la simulación usando la técnica de Doble Búfer.
 *tableroEstadoInicial El tablero inicial (se usa para crear los dos buffers).
 */
procedure ejecutarSimulacion(TipoCelda[][] tableroEstadoInicial) {
    writeLine("--- INICIANDO SIMULACIÓN CON DOBLE BÚFER ---");

    // 1. INICIALIZACIÓN DE BUFFERS
    // Tablero Front (Lectura): Copia de la matriz inicial.
    var tableroFront = crearTablero(DIMENSION, NUM_SANOS_INICIAL); 
    copiarMatriz(tableroEstadoInicial, tableroFront); // Ya no requiere DIMENSION

    // Tablero Back (Escritura): Requiere una matriz física distinta.
    var tableroBack = crearTablero(DIMENSION, NUM_SANOS_INICIAL); 
    copiarMatriz(tableroEstadoInicial, tableroBack); // Inicializado idéntico a Front

    var tiempo = 0;
    var numSanos = 0;
    
    do {
        writeLine("--- CICLO: " + tiempo + " segundos ---");
        
        // PASO 1: LECTURA/VISUALIZACIÓN (Muestra el estado visible)
        mostrarTablero(tableroFront); // Ya no requiere DIMENSION

        // PASO 2: CÁLCULO/ESCRITURA
        // Lee de tableroFront y escribe en tableroBack.
        // En esta función se realiza la copia de coherencia O(N^2).
        // ¿Que es una copia de coherencia? Ver explicación en el procedimiento.
        // Esto es así porque ahora el buffer de escritura (Back) parte del estado T,
        // y solo se modifican las células que cambian (infectadas y sus vecinos).
        // Garantizar que el estado T+1 herede el T completo.
        calcularSiguienteEstado(tableroFront, tableroBack); // Ya no requiere DIMENSION

        // PASO 3: SWAP (INTERCAMBIO ATÓMICO) - O(1)
        // Se intercambian las referencias (punteros). El nuevo estado (Back) pasa a ser visible (Front).
        // Esta es la operación de bajo coste que se repite en el bucle principal.
        // No se copia ningún dato, solo se intercambian las referencias.
        // ¿Por qué lo necesitamos? Porque el buffer de escritura (Back) ahora contiene el nuevo estado T+1.
        var temp = tableroFront;
        tableroFront = tableroBack; 
        tableroBack = temp;         
        
        Sleep(300); // Pausa para la visualización (300 ms)
        tiempo = tiempo + 1;
        
        numSanos = contarCelulas(tableroFront, TipoCelda.SANA); // Ya no requiere DIMENSION

    } while (tiempo < TIEMPO_MAXIMO and numSanos > 0);
    
    writeLine("==============================================");
    mostrarResultados(tableroFront, tiempo); // Ya no requiere DIMENSION
}

// --------------------------------------------------------------------
// LÓGICA DE SIMULACIÓN - VERSIÓN SIN DOBLE BÚFER (Comentada)
// --------------------------------------------------------------------

/**
 * Versión de simulación ineficiente o incorrecta por mutar la matriz mientras se itera sobre ella.
 * Esto es para que el alumno analice por qué falla.
 * matrix El tablero que se leerá y mutará simultáneamente.
 */
// procedure sinDobleBuffer(TipoCelda[][] matrix) {
//     writeLine("\n--- INICIANDO SIMULACIÓN SIN DOBLE BÚFER (NO COHERENTE) ---");
//     var dimension = matrix.Length;
//     var tiempoMax = 3;
//     var tiempo = 0;
//     do {
//         writeLine("\n--- CICLO FALLIDO: " + tiempo + " segundos ---");
//         mostrarTablero(matrix); // Refactorizado
        
//         // PROBLEMA: Este procedimiento muta `matrix` mientras itera sobre ella.
//         // Los cambios que ocurren al principio del bucle afectan las iteraciones posteriores del mismo ciclo.
//         moverInfectadosSinDobleBuffer(matrix, dimension);
        
//         Sleep(1000);
//         tiempo = tiempo + 1;
//     } while (tiempo < tiempoMax);
//     writeLine("\n--- FIN DEL EJEMPLO FALLIDO ---");
// }

// procedure moverInfectadosSinDobleBuffer(TipoCelda[][] matrix, int dimension) {
//     // El problema aquí es que si matrix[0][0] es un INFECTADO, se mueve a [3][3] y lo infecta.
//     // Si en la misma iteración del bucle se llega a [3][3], esta celda se detectará como INFECTADA
//     // y se procesará de nuevo, lo cual no es correcto para una simulación por pasos.
//     for (int fila = 0; fila < dimension; fila++) {
//         for (int columna = 0; columna < dimension; columna++) {
//             if (matrix[fila][columna] == TipoCelda.INFECTADA) {
//                 // 1. Se mueve el infectado, liberando la posición actual (fila, columna)
//                 matrix[fila][columna] = TipoCelda.LIBRE;
                
//                 // 2. Se calcula una nueva posición y se infecta (mutación del array)
//                 var nuevaFila = Math.Random(0, dimension - 1);
//                 var nuevaColumna = Math.Random(0, dimension - 1);
                
//                 if (matrix[nuevaFila][nuevaColumna] == TipoCelda.LIBRE or matrix[nuevaFila][nuevaColumna] == TipoCelda.SANA) {
//                     matrix[nuevaFila][nuevaColumna] = TipoCelda.INFECTADA;
//                 }
//             }
//         }
//     }
// }

// --------------------------------------------------------------------
// FUNCIONES AUXILIARES
// --------------------------------------------------------------------

/**
 * Crea e inicializa un nuevo tablero de simulación con estados LIBRE, SANA e INFECTADA.
 * Retorna una matriz 2D de TipoCelda (TipoCelda[][]).
 */
function TipoCelda[][] crearTablero(int dimension, int numSanos) {
    var tablero = TipoCelda[dimension][dimension];
    
    // 1. Inicializar filas y columnas a LIBRE
    for (int i = 0; i < dimension; i++) {
        tablero[i] = TipoCelda[dimension];
        for (int j = 0; j < dimension; j++) {
            tablero[i][j] = TipoCelda.LIBRE;
        }
    }

    // 2. Colocar células SANAS (TipoCelda.SANA) en posición aleatoria
    // Esto se hace hasta alcanzar el número deseado de células sanas
    // Random nos puede dar elementos repetidos, por lo que usamos un contador
    var contSanos = 0;
    while (contSanos < numSanos) {
        var fila = Math.Random(0, dimension - 1);
        var columna = Math.Random(0, dimension - 1);
        
        if (tablero[fila][columna] == TipoCelda.LIBRE) {
            tablero[fila][columna] = TipoCelda.SANA;
            contSanos = contSanos + 1;
        }
    }

    // 3. Colocar una célula INFECTADA (TipoCelda.INFECTADA) en posición aleatoria
    // El razonamiento es igual que el anterior, usamos un bucle hasta asignar
    var asignado = false;
    while (!asignado) {
        var fila = Math.Random(0, dimension - 1);
        var columna = Math.Random(0, dimension - 1);
        
        if (tablero[fila][columna] == TipoCelda.LIBRE) {
            tablero[fila][columna] = TipoCelda.INFECTADA;
            asignado = true;
        }
    }
    return tablero;
}

/**
 * Realiza una COPIA PROFUNDA (O(n^2)) de los VALORES de la matriz fuente a la destino.
 * bufferFuente Matriz de origen.
 * bufferDestino Matriz de destino.
 */
procedure copiarMatriz(TipoCelda[][] bufferFuente, TipoCelda[][] bufferDestino) {
    for (int i = 0; i < bufferFuente.Length; i++) {
        for (int j = 0; j < bufferFuente[i].Length; j++) {
            // Se copia el valor, NO la referencia.
            bufferDestino[i][j] = bufferFuente[i][j];
        }
    }
}

/**
 * Imprime el estado del tablero con emojis para una visualización más atractiva.
 * tablero La matriz a imprimir.
 */
procedure mostrarTablero(TipoCelda[][] tablero) {
    // Emojis utilizados: LIBRE: ◻️, SANA: 🟢, INFECTADA: 🔴
    for (int i = 0; i < tablero.Length; i++) {
        for (int j = 0; j < tablero[i].Length; j++) {
            var simbolo = "";

            switch (tablero[i][j]) {
                case TipoCelda.LIBRE:
                    simbolo = "◻️"; // Celda Libre (Cuadrado)
                    break;
                case TipoCelda.SANA:
                    simbolo = "🟢"; // Célula Sana (verde)
                    break;
                case TipoCelda.INFECTADA:
                    simbolo = "🔴"; // Célula Infectada (rojo)
                    break;
                default:
                    simbolo = "❓"; // Desconocido
                    break;
            }
            // Se añade un espacio para asegurar la separación visual entre emojis
            write(simbolo + " "); 
        }
        writeLine("");
    }
}

/**
 * Comprueba que una posición esté dentro de los límites de la matriz.
 * tablero La matriz para obtener la dimensión.
 */
function bool esPosicionValida(TipoCelda[][] tablero, int fila, int columna) {
    return (fila >= 0 and fila < tablero.Length) and (columna >= 0 and columna < tablero[fila].Length);
}

/**
 * Genera un número aleatorio para realizar un sorteo con un límite porcentual.
 * limite Límite superior para que el sorteo sea exitoso (ej: 20 para 20%).
 */
function bool realizarSorteo(int limite) {
    var numero = Math.Random(0, 99); // Número entre 0 y 99
    return numero < limite;
}

/**
 * Cuenta el número de células en un estado específico.
 * tablero La matriz donde se buscará.
 * estado El TipoCelda (SANA, INFECTADA, LIBRE) a contar.
 */
function int contarCelulas(TipoCelda[][] tablero, TipoCelda estado) {
    var contador = 0;
    for (int i = 0; i < tablero.Length; i++) {
        for (int j = 0; j < tablero[i].Length; j++) {
            if (tablero[i][j] == estado) {
                contador = contador + 1;
            }
        }
    }
    return contador;
}

// --------------------------------------------------------------------
// LÓGICA DE LA SIMULACIÓN CON DOBLE BÚFER (Implementación)
// --------------------------------------------------------------------

/**
 * Mueve un infectado y propaga la infección a los vecinos adyacentes.
 * - Lee del buffer de LECTURA (tableroLectura) para la lógica.
 * - Escribe en el buffer de ESCRITURA (tableroEscritura) para el nuevo estado.
 * tableroLectura Buffer de lectura (Estado T).
 * tableroEscritura Buffer de escritura (Estado T+1).
 * fila Fila de la célula infectada actual.
 * columna Columna de la célula infectada actual.
 */
procedure moverEInfectar(TipoCelda[][] tableroLectura, TipoCelda[][] tableroEscritura, int fila, int columna) {
    var dimension = tableroLectura.Length;

    // 1. La posición original del infectado en el buffer de ESCRITURA debe quedar LIBRE.
    tableroEscritura[fila][columna] = TipoCelda.LIBRE;

    // 2. Buscamos una nueva posición LIBRE aleatoria para el infectado en el buffer de ESCRITURA.
    var posFila = -1;
    var posColumna = -1;
    var asignado = false;

    // Buscamos una posición LIBRE en un radio de 1 celda (vecinos).
    // Si no lo encuentra, se repite el proceso hasta encontrar una posición LIBRE.
    while (!asignado) {
        posFila = Math.Random(0, dimension - 1);
        posColumna = Math.Random(0, dimension - 1);
        
        // Verificamos el estado en el buffer de ESCRITURA.
        if (tableroEscritura[posFila][posColumna] == TipoCelda.LIBRE) { 
            tableroEscritura[posFila][posColumna] = TipoCelda.INFECTADA; // Nuevo infectado en ESCRITURA
            asignado = true;
        }
    }
    
    // 3. Propagamos la infección a los vecinos.
    propagarInfeccion(tableroLectura, tableroEscritura, posFila, posColumna);
}

/**
 * Propaga la infección a los vecinos de la posición (filaActual, columnaActual).
 * tableroLectura Buffer de lectura (Estado T).
 * tableroEscritura Buffer de escritura (Estado T+1).
 * filaActual Fila del punto desde donde se propaga la infección.
 * columnaActual Columna del punto desde donde se propaga la infección.
 */
procedure propagarInfeccion(TipoCelda[][] tableroLectura, TipoCelda[][] tableroEscritura, int filaActual, int columnaActual) {
    
    // Recorremos las 8 posiciones adyacentes, incluyendo las diagonales.
    // El bucle va de -1 a +1 en filas y columnas.
    for (int df = filaActual - 1; df <= filaActual + 1; df++) {
        for (int dc = columnaActual - 1; dc <= columnaActual + 1; dc++) {
            
            // Verificamos que la posición sea válida y no sea la celda central
            if (esPosicionValida(tableroLectura, df, dc)) {
                if (!(df == filaActual && dc == columnaActual)) {
                    
                    // Leemos el estado del vecino del buffer de LECTURA (T).
                    if (tableroLectura[df][dc] == TipoCelda.SANA) {
                        
                        // Sorteamos la probabilidad de contagio (20%)
                        if (realizarSorteo(20)) {
                            // ESCRITURA: Aplicamos el cambio al buffer de ESCRITURA (T+1).
                            writeLine("  > Propaga de (" + filaActual + ", " + columnaActual + ") a (" + df + ", " + dc + ")");
                            tableroEscritura[df][dc] = TipoCelda.INFECTADA;
                        }
                    }
                }
            }
        }
    }
}

/**
 * Recorre el tablero de lectura (Estado T) y aplica las modificaciones al tablero de escritura (Estado T+1).
 * Esta función incluye la copia de coherencia O(N^2) para simplificar el bucle principal.
 * @param tableroLectura El buffer visible (Front Buffer)
 * @param tableroEscritura El buffer de trabajo (Back Buffer)
 */
procedure calcularSiguienteEstado(TipoCelda[][] tableroLectura, TipoCelda[][] tableroEscritura) {
    var dimension = tableroLectura.Length;

    // PASO 1. ESTA COPIA ES NECESARIA: El SWAP solo intercambia referencias. 
    // Necesitamos esta copia profunda para que el 'tableroEscritura' (Back Buffer) 
    // contenga inicialmente TODAS las células 'SANA' y 'LIBRE' que NO van a ser modificadas 
    // por la lógica de infección en este ciclo, asegurando la coherencia del estado T+1.
    copiarMatriz(tableroLectura, tableroEscritura);

    // PASO 2. CÁLCULO DE MOVIMIENTO/INFECCIÓN (O(N^2))
    // La lógica lee el estado T (tableroLectura) y lo modifica sobre el estado T+1 (tableroEscritura)
    for (int i = 0; i < dimension; i++) {
        for (int j = 0; j < dimension; j++) {
            // Usamos el buffer de LECTURA para determinar qué celdas infectan.
            if (tableroLectura[i][j] == TipoCelda.INFECTADA) {
                moverEInfectar(tableroLectura, tableroEscritura, i, j);
            }
        }
    }
}

/**
 * Imprime el informe final de resultados.
 * @param tablero El tablero final.
 * @param tiempo El tiempo total transcurrido en la simulación.
 */
procedure mostrarResultados(TipoCelda[][] tablero, int tiempo) {
    mostrarTablero(tablero); // Imprime la matriz final
    writeLine("\RESULTADOS FINALES:");
    writeLine("Tiempo total transcurrido: " + tiempo + " segundos");
    
    var numInfectados = contarCelulas(tablero, TipoCelda.INFECTADA);
    var numSanos = contarCelulas(tablero, TipoCelda.SANA);
    var numLibres = contarCelulas(tablero, TipoCelda.LIBRE);
    
    writeLine("Células Infectadas (🔴): " + numInfectados);
    writeLine("Células Sanas (🟢): " + numSanos);
    writeLine("Celdas Libres (◻️): " + numLibres);

    if (numSanos == 0) {
        writeLine("¡La infección se ha propagado por completo!");
    } else {
        writeLine("La simulación finalizó con células sanas restantes.");
    }
}
