using Math;

// ====================================================================
// GESTIÓN DE ALUMNOS - CONSTANTES DEL SISTEMA
// ====================================================================

// --- Estructura Principal de Datos ---
struct Alumno {
    int id; // Identificador único del alumno (autoincremental)
    string dni; // Clave primaria
    string nombreCompleto;
    decimal nota; 
}

// --- Constantes del Sistema ---
const int TAMANO_INICIAL = 10;
const int INCREMENTO_TAMANO = 10;
const int PORCENTAJE_EXPANSION = 80;
const int PORCENTAJE_REDUCCION = 50;
const decimal NOTA_APROBADO = 5.00; // Criterio de aprobado
const string LETRAS_DNI = "TRWAGMYFPDXBNJZSQVHLCKE";

// --- Constantes del Menú ---
const int OPCION_LISTAR_TODOS = 1;
const int OPCION_INFO_ID = 2;
const int OPCION_INFO_DNI = 3;
const int OPCION_ANADIR = 4;
const int OPCION_ACTUALIZAR = 5;
const int OPCION_ELIMINAR = 6;
const int OPCION_LISTAR_NOTAS = 7;
const int OPCION_ESTADISTICAS = 8;
const int OPCION_SALIR = 0;
const int MAX_OPCION = 8;

int idAlumnoContador = 0; // OJO el unico caso que usamos variable global sin que sea constante

// --- Constantes de Regex (@ para string de expresión literal) ---

// ID: Solo dígitos, no vacío
const string REGEX_ID = @"^\d+$";
// DNI: 8 dígitos + 1 letra mayúscula
const string REGEX_DNI = @"^\d{8}[" + LETRAS_DNI + "]$"; 
// Nombre: Al menos 3 caracteres, letras y espacios, no vacío
const string REGEX_NOMBRE = @"^[A-Za-zñÑáéíóúÁÉÍÓÚ\s]{3,}$";
// Nota: Número real entre 0.00 y 10.00 (permite 0, 5.0, 10.00)
// Se usa un regex robusto para validación de entrada
const string REGEX_NOTA = @"^(0(\.\d{1,2})?|[1-9](\.\d{1,2})?|10(\.0{1,2})?)$"; 
// Opciones de Menú: Un solo dígito entre 0 y 7
const string REGEX_OPCION_MENU = @"^[0-" + MAX_OPCION + "]$"; 


// Tipo de Orden
enum Orden {
   ASC, // Ascendente
   DESC // Descendente
}

// Tipo de Ordenamiento
enum TipoOrdenamiento {
    DNI,
    NOTA
}

// --------------------------------------------------------------------
// BLOQUE PRINCIPAL (Main)
// --------------------------------------------------------------------
Main {
    writeLine("Sistema de Gestión de Alumnos DAW");
    writeLine("==================================");
    
    // El vector principal ahora almacena estructuras de Alumno. 
    // Las posiciones nulas (null) indican huecos libres.
    Alumno?[] alumnosData = Alumno?[TAMANO_INICIAL]; 
    var numAlumnos = 0;
    var opcionStr = "";
    var opcion = -1;

    // Inicialización de datos de prueba
    inicializarDatos(alumnosData, ref numAlumnos);

    do {
        mostrarMenu(alumnosData.Length);
        
        // Validación de la opción de menú con Regex
        do {
            opcionStr = readLine("Seleccione una opción: ");
        } while (!validarEntrada(REGEX_OPCION_MENU, opcionStr));
        
        // Conversión a entero usando el casting explícito
        opcion = (int)opcionStr; 
        
        // El bucle principal delega la lógica a los procedimientos
        switch (opcion) {
            case OPCION_LISTAR_TODOS:
                listarAlumnos(alumnosData, numAlumnos, TipoOrdenamiento.DNI);
                break;
            case OPCION_INFO_ID:
                mostrarInfoAlumnoPorID(alumnosData);
                break;
            case OPCION_INFO_DNI:
                mostrarInfoAlumnoPorDNI(alumnosData);
                break;
            case OPCION_ANADIR:
                anadirNuevoAlumno(alumnosData, ref numAlumnos); // Necesita ref para alumnosData si hay redimensión
                break;
            case OPCION_ACTUALIZAR:
                actualizarDatosAlumno(alumnosData);
                break;
            case OPCION_ELIMINAR:
                eliminarAlumnoPorDNI(alumnosData, ref numAlumnos); // Necesita ref para alumnosData si hay reducción
                break;
            case OPCION_LISTAR_NOTAS:
                listarAlumnos(alumnosData, numAlumnos, TipoOrdenamiento.NOTA);
                break;
            case OPCION_ESTADISTICAS:
                mostrarEstadisticas(alumnosData, numAlumnos);
                break;
            case OPCION_SALIR:
                writeLine("Saliendo del programa. ¡Hasta pronto!");
                break;
            default:
                writeLine("Opción no válida. Intente de nuevo.");
                break;
        }
    } while (opcion != OPCION_SALIR);
}

