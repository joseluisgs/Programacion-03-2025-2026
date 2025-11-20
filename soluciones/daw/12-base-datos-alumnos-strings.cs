using Math; // Incluye funciones como Math.Regex, Math.Round, etc.

// ====================================================================
// GESTIÓN DE ALUMNOS - CONSTANTES DEL SISTEMA
// El formato de registro es: DNI;Nombre Completo;Nota
// ====================================================================

// --- Constantes del Sistema ---
const int TAMANO_INICIAL = 10;
const int INCREMENTO_TAMANO = 10;
const int PORCENTAJE_EXPANSION = 80;
const int PORCENTAJE_REDUCCION = 50;
const string LETRAS_DNI = "TRWAGMYFPDXBNJZSQVHLCKE";

// --- Constantes del Menú ---
const int OPCION_LISTAR_TODOS = 1;
const int OPCION_INFO_DNI = 2;
const int OPCION_ANADIR = 3;
const int OPCION_ACTUALIZAR = 4;
const int OPCION_ELIMINAR = 5;
const int OPCION_LISTAR_NOTAS = 6;
const int OPCION_ESTADISTICAS = 7;
const int OPCION_SALIR = 0;
const int MAX_OPCION = 7;

// --- Constantes de Regex (@ para string de expresión literal) ---
// DNI: 8 dígitos + 1 letra mayúscula
const string REGEX_DNI = @"^\d{8}[A-Z]$"; 
// Nombre: Al menos 3 caracteres, letras y espacios, no vacío
const string REGEX_NOMBRE = @"^[A-Za-zñÑáéíóúÁÉÍÓÚ\s]{3,}$";
// Nota: Número real entre 0.00 y 10.00 (permite 0, 5.0, 10.00)
const string REGEX_NOTA = @"^(([0-9]|10)(\.\d{1,2})?)$"; 
// Opciones de Menú: Un solo dígito entre 0 y 7
const string REGEX_OPCION_MENU = @"^[0-" + MAX_OPCION + "]$"; 


// --------------------------------------------------------------------
// BLOQUE PRINCIPAL (Main)
// --------------------------------------------------------------------
Main {
    writeLine("Sistema de Gestión de Alumnos DAW");
    writeLine("==================================");
    
    // Variables de almacenamiento (locales al Main, pasadas por referencia)
    var alumnosData = string?[TAMANO_INICIAL]; // Vector de strings? (posiciones nulas para huecos libres)
    var numAlumnos = 0;
    var opcionStr = "";
    var opcion = -1;

    // Inicialización de datos de prueba
    inicializarDatos(alumnosData, ref numAlumnos);

    while (opcion != OPCION_SALIR) {
        mostrarMenu(alumnosData.Length);
        
        // Validación de la opción de menú con Regex
        do {
            opcionStr = readLine("Seleccione una opción: ");
        } while (!validarEntrada(REGEX_OPCION_MENU, opcionStr));
        
        // Conversión a entero usando el casting explícito de DAW
        opcion = (int)opcionStr; 
        
        // El bucle principal delega la lógica a los procedimientos
        switch (opcion) {
            case OPCION_LISTAR_TODOS:
                listarAlumnosPorDNI(alumnosData, numAlumnos);
                break;
            case OPCION_INFO_DNI:
                mostrarInfoAlumnoPorDNI(alumnosData, numAlumnos);
                break;
            case OPCION_ANADIR:
                anadirNuevoAlumno(alumnosData, ref numAlumnos);
                break;
            case OPCION_ACTUALIZAR:
                actualizarDatosAlumno(alumnosData, numAlumnos);
                break;
            case OPCION_ELIMINAR:
                eliminarAlumnoPorDNI(alumnosData, ref numAlumnos);
                break;
            case OPCION_LISTAR_NOTAS:
                listarAlumnosPorNota(alumnosData, numAlumnos);
                break;
            case OPCION_ESTADISTICAS:
                mostrarEstadisticas(alumnosData, numAlumnos);
                break;
            case OPCION_SALIR:
                writeLine("\nSaliendo del programa. ¡Hasta pronto!");
                break;
            default:
                // Esta opción solo se ejecuta si el Regex falla, lo cual no debería ocurrir.
                writeLine("\nOpción no válida. Intente de nuevo.");
                break;
        }
    }
}

