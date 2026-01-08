// WalkingDaw.exe size:6 enemigos:10 bloques:5 salud:12 municion:8 tiempo:20000 pausa:500

using System.Text;
using TheWalkingDawTwo.Enums;
using TheWalkingDawTwo.Structs;

// -----------------------------------------------------
// CONSTANTES (PascalCase y valores por defecto)
// -----------------------------------------------------
const int DefaultTamTablero = 5;
const int DefaultNumBloques = 7;
const int DefaultNumEnemigos = 15;
const int DefaultNumVidas = 2;
const int DefaultSaludInicial = 10;
const int DefaultMunicionInicial = 10;
const int DefaultProbRecibirAtaque = 50;
const int DefaultDuracionJuegoMs = 30_000;
const int DefaultPausaMs = 1000;
const int DefaultEnemigosIntervaloMs = 5000;

// Barra de progreso
const int ProgressBarWidth = 30;

// Random compartido
var random = Random.Shared;

// -----------------------------------------------------
// INICIO (Top-level)
// -----------------------------------------------------
Console.Title = "WalkingDAW - Portado a C# (Estilo docente)";
Console.OutputEncoding = Encoding.UTF8;
Console.Clear();

Main(args);

// Fin
Console.WriteLine("\n👋 Presiona una tecla para salir...");
Console.ReadKey();
return;


void Main(string[] args) {
    Console.WriteLine("----------------------------------------------------");
    Console.WriteLine(" 🧟 WalkingDAW - Juego de Zombies (Doble Buffer)");
    Console.WriteLine("----------------------------------------------------");
    Console.WriteLine();

// 1) Procesar argumentos opcionales (formato clave:valor)
    var configuracion = ProcesarArgumentos(args);

// 2) Crear tableros (front = lectura, back = escritura)
    var tableroFront = new TipoCelda[configuracion.TamTablero, configuracion.TamTablero];
    var tableroBack = new TipoCelda[configuracion.TamTablero, configuracion.TamTablero];

// 3) Inicializar estado y colocar jugador y elementos
    var marcador = new Marcador();

// Inicializamos tablero front vacío y poblamos (sin Daryl aún)
    InicializarTablero(tableroFront, configuracion);

// Colocar Daryl en posición aleatoria y asignar estado.Posicion
    var posicionInicial = new Posicion {
        Fila = random.Next(0, configuracion.TamTablero),
        Columna = random.Next(0, configuracion.TamTablero)
    };

    tableroFront[posicionInicial.Fila, posicionInicial.Columna] = TipoCelda.Daryl;
    marcador.Posicion = posicionInicial;
    marcador.Salud = configuracion.SaludInicial;
    marcador.Municion = configuracion.MunicionInicial;

// Elegir dirección inicial aleatoria (enum)
    var possibleDirs = new[] { Direccion.Norte, Direccion.Sur, Direccion.Este, Direccion.Oeste };
    marcador.Direccion = possibleDirs[random.Next(0, possibleDirs.Length)];

    marcador.TiempoMs = 0;
    marcador.Salida = EstadoSalida.Continuar;
    marcador.EnemigosMuertos = 0;

// Mensaje de configuración
    Console.WriteLine("----------------------------------------------------");
    Console.WriteLine(" ⚙️ Configuración:");
    Console.WriteLine($"- Tamaño del tablero: {configuracion.TamTablero}x{configuracion.TamTablero}");
    Console.WriteLine($"- Bloques iniciales: {configuracion.NumBloques}");
    Console.WriteLine($"- Enemigos iniciales: {configuracion.NumEnemigos}");
    Console.WriteLine($"- Vidas colocadas: {configuracion.NumVidas}");
    Console.WriteLine($"- Salud inicial jugador: {configuracion.SaludInicial}");
    Console.WriteLine($"- Munición inicial jugador: {configuracion.MunicionInicial}");
    Console.WriteLine($"- Prob. recibir ataque: {configuracion.ProbRecibirAtaque}%");
    Console.WriteLine($"- Duración (ms): {configuracion.DuracionJuegoMs}");
    Console.WriteLine($"- Pausa por ciclo (ms): {configuracion.PausaMs}");
    Console.WriteLine("----------------------------------------------------");
    Console.WriteLine("\nPulse una tecla para iniciar la simulación...");
    Console.ReadKey();

// 4) Bucle principal - doble buffer + swap con tuplas
    Simulacion(ref tableroFront, ref tableroBack, ref marcador, configuracion);

// 5) Mostramos la última imagen del tablero
    PrintTablero(tableroFront);
    DibujarBarraProgreso(marcador.TiempoMs, configuracion.DuracionJuegoMs);

    Console.WriteLine("\n----------------------------------------------------");
    Console.WriteLine(" 🗒️ Informe Final:");
    Console.WriteLine($"- Enemigos muertos: {marcador.EnemigosMuertos}");
    Console.WriteLine($"- Tiempo jugado (ms): {marcador.TiempoMs}");
// 6) Informe final
    InformeFinal(marcador);
}
/* ===================================================================
   FUNCIONES (ajustadas: ref solo donde se modifica realmente el estado)
   =================================================================== */

