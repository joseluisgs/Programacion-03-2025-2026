using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using BaseDatosAlumnado.Enums;
using BaseDatosAlumnado.Structs;
using Serilog;
using Spectre.Console;


// ====================================================================
// GESTIÓN DE ALUMNOS - CONSTANTES DEL SISTEMA
// ====================================================================

// Usamos 'const' para definir constantes de compilación.
const int TamanoInicial = 10;
const int IncrementoTamano = 10;
const int PorcentajeExpansion = 80;
const int PorcentajeReduccion = 50;
const double NotaAprobado = 5.00;

// Expresión regular para validar nombres: letras, acentos, ñ, espacios, mínimo 3 caracteres.
const string RegexNombre = @"^[A-Za-zñÑáéíóúÁÉÍÓÚ\s]{3,}$";

// Formato de cultura para España (números con coma decimal y monedas o fechas locales)
// Se mantiene para el formateo de salida (ToString)
var localeEs = new CultureInfo("es-ES");

// Variables globales para contador de IDs
var idAlumnoContador = 0;

// --------------------------------------------------------------------
// CONFIGURACIÓN DE SERILOG
// --------------------------------------------------------------------

// Configurar el logger estático: Nivel mínimo Debug y salida a la consola con template.
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug() // Permitir mensajes Debug y superiores
    .WriteTo.Console()
    .CreateLogger(); // Utilizamos Serilog para el logging

// --------------------------------------------------------------------
// BLOQUE PRINCIPAL (Top-Level Statements)
// --------------------------------------------------------------------

Console.Title = "Bases de Datos Alumnado con Arrays Estáticos en C#";
Console.OutputEncoding = Encoding.UTF8;
Console.Clear();

AnsiConsole.MarkupLine("[bold underline green]Sistema de Gestión de Alumnos DAW[/]");
AnsiConsole.MarkupLine("[green]==================================[/]");

// El vector principal ahora almacena estructuras de Alumno. 
// Usamos 'Alumno?' (Nullable<Alumno>) para que las posiciones puedan ser null.
var alumnosData = new Alumno?[TamanoInicial];
var numAlumnos = 0;
var opcionStr = "";
// Usamos el tipo del enum, que internamente es un int.
var opcion = (OpcionMenu)(-1); // Valor inicial inválido para forzar la entrada al bucle do-while.

// Inicialización de datos de prueba
InicializarDatos(alumnosData, ref numAlumnos);

var regexOpcionMenu = "^[0-8]$";

do {
    MostrarMenu(alumnosData.Length);

    // Validación de la opción de menú con Regex
    do {
        AnsiConsole.Markup("[bold]Seleccione una opción:[/] ");
        opcionStr = (AnsiConsole.Prompt(
            new TextPrompt<string>("")
                .AllowEmpty()
        ) ?? "").Trim();
        if (!ValidarEntrada(regexOpcionMenu, opcionStr))
            AnsiConsole.MarkupLine("[yellow]⚠️ Opción no válida. Intente de nuevo.[/]");
    } while (!ValidarEntrada(regexOpcionMenu, opcionStr));

    // Conversión a entero y luego al tipo enum OpcionMenu
    opcion = (OpcionMenu)int.Parse(opcionStr);

    // El bucle principal delega la lógica a los métodos locales
    switch (opcion) {
        case OpcionMenu.ListarTodos:
            // Llamada a la función que faltaba
            ListarAlumnos(alumnosData, numAlumnos);
            break;
        case OpcionMenu.InfoId:
            MostrarInfoAlumnoPorId(alumnosData);
            break;
        case OpcionMenu.InfoDni:
            MostrarInfoAlumnoPorDni(alumnosData);
            break;
        case OpcionMenu.Anadir:
            //Necesitamos 'ref' para 'alumnos' si hay redimensión.
            AnadirNuevoAlumno(ref alumnosData, ref numAlumnos);
            break;
        case OpcionMenu.Actualizar:
            ActualizarDatosAlumno(alumnosData);
            break;
        case OpcionMenu.Eliminar:
            EliminarAlumnoPorDni(ref alumnosData, ref numAlumnos);
            break;
        case OpcionMenu.ListarNotas:
            // Llamada a la función que faltaba, con ordenamiento por Nota
            ListarAlumnos(alumnosData, numAlumnos, TipoOrdenamiento.Nota);
            break;
        case OpcionMenu.Estadisticas:
            MostrarEstadisticas(alumnosData, numAlumnos);
            break;
        case OpcionMenu.Salir:
            AnsiConsole.MarkupLine("[green]👋 Saliendo del programa. ¡Hasta pronto![/]");
            break;
        default:
            // Este caso ya no debería ocurrir si la validación es correcta.
            AnsiConsole.MarkupLine("[yellow]⚠️ Opción no reconocida. Intente de nuevo.[/]");
            break;
    }
} while (opcion != OpcionMenu.Salir);

// --------------------------------------------------------------------
// LIMPIEZA DE SERILOG
// --------------------------------------------------------------------

Log.CloseAndFlush(); // Asegura que todos los logs pendientes se escriban.
AnsiConsole.MarkupLine("\n[silver]⌨️ Presiona una tecla para salir...[/]");
Console.ReadKey();


