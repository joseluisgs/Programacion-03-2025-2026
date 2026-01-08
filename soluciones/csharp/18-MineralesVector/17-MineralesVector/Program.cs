using System.Text;

// ----------------------------------------------------
// CONSTANTES GLOBALES
// ----------------------------------------------------
const int Size = 10;
const int MaxValue = 20;
const int ProbMineral = 50;
const int MaxTime = 30;
const int ProbTakeMineral = 50;
const int PauseTime = 1000;
const int NumMineralsTaken = 2;
const int ProbDecision = 30;

// ----------------------------------------------------
// BLOQUE PRINCIPAL (MAIN)
// ----------------------------------------------------

Console.OutputEncoding = Encoding.UTF8;
Console.Clear();

Console.WriteLine("Detector de Minerales");

var mapMinerales = CrearMapa(Size, MaxValue, ProbMineral);
Console.WriteLine("--- Mapa Inicial de Minerales (Valores) ---");
PrintMapMinerales(mapMinerales);

var time = 1;
var cantidadMineral = 0;
var direccionBusqueda = 1;
var posicionActual = 0;

var rnd = new Random();

do {
    Console.WriteLine();
    Console.WriteLine($"--- Paso {time} / {MaxTime} ---");
    Console.WriteLine($"Mineral Recolectado: {cantidadMineral}");
    Console.WriteLine($"Posicion Actual: {posicionActual + 1}");
    Console.WriteLine($"Direccion de Busqueda: {(direccionBusqueda == 1 ? "Derecha ➡️" : "Izquierda ⬅️")}");

    PrintTablero(posicionActual);

    cantidadMineral += BuscarMineral(mapMinerales, posicionActual, rnd);

    if (time % 2 == 0)
        if (rnd.Next(0, 100) < ProbDecision) {
            Console.WriteLine("He decidido cambiar de Direccion, me lo pienso...");

            var nuevaDireccionRandom = rnd.Next(0, 2);
            var nuevaDireccionBusqueda = nuevaDireccionRandom == 0 ? -1 : 1;

            if (nuevaDireccionBusqueda == direccionBusqueda) {
                Console.WriteLine("...No cambio de Direccion");
            }
            else {
                Console.WriteLine("...Cambio de Direccion");
                direccionBusqueda = nuevaDireccionBusqueda;
            }
        }

    if (IsEndMap(mapMinerales, posicionActual, direccionBusqueda)) {
        Console.WriteLine("He llegado al extremo del mapa, cambio de Direccion obligatoriamente");
        direccionBusqueda *= -1;
    }

    posicionActual += direccionBusqueda;

    Thread.Sleep(PauseTime);
    time++;
} while (HayMineral(mapMinerales) && time <= MaxTime);



// ----------------------------------------------------
// RESULTADO FINAL
// ----------------------------------------------------
Console.WriteLine();
Console.WriteLine("--------------------------------------");
Console.WriteLine("FIN DE LA EXPLORACION");
Console.WriteLine("--------------------------------------");
Console.WriteLine($"Tiempo Final: {time - 1}");
Console.WriteLine($"Cantidad de Mineral Total: {cantidadMineral}");
Console.WriteLine($"Posicion Final: {posicionActual + 1}");
Console.WriteLine("--- Mapa Final de Minerales (Valores) ---");
PrintMapMinerales(mapMinerales);

Console.WriteLine("Presiona una tecla para salir...");
Console.ReadKey();
return;


// ----------------------------------------------------
// FUNCIONES AUXILIARES
// ----------------------------------------------------
void PrintTablero(int posicionActual) {
    for (var i = 0; i < Size; i++)
        if (i == posicionActual)
            Console.Write("[🤖]");
        else
            Console.Write("[  ]");
    Console.WriteLine();
}

bool IsEndMap(int[] mapMinerales, int posicionActual, int direccionBusqueda) {
    return (posicionActual == 0 && direccionBusqueda == -1) ||
           (posicionActual == mapMinerales.Length - 1 && direccionBusqueda == 1);
}

int BuscarMineral(int[] mapMinerales, int posicionActual, Random rnd) {
    if (mapMinerales[posicionActual] >= NumMineralsTaken) {
        Console.WriteLine($"Mineral encontrado en la posicion {posicionActual + 1}");

        if (rnd.Next(0, 100) < ProbTakeMineral) {
            Console.WriteLine($"Mineral tomado (-{NumMineralsTaken})");
            mapMinerales[posicionActual] -= NumMineralsTaken;
            return NumMineralsTaken;
        }

        Console.WriteLine("Mineral no tomado (Probabilidad fallida)");
        return 0;
    }

    Console.WriteLine($"No hay mineral suficiente para tomar en la posicion {posicionActual + 1}");
    return 0;
}

int[] CrearMapa(int size, int maxValue, int probMineral) {
    var map = new int[size];
    var rnd = new Random();

    for (var i = 0; i < map.Length; i++)
        if (rnd.Next(0, 100) < probMineral)
            map[i] = rnd.Next(0, maxValue);
        else
            map[i] = 0;

    return map;
}

void PrintMapMinerales(int[] map) {
    for (var i = 0; i < map.Length; i++)
        Console.Write($"[{map[i]}]");
    Console.WriteLine();
}

bool HayMineral(int[] map) {
    foreach (var m in map)
        if (m > 0)
            return true;
    return false;
}