// Procesa argumentos clave:valor y devuelve configuración
Configuracion ProcesarArgumentos(string[] args) {
    Console.WriteLine("------------ ⚙️ Procesando Configuración -----------");
    var c = new Configuracion {
        TamTablero = DefaultTamTablero,
        NumBloques = DefaultNumBloques,
        NumEnemigos = DefaultNumEnemigos,
        NumVidas = DefaultNumVidas,
        SaludInicial = DefaultSaludInicial,
        MunicionInicial = DefaultMunicionInicial,
        ProbRecibirAtaque = DefaultProbRecibirAtaque,
        DuracionJuegoMs = DefaultDuracionJuegoMs,
        PausaMs = DefaultPausaMs,
        EnemigosIntervaloMs = DefaultEnemigosIntervaloMs
    };

    string? v;
    v = BuscarValorEnArgs(args, "size");
    if (v != null && int.TryParse(v, out var size) && size > 0)
        c.TamTablero = size;
    else if (v != null)
        Console.WriteLine($"⚠️ 'size' inválido ('{v}'), usando {DefaultTamTablero}");

    v = BuscarValorEnArgs(args, "bloques");
    if (v != null && int.TryParse(v, out var b) && b >= 0)
        c.NumBloques = b;
    else if (v != null)
        Console.WriteLine($"⚠️ 'bloques' inválido ('{v}'), usando {DefaultNumBloques}");

    v = BuscarValorEnArgs(args, "enemigos");
    if (v != null && int.TryParse(v, out var e) && e >= 0)
        c.NumEnemigos = e;
    else if (v != null)
        Console.WriteLine($"⚠️ 'enemigos' inválido ('{v}'), usando {DefaultNumEnemigos}");

    v = BuscarValorEnArgs(args, "vidas");
    if (v != null && int.TryParse(v, out var vid) && vid >= 0)
        c.NumVidas = vid;
    else if (v != null)
        Console.WriteLine($"⚠️ 'vidas' inválido ('{v}'), usando {DefaultNumVidas}");

    v = BuscarValorEnArgs(args, "salud");
    if (v != null && int.TryParse(v, out var s) && s > 0)
        c.SaludInicial = s;
    else if (v != null)
        Console.WriteLine($"⚠️ 'salud' inválido ('{v}'), usando {DefaultSaludInicial}");

    v = BuscarValorEnArgs(args, "municion");
    if (v != null && int.TryParse(v, out var m) && m >= 0)
        c.MunicionInicial = m;
    else if (v != null)
        Console.WriteLine($"⚠️ 'municion' inválido ('{v}'), usando {DefaultMunicionInicial}");

    v = BuscarValorEnArgs(args, "probataque") ?? BuscarValorEnArgs(args, "prob");
    if (v != null && int.TryParse(v, out var p) && p >= 0 && p <= 100)
        c.ProbRecibirAtaque = p;
    else if (v != null)
        Console.WriteLine($"⚠️ 'probataque' inválido ('{v}'), usando {DefaultProbRecibirAtaque}");

    v = BuscarValorEnArgs(args, "tiempo") ?? BuscarValorEnArgs(args, "duracion");
    if (v != null && int.TryParse(v, out var t) && t > 0)
        c.DuracionJuegoMs = t;
    else if (v != null)
        Console.WriteLine($"⚠️ 'tiempo' inválido ('{v}'), usando {DefaultDuracionJuegoMs}");

    v = BuscarValorEnArgs(args, "pausa");
    if (v != null && int.TryParse(v, out var pms) && pms > 0)
        c.PausaMs = pms;
    else if (v != null)
        Console.WriteLine($"⚠️ 'pausa' inválido ('{v}'), usando {DefaultPausaMs}");

    v = BuscarValorEnArgs(args, "intervalo");
    if (v != null && int.TryParse(v, out var ims) && ims > 0)
        c.EnemigosIntervaloMs = ims;
    else if (v != null)
        Console.WriteLine($"⚠️ 'intervalo' inválido ('{v}'), usando {DefaultEnemigosIntervaloMs}");

    Console.WriteLine("----------------------------------------------------");
    return c;
}

