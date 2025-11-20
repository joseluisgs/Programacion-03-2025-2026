using System.Text;
using System.Text.RegularExpressions;
using _12_MoscaMatriz.Enums;
using _12_MoscaMatriz.Structs;

// ----------------------------------------------------
// CONSTANTES GLOBALES
// ----------------------------------------------------

// Constantes para las condiciones de inicio del juego
const int TamDefault = 8; // Tamaño predeterminado de la matriz: 8x8
const int NumIntentosDefault = 5; // Número de oportunidades para cazar la mosca

// Creamos una instancia de Random global. Esto es crucial para generar números aleatorios
// de forma correcta, evitando que se repitan en sorteos sucesivos rápidos.
var random = new Random();

// Main program
Console.OutputEncoding = Encoding.UTF8;
Console.Clear();


// ----------------------------------------------------
// BLOQUE PRINCIPAL (Top-Level Statements)
// ----------------------------------------------------

// **INICIO DEL PROGRAMA PRINCIPAL**

// 0. Limpieza de la consola al iniciar
Console.Clear();

// 0.1. Validación de la entrada del tamaño de la matriz y el número de intentos por argumentos
var configuracion = ValidarArgumentosEntrada(args);

// 1. Presentación del juego
Console.WriteLine("=============================================");
Console.WriteLine("    🎮 INICIANDO JUEGO CAZAR LA MOSCA 🪰    ");
Console.WriteLine("=============================================");
Console.WriteLine("Parámetros del juego:");
Console.WriteLine($"\t- Tamaño de la matriz: {configuracion.Tamaño}x{configuracion.Tamaño}");
Console.WriteLine($"\t- Número de intentos: {configuracion.Vidas}");
Console.WriteLine();

// 2. Creación de la matriz
// Se utiliza un array bidimensional (int[,]), la representación estándar en C#.
// se inicializa más adelante en el código.
var matriz = new Celda[configuracion.Tamaño, configuracion.Tamaño];

// 3. Ejecución del juego
// Los arrays se pasan por referencia implícita en C#, lo que permite modificar 'matriz'
// dentro de la función 'JugarCazarMosca'.
var result = JugarCazarMosca(matriz, configuracion.Vidas);

// 4. Mostrar el resultado final
if (result) {
    Console.WriteLine("=============================================");
    Console.WriteLine("✅ ¡HAS GANADO! Has cazado la mosca.");
    Console.WriteLine("=============================================");
}
else {
    Console.WriteLine("=============================================");
    Console.WriteLine("❌ ¡HAS PERDIDO! Se agotaron los intentos.");
    Console.WriteLine("=============================================");
}

// 5. Imprimir la matriz final para que el jugador vea dónde estaba la mosca
Console.WriteLine("\n--- Posición Final de la Mosca ---");
ImprimirMatriz(matriz);

Console.WriteLine("👋 Presiona una tecla para salir...");
Console.ReadKey();
return;
// End of main program

// ----------------------------------------------------
// FUNCIONES Y PROCEDIMIENTOS AUXILIARES
// ----------------------------------------------------

// Valida los argumentos de entrada del programa (tamaño y número de intentos).
// Parámetros:
// - args: Array de strings con los argumentos de entrada.
// Devuelve: Una estructura Configuracion con los valores validados o por defecto.
Configuracion ValidarArgumentosEntrada(string[] args) {
    // Analizamos que los argumentos siguen este formato: vidas:X tam:Y
    // Analizamos si vienen dos argumentos
    if (args.Length != 2) {
        Console.WriteLine("❌ Error: Debe ingresar dos argumentos: vidas:X tam:Y");
        return PedirConfiguracion();
    }

    // Analizamos los argumentos de entrada
    // Primero vidas:X
    var vidas = args[0].Split(':');
    if (vidas.Length != 2 || !int.TryParse(vidas[1], out var vidasParsed) || vidasParsed <= 0 ||
        vidasParsed > NumIntentosDefault) {
        Console.WriteLine(
            $"❌ Error: El argumento '{args[0]}' no es válido. Debe ser vidas:X, donde X es un entero entre 1 y {NumIntentosDefault}.");
        return PedirConfiguracion();
    }

    // Luego tam:Y
    var tam = args[1].Split(':');
    if (tam.Length != 2 || !int.TryParse(tam[1], out var tamParsed) || tamParsed <= 0 || tamParsed > TamDefault) {
        Console.WriteLine(
            $"❌ Error: El argumento '{args[1]}' no es válido. Debe ser tam:Y, donde Y es un entero entre 1 y {TamDefault}.");
        return PedirConfiguracion();
    }

    // Si todo es correcto, asignamos los valores
    return new Configuracion {
        Vidas = vidasParsed,
        Tamaño = tamParsed
    };
}

