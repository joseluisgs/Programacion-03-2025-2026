// Main Program

using System.Diagnostics;
using System.Text;
using InfeccionDobleBuffer.Enums;
using InfeccionDobleBuffer.Structs;

// .\Simulador.exe dimension:X infectados:Y sanos:Z contagio:C tiempo:T muerte:M matar:K
// .\Simulador.exe dimension:25 infectados:5 sanos:150 contagio:40 tiempo:50 muerte:10 matar:5

/*
 * ===================================================================
 * DEFINICIONES DE CONSTANTES
 * ===================================================================
 */

// Constantes con valores por defecto (PascalCase)
const int DefaultDimension = 20; // Dimensión del tablero (20x20)
const int DefaultInfectados = 20; // Cantidad inicial de infectados
const int DefaultSanos = 100; // Cantidad inicial de sanos
const int DefaultContagio = 15; // 10% de probabilidad de contagio
const int DefaultTiempo = 15; // Ciclos máximos
const int DefaultMuerte = 5; // 5% de probabilidad de morir por ciclo
const int DefaultMatar = 5; // 5% de probabilidad de matar

// Instancia de Random compartida para toda la simulación
var random = Random.Shared;

// Programa principal
Console.Title = "Simulador de Infección con Doble Buffering";
Console.OutputEncoding = Encoding.UTF8;
Console.Clear();

Main(args);

Console.WriteLine("\n👋 Presiona una tecla para salir...");
Console.ReadKey();
return;
// Fin del programa

void Main(string[] args) {
/*
 * ===================================================================
 * BUCLE PRINCIPAL DE SIMULACIÓN
 * ===================================================================
 */

    Console.WriteLine("----------------------------------------------------");
    Console.WriteLine(" 🧟 Simulador de Infección Zombie con Doble Buffering");
    Console.WriteLine("         The Walking DAW Code Edition        ");
    Console.WriteLine("----------------------------------------------------");
    Console.WriteLine();

// 1. Obtener configuración
    var configuracion = ProcesarArgumentos(args);

// Mensaje de configuración
    Console.WriteLine("---------------------------------------------------");
    Console.WriteLine(" ⚙️ Configuración de la Simulación:");
    Console.WriteLine($"- Dimensión: {configuracion.Dimension}x{configuracion.Dimension}");
    Console.WriteLine($"- Infectados iniciales: {configuracion.Infectados}");
    Console.WriteLine($"- Sanos iniciales: {configuracion.Sanos}");
    Console.WriteLine($"- Probabilidad Contagio: {configuracion.Contagio}%");
    Console.WriteLine($"- Ciclos máximos: {configuracion.Tiempo} segundos");
    Console.WriteLine($"- Probabilidad Muerte Zombie: {configuracion.Muerte}%");
    Console.WriteLine($"- Probabilidad Matar Zombie: {configuracion.Matar}%");
    Console.WriteLine("-------------------------------------------------");

    Console.WriteLine("\n Pulse una tecla para iniciar la simulación...");
    Console.ReadKey();


// 2. Inicializar Tableros (Buffers)
    var tableroFront = new TipoCelda[configuracion.Dimension, configuracion.Dimension]; // Lectura (T)
    var tableroBack = new TipoCelda[configuracion.Dimension, configuracion.Dimension]; // Escritura (T+1)

    PoblarTableroInicial(tableroFront, configuracion.Infectados, configuracion.Sanos);

// 3. Bucle de Simulación (Cambiado a DO-WHILE)
    var ciclosTranscurridos = 0;
    var simulacionActiva = true;

    do {
        // 0. Imprimir estado actual
        Console.Clear();
        Console.WriteLine($"\n--- ⏱️ Ciclo {ciclosTranscurridos + 1} ---");
        MostrarTablero(tableroFront);
        DibujarBarraProgreso(ciclosTranscurridos, configuracion.Tiempo);
        // A. Calcular el siguiente estado
        // Lee de 'tableroFront' (T) y escribe en 'tableroBack' (T+1)
        CalcularSiguienteEstado(tableroFront, tableroBack, configuracion);

        // B. Intercambiar buffers (Swap)
        // El 'tableroBack' (T+1) se convierte en el 'tableroFront' (T) 
        // Swap de referencias usando tuplas (eficiente)
        (tableroFront, tableroBack) = (tableroBack, tableroFront);

        // C. Incrementar contador de ciclos
        ciclosTranscurridos++;

        // D. Comprobar condición de fin
        if (ContarCelulas(tableroFront, TipoCelda.Sana) == 0 ||
            ContarCelulas(tableroFront, TipoCelda.Infectada) == 0)
            simulacionActiva = false;

        // E. Pausa para visualización (opcional)
        Thread.Sleep(1000);
    } while (simulacionActiva && ciclosTranscurridos < configuracion.Tiempo);


// 4. Mostrar Resultados Finales
// Pasamos los ciclos que realmente ocurrieron
    MostrarResultados(tableroFront, ciclosTranscurridos, configuracion);
}


