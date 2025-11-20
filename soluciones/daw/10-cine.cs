using Math;
// ----------------------------------------------------
// ENUMERACIONES
// ----------------------------------------------------



// ----------------------------------------------------
// CONSTANTES GLOBALES
// ----------------------------------------------------

// Define el tamaño de la matriz cuadrada de la sala (TAM x TAM).
const int TAM_FILAS = 5;
const int TAM_COLUMNAS = 6;
// Número de butacas a establecer Fuera de Servicio (aprox. 10% de 25, redondeado a 3).
const int NUM_BUTACAS_FS = 3; 
// Precio de la entrada.
const double PRECIO_ENTRADA = 5.50; 

// Constantes para las opciones del menú.
const int OPCION_MOSTRAR = 1;
const int OPCION_COMPRAR = 2;
const int OPCION_DEVOLVER = 3;
// Opción 4 ahora es INFORME.
const int OPCION_INFORME = 4;
const int OPCION_SALIR = 5;

// Define los posibles estados de una butaca en la sala de cine.
enum Estado {
    LIBRE,         // Butaca disponible [🟢]
    OCUPADA,       // Butaca vendida/ocupada [🔴]
    FUERA_SERVICIO // Butaca no disponible para venta [🚫]
}

// Estructura para representar la posición de una butaca.
struct Posicion {
    int fila;
    int columna;
}

// Estructura para representar una butaca: posición, precio y estado.
struct Butaca {
    Posicion posicion;  // Posición de la butaca, no le vamos a dar mucho uso, pero lo dejamos
    decimal precio;      // Precio de la butaca
    Estado estado; // Estado de la butaca (LIBRE, OCUPADA, FUERA_SERVICIO)
}


// ----------------------------------------------------
// BLOQUE PRINCIPAL (MAIN)
// ----------------------------------------------------
Main {
    // Inicialización de la sala: matriz 5x6 de TipoButaca.
    Butaca[][] sala = Butaca[TAM_FILAS][TAM_COLUMNAS];
    
    // Inicialización de las butacas en la sala.
    initButacas(sala); 
    
    writeLine("Bienvenido al cine");
    writeLine("=====================");
    writeLine("");
    
    var opcion = 0;
    
    do {
        writeLine(OPCION_MOSTRAR + ". Mostrar sala");
        writeLine(OPCION_COMPRAR + ". Comprar entrada");
        writeLine(OPCION_DEVOLVER + ". Devolver entrada");
        writeLine(OPCION_INFORME + ". Informe final (Estadísticas)");
        writeLine(OPCION_SALIR + ". Salir");
        write("Ingrese una opción: ");
        
        // Lee la opción como cadena.
        var inputOpcion = readLine().Trim(); // Elimina espacios en blanco

        // Usa Regex para validar que la entrada es un dígito del 1 al 5.
        var patronOpcion = @"^[1-5]$";
        var regexOpcion = Regex(patronOpcion);
        
        opcion = 0; // Se inicializa a 0 (opción no válida)

        
        if (regexOpcion.IsMatch(inputOpcion)) {
            // Si coincide, obtenemos el primer (y único) dígito y lo convertimos a entero.
            opcion = (int)inputOpcion[0]; // el casting es seguro porque ha pasado el validador de Regex
        }

        // Estructura Switch para el menú
        switch (opcion) {
            case OPCION_MOSTRAR:
                mostrarSala(sala);
                break;
            case OPCION_COMPRAR:
                comprarEntrada(sala);
                break;
            case OPCION_DEVOLVER:
                devolverEntrada(sala);
                break;
            case OPCION_INFORME: // Llama a la nueva función de informe
                generarInforme(sala);
                break;
            case OPCION_SALIR:
                writeLine("¡Hasta luego!");
                break;
            default:
                writeLine("Opción no válida");
                break;
        }
        
        writeLine("");
    } while (opcion != OPCION_SALIR);
}

// ----------------------------------------------------
// FUNCIONES DE INICIALIZACIÓN
// ----------------------------------------------------