// --------------------------------------------------------------------
// INICIALIZACIÓN Y UTILIDADES
// --------------------------------------------------------------------

/**
 * Inicializa el vector de alumnos con datos de prueba, usando structs.
 * alumnosData Vector de estructuras Alumno? (posiciones nulas para huecos libres).
 * num Referencia al contador de alumnos.
 */
procedure inicializarDatos(Alumno?[] alumnosData, ref int num) {
    // Inicialización de structs
    Alumno a1 = Alumno { id= nextIdAlumno(), dni = "12345678A", nombreCompleto = "Juan Pérez", nota = 8.50 };
    Alumno a2 = Alumno { id= nextIdAlumno(), dni = "87654321B", nombreCompleto = "Ana García", nota = 4.25 };
    Alumno a3 = Alumno { id= nextIdAlumno(), dni = "11111111C", nombreCompleto = "Carlos Ruiz", nota = 10.00 };
    
    // Asignación a las primeras posiciones del vector
    alumnosData[0] = a1;
    alumnosData[1] = a2;
    alumnosData[2] = a3;

    num = 3;
    writeLine("INFO: Datos de prueba inicializados. Alumnos activos: " + num);
}

/**
 * Muestra el menú de operaciones al usuario.
 * capacidad La capacidad actual del vector.
 */
procedure mostrarMenu(int capacidad) {
    writeLine("--- MENÚ DE OPERACIONES (Capacidad: " + capacidad + ") ---");
    writeLine(OPCION_LISTAR_TODOS + ". Listar todos los alumnos (Ordenado por DNI)");
    writeLine(OPCION_INFO_ID + ". Información de alumno por ID");
    writeLine(OPCION_INFO_DNI + ". Información de alumno por DNI");
    writeLine(OPCION_ANADIR + ". Añadir alumno");
    writeLine(OPCION_ACTUALIZAR + ". Actualizar alumno");
    writeLine(OPCION_ELIMINAR + ". Eliminar alumno");
    writeLine(OPCION_LISTAR_NOTAS + ". Listado ordenado por notas (Descendente)");
    writeLine(OPCION_ESTADISTICAS + ". Mostrar Estadísticas");
    writeLine(OPCION_SALIR + ". Salir");
    writeLine("---------------------------");
}

function nextIdAlumno() {
    idAlumnoContador = idAlumnoContador + 1;
    return idAlumnoContador;
}

/**
 * Valida una cadena de entrada usando una expresión regular.
 * patron El patrón de expresión regular (string).
 * entrada La cadena a validar (string).
 * Retorna true si la cadena coincide con el patrón, false en caso contrario.
 */
function bool validarEntrada(string patron, string entrada) {
    return Regex(patron, entrada).IsMatch;
}

/**
 * Valida la letra de control del DNI español.
 * dni El DNI completo (ej: 12345678A).
 * bool Retorna true si la letra es correcta para el número.
 */
