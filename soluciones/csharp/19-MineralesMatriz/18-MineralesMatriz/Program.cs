using System.Text;
using _18_MineralesMatriz.Structs;

// ----------------------------------------------------
// CONSTANTES GLOBALES
// ----------------------------------------------------
const int Size = 10; // Tamaño del mapa (Size x Size)
const int MaxValue = 20; // Máximo mineral por casilla
const int ProbMineral = 50; // Probabilidad (%) de que haya mineral al inicio
const int MaxTime = 30; // Máximo de pasos de la simulación
const int ProbTakeMineral = 50; // Probabilidad (%) de tomar mineral
const int PauseTime = 1000; // Pausa entre pasos (ms)
const int NumMineralsTaken = 2; // Cantidad de mineral extraída por intento
const int ProbDecision = 30; // Probabilidad (%) de cambiar de dirección

var random = new Random(); // Instancia global de Random

// ----------------------------------------------------
// BLOQUE PRINCIPAL (MAIN)
// ----------------------------------------------------
Console.OutputEncoding = Encoding.UTF8;
Console.Clear();

Console.WriteLine("🤖 Detector de Minerales 2D 🤖");

// Creamos la matriz de minerales
var mapMinerales = CrearMapa(Size, MaxValue, ProbMineral);
Console.WriteLine("--- Mapa Inicial de Minerales (Valores) ---");
PrintMapMinerales(mapMinerales);

var time = 1;
var cantidadMineral = 0;

// Inicializamos posición y dirección
var direccionBusqueda = GetRandomDirection();
var posicionActual = GetInitialPosition();

do {
    Console.Clear(); // Limpia la consola para mostrar solo el paso actual
    Console.WriteLine($"--- Paso {time} / {MaxTime} ---");
    Console.WriteLine($"Mineral Recolectado: {cantidadMineral} 💎");
    Console.WriteLine(GetPosicionActual(posicionActual) + " 🤖");
    Console.WriteLine(GetDireccionBusqueda(direccionBusqueda));

    // Imprime el mapa con la barra de mineral por casilla
    PrintTablero(mapMinerales, posicionActual);

    cantidadMineral += BuscarMineral(mapMinerales, posicionActual);

    // Decisión de cambio de dirección
    if (time % 2 == 0)
        direccionBusqueda = GetAndThinkNewDirection(direccionBusqueda);

    // Evitar salir del mapa
    while (IsEndMap(posicionActual, direccionBusqueda)) {
        Console.WriteLine("⚠️ Límite alcanzado. Generando nueva dirección...");
        direccionBusqueda = GetRandomDirection();
    }

    // Movimiento
    posicionActual = GetNewPosicion(posicionActual, direccionBusqueda);

    // Dibujamos la barra de progreso **después del mapa**
    Console.WriteLine(); // Línea vacía antes de la barra
    DibujarBarraProgreso(time, MaxTime);

    Thread.Sleep(PauseTime);
    time++;
} while (HayMineral(mapMinerales) && time <= MaxTime);

// Resultado final
Console.Clear();
Console.WriteLine("--------------------------------------");
Console.WriteLine("FIN DE LA EXPLORACION 🤖");
Console.WriteLine("--------------------------------------");
Console.WriteLine($"Tiempo Final: {time - 1}");
Console.WriteLine($"Cantidad de Mineral Total: {cantidadMineral} 💎");
Console.WriteLine(GetPosicionActual(posicionActual) + " 🤖");
Console.WriteLine("--- Mapa Final de Minerales (Valores) ---");
PrintMapMinerales(mapMinerales);

Console.WriteLine("👋 Presiona una tecla para salir...");
Console.ReadKey();
return;

// ----------------------------------------------------
// FUNCIONES AUXILIARES
// ----------------------------------------------------
Posicion GetInitialPosition() {
    return new Posicion { Fila = random.Next(0, Size), Columna = random.Next(0, Size) };
}

Direccion GetRandomDirection() {
    Direccion nuevaDireccion;
    do {
        nuevaDireccion.Fila = random.Next(-1, 2); // -1,0,1
        nuevaDireccion.Columna = random.Next(-1, 2);
    } while (nuevaDireccion.Fila == 0 && nuevaDireccion.Columna == 0);

    return nuevaDireccion;
}

Posicion GetNewPosicion(Posicion actual, Direccion direccion) {
    return new Posicion {
        Fila = actual.Fila + direccion.Fila,
        Columna = actual.Columna + direccion.Columna
    };
}

Direccion GetAndThinkNewDirection(Direccion direccion) {
    if (random.Next(0, 100) < ProbDecision) {
        Console.WriteLine("💭 He decidido cambiar de Dirección...");
        var nueva = GetRandomDirection();
        if (nueva.Fila == direccion.Fila && nueva.Columna == direccion.Columna) {
            Console.WriteLine("...No cambio de dirección");
            return direccion;
        }

        Console.WriteLine("↗️ Cambio de dirección");
        return nueva;
    }

    return direccion;
}

