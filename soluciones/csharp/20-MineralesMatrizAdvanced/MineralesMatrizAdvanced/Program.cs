using System.Text;
using _18_MineralesMatriz.Structs;
using Serilog;
using Serilog.Events;
using Spectre.Console;

// ----------------------------------------------------
// CONFIGURACIÓN DE LOG
// ----------------------------------------------------
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
    .WriteTo.Console(LogEventLevel.Warning)
    .CreateLogger();

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

var random = new Random();

// ----------------------------------------------------
// BLOQUE PRINCIPAL (MAIN)
// ----------------------------------------------------
Console.OutputEncoding = Encoding.UTF8;
Console.Clear();
AnsiConsole.MarkupLine("[bold yellow]🤖 Detector de Minerales 2D 🤖[/]");

// Creamos la matriz de minerales
var mapMinerales = CrearMapa(Size, MaxValue, ProbMineral);
AnsiConsole.MarkupLine("[bold yellow]--- Mapa Inicial de Minerales (Valores) ---[/]");
PrintMapMinerales(mapMinerales);

var cantidadMineral = 0;
var direccionBusqueda = GetRandomDirection();
var posicionActual = GetInitialPosition();

// Barra de progreso con Spectre.Console
AnsiConsole.Progress()
    .AutoClear(false)
    .Columns(new TaskDescriptionColumn(), new ProgressBarColumn(), new PercentageColumn(), new RemainingTimeColumn())
    .Start(ctx => {
        var task = ctx.AddTask("Explorando minerales...", maxValue: MaxTime);

        for (var t = 1; t <= MaxTime && HayMineral(mapMinerales); t++) {
            AccionJuego(t, ref cantidadMineral, ref posicionActual, ref direccionBusqueda, mapMinerales);

            Thread.Sleep(PauseTime);
            task.Increment(1);
        }

        task.Value = task.MaxValue;
    });

// ----------------------------------------------------
// RESULTADO FINAL
// ----------------------------------------------------
Console.Clear();
AnsiConsole.MarkupLine("[bold yellow]--------------------------------------[/]");
AnsiConsole.MarkupLine("[bold yellow]FIN DE LA EXPLORACION 🤖[/]");
AnsiConsole.MarkupLine("[bold yellow]--------------------------------------[/]");
AnsiConsole.MarkupLine($"[bold cyan]Tiempo Final:[/] [green]{MaxTime}[/]");
AnsiConsole.MarkupLine($"[bold cyan]Cantidad de Mineral Total:[/] [green]{cantidadMineral} 💎[/]");
AnsiConsole.MarkupLine($"[bold cyan]{GetPosicionActual(posicionActual)} 🤖[/]");
AnsiConsole.MarkupLine("[bold yellow]--- Mapa Final de Minerales (Valores) ---[/]");
PrintMapMinerales(mapMinerales);

AnsiConsole.MarkupLine("[bold yellow]👋 Presiona una tecla para salir...[/]");
Console.ReadKey();
return;

// ----------------------------------------------------
// FUNCIONES DEL JUEGO
// ----------------------------------------------------
void AccionJuego(int t, ref int cantidadMineral, ref Posicion posicionActual, ref Direccion direccionBusqueda,
    int[,] mapMinerales) {
    Console.Clear();
    AnsiConsole.MarkupLine($"[bold yellow]--- Paso {t} / {MaxTime} ---[/]");
    AnsiConsole.MarkupLine($"[bold cyan]Mineral Recolectado:[/] [green]{cantidadMineral} 💎[/]");
    AnsiConsole.MarkupLine($"[bold cyan]{GetPosicionActual(posicionActual)} 🤖[/]");
    AnsiConsole.MarkupLine($"[bold cyan]{GetDireccionBusqueda(direccionBusqueda)}[/]");

    // Imprime el mapa con el robot y los minerales (tablas originales)
    PrintTablero(mapMinerales, posicionActual);

    // Buscar mineral en la posición actual
    cantidadMineral += BuscarMineral(mapMinerales, posicionActual);

    // Decisión de cambio de dirección
    if (t % 2 == 0)
        direccionBusqueda = GetAndThinkNewDirection(direccionBusqueda);

    // Evitar salir del mapa
    while (IsEndMap(posicionActual, direccionBusqueda)) {
        AnsiConsole.MarkupLine("[red]⚠️ Límite alcanzado. Generando nueva dirección...[/]");
        Log.Warning("Límite alcanzado en la posición f:{Fila} c:{Columna}, recalculando dirección",
            posicionActual.Fila + 1, posicionActual.Columna + 1);
        direccionBusqueda = GetRandomDirection();
    }

    // Movimiento
    posicionActual = GetNewPosicion(posicionActual, direccionBusqueda);
}

Posicion GetInitialPosition() {
    var pos = new Posicion { Fila = random.Next(0, Size), Columna = random.Next(0, Size) };
    Log.Debug("Posición inicial generada: f:{Fila} c:{Columna}", pos.Fila + 1, pos.Columna + 1);
    return pos;
}

Direccion GetRandomDirection() {
    Direccion nueva;
    do {
        nueva = new Direccion { Fila = random.Next(-1, 2), Columna = random.Next(-1, 2) };
    } while (nueva.Fila == 0 && nueva.Columna == 0);

    Log.Debug("Dirección aleatoria generada: fila {Fila}, columna {Columna}", nueva.Fila, nueva.Columna);
    return nueva;
}