// --------------------------------------------------------------------
// MÉTODOS ESTÁTICOS LOCALES (Funciones y Procedimientos)
// --------------------------------------------------------------------

/*
 * Inicializa el vector de alumnos con datos de prueba, usando structs.
 * * alumnos Vector de estructuras Alumno? (posiciones nulas para huecos libres).
 * num Referencia al contador de alumnos.
 */
void InicializarDatos(Alumno?[] alumnos, ref int total) {
    var a1 = new Alumno { Id = NextIdAlumno(), Dni = "48612345M", NombreCompleto = "Juan Pérez", Nota = 8.50 };
    var a2 = new Alumno { Id = NextIdAlumno(), Dni = "87654321X", NombreCompleto = "Ana García", Nota = 4.25 };
    var a3 = new Alumno { Id = NextIdAlumno(), Dni = "11111111H", NombreCompleto = "Carlos Ruiz", Nota = 10.00 };

    // Asignación a las primeras posiciones del vector
    alumnos[0] = a1; // ID 1
    alumnos[1] = a2; // ID 2
    alumnos[2] = a3; // ID 3

    total = 3;
    // Log de inicialización
    Log.Information("Datos de prueba inicializados. Alumnos activos: {Total}", total);
}

/*
 * Muestra el menú de operaciones al usuario.
 * * capacidad La capacidad actual del vector.
 */
void MostrarMenu(int capacidad) {
    //  Usamos casting explícito a int para obtener el valor del enum.
    AnsiConsole.MarkupLine($"\n[bold aqua]--- MENÚ DE OPERACIONES (Capacidad: {capacidad}) ---[/]");
    AnsiConsole.MarkupLine(
        $"[silver]{(int)OpcionMenu.ListarTodos}[/]. [bold]Listar todos los alumnos[/] (Ordenado por DNI)");
    AnsiConsole.MarkupLine($"[silver]{(int)OpcionMenu.InfoId}[/]. Información de alumno por ID");
    AnsiConsole.MarkupLine($"[silver]{(int)OpcionMenu.InfoDni}[/]. Información de alumno por DNI");
    AnsiConsole.MarkupLine($"[silver]{(int)OpcionMenu.Anadir}[/]. Añadir alumno");
    AnsiConsole.MarkupLine($"[silver]{(int)OpcionMenu.Actualizar}[/]. Actualizar alumno");
    AnsiConsole.MarkupLine($"[silver]{(int)OpcionMenu.Eliminar}[/]. Eliminar alumno");
    AnsiConsole.MarkupLine($"[silver]{(int)OpcionMenu.ListarNotas}[/]. Listado ordenado por notas (Descendente)");
    AnsiConsole.MarkupLine($"[silver]{(int)OpcionMenu.Estadisticas}[/]. Mostrar Estadísticas");
    AnsiConsole.MarkupLine($"[silver]{(int)OpcionMenu.Salir}[/]. Salir");
    AnsiConsole.MarkupLine("[aqua]---------------------------[/]");
}

/*
 * Retorna el siguiente ID autoincremental.
 * * return int El siguiente ID.
 */
int NextIdAlumno() {
    idAlumnoContador++;
    return idAlumnoContador;
}

/*
 * Valida una cadena de entrada usando una expresión regular.
 * * patron El patrón de expresión regular (string).
 * entrada La cadena a validar (string).
 * return bool Retorna true si la cadena coincide con el patrón, false en caso contrario.
 */
bool ValidarEntrada(string patron, string entrada) {
    return Regex.IsMatch(entrada, patron);
}

/*
 * Valida la letra de control del DNI español.
 * * dni El DNI completo (ej: 12345678A).
 * return bool Retorna true si la letra es correcta para el número.
 */
bool ValidarDniCompleto(string dni) {
    var letrasDni = "TRWAGMYFPDXBNJZSQVHLCKE";
    // La expresión regular ahora solo valida formato: 8 dígitos + 1 letra mayúscula (más robusto)
    var regexDniFormato = @"^(\d{8})([A-Z])$";

    // 1. Validar el formato base
    if (!Regex.IsMatch(dni, regexDniFormato)) {
        Log.Warning("Validación DNI fallida por formato (no 8 dígitos + 1 letra A-Z): '{Dni}'", dni);
        return false;
    }

    // 2. Extraer número y letra (ahora que sabemos que el formato es 8+1)
    var match = Regex.Match(dni, regexDniFormato);
    // Group[1] contiene los 8 dígitos, Group[2] contiene la letra
    var dniNumero = int.Parse(match.Groups[1].Value);
    var dniLetra = match.Groups[2].Value[0]; // Ya está en mayúscula por LeerDniValido

    // 3. Cálculo del módulo y de la letra esperada
    var indiceLetra = dniNumero % 23;
    var letraEsperada = letrasDni[indiceLetra];

    // 4. Comparamos
    var resultado = letraEsperada == dniLetra;

    if (!resultado)
        Log.Warning("Validación DNI fallida por letra. DNI: '{Dni}'. Esperada: '{Esperada}'.", dni, letraEsperada);

    return resultado;
}

// --------------------------------------------------------------------
// MÉTODOS DE BÚSQUEDA
// --------------------------------------------------------------------

