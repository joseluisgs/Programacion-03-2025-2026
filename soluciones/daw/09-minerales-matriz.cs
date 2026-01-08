using Math;

// ----------------------------------------------------
// CONSTANTES GLOBALES
// ----------------------------------------------------

// [CONCEPTO CLAVE: CONSTANTES DE CONFIGURACIÓN]
// El tamaño (SIZE) ahora define una matriz cuadrada de SIZE x SIZE.
const int SIZE = 5; 
const int MAX_VALUE = 20; 
const int PROB_MINERAL = 50; 
const int MAX_TIME = 30; 
const int PROB_TAKE_MINERAL = 50; 
const long PAUSE_TIME = 1000; 
const int NUM_MINERALS_TAKEN = 2; 
const int PROB_DECISION = 30;


struct Posicion {
    int fila;
    int columna;
}

struct Direccion {
    int fila;
    int columna;
}

// ----------------------------------------------------
// BLOQUE PRINCIPAL (MAIN)
// ----------------------------------------------------
Main {
    writeLine("Detector de Minerales 2D");
    
    // La matriz de minerales es bidimensional: int[][]
    var mapMinerales = crearMapa(SIZE, MAX_VALUE, PROB_MINERAL);
    writeLine("--- Mapa Inicial de Minerales (Valores) ---");
    printMapMinerales(mapMinerales);

    var time = 1; 
    var cantidadMineral = 0; 
    
    // La dirección y posición son vectores (arrays) de 2 elementos: [fila, columna] o [dy, dx].
    Direccion direccionBusqueda = getRandomDirection(); 
    Posicion posicionActual = getInitialPosition(); 
    
    // Bucle principal de la simulación
    do {
        writeLine("");
        writeLine("--- Paso " + time + " / " + MAX_TIME + " ---");
        writeLine("Mineral Recolectado: " + cantidadMineral);
        writeLine(getPosicionActual(posicionActual));
        writeLine(getDireccionBusqueda(direccionBusqueda));
        
        // Imprime el mapa con la posición actual marcada con 'X'.
        printTablero(posicionActual);

        // ACCIÓN: El detector busca y toma mineral.
        cantidadMineral += buscarMineral(mapMinerales, posicionActual);

        // Lógica de cambio de dirección
        if (time % 2 == 0) {
            direccionBusqueda = getAndThinckNewDirection(direccionBusqueda);
        }

        // Mientras la nueva posición esté fuera de los límites, generamos una nueva dirección.
        while (isEndMap(mapMinerales, posicionActual, direccionBusqueda)) {
            writeLine("Limite alcanzado. Generando nueva dirección...");
            direccionBusqueda = getRandomDirection();
        }

        // Muevo la posición actual: se actualizan Fila y Columna.
        posicionActual = getNewPosicion(posicionActual, direccionBusqueda);

        Sleep(PAUSE_TIME); 
        time++;
    } while (hayMineral(mapMinerales) && time <= MAX_TIME);

    // ----------------------------------------------------
    // RESULTADO FINAL
    // ----------------------------------------------------
    writeLine("");
    writeLine("--------------------------------------");
    writeLine("FIN DE LA EXPLORACION");
    writeLine("--------------------------------------");
    writeLine("Tiempo Final: " + (time - 1));
    writeLine("Cantidad de Mineral Total: " + cantidadMineral);
    writeLine(getPosicionActual(posicionActual));
    writeLine("--- Mapa Final de Minerales (Valores) ---");
    printMapMinerales(mapMinerales);
}


// ----------------------------------------------------
// FUNCIONES DE UTILIDAD PARA POSICIÓN Y MOVIMIENTO
// ----------------------------------------------------

// Genera una posición inicial aleatoria en el mapa.
// Retorna un array de 2 enteros [fila, columna] (0-indexado).
function Posicion getInitialPosition() {
    Posicion posicion = Posicion {fila =  Math.Random(0, SIZE - 1), columna = Math.Random(0, SIZE - 1)};
    return posicion;
}

