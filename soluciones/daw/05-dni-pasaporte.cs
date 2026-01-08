// ----------------------------------------------------
// CONSTANTES GLOBALES
// ----------------------------------------------------

// Constantes del Menú
const int OPCION_DNI = 1;
const int OPCION_PASAPORTE = 2;
const int OPCION_SALIR = 3;

// Constantes de Validación
const string TABLA_LETRAS = "TRWAGMYFPDXBNJZSQVHLCKE";
const string ALFABETO = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
const string REGEX_MENU = "^[1-3]$"; // Expresión regular para validar la entrada del menú
// Expresión regular para la sintaxis del DNI
const string REGEX_DNI_PATRON = "^[0-9]{8}[TRWAGMYFPDXBNJZSQVHLCKE]$";
// Expresión regular para la sintaxis del Pasaporte
const string REGEX_PASAPORTE_PATRON = "^[ABCDEFGHIJKLMNOPQRSTUVWXYZ]{3}[0-9]{6}[TRWAGMYFPDXBNJZSQVHLCKE]$";


// ----------------------------------------------------
// BLOQUE PRINCIPAL (MAIN)
// ----------------------------------------------------
Main {
    writeLine("Validador de DNI y Pasaporte"); 
    menuAplicacion();
}

// ----------------------------------------------------
// FUNCIONES Y PROCEDIMIENTOS AUXILIARES
// ----------------------------------------------------

/**
 * Muestra el menú principal de la aplicación.
 */
procedure menuAplicacion() {
    var opcion = 0;
    // Creamos el objeto Regex con el patrón
    var regexMenu = Regex(REGEX_MENU); 

    do {
        writeLine("1. Validar DNI");
        writeLine("2. Validar Pasaporte");
        writeLine("3. Salir");
        writeLine("Seleccione una opción (1-3):");

        // Entrada de datos
        var input = readLine();

        // Uso de Regex para validar la entrada (IsMatch)
        if (regexMenu.IsMatch(input)) { 
            // Casting obligatorio de string a int
            opcion = (int)input;
        } else {
            writeLine("Opción no válida. Inténtelo de nuevo.");
            opcion = 0; // Se fuerza a continuar el bucle
        }

        // switch para manejar las opciones del menú
        switch (opcion) {
            case OPCION_DNI:
                validarDNI();
                break;
            case OPCION_PASAPORTE:
                validarPasaporte();
                break;
            case OPCION_SALIR:
                salir();
                break;
            default:
                writeLine("Opción no válida. Inténtelo de nuevo.");
                break;
        }

    } while (opcion != OPCION_SALIR);
}

/**
 * Procedimiento que sale del programa.
 */
procedure salir() {
    writeLine("Hasta la próxima!");
}
// ====================================================
// VALIDACIÓN DE DNI
// ====================================================

/**
 * Valida un DNI, permitiendo elegir si usar Regex o la validación Manual.
 */
procedure validarDNI(boolean usarRegex = true) {
    writeLine("Introduce el DNI a validar:");
    var dniString = readLine().Trim().ToUpper(); 
    var valido = false;

    if (usarRegex) {
        valido = validarDniRegex(dniString);
    } else {
        valido = validarDniManual(dniString);
    }

    // Salida simplificada
    if (valido) {
        writeLine("✅ El DNI " + dniString + " es válido.");
    } else {
        writeLine("❌ El DNI " + dniString + " no es válido.");
    }
}

/**
 * Valida un DNI manualmente (longitud y tipo de carácter).
 */
function boolean validarDniManual(string dniString) {

    // 1. Longitud 9
    if (!(dniString.length == 9)) {
        return false;
    }
    // 2. Los 8 primeros son números
    var numerosParte = dniString.substring(0, 8);
    int numeros = 0;
    try {
        // Casting de string a int es obligatorio
        numeros = (int)numerosParte; 
    } catch (Exception e) {
        return false;
    }
    // 3. El último es una letra válida
    string letra = dniString[8];
    if (!TABLA_LETRAS.Contains(letra)) {
        return false;
    }

    // Cálculo de la letra
    int resto = numeros % 23;
    string letraCalculada = TABLA_LETRAS[resto];

    // Comparación final
    return letraCalculada == letra;


}

/**
 * Valida un DNI usando una expresión regular.
 */