function bool validarDniCompleto(string dni) {
    if (!validarEntrada(REGEX_DNI, dni)) {
        return false;
    }
    
    // 1. Extraer número y letra
    var dniNumeroStr = dni.Substring(0, 8);
    var dniLetra = dni.Substring(8, 1);
    
    // 2. Conversión a entero (casting explícito)
    var dniNumero = (int)dniNumeroStr;
    
    // 3. Cálculo del módulo y de la letra esperada
    var indiceLetra = dniNumero % 23;
    var letraEsperada = LETRAS_DNI[indiceLetra];
    
    return letraEsperada == dniLetra;
}

/**
 * Encuentra el índice de un alumno basándose en su DNI.
 * dni El DNI a buscar (string).
 * alumnosData Vector de structs Alumno?
 * int Retorna el índice del alumno o -1 si no se encuentra.
 */
function int buscarIndicePorDNI(string dni, Alumno?[] alumnosData) {
    for (int i = 0; i < alumnosData.Length; i++) {
        // Accedemos directamente al campo 'dni' de la struct
        if (alumnosData[i] != null && alumnosData[i].dni == dni) { 
            return i;
        }
    }
    return -1; // No encontrado
}

function int buscarIndicePorID(int id, Alumno?[] alumnosData) {
    for (int i = 0; i < alumnosData.Length; i++) {
        // Accedemos directamente al campo 'id' de la struct
        if (alumnosData[i] != null && alumnosData[i].id == id) { 
            return i;
        }
    }
    return -1; // No encontrado
}

/**
 * Formatea una nota real a un string con exactamente dos decimales (ej: 8.5 -> "8.50").
 * @param nota Nota real (0.00 a 10.00).
 * @return string Nota formateada.
 */
function string formatearNota(decimal nota, int decimales = 2) {
     // 1. Redondeo a dos decimales
    var factor = Math.Pow(10, decimales);
    // obtenemos el número redondeado entero con el casting a int
    var roundedValue = (int)(nota * factor);
    // devolvemos el número redondeado como decimal como string
    var finalValue = (decimal)roundedValue / factor;
    return "" + finalValue;
}

// --------------------------------------------------------------------
// GESTIÓN DE LA CAPACIDAD DEL VECTOR (Redimensionamiento)
// --------------------------------------------------------------------

/**
 * Copia los datos válidos de un vector a otro.
 * @param origen Vector de structs? de origen.
 * @param destino Vector de structs? de destino.
 */
procedure copiarVector(Alumno?[] origen, Alumno?[] destino) {
    // Copia de datos válidos (structs completas) del origen al destino
    var indiceDestino = 0;
    for (int i = 0; i < origen.Length; i++) {
        if (origen[i] != null) {
            destino[indiceDestino] = origen[i];
            indiceDestino = indiceDestino + 1; 
            //indiceDestino =+ 1;
            //indiceDestino ++;
        }
    }
}

/**
 * Redimensiona el vector de alumnos si se alcanza o supera el 80% de capacidad.
 * @param alumnosData Vector de alumnos.
 * @param numAlumnos Número actual de alumnos.
 */
procedure redimensionarSiNecesario(Alumno?[] alumnosData, int numAlumnos) {
    var porcentajeUso = (numAlumnos * 100) /  alumnosData.Length;
    
    // Condición de Expansión: 80% o más de uso
    if (porcentajeUso >= PORCENTAJE_EXPANSION) {
        var nuevoTamano = alumnosData.Length + INCREMENTO_TAMANO;
        writeLine("[REDIMENSIONAMIENTO]: Capacidad usada: " + porcentajeUso + "%. Expandiendo de " + tamanoActual + " a " + nuevoTamano);
        
        // 1. Crear nuevo vector
        Alumno? nuevoVector = Alumno?[nuevoTamano];
        
        // 2. Copiar datos del antiguo vector al nuevo (pasamos nuevoVector)
        copiarVector(alumnosData, nuevoVector); 
        
        // 3. Asignar la referencia del nuevo vector (necesitamos el 'ref' en la firma de la procedure)
        alumnosData = nuevoVector;
        writeLine("[REDIMENSIONAMIENTO]: ¡Expansión exitosa!");
    }
}

/**
 * Reduce el vector de alumnos si el uso es inferior al 50% de la capacidad
 * y el tamaño actual es mayor que el inicial.
 * @param alumnosData Vector de alumnos.
 * @param numAlumnos Número actual de alumnos.
 */