/*
 * ===================================================================
 * DEFINICIONES DE FUNCIONES AUXILIARES
 * ===================================================================
 */

/*
 * Busca un valor en el array de argumentos (formato clave:valor).
 * Esta función auxiliar evita el uso de Dictionaries.
 * args El array de argumentos (ej: ["dimension:10", "sanos:50"])
 * claveBuscada La clave a buscar (ej: "dimension")
 * return El valor (string) si se encuentra, o 'null' si no.
 */
string? BuscarValorEnArgs(string[] args, string claveBuscada) {
    var claveNormalizada = claveBuscada.ToLower().Trim();

    foreach (var arg in args) {
        var parts = arg.Split(':');
        if (parts.Length == 2) {
            var claveActual = parts[0].ToLower().Trim();
            if (claveActual == claveNormalizada)
                return parts[1].Trim(); // Valor encontrado
        }
    }

    return null; // No encontrado
}

/*
 * Procesa los argumentos de la línea de comandos (formato clave:valor).
 * Informa sobre parámetros faltantes o inválidos y usa valores por defecto.
 * args Los argumentos de la línea de comandos.
 * return Una struct Configuracion con los valores finales.
 */
Configuracion ProcesarArgumentos(string[] args) {
    Console.WriteLine("------------ ⚙️ Procesando Configuración -----------");

    // 1. Iniciar config con todos los valores por defecto
    var config = new Configuracion {
        Dimension = DefaultDimension,
        Infectados = DefaultInfectados,
        Sanos = DefaultSanos,
        Contagio = DefaultContagio,
        Tiempo = DefaultTiempo,
        Muerte = DefaultMuerte,
        Matar = DefaultMatar
    };

    // 2. Validar cada parámetro usando la función auxiliar
    // Dimensión
    var dimStr = BuscarValorEnArgs(args, "dimension");
    if (dimStr != null) {
        if (int.TryParse(dimStr, out var dimVal) && dimVal > 0)
            config.Dimension = dimVal;
        else
            Console.WriteLine(
                $"⚠️ 'dimension' con valor inválido ('{dimStr}'). Usando por defecto: {DefaultDimension}");
    }
    else {
        Console.WriteLine($"❌ 'dimension' no especificado. Usando por defecto: {DefaultDimension}");
    }

    // Infectados
    var infStr = BuscarValorEnArgs(args, "infectados");
    if (infStr != null) {
        if (int.TryParse(infStr, out var infVal) && infVal >= 0)
            config.Infectados = infVal;
        else
            Console.WriteLine(
                $"⚠️ 'infectados' con valor inválido ('{infStr}'). Usando por defecto: {DefaultInfectados}");
    }
    else {
        Console.WriteLine($"❌ 'infectados' no especificado. Usando por defecto: {DefaultInfectados}");
    }

    // Sanos
    var sanosStr = BuscarValorEnArgs(args, "sanos");
    if (sanosStr != null) {
        if (int.TryParse(sanosStr, out var sanosVal) && sanosVal >= 0)
            config.Sanos = sanosVal;
        else
            Console.WriteLine($"⚠️ 'sanos' con valor inválido ('{sanosStr}'). Usando por defecto: {DefaultSanos}");
    }
    else {
        Console.WriteLine($"❌ 'sanos' no especificado. Usando por defecto: {DefaultSanos}");
    }

    // Contagio
    var contStr = BuscarValorEnArgs(args, "contagio");
    if (contStr != null) {
        if (int.TryParse(contStr, out var contVal) && contVal >= 0 && contVal <= 100)
            config.Contagio = contVal;
        else
            Console.WriteLine($"⚠️ 'contagio' con valor inválido ('{contStr}'). Usando por defecto: {DefaultContagio}");
    }
    else {
        Console.WriteLine($"❌ 'contagio' no especificado. Usando por defecto: {DefaultContagio}");
    }

    // Tiempo (Ciclos)
    var tiempoStr = BuscarValorEnArgs(args, "tiempo");
    if (tiempoStr != null) {
        if (int.TryParse(tiempoStr, out var tiempoVal) && tiempoVal > 0)
            config.Tiempo = tiempoVal;
        else
            Console.WriteLine($"⚠️ 'tiempo' con valor inválido ('{tiempoStr}'). Usando por defecto: {DefaultTiempo}");
    }
    else {
        Console.WriteLine($"❌ 'tiempo' no especificado. Usando por defecto: {DefaultTiempo}");
    }

    // Muerte (Probabilidad)
    var muerteStr = BuscarValorEnArgs(args, "muerte");
    if (muerteStr != null) {
        if (int.TryParse(muerteStr, out var muerteVal) && muerteVal >= 0 && muerteVal <= 100)
            config.Muerte = muerteVal;
        else
            Console.WriteLine($"⚠️ 'muerte' con valor inválido ('{muerteStr}'). Usando por defecto: {DefaultMuerte}");
    }
    else {
        Console.WriteLine($"❌ 'muerte' no especificado. Usando por defecto: {DefaultMuerte}");
    }

    // Matar (Probabilidad de matar del sano)
    var matarStr = BuscarValorEnArgs(args, "matar");
    if (matarStr != null) {
        if (int.TryParse(matarStr, out var matarVal) && matarVal >= 0 && matarVal <= 100)
            // *** CORRECCIÓN IMPORTANTE: Asignar a config.Matar ***
            config.Matar = matarVal;
        else
            Console.WriteLine($"⚠️ 'matar' con valor inválido ('{matarStr}'). Usando por defecto: {DefaultMatar}");
    }
    else {
        // *** CORRECCIÓN: Usar la clave 'matar' en el mensaje de error ***
        Console.WriteLine($"❌ 'matar' no especificado. Usando por defecto: {DefaultMatar}");
    }

    Console.WriteLine("----------------------------------------------------");
    return config;
}

