using System.Text;

// Constantes
const int MaximoCarton = 6;

// Main entry point 
// Poder escribir Emojis en la consola
Console.OutputEncoding = Encoding.UTF8;

var numerosGanadores = GenerarCartonLoteria();
Console.WriteLine("🎉 Números ganadores de la lotería:");
Console.WriteLine(string.Join(", ", numerosGanadores));

// Pausa para ver el resultado
Console.WriteLine("👋 Presiona una tecla para salir...");
Console.ReadKey();
return;
// End of Main entry point

// Métodos auxiliares
int[] GenerarCartonLoteria() {
    var rand = new Random();
    var cartonLoteria = new int[MaximoCarton];

    // Generar números únicos entre 1 y 49
    // Recorremos el array y vamos generando números aleatorios
    for (var i = 0; i < cartonLoteria.Length; i++) {
        int numero;
        // Mientras el número generado ya esté en el array, generamos un nuevo número
        do {
            numero = rand.Next(1, 50);
        } while (cartonLoteria.Contains(numero));

        cartonLoteria[i] = numero;
    }

    return cartonLoteria;
}

int IndexOf(int[] array, int value) {
    for (var i = 0; i < array.Length; i++)
        if (array[i] == value)
            return i;

    return -1;
}