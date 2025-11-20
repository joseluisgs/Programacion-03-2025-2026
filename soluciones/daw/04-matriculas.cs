// 🚗 Validador de Matrículas Españolas - Lenguaje DAW
using Math;

// --- Constantes del Menú ---
const int OPCION_REGEX = 1;
const int OPCION_MANUAL = 2;
const int OPCION_SALIR = 0;

Main {
    bool salir = false;

    do {
        writeLine("=== 🚗 MENÚ VALIDACIÓN DE MATRÍCULAS ===");
        writeLine("1. Validar matrícula con Regex");
        writeLine("2. Validar matrícula sin Regex");
        writeLine("0. Salir");

        int opcion = leerOpcion();
        bool resultado = false;

        switch (opcion) {
            case OPCION_REGEX:
                resultado= validarMatriculaConRegex();
                imprimirResultado(resultado);
                break;

            case OPCION_MANUAL:
                resultado= validarMatriculaSinRegex();
                imprimirResultado(resultado);
                break;

            case OPCION_SALIR:
                salir = true;
                break;

            default:
                writeLine("⚠️ Opción no válida. Intenta de nuevo.");
                break;
        }
    } while (!salir);
}

// ------------------------------------------------------------
// Lee la opción del usuario y valida que sea un número entero permitido
// ------------------------------------------------------------
function int leerOpcion() {
    var isValid = false;
    var opcion = -1;
    do {
        write("Selecciona una opción (0-2): ");
        
        string entrada = readLine();
        
        var patron = @"^[0-2]$"; // Solo acepta 0, 1 o 2
        var regex = Regex(patron);

        if (regex.IsMatch(entrada)) {
            opcion = (int)entrada; // Casting explícito a entero
            isValid = true;
        }
    
        writeLine("⚠️ Debes introducir un número válido (0, 1 o 2).");
    } while (!isValid);
}

// ------------------------------------------------------------
// Imprime el resultado de la validación
// ------------------------------------------------------------
function imprimirResultado(bool resultado) {
    if (resultado) {
        writeLine("✅ Matrícula válida.");
    } else {
        writeLine("❌ Matrícula no válida.");
    }
}

// ------------------------------------------------------------
// 1️⃣ Validar matrícula con Regex
// ------------------------------------------------------------
function bool validarMatriculaConRegex() {
    write("Introduce la matrícula (formato NNNNLLL): ");
    string matricula = readLine();

    // Patrón de matrícula española (4 números + 3 letras válidas)
    var patron = @"^\d{4}[B-DF-HJ-NP-TV-Z]{3}$";
    var regex = Regex(patron);

    // Convertimos a mayúsculas para validar letras pero antes quitamos espacios
    return regex.IsMatch(matricula.Trim().ToUpper()); 
}

// ------------------------------------------------------------
// 2️⃣ Validar matrícula sin Regex (por operaciones de cadena)
// ------------------------------------------------------------
function bool validarMatriculaSinRegex() {
    write("Introduce la matrícula (formato NNNNLLL): ");
    string matricula = readLine();
    
    //Quitando espacios al principio y al final, y comprobando longitud
    if (matricula.Trim()Length != 7) {
        // writeLine("⚠️ La matrícula debe tener exactamente 7 caracteres.");
        return false;
    }

    string numeros = matricula.Substring(0, 4); // Primeros 4 caracteres, numéricos
    string letras = matricula.Substring(4, 3); // Últimos 3 caracteres, letras

    bool numerosValidos = checkNumeros(numeros); // Comprobar números
    bool letrasValidas = checkLetras(letras); // Comprobar letras

    return numerosValidos && letrasValidas;
}

// ------------------------------------------------------------
// Comprueba que los primeros 4 caracteres sean numéricos válidos
// ------------------------------------------------------------
function bool checkNumeros(string numeros) {
    try {
        int valor = (int)numeros; // Casting explícito
        if (valor >= 0 && valor <= 9999) {
            return true; // Número válido
        }
    } catch (Exception e) {
        return false; // No se puede convertir a entero, no es numérico
    }
    return false; // No es numérico o está fuera del rango permitido
}

// ------------------------------------------------------------
// Comprueba que las 3 letras sean válidas (sin vocales ni Ñ)
// ------------------------------------------------------------
function bool checkLetras(string letras) {
    if (letras.Length != 3) {
        return false; // Longitud inválida
    }

    string letrasValidas = "BCDFGHJKLMNPRSTVWXYZ";

    for (int i = 0; i < letras.Length; i++) {
        string letra = letras[i].ToUpper();
        // Puedo usar Contains porque es una cadena corta o IndexOf
        // Si no está en las letras válidas, es inválida
        if (!letrasValidas.Contains(letra)) {
            return false; // No encontrada
        }
        // Con IndexOf sería:
        // if (letrasValidas.IndexOf(letra) == -1) {
        //     return false; // No encontrada
        // }

        // Tambien puedo hacer un foreach que que recorre letras y otro for que recorre letrasValidas, 
        // y un contador para que el total de coincidencias sea 3
        // pero es más eficiente usar Contains porque es más rápido o IndexOf
        // en este caso
        
        /*
        bool encontrada = false;
        int totalLetrasValidas = 0;
        foreach (string letra in letras) {
            for (int j = 0; j < letrasValidas.Length; j++) {
                if (letra == letrasValidas[j]) {
                    encontrada = true;
                    totalLetrasValidas = totalLetrasValidas + 1;
                    break; // o añadir un contador
                }
            }
            if (!encontrada) {
                return false; // No encontrada
            }
        }
        return totalLetrasValidas == 3;
        */
    }
    return true;
}