/*
 * Mueve una célula infectada (T) a una nueva posición (T+1)
 * y propaga la infección desde la posición original (T).
 */
void MoverEInfectar(TipoCelda[,] tableroLectura, TipoCelda[,] tableroEscritura, int posFila, int posColumna,
    Configuracion configuracion) {
    // PASO 1: Buscar Personas alrededor
    var celdasLibresFila = new int[8];
    var celdasLibresCol = new int[8];
    var numCeldasLibres = 0;

    for (var df = -1; df <= 1; df++) {
        for (var dc = -1; dc <= 1; dc++) {
            if (df == 0 && dc == 0) continue; // No contarse a sí mismo

            var nuevaFila = posFila + df;
            var nuevaCol = posColumna + dc;

            // Comprobamos posición válida Y que esté LIBRE en ESCRITURA
            // (Miramos en ESCRITURA (T+1) por si otro zombie ya se movió allí en este ciclo)
            if (EsPosicionValida(tableroLectura, nuevaFila, nuevaCol) &&
                tableroEscritura[nuevaFila, nuevaCol] == TipoCelda.Libre) {
                // Guardamos esta posición como candidata
                celdasLibresFila[numCeldasLibres] = nuevaFila;
                celdasLibresCol[numCeldasLibres] = nuevaCol;
                numCeldasLibres++;
            }
        }
    }

    // PASO 2: Decidir si se mueve
    if (numCeldasLibres > 0) {
        // ¡Puede moverse! Elegir un destino aleatorio de los libres
        var indiceElegido = random.Next(0, numCeldasLibres);
        var filaDestino = celdasLibresFila[indiceElegido];
        var colDestino = celdasLibresCol[indiceElegido];

        // Aplicar movimiento en T+1 (Escritura)
        tableroEscritura[filaDestino, colDestino] = TipoCelda.Infectada; // Moverse a la nueva
        tableroEscritura[posFila, posColumna] = TipoCelda.Libre; // Dejar la antigua
    }
    // else: Si numCeldasLibres == 0, no hace nada. 
    // El zombie se queda en [posFila, posColumna] (ya copiado de T a T+1)

    // PASO 3: Propagar infección (siempre desde la posición T)
    // (Esto infecta, se mueva o no)
    PropagarInfeccion(tableroLectura, tableroEscritura, posFila, posColumna, configuracion);
}