procedure reducirSiNecesario(Alumno?[] alumnosData, int numAlumnos) {
    var porcentajeUso = (numAlumnos * 100) / alumnosData.Length;
    
    // Condición de Reducción: Menos del 50% de uso Y el tamaño es mayor al inicial (10)
    if (alumnosData.Length > TAMANO_INICIAL && porcentajeUso < PORCENTAJE_REDUCCION) {
        var nuevoTamano = alumnosData.Length - INCREMENTO_TAMANO;
        
        // Asegurar que el nuevo tamaño no sea menor al tamaño inicial
        if (nuevoTamano < TAMANO_INICIAL) {
            nuevoTamano = TAMANO_INICIAL;
        }
        
        writeLine("[REDIMENSIONAMIENTO]: Capacidad usada: " + porcentajeUso + "%. Reduciendo de " + tamanoActual + " a " + nuevoTamano);
        
        // 1. Crear nuevo vector
        Alumno? nuevoVector = Alumno?[nuevoTamano];
        
        // 2. Copiar datos válidos (solo los que existen)
        copiarVector(alumnosData, nuevoVector);
        
        // 3. Asignar la referencia
        alumnosData = nuevoVector;
        writeLine("[REDIMENSIONAMIENTO]: ¡Reducción exitosa!");
    }
}

// --------------------------------------------------------------------
// CRUD Y OPERACIONES DE ALUMNO
// --------------------------------------------------------------------

/**
 * Añade un nuevo alumno al primer hueco libre.
 * @param alumnosData Vector de alumnos.
 * @param num Referencia al contador de alumnos.
 */
procedure anadirNuevoAlumno(Alumno?[] alumnosData, ref int totalAlumnos) {
    writeLine("--- AÑADIR NUEVO ALUMNO ---");
    var dni = "";
    var nombre = "";
    var notaStr = "";
    
    writeLine("Introduzca los datos del nuevo alumno:");

    // --- 1. Validación DNI (Formato y Letra) ---
    var dniValido = false;
    do { 
        writeLine("DNI: ");
        dni = readLine().Trim();
        if (!validarDniCompleto(dni)) {
            writeLine("ERROR: DNI inválido. Asegúrese del formato y la letra de control.");
        } else {
            // Verificar unicidad del DNI
            if (buscarIndicePorDNI(dni, alumnosData) != -1) {
                writeLine("ERROR: Ya existe un alumno con ese DNI.");
            } else {
                dniValido = true;
            }
        }
    } while (!dniValido);

    // --- 2. Validación Nombre (No vacío y formato) ---
    var nombreValido = false;
    do {
      writeLine("Nombre Completo: ");
      nombre = readLine().Trim();
      if (!validarEntrada(REGEX_NOMBRE, nombre)) {
          writeLine("ERROR: Nombre inválido. Mínimo 3 caracteres, solo letras y espacios.");
      } else {
          nombreValido = true;
      }
    } while (!nombreValido);

    // --- 3. Validación Nota (Real 0.00 a 10.00) ---
    var validoNota = false;
    do { 
        writeLine("Nota (0.00 - 10.00): ");
        notaStr = readLine().Trim();
        if (!validarEntrada(REGEX_NOTA, notaStr)) {
            writeLine("ERROR: La nota debe estar entre 0.00 y 10.00 y tener hasta dos decimales.");
        } else {
            validoNota = true;
        }
    } while (!validoNota);

    var nota = (decimal)notaStr; // Conversión a real (decimal)

    // 4. Crear la nueva struct Alumno
    var nuevoAlumno = Alumno {
        id = nextIdAlumno(),
        dni = dni,
        nombreCompleto = nombre,
        nota = nota
    };

    // 5. Redimensionar antes de insertar si es necesario
    redimensionarSiNecesario(alumnosData, num);

    // 6. Insertar en el primer hueco libre
    for (int i = 0; i < alumnosData.Length; i++) {
        if (alumnosData[i] == null) {
            alumnosData[i] = nuevoAlumno;
            totalAlumnos = totalAlumnos + 1;
            writeLine("INFO: Alumno añadido exitosamente en el índice " + i + ".");
            return;
        }
    }
    writeLine("ERROR: No se pudo encontrar un hueco libre.");
}

