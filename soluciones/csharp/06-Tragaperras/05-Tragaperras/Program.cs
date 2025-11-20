using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using _05_Tragaperras;

// Constantes globales
const double ApuestaMinima = 0.01;
const int JackpotNum = 7;

const int PremioJackpotMult = 10;
const int PremioTresIgualesMult = 3;
const double PremioDosIgualesMult = 1.5;

const int OpcionMenuTirar = 1;
const int OpcionMenuGestionar = 2;
const int OpcionMenuPremios = 3;
const int OpcionMenuSalir = 4;

const int OpcionGestionAnadir = 1;
const int OpcionGestionRetirar = 2;
const int OpcionGestionVolver = 3;

// Main Program
Console.OutputEncoding = Encoding.UTF8;

double saldo;
bool isSaldoValido;

Console.WriteLine("🎰 Bienvenido a la Máquina Tragaperras");

do {
    Console.WriteLine("----------------------");
    saldo = LeerDouble("Indique el saldo inicial para comenzar a jugar (mínimo 0.01€): ");

    isSaldoValido = IsSuperiorA(saldo, 0.0);
    if (!isSaldoValido)
        Console.WriteLine("❌ Error. La cantidad debe ser superior a 0.00€.");
} while (!isSaldoValido);

EjecutarMenu(ref saldo);

Console.WriteLine("Ha sido un placer, ¡vuelve pronto! 😉");
Console.WriteLine("👋 Presiona una tecla para salir...");
Console.ReadKey();
return;

// End Main Program

// Otras funciones

// Lee un entero desde consola con validación mediante regex
int LeerEntero(string mensaje) {
    var valorLeido = 0;
    var formatoCorrecto = false;
    var regex = new Regex(@"^\d+$");

    do {
        Console.Write(mensaje);
        var input = Console.ReadLine()?.Trim() ?? "";

        if (regex.IsMatch(input)) {
            valorLeido = int.Parse(input);
            formatoCorrecto = true;
        }
        else {
            Console.WriteLine("❌ Error. Debe introducir un número entero.");
        }
    } while (!formatoCorrecto);

    return valorLeido;
}

// Lee un double desde consola con validación
double LeerDouble(string mensaje) {
    var valorLeido = 0.0;
    var formatoCorrecto = false;

    do {
        Console.Write(mensaje);
        var input = Console.ReadLine()?.Trim() ?? "";
        // Le añado esto para que se trague tanto el punto como la coma como separador decimal
        // Es un truco rápido para evitar problemas de localización
        if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out valorLeido) && valorLeido >= 1.0)
            formatoCorrecto = true;
        else
            Console.WriteLine("❌ Error. La entrada debe ser como minimo 1,0€ (ej: 10,00€)");
    } while (!formatoCorrecto);

    return valorLeido;
}

// Comprueba si un número es superior a un umbral
bool IsSuperiorA(double num, double umbral) {
    return num > umbral;
}

// Ejecuta el menú principal
void EjecutarMenu(ref double saldo) {
    int opcionElegida;

    do {
        Console.WriteLine("----------------------");
        // Podemos imprimir el saldo con dos decimales y el símbolo del euro
        // Console.WriteLine($"Saldo actual: {saldo:F2} €");
        // O imprimirlo como moneda local (usando el formato C2, redondeado a 2 decimales y con el símbolo)
        Console.WriteLine($"Saldo actual: {saldo:C2}");
        Console.WriteLine($"{OpcionMenuTirar}.- Tirar");
        Console.WriteLine($"{OpcionMenuGestionar}.- Gestionar saldo");
        Console.WriteLine($"{OpcionMenuPremios}.- Ver premios");
        Console.WriteLine($"{OpcionMenuSalir}.- Salir");

        opcionElegida = LeerEntero("Opción = ");

        switch (opcionElegida) {
            case OpcionMenuTirar: TirarTragaperras(ref saldo); break;
            case OpcionMenuGestionar: GestionarSaldo(ref saldo); break;
            case OpcionMenuPremios: ImprimirListaPremios(); break;
            case OpcionMenuSalir: Console.WriteLine("Saliendo..."); break;
            default: Console.WriteLine("⚠️ Opción no válida."); break;
        }

        if (saldo <= 0.0 && opcionElegida != OpcionMenuSalir) {
            Console.WriteLine("Te has quedado sin saldo. Debes recargar.");
            GestionarSaldo(ref saldo);
            if (saldo <= 0.0) opcionElegida = OpcionMenuSalir;
        }
    } while (opcionElegida != OpcionMenuSalir);
}

// Tira la tragaperras
void TirarTragaperras(ref double saldo) {
    double saldoApostado;
    bool valido;
    var random = new Random();

    do {
        Console.WriteLine("----------------------");
        Console.WriteLine($"Saldo actual: {saldo:C2}");

        saldoApostado = LeerDouble("Apuesta: ");
        valido = saldoApostado >= ApuestaMinima && saldoApostado <= saldo;

        if (!valido)
            Console.WriteLine("❌ Apuesta inválida.");
    } while (!valido);

    saldo -= saldoApostado;

    var resultado = new Tirada {
        N1 = random.Next(0, 10),
        N2 = random.Next(0, 10),
        N3 = random.Next(0, 10)
    };

    Console.WriteLine($"Resultado: {resultado.N1} {resultado.N2} {resultado.N3}");

    var premio = CalcularPremio(resultado, saldoApostado);
    saldo += premio;
    Console.WriteLine($"Saldo actual: {saldo:F2}€");
}

// Calcula el premio según el resultado de la tirada
double CalcularPremio(Tirada tirada, double apuesta) {
    if (tirada.N1 == JackpotNum && tirada.N2 == JackpotNum && tirada.N3 == JackpotNum) return apuesta * PremioJackpotMult;
    if (tirada.N1 == tirada.N2 && tirada.N2 == tirada.N3) return apuesta * PremioTresIgualesMult;
    if (tirada.N1 == tirada.N2 || tirada.N1 == tirada.N3 || tirada.N2 == tirada.N3)
        return apuesta * PremioDosIgualesMult;
    
    return 0.0;
}

// Añade saldo
void AnadirSaldo(ref double saldo) {
    var monto = LeerDouble("Añadir: ");
    if (monto > 0) saldo += monto;
}

// Retira saldo
void RetirarSaldo(ref double saldo) {
    var monto = LeerDouble("Retirar: ");
    if (monto > 0 && monto <= saldo) saldo -= monto;
}

// Gestiona el saldo (añadir o retirar)
void GestionarSaldo(ref double saldo) {
    Console.WriteLine($"{OpcionGestionAnadir} Añadir");
    Console.WriteLine($"{OpcionGestionRetirar} Retirar");
    Console.WriteLine($"{OpcionGestionVolver} Volver");

    var opcionElegida = LeerEntero("Opción = ");

    switch (opcionElegida) {
        case OpcionGestionAnadir: AnadirSaldo(ref saldo); break;
        case OpcionGestionRetirar: RetirarSaldo(ref saldo); break;
    }
}

// Imprime la lista de premios
void ImprimirListaPremios() {
    Console.WriteLine("🏆 Premios:");
    Console.WriteLine($"Jackpot ({JackpotNum}{JackpotNum}{JackpotNum}): x{PremioJackpotMult}");
    Console.WriteLine($"Tres iguales: x{PremioTresIgualesMult}");
    Console.WriteLine($"Dos iguales: x{PremioDosIgualesMult}");
}