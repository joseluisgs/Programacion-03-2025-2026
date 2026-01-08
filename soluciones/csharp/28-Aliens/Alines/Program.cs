//  .\Aliens.exe space:12 aliens:8 lives:4 tiempo:80

using System.Text;
using Alines.Enums;
using Alines.Structs;

// -----------------------------------------------------
// CONSTANTES (PascalCase)
// -----------------------------------------------------
const int DefaultSpaceSize = 10;
const int DefaultNumAliens = 6;
const int DefaultLives = 3;
const int DefaultMaxTime = 60;

const int TimeToDefend = 2;
const int TimeToMove = 3;
const int TimeToAttack = 5;

const int PauseTime = 700;
const int MaxTriesToMove = 10;
const int ProbAccuracy = 70;
const int ProbAttack = 40;

const int ProgressBarWidth = 30;

// Random compartido
var random = Random.Shared;

// -----------------------------------------------------
// INICIO (Top-level)
// -----------------------------------------------------
Console.Title = "Juego Aliens - Doble Buffer con Swap";
Console.OutputEncoding = Encoding.UTF8;
Console.Clear();

Main(args);

Console.WriteLine("\n👋 Presiona una tecla para salir...");
Console.ReadKey();
return;

void Main(string[] args) {

    Console.WriteLine("----------------------------------------------------");
    Console.WriteLine(" 👾 Simulación Aliens (Doble Buffer) - DAW Edition");
    Console.WriteLine("----------------------------------------------------");
    Console.WriteLine();

    var configuracion = ProcesarArgumentos(args);

    Console.WriteLine("----------------------------------------------------");
    Console.WriteLine(" ⚙️ Configuración:");
    Console.WriteLine($"- Tamaño del espacio: {configuracion.SpaceSize}x{configuracion.SpaceSize}");
    Console.WriteLine($"- Aliens iniciales: {configuracion.NumAliens}");
    Console.WriteLine($"- Vidas iniciales: {configuracion.Lives}");
    Console.WriteLine($"- Tiempo máximo (ciclos): {configuracion.MaxTime}");
    Console.WriteLine("----------------------------------------------------");
    Console.WriteLine("\nPulse una tecla para iniciar la simulación...");
    Console.ReadKey();

// Inicializar buffers: front y back (se crean una sola vez)
    var espacioInicial = CrearEspacio(configuracion.SpaceSize, configuracion.NumAliens);
    var tableroFront = espacioInicial; // lectura (T)
    var tableroBack = new TipoCelda[configuracion.SpaceSize, configuracion.SpaceSize]; // escritura (T+1)

// Inicializar estado (struct)
    var marcador = new Marcador {
        Tiempo = 0,
        Vidas = configuracion.Lives,
        Aliens = configuracion.NumAliens
    };

// Ejecutar simulación (los buffers se manejan localmente)
    Simulacion(ref tableroFront, ref tableroBack, ref marcador, configuracion);

// Mostrar resultados finales
    InformeFinal(tableroFront, marcador, configuracion);

}



/* ===================================================================
   FUNCIONES PRINCIPALES (resumen)
   =================================================================== */

Configuracion ProcesarArgumentos(string[] args) {
    Console.WriteLine("------------ ⚙️ Procesando Configuración -----------");
    var config = new Configuracion {
        SpaceSize = DefaultSpaceSize,
        NumAliens = DefaultNumAliens,
        Lives = DefaultLives,
        MaxTime = DefaultMaxTime
    };
    string? v;
    v = BuscarValorEnArgs(args, "space");
    if (v != null && int.TryParse(v, out var s) && s > 0)
        config.SpaceSize = s;
    else if (v != null)
        Console.WriteLine($"⚠️ 'space' inválido ('{v}'), usando {DefaultSpaceSize}");
    v = BuscarValorEnArgs(args, "aliens");
    if (v != null && int.TryParse(v, out var a) && a >= 0)
        config.NumAliens = a;
    else if (v != null)
        Console.WriteLine($"⚠️ 'aliens' inválido ('{v}'), usando {DefaultNumAliens}");
    v = BuscarValorEnArgs(args, "lives");
    if (v != null && int.TryParse(v, out var l) && l >= 0)
        config.Lives = l;
    else if (v != null)
        Console.WriteLine($"⚠️ 'lives' inválido ('{v}'), usando {DefaultLives}");
    v = BuscarValorEnArgs(args, "tiempo") ?? BuscarValorEnArgs(args, "time");
    if (v != null && int.TryParse(v, out var t) && t > 0)
        config.MaxTime = t;
    else if (v != null) Console.WriteLine($"⚠️ 'tiempo' inválido ('{v}'), usando {DefaultMaxTime}");
    Console.WriteLine("----------------------------------------------------");
    return config;
}

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

