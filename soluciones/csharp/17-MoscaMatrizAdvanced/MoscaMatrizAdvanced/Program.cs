using System.Text;
using System.Text.RegularExpressions;
using _12_MoscaMatriz.Enums;
using _12_MoscaMatriz.Structs;
using Serilog;
using Spectre.Console;
using AnsiConsole = Spectre.Console.AnsiConsole;
using Rule = Spectre.Console.Rule;
using Table = Spectre.Console.Table;
using TableBorder = Spectre.Console.TableBorder;
using TableColumn = Spectre.Console.TableColumn;

// ----------------------------------------------------
// CONSTANTES GLOBALES
// ----------------------------------------------------
const int TamDefault = 8;
const int NumIntentosDefault = 5;
var random = new Random();

// ----------------------------------------------------
// CONFIGURACIÓN DEL LOGGER (Serilog)
// ----------------------------------------------------
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("debug.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();

Log.Information("🎮 Iniciando el juego Cazar la Mosca...");

// Main program
Console.OutputEncoding = Encoding.UTF8;
Console.Clear();

// ----------------------------------------------------
// BLOQUE PRINCIPAL
// ----------------------------------------------------
var configuracion = ValidarArgumentosEntrada(args);

AnsiConsole.Write(
    new Rule("[bold yellow]🎮 INICIANDO JUEGO CAZAR LA MOSCA 🪰[/]").Centered());
AnsiConsole.WriteLine();
AnsiConsole.MarkupLine($"[green]Tamaño del tablero:[/] {configuracion.Tamaño}x{configuracion.Tamaño}");
AnsiConsole.MarkupLine($"[green]Intentos disponibles:[/] {configuracion.Vidas}\n");

var matriz = new Celda[configuracion.Tamaño, configuracion.Tamaño];
var result = JugarCazarMosca(matriz, configuracion.Vidas);

if (result)
    AnsiConsole.MarkupLine("[bold green]✅ ¡HAS GANADO! Has cazado la mosca.[/]");
else
    AnsiConsole.MarkupLine("[bold red]❌ ¡HAS PERDIDO! La mosca se burló de ti.[/]");

AnsiConsole.Write(new Rule("[yellow]Posición Final de la Mosca[/]").LeftJustified());
ImprimirMatriz(matriz, result);

AnsiConsole.MarkupLine("[grey]👋 Presiona una tecla para salir...[/]");
Console.ReadKey();
return;

// ----------------------------------------------------
// FUNCIONES AUXILIARES
// ----------------------------------------------------

Configuracion ValidarArgumentosEntrada(string[] args) {
    Log.Debug("Entrando en ValidarArgumentosEntrada() con args: {Args}", string.Join(" ", args));

    if (args.Length != 2) {
        Log.Warning("Argumentos inválidos, se pedirá configuración manual.");
        return PedirConfiguracion();
    }

    var vidas = args[0].Split(':');
    var tam = args[1].Split(':');

    if (vidas.Length != 2 || tam.Length != 2 ||
        !int.TryParse(vidas[1], out var vidasParsed) ||
        !int.TryParse(tam[1], out var tamParsed)) {
        Log.Warning("Argumentos inválidos, se pedirá configuración manual.");
        return PedirConfiguracion();
    }

    if (vidasParsed < 1 || vidasParsed > NumIntentosDefault || tamParsed < 1 || tamParsed > TamDefault) {
        Log.Warning("Argumentos fuera de rango, se pedirá configuración manual.");
        return PedirConfiguracion();
    }

    return new Configuracion { Vidas = vidasParsed, Tamaño = tamParsed };
}

Configuracion PedirConfiguracion() {
    Log.Debug("Entrando en PedirConfiguracion()");
    // Esta expresión significa vidas:X tam:Y donde X e Y son números enteros, y hay un espacio entre ambos
    var regex = new Regex(@"^vidas:(\d+)\s+tam:(\d+)$", RegexOptions.IgnoreCase);

    var input = AnsiConsole.Prompt(
        new TextPrompt<string>("Introduce configuración (ej: vidas:3 tam:5):").PromptStyle("yellow")
            .Validate(text => regex.IsMatch(text.Trim()))
            .ValidationErrorMessage("Formato inválido. Debe ser: vidas:X tam:Y")
    ).Trim();

    var match = regex.Match(input);
    var vidas = int.Parse(match.Groups[1].Value);
    var tam = int.Parse(match.Groups[2].Value);

    if (vidas < 1 || vidas > NumIntentosDefault) {
        AnsiConsole.MarkupLine($"[red]vidas debe estar entre 1 y {NumIntentosDefault}[/]");
        return PedirConfiguracion();
    }

    if (tam < 1 || tam > TamDefault) {
        AnsiConsole.MarkupLine($"[red]tam debe estar entre 1 y {TamDefault}[/]");
        return PedirConfiguracion();
    }

    return new Configuracion { Vidas = vidas, Tamaño = tam };
}

bool JugarCazarMosca(Celda[,] matriz, int numIntentos) {
    Log.Debug("Entrando en JugarCazarMosca() con numIntentos={N}", numIntentos);

    SortearPosicionMosca(matriz);
    var moscaMuerta = false;
    var intentos = 0;
    var fallos = 0;

    while (!moscaMuerta && intentos < numIntentos) {
        intentos++;
        AnsiConsole.MarkupLine($"\n[bold cyan]--- INTENTO {intentos} de {numIntentos} ---[/]");

        // Pedimos la posición **fuera de cualquier Progress**
        var posicion = PedirPosicionValida(matriz.GetLength(0));

        var resultado = AnalizarGolpeo(matriz, posicion);

        switch (resultado) {
            case Golpeo.Acertado:
                AnsiConsole.MarkupLine("[bold green]✅ ☠️ ¡TE LA HAS CARGADO![/]");
                matriz[posicion.Fila, posicion.Columna] = Celda.MoscaMuerta;
                moscaMuerta = true;
                break;

            case Golpeo.Casi:
                AnsiConsole.MarkupLine("[yellow]💨 ¡CASI! La mosca se mueve y se ríe de ti! 🤣[/]");
                LimpiarMatriz(matriz);
                SortearPosicionMosca(matriz);
                break;

            case Golpeo.Fallado:
                AnsiConsole.MarkupLine("[red]❌ Has fallado, inténtalo otra vez.[/]");
                fallos++;
                // Dibujar barra manual
                DibujarBarraProgreso(fallos, numIntentos);
                break;
        }
        // Esto es para depurar
        // ImprimirMatriz(matriz, moscaMuerta);
    }

    return moscaMuerta;
}

// Barra de progreso simple en la consola
void DibujarBarraProgreso(int fallos, int maxFallos) {
    var porcentaje = (int)(fallos / (double)maxFallos * 100);
    var largo = 30; // ancho de barra
    var llenado = (int)(largo * porcentaje / 100.0);

    // Elegimos color según porcentaje
    Style style;
    if (porcentaje < 50) style = new Style(Color.Green);
    else if (porcentaje < 80) style = new Style(Color.Yellow);
    else style = new Style(Color.Red);

    var barra = new string('■', llenado).PadRight(largo, '─');

    // Imprimimos de manera segura sin usar Markup
    AnsiConsole.WriteLine();
    AnsiConsole.Write(new Markup(barra, style));
    AnsiConsole.WriteLine($" {porcentaje}% fallos");
}


Golpeo AnalizarGolpeo(Celda[,] matriz, Posicion posicion) {
    Log.Debug("Analizando golpeo en posición ({F},{C})", posicion.Fila, posicion.Columna);

    var size = matriz.GetLength(0);

    if (matriz[posicion.Fila, posicion.Columna] == Celda.Mosca)
        return Golpeo.Acertado;

    for (var i = -1; i <= 1; i++)
        for (var j = -1; j <= 1; j++)
            if (!(i == 0 && j == 0)) {
                var f = posicion.Fila + i;
                var c = posicion.Columna + j;

                if (f >= 0 && f < size && c >= 0 && c < size && matriz[f, c] == Celda.Mosca)
                    return Golpeo.Casi;
            }

    return Golpeo.Fallado;
}

Posicion PedirPosicionValida(int size) {
    Log.Debug("Entrando en PedirPosicionValida(size={S})", size);

    var regex = new Regex(@"^(\d+),(\d+)$", RegexOptions.IgnoreCase);

    var entrada = AnsiConsole.Prompt(
        new TextPrompt<string>($"Introduce posición (fila,columna) entre 1 y {size}:").PromptStyle("cyan")
            .Validate(text => regex.IsMatch(text.Trim())).ValidationErrorMessage("Formato inválido. Ejemplo: 2:3")
    ).Trim();

    var match = regex.Match(entrada);
    var fila = int.Parse(match.Groups[1].Value);
    var col = int.Parse(match.Groups[2].Value);

    if (fila < 1 || fila > size || col < 1 || col > size) {
        AnsiConsole.MarkupLine($"[red]Valores fuera de rango (1-{size})[/]");
        return PedirPosicionValida(size);
    }

    return new Posicion { Fila = fila - 1, Columna = col - 1 };
}

void ImprimirMatriz(Celda[,] matriz, bool isMuerta = false) {
    Log.Debug("Mostrando matriz final con Spectre.Table()");

    var size = matriz.GetLength(0);

    // Empleados caracteres de ancho fijo
    var vacio = "◻️";
    var mosca = "🐝";
    var muerta = "☠️";

    var tabla = new Table()
        .Border(TableBorder.None)
        //.Centered()
        .HideHeaders();

    // Primera columna vacía (esquina superior izquierda)
    tabla.AddColumn(new TableColumn("").Centered());

    // Números de columnas
    for (var c = 0; c < size; c++)
        tabla.AddColumn(new TableColumn($"{c + 1}").Centered());

    // Filas
    for (var f = 0; f < size; f++) {
        var fila = new string[size + 1];
        fila[0] = $"{f + 1}"; // número de fila

        // Recorremos columnas
        for (var c = 0; c < size; c++)
            // Asignamos el símbolo correspondiente según el estado de la celda
            //Dependiendo si la mosca está muerta o no, mostramos diferente símbolo
            fila[c + 1] = matriz[f, c] switch {
                Celda.Mosca => mosca,
                Celda.MoscaMuerta => muerta,
                _ => vacio
            };

        tabla.AddRow(fila);
    }

    AnsiConsole.Write(tabla);
}

void SortearPosicionMosca(Celda[,] matriz) {
    Log.Debug("Sorteando posición nueva para la mosca...");
    LimpiarMatriz(matriz);

    var size = matriz.GetLength(0);
    var f = random.Next(size);
    var c = random.Next(size);

    matriz[f, c] = Celda.Mosca;
    Log.Debug("Mosca colocada en ({F},{C})", f, c);
}

void LimpiarMatriz(Celda[,] matriz) {
    Log.Debug("Limpiando matriz...");
    var filas = matriz.GetLength(0);
    var columnas = matriz.GetLength(1);

    for (var i = 0; i < filas; i++)
        for (var j = 0; j < columnas; j++)
            matriz[i, j] = Celda.Vacio;
}