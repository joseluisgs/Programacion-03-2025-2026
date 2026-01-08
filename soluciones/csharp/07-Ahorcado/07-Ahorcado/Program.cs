using System.Text;
using System.Text.RegularExpressions;

// Main Program
Console.OutputEncoding = Encoding.UTF8;
Console.Clear();

// 🎯 Juego del Ahorcado
// Todo el código se ejecuta secuencialmente desde aquí.

Console.WriteLine("🎯 Juego del Ahorcado");

// --- 1. Inicialización ---
var palabra = PalabraAleatoriaDiccionario();

// Convertir la palabra a un array de strings (cada uno es una letra)
var arrayLetras = CrearArrayLetras(palabra);
// Array booleano para rastrear las letras adivinadas, inicializado a false por defecto
var arrayBooleanLetras = CrearArrayBoolean(palabra);

// Lógica de intentos: Longitud de la palabra + 3 vidas extra
var intentos = palabra.Length + 3;
var maxIntentos = intentos;
var adivinado = false;

// --- 2. Bucle Principal del Juego ---
do {
    Console.WriteLine($"\nIntentos restantes: {intentos}");
    Console.WriteLine("Palabra secreta:");
    ImprimirPalabraSecreta(arrayLetras, arrayBooleanLetras);

    var letra = PedirLetra(); // string de un único carácter en minúscula, p.ej. "a"
    Console.WriteLine($"Letra introducida: {letra}");

    // Comprobar la letra, actualizar el array de booleanos y verificar si la palabra se ha adivinado.
    // El pseudocódigo original resta un intento *incondicionalmente* por cada turno.
    adivinado = ComprobarLetra(letra, arrayLetras, arrayBooleanLetras);

    intentos = intentos - 1;
} while (intentos > 0 && !adivinado);

// --- 3. Resultado Final ---
Console.WriteLine("--- Fin del Juego ---");

if (adivinado) {
    Console.WriteLine("✅ ¡Has adivinado la palabra!");
    // Intentos restantes se restan al final del bucle, así que (maxIntentos - intentos) es el número de turnos jugados.
    Console.WriteLine($"Lo has conseguido en {maxIntentos - intentos} intentos.");
}
else {
    Console.WriteLine("❌ Has perdido.");
}

Console.WriteLine($"La palabra era: {palabra}");

Console.WriteLine("👋 Presiona una tecla para salir...");
Console.ReadKey();
return;
// End Main Program

// --- Funciones Auxiliares ---

// Imprime la palabra secreta mostrando letras adivinadas y guiones bajos para las no adivinadas
void ImprimirPalabraSecreta(char[] arrayLetras, bool[] arrayBooleanLetras) {
    for (var i = 0; i < arrayLetras.Length; i++)
        if (arrayBooleanLetras[i])
            Console.Write(arrayLetras[i] + " ");
        else
            Console.Write("_ ");

    Console.WriteLine();
}

// Comprueba si la letra está en la palabra, actualiza el array booleano y verifica si la palabra está adivinada
bool ComprobarLetra(char letra, char[] arrayLetras, bool[] arrayBooleanLetras) {
    // Recorremos en busca de la letra y marcamos las apariciones
    for (var i = 0; i < arrayLetras.Length; i++)
        if (arrayLetras[i] == letra)
            arrayBooleanLetras[i] = true;

    // Si todas las posiciones son true, la palabra está completa
    for (var i = 0; i < arrayBooleanLetras.Length; i++)
        if (!arrayBooleanLetras[i])
            return false;

    return true;
}

// Pide una letra al usuario con validación
static char PedirLetra() {
    var isValidLetter = false;
    // Patrón Regex para una única letra (a-z o A-Z)
    var patron = @"^[a-zA-Z]$";
    var regex = new Regex(patron);
    var letra = char.MinValue;

    do {
        Console.Write("Introduce una letra (a-z): ");
        // Console.ReadLine() devuelve un string o null.
        var entrada = (Console.ReadLine() ?? "").Trim().ToLower();

        // Validar: no nula/vacía y que coincida con el patrón de letra única.
        if (regex.IsMatch(entrada)) {
            letra = entrada[0];
            isValidLetter = true;
        }
        else {
            Console.WriteLine("⚠️ No has introducido una letra válida. Intenta de nuevo.");
        }
    } while (!isValidLetter);

    return letra;
}

// Crea un Array de Char del tamaño de la palabra
static char[] CrearArrayLetras(string palabra) {
    var arrayLetras = new char[palabra.Length];
    for (var i = 0; i < palabra.Length; i++)
        arrayLetras[i] = palabra[i];
    // return palabra.ToCharArray();
    return arrayLetras;
}

// Crea un array de booleanos del mismo tamaño que la palabra, inicializado a false
static bool[] CrearArrayBoolean(string palabra) {
    // La inicialización a false es automática en C# para arrays de tipo bool.
    var arrayBoolean = new bool[palabra.Length];
    return arrayBoolean;
}

// Devuelve una palabra aleatoria de un diccionario predefinido
string PalabraAleatoriaDiccionario() {
    string[] listaPalabras =
        { "portatil", "arbol", "hormiga", "regleta", "supercomplicado", "programa", "teclado", "computadora" };

    var random = new Random();
    // Next(min, max) donde max es exclusivo, coincidiendo con la longitud del array
    var indiceAleatorio = random.Next(0, listaPalabras.Length);

    return listaPalabras[indiceAleatorio];
}