/*
 * Encuentra el índice de un alumno basándose en su DNI.
 * Este método se mantiene para ser usado internamente por otras funciones.
 * * dni El DNI a buscar (string).
 * alumnos Vector de structs Alumno?
 * return int Retorna el índice del alumno o -1 si no se encuentra.
 */
int BuscarIndicePorDni(string dni, Alumno?[] alumnos) {
    for (var i = 0; i < alumnos.Length; i++)
        // Usamos la Opción 6 (?. ) por ser la más compacta.
        if (alumnos[i]?.Dni == dni)
            return i;

    return -1; // No encontrado
}

/*
 * Encuentra el índice de un alumno basándose en su ID.
 * Este método se mantiene para ser usado internamente por otras funciones.
 * * id El ID a buscar (int).
 * alumnos Vector de structs Alumno?
 * return int Retorna el índice del alumno o -1 si no se encuentra.
 */
int BuscarIndicePorId(int id, Alumno?[] alumnos) {
    for (var i = 0; i < alumnos.Length; i++)
        if (alumnos[i]?.Id == id)
            return i; // Devolvemos el índice 'i', no el 'id'.

    return -1; // No encontrado
}

/*
 * SOBRECARGA: Encuentra un alumno basándose en su DNI y devuelve la estructura Alumno? (o null).
 * Esto simplifica las funciones de consumo (MostrarInfo, Actualizar).
 * * dni El DNI a buscar (string).
 * * alumnos Vector de structs Alumno?
 * return Alumno? Retorna la estructura del alumno o null si no se encuentra.
 */
Alumno? BuscarAlumnoPorDni(string dni, Alumno?[] alumnos) {
    var indice = BuscarIndicePorDni(dni, alumnos);
    // Si se encuentra, devolvemos el valor de esa posición, que ya es un Alumno?
    return indice != -1 ? alumnos[indice] : null;
}

/*
 * SOBRECARGA: Encuentra un alumno basándose en su ID y devuelve la estructura Alumno? (o null).
 * Esto simplifica las funciones de consumo (MostrarInfo).
 * * id El ID a buscar (int).
 * * alumnos Vector de structs Alumno?
 * return Alumno? Retorna la estructura del alumno o null si no se encuentra.
 */
Alumno? BuscarAlumnoPorId(int id, Alumno?[] alumnos) {
    var indice = BuscarIndicePorId(id, alumnos);
    // Si se encuentra, devolvemos el valor de esa posición.
    return indice != -1 ? alumnos[indice] : null;
}


// --------------------------------------------------------------------
// MÉTODOS DE REFACTORIZACIÓN (Input/Output y Confirmación)
// --------------------------------------------------------------------

/*
 * Imprime los detalles de un único alumno de forma formateada.
 * Esta función evita repetir el bloque Console.WriteLine en MostrarInfo...
 * * alumno La estructura Alumno a mostrar.
 */
void ImprimirInfoAlumno(Alumno alumno) {
    AnsiConsole.MarkupLine("[aqua]-----------------------------------[/]");
    AnsiConsole.MarkupLine($"[bold]👤 ID:[/] [silver]{alumno.Id}[/]");
    AnsiConsole.MarkupLine($"[bold]💳 DNI:[/] [silver]{alumno.Dni}[/]");
    AnsiConsole.MarkupLine($"[bold]📝 Nombre:[/] [silver]{alumno.NombreCompleto}[/]");
    AnsiConsole.MarkupLine($"[bold]💯 Nota:[/] [silver]{alumno.Nota.ToString("F2", localeEs)}[/]");
    AnsiConsole.MarkupLine("[aqua]-----------------------------------[/]");
}

/*
 * Pide confirmación al usuario (S/s) para continuar con una operación.
 * * mensaje El mensaje de acción a confirmar.
 * return bool True si el usuario presiona 'S' o 's', false en caso contrario.
 */
bool PedirConfirmacion(string mensaje) {
    AnsiConsole.MarkupLine("\n[aqua]-----------------------------------[/]");
    AnsiConsole.MarkupLine($"[yellow]⚠️ {mensaje} Se requiere confirmación.[/]");
    // Usamos Spectre para confirmar
    var confirmado = AnsiConsole.Confirm(mensaje + " ¿Confirmar?");
    if (confirmado) {
        AnsiConsole.MarkupLine("[green]✅ Operación CONFIRMADA.[/]");
        return true;
    }

    AnsiConsole.MarkupLine("[red]🚫 Operación CANCELADA por el usuario.[/]");
    return false;
}

/*
 * Solicita una cadena al usuario y la valida contra un patrón Regex.
 * Esta función simplifica la lógica de los bucles de validación.
 * * prompt Mensaje a mostrar al usuario.
 * * regexPattern Patrón de expresión regular para validación.
 * * errorMsg Mensaje de error a mostrar si falla la validación.
 * return string La cadena validada y recortada.
 */
string LeerCadenaValidada(string prompt, string regexPattern, string errorMsg) {
    Log.Information("Solicitando entrada: '{Prompt}' con patrón '{Pattern}'", prompt, regexPattern);
    var input = "";
    // Usamos TextPrompt con validación integrada
    input = AnsiConsole.Prompt(
        new TextPrompt<string>(prompt)
            .Validate(val => Regex.IsMatch(val ?? "", regexPattern)
                ? ValidationResult.Success()
                : ValidationResult.Error(errorMsg))
    );

    Log.Warning("Validación de entrada: completada");
    return (input ?? "").Trim();
}

