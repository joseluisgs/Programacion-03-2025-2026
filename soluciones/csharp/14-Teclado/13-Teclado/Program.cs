
// 0. Limpieza de la consola al iniciar

using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.Clear();
Console.WriteLine("Pulsa teclas. (Esc para salir)");

ConsoleKeyInfo tecla;
do {
    tecla = Console.ReadKey(true); // true = no mostrar la tecla en consola

    if (tecla.Key == ConsoleKey.Enter)
        Console.WriteLine("⏎ Has pulsado ENTER");

    else if (tecla.Key == ConsoleKey.Spacebar)
        Console.WriteLine("␣ Has pulsado ESPACIO");

    else if (tecla.Key == ConsoleKey.A)
        Console.WriteLine("Has pulsado la letra A");

    else
        Console.WriteLine($"Has pulsado: {tecla.Key}");

} while (tecla.Key != ConsoleKey.Backspace); // Salir con BACKSPACE

Console.WriteLine("👋 Presiona una tecla para salir...");
Console.ReadKey();
return;