/**
 * Inicializa el estado de las butacas de la sala.
 * Establece un número fijo de butacas aleatorias como FUERA_SERVICIO (NUM_BUTACAS_FS)
 * y el resto como LIBRE.
 * Parámetros:
 * - sala: Matriz de TipoButaca que representa los estados de las butacas.
 */
procedure initButacas(Butaca[][] sala) {
    // 1. Inicializar todas a LIBRE
    // Podemos usar las constantes TAM_FILAS y TAM_COLUMNAS para el tamaño de la matriz.
    for (int i = 0; i < sala.Length; i++) {
        for (int j = 0; j < sala[i].Length; j++) {
            // Inicializamos la butaca
            Posicion posicion = Posicion { fila = i, columna = j};
            Butaca butaca = Butaca {
                posicion = posicion;
                precio = PRECIO_ENTRADA;
                estado = Estado.LIBRE
            }
            // Asignamos la butaca a la matriz
            sala[i][j] = butaca;
        }
    }
    
    writeLine("Inicializando sala. Estableciendo " + NUM_BUTACAS_FS + " butacas fuera de servicio aleatoriamente.");

    var countFS = 0;
    // Hacemos un while porque no sabemos cuántas iteraciones necesitaremos
    // hasta colocar todas las butacas F/S, porque puede que el random genera valores repetidos.
    while (countFS < NUM_BUTACAS_FS) {
        // Genera una fila y columna aleatoria entre 0 y TAM-1
        var randFila = Math.Random(0, TAM_FILAS - 1);
        var randColumna = Math.Random(0, TAM_COLUMNAS - 1);

        // Si la butaca no está ya FUERA_SERVICIO, la marcamos.
        if (sala[randFila][randColumna].estado != Estado.FUERA_SERVICIO) {
            sala[randFila][randColumna].estado = Estado.FUERA_SERVICIO;
            countFS = countFS + 1;
        }
    }
}


// ----------------------------------------------------
// FUNCIONES DE LAS OPCIONES DEL MENÚ
// ----------------------------------------------------

// ---------------------
// OPCIÓN 1: MOSTRAR SALA
// ---------------------

/**
 * Muestra el estado actual de la sala de cine por consola.
 * Muestra el emoji correspondiente a cada estado: [🟢](Libre), [🔴](Ocupada) o [🚫](Fuera Servicio).
 * Parámetros:
 * - sala: Matriz de TipoButaca que representa los estados de las butacas.

Un ejemplo de salida sería:
    Estado de la sala de cine
        |  1  |  2  |  3  |  4  |  5  |
     A  | 🟢 | 🔴 | 🟢 | 🚫 | 🟢 |
     B  | 🟢 | 🟢 | 🔴 | 🟢 | 🟢 |
     C  | 🚫 | 🟢 | 🟢 | 🟢 | 🔴 |
     D  | 🟢 | 🟢 | 🚫 | 🟢 | 🟢 |
     E  | 🔴 | 🟢 | 🟢 | 🟢 | 🟢 |

 */
procedure mostrarSala(Butaca[][] sala) {
    writeLine("Estado de la sala de cine");
    
    // Imprimir cabecera de columnas (1 2 3 4 5)
    write("    ");
    for (int i = 1; i <= sala.Length; i++) {
        // Añadimos más espacio para que los emojis quepan bien
        write(" | " + i + "  "); 
    }
    writeLine(" |");
    
    // Recorrer filas
    for (int fila = 0; fila < sala.Length; fila++) {
        // Imprimir letra de fila (A, B, C, D, E)
        write(" " + obtenerLetra(fila) + " "); 
        
        // Recorrer columnas
        for (int columna = 0; columna < sala[fila].Length; columna++) {
            if (sala[fila][columna].estado == Estado.OCUPADA) {
                write(" | 🔴 "); // Ocupado
            } else if (sala[fila][columna].estado == Estado.FUERA_SERVICIO) {
                write(" | 🚫 "); // Fuera de Servicio
            } else {
                write(" | 🟢 "); // Libre
            }
        }
        writeLine(" |"); 
    }
    writeLine("");
}