/*
 * Solicita un DNI y valida formato, letra de control y existencia/unicidad.
 * Esta función centraliza toda la lógica de entrada de DNI.
 * * alumnos Vector de alumnos.
 * * debeSerNuevo Si true, el DNI NO debe existir (para añadir). Si false, el DNI SÍ debe existir (para CRUD).
 * return string El DNI validado.
 */
string LeerDniValido(Alumno?[] alumnos, bool debeSerNuevo) {
    var dni = "";
    var dniValido = false;

    do {
        dni = AnsiConsole.Prompt(
            new TextPrompt<string>("DNI: ")
                .Validate(val => {
                    if (string.IsNullOrWhiteSpace(val))
                        return ValidationResult.Error("DNI no puede estar vacío.");
                    var v = val.ToUpper().Trim();
                    // Formato básico: 8 dígitos + letra (mayúscula)
                    if (!Regex.IsMatch(v, @"^\d{8}[A-Z]$"))
                        return ValidationResult.Error("Formato incorrecto. Debe ser 8 dígitos + letra (A-Z).");
                    // Validamos la letra con la función existente
                    return ValidarDniCompleto(v)
                        ? ValidationResult.Success()
                        : ValidationResult.Error("Letra de control incorrecta.");
                })
        );

        // Normalizamos a mayúsculas
        dni = dni.ToUpper();

        // Usamos la nueva función BuscarAlumnoPorDni para verificar existencia
        var alumnoExistente = BuscarAlumnoPorDni(dni, alumnos);
        var existe = alumnoExistente.HasValue;

        if (debeSerNuevo) {
            // Caso AÑADIR: Debe ser nuevo (NO debe existir)
            if (existe)
                AnsiConsole.MarkupLine("[red]❌ ERROR: Ya existe un alumno con ese DNI.[/]");
            else
                dniValido = true;
        }
        else {
            // Caso ACTUALIZAR/ELIMINAR/MOSTRAR: Debe existir
            if (!existe)
                // Una vez que el DNI pasa la validación de formato, comprobamos la existencia
                AnsiConsole.MarkupLine($"[red]❌ ERROR: Alumno con DNI {dni} no encontrado.[/]");
            else
                dniValido = true;
        }
    } while (!dniValido);

    return dni;
}

/*
 * Solicita la nota al usuario y valida que esté entre 0.00 y 10.00.
 * Usa el CultureInfo español para leer la coma decimal.
 * return double La nota validada.
 */
double LeerNotaValida() {
    // Patrón que acepta coma o punto como separador decimal.
    var regexNotaLocale = @"^(?:0([,.]\d{1,2})?|[1-9]([,.]\d{1,2})?|10([,.]0{1,2})?)$";

    Log.Information("Solicitando entrada: Nota con patrón '{Pattern}'", regexNotaLocale);
    var notaStr = AnsiConsole.Prompt(
        new TextPrompt<string>("Nota (0.00 - 10.00, use punto o coma para decimales: ")
            .Validate(val => Regex.IsMatch(val ?? "", regexNotaLocale)
                ? ValidationResult.Success()
                : ValidationResult.Error("La nota debe estar entre 0.00 y 10.00 y tener hasta dos decimales."))
    );

    // Reemplazamos la coma por punto para el parseo correcto.
    //notaStr = notaStr.Replace(',', '.');

    // El parseo original usaba float.Parse, lo cambiamos a double.Parse que es consistente con la struct.
    //return double.Parse(notaStr, NumberStyles.Float, localeEs);
    Log.Warning("Validación de nota: completada");
    double.TryParse(notaStr, NumberStyles.Float, CultureInfo.InvariantCulture, out var nota);
    return nota;
}

// --------------------------------------------------------------------
// GESTIÓN DE LA CAPACIDAD DEL VECTOR (Redimensionamiento)
// --------------------------------------------------------------------

/*
 * Copia los datos válidos de un vector a otro.
 * * origen Vector de structs? de origen.
 * destino Vector de structs? de destino.
 */
void CopiarVector(Alumno?[] origen, Alumno?[] destino) {
    // Log de Debug para la operación interna de copia
    Log.Debug("Iniciando copia de {OrigenLength} elementos a vector de {DestinoLength}",
        origen.Length, destino.Length);

    // Copiamos solo los elementos no nulos, simulando la compactación.
    var indiceDestino = 0;
    for (var i = 0; i < origen.Length; i++)
        // HasValue es un alias para '!= null'
        if (origen[i].HasValue) {
            destino[indiceDestino] = origen[i];
            indiceDestino++;
        }

    // Log de Debug para el resultado de la copia
    Log.Debug("Copia finalizada. Elementos válidos copiados: {Copiados}", indiceDestino);
}

/*
 * Redimensiona el vector de alumnos si se alcanza o supera el 80% de capacidad.
 * * alumnos Referencia al Vector de alumnos (necesita 'ref' para reasignación).
 * total Número actual de alumnos.
 */