// Busca el valor asociado a una clave en los argumentos (formato clave:valor)
string? BuscarValorEnArgs(string[] args, string claveBuscada) {
    var claveNormalizada = claveBuscada.ToLower().Trim();
    foreach (var arg in args) {
        var parts = arg.Split(':');
        if (parts.Length == 2) {
            var claveActual = parts[0].ToLower().Trim();
            if (claveActual == claveNormalizada) return parts[1].Trim();
        }
    }

    return null;
}

void InicializarTablero(TipoCelda[,] tablero, Configuracion config) {
    var n = tablero.GetLength(0);
    // Inicializar a Libre
    for (var i = 0; i < n; i++)
        for (var j = 0; j < n; j++)
            tablero[i, j] = TipoCelda.Libre;

    // Colocar vidas
    for (var k = 0; k < config.NumVidas; k++)
        ColocarEnPosicionAleatoria(TipoCelda.Vida, tablero);

    // Colocar bloques
    for (var k = 0; k < config.NumBloques; k++)
        ColocarEnPosicionAleatoria(TipoCelda.Bloque, tablero);

    // Colocar enemigos
    for (var k = 0; k < config.NumEnemigos; k++)
        ColocarEnPosicionAleatoria(TipoCelda.Zombi, tablero);
}

void ColocarEnPosicionAleatoria(TipoCelda item, TipoCelda[,] tablero) {
    var n = tablero.GetLength(0);
    var fila = 0;
    var col = 0;
    do {
        fila = random.Next(0, n);
        col = random.Next(0, n);
    } while (tablero[fila, col] != TipoCelda.Libre);

    tablero[fila, col] = item;
}

bool HayEspacioLibre(TipoCelda[,] tablero) {
    var n = tablero.GetLength(0);
    for (var i = 0; i < n; i++)
        for (var j = 0; j < n; j++)
            if (tablero[i, j] == TipoCelda.Libre)
                return true;
    return false;
}

/*
 * Simulación principal con doble buffer y swap (front = lectura, back = escritura)
 * Marcador pasado por ref (se modifica). Configuracion pasada por valor.
 */
void Simulacion(ref TipoCelda[,] front, ref TipoCelda[,] back, ref Marcador estado,
    Configuracion config) {
    var size = front.GetLength(0);
    // Asegurar tamaño de back
    if (back.GetLength(0) != size || back.GetLength(1) != size)
        back = new TipoCelda[size, size];

    var simulacionActiva = true;

    do {
        // Imprimir estado
        Console.Clear();
        Console.WriteLine($"\n--- ⏱️ Tiempo {estado.TiempoMs / 1000} s ---");
        PrintTablero(front);
        DibujarBarraProgreso(estado.TiempoMs, config.DuracionJuegoMs);

        // Copiar front -> back para coherencia T+1
        Array.Copy(front, back, front.Length);

        // Accion del juego: lee de front y escribe en back, modifica estado (por ref)
        AccionJuego(front, back, ref estado, config);

        // Cada intervalo de enemigos: añadir uno si hay espacio
        if (estado.TiempoMs > 0 && estado.TiempoMs % config.EnemigosIntervaloMs == 0)
            if (HayEspacioLibre(back)) {
                Console.WriteLine("🧟 Aparece un nuevo enemigo!");
                ColocarEnPosicionAleatoria(TipoCelda.Zombi, back);
            }

        // Swap front/back por tuplas (eficiente)
        (front, back) = (back, front);

        // Incrementar tiempo
        estado.TiempoMs += config.PausaMs;

        // Comprobar condiciones de fin
        if (estado.TiempoMs >= config.DuracionJuegoMs || estado.Salud <= 0 ||
            estado.Salida == EstadoSalida.Salida)
            simulacionActiva = false;

        // Pausa para visualización
        Thread.Sleep(config.PausaMs);
    } while (simulacionActiva);

    // Dibujar barra completa final
    //DibujarBarraProgreso(config.DuracionJuegoMs, config.DuracionJuegoMs);
    Console.WriteLine();
}

