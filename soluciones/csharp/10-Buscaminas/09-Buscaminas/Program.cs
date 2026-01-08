using System.Text;
using System.Text.RegularExpressions;
using _09_Buscaminas.Enums;
using _09_Buscaminas.Structs;

// ---------------------------------------------------------------
// NOTA SOBRE EL TIPO DE MATRIZ USADO
// ---------------------------------------------------------------
// Aquí usamos `Celda[,]` en lugar de `Celda[][]`.
//
// `Celda[,]` es una matriz rectangular: todas las filas tienen la misma longitud.
// Esto es perfecto para un tablero fijo NxN como el Buscaminas.
//
// Con `Celda[][]` habría que inicializar cada fila manualmente,
// mientras que con `Celda[,]` la matriz queda lista de una sola vez.
// Además, el acceso es más simple: tablero[f, c].
//
// Por tanto, para este caso `Celda[,]` es mejor opción.
// ---------------------------------------------------------------

// Constantes
const int DimensionMaxTablero = 9; // Tamaño del tablero (9x9)

// Configuramos la consola para permitir emojis
Console.OutputEncoding = Encoding.UTF8;

// Bucle principal del juego: permite jugar varias partidas
bool jugarDeNuevo;
do {
    Partida(); // Jugamos una partida completa
    Console.WriteLine("🎮 Juego terminado.");
    jugarDeNuevo = PreguntarRepetir(); // Preguntamos si queremos jugar otra
} while (jugarDeNuevo);

// Mensaje final
Console.WriteLine("👋 Presiona una tecla para salir...");
Console.ReadKey();
return;

// ---------------------------------------------------------------
// Ejecuta una partida completa
// ---------------------------------------------------------------
void Partida() {
    Console.WriteLine($"💣 Iniciando Buscaminas {DimensionMaxTablero}x{DimensionMaxTablero}.");

    // Pedimos al usuario cuántas minas quiere colocar
    var totalMinas = PedirNumeroMinas();

    // Creamos el tablero interno (dónde están las minas y números)
    var tablero = InicializarTablero(DimensionMaxTablero, totalMinas);

    // Creamos el tablero visible (lo que ve el jugador)
    // Todas las casillas comienzan ocultas, para ser reveladas luego
    var tableroVisible = new Celda[DimensionMaxTablero, DimensionMaxTablero];
    for (var f = 0; f < DimensionMaxTablero; f++)
        for (var c = 0; c < DimensionMaxTablero; c++)
            tableroVisible[f, c] = Celda.Oculta;

    var juegoTerminado = false; // Indica si se explotó una mina
    var reveladas = 0; // Contador de casillas reveladas correctamente

    // Bucle principal del juego
    while (!juegoTerminado && !JuegoGanado(reveladas, totalMinas)) {
        ImprimirTablero(tableroVisible); // Mostramos el tablero actual

        // Leemos acción del usuario
        var accion = PedirAccion(DimensionMaxTablero);
        var p = accion.Posicion;

        // Contamos casillas marcadas (para referencia futura si se expandiera lógica)
        var minasMarcadas = ContarMarcadas(tableroVisible);

        switch (accion.Accion) {
            case "marcar":
                // Solo podemos marcar casillas que estén ocultas
                if (tableroVisible[p.Fila, p.Columna] == Celda.Oculta)
                    Marcar(tableroVisible, p);
                else if (tableroVisible[p.Fila, p.Columna] == Celda.Marcada)
                    Desmarcar(tableroVisible, p);
                else
                    Console.WriteLine("⚠️ Esta casilla ya está revelada.");
                break;

            case "liberar":
                // No podemos liberar casillas marcadas
                if (tableroVisible[p.Fila, p.Columna] == Celda.Marcada) {
                    Console.WriteLine("⚠️ Primero desmarque la casilla.");
                }
                // No podemos liberar casillas ya reveladas
                else if (tableroVisible[p.Fila, p.Columna] != Celda.Oculta) {
                    Console.WriteLine("⚠️ Esta casilla ya ha sido revelada.");
                }
                else {
                    // Revelamos
                    var resultado = RevelarCasilla(tablero, tableroVisible, p);

                    if (resultado == -1) // Se reveló una mina
                        juegoTerminado = true;
                    else
                        reveladas += resultado; // Sumamos casillas reveladas
                }

                break;
        }
    }

    // Mensaje de victoria o derrota
    Console.WriteLine(juegoTerminado ? "💥 ¡Has explotado una mina!" : "🎉 ¡Has ganado!");

    // Mostramos tablero completo incluyendo minas
    ImprimirTablero(tablero, true);
}