void RedimensionarSiNecesario(ref Alumno?[] alumnos, int total) {
    // Usamos la división entera.
    var porcentajeUso = total * 100 / alumnos.Length;
    var tamanoActual = alumnos.Length;
    var nuevoTamano = tamanoActual + IncrementoTamano;

    // Condición de Expansión
    if (porcentajeUso >= PorcentajeExpansion) {
        // Log Warning para alertar sobre la necesidad de expansión
        Log.Warning("EXPANSION NECESARIA. Uso: {Uso}%. Expandiendo de {Actual} a {Nuevo}",
            porcentajeUso, tamanoActual, nuevoTamano);

        // 1. Crear nuevo vector
        var nuevoVector = new Alumno?[nuevoTamano];

        // 2. Copiar datos válidos del antiguo vector al nuevo
        CopiarVector(alumnos, nuevoVector);

        // 3. Asignar la referencia del nuevo vector (aquí es donde 'ref' es vital)
        alumnos = nuevoVector;
        // Log Information para el éxito de la expansión
        Log.Information("Expansión exitosa. Nuevo tamaño: {Nuevo}", nuevoTamano);
    }
}

/*
 * Reduce el vector de alumnos si el uso es inferior al 50% de la capacidad
 * y el tamaño actual es mayor que el inicial.
 * * alumnos Referencia al Vector de alumnos (necesita 'ref' para reasignación).
 * total Número actual de alumnos.
 */
void ReducirSiNecesario(ref Alumno?[] alumnos, int total) {
    var porcentajeUso = total * 100 / alumnos.Length;

    // Condición de Reducción
    if (alumnos.Length > TamanoInicial && porcentajeUso < PorcentajeReduccion) {
        var tamanoActual = alumnos.Length;
        var nuevoTamano = tamanoActual - IncrementoTamano;

        // Asegurar que el nuevo tamaño no sea menor al tamaño inicial
        if (nuevoTamano < TamanoInicial) nuevoTamano = TamanoInicial;

        // Log Warning para alertar sobre la necesidad de reducción
        Log.Warning("REDUCCION NECESARIA. Uso: {Uso}%. Reduciendo de {Actual} a {Nuevo}",
            porcentajeUso, tamanoActual, nuevoTamano);

        // 1. Crear nuevo vector
        var nuevoVector = new Alumno?[nuevoTamano];

        // 2. Copiar datos válidos (solo los que existen)
        CopiarVector(alumnos, nuevoVector);

        // 3. Asignar la referencia
        alumnos = nuevoVector;
        // Log Information para el éxito de la reducción
        Log.Information("Reducción exitosa. Nuevo tamaño: {Nuevo}", nuevoTamano);
    }
}

// --------------------------------------------------------------------
// CRUD Y OPERACIONES DE ALUMNO (Modificados con Confirmación)
// --------------------------------------------------------------------

/*
 * Añade un nuevo alumno al primer hueco libre.
 * Usa las nuevas funciones refactorizadas para la entrada de datos.
 * * alumnos Referencia al Vector de alumnos (para poder redimensionar).
 * total Referencia al contador de alumnos.
 */
void AnadirNuevoAlumno(ref Alumno?[] alumnos, ref int totalAlumnos) {
    AnsiConsole.MarkupLine("\n[bold aqua]--- AÑADIR NUEVO ALUMNO ---[/]");
    AnsiConsole.MarkupLine("[silver]Introduzca los datos del nuevo alumno:[/]");

    // 1. Lectura y Validación de DNI (debe ser nuevo)
    var dni = LeerDniValido(alumnos, true);

    // 2. Lectura y Validación de Nombre
    var nombre = LeerCadenaValidada(
        "Nombre Completo: ",
        RegexNombre,
        "Nombre inválido. Mínimo 3 caracteres, solo letras y espacios."
    );

    // 3. Lectura y Validación de Nota
    var nota = LeerNotaValida();

    // 4. Crear la nueva struct Alumno
    var nuevoAlumno = new Alumno {
        Id = NextIdAlumno(),
        Dni = dni,
        NombreCompleto = nombre,
        Nota = nota
    };

    // 5. Redimensionar antes de insertar si es necesario
    RedimensionarSiNecesario(ref alumnos, totalAlumnos);

    // 6. Insertar en el primer hueco libre
    for (var i = 0; i < alumnos.Length; i++)
        if (!alumnos[i].HasValue) // Si la posición es null (no tiene valor)
        {
            alumnos[i] = nuevoAlumno;
            totalAlumnos++; // total = total + 1;
            AnsiConsole.MarkupLine(
                $"[green]✅ INFO: Alumno (ID: {nuevoAlumno.Id}) añadido exitosamente en el índice {i}.[/]");
            return;
        }

    AnsiConsole.MarkupLine(
        "[red]❌ ERROR: No se pudo encontrar un hueco libre. Revisar lógica de redimensionamiento.[/]");
}

/*
 * Muestra la información de un alumno dado su DNI.
 * Usa la nueva función BuscarAlumnoPorDni para simplificar la lógica.
 * * alumnos Vector de structs Alumno?
 */