/*
 * Propaga la infección a los vecinos de la posición (filaActual, columnaActual).
 */
void PropagarInfeccion(TipoCelda[,] tableroLectura, TipoCelda[,] tableroEscritura, int filaActual, int columnaActual,
    Configuracion configuracion) {
    // Recorremos las 8 posiciones vecinas
    for (var df = filaActual - 1; df <= filaActual + 1; df++) {
        for (var dc = columnaActual - 1; dc <= columnaActual + 1; dc++)
            if (EsPosicionValida(tableroLectura, df, dc))
                if (!(df == filaActual && dc == columnaActual))
                    // Solo intentamos infectar si la célula es SANA en LECTURA
                    if (tableroLectura[df, dc] == TipoCelda.Sana)
                        // Usamos el valor de contagio de la struct 'config'
                        if (RealizarSorteo(configuracion.Contagio))
                            // Console.WriteLine($"  > Propaga de ({filaActual}, {columnaActual}) a ({df}, {dc})");
                            // La hemos infectado en ESCRITURA
                            tableroEscritura[df, dc] = TipoCelda.Infectada;
    }
}

/*
 * Intenta mover una célula sana (T) a una posición adyacente LIBRE (T+1),
 * o matar a un zombie adyacente (T) con una probabilidad definida.
 */
void MoverSano(TipoCelda[,] tableroLectura, TipoCelda[,] tableroEscritura, int posFila, int posColumna,
    Configuracion configuracion) {
    // PASO 1: Identificar vecinos (Zombies y Celdas Libres)
    var celdasLibresFila = new int[8];
    var celdasLibresCol = new int[8];
    var numCeldasLibres = 0;

    var zombiesVecinosFila = new int[8];
    var zombiesVecinosCol = new int[8];
    var numZombiesVecinos = 0;

    for (var df = -1; df <= 1; df++) {
        for (var dc = -1; dc <= 1; dc++) {
            if (df == 0 && dc == 0) continue; // No contarse a sí mismo

            var nuevaFila = posFila + df;
            var nuevaCol = posColumna + dc;

            if (EsPosicionValida(tableroLectura, nuevaFila, nuevaCol)) {
                // Comprobamos el estado en LECTURA (T) para la defensa
                if (tableroLectura[nuevaFila, nuevaCol] == TipoCelda.Infectada) {
                    zombiesVecinosFila[numZombiesVecinos] = nuevaFila;
                    zombiesVecinosCol[numZombiesVecinos] = nuevaCol;
                    numZombiesVecinos++;
                }

                // Comprobamos el estado en ESCRITURA (T+1) para el movimiento
                if (tableroEscritura[nuevaFila, nuevaCol] == TipoCelda.Libre) {
                    celdasLibresFila[numCeldasLibres] = nuevaFila;
                    celdasLibresCol[numCeldasLibres] = nuevaCol;
                    numCeldasLibres++;
                }
            }
        }
    }

    // PASO 2: Lógica de Ataque (Prioridad: Matar)
    if (numZombiesVecinos > 0) {
        // Elegimos UN zombie adyacente al azar para intentar atacarlo
        var indiceZombie = random.Next(0, numZombiesVecinos);
        var zombieFila = zombiesVecinosFila[indiceZombie];
        var zombieCol = zombiesVecinosCol[indiceZombie];

        if (RealizarSorteo(configuracion.Matar)) {
            // ¡Éxito! El sano mata al zombie
            // La posición del zombie debe quedar LIBRE en ESCRITURA (T+1)
            tableroEscritura[zombieFila, zombieCol] = TipoCelda.Libre;

            // El sano no se mueve, permanece en su posición (ya copiada en T+1)
            return; // Termina la función aquí
        }
        // Si no mata al zombie, pasa al movimiento (el zombie sobrevive para atacarle en el futuro)
    }

    // PASO 3: Lógica de Movimiento
    if (numCeldasLibres > 0) {
        // Si hay casillas libres y no se ha movido/matado antes: moverse
        var indiceElegido = random.Next(0, numCeldasLibres);
        var filaDestino = celdasLibresFila[indiceElegido];
        var colDestino = celdasLibresCol[indiceElegido];

        // Aplicar movimiento en T+1 (Escritura)
        tableroEscritura[filaDestino, colDestino] = TipoCelda.Sana; // Moverse a la nueva
        tableroEscritura[posFila, posColumna] = TipoCelda.Libre; // Dejar la antigua
    }
    // else: El sano se queda quieto si no tiene donde ir ni zombies para atacar.
    // (Ya fue copiado de T a T+1, así que permanece sano en su sitio)
}

