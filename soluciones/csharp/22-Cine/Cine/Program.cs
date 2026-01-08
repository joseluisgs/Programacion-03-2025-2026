using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Cine.Enums;
using Cine.Structs;


// Main Program
Console.OutputEncoding = Encoding.UTF8;
Console.Clear();

const int TamFilas = 5;
const int TamColumnas = 6;
const int NumButacasFueraServicio = 3;
const decimal PrecioEntrada = 5.50m;

var localeEs = new CultureInfo("es-ES");
var random = Random.Shared;
var sala = new Butaca[TamFilas, TamColumnas];

// Inicializar miSala
InitButacas(sala);

// Mensaje bienvenida
Console.WriteLine("🎞️ Bienvenido a CineDaw 🎞️");
Console.WriteLine("=========================");
Console.WriteLine();

var opcion = 0;

do {
    // Barra de progreso
    Console.WriteLine("Estado de ocupación de la sala:");
    DibujarBarraProgreso(CalcularButacasOcupadasOFueraServicio(sala), TamFilas * TamColumnas);
    Console.WriteLine("\n");
    Console.WriteLine("Menú:");
    Console.WriteLine($"{(int)MenuOpcion.Mostrar}. Mostrar miSala");
    Console.WriteLine($"{(int)MenuOpcion.Comprar}. Comprar entrada");
    Console.WriteLine($"{(int)MenuOpcion.Devolver}. Devolver entrada");
    Console.WriteLine($"{(int)MenuOpcion.Informe}. Informe final (Estadísticas)");
    Console.WriteLine($"{(int)MenuOpcion.Salir}. Salir");
    Console.Write("Ingrese una opción: ");

    var inputOpcion = (Console.ReadLine() ?? string.Empty).Trim();

    var patronOpcion = @"^[1-5]$";
    var regexOpcion = new Regex(patronOpcion);

    opcion = 0;
    if (regexOpcion.IsMatch(inputOpcion))
        opcion = int.Parse(inputOpcion);

    switch (opcion) {
        case (int)MenuOpcion.Mostrar:
            MostrarSala(sala);
            break;
        case (int)MenuOpcion.Comprar:
            ComprarEntrada(sala);
            break;
        case (int)MenuOpcion.Devolver:
            DevolverEntrada(sala);
            break;
        case (int)MenuOpcion.Informe:
            GenerarInforme(sala);
            break;
        case (int)MenuOpcion.Salir:
            Console.WriteLine("¡Hasta luego!");
            break;
        default:
            Console.WriteLine("Opción no válida");
            break;
    }

    Console.WriteLine();
} while (opcion != (int)MenuOpcion.Salir);


Console.WriteLine("\n👋 Presiona una tecla para salir...");
Console.ReadKey();
return;

// End Main Program

// Inicializa la miSala de cine con butacas
void InitButacas(Butaca[,] miSala) {
    for (var i = 0; i < TamFilas; i++)
        for (var j = 0; j < TamColumnas; j++)
            miSala[i, j] = new Butaca {
                Posicion = new Posicion { Fila = i, Columna = j },
                Precio = PrecioEntrada,
                Estado = Estado.Libre
            };

    var countFs = 0;
    while (countFs < NumButacasFueraServicio) {
        var f = random.Next(TamFilas); // Generar una fila aleatoria entre 0 y TamFilas-1
        var c = random.Next(TamColumnas); // Generar una columna aleatoria entre 0 y TamColumnas-1
        if (miSala[f, c].Estado != Estado.FueraServicio) {
            miSala[f, c].Estado = Estado.FueraServicio;
            countFs++;
        }
    }
}

// Muestra la miSala de cine
void MostrarSala(Butaca[,] miSala) {
    Console.WriteLine("\nEstado de la sala de cine\n");

    var ancho = 3; // fijo para todos

    // Usamos padLeft para alinear a la derecha

    // Encabezados de columnas
    Console.Write("    ");
    for (var i = 1; i <= TamColumnas; i++)
        Console.Write(i.ToString().PadLeft(ancho));

    Console.WriteLine();

    // Filas con butacas
    for (var fila = 0; fila < TamFilas; fila++) {
        Console.Write(" " + ObtenerLetraFila(fila) + "  "); // Esto funciona porque 'A' + 0 = 'A', 'A' + 1 = 'B', etc.

        for (var col = 0; col < TamColumnas; col++) {
            var icono = miSala[fila, col].Estado switch {
                Estado.Ocupada => "🔴",
                Estado.FueraServicio => "🚫",
                _ => "💺"
            };

            Console.Write(icono.PadLeft(ancho));
        }

        Console.WriteLine();
    }

    Console.WriteLine();
}

