// Main entry point 
// Poder escribir Emojis en la consola

using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine("Hola 2º DAW! 😀🚀");


// Por argumentos, que es args
if (args.Length > 0) {
    Console.WriteLine($"Has ingresado {args.Length} argumentos:");
    foreach (var arg in args) {
        Console.WriteLine(arg);
    }
} else {
    Console.WriteLine("No has ingresado argumentos.");
}

if (args.Length == 1) {
    if (int.TryParse(args[0], out var numeroArg)) {
        if (IsPrime(numeroArg)) {
            Console.WriteLine($"✅  El número pasado por argumento, {numeroArg},  es primo.");
        } else {
            Console.WriteLine($"❌  El número pasado por argumento, {numeroArg},  no es primo.");
        }
    } else {
        Console.WriteLine("❌  Error: El argumento debe ser un número entero.");
    }
}

// Pedir al usuario que ingrese un número entero positivo
var numero = LeerEnteroPositivo("Por favor, ingresa un número entero positivo: ");
if (IsPrime(numero)) {
    Console.WriteLine($"✅  El número {numero} es primo.");
} else {
    Console.WriteLine($"❌  El número {numero} no es primo.");
}

var limite = LeerEnteroPositivo("Por favor, ingresa el límite superior para listar números primos: ");
ImprimirPrimosHasta(limite);

// Verificar si dos números son primos gemelos
var num1 = LeerEnteroPositivo("Por favor, ingresa el primer número para verificar primos gemelos: ");
var num2 = LeerEnteroPositivo("Por favor, ingresa el segundo número para verificar primos gemelos: ");
if (PrimosGemelos(num1, num2)) {
    Console.WriteLine($"✅  Los números {num1} y {num2} son primos gemelos.");
} else {
    Console.WriteLine($"❌  Los números {num1} y {num2} no son primos gemelos.");
}

// Ver todos los pares de primos gemelos hasta un límite
limite = LeerEnteroPositivo("Por favor, ingresa el límite superior para listar primos gemelos: ");
ImprimirPrimosGemelosHasta(limite);




// Pausa para ver el resultado
Console.WriteLine("👋 Presiona una tecla para salir...");
Console.ReadKey();
return;
// End of Main entry point

bool IsPrime(int number) {
    if (number <= 1) return false;
    // Si es dos es primo
    if (number == 2) return true;
    // Si es par no es primo
    if (number % 2 == 0) return false;
    // Comprobar divisores impares desde 3 hasta la raíz cuadrada del número
    for (var i = 3; i * i <= number; i += 2) {
        if (number % i == 0) return false;
    }
    return true;
}

int LeerEnteroPositivo(string mensaje) {
    int valor;
    while (true) {
        Console.Write(mensaje);
        var entrada = Console.ReadLine()?.Trim();
        if (int.TryParse(entrada, out valor) && valor >= 0) {
            return valor;
        }
        Console.WriteLine("❌  Error: Debes ingresar un número entero positivo.");
    }
}

void ImprimirPrimosHasta(int limite) {
    Console.WriteLine($"Números primos hasta {limite}:");
    for (var i = 2; i <= limite; i++) {
        if (IsPrime(i)) {
            Console.Write($"{i} ");
        }
    }
    Console.WriteLine();
}

bool PrimosGemelos(int num1, int num2) {
    return IsPrime(num1) && IsPrime(num2) && Math.Abs(num1 - num2) == 2;
}

void ImprimirPrimosGemelosHasta(int limite) {
    Console.WriteLine($"Números primos gemelos hasta {limite}:");
    for (var i = 2; i <= limite; i++) {
        if (IsPrime(i) && IsPrime(i + 2)) {
            Console.WriteLine($"({i}, {i + 2})");
        }
    }
}