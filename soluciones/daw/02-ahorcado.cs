// 🎯 Juego del Ahorcado - Lenguaje DAW
using Math;

Main {
    writeLine("🎯 Juego del Ahorcado");

    string palabra = palabraAleatoriaDiccionario();

    string[] arrayLetras = crearArrayLetras(palabra);
    bool[] arrayBooleanLetras = crearArrayBoolean(palabra);

    int intentos = palabra.Length + 3; // Tres vidas extra
    int maxIntentos = intentos;
    bool adivinado = false;

    do {
        writeLine("Intentos restantes: " + intentos);
        writeLine("Palabra secreta:");
        imprimirPalabraSecreta(arrayLetras, arrayBooleanLetras);

        string letra = pedirLetra(); // string de un único carácter, por ejemplo "a"
        writeLine("Letra introducida: " + letra);

        adivinado = comprobarLetra(letra, arrayLetras, arrayBooleanLetras);
        intentos = intentos - 1;
    } while (intentos > 0 && !adivinado);

    if (adivinado) {
        writeLine("✅ ¡Has adivinado la palabra!");
        writeLine("Lo has conseguido en " + (maxIntentos - intentos) + " intentos.");
    } else {
        writeLine("❌ Has perdido.");
    }

    writeLine("La palabra era: " + palabra);
}

// ------------------------------------------------------------
// Imprime la palabra mostrando las letras adivinadas o guiones bajos
// ------------------------------------------------------------
procedure imprimirPalabraSecreta(string[] arrayLetras, bool[] arrayBooleanLetras) {

    for (int i = 0; i < arrayLetras.Length; i++) {
        if (arrayBooleanLetras[i]) {
            write(arrayLetras[i] + " ");
        } else {
            write("_ ");
        }
    }
    writeLine("");
}

// ------------------------------------------------------------
// Comprueba si una letra (string de 1 char) está en la palabra y actualiza el estado
// ------------------------------------------------------------
function bool comprobarLetra(string letra, string[] arrayLetras, bool[] arrayBooleanLetras) {
    // Recorremos en busca de la letra y marcamos las apariciones
    for (int i = 0; i < arrayLetras.Length; i++) {
        if (arrayLetras[i] == letra) {
            arrayBooleanLetras[i] = true;
        }
    }

    // Si todas las posiciones son true, la palabra está completa
    for (int i = 0; i < arrayBooleanLetras.Length; i++) {
        if (!arrayBooleanLetras[i]) {
            return false;
        }
    }
    return true;
}

// ------------------------------------------------------------
// Pide una letra válida al usuario (devuelve string de longitud 1, p.e. "a")
// ------------------------------------------------------------
function string pedirLetra() {
    var isValidLetter = false;
    var patron = @"^[a-zA-Z]$";
    var regex = Regex(patron);
    var letra = "";
    
    do {
        writeLine("Introduce una letra (a-z):");
        string entrada = readLine();
        // Validar entrada: no nula, longitud 1 y carácter alfabético
        if (regex.IsMatch(entrada)) {
            letra = entrada.ToLower(); // devolvemos en minúscula, p.e. "a"
            isValidLetter = true;
        } else {
             writeLine("⚠️ No has introducido una letra válida. Intenta de nuevo.");
        }
    } while (!isValidLetter);
    return letra;
}

// ------------------------------------------------------------
// Crea un array de strings (cada string es un carácter) a partir de la palabra
// ------------------------------------------------------------
function string[] crearArrayLetras(string palabra) {
    string[] arrayLetras = string[palabra.Length];
    for (int i = 0; i < palabra.Length; i++) {
        // Cada posición es un string de longitud 1
        arrayLetras[i] = palabra[i];
    }
    return arrayLetras;
}

// ------------------------------------------------------------
// Crea un array de booleanos inicializado a false
// ------------------------------------------------------------
function bool[] crearArrayBoolean(string palabra) {
    bool[] arrayBoolean = bool[palabra.Length];
    // Esto no es necesario porque en DAW los booleanos 
    // se inicializan a false por defecto
    for (int i = 0; i < palabra.Length; i++) {
        arrayBoolean[i] = false;
    }
    return arrayBoolean;
}

// ------------------------------------------------------------
// Devuelve una palabra aleatoria de una lista
// ------------------------------------------------------------
function string palabraAleatoriaDiccionario() {
    string[] listaPalabras = { "portatil", "arbol", "hormiga", "regleta", "supercomplicado" };

    int indiceAleatorio = Math.Random(0, listaPalabras.Length - 1);
    return listaPalabras[indiceAleatorio];
}