// Compra una entrada para el usuario
int ObtenerIndiceFila(char letra) {
    //¿Por qué esto funciona?
    // Porque en C#, los caracteres se pueden tratar como números enteros
    // basados en su valor Unicode. Al restar 'A', obtenemos la posición
    // relativa de la letra en el alfabeto (A=0, B=1, C=2, etc.).
    // Si 'A' tiene un valor Unicode de 65, entonces 'B' es 66, 'C' es 67, y así sucesivamente.
    return letra - 'A';
    // Otra forma de hacerlo es usando IndexOf en una cadena:
    // "ABCDE".IndexOf(letra);
    // La otra forma es:
    /*switch (letra) {
        case 'A': return 0;
        case 'B': return 1;
        case 'C': return 2;
        case 'D': return 3;
        case 'E': return 4;
        default: return -1; // Valor inválido
    }*/
}

// Convierte un índice de fila a su letra correspondiente
// Sabiendo que 0 = A, 1 = B, 2 = C, etc.
char ObtenerLetraFila(int indice) {
    return (char)('A' + indice);
}

// Verifica si hay alguna butaca libre en la miSala
bool HayButacaPorEstado(Butaca[,] miSala, Estado estado) {
    foreach (var b in miSala)
        if (b.Estado == estado)
            return true;
    return false;
}

// Verifica si la butaca está ocupada en la miSala
bool IsOcupada(Butaca[,] miSala, Posicion posicion) {
    // No necesitamos el if, podemos devolver directamente la comparación booleana
    return miSala[posicion.Fila, posicion.Columna].Estado == Estado.Ocupada;
}

// Obtiene una butaca aleatoria libre en la miSala
void OcuparButaca(Butaca[,] miSala, Posicion posicion) {
    //var b = miSala[posicion.Fila, posicion.Columna];
    //b.Estado = Estado.Ocupada;
    //miSala[posicion.Fila, posicion.Columna] = b;
    miSala[posicion.Fila, posicion.Columna].Estado = Estado.Ocupada;
}

// Libera una butaca en la miSala
void LiberarButaca(Butaca[,] miSala, Posicion posicion) {
    //var b = miSala[posicion.Fila, posicion.Columna];
    //b.Estado = Estado.Libre;
    //miSala[posicion.Fila, posicion.Columna] = b;
    miSala[posicion.Fila, posicion.Columna].Estado = Estado.Libre;
}

// Lee una posición de butaca desde la entrada del usuario o devuelve null si es inválida
Posicion LeerPosicionButaca(string mensaje) {
    Posicion pos;
    string input;
    var inputOk = false;
    do {
        Console.Write(mensaje);
        input = (Console.ReadLine() ?? "").Trim().ToUpper();
        inputOk = Regex.IsMatch(input, @"^([A-E]):([1-6])$");
        if (!inputOk)
            Console.WriteLine("Formato incorrecto. Usa A-E:1-6 (ej. B:3).");
    } while (!inputOk);

    var partes = input.Split(':');

    pos = new Posicion {
        Fila = ObtenerIndiceFila(partes[0][0]), // "A", 'A'
        Columna = int.Parse(partes[1]) - 1
    };
    return pos;
}

// Solicita confirmación al usuario
bool Confirmar(string mensaje) {
    Console.Write(mensaje);
    var k = Console.ReadKey(true).KeyChar;
    Console.WriteLine();
    return k == 's' || k == 'S'; // Si la respuesta es's' o 'S'
}

// Compra la entrada para el usuario
void ComprarButaca(Butaca[,] miSala, Posicion posicion) {
    OcuparButaca(miSala, posicion);

    var entrada = new Entrada {
        Butaca = miSala[posicion.Fila, posicion.Columna],
        FechaCompra = DateTime.Now,
        Precio = miSala[posicion.Fila, posicion.Columna].Precio
    };

    Console.WriteLine("\n--- 🎟️ ENTRADA DE CINE ---");
    Console.WriteLine(
        $"Butaca: {ObtenerLetraFila(entrada.Butaca.Posicion.Fila)}:{entrada.Butaca.Posicion.Columna + 1}");
    Console.WriteLine($"Precio: {entrada.Precio.ToString("C2", localeEs)}");
    Console.WriteLine($"Fecha:  {entrada.FechaCompra.ToString("g", localeEs)}");
    Console.WriteLine("------------------------------\n");
}