// --------------------------------------------------------------------
// INICIALIZACIÓN Y UTILIDADES
// --------------------------------------------------------------------

/**
 * Inicializa el vector de alumnos con datos de prueba.
 * alumnosData vector de strings? de alumnos. Es nulo en posiciones libres.
 * num Referencia al contador de alumnos.
 */
procedure inicializarDatos(string?[] alumnosData, ref int num) {
    // Se usan notas con decimales.
    alumnosData[0] = "12345678A;Juan Pérez;8.50";
    alumnosData[1] = "87654321B;Ana García;4.25";
    alumnosData[2] = "11111111C;Carlos Ruiz;10.00";
    alumnosData[3] = "22222222D;Laura Soto;6.88";
    num = 4;
    writeLine("INFO: Datos de prueba inicializados. Alumnos activos: " + num);
}

/**
 * Muestra el menú de operaciones al usuario.
 * capacidad La capacidad actual del vector.
 */
procedure mostrarMenu(int capacidad) {
    writeLine("\n--- MENÚ DE OPERACIONES (Capacidad: " + capacidad + ") ---");
    writeLine(OPCION_LISTAR_TODOS + ". Listar todos los alumnos (Ordenado por DNI)");
    writeLine(OPCION_INFO_DNI + ". Información de alumno por DNI");
    writeLine(OPCION_ANADIR + ". Añadir alumno");
    writeLine(OPCION_ACTUALIZAR + ". Actualizar alumno");
    writeLine(OPCION_ELIMINAR + ". Eliminar alumno");
    writeLine(OPCION_LISTAR_NOTAS + ". Listado ordenado por notas (Descendente)");
    writeLine(OPCION_ESTADISTICAS + ". Mostrar Estadísticas");
    writeLine(OPCION_SALIR + ". Salir");
    writeLine("---------------------------");
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
    var letraEsperada = LETRAS_DNI.Substring(indiceLetra, 1);
    
    return letraEsperada == dniLetra;
}

/**
 * Encuentra el índice de un alumno basándose en su DNI.
 * dni El DNI a buscar (string).
 * alumnosData Vector de strings? de alumnos.
 * int Retorna el índice del alumno o -1 si no se encuentra.
 */
function int buscarIndicePorDNI(string dni, string?[] alumnosData) {
    for (int i = 0; i < alumnosData.Length; i++) {
        if (alumnosData[i] != null) { 
            var registro = alumnosData[i];
            
            // Se usa string.Split para obtener el DNI
            var partes = registro.Split(';');
            var dniRegistro = partes[0]; 
            // Si coincide, retornar el índice
            if (dniRegistro == dni) {
                return i;
            }
        }
    }
    return -1; // No encontrado
}

/**
 * Busca un alumno por DNI y retorna el registro completo.
 * dni El DNI a buscar (string).
 * alumnosData Vector de strings? de alumnos.
 * string? Retorna el registro del alumno (string) o null si no existe.
 */
function string? buscarAlumnoPorDNI(string dni, string?[] alumnosData) {
    var indice = buscarIndicePorDNI(dni, alumnosData);
    if (indice != -1) {
        return alumnosData[indice];
    }
    return null; // Retorna nulo si no existe
}

/**
 * Formatea una nota real a un string con exactamente dos decimales (ej: 8.5 -> "8.50").
 * @param nota Nota real (0.00 a 10.00).
 * @return string Nota formateada.
 */
function string formatearNota(decimal nota) {
    // 1. Redondeo a dos decimales
    var factor = Math.Pow(10, 2);
    // obtenemos el número redondeado entero con el casting a int
    var roundedValue = (int)(nota * factor);
    // devolvemos el número redondeado como decimal como string
    var finalValue = (double)roundedValue / factor;
    return "" + finalValue;
}

/**
 * Crea un registro de alumno en formato string (DNI;Nombre;Nota).
 * dni DNI del alumno.
 * nombre Nombre completo.
 * nota Nota.
 * string Retorna el registro formateado.
 */
function string crearRegistroAlumno(string dni, string nombre, decimal nota) {
    var notaFormateada = formatearNota(nota);
    return dni + ";" + nombre + ";" + notaFormateada;
}

// --------------------------------------------------------------------
// GESTIÓN DE LA CAPACIDAD DEL VECTOR (Redimensionamiento)
// --------------------------------------------------------------------

