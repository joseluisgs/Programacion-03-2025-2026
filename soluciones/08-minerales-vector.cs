using Math;

// ----------------------------------------------------
// CONSTANTES GLOBALES
// ----------------------------------------------------

// Permiten modificar el comportamiento de la simulación fácilmente.
const int SIZE = 10; // Tamaño del mapa (array unidimensional)
const int MAX_VALUE = 20; // Máxima cantidad de mineral inicial
const int PROB_MINERAL = 50; // Probabilidad (%) de que una casilla tenga mineral inicialmente
const int MAX_TIME = 30; // Tiempo máximo de la simulación
const int PROB_TAKE_MINERAL = 50; // Probabilidad (%) de tomar el mineral al encontrarlo
const long PAUSE_TIME = 1000; // Tiempo de pausa entre pasos (1 segundo)
const int NUM_MINERALS_TAKEN = 2; // Cantidad de mineral que se extrae en cada intento
const int PROB_DECISION = 30; // Probabilidad (%) de que el robot intente cambiar de dirección

// ----------------------------------------------------
// BLOQUE PRINCIPAL (MAIN)
// ----------------------------------------------------
Main {
    writeLine("Detector de Minerales");
    
    // [CONCEPTO CLAVE: INICIALIZACIÓN DE ARRAYS]
    // Creamos el mapa de minerales como un array de enteros unidimensional.
    var mapMinerales = crearMapa(SIZE, MAX_VALUE, PROB_MINERAL);
    writeLine("--- Mapa Inicial de Minerales (Valores) ---");
    printMapMinerales(mapMinerales);

    var time = 1; // Contador de tiempo/pasos
    var cantidadMineral = 0; // Mineral recolectado
    var direccionBusqueda = 1; // Dirección: 1 (Derecha), -1 (Izquierda)
    var posicionActual = 0; // Posición inicial (0-indexada)
    
    // El bucle 'do-while' controla la simulación. Continúa mientras haya mineral Y no se exceda MAX_TIME.
    do {
        writeLine("");
        writeLine("--- Paso " + time + " / " + MAX_TIME + " ---");
        writeLine("Mineral Recolectado: " + cantidadMineral);
        writeLine("Posicion Actual: " + (posicionActual + 1));
        writeLine("Direccion de Busqueda: " + (direccionBusqueda == 1 ? "Derecha ➡️" : "Izquierda ⬅️"));
        
        // Muestra la posición del detector en el tablero
        printTablero(posicionActual);

        // ACCIÓN: El detector intenta buscar y tomar mineral en la posición actual.
        cantidadMineral += buscarMineral(mapMinerales, posicionActual);

        // Lógica de decisión de cambio de dirección (solo en pasos pares y con probabilidad)
        if (time % 2 == 0) {
            if (Math.Random(0, 99) < PROB_DECISION) { 
                writeLine("He decidido cambiar de Direccion, me lo pienso...");
                
                // Sortea una nueva dirección (0 para Izquierda (-1), 1 para Derecha (1))
                var nuevaDireccionRandom = Math.Random(0, 1); 
                var nuevaDireccionBusqueda = (nuevaDireccionRandom == 0) ? -1 : 1;
                
                if (nuevaDireccionBusqueda == direccionBusqueda) {
                    writeLine("...No cambio de Direccion");
                } else {
                    writeLine("...Cambio de Direccion");
                    direccionBusqueda = nuevaDireccionBusqueda;
                }
            }
        }
        // Si se llega al final del mapa, la dirección de búsqueda se invierte.
        if (isEndMap(mapMinerales, posicionActual, direccionBusqueda)) {
            writeLine("He llegado al extremo del mapa, cambio de Direccion obligatoriamente");
            direccionBusqueda *= -1; // Multiplicar por -1 invierte 1 a -1, o -1 a 1.
        }

        // Muevo la posición actual según la dirección
        posicionActual += direccionBusqueda;

        // Pausamos la simulación para visualizar el cambio
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
    writeLine("Posicion Final: " + (posicionActual + 1));
    writeLine("--- Mapa Final de Minerales (Valores) ---");
    printMapMinerales(mapMinerales);
}


// ----------------------------------------------------
// FUNCIONES AUXILIARES
// ----------------------------------------------------

// Imprime el tablero visualmente, mostrando dónde está el detector 'X'.
procedure printTablero(int[][] mapMinerales, int posicionActual) {
    // Recorremos el array desde el índice 0 hasta SIZE - 1.
    for (int i = 0; i < mapMinerales.Length; i++) {
        if (i == posicionActual) {
            write("[X]"); // Posición del detector
        } else {
            write("[ ]"); // Espacio vacío
        }
    }
    writeLine("");
}

// Comprueba si el detector ha llegado a un extremo y está intentando ir más allá.
// Si estamos en el índice 0 y la dirección es -1, o en el último índice (SIZE-1) y la dirección es 1.
function boolean isEndMap(int[] mapMinerales, int posicionActual, int direccionBusqueda) {
    return (posicionActual == 0 && direccionBusqueda == -1) || 
           (posicionActual == (mapMinerales.Length - 1) && direccionBusqueda == 1);
}

// Lógica para buscar y tomar mineral en la posición actual.
function int buscarMineral(int[] mapMinerales, int posicionActual) {
    // Si la cantidad de mineral es suficiente para tomar
    if (mapMinerales[posicionActual] >= NUM_MINERALS_TAKEN) {
        writeLine("Mineral encontrado en la posicion " + (posicionActual + 1));
        
        // Decisión probabilística de tomar el mineral
        if (Math.Random(0, 99) < PROB_TAKE_MINERAL) { 
            writeLine("Mineral tomado (-" + NUM_MINERALS_TAKEN + ")");
            // Actualizamos la cantidad de mineral en el mapa
            mapMinerales[posicionActual] -= NUM_MINERALS_TAKEN;
            return NUM_MINERALS_TAKEN; // Devolvemos la cantidad tomada
        } else {
            writeLine("Mineral no tomado (Probabilidad fallida)");
            return 0;
        }
    } else {
        // No hay mineral suficiente, aunque podría haber una pequeña cantidad (ej: 1).
        writeLine("No hay mineral suficiente para tomar en la posicion " + (posicionActual + 1));
        return 0;
    }
}

// Crea y rellena el mapa de minerales inicialmente.
function int[] crearMapa(int size, int maxValue, int probMineral) {
    int[] map = int[size];
    
    // map.Length es la forma correcta de obtener el tamaño del array.
    for (int i = 0; i < map.Length; i++) { 
        // Si el número aleatorio (0-99) es menor que la probabilidad, se coloca mineral.
        if (Math.Random(0, 99) < probMineral) {
            // genera un valor aleatorio entre 0 y maxValue (inclusive de 0).
            map[i] = Math.Random(0, maxValue - 1); 
        } else {
            map[i] = 0; // Casilla sin mineral
        }
    }
    return map;
}

// Imprime el contenido numérico del mapa de minerales.
procedure printMapMinerales(int[] map) {
    for (int i = 0; i < map.Length; i++) {
        // Formato para que los números se vean alineados, aunque sean de una sola cifra.
        write("[" + map[i] + "]");
    }
    writeLine("");
}

// Comprueba si queda algún mineral en el mapa para continuar la exploración.
function boolean hayMineral(int[] map) {
    // Recorremos el array; si encontramos UN solo valor mayor que 0, devolvemos 'true' inmediatamente.
    for (int i = 0; i < map.Length; i++) {
        if (map[i] > 0) {
            return true;
        }
    }
    // Si el bucle termina sin encontrar nada, devolvemos 'false'.
    return false;
}
