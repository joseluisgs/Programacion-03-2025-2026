using System.Text;
using System.Text.RegularExpressions;

// Constantes globales (permitidas)
const int TotalHomenajeDario = 18000; // Darío tenía 18000 hombres
const int TotalHomenajeAlejandro = 12000; // Alejandro tenía 12000 hombres

Console.OutputEncoding = Encoding.UTF8;
Console.Clear();

// Variables de estado del juego (ahora locales al Top-Level Statement)
var tropasDario = new int[3] { 0, 0, 0 };
var tropasAlejandro = new int[3] { 0, 0, 0 };
var hombresNoDistribuidos = TotalHomenajeDario;
var victoriasObtenidas = 0;

Console.WriteLine("=== ⚔️ La Batalla de Issos ❌ ===");

// --- 1. Pedir distribución de Darío ---
Console.WriteLine("\n--- Distribución de Darío (El observador informa 🕵️) ---");
for (var i = 0; i < 3; i++) {
    Console.WriteLine($"\nGrupo de Banderas {i + 1}/3:");
    Console.Write("Introduce las dos banderas (ej: 'ra', 'rv', etc.): ");
    var banderas = Console.ReadLine()?.ToLower()?.Trim() ?? "";

    // Llamada al módulo: se pasan por referencia o se devuelven los valores actualizados.
    // Usamos 'out' y el valor de retorno para actualizar las variables locales.
    hombresNoDistribuidos = CalcularDistribucionDario(banderas, tropasDario, hombresNoDistribuidos, out tropasDario);
}

Console.WriteLine(
    $"\nDarío ha distribuido {TotalHomenajeDario - hombresNoDistribuidos} hombres. Le quedan {hombresNoDistribuidos} por distribuir.");

// --- 2. Pedir distribución de Alejandro ---
Console.WriteLine("\n--- Distribución de Alejandro (Estrategia Griega 🇬🇷) ---");
// La función modifica el array tropasDeAlejandro que es un tipo referencia (puntero)
PedirDistribucionAlejandro(tropasAlejandro);

// --- 3. Mostrar Distribución de Darío y Alejandro ---
MostrarDistribucion(tropasDario, tropasAlejandro);

// --- 4. Comprobar Batalla en cada Flanco ---
Console.WriteLine("\n--- Luchando ---");
// Vectores para el estado final de las tropas y resultados
var tropasDarioFinal = new int[3];
var tropasAlejandroFinal = new int[3];
var victoriasAlejandro = new bool[3];

for (var i = 0; i < 3; i++) {
    // i = 0: Izquierdo, i = 1: Central, i = 2: Derecho
    // La función devuelve el número de victorias, y usa 'out' para devolver los arrays actualizados.
    victoriasObtenidas = CalcularBatalla(
        i,
        tropasAlejandro[i],
        tropasDario[i],
        victoriasObtenidas,
        out var tropasAlejandroFlancoFinal,
        out var tropasDarioFlancoFinal,
        out var flancoGanado
    );

    // Asignar los valores devueltos por 'out' a los arrays locales.
    tropasAlejandroFinal[i] = tropasAlejandroFlancoFinal;
    tropasDarioFinal[i] = tropasDarioFlancoFinal;
    victoriasAlejandro[i] = flancoGanado;
}

// --- 5. Mostrar Resultado y Ganador ---
MostrarResultadoBatalla(victoriasObtenidas, tropasAlejandroFinal, tropasDarioFinal);

Console.WriteLine("\n👋 Presiona una tecla para salir...");
Console.ReadKey();
return;


// ====================================================================================
// --- MÓDULOS (Funciones Locales) ---
// ====================================================================================

