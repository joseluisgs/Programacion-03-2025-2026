using System.Text;
using System.Text.RegularExpressions;
using _08_MoscaVector.Enums;

// Constantes
const int TamDefault = 8;
const int NumIntentosDefault = 5;
const int Vacio = 0;
const int Mosca = 1;


// Main Program

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("🪰 Iniciando el juego de la mosca...");
Console.WriteLine($"Tamaño del vector: {TamDefault}");
Console.WriteLine($"Número de intentos: {NumIntentosDefault}");

// Crear el vector (int[] se inicializa automáticamente con 0, que es VACIO)
var vector = new int[TamDefault];
SortearPosicionMosca(vector);

// Jugar
var resultado = JugarCazarMosca(vector, NumIntentosDefault);

// Mostrar resultado final
if (resultado)
    Console.WriteLine($"\n✅ ¡Has ganado! Cazaste la mosca en menos de {NumIntentosDefault} intentos.");
else
    Console.WriteLine($"\n❌ Has perdido. No cazaste la mosca en {NumIntentosDefault} intentos.");

// Mostrar vector final (se incluye para depuración o para mostrar dónde estaba la mosca)
ImprimirVector(vector);

Console.WriteLine("👋 Presiona una tecla para salir...");
Console.ReadKey();

// End Main Program

// Juego de cazar la mosca
bool JugarCazarMosca(int[] vector, int numIntentos) {
    var intentos = 0;
    var moscaMuerta = false;

    do {
        intentos = intentos + 1;
        Console.WriteLine($"--- Intento {intentos} de {numIntentos} ---");

        // Pedir posición y convertir a índice base 0
        var posicion = PedirPosicionValida(vector.Length);
        var resultadoGolpeo = AnalizarGolpeo(vector, posicion);

        switch (resultadoGolpeo) {
            case TipoGolpeo.Acertado:
                Console.WriteLine($"☠️ ¡TE LA HAS CARGADO! Has acertado en el intento {intentos}");
                moscaMuerta = true;
                break;

            case TipoGolpeo.Casi:
                Console.WriteLine($"🫤 ¡CASI! Has estado cerca en el intento {intentos}");
                Console.WriteLine("🪰 La mosca revolotea y cambia de posición...");
                SortearPosicionMosca(vector); // La mosca se mueve
                break;

            case TipoGolpeo.Fallado:
                Console.WriteLine($"💨 Has fallado en el intento {intentos}");
                break;

            default:
                Console.WriteLine("Error en la función AnalizarGolpeo");
                break;
        }
    } while (!moscaMuerta && intentos < numIntentos);

    return moscaMuerta;
}

// Analiza el golpeo en la posición dada y devuelve el tipo de golpeo.
static TipoGolpeo AnalizarGolpeo(int[] vector, int posicion) {
    // 1. Acertado
    if (vector[posicion] == Mosca)
        return TipoGolpeo.Acertado;

    // 2. Casi (adyacente)
    // Posición anterior (si existe)
    if (posicion > 0 && vector[posicion - 1] == Mosca)
        return TipoGolpeo.Casi;
    // Posición posterior (si existe)
    if (posicion < vector.Length - 1 && vector[posicion + 1] == Mosca)
        return TipoGolpeo.Casi;

    // 3. Fallado
    return TipoGolpeo.Fallado;
}

// Pide al usuario una posición válida dentro del rango del vector.
static int PedirPosicionValida(int size) {
    var inputValido = false;
    var posicion = -1;

    var regex = new Regex("^[1-" + size + "]$");

    do {
        Console.Write($"Introduce una posición para golpear (1..{size}): ");
        var userInput = (Console.ReadLine() ?? "").Trim(); // Remover espacios en blanco

        // Intentamos parsear la entrada y validar que esté dentro del rango [1, size]
        if (regex.IsMatch(userInput)) {
            posicion = int.Parse(userInput); // Es válido el casting
            inputValido = true;
        }
        else {
            Console.WriteLine($"❌ Entrada no válida. Debes introducir un número entero entre 1 y {size}.");
        }
    } while (!inputValido);

    return posicion - 1; // Convertir a índice 0-based
}

// Imprime el estado actual del vector en consola.
static void ImprimirVector(int[] vector) {
    Console.WriteLine("--- Estado del Tablero ---");
    // Imprimir los índices (para referencia del usuario)
    for (var i = 0; i < vector.Length; i++)
        Console.Write($"({i + 1})");

    Console.WriteLine();

    // Imprimir el contenido
    for (var i = 0; i < vector.Length; i++)
        if (vector[i] == Mosca)
            Console.Write("[🪰]");
        else
            Console.Write("[ ]");

    Console.WriteLine(); // Salto de línea
    Console.WriteLine("--------------------------");
}

// Sortea una nueva posición para la mosca dentro del vector.
static void SortearPosicionMosca(int[] vector) {
    // 1. Inicializar con VACIO (0)
    var random = new Random();
    for (var i = 0; i < vector.Length; i++)
        vector[i] = Vacio;

    // 2. Elegir posición aleatoria
    // Next(min, max) donde max es exclusivo (0 hasta Length-1)
    var posicionMosca = random.Next(0, vector.Length);
    vector[posicionMosca] = Mosca;
}