/*
 * Acción del juego: lee de 'front' y escribe en 'back'.
 * Marcador pasado por ref (se modifica). Configuración por valor.
 */
void AccionJuego(TipoCelda[,] front, TipoCelda[,] back, ref Marcador estado, Configuracion config) {
    // Guardamos la posición previa para poder limpiar en BACK
    var prevFila = estado.Posicion.Fila;
    var prevCol = estado.Posicion.Columna;

    var filaActual = prevFila;
    var colActual = prevCol;
    var nuevaFila = filaActual;
    var nuevaCol = colActual;

    // Elegimos dirección aleatoria (cambia cada turno)
    var dirs = new[] { Direccion.Norte, Direccion.Sur, Direccion.Este, Direccion.Oeste };
    var dirElegida = dirs[random.Next(0, dirs.Length)];
    estado.Direccion = dirElegida;
    Console.WriteLine($"🔀 Nueva dirección: {MiDireccion(dirElegida)}");

    // Calcular nueva posición según dirección
    if (dirElegida == Direccion.Norte && filaActual > 0) nuevaFila--;
    else if (dirElegida == Direccion.Sur && filaActual < front.GetLength(0) - 1) nuevaFila++;
    else if (dirElegida == Direccion.Este && colActual < front.GetLength(1) - 1) nuevaCol++;
    else if (dirElegida == Direccion.Oeste && colActual > 0) nuevaCol--;

    // Si se sale del tablero, ajustar dirección y quedarse
    if (nuevaFila < 0 || nuevaFila >= front.GetLength(0) || nuevaCol < 0 || nuevaCol >= front.GetLength(1)) {
        var nuevaDir =
            CambiarDireccionEnLimiteTablero(front, filaActual, colActual, dirElegida);
        estado.Direccion = nuevaDir;
        nuevaFila = filaActual;
        nuevaCol = colActual;
    }

    // Actualizamos la posición del jugador (local)
    filaActual = nuevaFila;
    colActual = nuevaCol;

    // Comportamiento según el contenido de la celda en LECTURA (front)
    var celda = front[filaActual, colActual];
    switch (celda) {
        case TipoCelda.Libre:
            Console.WriteLine(
                $"No encontramos nada en {filaActual + 1},{colActual + 1}, seguimos {MiDireccion(estado.Direccion)}");
            break;
        case TipoCelda.Bloque:
            Console.WriteLine($"Chocamos con un bloque en {filaActual + 1},{colActual + 1}");
            if (estado.Municion >= 2) {
                estado.Municion -= 2;
                Console.WriteLine("🔫 Disparamos y destruimos el bloque (-2 munición).");
                back[filaActual, colActual] = TipoCelda.Libre;
            }
            else {
                var newDir = CambiarDireccionCuandoHayBloque(front, filaActual, colActual, estado.Direccion);
                if (newDir != estado.Direccion) {
                    estado.Direccion = newDir;
                    Console.WriteLine($"↩️ Cambiamos de dirección a {MiDireccion(newDir)}");
                }
                else {
                    Console.WriteLine("🔒 Atascados por bloques y sin munición suficiente. Nos quedamos.");
                }
            }

            break;
        case TipoCelda.Zombi:
            Console.WriteLine($"🧟 Encontramos un enemigo en {filaActual + 1},{colActual + 1}");
            if (estado.Municion > 0) {
                if (random.Next(100) < config.ProbRecibirAtaque) {
                    estado.Salud--;
                    Console.WriteLine("💥 El enemigo nos ha atacado primero! -1 vida");
                }

                estado.Municion--;
                estado.EnemigosMuertos++;
                Console.WriteLine("🎯 Disparamos y matamos al enemigo.");
                back[filaActual, colActual] = TipoCelda.Libre;
            }
            else {
                estado.Salud -= 2;
                Console.WriteLine("⚔️ Atacamos con el machete y perdemos 2 vidas.");
                back[filaActual, colActual] = TipoCelda.Libre;
            }

            break;
        case TipoCelda.Vida:
            estado.Salud++;
            Console.WriteLine($"💖 Recogemos una vida en {filaActual + 1},{colActual + 1} (+1 salud).");
            back[filaActual, colActual] = TipoCelda.Libre;
            break;
        case TipoCelda.Municion:
            estado.Municion++;
            Console.WriteLine($"🔋 Recogemos munición en {filaActual + 1},{colActual + 1} (+1 munición).");
            back[filaActual, colActual] = TipoCelda.Libre;
            break;
        case TipoCelda.Daryl:
            // no debería suceder (otra Daryl)
            break;
    }

    // Actualizar posición del jugador en BACK: dejar libre donde estaba y poner Daryl donde esté ahora
    back[prevFila, prevCol] = TipoCelda.Libre;
    back[filaActual, colActual] = TipoCelda.Daryl;

    // Actualizar estado con nueva posición
    estado.Posicion.Fila = filaActual;
    estado.Posicion.Columna = colActual;

    // Si llegamos a la esquina inferior derecha, hemos salido
    if (filaActual == front.GetLength(0) - 1 && colActual == front.GetLength(1) - 1) {
        Console.WriteLine("🏁 ¡Hemos salido del mundo!");
        estado.Salida = EstadoSalida.Salida;
    }
}