// Pide al usuario la configuración del juego (vidas y tamaño) si los argumentos de entrada son inválidos.
// Devuelve: Una estructura Configuracion con los valores ingresados por el usuario
Configuracion PedirConfiguracion() {
    Console.WriteLine("--- Configuración del Juego ---");
    Console.WriteLine(
        $"Por favor ingrese los parametros vidas y tamaño, de la siguiente forma: vidas:[1-{NumIntentosDefault}] tam:[1-{TamDefault}]");

    var regex = new Regex($@"^vidas:([1-{NumIntentosDefault}])\s+tam:([1-{TamDefault}])$");

    var input = (Console.ReadLine() ?? "").Trim();
    while (!regex.IsMatch(input)) {
        Console.WriteLine(
            $"❌ Error: Entrada inválida. Inténtalo de nuevo. Formato correcto: vidas:[1-{NumIntentosDefault}] tam:[1-{TamDefault}]");
        input = (Console.ReadLine() ?? "").Trim();
    }

    var match = regex.Match(input);
    var vidas = int.Parse(match.Groups[1].Value);
    var tamaño = int.Parse(match.Groups[2].Value);

    return new Configuracion {
        Vidas = vidas,
        Tamaño = tamaño
    };
}


// Implementa la lógica principal del juego: bucle de intentos, pedir posición y analizar golpeo.
// Parámetros:
// - matriz: La matriz de juego (se modifica por referencia implícita).
// - numIntentos: Número máximo de intentos.
// - random: Instancia para generar números aleatorios.
// Devuelve: True si la mosca fue cazada, False en caso contrario.
bool JugarCazarMosca(Celda[,] matriz, int numIntentos) {
    var intentos = 0;
    var moscaMuerta = false;

    // Sorteamos la posición inicial de la mosca
    SortearPosicionMosca(matriz);

    // Bucle principal: se repite mientras la mosca no esté muerta Y queden intentos
    do {
        intentos++;
        Console.WriteLine($"\n--- INTENTO {intentos} de {numIntentos} ---");

        // Pedimos la posición. GetLength(0) devuelve el número de filas (el tamaño).
        var posicion = PedirPosicionValida(matriz.GetLength(0));

        // Analizamos el resultado del golpeo
        var resultado = AnalizarGolpeo(matriz, posicion);

        // Usamos switch para gestionar el flujo de juego según el resultado
        switch (resultado) {
            case Golpeo.Acertado:
                Console.WriteLine($"✅ ☠️ ¡TE LA HAS CARGADO! Has acertado en el intento {intentos}.");
                // Al acertar, limpiamos la celda. Usamos (int) para obtener el valor 0 de Vacio.
                matriz[posicion.Fila, posicion.Columna] = Celda.Vacio;
                moscaMuerta = true;
                break;

            case Golpeo.Casi:
                // ¡CASI! La mosca está en un lugar adyacente y se mueve.
                Console.WriteLine($"💨 ¡CASI! Has estado cerca en el intento {intentos}.");
                Console.WriteLine("🪰 ¡La mosca revolotea y CAMBIA de posición!");
                // 1. Limpiamos la posición anterior (la mosca se va).
                LimpiarMatriz(matriz);
                // 2. Sorteamos una nueva posición.
                SortearPosicionMosca(matriz);
                break;

            case Golpeo.Fallado:
                Console.WriteLine($"❌ Has fallado en el intento {intentos}.");
                break;
        }
    } while (!moscaMuerta && intentos < numIntentos);

    return moscaMuerta;
}

