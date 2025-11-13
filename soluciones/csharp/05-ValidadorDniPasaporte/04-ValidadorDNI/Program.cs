using System.Text;
using System.Text.RegularExpressions;

// Main entry point 
// Poder escribir Emojis en la consola
Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("\nValidador de Pasaporte 🇪🇸");
var pasaporteInput = Console.ReadLine()?.Trim() ?? "";
if (IsPasaporteValido(pasaporteInput))
    Console.WriteLine($"✅  El pasaporte {pasaporteInput} es válido.");
else
    Console.WriteLine($"❌  El pasaporte {pasaporteInput} no es válido.");


Console.WriteLine("Validador de DNI 🇪🇸");
// Pedir al usuario que ingrese un DNI
var dniInput = Console.ReadLine()?.Trim() ?? "";
if (IsDniValido(dniInput))
    Console.WriteLine($"✅  El DNI {dniInput} es válido.");
else
    Console.WriteLine($"❌  El DNI {dniInput} no es válido.");

// Otros ejemplos de DNIs para probar
var ejemplosDni = new[] { "12345678Z", "87654321X", "00000000T", "99999999R", "12345678A" };
foreach (var ejemplo in ejemplosDni)
    if (IsDniValido(ejemplo))
        Console.WriteLine($"✅  El DNI {ejemplo} es válido.");
    else
        Console.WriteLine($"❌  El DNI {ejemplo} no es válido.");


// Pausa para ver el resultado
Console.WriteLine("👋 Presiona una tecla para salir...");
Console.ReadKey();
return;
// End of Main entry point

// Métodos auxiliares
bool IsDniValido(string dni) {
    // Sin usar grupos, lo usaremos en el pasaporte!!!
    var letrasValidas = "TRWAGMYFPDXBNJZSQVHLCKE";
    var regex = new Regex(@"^\d{8}[" + letrasValidas + "]$");

    dni = dni?.ToUpper()?.Trim() ?? "";

    if (!regex.IsMatch(dni)) return false;

    var numero = int.Parse(dni.Substring(0, 8));
    var letra = dni[8];
    var letraEsperada = letrasValidas[numero % 23];

    return letra == letraEsperada;
}

bool IsPasaporteValido(string pasaporte) {
    var alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    var letrasValidas = "TRWAGMYFPDXBNJZSQVHLCKE";
    var regex = new Regex(
        @"^(?<tresletras>[ABCDEFGHIJKLMNOPQRSTUVWXYZ]{3})(?<numero>[0-9]{6})(?<letra>[TRWAGMYFPDXBNJZSQVHLCKE])$");

    pasaporte = pasaporte?.ToUpper()?.Trim() ?? "";

    var match = regex.Match(pasaporte);
    if (!match.Success) return false;
    var tresletras = match.Groups["tresletras"].Value;
    var numero = int.Parse(match.Groups["numero"].Value);
    var letra = match.Groups["letra"].Value[0];

    Console.WriteLine($"Validando pasaporte con tres letras: {tresletras}, número: {numero}, letra: {letra}");

    var sb = new StringBuilder();
    var numerosConcatenados = "";

    foreach (var item in tresletras) {
        var indice = alfabeto.IndexOf(item);
        sb.Append(indice);
    }

    // Obtener la cadena del StringBuilder
    numerosConcatenados = sb.ToString();

    // Se concatenan las letras convertidas a números con los 6 dígitos del Pasaporte
    var numeroFinalString = numerosConcatenados + numero;
    var numeroBase = long.Parse(numeroFinalString);

    // Cálculo final
    // Console.WriteLine($"Número base: {numeroBase}");
    var resto = Convert.ToInt32(numeroBase % 23);
    // Console.WriteLine($"Resto de la división: {resto}");
    var letraCalculada = letrasValidas[resto];
    // Console.WriteLine($"Letra calculada: {letraCalculada}");

    // Comparación final
    return letraCalculada == letra;
}