Posicion GetNewPosicion(Posicion actual, Direccion direccion) {
    var nueva = new Posicion { Fila = actual.Fila + direccion.Fila, Columna = actual.Columna + direccion.Columna };
    Log.Debug("Nueva posición calculada: f:{Fila} c:{Columna}", nueva.Fila + 1, nueva.Columna + 1);
    return nueva;
}

Direccion GetAndThinkNewDirection(Direccion direccion) {
    if (random.Next(0, 100) < ProbDecision) {
        AnsiConsole.MarkupLine("[bold magenta]💭 He decidido cambiar de Dirección...[/]");
        var nueva = GetRandomDirection();
        if (nueva.Fila == direccion.Fila && nueva.Columna == direccion.Columna) {
            AnsiConsole.MarkupLine("[yellow]...No cambio de dirección[/]");
            Log.Information("Decidí cambiar de dirección, pero se mantiene la misma");
            return direccion;
        }

        AnsiConsole.MarkupLine("[bold green]↗️ Cambio de dirección[/]");
        Log.Information("Dirección cambiada: fila {Fila}, columna {Columna}", nueva.Fila, nueva.Columna);
        return nueva;
    }

    return direccion;
}

int BuscarMineral(int[,] mapa, Posicion pos) {
    if (mapa[pos.Fila, pos.Columna] > 0) {
        AnsiConsole.MarkupLine($"[bold yellow]⛏️ Mineral encontrado en f:{pos.Fila + 1}, c:{pos.Columna + 1}[/]");
        if (random.Next(0, 100) < ProbTakeMineral) {
            var tomar = NumMineralsTaken;
            if (mapa[pos.Fila, pos.Columna] < NumMineralsTaken) tomar = mapa[pos.Fila, pos.Columna];
            AnsiConsole.MarkupLine($"[bold green]✅ Mineral tomado (-{tomar})[/]");
            Log.Information("Mineral tomado: {Cantidad} en f:{Fila} c:{Columna}", tomar, pos.Fila + 1, pos.Columna + 1);
            mapa[pos.Fila, pos.Columna] -= tomar;
            return tomar;
        }

        AnsiConsole.MarkupLine("[red]❌ Mineral no tomado (falló probabilidad)[/]");
        return 0;
    }

    AnsiConsole.MarkupLine($"[grey]⚠️ No hay mineral en f:{pos.Fila + 1}, c:{pos.Columna + 1}[/]");
    return 0;
}

int[,] CrearMapa(int size, int maxValue, int probMineral) {
    var mapa = new int[size, size];
    for (var i = 0; i < size; i++)
        for (var j = 0; j < size; j++)
            mapa[i, j] = random.Next(0, 100) < probMineral ? random.Next(0, maxValue) : 0;
    Log.Debug("Mapa creado con tamaño {Size}x{Size}", size, size);
    return mapa;
}

bool IsEndMap(Posicion pos, Direccion dir) {
    var nueva = new Posicion { Fila = pos.Fila + dir.Fila, Columna = pos.Columna + dir.Columna };
    return nueva.Fila < 0 || nueva.Fila >= Size || nueva.Columna < 0 || nueva.Columna >= Size;
}

bool HayMineral(int[,] mapa) {
    for (var i = 0; i < Size; i++)
        for (var j = 0; j < Size; j++)
            if (mapa[i, j] > 0)
                return true;
    return false;
}

string GetPosicionActual(Posicion pos) {
    return $"Posición Actual: f:{pos.Fila + 1}, c:{pos.Columna + 1}";
}

string GetDireccionBusqueda(Direccion dir) {
    return (dir.Fila, dir.Columna) switch {
        (-1, -1) => "Dirección de búsqueda: ↖️ NW",
        (-1, 0) => "Dirección de búsqueda: ⬆️ N",
        (-1, 1) => "Dirección de búsqueda: ↗️ NE",
        (0, -1) => "Dirección de búsqueda: ⬅️ W",
        (0, 1) => "Dirección de búsqueda: ➡️ E",
        (1, -1) => "Dirección de búsqueda: ↙️ SW",
        (1, 0) => "Dirección de búsqueda: ⬇️ S",
        (1, 1) => "Dirección de búsqueda: ↘️ SE",
        _ => "Dirección de búsqueda: -"
    };
}

// ----------------------------------------------------
// TABLAS ORIGINALES
// ----------------------------------------------------
void PrintTablero(int[,] mapa, Posicion pos) {
    Console.WriteLine();
    Console.WriteLine($"--- Tablero ({Size}x{Size}) ---");
    for (var i = 0; i < Size; i++) {
        for (var j = 0; j < Size; j++)
            if (i == pos.Fila && j == pos.Columna) Console.Write("🤖");
            else if (mapa[i, j] > 0) Console.Write("⛏️");
            else Console.Write(" . ");
        Console.WriteLine();
    }
}

void PrintMapMinerales(int[,] mapa) {
    for (var i = 0; i < Size; i++) {
        for (var j = 0; j < Size; j++) {
            if (mapa[i, j] > 0)
                Console.Write($"[{mapa[i, j],2}]");
            else
                Console.Write("[  ]");
            Console.Write(" ");
        }

        Console.WriteLine();
    }
}