/**
 * Copia los datos válidos de un vector a otro.
 * rigen Vector de strings? de origen.
 * destino Referencia al vector de strings? de destino.
 */
procedure copiarVector(string?[] origen, string?[] destino) {
    var indiceDestino = 0;
    
    if (destino.Length < origen.Length) {
        writeLine("ERROR: El vector destino es más pequeño que el origen en copiarVector.");
        return;
    }

    // Copia de datos válidos del origen al destino
    for (int i = 0; i < origen.Length; i++) {
        if (origen[i] != null) {
            destino[indiceDestino] = origen[i];
            indiceDestino = indiceDestino + 1;
        }
    }
}

/**
 * Redimensiona el vector de alumnos si se alcanza o supera el 80% de capacidad.
 * alumnosData Referencia al vector de alumnos.
 * numAlumnos Número actual de alumnos.
 */
procedure redimensionarSiNecesario(string?[] alumnosData, int numAlumnos) {
    var tamanoActual = alumnosData.Length;
    var porcentajeUso = (numAlumnos * 100) / tamanoActual;
    
    // Condición de Expansión: 80% o más de uso
    if (porcentajeUso >= PORCENTAJE_EXPANSION) {
        var nuevoTamano = tamanoActual + INCREMENTO_TAMANO;
        writeLine("[REDIMENSIONAMIENTO]: Capacidad usada: " + porcentajeUso + "%. Expandiendo de " + tamanoActual + " a " + nuevoTamano);
        
        // 1. Crear nuevo vector
        var nuevoVector = string?[nuevoTamano];
        
        // 2. Copiar datos del antiguo vector al nuevo
        copiarVector(alumnosData, ref nuevoVector); 
        
        // 3. Asignar la referencia del nuevo vector, cambiamos el original
        alumnosData = nuevoVector;
        writeLine("[REDIMENSIONAMIENTO]: ¡Expansión exitosa!");
    }
}

/**
 * Reduce el vector de alumnos si el uso es inferior al 50% de la capacidad
 * y el tamaño actual es mayor que el inicial.
 * alumnosData Referencia al vector de alumnos.
 * numAlumnos Número actual de alumnos.
 */