/*
 * Recorre el tablero de lectura (T) y aplica las modificaciones al tablero de escritura (T+1).
 */
/*
 * Recorre el tablero de lectura (T) y aplica las modificaciones al tablero de escritura (T+1).
 */
void CalcularSiguienteEstado(TipoCelda[,] tableroLectura, TipoCelda[,] tableroEscritura, Configuracion configuracion) {
    var dimensionLocal = tableroLectura.GetLength(0);

    // PASO 1. COPIA NECESARIA (Coherencia T+1)
    CopiarMatriz(tableroLectura, tableroEscritura);

    // PASO 2. CÁLCULO DE MOVIMIENTO/INFECCIÓN (O(N^2))
    for (var i = 0; i < dimensionLocal; i++) {
        for (var j = 0; j < dimensionLocal; j++) {
            // Usamos el buffer de LECTURA (T) para determinar qué hacer
            var tipoCelda = tableroLectura[i, j];

            if (tipoCelda == TipoCelda.Infectada) {
                // LÓGICA ZOMBIE
                // Decidir si el zombie muere por inanición
                if (RealizarSorteo(configuracion.Muerte))
                    tableroEscritura[i, j] = TipoCelda.Libre; // Zombie muere
                else
                    // Si no muere, intenta moverse e infectar
                    MoverEInfectar(tableroLectura, tableroEscritura, i, j, configuracion); // Zombie se mueve/infecta
            }
            else if (tipoCelda == TipoCelda.Sana) {
                // LÓGICA SANO
                // Las personas sanas no mueren por inanición, solo por infección/ataque zombie
                // MoverSano incluye la lógica de ataque/movimiento
                MoverSano(tableroLectura, tableroEscritura, i, j, configuracion); // Sano se mueve/ataca
            }
        }
    }
}

/*
 * Imprime el informe final de resultados.
 * tablero El tablero final.
 * tiempo El número total de CICLOS transcurridos en la simulación.
 */
/*
 * Imprime el informe final de resultados, incluyendo porcentajes de cambio.
 * tablero El tablero final.
 * tiempo El número total de CICLOS transcurridos en la simulación.
 */