/*
 * Simulación con doble buffer pre-allocado y swap por tuplas.
 * front: lectura (T), back: escritura (T+1)
 * Ambos buffers se pasan por ref para poder swapear las referencias.
 */
void Simulacion(ref TipoCelda[,] front, ref TipoCelda[,] back, ref Marcador estado,
    Configuracion config) {
    var size = front.GetLength(0);

    // Aseguramos que back tiene el tamaño correcto
    if (back.GetLength(0) != size || back.GetLength(1) != size)
        back = new TipoCelda[size, size];

    // Bucle principal
    var simulacionActiva = true;
    do {
        // 0. Imprimir estado actual
        Console.Clear();
        Console.WriteLine($"\n--- ⏱️ Ciclo {estado.Tiempo + 1} ---");
        PrintSpace(front, estado);
        DibujarBarraProgreso(estado.Tiempo, config.MaxTime, estado);

        // 1. COPIA NECESARIA (Coherencia T+1)
        // Copiamos front a back para conservar las celdas sin cambios (operación eficiente con Array.Copy)
        Array.Copy(front, back, front.Length);

        // 2. Calcular siguiente estado: leer de 'front' y escribir en 'back'
        // Acciones: disparo, movimiento, ataque
        if (estado.Tiempo % TimeToDefend == 0) 
            AimAndFire(front, back, size, ref estado);
        if (estado.Tiempo % TimeToMove == 0) {
            MoveAliens(front, back, estado);
            Console.WriteLine("➡️  Los aliens se han movido!");
        }

        if (estado.Tiempo % TimeToAttack == 0) {
            if (AlienAttack(estado)) {
                estado.Vidas -= 1;
                Console.WriteLine("💥 Los aliens han atacado!");
                Console.WriteLine($"Vidas restantes: {estado.Vidas}");
            }
            else {
                Console.WriteLine("❌ Los aliens han fallado al atacar!");
            }
        }

        // 3. Swap de referencias (eficiente)
        // Ahora el back (T+1) pasa a ser front (T) para la siguiente iteración
        (front, back) = (back, front);

        // 4. Incrementar tiempo y condiciones de fin
        estado.Tiempo += 1;
        if (estado.Tiempo > config.MaxTime || estado.Vidas <= 0 || estado.Aliens <= 0)
            simulacionActiva = false;

        // Pausa para visualización
        Thread.Sleep(PauseTime);
    } while (simulacionActiva);

    // Mostrar barra final completa
    //DibujarBarraProgreso(Math.Min(estado.Tiempo, config.MaxTime), config.MaxTime, estado);
    Console.WriteLine();
}

/* ===================================================================
   FUNCIONES AUXILIARES (sin cambios semánticos, solo firmas adaptadas)
   =================================================================== */

// Mover aliens leyendo de 'front' y escribiendo en 'back'
void MoveAliens(TipoCelda[,] front, TipoCelda[,] back, Marcador estado) {
    var size = front.GetLength(0);
    for (var i = 0; i < size; i++) {
        for (var j = 0; j < size; j++)
            if (front[i, j] == TipoCelda.Alien)
                MoveAlienToANewPosition(back, i, j, estado);
    }
}

// Mover un alien a una nueva posición válida en 'back'
void MoveAlienToANewPosition(TipoCelda[,] back, int fil, int col, Marcador estado) {
    var size = back.GetLength(0);
    var intentos = 0;
    var isStored = false;
    int newFil = fil, newCol = col;

    do {
        // Generar desplazamiento aleatorio (-1, 0, 1) para fila y columna
        var df = random.Next(-1, 2);
        var dc = random.Next(-1, 2);
        if (df == 0 && dc == 0) {
            intentos++;
            continue;
        }

        newFil = fil + df; // Actualizar nueva posición
        newCol = col + dc; // Actualizar nueva posición
        if (IsValidPosition(newFil, newCol, size) && back[newFil, newCol] == TipoCelda.Libre) {
            back[fil, col] = TipoCelda.Libre;
            back[newFil, newCol] = TipoCelda.Alien;
            isStored = true;
        }

        intentos++;
    } while (!isStored && intentos < MaxTriesToMove);

    if (!isStored) Console.WriteLine($"⚠️ Alien en [{fil + 1},{col + 1}] no se ha podido mover (bloqueado).");
    else Console.WriteLine($"➡️ Alien se desplaza desde [{fil + 1},{col + 1}] a [{newFil + 1},{newCol + 1}]");
}

