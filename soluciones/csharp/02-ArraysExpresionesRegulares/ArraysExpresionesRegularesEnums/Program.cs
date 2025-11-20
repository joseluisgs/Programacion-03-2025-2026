using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using ArraysExpresionesRegulares.Enums;

// Main Entry Point
Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine("✅ ✅");

ArraysMultidimensionalesNormales();
ArraysMultidimensionalesJagged();
ExpresioneRegularesinGrupos();
ExpresionesRegularesConGrupos();
JugandoConEnums();


Console.WriteLine("Pulsa una tecla para finalizar...");
Console.ReadKey();

return;
// End Main Entry Point

void ArraysMultidimensionalesNormales() {
    var array = new int[3, 4];

    Console.WriteLine("Total:" + array.Length);
    Console.WriteLine("Dimensiones:" + array.Rank);
    Console.WriteLine("Filas:" + array.GetLength(0));
    Console.WriteLine("Columnas:" + array.GetLength(1));

    for (var i = 0; i < array.GetLength(0); i++) {
        for (var j = 0; j < array.GetLength(1); j++)
            array[i, j] = i + j;
    }

    for (var i = 0; i < array.GetLength(0); i++) {
        for (var j = 0; j < array.GetLength(1); j++)
            Console.Write(array[i, j] + " ");
        Console.WriteLine();
    }
}

void ArraysMultidimensionalesJagged() {
    var array = new int[3][];

    // obligatoriamente debes inicializar cada una de las filas
    for (var i = 0; i < array.Length; i++)
        array[i] = new int[4];

    Console.WriteLine("Total:" + array.Length);
    Console.WriteLine("Dimensiones:" + array.Rank);

    for (var i = 0; i < array.Length; i++) {
        for (var j = 0; j < array[i].Length; j++)
            array[i][j] = i + j;
    }

    for (var i = 0; i < array.Length; i++) {
        for (var j = 0; j < array[i].Length; j++)
            Console.Write(array[i][j] + " ");
        Console.WriteLine();
    }
}

void ExpresioneRegularesinGrupos() {
    var dni = "69696969X";
    var expresionRegular = @"^\d{8}[A-Z]$";
    var regex = new Regex(expresionRegular);

    if (regex.IsMatch(dni)) {
        Console.WriteLine("DNI válido");
        // El casting es seguro porque ha pasado la validación
        Console.WriteLine($"DNI Completo: {dni}");
        var numero = int.Parse(dni.Substring(0, 8));
        var letra = dni[8];
        Console.WriteLine($"Número: {numero}, Letra: {letra}");
    }
    else {
        Console.WriteLine("DNI inválido");
    }
}

void ExpresionesRegularesConGrupos() {
    var dni = "69696969X";
    // Usando grupos sin alias
    var expresionRegular = @"^(\d{8})([A-Z])$";
    // Usando grupos y alias para el grupo
    //var expresionRegular = @"^(?<numero>\d{8})(?<letra>[A-Z])$";
    var regex = new Regex(expresionRegular);
    
    // Ejecutamos match con la expresión regular
    var match = regex.Match(dni);

    if (match.Success) {
        Console.WriteLine("DNI válido");
        // El casting es seguro porque ha pasado la validación
        Console.WriteLine($"DNI Completo: {match.Groups[0].Value}");        
        var numero = int.Parse(match.Groups[1].Value);
        var letra = match.Groups[2].Value[0];
        Console.WriteLine($"Número: {numero}, Letra: {letra}");
       
        // Usando alias para el grupo
        //numero = int.Parse(match.Groups["numero"].Value);
        //letra = match.Groups["letra"].Value[0];
        Console.WriteLine($"Número: {numero}, Letra: {letra}");
        
    }
    else {
        Console.WriteLine("DNI inválido");
    }
}

void JugandoConEnums() {
    var dia = DiasSemana.Lunes;
    Console.WriteLine($"Día de la semana: {dia}");
    // Entero que representa el valor del enum
    Console.WriteLine($"Valor del enum: {(int)dia}");

    // Convertimos el entero a enum
    DiasSemana diaConvertido = (DiasSemana)1; // diaConvertido será Martes
    Console.WriteLine($"Día convertido: {diaConvertido}");
    
    // Que pasa si el dia no existe en el enum? Pues es un entero
    // Solo lo muestra la clave que representa el valor del enum si existe en el casting, si no entero
    diaConvertido = (DiasSemana)10;
    Console.WriteLine($"Día convertido: {diaConvertido}");
    
    // Obtener el nombre directamente de la constante del enum
    string nombreConstante = nameof(DiasSemana.Lunes);
    Console.WriteLine($"Nombre de la constante: {nombreConstante}");
    
    // array de dias de la semana aleatorios
    DiasSemana[] diasSemana = new DiasSemana[10];
    Random random = new Random();
    for (int i = 0; i < diasSemana.Length; i++) {
        var numeroAleatorio = random.Next(0, 7); // 0 a 6
        Console.WriteLine($"Número aleatorio: {numeroAleatorio}");
        diasSemana[i] = (DiasSemana) numeroAleatorio;
        Console.WriteLine($"Día aleatorio: {diasSemana[i]}");
    }
    
    // Mostramos los dias de la semana aleatorios
    Console.WriteLine("Dias de la semana aleatorios:");
    foreach (var d in diasSemana) {
        Console.WriteLine(d);
    }

     // Casar un string con la clave del enum
    var diaString = "Lunes";
    DiasSemana diaCasado = (DiasSemana) Enum.Parse(typeof(DiasSemana), diaString);
    Console.WriteLine($"Día casado: {diaCasado}");
    Console.WriteLine($"Valor del enum del día casado: {(int)diaCasado}");
}
