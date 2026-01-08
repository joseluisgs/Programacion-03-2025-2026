using Math;

// ----------------------------------------------------
// CONSTANTES GLOBALES
// ----------------------------------------------------

// Constantes para las condiciones de inicio del juego
const int TAM_DEFAULT = 8;
const int NUM_INTENTOS_DEFAULT = 5;

// Constantes de estado de la matriz
const int VACIO = 0;
const int MOSCA = 1;

enum TipoGolpeo {
    GOLPEO_ACERTADO,
    GOLPEO_FALLADO,
    GOLPEO_CASI
}

struct Posicion {
    int fila;
    int columna;
}


// Expresión regular para validar la posición
const string REGEX_POSICION = @"^[1-"+TAM_DEFAULT+"]:[1-"+TAM_DEFAULT+"]$"; // Formato fila:columna


// ----------------------------------------------------
// BLOQUE PRINCIPAL (MAIN)
// ----------------------------------------------------
Main {

    // Presentación del juego
    writeLine("Iniciando el juego de la mosca con los siguientes parámetros:");
    writeLine("Tamaño de la matriz: " + TAM_DEFAULT + "x" + TAM_DEFAULT);
    writeLine("Número de intentos: " + NUM_INTENTOS_DEFAULT);

    // Creamos la matriz de enteros bidimensional
    // Se asume la función de creación de array 2D.
    var matriz = int[TAM_DEFAULT, TAM_DEFAULT];
    
    // Se ejecuta el juego. La matriz se pasa por referencia (implícito en arrays).
    var result = jugarCazarMosca(matriz, NUM_INTENTOS_DEFAULT);
    
    if (result) {
        // Simulación de color verde
        writeLine("✅ Has ganado y has cazado la mosca en menos de " + NUM_INTENTOS_DEFAULT + " intentos");
    } else {
        // Simulación de color rojo
        writeLine("❌ Has perdido y no has podido cazar la mosca en " + NUM_INTENTOS_DEFAULT + " intentos");
    }
    
    // Imprimimos la matriz final
    imprimirMatriz(matriz);
}


// ----------------------------------------------------
// FUNCIONES Y PROCEDIMIENTOS AUXILIARES
// ----------------------------------------------------

// Juega a cazar la mosca en una matriz.
// matriz Matriz de enteros
// numIntentos Número de intentos para cazar la mosca, por defecto NUM_INTENTOS_DEFAULT
// devuelve true si se ha cazado la mosca, false si no se ha cazado
function boolean jugarCazarMosca(int[][] matriz, int numIntentos = NUM_INTENTOS_DEFAULT) {
    var intentos = 0;
    var moscaMuerta = false;
    
    // La primera vez sorteamos la posición de la mosca
    sortearPosicionMosca(matriz);
    // imprimirMatriz(matriz); // Quitar en producción, solo para depuración

    // Comenzamos el juego
    do {
        // Aumentamos el número de intentos
        intentos++;
        
        // Pedimos la posición válida. Usamos .Length para obtener el tamaño (número de filas).
        Posicion posicion = pedirPosicionValida(matriz.Length); 
        
        // Analizamos la posición
        var resultado = analizarGolpeo(matriz, posicion);
        
        // switch para manejar los resultados
        switch (resultado) {
            case TipoGolpeo.GOLPEO_ACERTADO:
                writeLine("✅ ¡TE LA HAS CARGADO! has acertado en el intento " + intentos);
                moscaMuerta = true;
                break;

            case TipoGolpeo.GOLPEO_CASI:
                // Simulación de color amarillo
                writeLine("🫤 ¡CASI! Has estado cerca en el intento " + intentos);
                writeLine("🪰 La mosca revoltea y cambia de posición");
                sortearPosicionMosca(matriz);
                // imprimirMatriz(matriz); // TODO Quitar en producción
                break;

            case TipoGolpeo.GOLPEO_FALLADO:
                // Simulación de color rojo
                writeLine("❌ Has fallado en el intento " + intentos);
                break;
        }

    } while (!moscaMuerta && intentos < numIntentos);
    
    return moscaMuerta;
}