// Módulo 1: Calcula el flanco, la cantidad a mover y el restante de Darío.
int CalcularDistribucionDario(string banderas, int[] currentTropasDario, int currentHombresNoDistribuidos,
    out int[] updatedTropasDario) {
    // Crear una copia para evitar modificar el original directamente si el tipo es referencia (aunque aquí se hace por out)
    updatedTropasDario = (int[])currentTropasDario.Clone();

    if (banderas.Length != 2) {
        Console.WriteLine("⚠️ Formato de banderas incorrecto. Ignorando movimiento.");
        return currentHombresNoDistribuidos;
    }

    var bandera1 = banderas[0]; // División
    var bandera2 = banderas[1]; // Colocación

    var divisionHombres = 0;
    var indiceFlanco = -1; // 0=izquierdo, 1=central, 2=derecho

    // Calcular División de Hombres (Bandera 1)
    if (bandera1 == 'r') {
        divisionHombres = TotalHomenajeDario / 4; // Darío divide 1/4
    }
    else if (bandera1 == 'v') {
        divisionHombres = TotalHomenajeDario / 2; // Darío divide 1/2
    }
    else if (bandera1 == 'a') {
        divisionHombres = TotalHomenajeDario / 3; // Darío divide 1/3
    }
    else {
        Console.WriteLine($"⚠️ Color de Bandera 1 ('{bandera1}') no reconocido. Ignorando movimiento.");
        return currentHombresNoDistribuidos;
    }

    // Calcular Colocación (Bandera 2)
    if (bandera2 == 'a') {
        indiceFlanco = 0; // Izquierdo (i)
    }
    else if (bandera2 == 'v') {
        indiceFlanco = 1; // Central (c)
    }
    else if (bandera2 == 'r') {
        indiceFlanco = 2; // Derecho (d)
    }
    else {
        Console.WriteLine($"⚠️ Color de Bandera 2 ('{bandera2}') no reconocido. Ignorando movimiento.");
        return currentHombresNoDistribuidos;
    }

    // Aplicar la distribución si hay hombres disponibles
    if (currentHombresNoDistribuidos >= divisionHombres) {
        updatedTropasDario[indiceFlanco] += divisionHombres;
        currentHombresNoDistribuidos -= divisionHombres;
        Console.WriteLine(
            $"✅ Movimiento: {divisionHombres} hombres a {FlancoAString(indiceFlanco)}. Restan: {currentHombresNoDistribuidos}");
    }
    else {
        Console.WriteLine($"❌ No quedan suficientes hombres ({divisionHombres}) para distribuir.");
    }

    // Devuelve el nuevo resto de hombres no distribuidos
    return currentHombresNoDistribuidos;
}

// Módulo que pide la distribución de Alejandro por teclado.
void PedirDistribucionAlejandro(int[] tropasDeAlejandro) {
    var hombresRestantes = TotalHomenajeAlejandro;

    // Pedir Izquierdo (0)
    hombresRestantes = PedirFlanco(0, hombresRestantes, tropasDeAlejandro);

    // Pedir Derecho (2)
    hombresRestantes = PedirFlanco(2, hombresRestantes, tropasDeAlejandro);

    // El resto va al Central (1)
    tropasDeAlejandro[1] = hombresRestantes;
    Console.WriteLine($"\nEl resto ({hombresRestantes}) va al Flanco Central.");
}

// Módulo auxiliar para pedir y validar la distribución en un flanco.
int PedirFlanco(int indice, int maxHombres, int[] tropasDeAlejandro) {
    var flancoStr = FlancoAString(indice);
    int hombres;
    string input;

    // Uso de RegEx para asegurar que la entrada es un número positivo (simplificado a IsMatch)
    var patronRegEx = "^[0-9]+$";

    while (true) {
        Console.Write($"Distribución Flanco {flancoStr} (máx {maxHombres}): ");
        input = Console.ReadLine()?.Trim() ?? "";

        if (Regex.IsMatch(input, patronRegEx) && int.TryParse(input, out hombres)) {
            if (hombres >= 0 && hombres <= maxHombres) {
                // Actualiza el array pasado por parámetro
                tropasDeAlejandro[indice] = hombres;
                return maxHombres - hombres;
            }

            Console.WriteLine($"⚠️ Cantidad inválida. Debe ser entre 0 y {maxHombres}.");
        }
        else {
            Console.WriteLine("⚠️ Entrada no numérica válida.");
        }
    }
}

