// See https://aka.ms/new-console-template for more information

using System.Text;
using Spectre.Console;

Console.OutputEncoding = Encoding.UTF8;
Console.Clear();
Console.WriteLine("Hello, World!");


ColoresPorMi();

/*
 * Spectre.Console
 * dotnet add package Spectre.Console
 * dotnet add package Spectre.Console.Cli
 * Documentación oficial → https://spectreconsole.net/
 */

Console.WriteLine("\n--- Colores con Spectre.Console ---\n");
ColoresConSpectre();

Console.WriteLine("\n--- Tablas con Spectre.Console ---\n");
TablasConSpectre();

Console.WriteLine("👋 Presiona una tecla para salir...");
Console.ReadKey();
return;


void ColoresPorMi() {
    // Escribe en gris normal (como Print normal)
    PrintColor("Normal\n");

// Texto amarillo, fondo rojo, y luego vuelve a los colores normales
    PrintColor("Peligro!\n", ConsoleColor.Yellow, ConsoleColor.Red);

// Cambia solo color de texto y mantiene el fondo actual
    PrintColor("Aviso\n", ConsoleColor.Cyan);

// Deja los colores activos hasta que tú los cambies
    PrintColor("Modo alerta activado\n", ConsoleColor.Black, ConsoleColor.Yellow, false);

    Console.ResetColor();
    PrintColor("Todo el texto después saldrá con esos colores!\n");

    PrintColor("Este es un texto en ", ConsoleColor.White);
    PrintColor("rojo", ConsoleColor.Red);
    PrintColor(", y este es un texto en ", ConsoleColor.White);
    PrintColor("verde", ConsoleColor.Green);
    PrintColor(".\n", ConsoleColor.White);

    PrintColor("Este es un texto con fondo ", ConsoleColor.Black);
    PrintColor("amarillo", null, ConsoleColor.Yellow);
    PrintColor(", y este es un texto con fondo ", ConsoleColor.Black);
    PrintColor("azul", null, ConsoleColor.Blue);
    PrintColor(".\n", ConsoleColor.Black);

    PrintColor("Este es un texto ", ConsoleColor.Cyan, ConsoleColor.DarkMagenta);
    PrintColor("con colores personalizados.\n", ConsoleColor.Yellow, ConsoleColor.DarkBlue);
}

// Hecho por mi
void PrintColor(
    string texto,
    ConsoleColor? colorTexto = null,
    ConsoleColor? colorFondo = null,
    bool resetColor = true) {
    // Si se indica color de texto lo aplicamos
    if (colorTexto.HasValue)
        Console.ForegroundColor = colorTexto.Value;

    // Si se indica color de fondo lo aplicamos
    if (colorFondo.HasValue)
        Console.BackgroundColor = colorFondo.Value;

    Console.Write(texto);

    // Si queremos restaurar los colores originales
    if (resetColor)
        Console.ResetColor();
}

void ColoresConSpectre() {
    // Texto con colores (estilo tipo BBCode)
    AnsiConsole.MarkupLine("[green]Texto en verde[/]");
    AnsiConsole.MarkupLine("[red on yellow]Texto rojo con fondo amarillo[/]");
    AnsiConsole.MarkupLine("[bold blue]Texto azul en negrita[/]");

    // Combinar estilos fácilmente
    AnsiConsole.MarkupLine("[underline italic magenta]Subrayado, cursiva y magenta[/]");

    // Texto con emojis
    AnsiConsole.MarkupLine("¡Hola! 👋 ¿Cómo estás? 💏");

    // Texto en negrita rojo con fondo blanco
    AnsiConsole.MarkupLine("[bold red on white]Importante[/]");

    // Puedes usar Write o WriteLine, por ejemplo con Bold e italics y subrayado en blanco sobre rojo
    AnsiConsole.MarkupLine("[bold italic underline white on red]Atención!!![/]");
    AnsiConsole.MarkupLine("[green]Mensaje normal en verde[/]");
}

void TablasConSpectre() {
    // Creamos la tabla
    var tabla = new Table();

    tabla.Border = TableBorder.Rounded; // Borde bonito 😎
    tabla.AddColumn("[yellow]Jugador[/]");
    tabla.AddColumn("[green]Puntuación[/]");
    tabla.AddColumn("[cyan]Nivel[/]");

    tabla.AddRow("Luis", "1500", "7");
    tabla.AddRow("Ana", "2100", "9");
    tabla.AddRow("Marco", "500", "2");

    AnsiConsole.Write(tabla);
}