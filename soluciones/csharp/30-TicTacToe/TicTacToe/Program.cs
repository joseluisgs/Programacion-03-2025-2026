using System.Text;
using System.Text.RegularExpressions;
using TicTacToe.Structs;

Console.OutputEncoding = Encoding.UTF8;
Console.Clear();


var tablero = new char[3, 3];
var turno = 0; // 0 para Jugador 'X', 1 para Jugador 'O'
var juegoTerminado = false;


Console.WriteLine("=== ⭕ Tres en Raya con C# ❌ ===");

// --- Módulo Principal (Flujo del Juego) ---

InicializarTablero();

do {
    DibujarTablero();

    // Determinar el símbolo del jugador que acaba de jugar (el opuesto al turno actual)
    var simboloJugadorAnterior = turno == 0 ? 'O' : 'X';

    // Comprobar estado después del movimiento del ciclo anterior
    if (ComprobarVictoria(simboloJugadorAnterior)) {
        Console.WriteLine($"\n🎉 ¡El jugador '{simboloJugadorAnterior}' ha ganado el juego! 🎉");
        juegoTerminado = true;
    }

    if (ComprobarEmpate()) {
        Console.WriteLine("\n🤝 ¡Empate! El tablero está lleno. 🤝");
        juegoTerminado = true;
    }

    // Si el juego no ha terminado, pedir y realizar el siguiente movimiento
    var jugada = PedirMovimiento(turno);
    RealizarMovimiento(jugada, ref turno);
} while (!juegoTerminado);

// Mostrar el tablero final
DibujarTablero();
Console.WriteLine("\n--- Fin del juego ---");
Console.WriteLine("\n👋 Presiona una tecla para salir...");
Console.ReadKey();
return;


void InicializarTablero() {
    for (var i = 0; i < 3; i++) {
        for (var j = 0; j < 3; j++) tablero[i, j] = ' ';
    }

    turno = 0;
    juegoTerminado = false;
}

void DibujarTablero() {
    Console.WriteLine("\n     1   2   3");
    Console.WriteLine("   -------------");
    for (var i = 0; i < 3; i++) {
        Console.Write($" {i + 1} |");
        for (var j = 0; j < 3; j++)
            // Muestra el contenido del tablero
            Console.Write($" {tablero[i, j]} |");
        Console.WriteLine("\n   -------------");
    }
}

int ObtenerEntradaValida(string prompt) {
    string entrada;
    // Patrón RegEx: Coincide exactamente con '1', '2', o '3'.
    var patronRegEx = "^[1-3]$";

    while (true) {
        Console.Write($"{prompt} (1-3): ");
        entrada = Console.ReadLine()?.Trim() ?? "";

        // Comprobación con Expresión Regular
        if (Regex.IsMatch(entrada, patronRegEx))
            // Devolvemos el valor - 1 para que sea el índice de la matriz (0, 1, o 2)
            return int.Parse(entrada) - 1;

        Console.WriteLine("❌ Entrada no válida. Debe ser un número entre 1 y 3.");
    }
}

Tirada PedirMovimiento(int jugadorTurno) {
    var jugadorActual = jugadorTurno == 0 ? 'X' : 'O';
    Console.WriteLine($"\nTurno de {jugadorActual}.");

    var nuevaTirada = new Tirada();
    var movimientoValido = false;

    do {
        // Obtener entrada validada entre 1 y 3
        nuevaTirada.Fila = ObtenerEntradaValida("Introduce la fila");
        nuevaTirada.Columna = ObtenerEntradaValida("Introduce la columna");

        // Validar si la casilla está vacía usando la matriz 'tablero'
        if (tablero[nuevaTirada.Fila, nuevaTirada.Columna] == ' ')
            movimientoValido = true;
        else
            Console.WriteLine("🚫 Casilla ocupada. Inténtalo de nuevo.");
    } while (!movimientoValido);

    return nuevaTirada;
}

void RealizarMovimiento(Tirada tirada, ref int jugadorTurno) {
    var jugadorActual = jugadorTurno == 0 ? 'X' : 'O';

    tablero[tirada.Fila, tirada.Columna] = jugadorActual;

    // Cambiar de turno
    jugadorTurno = 1 - jugadorTurno;
}

bool ComprobarVictoria(char simbolo) {
    // 1. Comprobar Filas y Columnas
    for (var i = 0; i < 3; i++) {
        // Comprobar Fila i: (i,0), (i,1), (i,2)
        if (tablero[i, 0] == simbolo && tablero[i, 1] == simbolo && tablero[i, 2] == simbolo)
            return true;
        // Comprobar Columna i: (0,i), (1,i), (2,i)
        if (tablero[0, i] == simbolo && tablero[1, i] == simbolo && tablero[2, i] == simbolo)
            return true;
    }

    // 2. Comprobar Diagonales
    // Diagonal Principal: (0,0), (1,1), (2,2)
    if (tablero[0, 0] == simbolo && tablero[1, 1] == simbolo && tablero[2, 2] == simbolo)
        return true;
    // Diagonal Secundaria: (0,2), (1,1), (2,0)
    if (tablero[0, 2] == simbolo && tablero[1, 1] == simbolo && tablero[2, 0] == simbolo)
        return true;

    return false;
}

bool ComprobarEmpate() {
    var casillasVacias = 0;
    for (var i = 0; i < 3; i++) {
        for (var j = 0; j < 3; j++)
            if (tablero[i, j] == ' ')
                casillasVacias++;
    }

    return casillasVacias == 0;
}