void MostrarInfoAlumnoPorDni(Alumno?[] alumnos) {
    AnsiConsole.MarkupLine("\n[bold aqua]--- INFORMACIÓN DE ALUMNO POR DNI ---[/]");

    // 1. Lectura y Validación de DNI (debe existir)
    var dni = LeerDniValido(alumnos, false);

    // 2. Usamos la nueva función que devuelve Alumno?
    var alumno = BuscarAlumnoPorDni(dni, alumnos);

    // 3. Uso de Pattern Matching si es != null lo desempaquetamos a alumnoValido
    // De esta manera el codigo es más limpio y claro (podemos hacer alumno is Alumno alumnoValido
    if (alumno is { } alumnoValido) {
        // Pattern Matching: si tiene valor, asigna a alumnoValido
        // Nota: ya no necesitamos buscar el índice para obtener el Alumno, solo para depuración
        var indice = BuscarIndicePorDni(dni, alumnos);
        AnsiConsole.MarkupLine($"\n[silver]🔍 INFO: Alumno encontrado (índice: {indice}).[/]");
        ImprimirInfoAlumno(alumnoValido);
    }
    else {
        // En teoría, este else nunca se debería alcanzar si LeerDniValido funciona correctamente.
        AnsiConsole.MarkupLine("[red]❌ ERROR Crítico: No se pudo recuperar el alumno después de la búsqueda.[/]");
    }
}

/*
 * Muestra la información de un alumno dado su ID.
 * Usa la nueva función BuscarAlumnoPorId para simplificar la lógica.
 * * alumnos Vector de structs Alumno?
 */
void MostrarInfoAlumnoPorId(Alumno?[] alumnos) {
    var regexId = @"^\d+$";

    AnsiConsole.MarkupLine("\n[bold aqua]--- INFORMACIÓN DE ALUMNO POR ID ---[/]");
    var idStr = LeerCadenaValidada("Introduzca el ID del alumno a buscar: ", regexId, "Formato de ID no válido.");

    // Conversión a entero
    var id = int.Parse(idStr);

    // Usamos la nueva función que devuelve Alumno?
    var alumno = BuscarAlumnoPorId(id, alumnos);

    // Uso de Pattern Matching si es!= null lo desempaquetamos a alumnoValido
    if (alumno is { } alumnoValido) {
        // Pattern Matching: si tiene valor, asigna a alumnoValido
        // Nota: ya no necesitamos buscar el índice para obtener el Alumno, solo para depuración
        var indice = BuscarIndicePorId(id, alumnos);
        AnsiConsole.MarkupLine($"\n[silver]🔍 INFO: Alumno encontrado (índice: {indice}).[/]");
        ImprimirInfoAlumno(alumnoValido);
    }
    else {
        AnsiConsole.MarkupLine($"[red]❌ ERROR: Alumno con ID {id} no encontrado.[/]");
    }
}

/*
 * Actualiza el nombre y la nota de un alumno existente
 * con MUESTRA DE DATOS ANTIGUOS/NUEVOS y CONFIRMACIÓN.
 * * alumnos Vector de structs Alumno?
 */
void ActualizarDatosAlumno(Alumno?[] alumnos) {
    AnsiConsole.MarkupLine("\n[bold aqua]--- ACTUALIZAR ALUMNO ---[/]");
    AnsiConsole.MarkupLine("[silver]Introduzca el DNI del alumno cuyos datos desea actualizar:[/]");

    // 1. Lectura y Validación de DNI (debe existir)
    var dni = LeerDniValido(alumnos, false);

    // Usamos BuscarIndicePorDni porque necesitamos la POSICIÓN para modificar el array.
    var indice = BuscarIndicePorDni(dni, alumnos);

    // 2. Guardar datos antiguos y mostrarlos
    var alumnoAntiguo = alumnos[indice]!.Value; // Obtener la struct original no nula

    AnsiConsole.MarkupLine("\n[silver]--- DATOS ACTUALES (ANTIGUOS) ---[/]");
    ImprimirInfoAlumno(alumnoAntiguo);

    // 3. Recoger nuevos datos con validación
    AnsiConsole.MarkupLine($"\n[silver]✏️ Introduzca los nuevos datos para {alumnoAntiguo.NombreCompleto}:[/]");

    // quieres cambiar el nombre?
    var nombreActualizado = AnsiConsole.Confirm("¿Desea cambiar el nombre completo?")
        ? LeerCadenaValidada(
            "Nuevo Nombre Completo: ",
            RegexNombre,
            "Nombre inválido. Mínimo 3 caracteres, solo letras y espacios."
        )
        : alumnoAntiguo.NombreCompleto;


    // quieres cambiar la nota?
    var notaActualizada = AnsiConsole.Confirm("¿Desea cambiar la nota?")
        ? LeerNotaValida()
        : alumnoAntiguo.Nota;
    

    // 4. Crear el registro PROPUESTO con los datos nuevos (para mostrar la vista previa)
    var alumnoNuevo = new Alumno {
        Id = alumnoAntiguo.Id, // Mantenemos el mismo ID
        Dni = alumnoAntiguo.Dni, // Mantenemos el mismo DNI
        NombreCompleto = nombreActualizado,
        Nota = notaActualizada
    };

    // 5. Mostrar los datos propuestos
    AnsiConsole.MarkupLine("\n[silver]--- DATOS PROPUESTOS (NUEVOS) ---[/]");
    ImprimirInfoAlumno(alumnoNuevo);

    // 6. Pedir confirmación antes de aplicar
    if (PedirConfirmacion($"Actualizar el alumno {alumnoAntiguo.NombreCompleto} (ID: {alumnoAntiguo.Id})")) {
        // 7. Si confirma, aplicar la modificación
        alumnos[indice] = alumnoNuevo; // Reasignar la copia modificada
        AnsiConsole.MarkupLine($"\n[green]✅ INFO: Datos del alumno con DNI {dni} actualizados con éxito.[/]");
    }
    else {
        AnsiConsole.MarkupLine(
            $"\n[red]🚫 CANCELADO: Actualización de datos para {dni} cancelada. Los datos antiguos se mantienen.[/]");
    }
}