/**
 * Muestra la información de un alumno dado su DNI.
 * @param alumnosData Vector de structs Alumno?
 */
procedure mostrarInfoAlumnoPorDNI(Alumno?[] alumnosData) {
    writeLine("--- INFORMACIÓN DE ALUMNO POR DNI ---");
    writeLine("Introduzca el DNI del alumno a buscar: ");
    var dni = readLine().Trim();

    if (!validarEntrada(REGEX_DNI, dni)) {
        writeLine("ERROR: Formato de DNI no válido.");
        return;
    }
    
    var indice = buscarIndicePorDNI(dni, alumnosData);
    
    if (indice != -1) {
        var alumno = alumnosData[indice];
        writeLine("\--- DATOS DE ALUMNO EN ÍNDICE " + indice + " ---");
        writeLine("ID: " + alumno.id);
        writeLine("DNI: " + alumno.dni);
        writeLine("Nombre: " + alumno.nombreCompleto);
        writeLine("Nota: " + formatearNota(alumno.nota));
    } else {
        writeLine("INFO: Alumno con DNI " + dni + " no encontrado.");
    }
}

procedure mostrarInfoAlumnoPorID(Alumno?[] alumnosData) {
    writeLine("--- INFORMACIÓN DE ALUMNO POR ID ---");
    writeLine("Introduzca el ID del alumno a buscar: ");
    var idStr = readLine().Trim();

    if (!validarEntrada(REGEX_ID, idStr)) {
        writeLine("ERROR: Formato de ID no válido.");
        return;
    }

    var id = (int)idStr; // Conversión a entero
    var indice = buscarIndicePorID(id, alumnosData);

    if (indice != -1) {
        var alumno = alumnosData[indice];
        writeLine("\--- DATOS DE ALUMNO EN ÍNDICE " + indice + " ---");
        writeLine("ID: " + alumno.id);
        writeLine("DNI: " + alumno.dni);
        writeLine("Nombre: " + alumno.nombreCompleto);
        writeLine("Nota: " + formatearNota(alumno.nota));
    } else {
        writeLine("INFO: Alumno con DNI " + dni + " no encontrado.");
    }
}

/**
 * Actualiza el nombre y la nota de un alumno existente.
 * @param alumnosData Vector de structs Alumno? (se pasa por valor, pero la posición es la misma)
 */
procedure actualizarDatosAlumno(Alumno?[] alumnosData) {
    writeLine("\--- ACTUALIZAR ALUMNO ---");
    var dni = "";
    var indice = -1;
    
    writeLine("Introduzca el DNI del alumno cuyos datos desea actualizar:");
    // 1. Validar y buscar DNI
    var dniValido = false;

    do { 
        writeLine("DNI: ");
        dni = readLine().Trim();
        if (!validarDniCompleto(dni)) {
            writeLine("ERROR: DNI inválido. Asegúrese del formato y la letra de control.");
        } else {
            indice = buscarIndicePorDNI(dni, alumnosData);
            if (indice == -1) {
                writeLine("ERROR: Alumno con DNI " + dni + " no encontrado.");
            } 
            // Esto es para ahorrar un else que verifica que el DNI es válido
            dniValido = (indice != -1);
        }
    } while (!dniValido);
    
    // 2. Recoger nuevos datos con validación
    var nombreActualizado = "";
    var notaStr = "";
    
    writeLine("Actualizando datos para " + dni + "...");

    // Validación Nombre
    var nombreValido = false;
    do { 
        writeLine("Nuevo Nombre Completo: ");
        nombreActualizado = readLine().Trim();
        if (!validarEntrada(REGEX_NOMBRE, nombreActualizado)) {
            writeLine("ERROR: Nombre inválido. Mínimo 3 caracteres, solo letras y espacios.");
        } else {
            nombreValido = true;
        }
    } while (!nombreValido);

    // Validación Nota
    var notaValida = false;
    do { 
        writeLine("Nueva Nota (0.00 - 10.00): ");
        notaStr = readLine().Trim();
        if (!validarEntrada(REGEX_NOTA, notaStr)) {
            writeLine("ERROR: La nota debe estar entre 0.00 y 10.00 y tener hasta dos decimales.");
        } else {
            notaValida = true;
        }
    } while (!notaValida);
    var notaActualizada = (decimal)notaStr; // Conversión a real (decimal)

    // 3. Modificar la struct directamente en el vector (no necesitamos crear una nueva)
    alumnosData[indice].nombreCompleto = nombreActualizado;
    alumnosData[indice].nota = notaActualizada;
    
    writeLine("INFO: Datos del alumno con DNI " + dni + " actualizados con éxito.");
}