/**
 * Obtiene la letra correspondiente a una fila dada su índice.
 * Parámetros:
 * - fila: Índice de la fila (0 a TAM-1).
 * Devuelve: La letra correspondiente (A-E).
 */
function string obtenerLetra(int fila) {
    // Creamos el diccionario de mapeo con un string, suponemos que tenemos de la A a la Z
    // No sabemos cuantas filas habrá, pero en este caso solo 5 (A-E).
    const string filasLetras = "ABCDE";
    return filasLetras[fila];
}

/**
 * Obtiene el índice de fila correspondiente a una letra dada.
 * Parámetros:
 * - letra: Letra de la fila (A-E).
 * Devuelve: El índice correspondiente (0 a TAM-1).
 */
function int obtenerIndiceFila(string letra) {
    const string filasLetras = "ABCDE";
    return filasLetras.IndexOf(letra);
}

// ---------------------
// OPCIÓN 2: COMPRAR ENTRADA
// ---------------------

/**
 * Ocupa una butaca específica en la matriz (la pone en estado OCUPADA).
 * Parámetros:
 * - sala: Matriz de Estado que representa los estados de las butacas.
 * - fila: Índice de la fila.
 * - columna: Índice de la columna.
 */
procedure ocuparButaca(Butaca[][] sala, Posicion posicion) {
    sala[posicion.fila][posicion.columna] = Estado.OCUPADA;
    writeLine("Butaca ocupada correctamente. Coste: " + PRECIO_ENTRADA + " €");
}

/**
 * Comprueba si alguna butaca está libre en la sala (no fuera de servicio, no ocupada).
 * Parámetros:
 * - sala: Matriz de Estado que representa los estados de las butacas.
 * Devuelve: True si hay butacas libres, False si el resto está ocupado o fuera de servicio.
 */
function boolean hayButacaLibre(Butaca[][] sala) {
    for (int fila = 0; fila < TAM; fila++) {
        for (int columna = 0; columna < TAM; columna++) {
            if (sala[fila][columna].estado == Estado.LIBRE) {
                return true;
            }
        }
    }
    return false;
}

/**
 * Proceso para comprar una entrada (ocupar una butaca).
 * Incluye validación de formato, disponibilidad y estado "Fuera de Servicio".
 * Parámetros:
 * - sala: Matriz de TipoButaca que representa los estados de las butacas.
 */
procedure comprarEntrada(Butaca[][] sala) {
    writeLine("");
    if (hayButacaLibre(sala) == false) {
        writeLine("No hay butacas libres disponibles para la venta.");
        return; // Salimos del método para evitar continuar con la compra.
    }
    
    var isCorrecto = false;
    do {
        writeLine("Ingrese la fila y la columna a comprar (Fila:Columna, Ejemplo: A:2): ");
        
        // Expresión regular: Letra A-E, seguida de :, seguida de número 1-5.
        var patron = @"^[A-E]:[1-5]$";
        var regex = Regex(patron);
        var input = readLine().Trim().ToUpper();

        if (regex.IsMatch(input) == false) {
            writeLine("No has introducido una butaca válida (Ejemplo: A:2).");
            isCorrecto = false;
        } else {
            // Hacemos el Split para obtener la fila y la columna.
            var inputSplit = input.Split(':');
            Posicion posicion = Posicion {
                fila = obtenerIndiceFila(inputSplit[0]), 
                columna = (int)inputSplit[1][0] - 1 //  Conversión robusta de carácter '1'-'5' a índice 0-4.
            };
           
            // Se verifica que solo se puede comprar si está en estado LIBRE (0).
            if (sala[posicion.fila][posicion.columna].estado == TipoButaca.LIBRE) {
                ocuparButaca(sala, posicion);
                writeLine("✅ Compra realizada correctamente. Coste: " + PRECIO_ENTRADA + " €");
                writeLine("✅ Butaca " + input + (posicion.columna + 1) + " ocupada.");
                isCorrecto = true;
            } 
            // Si no es que está fuera de servicio o ocupada.
            // 1. Comprobar si está fuera de servicio.
            else if (sala[posicion.fila][posicion.columna].estado == TipoButaca.FUERA_SERVICIO) {
                writeLine("🔴 La butaca " + input + " está fuera de servicio.");
                isCorrecto = false;
            } 
            // 2. Comprobar si está ocupada.
            else if (isOcupada(sala, posicion)) { 
                writeLine("La butaca " + input + " ya está ocupada.");
                isCorrecto = false;
            } 
            // 3. Caso por si acaso (no debería ocurrir).
            else {
                 writeLine("🔴 Error desconocido al comprar la butaca " + input + ".");
                 isCorrecto = false;
            }
        }
        // Sólo se sigue comprando si la entrada es correcta.
    } while (isCorrecto == false);
}