void MostrarResultados(TipoCelda[,] tablero, int tiempo, Configuracion configuracion) {
    Console.Clear();

    MostrarTablero(tablero);

    Console.WriteLine("\nRESULTADOS FINALES:");
    Console.WriteLine($"Ciclos transcurridos: {tiempo} (Máximo configurado: {configuracion.Tiempo})");

    // --- CÁLCULO DE PORCENTAJES ---

    // 1. Obtenemos los conteos finales (como double para precisión)
    double numInfectados = ContarCelulas(tablero, TipoCelda.Infectada);
    double numSanos = ContarCelulas(tablero, TipoCelda.Sana);
    double numLibres = ContarCelulas(tablero, TipoCelda.Libre);

    // 2. Obtenemos los conteos iniciales (de la configuración)
    double inicialInfectados = configuracion.Infectados;
    double inicialSanos = configuracion.Sanos;
    var inicialLibres = configuracion.Dimension * configuracion.Dimension - (inicialInfectados + inicialSanos);

    // 3. Generamos los strings de porcentaje
    var pctInfectados = CalcularPorcentajeCambio(numInfectados, inicialInfectados);
    var pctSanos = CalcularPorcentajeCambio(numSanos, inicialSanos);
    var pctLibres = CalcularPorcentajeCambio(numLibres, inicialLibres);

    // --- IMPRESIÓN DE RESULTADOS ---

    // Imprimimos los resultados con los porcentajes
    Console.WriteLine(
        $"Zombis Infectados (🧟): {numInfectados} (Inicio: {inicialInfectados}) {pctInfectados}");
    Console.WriteLine(
        $"Personas Sanas (🙂): {numSanos} (Inicio: {inicialSanos}) {pctSanos}");
    Console.WriteLine(
        $"Lugares Libres (◻️): {numLibres} (Inicio: {inicialLibres}) {pctLibres}");


    if (numSanos == 0)
        Console.WriteLine("🧟 ¡La infección se ha propagado por completo!");
    else if (numInfectados == 0)
        Console.WriteLine("💉  ¡La infección ha sido erradicada!");
    else
        Console.WriteLine("⏱️ La simulación finalizó con personas sanas restantes (límite de tiempo alcanzado).");
}


/*
 * ===================================================================
 * FUNCIONES AUXILIARES (STUBS)
 * ===================================================================
 */

/* Población inicial del tablero con personas infectadas y sanas.
 * tablero El tablero donde se poblará.
 * infectados El número de personas infectadas.
 * sanos El número de personas sanas.
 */
void PoblarTableroInicial(TipoCelda[,] tablero, int infectados, int sanos) {
    var dim = tablero.GetLength(0);
    var totalCeldas = dim * dim;

    if (infectados + sanos > totalCeldas) {
        Console.WriteLine("! Advertencia: El número de infectados y sanos supera el tamaño del tablero. Se ajustará.");
        infectados = Math.Min(infectados, totalCeldas);

        // Por que usamos Min, evitamos que sanos sea negativo y nos ahorramos el if extra
        // Es decir, tomamos el mínimo entre sanos y las celdas restantes
        sanos = Math.Min(sanos, totalCeldas - infectados);
    }

    // Colocar Infectados
    for (var i = 0; i < infectados; i++) {
        int f, c; // fila y columna aleatorias, sorteamos mientras esté libres
        do {
            f = random.Next(0, dim);
            c = random.Next(0, dim);
        } while (tablero[f, c] != TipoCelda.Libre);

        tablero[f, c] = TipoCelda.Infectada;
    }

    // Colocar Sanos
    for (var i = 0; i < sanos; i++) {
        int f, c;
        do {
            f = random.Next(0, dim);
            c = random.Next(0, dim);
        } while (tablero[f, c] != TipoCelda.Libre);

        tablero[f, c] = TipoCelda.Sana;
    }
}

/*
 * Calcula el número de personas con un determinado estado en el tablero.
 * tablero El tablero a analizar.
 * fila La fila a comprobar.
 * col La columna a comprobar.
 * return El número de personas del tipo especificado.
 */
bool EsPosicionValida(TipoCelda[,] tablero, int fila, int col) {
    var dimFilas = tablero.GetLength(0);
    var dimCols = tablero.GetLength(1);

    // Validamos que la posición esté dentro del rango de la matriz
    return fila >= 0 && fila < dimFilas && col >= 0 && col < dimCols;
}

/*
 * Realiza un sorteo basado en un porcentaje dado.
 * porcentaje El porcentaje de probabilidad (0-100).
 * return true si el sorteo es exitoso, false en caso contrario.
 */
bool RealizarSorteo(int porcentaje) {
    // Como el procentaje es 75%, lo dividimos entre 100 para obtener 0.75
    var probabilidad = porcentaje / 100.0;
    // Usamos Random.NextDouble para obtener un número decimal entre 0 y 1.
    return random.NextDouble() < probabilidad;
}