function boolean validarDniRegex(string dniString) {

    var regex = Regex(REGEX_DNI_PATRON);

    // 1. Comprueba si el patrón es válido
    if (!regex.IsMatch(dniString)) {
        return false;
    }

    // 2. Extrae las partes del DNI
    var numerosParte = dniString.Substring(0, 8);
    int numeros = (int)numerosParte; // el Casting es seguro porque ha pasado el validador de Regex
    string letra = dniString[8];

    // Cálculo de la letra
    int resto = numeros % 23;
    string letraCalculada = TABLA_LETRAS[resto];

    // Comparación final
    return letraCalculada == letra;
}// ====================================================
// VALIDACIÓN DE PASAPORTE
// ====================================================

/**
 * Valida un Pasaporte, permitiendo elegir si usar Regex o la validación Manual.
 */
procedure validarPasaporte(boolean usarRegex = true) {
    writeLine("Introduce el Pasaporte a validar:");
    var pasaporteString = readLine().Trim().ToUpper();
    var valido = false;

    if (usarRegex) {
        valido = validarPasaporteRegex(pasaporteString);
    } else {
        valido = validarPasaporteManual(pasaporteString);
    }

    // Salida simplificada
    if (valido) {
        writeLine("✅ El Pasaporte " + pasaporteString + " es válido.");
    } else {
        writeLine("❌ El Pasaporte " + pasaporteString + " no es válido.");
    }
}

/**
 * Valida un Pasaporte manualmente (longitud y tipo de carácter).
 */
function boolean validarPasaporteManual(string pasaporteString) {

    // 1. El Pasaporte tiene longitud 10 (3L + 6N + 1L)
    if (!(pasaporteString.Length == 10)) {
        return false;
    }

    // 2. Los 6 números (del índice 3 al 8)
    var numerosParte = pasaporteString.Substring(3, 9);
    int numerosDePasaporte = 0; 

    try {
        // Casting de string a int es obligatorio
        numerosDePasaporte = (int)numerosParte; 
    } catch (Exception e) {
        return false;
    }

    var letrasParte = pasaporteString.Substring(0, 3);
    var letra = pasaporteString[9]; 

    // Comprobación de letras válidas
    foreach (var c in letrasParte) {
        if (!ALFABETO.Contains(c)) {
            return false;
        }
    }


    // USO DE STRINGBUILDER: Más eficiente para múltiples concatenaciones.
    var sb = StringBuilder();
    var numerosConcatenados = ""; // Variable que recogerá la concatenación del StringBuilder
    
    foreach (string item in letrasParte) {
        int indice = ALFABETO.IndexOf(item); 
        // Los índices deben ser tratados como cadenas y concatenados
        // numerosConcatenados = numerosConcatenados + indice;
        sb.Append(indice);
    }
    
    // Obtener la cadena del StringBuilder
    numerosConcatenados = sb.ToString();

    // Se concatenan las letras convertidas a números con los 6 dígitos del Pasaporte
    var numeroFinalString = numerosConcatenados + numerosParte;
    int numeroBase = (int)numeroFinalString; // El Casting es seguro, porque ha pasado el try catch

    // Cálculo final
    int resto = numeroBase % 23;
    string letraCalculada = TABLA_LETRAS[resto];

    // Comparación final
    return letraCalculada == letra;
}

/**
 * Valida un Pasaporte usando una expresión regular.
 */
function boolean validarPasaporteRegex(string pasaporteString) {

var regex = Regex(REGEX_PASAPORTE_PATRON);

  // 1. Comprueba si el patrón es válido
  if (!regex.IsMatch(pasaporteString)) {
    return false;
  }

  // 2. Extrae las partes
  var letrasParte = pasaporteString.substring(0, 3);
  var numerosParte = pasaporteString.substring(3, 9); 
  string letra = pasaporteString[9]; 

  // USO DE STRINGBUILDER: Más eficiente para múltiples concatenaciones.
    var sb = StringBuilder();
    var numerosConcatenados = "";
      
    foreach (var item in letrasParte) {
        int indice = ALFABETO.IndexOf(item);
        // numerosConcatenados = numerosConcatenados + (string)indice;
        sb.Append((string)indice);
    }

    // Obtener la cadena del StringBuilder
    numerosConcatenados = sb.ToString();
      
  // Se concatenan las letras convertidas a números con los 6 dígitos del Pasaporte
  var numeroFinalString = numerosConcatenados + numerosParte;
  int numeroBase = (int)numeroFinalString;

  // Cálculo final
  int resto = numeroBase % 23;
  string letraCalculada = TABLA_LETRAS[resto];

  // Comparación final
  return letraCalculada == letra;
}