/**
 * Elimina un alumno del vector, marcando su posición como nula.
 * @param alumnosData Vector de alumnos.
 * @param num Referencia al contador de alumnos.
 */
procedure eliminarAlumnoPorDNI(Alumno?[] alumnosData, ref int totalAlumnos) {
    writeLine("\--- ELIMINAR ALUMNO ---");
    
    writeLine("Introduzca el DNI del alumno a eliminar: ");
    var dni = readLine().Trim();

    if (!validarDniCompleto(dni)) {
        writeLine("ERROR: DNI no válido. Asegúrese del formato y la letra.");
        return;
    }
    
    var indice = buscarIndicePorDNI(dni, alumnosData);
    
    if (indice != -1) {
        alumnosData[indice] = null; // Borrado (NULL)
        totalAlumnos = totalAlumnos - 1;
        writeLine("INFO: Alumno con DNI " + dni + " eliminado (posición " + indice + ").");
        
        // Intentar reducir el tamaño del vector si es necesario
        reducirSiNecesario(alumnosData, totalAlumnos);
    } else {
        writeLine("ERROR: Alumno con DNI " + dni + " no encontrado.");
    }
}

// --------------------------------------------------------------------
// ORDENAMIENTO Y LISTADO (USANDO BUBBLE SORT DE STRUCTS)
// --------------------------------------------------------------------

/**
 * Realiza una copia coherente de los datos válidos a un vector auxiliar de structs.
 * @param alumnosData Vector de structs Alumno? de origen.
 * @param numAlumnos Número actual de alumnos.
 * @return Alumno[] Vector de structs Alumno sin nulos.
 */
function Alumno[] obtenerVectorCompacto(Alumno?[] alumnosData, int numAlumnos) {
    // Si no hay alumnos, retornamos un vector vacío.
    if (numAlumnos == 0) return Alumno[0];

    // 1. Crear vector auxiliar con el tamaño exacto
    Alumno[] vectorCompacto = Alumno[numAlumnos];
    var auxIndex = 0;
    
    // 2. Copiar solo los elementos no nulos
    copiarVector(alumnosData, vectorCompacto);
    
    return vectorCompacto;
}

/**
 * Implementación de Bubble Sort para ordenar un vector de structs Alumno.
 * @param alumnosArr Referencia al vector de structs Alumno a ordenar.
 * @param tipoOrden para DNI (Ascendente), para Nota (Descendente).
 */
procedure ordenarVectorAlumnos(Alumno[] alumnosArr, TipoOrdenamiento ordenamiento = TipoOrdenamiento.DNI) {
    var n = alumnosArr.Length;
    if (n <= 1) return;
    
    // Son burbujas para ordenar structs completas
    for (int i = 0; i < n - 1; i++) {
        for (int j = 0; j < n - i - 1; j++) {
            var debeIntercambiar = false;
            var alumnoJ = alumnosArr[j];
            var alumnoJ1 = alumnosArr[j + 1];

            if (ordenamiento == TipoOrden.DNI) { // Ordenar por DNI (Ascendente)
                // Comparación de strings lexicográfica
                if (alumnoJ.dni > alumnoJ1.dni) { 
                    debeIntercambiar = true;
                }
            } else if (ordenamiento == TipoOrden.NOTA) { // Ordenar por Nota (Descendente)
                // Comparación de reales, descendente
                if (alumnoJ.nota < alumnoJ1.nota) { 
                    debeIntercambiar = true;
                }
            }
            
            if (debeIntercambiar) {
                // Intercambio de la struct completa
                var tempAlumno = alumnosArr[j];
                alumnosArr[j] = alumnosArr[j + 1];
                alumnosArr[j + 1] = tempAlumno;
            }
        }
    }
}