/*
 * Cambia dirección si la nueva posición sale del tablero: devuelve nueva dirección segura
 * (ya no recibe Configuracion porque no lo usa)
 */
Direccion CambiarDireccionEnLimiteTablero(TipoCelda[,] tablero, int posFil, int posCol, Direccion direccion) {
    var direcciones = new[] { Direccion.Norte, Direccion.Sur, Direccion.Este, Direccion.Oeste };
    // Construimos array de direcciones sin la actual (sin LINQ)
    var restantes = new Direccion[3];
    var idx = 0;
    for (var i = 0; i < direcciones.Length; i++)
        if (direcciones[i] != direccion)
            restantes[idx++] = direcciones[i];

    // Barajar restantes manualmente
    var barajadas = BarajarArray(restantes);

    foreach (var dir in barajadas) {
        var nf = posFil;
        var nc = posCol;
        if (dir == Direccion.Norte) nf = posFil - 1;
        else if (dir == Direccion.Sur) nf = posFil + 1;
        else if (dir == Direccion.Este) nc = posCol + 1;
        else if (dir == Direccion.Oeste) nc = posCol - 1;

        if (nf >= 0 && nf < tablero.GetLength(0) && nc >= 0 && nc < tablero.GetLength(1)) {
            Console.WriteLine($"↪️ Salimos del tablero y cambiamos a {MiDireccion(dir)}");
            return dir;
        }
    }

    Console.WriteLine("↪️ Salimos del tablero pero no encontramos mejor dirección, mantenemos la actual.");
    return direccion;
}

/*
 * Cambiar dirección si chocamos con un bloque: devuelve nueva dirección segura
 * (se ha eliminado la variable redundante y el parámetro Configuracion)
 */
