// See htt

using System.Text;

const int TiempoEsperaSegundos = 2;
const double ProbabilidadFallo = 0.1;
const int TiempoSimulacionSegundos = 300;

Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine("🛩️ Piloto Automático Simulador v1.0");

var altitudInicial = 1000;
var velocidadInicial = 800;

var altitudObjetivo = LeerParametro("altitud objetivo", (int)(altitudInicial * 0.75), (int)(altitudInicial * 1.25));
var velocidadObjetivo =
    LeerParametro("velocidad objetivo", (int)(velocidadInicial * 0.85), (int)(velocidadInicial * 1.15));

var tiempoActual = 0;
var altitudActual = altitudInicial;
var velocidadActual = velocidadInicial;
do {
    Console.WriteLine($"⏱️ Tiempo: {tiempoActual} segundos");
    // Comprobamos si hay fallo en el sistema
    try {
        ComprobarFallo();
    }
    catch (SystemException) {
        Console.WriteLine("⚠️ Piloto automático ha fallado. Terminando simulación.");
        break;
    }

    // Leemos los valores actuales con cierta variabilidad
    Console.WriteLine("🔄 Leyendo datos actuales...");
    altitudActual = Altitud(altitudActual);
    Velocidad(ref velocidadActual);

    // Comparamos con los objetivos y ajustamos si es necesario
    if (altitudActual < altitudObjetivo) {
        altitudActual = AumentarAltitud(altitudActual);
        Console.WriteLine($"⬆️ Altitud aumentada a {altitudActual} metros.");
    }
    else if (altitudActual > altitudObjetivo) {
        altitudActual = DisminuirAltitud(altitudActual);
        Console.WriteLine($"⬇️ Altitud disminuida a {altitudActual} metros.");
    }
    else {
        Console.WriteLine($"✅ Altitud mantenida en {altitudActual} metros.");
    }

    if (velocidadActual < velocidadObjetivo) {
        AumentarVelocidad(ref velocidadActual);
        Console.WriteLine($"➡️ Velocidad aumentada a {velocidadActual} km/h.");
    }
    else if (velocidadActual > velocidadObjetivo) {
        DisminuirVelocidad(ref velocidadActual);
        Console.WriteLine($"⬅️ Velocidad disminuida a {velocidadActual} km/h.");
    }
    else {
        Console.WriteLine($"✅ Velocidad mantenida en {velocidadActual} km/h.");
    }

    // Esperamos antes de la siguiente iteración
    Espera();
    // Actualizamos el tiempo de simulación
    tiempoActual += TiempoEsperaSegundos;
} while (tiempoActual < TiempoSimulacionSegundos);

Console.WriteLine("✈️ Simulación de piloto automático finalizada.");
Console.WriteLine("👋 Presiona una tecla para salir...");
Console.ReadKey();
return;

int Altitud(int altitudActual) {
    var random = new Random();
    var cambio = random.Next(-2, 3);
    return altitudActual + cambio;
}

void Velocidad(ref int velocidAdactual) {
    var random = new Random();
    var cambio = random.Next(-10, 11);
    velocidAdactual += cambio;
}

int AumentarAltitud(int altitudActual, int incremento = 1) {
    return altitudActual + incremento;
}

int DisminuirAltitud(int altitudActual, int decremento = 1) {
    return altitudActual - decremento;
}

void AumentarVelocidad(ref int velocidadActual, int incremento = 1) {
    velocidadActual += incremento;
}

void DisminuirVelocidad(ref int velocidadActual, int decremento = 1) {
    velocidadActual -= decremento;
}

void Espera(int segundos = TiempoEsperaSegundos) {
    Thread.Sleep(segundos * 1000);
}

void ComprobarFallo(double probabilidadFallo = ProbabilidadFallo) {
    var random = new Random();
    if (random.NextDouble() < probabilidadFallo)
        throw new SystemException("💥 Fallo en el sistema del piloto automático!");
}

int LeerParametro(string nombreParametro, int limiteInferior, int limiteSuperior) {
    var isOk = false;
    var valor = 0;
    do {
        Console.Write($"Ingrese el valor para {nombreParametro}: ");
        var entrada = Console.ReadLine()?.Trim() ?? "";
        if (int.TryParse(entrada, out valor) && valor >= limiteInferior && valor <= limiteSuperior)
            isOk = true;
        else
            Console.WriteLine(
                $"⚠️ Valor inválido. Por favor, ingrese un número entre {limiteInferior} y {limiteSuperior}.");
    } while (!isOk);

    return valor;
}