/**
 * Muestra el listado de alumnos a partir del vector de structs ordenado.
 * @param alumnosArr Vector de structs Alumno ordenado.
 */
procedure imprimirListado(Alumno[] alumnosArr) {
    writeLine("--------------------------------------------------");
    writeLine("DNI -------- Nombre -------- Nota");
    writeLine("--------------------------------------------------");
    
    for (int i = 0; i < alumnosArr.Length; i++) {
        var alumno = alumnosArr[i];
        var notaStr = formatearNota(alumno.nota); // Asegura dos decimales
        write(alumno.dni + " | ");
        write(alumno.nombreCompleto + " | ");
        writeLine(notaStr);
    }
    writeLine("--------------------------------------------------");
}


/**
 * Lista todos los alumnos (opción 1 y 6 del menú).
 * @param alumnosData Vector de structs Alumno? de alumnos.
 * @param numAlumnos Número actual de alumnos.
 * @param tipoOrden 0 para DNI (Ascendente), 1 para Nota (Descendente).
 */
procedure listarAlumnos(Alumno?[] alumnosData, int numAlumnos, TipoOrdenamiento ordenamiento = TipoOrdenamiento.DNI) {
    if (numAlumnos == 0) {
        writeLine("No hay alumnos registrados.");
        return;
    }

    if (ordenamiento == TipoOrdenamiento.DNI) {
        writeLine("--- LISTADO DE ALUMNOS (ORDENADO POR DNI) ---");
    } else {
        writeLine("--- LISTADO DE ALUMNOS (ORDENADO POR NOTA DESC.) ---");
    }
    
    // 1. Obtener una copia compacta de los datos
    var alumnosCompactos = obtenerVectorCompacto(alumnosData, numAlumnos);
    
    // 2. Ordenar el vector compacto por referencia
    ordenarVectorAlumnos(alumnosCompactos, ordenamiento);
    
    // 3. Imprimir
    imprimirListado(alumnosCompactos);
}


// --------------------------------------------------------------------
// ESTADÍSTICAS
// --------------------------------------------------------------------

/**
 * Calcula y muestra el número de aprobados, suspensos y la nota media.
 * @param alumnosData Vector de structs Alumno? de alumnos.
 * @param numAlumnos Número actual de alumnos.
 */
procedure mostrarEstadisticas(Alumno?[] alumnosData, int numAlumnos) {
    writeLine("--- ESTADÍSTICAS DEL ALUMNADO ---");
    if (numAlumnos == 0) {
        writeLine("No hay alumnos para calcular estadísticas.");
        return;
    }
    
    var totalNotas = 0.0;
    var aprobados = 0;
    var suspensos = 0;
    
    // Se recorre el vector principal directamente
    for (int i = 0; i < alumnosData.Length; i++) {
        if (alumnosData[i] != null) {
            var nota = alumnosData[i].nota; // Acceso directo al campo nota de la struct
            
            totalNotas = totalNotas + nota;
            
            if (nota >= NOTA_APROBADO) { // Criterio de aprobado (constante 5.00)
                aprobados = aprobados + 1;
            } else {
                suspensos = suspensos + 1;
            }
        }
    }
    
    // La división de dos reales (decimal) produce un real (decimal)
    var notaMedia = totalNotas / (decimal)numAlumnos; 
    var notaMediaStr = formatearNota(notaMedia);
    
    writeLine("Alumnos totales: " + numAlumnos);
    writeLine("Aprobados (Nota >= " + formatearNota(NOTA_APROBADO) + "): " + aprobados);
    writeLine("Suspensos (Nota < " + formatearNota(NOTA_APROBADO) + "): " + suspensos);
    writeLine("Nota Media: " + notaMediaStr);
}
