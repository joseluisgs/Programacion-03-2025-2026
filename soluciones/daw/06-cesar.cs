// ----------------------------------------------------
// CONSTANTES GLOBALES
// ----------------------------------------------------

// Alfabeto completo usado para el cifrado (incluye espacio, mayúsculas, minúsculas, números y símbolos)
const string ALFABETO_CESAR = " abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ1234567890.,;:?¡!()[]{}@#$%&/\\\"'çÇáéíóúÁÉÍÓÚàèìòùÀÈÌÒÙâêîôûÂÊÎÔÛäëïöüÄËÏÖÜãõÃÕ";


// ----------------------------------------------------
// BLOQUE PRINCIPAL (MAIN)
// ----------------------------------------------------
Main {
    writeLine("Cifrado Cesar");
    
    // Variables de entrada
    var mensaje = "Hola 1 DAW estamos en lase de Programación. Disfrutando de los algoritmos";
    var desplazamiento = 28;
    
    writeLine("Mensaje Original: " + mensaje);
    // Saldría: Hola 1 DAW estamos en clase de Programación. Disfrutando de los algoritmos

    // Cifrado
    var textoCifrado = cifrarCesar(mensaje, desplazamiento);
    writeLine("Mensaje Cifrado: " + textoCifrado);
    // Saldría: Xliy WAVTY xqslk xjse de xubweyf. Xbewu xjse xjse xubweyf xbewu xjse xjse xubweyf ( aSaber!!!)
    
    // Descifrado
    var textoDescifrado = cifrarCesar(textoCifrado, -desplazamiento);
    writeLine("Mensaje Descifrado: " + textoDescifrado);
    // Saldría: Hola 1 DAW estamos en clase de Programación. Disfrutando de los algoritmos
}


// ----------------------------------------------------
// FUNCIONES Y PROCEDIMIENTOS AUXILIARES
// ----------------------------------------------------

/**
 * Cifra un mensaje con el cifrado de Cesar
 * mensaje Mensaje a cifrar
 * desplazamiento Desplazamiento a aplicar (puede ser positivo o negativo)
 * Devuelve el mensaje cifrado
 */
function string cifrarCesar(string mensaje, int desplazamiento) {
    
    // Uso de StringBuilder para construcción eficiente de la cadena de salida
    var sb = StringBuilder();

    // Calcula el desplazamiento efectivo (módulo de la longitud del alfabeto)
    var desplazamientoEfectivo = desplazamiento %  ALFABETO_CESAR.Length;

    foreach (string caracter in mensaje) {
        var posicion = ALFABETO_CESAR.IndexOf(caracter); // Retorna -1 si no se encuentra
        
        if (posicion == -1) {
            // Si el carácter no está en el alfabeto, se añade directamente.
            sb.Append(caracter);
        } else {
            // Calcula la nueva posición
            var nuevaPosicion = posicion + desplazamientoEfectivo;
            
            if (nuevaPosicion < 0) {
                // Caso de desplazamiento negativo: Si la posición es negativa, 
                // se enrolla añadiendo la longitud del alfabeto.
                sb.Append(ALFABETO_CESAR[ALFABETO_CESAR.Length + nuevaPosicion]);
            } else {
                // Caso de desplazamiento positivo: Se aplica el módulo 
                // para volver al inicio si se pasa del final.
                sb.Append(ALFABETO_CESAR[nuevaPosicion % ALFABETO_CESAR.Length]);
            }
        }
    }
    return sb.ToString();
}