// Analiza si la posición dada es la mosca, adyacente a la mosca o está lejos.
// Parámetros:
// - matriz: Matriz de enteros del juego.
// - posicion: Posición (0-indexada) a analizar.
// Devuelve: Un valor de la enumeración Golpeo.
Golpeo AnalizarGolpeo(Celda[,] matriz, Posicion posicion) {
    // Obtenemos las dimensiones de la matriz
    var filas = matriz.GetLength(0);
    var columnas = matriz.GetLength(1);

    // 1. ACERTADO: Comprobación directa.
    // Comparamos el valor entero de la celda con el valor entero del enum (Celda.Mosca).
    if (matriz[posicion.Fila, posicion.Columna] == Celda.Mosca)
        return Golpeo.Acertado;

    // 2. CASI: Comprobación adyacente (vecindario 3x3).
    // Los bucles de -1 a 1 permiten iterar sobre todas las casillas adyacentes.
    for (var i = -1; i <= 1; i++) {
        for (var j = -1; j <= 1; j++) {
            // Omitimos el centro (i=0, j=0) porque ya se comprobó arriba
            if (i == 0 && j == 0) continue;

            var nuevaPosicion = new Posicion {
                Fila = posicion.Fila + i,
                Columna = posicion.Columna + j
            };

            // Verificamos que la nueva posición no esté fuera de los límites de la matriz (0 a size-1)
            if (nuevaPosicion.Fila >= 0 && nuevaPosicion.Fila < filas &&
                nuevaPosicion.Columna >= 0 && nuevaPosicion.Columna < columnas)
                // Si la mosca está en alguna de las casillas adyacentes, devolvemos CASI.
                if (matriz[nuevaPosicion.Fila, nuevaPosicion.Columna] == Celda.Mosca)
                    return Golpeo.Casi;
        }
    }

    // 3. FALLADO: Si no se encontró en el punto ni adyacente.
    return Golpeo.Fallado;
}

// Pide una posición al usuario (formato Fila:Columna, 1-indexada), la valida y devuelve la posición 0-indexada.
// Parámetros:
// - size: Tamaño de la matriz (asumida cuadrada).
// Devuelve: La estructura Posicion (0-indexada) válida.
Posicion PedirPosicionValida(int size) {
    var inputIsOk = false;
    // Creamos la instancia de Regex a partir de nuestra constante RegexPosicion

    // La expresión regular para validar la posición. Formato esperado: "F:C" (ej. 3:5).
    // OPCIÓN 1 (ACTUAL): Solo valida el formato. Los números se extraen luego con Split(':').
    var regexPosicion = new Regex($@"^([1-{size}]):([1-{size}])$");

    // OPCIÓN 2 (ALTERNATIVO): Usa grupos de captura (y requiere 9x9):
    // string REGEX_POSICION = @"^([1-"+ size +"]):([1-"+ size +"])$";
    //Con esta opción, se pueden extraer los números directamente de los grupos capturados.
    // El uso de grupos facilitaría la extracción de los números sin usar Split, accediendo a:
    // match.Groups[1].Value (Fila) y match.Groups[2].Value (Columna)
    // OPCION 3, usar un alias para el regex:
    // const string REGEX_POSICION = @"^(?<fila>[1-"+ size +"]):(?<columna>[1-"+ size +"])$";
    // Y luego acceder a match.Groups["fila"].Value y match.Groups["columna"].Value

    var input = "";
    var posicion = new Posicion();

    do {
        Console.Write("Introduce una posición válida como fila:columna (ej. 3:5): ");
        // Leemos la entrada y quitamos espacios en blanco
        input = Console.ReadLine()?.Trim() ?? "";

        // Intentamos casar la entrada con el patrón. Si es válido, inputRegex.IsMatch(input) es true.
        if (regexPosicion.IsMatch(input)) {
            // --- MÉTODO DE EXTRACCIÓN 1 (Usando Split, el método actual y más simple) ---
            // La Regex ya asegura que hay dos números separados por ':'
            var partes = input.Split(':');

            // Convertimos las partes a enteros de forma segura
            if (int.TryParse(partes[0], out var fila) && int.TryParse(partes[1], out var columna)) {
                // Convertimos el valor (1-indexado por el usuario) a 0-indexado para la matriz
                posicion.Fila = fila - 1;
                posicion.Columna = columna - 1;
                inputIsOk = true;
            }

            // --- MÉTODO DE EXTRACCIÓN 2 (Usando Grupos de Captura) ---
            // NOTA: Para usar este método, la constante REGEX_POSICION debería ser: @"^([1-8]):([1-8])$"
            /*
            Match match = inputRegex.Match(input);
            if (match.Success)
            {
                // Los grupos se capturan. Group[1] es el primer grupo '([1-8])', Group[2] el segundo.
                if (int.TryParse(match.Groups[1].Value, out int fila) && int.TryParse(match.Groups[2].Value, out int columna))
                {
                    posicion.Fila = fila - 1;
                    posicion.Columna = columna - 1;
                    inputIsOk = true;
                }
            }

            // --- MÉTODO DE EXTRACCIÓN 3 (Usando Named Groups) ---
            // NOTA: Para usar este método, la constante REGEX_POSICION debería ser: @"^(?<fila>[1-8]):(?<columna>[1-8])$"

            Match match = inputRegex.Match(input);
            if (match.Success)
            {
                // Los grupos con nombre se capturan. Usamos los nombres 'fila' y 'columna'.
                if (int.TryParse(match.Groups["fila"].Value, out int fila) && int.TryParse(match.Groups["columna"].Value, out int columna))
                {                    posicion.Fila = fila - 1;
                    posicion.Columna = columna - 1;
                    inputIsOk = true;   }
                    }
            */
        }

        if (!inputIsOk)
            Console.WriteLine($"❌ La posición no es válida. Inténtalo de nuevo con valores entre 1 y {size}.");
    } while (!inputIsOk);

    return posicion;
}


