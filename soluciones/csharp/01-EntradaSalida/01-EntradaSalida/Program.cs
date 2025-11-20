using System.Text;
using System.Text.RegularExpressions;

// Main entry point 
// Poder escribir Emojis en la consola
Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine("Hola 2º DAW! 😀🚀");

// Pedir al usuario que ingrese un número entero
var numero = LeerEnteroEntreCeroYDiezTryParse("Por favor, ingresa un número entero: ");
Console.WriteLine($"✅  Has ingresado el número: {numero}");

numero = LeerEnteroEntreCeroYDiezExcepciones("Por favor, ingresa otro número entero: ");
Console.WriteLine($"✅  Has ingresado el número: {numero}");

numero = LeerEnteroEntreCeroYDiezExcepcionesMejorado("Por favor, ingresa un tercer número entero: ");
Console.WriteLine($"✅  Has ingresado el número: {numero}");

numero = LeerEnteroEntreCeroYDiezConExpresionesRegulares("Por favor, ingresa un cuarto número entero: ");
Console.WriteLine($"✅  Has ingresado el número: {numero}");

// Pausa para ver el resultado
Console.WriteLine("👋 Presiona una tecla para salir...");
Console.ReadKey();
return;


// End of Main entry point

// Métodos auxiliares
int LeerEnteroEntreCeroYDiezTryParse(string mensaje) {
    var esCorrecto = false;
    int valor;
    do {
        Console.Write(mensaje);
        esCorrecto = int.TryParse(Console.ReadLine()?.Trim(), out valor);
        if (!esCorrecto || valor < 0 || valor > 10) {
            Console.WriteLine("❌  Error: Debes ingresar un número entre 0 y 10.");
            esCorrecto = false;
        }
    } while (!esCorrecto);

    return valor;
}

int LeerEnteroEntreCeroYDiezExcepciones(string mensaje) {
    var valor = 0;
    var esCorrecto = false;
    do {
        try {
            Console.Write(mensaje);
            valor = int.Parse(Console.ReadLine()?.Trim() ?? "");
            if (valor < 0 || valor > 10)
                Console.WriteLine("❌  Error: Debes ingresar un número entre 0 y 10.");
            else
                esCorrecto = true;
        }
        catch (Exception) {
            Console.WriteLine("❌  Error: Entrada no válida. Inténtalo de nuevo.");
        }
    } while (!esCorrecto);

    return valor;
}

int LeerEnteroEntreCeroYDiezExcepcionesMejorado(string mensaje) {
    var valor = 0;
    while (true)
        try {
            Console.Write(mensaje);
            valor = int.Parse(Console.ReadLine()?.Trim() ?? "");
            if (valor < 0 || valor > 10)
                throw new ArgumentOutOfRangeException("El número debe estar entre 0 y 10.");
            return valor;
        }
        catch (FormatException) {
            Console.WriteLine("❌  Error: Entrada no válida. Inténtalo de nuevo.");
        }
        catch (ArgumentOutOfRangeException ex) {
            Console.WriteLine($"❌  Error: {ex.Message}");
        }
}

int LeerEnteroEntreCeroYDiezConExpresionesRegulares(string mensaje) {
    var esCorrecto = false;
    var valor = 0;
    var regex = new Regex(@"^(10|[0-9])$"); // Expresión regular para números entre 0 y 10
    do {
        Console.Write(mensaje);
        var entrada = Console.ReadLine()?.Trim() ?? "";
        if (regex.IsMatch(entrada ?? "")) {
            valor = int.Parse(entrada!); // Es seguro convertir aquí
            esCorrecto = true;
        }
        else {
            Console.WriteLine("❌  Error: Debes ingresar un número entre 0 y 10.");
        }
    } while (!esCorrecto);

    return valor;
}