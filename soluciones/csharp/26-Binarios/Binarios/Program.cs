using System.Text.RegularExpressions;

// Necesario si queremos usar Regex para isBinary

Console.WriteLine("Hola C# DAW - Binarios");
Console.WriteLine("Trabajando con Binarios");

// Usamos la clase estática para las funciones auxiliares
// Leemos un número binario y lo transformamos en array de enteros de 1 y 0
var binary = ReadBinary();
PrintBinary(binary);

// Pasamos a decimal
var dec = BinaryToDecimal(binary);
Console.WriteLine($"Decimal: {dec}");

var num1 = new[] { 1, 1 };
var num2 = new[] { 1, 1 };

// Vamos a sumar
Console.Write("primero: ");
PrintBinary(num1);
Console.Write("segundo: ");
PrintBinary(num2);

// Suma
Console.Write("Suma: ");
var sum = Add(num1, num2);
PrintBinary(sum);

// Resta
var sub = Subtract(num2, num1);
Console.Write("Resta: ");
PrintBinary(sub);


// --- Librería de Datos para trabajar con Binarios ---

/*
 * Lee un número binario desde la consola
 */
int[] ReadBinary() {
    string? line;
    // Leemos un número y solo debe tener 0s y 1s
    do {
        Console.WriteLine("Introduzca el número binario: ");
        line = Console.ReadLine(); // Lee de la consola
    } while (string.IsNullOrEmpty(line) || !IsBinary(line));

    // Ahora los transformamos a array de enteros
    return ToIntVector(line);
}

/*
 * Transforma una cadena de 1 y 0 en un array de enteros de 1 y 0
 */
int[] ToIntVector(string line) {
    var res = new int[line.Length];
    for (var i = 0; i < line.Length; i++)
        // Parseamos directamente el carácter. C# puede hacerlo directamente.
        res[i] = int.Parse(line[i].ToString());
    return res;
}

/*
 * Comprueba si una cadena es un número binario, es decir solo tiene 1s y 0s
 */
bool IsBinary(string line) {
    // El enfoque más sencillo en C# (y eficiente para este caso) es usar Regex.
    // Opcionalmente, se podría usar Linq: return line.All(c => c == '0' || c == '1');
    return Regex.IsMatch(line, "^[01]+$");
}

/*
 * Imprime un array binario
 */
void PrintBinary(int[] numero) {
    foreach (var i in numero) Console.Write(i);
    Console.WriteLine();
}

/*
 * Transforma un array de binarios en un entero
 */
int BinaryToDecimal(int[] num) {
    var res = 0;
    // Iterar al revés es más fácil con un for tradicional o una copia/reverso
    for (var i = 0; i < num.Length; i++) {
        // (num.Length - 1 - i) es la posición del bit, siendo 0 el bit menos significativo
        // Math.Pow(2, exponente) es el equivalente a 2.0.pow(exponente)
        var bitPosition = num.Length - 1 - i;
        res += num[i] * (int)Math.Pow(2, bitPosition);
    }

    return res;
}

/*
 * Redimensiona un array, añadiendo ceros al inicio (padding)
 */
int[] Resize(int[] num, int max) {
    var res = new int[max];
    // Colocamos los dígitos existentes de atrás hacia adelante
    var offset = max - num.Length;
    for (var i = 0; i < num.Length; i++) res[offset + i] = num[i];
    // Los 0s iniciales se quedan por defecto
    return res;
}

/*
 * Suma dos arrays binarios
 */
int[] Add(int[] primero, int[] segundo) {
    // Se crean copias para poder redimensionar sin afectar los arrays originales pasados
    var n1 = (int[])primero.Clone();
    var n2 = (int[])segundo.Clone();

    var max = Math.Max(n1.Length, n2.Length);

    // Ajustar tamaños, si es necesario, usando las copias
    if (n1.Length < n2.Length)
        n1 = Resize(n1, max);
    else 
        n2 = Resize(n2, max);

    // El resultado es uno más para el acarreo
    var res = new int[max + 1];
    var carry = 0;

    // Iteramos de atrás hacia adelante (de derecha a izquierda)
    for (var i = max - 1; i >= 0; i--) {
        var suma = n1[i] + n2[i] + carry;
        carry = suma > 1 ? 1 : 0;
        res[i + 1] = suma % 2; // El resultado se almacena una posición más adelante
    }

    // Si hay acarreo final, se guarda en la posición 0
    if (carry == 1)
        res[0] = 1;
    return res;
}

/*
 * Resta dos arrays binarios (primero - segundo)
 */
int[] Subtract(int[] primero, int[] segundo) {
    // Se crean copias para poder redimensionar sin afectar los arrays originales pasados
    var n1 = (int[])primero.Clone();
    var n2 = (int[])segundo.Clone();

    var max = Math.Max(n1.Length, n2.Length);

    // Ajustar tamaños, si es necesario, usando las copias
    if (n1.Length < n2.Length) n1 = Resize(n1, max);
    else n2 = Resize(n2, max);

    // El resultado tiene el tamaño del mayor
    var res = new int[max];
    var borrow = 0; // En la resta binaria es 'borrow' (préstamo) en lugar de 'carry' (acarreo)

    // Iteramos de atrás hacia adelante (de derecha a izquierda)
    for (var i = max - 1; i >= 0; i--) {
        // Resta con préstamo: bit1 - bit2 - préstamo_anterior
        var diff = n1[i] - n2[i] - borrow;

        // Si el resultado es negativo, significa que necesitamos un préstamo
        if (diff < 0) {
            // El préstamo se convierte en 1
            borrow = 1;
            // El resultado es (diff + 2) % 2, que es equivalente a |diff % 2| cuando diff es -1
            res[i] = Math.Abs(diff + 2) % 2;
        }
        else {
            // No hay préstamo
            borrow = 0;
            res[i] = diff;
        }
    }

    return res;
}