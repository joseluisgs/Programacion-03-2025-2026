using System.Text;

// Constantes globales
// Alfabeto completo usado para el cifrado (incluye espacio, mayúsculas, minúsculas, números y símbolos)
const string AlfabetoCesar =
    " abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ1234567890.,;:¿?¡!()[]{}@#$%€&/\\\"'çÇáéíóúÁÉÍÓÚàèìòùÀÈÌÒÙâêîôûÂÊÎÔÛäëïöüÄËÏÖÜãõÃÕ";

// Main Program
Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("Cifrado Cesar");

// Variables de entrada
var mensaje = "¿Hola? Estamos en 1 DAW estamos en clase de Programación. ¡Disfrutando de los algoritmos! :)";
var desplazamiento =
    new Random().Next(1, AlfabetoCesar.Length); // Desplazamiento aleatorio entre 1 y la longitud del alfabeto

Console.WriteLine("Mensaje Original: " + mensaje);

// Cifrado
var textoCifrado = CifrarCesar(mensaje, desplazamiento);
Console.WriteLine("Mensaje Cifrado: " + textoCifrado);

// Descifrado (Desplazamiento negativo revierte la operación)
var textoDescifrado = CifrarCesar(textoCifrado, -desplazamiento);
Console.WriteLine("Mensaje Descifrado: " + textoDescifrado);

Console.WriteLine("👋 Presiona una tecla para salir...");
Console.ReadKey();
return;
// End Main Program

// Cifra un men usando el cifrado César con el desp dado
string CifrarCesar(string men, int desp) {
    // Usamos StringBuilder para la construcción eficiente de la cadena de salida
    var sb = new StringBuilder();
    var alphabetLength = AlfabetoCesar.Length;

    // Calcula el desp efectivo módulo de la longitud del alfabeto.
    // Esto asegura que un desp grande (ej. 1000) se reduce al rango [0, length-1].
    // En C#, el operador % es el operador "resto" (remainder), que puede dar negativo.
    var desplazamientoEfectivo = desp % alphabetLength;

    // Iteramos sobre cada carácter del men
    foreach (var caracter in men) {
        // Buscamos la posición del carácter en el alfabeto
        // Necesitamos convertir el char a string para el método IndexOf de string
        var posicion = AlfabetoCesar.IndexOf(caracter);

        if (posicion == -1) {
            // Si el carácter no está en el alfabeto, se añade directamente, pues no hay cifrado posible
            sb.Append(caracter);
        }
        else {
            // Calcula la nueva posición
            var nuevaPosicion = posicion + desplazamientoEfectivo;

            // Que hace el código a continuación:
            // - Si la nueva posición es negativa, se ajusta sumando la longitud del alfabeto
            // - Si la nueva posición es positiva, se aplica el módulo para envolver alrededor del alfabeto
            if (nuevaPosicion < 0)
                // Caso de desp negativo: Si la posición es negativa, 
                // se enrolla añadiendo la longitud del alfabeto.
                sb.Append(AlfabetoCesar[AlfabetoCesar.Length + nuevaPosicion]);
            else
                // Caso de desp positivo: Se aplica el módulo 
                // para volver al inicio si se pasa del final.
                sb.Append(AlfabetoCesar[nuevaPosicion % AlfabetoCesar.Length]);
        }
    }

    return sb.ToString();
}