// Genera una dirección aleatoria (un vector de movimiento).
// La dirección debe ser distinta de [0, 0].
function Direccion getRandomDirection() {
    Direccion nuevaDireccion; // No la inicializamos, no la sabemos
    
    // Aseguramos que la dirección no sea estática (0, 0).
    do {
        // La dirección puede ser -1 (Norte/Oeste), 0 (Quieto), 1 (Sur/Este).
        nuevaDireccion.fila = Math.Random(-1, 1);
        nuevaDireccion.columna = Math.Random(-1, 1);
    } while (nuevaDireccion.fila == 0 && nuevaDireccion.columna == 0);
    
    return nuevaDireccion;
}

// Calcula la nueva posición sumando la posición actual con el vector de dirección.
function Posicion getNewPosicion(posicion posicionActual, Direccion direccionBusqueda) {
    Posicion nuevaPosicion;
    // Podría haberlo hecho en una línea, pero así se ve más claro
    
    // Fila + Movimiento en Fila
    nuevaPosicion.fila = posicionActual.fila + direccionBusqueda.fila; 
    // Columna + Movimiento en Columna
    nuevaPosicion.columna = posicionActual.columna + direccionBusqueda.columna; 
    
    return nuevaPosicion;
}

// Decide si se cambia de dirección basado en la probabilidad PROB_DECISION.
function Posicion getAndThinckNewDirection(Direccion direccionBusqueda) {
    if (Math.Random(0, 99) < PROB_DECISION) {
        writeLine("He decidido cambiar de Direccion, me lo pienso...");
        var newDirection = getRandomDirection();
        
        // Comprobamos si la nueva dirección es la misma que la actual.
        if (newDirection.fila == direccionBusqueda.fila && newDirection.columna == direccionBusqueda.columna) {
            writeLine("...No cambio de Direccion");
            return direccionBusqueda; // Devuelve la dirección original
        } else {
            writeLine("...Cambio de Direccion");
            return newDirection; // Devuelve la nueva dirección
        }
    }
    return direccionBusqueda; // No se cumple la probabilidad, se mantiene la dirección.
}

// Formatea la dirección de búsqueda en un string legible (ej: "NW", "E", "S").
function string getDireccionBusqueda(Direccion direccionBusqueda) {
    var direccion = "Direccion de Busqueda: ";
    
    // Analizamos el componente de Fila (Norte/Sur)
    if (direccionBusqueda.fila == -1) {
        direccion += "N"; // Norte (Fila - 1)
    } else if (direccionBusqueda.fila == 1) {
        direccion += "S"; // Sur (Fila + 1)
    }
    
    // Analizamos el componente de Columna (Oeste/Este)
    if (direccionBusqueda.columna == -1) {
        direccion += "W"; // Oeste (Columna - 1)
    } else if (direccionBusqueda.columna == 1) {
        direccion += "E"; // Este (Columna + 1)
    }
    
    // Si ambos son 0 (lo cual se evita en getRandomDirection), se mantendría "Direccion de Busqueda: ".
    return direccion;
}

// Formatea la posición actual para mostrarla al usuario (1-indexado).
function string getPosicionActual(Posicion posicionActual) {
    //Se muestra + 1 para que el usuario entienda la posición en base 1.
    return "Posicion Actual: f: " + (posicionActual.fila + 1) + ", c: " + (posicionActual.columna + 1);
}


// ----------------------------------------------------
// FUNCIONES DE MAPA Y JUEGO
// ----------------------------------------------------

// Imprime el tablero visualmente.
procedure printTablero(int[][] mapa, Posicion posicionActual) {
    writeLine("--- Tablero (" + SIZE + "x" + SIZE + ") ---");
    // Recorremos la matriz 2D.
    for (int i = 0; i < mapa.Length; i++) {
        for (int j = 0; j < mapa[i].Length; j++) {
            if (i == posicionActual.fila && j == posicionActual.columna) {
                write("[X]"); // Detector
            } else if (mapa[i][j] == MINERAL) {
                write("[M]"); // Mineral
            } else {
                write("[ ]"); // Espacio vacío
            }
        }
        writeLine(""); // Salto de línea al final de cada fila
    }
}