// Analiza el golpeo de la mosca en la matriz.
// matriz Matriz de enteros
// posicion Posición del vector a analizar [fila, columna]
// Devuelve GOLPEO_ACERTADO, GOLPEO_FALLADO o GOLPEO_CASI
function TipoGolpeo analizarGolpeo(int[][] matriz, Posicion posicion) {


    // Si la posición es MOSCA, devolvemos GOLPEO_ACERTADO
    if (matriz[posicion.fila][posicion.columna] == MOSCA) {
        return TipoGolpeo.GOLPEO_ACERTADO;
    }

    // Miramos en las 8 posiciones adyacentes
    // ¿Por que esto funciona?
    // Si tenemos una posición, como (fila, columna), las posiciones adyacentes
    // son:
    // (fila-1, columna), (fila, columna-1), (fila, columna+1),
    // (fila+1, columna), (fila-1, columna-1), (fila-1, columna+1),
    // (fila+1, columna-1), (fila+1, columna+1)
    // Aquí se utiliza la técnica de la matriz adyacente para evitar tener que comprobar todas las posiciones.
    // Los valores negativos y superiores al tamaño del vector son considerados fuera de límites.
    for (int i = -1; i <= 1; i++) {
        for (int j = -1; j <= 1; j++) {
            // Obtenemos la nueva posición a analizar
            Posicion nuevaPosicion = Posicion { fila = posicion.fila + i, columna = posicion.columna + j };
             
            // Comprobamos que la nueva posición es válida dentro de los límites
            // Se asume que matriz[0].Length da el número de columnas
            // ¿Por qué esto funciona?
            // Si la nueva posición está dentro de los límites, comprobamos si es MOSCA
            // ¿Por qué esto funciona?
            // Las matrices son 0-indexadas, así que fila-1 y columna-1 son equivalentes a fila y columna respectivamente
            // En este caso, si la posición es fuera de límites, no se ejecuta el código dentro del if, y la posición no es considerada.
            // Se asume que matriz[0].Length da el número de columnas
            // Los valores negativos y superiores al tamaño del vector son considerados fuera de límites.
            // Los valores 0 son considerados dentro de límites.
            // El uso de la matriz adyacente asegura que el código es más eficiente y menos propenso a errores.
            if (nuevaPosicion.fila >= 0 && nuevaPosicion.fila < matriz.Length && 
                nuevaPosicion.columna >= 0 && nuevaPosicion.columna < matriz[0].Length) {
                
                // Analizamos si la nueva posición es MOSCA
                if (matriz[nuevaPosicion.fila][nuevaPosicion.columna] == MOSCA) {
                    return TipoGolpeo.GOLPEO_CASI;
                }
            }
        }
    }

    // Si no se encuentra, devolvemos GOLPEO_FALLADO
    return TipoGolpeo.GOLPEO_FALLADO;
}

// Pide una posición válida para la matriz y la devuelve en un array de 2 enteros [fila, columna] (0-indexado).
// size Tamaño del vector (número de filas/columnas)
// devuelve Posición válida del vector
function Posicion pedirPosicionValida(int size) {
    var inputIsOk = false;
    // Se usa la sintaxis de Regex con un string literal
    var inputRegex = Regex(REGEX_POSICION); 
    var input = "";
    Posicion posicion; // no asignamos valores, no los sabemos
    
    do {
        write("Introduce una posición válida como fila:columna -> ");
        input = readLine().Trim(); // Leemos el input y eliminamos espacios en blanco
        
        if (inputRegex.IsMatch(input)) {
            // Cogemos cada parte del input y la convertimos a entero
            var partes = input.Split(":");
            // Casting de string a int es obligatorio, es seguro porque la regex ya ha validado el formato
            var fila = (int)partes[0];
            var columna = (int)partes[1];

            // Comprobamos que la fila y la columna están dentro del rango del vector (1 a size, inclusivo)
            // No es necesario el if porque ya se filtra con la expresión regular, 
            // pero lo dejamos por seguridad y para que os déis cuenta de la doble validación
            //if (fila >= 1 && fila <= size && columna >= 1 && columna <= size) {
                // Guardamos en la posición (0-indexado), recuerdo que el usuario introduce 1-indexado
                posicion.fila = fila - 1;
                posicion.columna = columna - 1;
                inputIsOk = true;
            //}
        }
        
        if (!inputIsOk) {
            // Simulación de color rojo
            writeLine("❌ La posición no es válida. Inténtalo de nuevo con valores entre 1 y " + size);
        }
    } while (!inputIsOk);

    return posicion;

}

// Imprime una matriz de enteros.
// matriz Matriz de enteros
procedure imprimirMatriz(int[][] matriz) {
    for (int i = 0; i < matriz.Length; i++) {
        for (int j = 0; j < matriz[i].Length; j++) {
            if (matriz[i][j] == MOSCA) {
                write("[🪰]");
            } else {
                write("[  ]");
            }
        }
        writeLine(""); // Salto de línea después de cada fila
    }
    writeLine(""); // Salto de línea final
}

// Sortea la posición de la mosca en la matriz.
// matriz Matriz de enteros
procedure sortearPosicionMosca(int[][] matriz) {
    // Ponemos todas las posiciones a VACIO
    for (int i = 0; i < matriz.Length; i++) {
        for (int j = 0; j < matriz[i].Length; j++) {
            matriz[i][j] = VACIO;
        }
    }
    // Sorteamos la posición de la mosca. Se asume Math.Random(min, max)
    int posicionMoscaFila = Math.Random(0, matriz.Length - 1);
    int posicionMoscaColumna = Math.Random(0, matriz[0].Length - 1);
    matriz[posicionMoscaFila][posicionMoscaColumna] = MOSCA;

    // Si fuera Math.Random(), entre 0 y 1, se calcularía todo de la siguiente manera, el codigo equivalentes al anterior:
    // var posicionMoscaFila = (int)(Math.random() * matriz.Length);
    // var posicionMoscaColumna = (int)(Math.random() * matriz[0].Length);
    // matriz[posicionMoscaFila][posicionMoscaColumna] = MOSCA;

}