procedure reducirSiNecesario(string?[] alumnosData, int numAlumnos) {
    var tamanoActual = alumnosData.Length;
    var porcentajeUso = (numAlumnos * 100) / tamanoActual;
    
    // Condición de Reducción: Menos del 50% de uso Y el tamaño es mayor al inicial (10)
    if (tamanoActual > TAMANO_INICIAL && porcentajeUso < PORCENTAJE_REDUCCION) {
        var nuevoTamano = tamanoActual - INCREMENTO_TAMANO;
        
        // Asegurar que el nuevo tamaño no sea menor al tamaño inicial
        if (nuevoTamano < TAMANO_INICIAL) {
            nuevoTamano = TAMANO_INICIAL;
        }
        
        writeLine("\n[REDIMENSIONAMIENTO]: Capacidad usada: " + porcentajeUso + "%. Reduciendo de " + tamanoActual + " a " + nuevoTamano);
        
        // 1. Crear nuevo vector
        var nuevoVector = string?[nuevoTamano];
        
        // 2. Copiar datos válidos (solo los que existen)
        copiarVector(alumnosData, ref nuevoVector);
        
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
 * @param alumnosData Referencia al vector de alumnos.
 * @param num Referencia al contador de alumnos.
 */
procedure anadirNuevoAlumno(string?[] alumnosData, ref int num) {
    writeLine("--- AÑADIR NUEVO ALUMNO ---");
    var dni = "";
    var nombre = "";
    var notaStr = "";
    var nota = 0.0;
    
    // Validación DNI (Formato y Letra)
    var dniValido = false;
    do { 
        dni = readLine("DNI: ");
        if (!validarDniCompleto(dni)) {
            writeLine("ERROR: DNI inválido. Asegúrese del formato y la letra de control.");
        } else {
            dniValido = true;
        }
    } while (!dniValido);

    // Verificar unicidad del DNI
    if (buscarAlumnoPorDNI(dni, alumnosData) != null) {
        writeLine("ERROR: Ya existe un alumno con ese DNI.");
        return;
    }

    // Validación Nombre (No vacío y formato)
    var nombreValido = false;
    do { 
      nombre = readLine("Nombre Completo: ");
      if (!validarEntrada(REGEX_NOMBRE, nombre)) {
          writeLine("ERROR: Nombre inválido. Asegúrese del formato.");
      } else {
          nombreValido = true;
      }
    } while (!nombreValido);

    // Validación Nota (Real 0.00 a 10.00)
    var validoNota = false;
    do { 
        notaStr = readLine("Nota (0.00 - 10.00): ");
        if (!validarEntrada(REGEX_NOTA, notaStr)) {
            writeLine("ERROR: La nota debe estar entre 0.00 y 10.00 y tener hasta dos decimales.");
            continue;
        }
        if (nota < 0.00 || nota > 10.00) {
            writeLine("ERROR: La nota debe estar entre 0.00 y 10.00 y tener hasta dos decimales.");
        } else {
            validoNota = true;
        }
    } while (!validoNota);

    
    nota = (decimal)notaStr; // Conversión a real usando casting (decimal), validada por Regex

    var nuevoRegistro = crearRegistroAlumno(dni, nombre, nota);

    // 1. Redimensionar antes de insertar si es necesario
    redimensionarSiNecesario(alumnosData, num);

    // 2. Insertar en el primer hueco libre
    for (int i = 0; i < alumnosData.Length; i++) {
        if (alumnosData[i] == null) {
            alumnosData[i] = nuevoRegistro;
            num = num + 1;
            writeLine("INFO: Alumno añadido exitosamente en el índice " + i + ".");
            return;
        }
    }
    writeLine("ERROR: No se pudo encontrar un hueco libre.");
}

/**
 * Muestra la información de un alumno dado su DNI.
 * alumnosData Vector de strings? de alumnos.
 * numAlumnos Número actual de alumnos.
 */
procedure mostrarInfoAlumnoPorDNI(string?[] alumnosData, int numAlumnos) {
    writeLine("--- INFORMACIÓN DE ALUMNO POR DNI ---");
    var dni = readLine("DNI del alumno a buscar: ");
    
    if (!validarEntrada(REGEX_DNI, dni)) {
        writeLine("ERROR: Formato de DNI no válido.");
        return;
    }
    
    var registro = buscarAlumnoPorDNI(dni, alumnosData);
    
    if (registro != null) {
        writeLine("--- DATOS DE ALUMNO ---");
        writeLine("Registro: " + registro);
    } else {
        writeLine("INFO: Alumno con DNI " + dni + " no encontrado.");
    }
}

/**
 * Actualiza el nombre y la nota de un alumno existente.
 * alumnosData Referencia al vector de alumnos.
 * numAlumnos Número actual de alumnos.
 */
procedure actualizarDatosAlumno(string?[] alumnosData, int numAlumnos) {
    writeLine("\n--- ACTUALIZAR ALUMNO ---");
    var dni = "";
    var indice = -1;
    
    // 1. Validar y buscar DNI
    do { 
        dni = readLine("DNI del alumno a actualizar: ");
        if (!validarDniCompleto(dni)) {
            writeLine("ERROR: DNI inválido. Asegúrese del formato y la letra de control.");
            continue;
        }
        indice = buscarIndicePorDNI(dni, alumnosData);
        if (indice == -1) {
            writeLine("ERROR: Alumno con DNI " + dni + " no encontrado.");
        }
    } while (indice == -1);
    
    // 2. Recoger nuevos datos con validación
    var nombreActualizado = "";
    var notaStr = "";
    var notaActualizada = 0.0;
    
    writeLine("Actualizando datos para " + dni + "...");

    // Validación Nombre
    var nombreValido = false;
    do { 
      nombreActualizado = readLine("Nuevo Nombre Completo: ");
      if (!validarEntrada(REGEX_NOMBRE, nombreActualizado)) {
          writeLine("ERROR: Nombre inválido. Asegúrese del formato.");
      } else {
          nombreValido = true;
      }
    } while (!nombreValido);

    // Validación Nota
    var notaValida = false;
    do { 
        notaStr = readLine("Nueva Nota (0.00-10.00): ");
        if (!validarEntrada(REGEX_NOTA, notaStr)) {
            writeLine("ERROR: La nota debe estar entre 0.00 y 10.00 y tener hasta dos decimales.");
        } else {
            notaValida = true;
        }
    } while (!notaValida);
    notaActualizada = (decimal)notaStr; // Conversión a real usando casting (decimal)

    // 3. Generar nuevo registro y actualizar
    var nuevoRegistro = crearRegistroAlumno(dni, nombreActualizado, notaActualizada);
    alumnosData[indice] = nuevoRegistro;
    
    writeLine("INFO: Datos del alumno con DNI " + dni + " actualizados con éxito.");
}

/**
 * Elimina un alumno del vector, marcando su posición como nula.
 * alumnosData Referencia al vector de alumnos.
 * num Referencia al contador de alumnos.
 */
procedure eliminarAlumnoPorDNI(string?[] alumnosData, ref int num) {
    writeLine("\n--- ELIMINAR ALUMNO ---");
    var dni = readLine("DNI del alumno a eliminar: ");

    if (!validarDniCompleto(dni)) {
        writeLine("ERROR: DNI no válido. Asegúrese del formato y la letra.");
        return;
    }
    
    var indice = buscarIndicePorDNI(dni, alumnosData);
    
    if (indice != -1) {
        alumnosData[indice] = null; // Borrado (NULL)
        num = num - 1;
        writeLine("INFO: Alumno con DNI " + dni + " eliminado (posición " + indice + ").");
        
        // Intentar reducir el tamaño del vector si es necesario
        reducirSiNecesario(ref alumnosData, num);
    } else {
        writeLine("ERROR: Alumno con DNI " + dni + " no encontrado.");
    }
}

// --------------------------------------------------------------------
// ORDENAMIENTO Y LISTADO
// --------------------------------------------------------------------

/**
 * Realiza una copia coherente de los datos válidos a vectores auxiliares.
 * alumnosData Vector de strings? de alumnos.
 * numAlumnos Número actual de alumnos.
 * @dniArr Referencia al vector de DNI.
 * ombreArr Referencia al vector de Nombres.
 * @notaArr Referencia al vector de Notas.
 */
procedure obtenerVectoresAuxiliares(string?[] alumnosData, int numAlumnos, string[] dniArr, string[] nombreArr, ref real[] notaArr) {
    // Inicializar vectores auxiliares con el tamaño exacto de alumnos activos
    dniArr = string[numAlumnos];
    nombreArr = string[numAlumnos];
    notaArr = real[numAlumnos];
    
    var auxIndex = 0;
    // Creamos los vectores paralelos o auxiliares
    for (int i = 0; i < alumnosData.Length; i++) {
        if (alumnosData[i] != null) {
            var registro = alumnosData[i];
            var partes = registro.Split(';');
            
            // Conversión de NotaStr a real usando casting explícito (decimal)
            dniArr[auxIndex] = partes[0];
            nombreArr[auxIndex] = partes[1];
            notaArr[auxIndex] = (decimal)partes[2]; 
            
            auxIndex = auxIndex + 1;
        }
    }
}

/**
 * Implementación de Bubble Sort para ordenar vectores paralelos.
 * dniArr Referencia al vector de DNI.
 * nombreArr Referencia al vector de Nombres.
 * notaArr Referencia al vector de Notas.
 * tipoOrden 0 para DNI (Ascendente), 1 para Nota (Descendente).
 */
procedure ordenarVectoresParalelos(ref string[] dniArr, ref string[] nombreArr, ref real[] notaArr, int tipoOrden = 0) {
    var n = dniArr.Length;
    if (n <= 1) return;
    
    // Son burbujas para ordenar los vectores paralelos
    for (int i = 0; i < n - 1; i++) {
        for (int j = 0; j < n - i - 1; j++) {
            var debeIntercambiar = false;

            if (tipoOrden == 0) { // Ordenar por DNI (Ascendente)
                // Comparación de strings lexicográfica
                if (dniArr[j] > dniArr[j + 1]) { 
                    debeIntercambiar = true;
                }
            } else if (tipoOrden == 1) { // Ordenar por Nota (Descendente)
                // Comparación de reales, descendente
                if (notaArr[j] < notaArr[j + 1]) { 
                    debeIntercambiar = true;
                }
            }
            
            if (debeIntercambiar) {
                // Intercambio de DNI (String)
                var tempDni = dniArr[j];
                dniArr[j] = dniArr[j + 1];
                dniArr[j + 1] = tempDni;

                // Intercambio de Nombre (String)
                var tempNombre = nombreArr[j];
                nombreArr[j] = nombreArr[j + 1];
                nombreArr[j + 1] = tempNombre;

                // Intercambio de Nota (Real)
                var tempNota = notaArr[j];
                notaArr[j] = notaArr[j + 1];
                notaArr[j + 1] = tempNota;
            }
        }
    }
}

/**
 * Muestra el listado de alumnos a partir de los vectores auxiliares ordenados.
 * dniArr Vector de DNI ordenado.
 * nombreArr Vector de Nombres ordenado.
 * notaArr Vector de Notas ordenado.
 */
procedure imprimirListado(string[] dniArr, string[] nombreArr, real[] notaArr) {
    writeLine("--------------------------------------------------");
    writeLine("DNI ---- Nombre ---- Nota");
    writeLine("--------------------------------------------------");
    
    for (int i = 0; i < dniArr.Length; i++) {
        var notaStr = formatearNota(notaArr[i]); // Asegura dos decimales
        write(dniArr[i] + "----");
        write(nombreArr[i] + "----");
        writeLine(notaStr);
    }
    writeLine("--------------------------------------------------");
}


/**
 * Lista todos los alumnos ordenados por DNI (opción 1 del menú).
 * alumnosData Vector de strings? de alumnos.
 * numAlumnos Número actual de alumnos.
 */
procedure listarAlumnosPorDNI(string?[] alumnosData, int numAlumnos) {
    writeLine("--- LISTADO DE ALUMNOS (ORDENADO POR DNI) ---");
    if (numAlumnos == 0) {
        writeLine("No hay alumnos registrados.");
        return;
    }
    
    // Los inicializamos los vectores auxiliares en la llamada a obtenerVectoresAuxiliares para optimizar la memoria
    var dniArr = string[0]; 
    var nombreArr = string[0];
    var notaArr = real[0]; 
    
    obtenerVectoresAuxiliares(alumnosData, numAlumnos, dniArr, nombreArr, notaArr);
    ordenarVectoresParalelos(dniArr, nombreArr, notaArr, 0); // Ordenar por DNI
    imprimirListado(dniArr, nombreArr, notaArr);
}

/**
 * Lista todos los alumnos ordenados por Nota (Descendente) (opción 6 del menú).
 * alumnosData Vector de strings? de alumnos.
 * numAlumnos Número actual de alumnos.
 */
procedure listarAlumnosPorNota(string?[] alumnosData, int numAlumnos) {
    writeLine("LISTADO DE ALUMNOS (ORDENADO POR NOTA DESC.) ---");
    if (numAlumnos == 0) {
        writeLine("No hay alumnos registrados.");
        return;
    }
    
    // Los inicializamos los vectores auxiliares en la llamada a obtenerVectoresAuxiliares para optimizar la memoria
    var dniArr = string[0]; 
    var nombreArr = string[0];
    var notaArr = real[0]; 
    
    obtenerVectoresAuxiliares(alumnosData, numAlumnos, ref dniArr, ref nombreArr, ref notaArr);
    ordenarVectoresParalelos(ref dniArr, ref nombreArr, ref notaArr, 1); // Ordenar por Nota Descendente
    imprimirListado(dniArr, nombreArr, notaArr);
}


// --------------------------------------------------------------------
// ESTADÍSTICAS
// --------------------------------------------------------------------

/**
 * Calcula y muestra el número de aprobados, suspensos y la nota media.
 * @param alumnosData Vector de strings? de alumnos.
 * @param numAlumnos Número actual de alumnos.
 */
procedure mostrarEstadisticas(string?[] alumnosData, int numAlumnos) {
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
            var registro = alumnosData[i];
            var partes = registro.Split(';');
            var nota = (decimal)partes[2]; // Conversión a usando casting explícito (decimal)
            
            totalNotas = totalNotas + nota;
            
            if (nota >= 5.0) { // Criterio de aprobado
                aprobados = aprobados + 1;
            } else {
                suspensos = suspensos + 1;
            }
        }
    }
    
    var notaMedia = totalNotas / (decimal)numAlumnos; // Se usa (decimal) para la división
    var notaMediaStr = formatearNota(notaMedia);
    
    writeLine("Alumnos totales: " + numAlumnos);
    writeLine("Aprobados (Nota >= 5.00): " + aprobados);
    writeLine("Suspensos (Nota < 5.00): " + suspensos);
    writeLine("Nota Media: " + notaMediaStr);
}