/*
 * ACTUALIZADO: Elimina un alumno del vector con MUESTRA DE DATOS y CONFIRMACIÓN.
 * * alumnos Referencia al Vector de alumnos (para poder reducir).
 * total Referencia al contador de alumnos.
 */
void EliminarAlumnoPorDni(ref Alumno?[] alumnos, ref int total) {
    AnsiConsole.MarkupLine("\n[bold aqua]--- ELIMINAR ALUMNO ---[/]");

    AnsiConsole.MarkupLine("[silver]Introduzca el DNI del alumno a eliminar:[/]");
    // Validamos que el DNI exista (false: debe existir)
    var dni = LeerDniValido(alumnos, false);

    var indice = BuscarIndicePorDni(dni, alumnos);

    if (indice != -1) {
        var alumnoAEliminar = alumnos[indice]!.Value; // Obtener la struct antes de borrar

        // 1. Mostrar datos a eliminar
        AnsiConsole.MarkupLine("\n[silver]--- ALUMNO A ELIMINAR PERMANENTEMENTE ---[/]");
        ImprimirInfoAlumno(alumnoAEliminar);

        // 2. Pedir confirmación
        if (PedirConfirmacion(
                $"Eliminar permanentemente al alumno {alumnoAEliminar.NombreCompleto} (ID: {alumnoAEliminar.Id})")) {
            // 3. Si confirma, eliminar y reducir
            alumnos[indice] = null; // Borrado (NULL)
            total--;
            AnsiConsole.MarkupLine($"[green]✅ INFO: Alumno con DNI {dni} eliminado (posición {indice}).[/]");

            // Intentar reducir el tamaño del vector si es necesario
            ReducirSiNecesario(ref alumnos, total);
        }
        else {
            // 4. Si cancela, no hacer nada
            AnsiConsole.MarkupLine($"[red]\n🚫 CANCELADO: Eliminación del alumno con DNI {dni} cancelada.[/]");
        }
    }
    else {
        // En teoría, este else nunca se debería alcanzar si LeerDniValido funciona correctamente.
        AnsiConsole.MarkupLine($"[red]❌ ERROR: Alumno con DNI {dni} no encontrado. Revisa la lógica.[/]");
    }
}

// --------------------------------------------------------------------
// ORDENAMIENTO Y LISTADO (USANDO BUBBLE SORT DE STRUCTS)
// --------------------------------------------------------------------

/*
 * Muestra la lista de alumnos, ordenada por DNI (default) o Nota (desc).
 * * alumnos Vector de structs Alumno? de alumnos.
 * total Número actual de alumnos.
 * ordenamiento Tipo de ordenamiento a aplicar.
 */
void ListarAlumnos(Alumno?[] alumnos, int total, TipoOrdenamiento ordenamiento = TipoOrdenamiento.Dni) {
    AnsiConsole.MarkupLine("\n[bold aqua]--- LISTADO DE ALUMNOS ---[/]");

    if (total == 0) {
        AnsiConsole.MarkupLine("[yellow]⚠️ INFO: No hay alumnos registrados.[/]");
        return;
    }

    // 1. Obtener una copia compacta de los datos válidos
    var vectorAOrdenar = ObtenerVectorCompacto(alumnos, total);

    // 2. Ordenar el vector (usando Bubble Sort)
    OrdenarVectorAlumnos(vectorAOrdenar, ordenamiento);

    // 3. Imprimir el resultado
    ImprimirListado(vectorAOrdenar);
}

/*
 * Realiza una copia coherente de los datos válidos a un vector auxiliar de structs.
 * * alumnos Vector de structs? de origen.
 * total Número actual de alumnos.
 * return Alumno[] Vector de structs Alumno sin nulos.
 */
Alumno[] ObtenerVectorCompacto(Alumno?[] alumnos, int total) {
    // ⬅️ Nuevo Log de Debug para la compactación
    Log.Debug("Iniciando ObtenerVectorCompacto: Preparando {Total} elementos válidos de un array de {Length}",
        total,
        alumnos.Length);

    if (total == 0)
        return new Alumno[0]; // Creamos un array vacío.

    // 1. Crear vector auxiliar con el tamaño exacto
    var vectorCompacto = new Alumno[total];

    // 2. Copiar solo los elementos no nulos
    var auxIndex = 0;
    for (var i = 0; i < alumnos.Length; i++)
        // Pattern Matching: si tiene un valor, asigna ese valor a 'alumnoValido'
        if (alumnosData[i] is { } alumnoValido) {
            vectorCompacto[auxIndex] = alumnoValido; // Asignación directa
            auxIndex++;
        }

    Log.Debug("Vector compacto creado con {Copiados} elementos listos para ordenar.", auxIndex);

    return vectorCompacto;
}