// ---------------------------------------------------------------
// Devuelve true si ya se han revelado todas las casillas sin mina
// ---------------------------------------------------------------
bool JuegoGanado(int reveladas, int totalMinas) {
    return reveladas == DimensionMaxTablero * DimensionMaxTablero - totalMinas;
}

// ---------------------------------------------------------------
// Pide al usuario cuántas minas quiere colocar
// ---------------------------------------------------------------
int PedirNumeroMinas() {
    var totalCeldas = DimensionMaxTablero * DimensionMaxTablero;
    var min = (int)(totalCeldas * 0.15);
    var max = (int)(totalCeldas * 0.85);

    // Regex: ^\d+$   → solo números enteros positivos
    var regex = new Regex(@"^\d+$");

    var numero = 0;
    bool ok;
    do {
        Console.Write($"Ingrese número de minas (entre {min} y {max}): ");
        var input = Console.ReadLine()?.Trim() ?? "";
        // Si cumple regex y está en rango
        ok = regex.IsMatch(input) && int.TryParse(input, out numero) && numero >= min && numero <= max;
        if (!ok) Console.WriteLine("❌ Entrada inválida.");
    } while (!ok);

    return numero;
}

// ---------------------------------------------------------------
// Inicializa el tablero interno colocando minas y números
// ---------------------------------------------------------------
Celda[,] InicializarTablero(int tamaño, int minas) {
    var tablero = new Celda[tamaño, tamaño];
    var rnd = new Random();
    var colocadas = 0;

    // Colocamos minas aleatoriamente sin repetir casillas
    while (colocadas < minas) {
        int f = rnd.Next(tamaño), c = rnd.Next(tamaño);
        if (tablero[f, c] != Celda.Mina) {
            tablero[f, c] = Celda.Mina;
            colocadas++;
        }
    }

    // Para cada casilla sin mina, calculamos cuántas minas hay alrededor
    for (var f = 0; f < tamaño; f++)
        for (var c = 0; c < tamaño; c++)
            if (tablero[f, c] != Celda.Mina)
                tablero[f, c] = (Celda)ContarMinasAdyacentes(tablero, f, c);

    return tablero;
}

// ---------------------------------------------------------------
// Cuenta minas alrededor de una casilla (8 direcciones)
// ---------------------------------------------------------------
int ContarMinasAdyacentes(Celda[,] tablero, int f, int c) {
    var count = 0;
    for (var df = -1; df <= 1; df++)
        for (var dc = -1; dc <= 1; dc++) {
            var nf = f + df;
            var nc = c + dc;
            if (nf >= 0 && nf < DimensionMaxTablero && nc >= 0 && nc < DimensionMaxTablero)
                if (tablero[nf, nc] == Celda.Mina)
                    count++;
        }

    return count;
}

// ---------------------------------------------------------------
// Lee y valida la acción del usuario
// ---------------------------------------------------------------
AccionDeJuego PedirAccion(int tamaño) {
    // Regex con grupos:
    // ^(\d+)\s+(\d+)\s+(marcar|liberar)$
    // Grupo1 = fila, Grupo2 = columna, Grupo3 = acción
    var regex = new Regex(@"^(\d+)\s+(\d+)\s+(marcar|liberar)$");

    while (true) {
        Console.Write("👉 Acción (fila columna marcar/liberar): ");
        var input = Console.ReadLine()?.Trim() ?? "";
        var m = regex.Match(input);

        if (m.Success) {
            var f = int.Parse(m.Groups[1].Value);
            var c = int.Parse(m.Groups[2].Value);

            if (f >= 1 && f <= tamaño && c >= 1 && c <= tamaño)
                return new AccionDeJuego {
                    Posicion = new Posicion { Fila = f - 1, Columna = c - 1 },
                    Accion = m.Groups[3].Value.ToLower()
                };

            Console.WriteLine("⚠️ Coordenadas fuera del tablero.");
        }
        else {
            Console.WriteLine("⚠️ Formato inválido. Ejemplo: 3 5 marcar");
        }
    }
}

// ---------------------------------------------------------------
// Marca una casilla con 🚩
// ---------------------------------------------------------------
void Marcar(Celda[,] tablero, Posicion p) {
    tablero[p.Fila, p.Columna] = Celda.Marcada;
}

// ---------------------------------------------------------------
// Desmarca una casilla
// ---------------------------------------------------------------
void Desmarcar(Celda[,] tablero, Posicion p) {
    tablero[p.Fila, p.Columna] = Celda.Oculta;
}