// ---------------------
// OPCIÓN 3: DEVOLVER ENTRADA
// ---------------------

/**
 * Libera una butaca específica en la matriz (la pone en estado LIBRE).
 * Parámetros:
 * - sala: Matriz de Butaca que representa los estados de las butacas.
 * - fila: Índice de la fila.
 * - columna: Índice de la columna.
 */
procedure liberarButaca(Butaca[][] sala, Posicion posicion) {
    sala[posicion.fila][posicion.columna] = Butaca.LIBRE;
    writeLine("Butaca liberada correctamente");
}

/**
 * Proceso para devolver una entrada (liberar una butaca).
 * Incluye validación de formato y estado de ocupación (solo se puede devolver si está OCUPADA).
 * Parámetros:
 * - sala: Matriz de TipoButaca que representa los estados de las butacas.
 */
procedure devolverEntrada(TipoButaca[][] sala) {
    writeLine("");
    var isCorrecto = false;
    
    do {
        writeLine("Ingrese la fila y la columna a devolver (Fila:Columna, Ejemplo: A:2): ");
        
        // Expresión regular: Letra A-E, seguida de :, seguida de número 1-5.
        var patron = @"^[A-E]:[1-5]$";
        var regex = Regex(patron);
        var input = readLine().Trim().ToUpper();

        if (regex.IsMatch(input) == false) {
            writeLine("No has introducido una butaca válida.");
            isCorrecto = false;
        } else {
            // Hacemos el Split para obtener la fila y la columna.
            var inputSplit = input.Split(':');
            Posicion posicion = Posicion {
                fila = obtenerIndiceFila(inputSplit[0]),
                columna = (int)inputSplit[1][0] - 1
            }; 

            // Solo se puede devolver si la butaca estaba OCUPADA
            if (isOcupada(sala, posicion) == false) {
                writeLine("🔴 La butaca " + input + " no estaba ocupada y no puede ser devuelta.");
                isCorrecto = false;
            } else {
                liberarButaca(sala, posicion);
                writeLine("✅ Devolución realizada correctamente.");
                isCorrecto = true;
            }
        }
        // Sólo se sigue devolviendo si la entrada es correcta.
    } while (isCorrecto == false);
}


// ---------------------
// OPCIÓN 4: INFORME
// ---------------------

/**
 * Cuenta el número de butacas que se encuentran en un estado específico.
 * Parámetros:
 * - sala: Matriz de Butaca que representa los estados de las butacas.
 * - estado: Estado (LIBRE, OCUPADA, FUERA_SERVICIO) a contar.
 * Devuelve: El número total de butacas en ese estado.
 */
function int contarButacas(Butaca[][] sala, Estado estado) {
    var contador = 0;
    for (int fila = 0; fila < sala.Length; fila++) {
        for (int columna = 0; columna < sala[fila].Length; columna++) {
            if (sala[fila][columna].estado == estado) {
                contador = contador + 1;
            }
        }
    }
    return contador;
}

/**
 * Calcula la recaudación total en base a las entradas OCUPADAS.
 * Parámetros:
 * - sala: Matriz de Butaca que representa los estados de las butacas.
 * Devuelve: La recaudación total en formato double.
 */