// Comprueba si el movimiento en la 'direccionBusqueda' sacaría al detector del mapa.
function boolean isEndMap(int[][] mapMinerales, Posicion posicionActual, Direccion direccionBusqueda) {
    // Calculamos la posible nueva posición
    // Ahora si lo hago en la misma asignación
    Posicion nuevaPosicion = Posicion {
        fila = posicionActual.fila + direccionBusqueda.fila,
        columna = posicionActual.columna + direccionBusqueda.columna
    }
    
    // Las filas deben estar en el rango [0, SIZE - 1]
    var filaFuera = nuevaPosicion.fila < 0 || nuevaPosicion.fila >= SIZE;
    // Las columnas deben estar en el rango [0, SIZE - 1]
    var columnaFuera = nuevaPosicion.columna < 0 || nuevaPosicion.columna >= SIZE;
    
    // Si la nueva posición está fuera de los límites en Fila O Columna, devuelve true.
    return filaFuera || columnaFuera;
}

// Lógica para buscar y tomar mineral en la posición actual.
function int buscarMineral(int[][] mapMinerales, Posicion posicion) {

    // Si la cantidad de mineral es positiva (hay algo)
    if (mapMinerales[posicion.fila][posicion.columna] > 0) {
        writeLine("Mineral encontrado en f:" + (posicion.fila + 1) + ", c:" + (posicion.columna + 1));
        
        if (Math.Random(0, 99) < PROB_TAKE_MINERAL) { 
            var cantidadATomar = NUM_MINERALS_TAKEN;
            // Si quedan menos minerales que el número a tomar, toma todos los minerales disponibles
            if (mapMinerales[posicion.fila][posicion.columna] < NUM_MINERALS_TAKEN) {
                cantidadATomar = mapMinerales[posicion.fila][posicion.columna];
            }
            
            writeLine("Mineral tomado (-" + cantidadATomar + ")");
            mapMinerales[posicion.fila][posicion.columna] -= cantidadATomar;
            return cantidadATomar; 
        } else {
            writeLine("Mineral no tomado (Probabilidad fallida)");
            return 0;
        }
    } else {
        writeLine("No hay mineral en f:" + (posicion.fila + 1) + ", c:" + (posicion.columna + 1));
        return 0;
    }
}

// Crea y rellena la matriz de minerales inicialmente.
function int[][] crearMapa(int size, int maxValue, int probMineral) {
    // Declaración de una matriz de enteros de size x size
    var map = int[size][size];
    
    for (int i = 0; i < map.Length; i++) { 
        for (int j = 0; j < map[i].Length; j++) {
            // Decisión probabilística de colocar mineral
            if (Math.Random(0, 99) < probMineral) {
                // Cantidad de mineral aleatoria entre 0 y maxValue-1
                map[i][j] = Math.Random(0, maxValue - 1); 
            } else {
                map[i][j] = 0;
            }
        }
    }
    return map;
}

// Imprime el contenido numérico del mapa de minerales (solo si el valor es > 0).
procedure printMapMinerales(int[][] map) {
    for (int i = 0; i < map.Length; i++) { // map.Length es el número de filas
        for (int j = 0; j < map[i].Length; j++) { // map[i].Length es el número de columnas
            if (map[i][j] > 0) {
                // Si hay mineral, mostramos la cantidad.
                write("[" + map[i][j] + "]");
            } else {
                // Si no hay mineral, mostramos un espacio vacío para la visualización.
                write("[ ]");
            }
        }
        writeLine(""); 
    }
    writeLine("");
}

// Comprueba si queda algún mineral en el mapa.
function boolean hayMineral(int[][] map) {
    // Recorremos toda la matriz.
    for (int i = 0; i < map.Length; i++) {
        for (int j = 0; j < map[i].Length; j++) {
            if (map[i][j] > 0) {
                return true;
            }
        }
    }
    return false;
}