// Módulo 2: Calcula si hay victoria en un flanco y cuántos hombres quedan.
// Devuelve el nuevo contador de victorias.
int CalcularBatalla(
    int indiceFlanco,
    int tropasA,
    int tropasD,
    int currentVictoriasObtenidas,
    out int tropasAlejandroFlancoFinal,
    out int tropasDarioFlancoFinal,
    out bool flancoGanado
) {
    var flancoStr = FlancoAString(indiceFlanco);
    double porcentajePerdidaA;
    double porcentajePerdidaD;

    // Escenario 1: Alejandro supera o iguala al otro en un flanco
    if (tropasA >= tropasD) {
        // Alejandro pierde 30%, Darío pierde 60%. Probabilidad de victoria de Alejandro 70%
        porcentajePerdidaA = 0.30;
        porcentajePerdidaD = 0.60;
        flancoGanado = true; // Simulación: Si la victoria es al 70%, simulamos que gana.
    }
    // Escenario 2: Darío supera a Alejandro
    else {
        // Alejandro pierde 60%, Darío pierde 50%. Probabilidad de victoria de Alejandro 50%
        porcentajePerdidaA = 0.60;
        porcentajePerdidaD = 0.50;
        flancoGanado = false; // Simulación: Si la victoria es al 50%, simulamos que gana Darío (por simplicidad).
    }

    // Calcular las tropas que quedan y asignarlas a los parámetros 'out'
    tropasAlejandroFlancoFinal = (int)(tropasA * (1 - porcentajePerdidaA));
    tropasDarioFlancoFinal = (int)(tropasD * (1 - porcentajePerdidaD));

    if (flancoGanado) {
        Console.WriteLine($"   Se ha ganado el {flancoStr}.");
        return currentVictoriasObtenidas + 1;
    }

    Console.WriteLine($"   Se ha perdido el {flancoStr}.");
    return currentVictoriasObtenidas;
}

// Módulo para mostrar la distribución de tropas.
void MostrarDistribucion(int[] tropasDeDario, int[] tropasDeAlejandro) {
    Console.WriteLine("\nDistribución de Darío.");
    Console.WriteLine("---------------------");
    Console.WriteLine($"Flanco izdo:  {tropasDeDario[0]}");
    Console.WriteLine($"Flanco central: {tropasDeDario[1]}");
    Console.WriteLine($"Flanco dcho:  {tropasDeDario[2]}");

    Console.WriteLine("\nDistribución de Alejandro.");
    Console.WriteLine("--------------------------");
    Console.WriteLine($"Flanco izdo:  {tropasDeAlejandro[0]}");
    Console.WriteLine($"Flanco central: {tropasDeAlejandro[1]}");
    Console.WriteLine($"Flanco dcho:  {tropasDeAlejandro[2]}");
}

// Módulo para mostrar el resultado final de la batalla.
void MostrarResultadoBatalla(int victorias, int[] tropasDeAlejandroFinal, int[] tropasDeDarioFinal) {
    Console.WriteLine("\nQuién gana la batalla:");
    // La batalla se gana si se gana en dos flancos
    if (victorias >= 2)
        Console.WriteLine($"¡Victoria de Alejandro! (Ganó en {victorias} flancos).");
    else
        Console.WriteLine($"¡Victoria de Darío! (Alejandro solo ganó en {victorias} flanco(s)).");

    Console.WriteLine("\nEstado final de las tropas (Hombres que han quedado):");
    Console.WriteLine("-----------------------------------------------------");
    Console.WriteLine(
        $"Alejandro: {tropasDeAlejandroFinal[0]}, {tropasDeAlejandroFinal[1]}, {tropasDeAlejandroFinal[2]} (Izdo, Ctro, Dcho)");
    Console.WriteLine(
        $"Darío:     {tropasDeDarioFinal[0]}, {tropasDeDarioFinal[1]}, {tropasDeDarioFinal[2]} (Izdo, Ctro, Dcho)");
}

// Módulo auxiliar para convertir el índice del vector a una cadena legible.
string FlancoAString(int indice) {
    return indice switch {
        0 => "izdo",
        1 => "central",
        2 => "dcho",
        _ => "desconocido"
    };
}