function double obtenerRecaudacion(Butaca[][] sala) {
    // Casting de int a double es necesario para la multiplicación.
    var vendidas = contarButacas(sala, Estado.OCUPADA);
    return (double)vendidas * PRECIO_ENTRADA;
}

/**
 * Calcula el porcentaje de ocupación sobre las butacas disponibles (no F/S).
 * Parámetros:
 * - vendidas: Número de butacas ocupadas.
 * - disponibles: Número total de butacas que no están fuera de servicio.
 * Devuelve: El porcentaje de ocupación en formato double.
 */
function double obtenerPorcentajeOcupacion(int vendidas, int disponibles) {
    if (disponibles == 0) {
        return 0.0;
    }
    // Conversión a double para asegurar división flotante.
    var porcentaje = ((double)vendidas / (double)disponibles) * 100.0; 
    return porcentaje;
}


/**
 * Genera el informe estadístico final de la sala, incluyendo ventas, ocupación y recaudación.
 * Parámetros:
 * - sala: Matriz de Butaca que representa los estados de las butacas.
 */
procedure generarInforme(Butaca[][] sala) {
    writeLine("");
    var vendidas = contarButacas(sala, Estado.OCUPADA);
    var libres = contarButacas(sala, Estado.LIBRE);
    var fs = contarButacas(sala, Estado.FUERA_SERVICIO);
    
    var disponibles =  vendidas + libres; // Butacas que no están F/S
    
    var ocupacionPorcentaje = obtenerPorcentajeOcupacion(vendidas, disponibles);
    var recaudacionTotal = obtenerRecaudacion(sala);
    
    // Uso de StringBuilder para componer el informe final
    var informe = StringBuilder();
    // el \n es para salto de línea
    informe.Append("--- INFORME CINEDAW ---");
    informe.Append("\nEntradas Vendidas: " + vendidas);
    informe.Append("\nAsientos Libres: " + libres);
    informe.Append("\nAsientos No Disponibles (F/S): " + fs);
    // Asumimos que la función formatDouble(value, decimals) existe para un formato limpio (2 decimales).
    informe.Append("\nOcupación: " + formatDouble(ocupacionPorcentaje, 2) + "% (sobre " + disponibles + " asientos disponibles)");
    // Asumimos que la función formatDouble(value, decimals) existe para un formato limpio (2 decimales).
    informe.Append("\nRecaudación Total: " + formatDouble(recaudacionTotal, 2) + "€");

    writeLine(informe.ToString());
}


// ----------------------------------------------------
// FUNCIONES AUXILIARES GENERALES (No ligadas a una opción del menú)
// ----------------------------------------------------

/**
 * Comprueba si una butaca específica está ocupada.
 * Parámetros:
 * - sala: Matriz de Butaca que representa los estados de las butacas.
 * - fila: Índice de la fila (0 a TAM-1).
 * - columna: Índice de la columna (0 a TAM-1).
 * Devuelve: True si la butaca está ocupada, False si está libre o fuera de servicio.
 */
function boolean isOcupada(Butaca[][] sala, Posicion posicion) {
    return sala[posicion.fila][posicion.columna].estado == Estado.OCUPADA;
}

/**
 * Formatea un número double a string con un número específico de decimales.
 * Parámetros:
 * - value: Número double a formatear.
 * - decimals: Número de decimales deseados.
 * Devuelve: El número formateado como string.
 */
function string formatDouble(double value, int decimals) {
    // Convierte el número a string con el número especificado de decimales
    // multiplicación por 10^n para redondear a los decimales deseados
    var factor = Math.Pow(10, decimals); // si no lo puedes hacer con un for loop, pero que ya lo sabes esta en los apuntes
    /**
    for (int i = 0; i < decimals; i++) {
        factor = factor * 10;
    }
    */
    // obtenemos el número redondeado entero con el casting a int
    var roundedValue = (int)(value * factor);
    // devolvemos el número redondeado como decimal como 
    var finalValue = (double)roundedValue / factor;
    return "" + finalValue;
}