// Imprime la matriz de juego con un formato bien alineado y usando emojis para una mejor experiencia.
// Se usa string.Format para garantizar el padding.
// Parámetros:
// - matriz: Matriz de enteros a imprimir.
void ImprimirMatriz(Celda[,] matriz) {
    var size = matriz.GetLength(0);

    Console.Write("  "); // Espacio inicial para alinear con los números de fila
    for (var col = 1; col <= size; col++)
        // {0,5} garantiza que el número de columna ocupe 5 espacios
        // 0, es el argumento (col), 5 es el ancho total
        Console.Write("{0,5}", col);
    Console.WriteLine();

    // Línea separadora superior
    Console.Write("   +");

    // Mejor que el for
    Console.WriteLine(new string('-', size * 5 + 2) + "+");

    /*for (var i = 0; i < size; i++)
        Console.Write("-----"); // 5 guiones para cada celda
    Console.WriteLine("-+");*/

    // Recorremos e imprimimos filas
    for (var i = 0; i < size; i++) {
        // Número de fila (1-indexado), alineado a la derecha en 2 espacios + el separador " |" (Total 4 caracteres)
        Console.Write("{0,2} |", i + 1);

        for (var j = 0; j < size; j++) {
            string celdaContenido;
            // Comprobamos si el valor almacenado es el valor numérico del enum Mosca
            if (matriz[i, j] == Celda.Mosca)
                celdaContenido = " 🪰 "; // 3 espacios
            else
                celdaContenido = "   "; // 3 espacios

            // {0,5} de la columna: [ + celdaContenido(3) + ] = 5 espacios
            Console.Write("{0,5}", $"[{celdaContenido}]");
        }

        Console.WriteLine(" |"); // Cierre de la fila
    }

    // Línea separadora inferior
    Console.Write("   +");
    Console.WriteLine(new string('-', size * 5 + 2) + "+");
    Console.WriteLine();
}


// Sortea y establece la posición de la mosca en la matriz.
// Este procedimiento garantiza que solo haya una mosca por turno.
// Parámetros:
// - matriz: Matriz de enteros del juego.
// - random: Instancia de System.Random.
void SortearPosicionMosca(Celda[,] matriz) {
    // 1. Aseguramos que el tablero está limpio antes de colocar una nueva mosca
    LimpiarMatriz(matriz);

    var size = matriz.GetLength(0);

    // 2. Sorteamos la posición (0-indexada). 
    // Next(size) devuelve un valor entre 0 (inclusivo) y size (exclusivo), es decir, 0 a size-1.
    var posicionMoscaFila = random.Next(0, size);
    var posicionMoscaColumna = random.Next(size);

    // 3. Colocamos la mosca. Almacenamos el valor entero del enum.
    matriz[posicionMoscaFila, posicionMoscaColumna] = Celda.Mosca;
}

// Pone todas las celdas de la matriz a Vacio (0).
// Parámetros:
// - matriz: Matriz de enteros a limpiar.
void LimpiarMatriz(Celda[,] matriz) {
    var filas = matriz.GetLength(0);
    var columnas = matriz.GetLength(1);

    // Almacenamos el valor entero de Vacio (que es 0)
    for (var i = 0; i < filas; i++) {
        for (var j = 0; j < columnas; j++)
            matriz[i, j] = Celda.Vacio;
    }
}