/*
 * Implementación de Bubble Sort para ordenar un vector de structs Alumno.
 * * alumnos El vector de structs Alumno a ordenar.
 * ordenamiento Tipo de ordenamiento (Dni o Nota).
 */
void OrdenarVectorAlumnos(Alumno[] alumnosArr, TipoOrdenamiento ordenamiento = TipoOrdenamiento.Dni) {
    var n = alumnosArr.Length;
    if (n <= 1) return;

    // ⬅️ Nuevo Log de Debug para el inicio del ordenamiento
    Log.Debug("Iniciando OrdenarVectorAlumnos ({Tipo}): {N} elementos", ordenamiento, n);

    for (var i = 0; i < n - 1; i++) {
        for (var j = 0; j < n - i - 1; j++) {
            var debeIntercambiar = false;
            var alumnoJ = alumnosArr[j];
            var alumnoJ1 = alumnosArr[j + 1];

            if (ordenamiento == TipoOrdenamiento.Dni) {
                // Ordenar por DNI (Ascendente). CompareTo > 0 significa que alumnoJ es lexicográficamente mayor.
                // Se usa así porque noe s un número sino una cadena: string
                if (alumnoJ.Dni.CompareTo(alumnoJ1.Dni) > 0) debeIntercambiar = true;
            }
            else if (ordenamiento == TipoOrdenamiento.Nota) {
                // Ordenar por Nota (Descendente). Si la nota actual es MENOR que la siguiente, debe intercambiarse.
                if (alumnoJ.Nota < alumnoJ1.Nota) debeIntercambiar = true;
            }

            if (debeIntercambiar)
                // Usamos swap de tuplas para simplificar el intercambio
                (alumnosArr[j], alumnosArr[j + 1]) = (alumnosArr[j + 1], alumnosArr[j]);
        }
    }

    // Opcional: Log de Debug para el fin del ordenamiento
    Log.Debug("Ordenamiento finalizado.");
}

/*
 * Muestra el listado de alumnos a partir del vector de structs ordenado,
 * incluyendo el ID.
 * * alumnos Vector de structs Alumno ordenado.
 */
void ImprimirListado(Alumno[] alumnos) {
    // Hemos añadido una columna para el ID
    var table = new Table();
    table.Border = TableBorder.Rounded;
    table.AddColumn(new TableColumn("[u]ID[/]").Centered());
    table.AddColumn(new TableColumn("[u]DNI[/]").Centered());
    table.AddColumn(new TableColumn("[u]Nombre[/]").Centered());
    table.AddColumn(new TableColumn("[u]Nota[/]").Centered());

    for (var i = 0; i < alumnos.Length; i++) {
        var alumno = alumnos[i];
        table.AddRow(
            $"[silver]{alumno.Id}[/]",
            $"[silver]{alumno.Dni}[/]",
            $"[silver]{alumno.NombreCompleto}[/]",
            $"[silver]{alumno.Nota.ToString("F2", localeEs)}[/]");
    }

    AnsiConsole.Write(table);
}

/*
 * Calcula y muestra el número de aprobados, suspensos y la nota media.
 * * alumnos Vector de structs Alumno? de alumnos.
 * total Número actual de alumnos.
 */
void MostrarEstadisticas(Alumno?[] alumnos, int total) {
    AnsiConsole.MarkupLine("\n[bold aqua]--- ESTADÍSTICAS DEL ALUMNADO ---[/]");
    if (total == 0) {
        AnsiConsole.MarkupLine("[yellow]⚠️ INFO: No hay alumnos para calcular estadísticas.[/]");
        return;
    }

    var totalNotas = 0.0;
    var aprobados = 0;
    var suspensos = 0;

    // Se recorre el vector principal directamente
    for (var i = 0; i < alumnos.Length; i++)
        // Pattern Matching para evitar nulls y asignacion directa a 'alumno'
        if (alumnos[i] is { } alumno) {
            totalNotas += alumno.Nota;
            if (alumno.Nota >= NotaAprobado) // Criterio de aprobado (constante 5.00m)
                aprobados = aprobados + 1;
            else
                suspensos = suspensos + 1;
        }

    // División con decimal para mantener la precisión
    var notaMedia = totalNotas / total;
    var notaMediaStr = notaMedia.ToString("F2", localeEs);

    AnsiConsole.MarkupLine($"[silver]📊 Alumnos totales: {total}[/]");
    AnsiConsole.MarkupLine($"[silver]🎖️ Aprobados (Nota >= {NotaAprobado.ToString("F2", localeEs)}): {aprobados}[/]");
    AnsiConsole.MarkupLine($"[silver]Porcentaje Aprobados: {(aprobados * 100.0 / total).ToString("F2", localeEs)}%[/]");
    AnsiConsole.MarkupLine($"[silver]🔴 Suspensos (Nota < {NotaAprobado.ToString("F2", localeEs)}): {suspensos}[/]");
    AnsiConsole.MarkupLine($"[silver]Porcentaje Suspensos: {(suspensos * 100.0 / total).ToString("F2", localeEs)}%[/]");
    AnsiConsole.MarkupLine($"[bold]⭐ Nota Media: {notaMediaStr}[/]");
}