/*
 * Copia el contenido de una matriz origen a una matriz destino.
 * origen La matriz de origen.
 * destino La matriz de destino.
 */
void CopiarMatriz(TipoCelda[,] origen, TipoCelda[,] destino) {
    // Esto asegura que ambas matrices tengan el mismo tamaño
    if (origen.Length != destino.Length)
        Debug.Assert(origen.Length == destino.Length, "Las matrices origen y destino tienen tamaños diferentes.");
    //throw new ArgumentException("Las matrices origen y destino tienen tamaños diferentes.");
    // Copiamos el contenido usando Array.Copy para eficiencia, si no hacer nosotros!!!
    Array.Copy(origen, destino, origen.Length);
}

/*
 * Muestra el tablero en la consola.
 * tablero El tablero a mostrar.
 */
void MostrarTablero(TipoCelda[,] tablero) {
    Console.WriteLine("--- Tablero Final ---");
    for (var i = 0; i < tablero.GetLength(0); i++) {
        // (Opcional) Limitar la impresión si el tablero es muy grande
        if (i >= 30) {
            Console.WriteLine($"... (y {tablero.GetLength(0) - i} filas más)");
            break;
        }

        for (var j = 0; j < tablero.GetLength(1); j++) {
            // (Opcional) Limitar la impresión si el tablero es muy ancho
            if (j >= 30) {
                Console.Write(" ...");
                break;
            }

            switch (tablero[i, j]) {
                case TipoCelda.Libre:
                    Console.Write("◻️");
                    break;
                case TipoCelda.Sana:
                    Console.Write("🙂");
                    break;
                case TipoCelda.Infectada:
                    Console.Write("🧟");
                    break;
            }
        }

        Console.WriteLine();
    }
}

/*
 * Cuenta el número de personas de un tipo específico en el tablero.
 * tablero El tablero a analizar.
 * tipo El tipo de célula a contar.
 * return El número de personas del tipo especificado.
 */
int ContarCelulas(TipoCelda[,] tablero, TipoCelda tipo) {
    var contador = 0;
    for (var i = 0; i < tablero.GetLength(0); i++) {
        for (var j = 0; j < tablero.GetLength(1); j++)
            if (tablero[i, j] == tipo)
                contador++;
    }

    return contador;
}

/*
 * Calcula el string de un porcentaje de cambio (incremento/decremento).
 * final El valor al final de la simulación.
 * inicial El valor al inicio de la simulación.
 * return Un string formateado, ej: "(+20.5%)" o "(-10.0%)".
 */
string CalcularPorcentajeCambio(double final, double inicial) {
    // Manejar división por cero
    if (inicial == 0) {
        if (final > 0)
            return "(+N/A)"; // Empezó en 0 y acabó con más (cambio infinito)

        return "(0.0%)"; // Empezó en 0 y acabó en 0
    }

    // (Aplicando regla DAW: Hacemos explícito que la operación es con 'double')
    var cambio = (final - inicial) / inicial * 100.0;

    // Formatear el string:
    // "F1" significa 1 solo decimal.
    // El 'casteo' (double) es crucial para evitar la división entera si usas 'int'.

    if (cambio > 0)
        return $"(+{cambio:F1}%)"; // Añade el + para incrementos

    return $"({cambio:F1}%)"; // El - ya viene incluido para decrementos
}

void DibujarBarraProgreso(int actual, int maximo) {
    var largo = 30; // ancho de la barra
    var porcentaje = actual / (double)maximo;
    var llenado = (int)(largo * porcentaje);

    // Construimos la barra
    var barra = new string('■', llenado).PadRight(largo, '─');

    // Color simulado con ANSI (opcional)
    string color;
    if (porcentaje < 0.5) color = "\u001b[32m"; // verde
    else if (porcentaje < 0.8) color = "\u001b[33m"; // amarillo
    else color = "\u001b[31m"; // rojo

    var reset = "\u001b[0m";

    // Imprimimos en la misma línea, es el /r
    Console.Write($"\r{color}[{barra}]{reset} {(int)(porcentaje * 100)}%");
}