// ---------------------------------------------------------------
// Revela una casilla → devuelve -1 si era mina
// ---------------------------------------------------------------
int RevelarCasilla(Celda[,] tablero, Celda[,] visible, Posicion p) {
    return tablero[p.Fila, p.Columna] == Celda.Mina ? -1 : RevelarAdyacentes(tablero, visible, p);
}

// ---------------------------------------------------------------
// Revela celdas adyacentes recursivamente (si es vacía)
// ---------------------------------------------------------------
int RevelarAdyacentes(Celda[,] tablero, Celda[,] visible, Posicion p) {
    // Si está fuera o ya revelada, no hacemos nada
    if (!PosicionValida(p) || visible[p.Fila, p.Columna] != Celda.Oculta)
        return 0;

    // Revelamos
    visible[p.Fila, p.Columna] = tablero[p.Fila, p.Columna];
    var count = 1;

    // Si es vacía, revelamos también las vecinas
    if (tablero[p.Fila, p.Columna] == Celda.Vacia)
        for (var df = -1; df <= 1; df++)
            for (var dc = -1; dc <= 1; dc++)
                count += RevelarAdyacentes(tablero,
                    visible,
                    new Posicion { Fila = p.Fila + df, Columna = p.Columna + dc });

    return count;
}

// ---------------------------------------------------------------
// Verifica que una posición está dentro del tablero
// ---------------------------------------------------------------
bool PosicionValida(Posicion p) {
    return p.Fila >= 0 && p.Fila < DimensionMaxTablero && p.Columna >= 0 && p.Columna < DimensionMaxTablero;
}


// ---------------------------------------------------------------
// Cuenta cuántas casillas están marcadas con 🚩
// ---------------------------------------------------------------
int ContarMarcadas(Celda[,] tablero) {
    var count = 0;
    for (var f = 0; f < DimensionMaxTablero; f++)
        for (var c = 0; c < DimensionMaxTablero; c++)
            if (tablero[f, c] == Celda.Marcada)
                count++;
    return count;
}

// ---------------------------------------------------------------
// Imprime el tablero en consola con alineación correcta
// ---------------------------------------------------------------
void ImprimirTablero(Celda[,] tablero, bool mostrarMinas = false) {
    Console.Write("\n    ");
    for (var i = 1; i <= DimensionMaxTablero; i++)
        Console.Write($"{i,2} "); // ← (explicación abajo)

    // {valor,2} → muestra la cadena ocupando *2 caracteres* siempre,
    // Esto garantiza que todos los símbolos se alineen verticalmente.
    // Sin esto, los números y los emojis descuadran la tabla.

    // Creamos un string que tiene el guion repetido tantas veces como columnas hay
    Console.WriteLine("\n   " + new string('-', DimensionMaxTablero * 3 + 1));

    for (var f = 0; f < DimensionMaxTablero; f++) {
        Console.Write($"{f + 1,2} | ");
        for (var c = 0; c < DimensionMaxTablero; c++) {
            var celda = tablero[f, c];
            var simbolo = celda switch {
                Celda.Oculta => "·",
                Celda.Marcada => "🚩",
                Celda.Mina when mostrarMinas => "💣",
                Celda.Mina => "·",
                Celda.Vacia => " ",
                _ => ((int)celda).ToString()
            };
            Console.Write($"{simbolo,2} ");
        }

        Console.WriteLine("|");
    }

    // Repetimos la línea inferior, tantas veces como la superior que es la dimensión del tablero
    Console.WriteLine("   " + new string('-', DimensionMaxTablero * 3 + 1) + "\n");
}

// ---------------------------------------------------------------
// Pregunta si se desea jugar de nuevo (con regex explicada)
// ---------------------------------------------------------------
bool PreguntarRepetir() {
    // Regex:
    // ^s(i|í)?$   → "s", "si", "sí"
    // ^no?$       → "n", "no"
    // ignoramos mayúsculas/minúsculas
    var regexSi = new Regex(@"^s(i|í)?$", RegexOptions.IgnoreCase);
    var regexNo = new Regex(@"^no?$", RegexOptions.IgnoreCase);

    while (true) {
        Console.Write("🔁 ¿Jugar otra vez? (s/n): ");
        var input = Console.ReadLine()?.Trim().ToLower() ?? "";
        if (regexSi.IsMatch(input)) return true;
        if (regexNo.IsMatch(input)) return false;
        Console.WriteLine("⚠️ Respuesta inválida. Usa 's' o 'n'.");
    }
}