// Devuelve la entrada para el usuario
void DevolverButaca(Butaca[,] miSala, Posicion posicion) {
    var importe = miSala[posicion.Fila, posicion.Columna].Precio;
    LiberarButaca(miSala, posicion);

    Console.WriteLine(
        $"✅ Devolución realizada de la entrada ({ObtenerLetraFila(posicion.Fila)},{posicion.Columna + 1}).");
    Console.WriteLine($"💰 Importe devuelto: {importe.ToString("C2", localeEs)}\n");
}

// Compra una entrada para el usuario
void ComprarEntrada(Butaca[,] miSala) {
    if (!HayButacaPorEstado(miSala, Estado.Libre)) {
        Console.WriteLine("❌ No hay butacas libres.");
        return;
    }

    var repetir = false; // bandera
    do {
        var pos = LeerPosicionButaca("Ingrese butaca (A-E:1-6): ");
        if (miSala[pos.Fila, pos.Columna].Estado != Estado.Libre) {
            Console.WriteLine("❌ La butaca no está disponible.");
            repetir = true;
            //return; // salimos del bucle para volver al menú principal
        }
        else {
            var precioStr = miSala[pos.Fila, pos.Columna].Precio.ToString("C2", localeEs);
            if (Confirmar(
                    $"⚠️ Confirmar compra de ({ObtenerLetraFila(pos.Fila)},{pos.Columna + 1}) por {precioStr} (s/n): ")) {
                ComprarButaca(miSala, pos);
                repetir = false;
            }
            else {
                Console.WriteLine("❌ Compra cancelada.");
                repetir = false;
            }
        }
    } while (repetir);
}

// Devuelve una entrada para el usuario
void DevolverEntrada(Butaca[,] miSala) {
    if (!HayButacaPorEstado(miSala, Estado.Ocupada)) {
        Console.WriteLine("❌ No hay butacas ocupadas.");
        return;
    }

    var repetir = false; // bandera
    do {
        var pos = LeerPosicionButaca("Ingrese butaca a devolver (A-E:1-6): ");
        if (!IsOcupada(miSala, pos)) {
            Console.WriteLine("❌ La butaca no estaba ocupada.");
            repetir = true;
        }
        else {
            var precioStr = miSala[pos.Fila, pos.Columna].Precio.ToString("C2", localeEs);
            if (Confirmar(
                    $"⚠️ Confirmar la devolución de ({ObtenerLetraFila(pos.Fila)},{pos.Columna + 1}) por {precioStr} (s/n): ")) {
                DevolverButaca(miSala, pos);
                repetir = false;
            }
            else {
                Console.WriteLine("❌ Operación cancelada.");
                repetir = false;
            }
        }
    } while (repetir);
}

// Genera un informe del estado de la miSala de cine
void GenerarInforme(Butaca[,] miSala) {
    int vendidas = 0, libres = 0, fueraServicio = 0;
    foreach (var b in miSala)
        switch (b.Estado) {
            case Estado.Ocupada:
                vendidas++;
                break;
            case Estado.Libre:
                libres++;
                break;
            default:
                fueraServicio++;
                break;
        }

    var disponibles = vendidas + libres;
    var ocup = disponibles == 0 ? 0 : (double)vendidas / disponibles * 100;
    var recaudacion = vendidas * PrecioEntrada;

    Console.WriteLine("\n--- 📈 INFORME CINEDAW 📈 ---");
    Console.WriteLine($"🎟️ Entradas Vendidas: {vendidas}");
    Console.WriteLine($"💺 Asientos Libres: {libres}");
    Console.WriteLine($"🚫 Fuera de Servicio: {fueraServicio}");
    Console.WriteLine($"📽️ Ocupación: {ocup.ToString("F2", localeEs)}%");
    Console.WriteLine($"💵 Recaudación Total: {recaudacion.ToString("C2", localeEs)}\n");
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

int CalcularButacasOcupadasOFueraServicio(Butaca[,] miSala) {
    var contador = 0;
    foreach (var b in miSala)
        if (b.Estado == Estado.Ocupada || b.Estado == Estado.FueraServicio)
            contador++;
    return contador;
}