Direccion CambiarDireccionCuandoHayBloque(TipoCelda[,] tablero, int posFil, int posCol, Direccion direccion) {
    var direcciones = BarajarArray(new[] { Direccion.Norte, Direccion.Sur, Direccion.Este, Direccion.Oeste });

    foreach (var dir in direcciones) {
        var nf = posFil;
        var nc = posCol;
        if (dir == Direccion.Norte) nf = posFil - 1;
        else if (dir == Direccion.Sur) nf = posFil + 1;
        else if (dir == Direccion.Este) nc = posCol + 1;
        else if (dir == Direccion.Oeste) nc = posCol - 1;

        if (nf >= 0 && nf < tablero.GetLength(0) && nc >= 0 && nc < tablero.GetLength(1)) {
            var contenido = tablero[nf, nc];
            if (contenido != TipoCelda.Bloque && contenido != TipoCelda.Zombi) {
                Console.WriteLine($"🔁 Chocamos con bloque, cambiamos a {MiDireccion(dir)}");
                return dir;
            }
        }
    }

    Console.WriteLine("🔒 Todas las direcciones están bloqueadas. Nos quedamos.");
    return direccion;
}

/*
 * Baraja un array de Direccion (Fisher-Yates) y devuelve array nuevo
 */
Direccion[] BarajarArray(Direccion[] array) {
    var n = array.Length;
    var copy = new Direccion[n];
    for (var i = 0; i < n; i++) copy[i] = array[i];
    for (var i = n - 1; i >= 1; i--) {
        var j = random.Next(0, i + 1);
        (copy[i], copy[j]) = (copy[j], copy[i]);
    }

    return copy;
}

// Imprime el tablero en consola usando emojis
void PrintTablero(TipoCelda[,] tablero) {
    var n = tablero.GetLength(0);
    // Superior
    Console.WriteLine("╔═" + new string('═', 3 * n) + "═╗");
    for (var i = 0; i < n; i++) {
        Console.Write("║ ");
        for (var j = 0; j < n; j++)
            switch (tablero[i, j]) {
                case TipoCelda.Daryl:
                    Console.Write("🤠 ");
                    break;
                case TipoCelda.Bloque:
                    Console.Write("🧱 ");
                    break;
                case TipoCelda.Zombi:
                    Console.Write("🧟 ");
                    break;
                case TipoCelda.Vida:
                    Console.Write("❤️ ");
                    break;
                case TipoCelda.Municion:
                    Console.Write("🔋 ");
                    break;
                default:
                    Console.Write("   ");
                    break;
            }

        Console.WriteLine(" ║");
    }

    // Inferior
    Console.WriteLine("╚═" + new string('═', 3 * n) + "═╝");
}

void InformeFinal(Marcador estado) {
    Console.WriteLine();
    Console.WriteLine("\nFin del juego!");
    if (estado.Salud <= 0) Console.WriteLine("☠️ Has muerto!");
    else Console.WriteLine("✌️Has sobrevivido!");

    if (estado.Salida == EstadoSalida.Salida) Console.WriteLine("Has escapado!");
    Console.WriteLine($"🔫 Has matado a {estado.EnemigosMuertos} enemigos.");
    Console.WriteLine($"❤️ Tu vida final fue {Math.Max(0, estado.Salud)}.");
    Console.WriteLine($"🔋 Tu munición final fue {estado.Municion}.");
}

void DibujarBarraProgreso(int actualMs, int maximoMs) {
    if (maximoMs <= 0) maximoMs = 1;
    var porcentaje = actualMs / (double)maximoMs;
    porcentaje = Math.Clamp(porcentaje, 0.0, 1.0);
    var llenado = (int)(ProgressBarWidth * porcentaje);
    var barra = new string('■', llenado).PadRight(ProgressBarWidth, '─');

    // Color ANSI simulado (opcional)
    var color = porcentaje < 0.5 ? "\u001b[32m" : porcentaje < 0.8 ? "\u001b[33m" : "\u001b[31m";
    var reset = "\u001b[0m";

    Console.Write($"\r{color}[{barra}]{reset} {(int)(porcentaje * 100)}%  Tiempo: {actualMs}ms\n");
}

/*
 * Convierte la Direccion enum a texto legible (sustituye la función miDireccion del Kotlin)
 */
string MiDireccion(Direccion direction) {
    return direction switch {
        Direccion.Norte => "Norte",
        Direccion.Sur => "Sur",
        Direccion.Este => "Este",
        Direccion.Oeste => "Oeste",
        _ => "Desconocida"
    };
}