// Verificar si una posición está dentro de los límites del espacio
bool IsValidPosition(int fil, int col, int size) {
    return fil >= 0 && fil < size && col >= 0 && col < size;
}

// Apuntar y disparar a una posición aleatoria en 'front', actualizar 'back' y 'estado'
bool AimAndFire(TipoCelda[,] front, TipoCelda[,] back, int size, ref Marcador estado) {
    Console.WriteLine("🎯 Apuntando...");
    var x = random.Next(0, size); // Generar coordenadas aleatorias para fila (x)
    var y = random.Next(0, size); // Generar coordenadas aleatorias para columna (y)

    // Disparas a una celda vacía
    if (front[x, y] == TipoCelda.Libre) {
        Console.WriteLine($"Has disparado a [{x + 1},{y + 1}] y es una posición vacía.");
        return false;
    }

    // Intento de disparo con probabilidad de acierto
    if (random.Next(100) < ProbAccuracy) {
        Console.WriteLine($"🎯 Has acertado en [{x + 1},{y + 1}]!");
        back[x, y] = TipoCelda.Libre;
        estado.Aliens -= 1; // modificamos estado (por ref en el llamador)
        return true;
    }

    // Disparo fallido
    Console.WriteLine($"❌ Has fallado en [{x + 1},{y + 1}]!");
    return false;
}

// Determinar si los aliens atacan con probabilidad
bool AlienAttack(Marcador marcador) {
    return random.Next(100) < ProbAttack;
}

// Crear espacio inicial con aliens colocados aleatoriamente
TipoCelda[,] CrearEspacio(int size, int numAliens) {
    var space = new TipoCelda[size, size];
    var colocados = 0;
    while (colocados < numAliens) {
        var x = random.Next(0, size);
        var y = random.Next(0, size);
        if (space[x, y] == TipoCelda.Libre) {
            space[x, y] = TipoCelda.Alien;
            colocados++;
        }
    }

    return space;
}

// Imprimir el espacio actual en consola
void PrintSpace(TipoCelda[,] space, Marcador marcador) {
    var n = space.GetLength(0);
    for (var i = 0; i < n; i++) {
        for (var j = 0; j < n; j++)
            if (space[i, j] == TipoCelda.Alien)
                Console.Write("👾");
            else Console.Write("◻️");
        Console.WriteLine();
    }
}

// Informe final de la simulación
void InformeFinal(TipoCelda[,] space, Marcador marcador, Configuracion config) {
    Console.WriteLine();
    PrintSpace(space, marcador);
    Console.WriteLine($"⏱️ Tiempo total: {marcador.Tiempo} (Máx: {config.MaxTime})");
    if (marcador.Aliens == 0) {
        Console.WriteLine("🏆 Has aniquilado a todos los aliens!");
    }
    else {
        Console.WriteLine("🚨 Hay aliens vivos que regresarán a por ti!");
        Console.WriteLine($"👾 Aliens restantes: {marcador.Aliens}");
    }

    if (marcador.Vidas == 0) {
        Console.WriteLine("💀 Has muerto en esta batalla!");
    }
    else {
        Console.WriteLine("💪 Has sobrevivido, y vives para luchar otro día!");
        Console.WriteLine($"❤️ Vidas restantes: {marcador.Vidas}");
    }
}

// Dibujar barra de progreso en consola
void DibujarBarraProgreso(int actual, int maximo, Marcador marcador) {
    if (maximo <= 0) maximo = 1;
    var porcentaje = actual / (double)maximo;
    porcentaje = Math.Clamp(porcentaje, 0.0, 1.0); // Asegurar rango [0,1]
    var llenado = (int)(ProgressBarWidth * porcentaje);
    var barra = new string('■', llenado).PadRight(ProgressBarWidth, '─');
    var color = porcentaje < 0.5 ? "\u001b[32m" : porcentaje < 0.8 ? "\u001b[33m" : "\u001b[31m";
    var reset = "\u001b[0m";
    Console.Write($"\r{color}[{barra}]{reset} {(int)(porcentaje * 100)}%\n");
}