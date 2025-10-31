// 🪰 Juego de la Mosca - Lenguaje DAW

using Math;

// --- Constantes del juego ---
const int TAM_DEFAULT = 8;
const int NUM_INTENTOS_DEFAULT = 5;
const int VACIO = 0;
const int MOSCA = 1;

enum TipoGolpeo {
    ACERTADO,
    FALLADO,
    CASI
}

// --- Programa principal ---
Main {
    int tamVector = TAM_DEFAULT;
    int numIntentos = NUM_INTENTOS_DEFAULT;

    writeLine("🪰 Iniciando el juego de la mosca...");
    writeLine("Tamaño del vector: " + tamVector);
    writeLine("Número de intentos: " + numIntentos);

    // Crear el vector
    int[] vector = int[tamVector]; // Inicializado con VACIO (0)
    sortearPosicionMosca(vector);

    // Jugar
    bool resultado = jugarCazarMosca(vector, numIntentos);

    if (resultado) {
        writeLine("✅ ¡Has ganado! Cazaste la mosca en menos de " + numIntentos + " intentos.");
    } else {
        writeLine("❌ Has perdido. No cazaste la mosca en " + numIntentos + " intentos.");
    }

    // Mostrar vector final
    imprimirVector(vector);
}

// --- Funciones y procedimientos auxiliares ---

// Juega al juego de la mosca
function bool jugarCazarMosca(int[] vector, int numIntentos) {
    int intentos = 0;
    bool moscaMuerta = false;

    do {
        intentos = intentos + 1;
        int posicion = pedirPosicionValida(vector.Length);
        TipoGolpeo resultado = analizarGolpeo(vector, posicion);

        switch (resultado) {
            case TipoGolpeo.ACERTADO:
                writeLine("☠️ ¡TE LA HAS CARGADO! Has acertado en el intento " + intentos);
                moscaMuerta = true;
                break;
            case TipoGolpeo.CASI:
                writeLine("🫤 ¡CASI! Has estado cerca en el intento " + intentos);
                writeLine("🪰 La mosca revolotea y cambia de posición...");
                sortearPosicionMosca(vector);
                break;
            case TipoGolpeo.FALLADO:
                writeLine("💨 Has fallado en el intento " + intentos);
                break;
            default:
                writeLine("Error en la función analizarGolpeo");
                break;
        }
    } while (!moscaMuerta && intentos < numIntentos);

    return moscaMuerta;
}

// Analiza el golpeo del jugador
function TipoGolpeo analizarGolpeo(int[] vector, int posicion) {
    if (vector[posicion] == MOSCA) {
        return TipoGolpeo.ACERTADO;
    }

    // Posiciones adyacentes
    if (posicion > 0 && vector[posicion - 1] == MOSCA) {
        return TipoGolpeo.CASI;
    }
    if (posicion < vector.Length - 1 && vector[posicion + 1] == MOSCA) {
        return TipoGolpeo.CASI;
    }

    return TipoGolpeo.FALLADO;
}

// Pide al usuario una posición válida
function int pedirPosicionValida(int size) {
    bool inputValido = false;
    int posicion = -1;
    var regex = Regex("^[1-" + size + "]$");

    do {
        writeLine("Introduce una posición válida (1.." + size + "):");
        string userInput = readLine();
        if (regex.isMatch(userInput)) {
            posicion = (int) userInput; // Ya es un numero valido por que ha pasado la expresión regular
            inputValido = true;
        } else {
            writeLine("❌ Entrada no válida. Debes introducir un número entre 1 y " + size + ".");
        }
    
    } while (!inputValido);

    return (posicion-1); // Convertir a índice 0-based
}

// Imprime el vector mostrando la mosca
procedure imprimirVector(int[] vector) {
    writeLine("--- Estado del vector ---");
    for (int i = 0; i < vector.Length; i++) {
        if (vector[i] == MOSCA) {
            write("[🪰]");// Es como writeLine pero imprime una linea sin Salto
        } else {
            write("[ ]");
        }
    }
    writeLine(""); // Salto de línea
}

// Sortea aleatoriamente la posición de la mosca
procedure sortearPosicionMosca(int[] vector) {
    // Inicializar con VACIO
    for (int i = 0; i < vector.Length; i++) {
        vector[i] = VACIO;
    }

    // Elegir posición aleatoria
    int posicionMosca = Math.random(0, vector.Length - 1);
    vector[posicionMosca] = MOSCA;
}