string GetDireccionBusqueda(Direccion dir) {
    var simbolo = "Dirección de búsqueda: ";
    if (dir.Fila == -1 && dir.Columna == -1) simbolo += "↖️ NW";
    else if (dir.Fila == -1 && dir.Columna == 0) simbolo += "⬆️ N";
    else if (dir.Fila == -1 && dir.Columna == 1) simbolo += "↗️ NE";
    else if (dir.Fila == 0 && dir.Columna == -1) simbolo += "⬅️ W";
    else if (dir.Fila == 0 && dir.Columna == 1) simbolo += "➡️ E";
    else if (dir.Fila == 1 && dir.Columna == -1) simbolo += "↙️ SW";
    else if (dir.Fila == 1 && dir.Columna == 0) simbolo += "⬇️ S";
    else if (dir.Fila == 1 && dir.Columna == 1) simbolo += "↘️ SE";
    return simbolo;
}

string GetPosicionActual(Posicion pos) {
    return $"Posición Actual: f:{pos.Fila + 1}, c:{pos.Columna + 1}";
}

// ----------------------------------------------------
// FUNCIONES DE MAPA Y JUEGO
// ----------------------------------------------------
void PrintTablero(int[,] mapa, Posicion pos) {
    Console.WriteLine($"--- Tablero ({Size}x{Size}) ---");
    for (var i = 0; i < Size; i++) {
        for (var j = 0; j < Size; j++)
            if (i == pos.Fila && j == pos.Columna)
                Console.Write("🤖"); // Robot
            else if (mapa[i, j] > 0)
                Console.Write("⛏️"); // Pico, hay mineral
            else
                Console.Write(" . "); // Vacío

        Console.WriteLine();
    }
}


bool IsEndMap(Posicion pos, Direccion dir) {
    var nueva = new Posicion {
        Fila = pos.Fila + dir.Fila,
        Columna = pos.Columna + dir.Columna
    };
    return nueva.Fila < 0 || nueva.Fila >= Size || nueva.Columna < 0 || nueva.Columna >= Size;
}

int BuscarMineral(int[,] mapa, Posicion pos) {
    if (mapa[pos.Fila, pos.Columna] > 0) {
        Console.WriteLine($"⛏️ Mineral encontrado en f:{pos.Fila + 1}, c:{pos.Columna + 1}");
        if (random.Next(0, 100) < ProbTakeMineral) {
            var tomar = NumMineralsTaken;
            if (mapa[pos.Fila, pos.Columna] < NumMineralsTaken) tomar = mapa[pos.Fila, pos.Columna];
            Console.WriteLine($"✅ Mineral tomado (-{tomar})");
            mapa[pos.Fila, pos.Columna] -= tomar;
            return tomar;
        }

        Console.WriteLine("❌ Mineral no tomado (falló probabilidad)");
        return 0;
    }

    Console.WriteLine($"⚠️ No hay mineral en f:{pos.Fila + 1}, c:{pos.Columna + 1}");
    return 0;
}

int[,] CrearMapa(int size, int maxValue, int probMineral) {
    var mapa = new int[size, size];
    for (var i = 0; i < size; i++)
        for (var j = 0; j < size; j++)
            mapa[i, j] = random.Next(0, 100) < probMineral ? random.Next(0, maxValue) : 0;
    return mapa;
}

void PrintMapMinerales(int[,] mapa) {
    // Determinamos ancho fijo: por ejemplo 4 caracteres por celda "[xx]"

    for (var i = 0; i < Size; i++) {
        for (var j = 0; j < Size; j++) {
            if (mapa[i, j] > 0)
                // Alineamos a la derecha el número dentro de los corchetes
                Console.Write($"[{mapa[i, j],2}]"); // 2 espacios para el número
            else
                Console.Write("[  ]"); // mismo ancho aunque esté vacío
            Console.Write(" "); // espacio entre columnas
        }

        Console.WriteLine();
    }
}


bool HayMineral(int[,] mapa) {
    for (var i = 0; i < Size; i++)
        for (var j = 0; j < Size; j++)
            if (mapa[i, j] > 0)
                return true;
    return false;
}

void DibujarBarraProgreso(int actual, int maximo) {
    var largo = 30; // ancho de la barra
    var porcentaje = actual / (double)maximo;
    var llenado = (int)(largo * porcentaje);

    // Construimos la barra
    var barra = new string('■', llenado).PadRight(largo, '─');

    // Color simulado con ANSI (opcional)
    string color;
    if (porcentaje < 0.5) color = "\u001b[32m"; // verde
    else if (porcentaje < 0.8) color = "\u001b[33m"; // amarillo
    else color = "\u001b[31m"; // rojo

    var reset = "\u001b[0m";

    // Imprimimos en la misma línea, es el /r
    Console.Write($"\r{color}[{barra}]{reset} {(int)(porcentaje * 100)}%");
}