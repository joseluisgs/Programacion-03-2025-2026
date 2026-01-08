Console.WriteLine("## Ejercicio: Compresión y Descompresión de Arrays ##");
Console.WriteLine("----------------------------------------------------");

// --- CASOS DE PRUEBA ---

// Sin elementos repetidos
int[] arr1 = [0, 1, 2, 3, 4, 5];
EjecutarPrueba(1, arr1);

// Elementos repetidos
int[] arr2 = [7, 7, 7, 8, 8];
EjecutarPrueba(2, arr2);

// Array con un solo elemento
int[] arr3 = [10];
EjecutarPrueba(3, arr3);

// Array con todos los elementos iguales
int[] arr4 = [5, 5, 5];
EjecutarPrueba(4, arr4);

// Array con múltiples secuencias de repetición
int[] arr5 = [1, 1, 2, 3, 3, 3, 4, 4, 1, 1];
EjecutarPrueba(5, arr5);


// --- MÉTODOS AUXILIARES LOCALES ---

void EjecutarPrueba(int num, int[] original) {
    Console.WriteLine($"\n--- PRUEBA {num} ---");
    Console.Write("Entrada: ");
    PrintArray(original);

    // 1. Compresión
    var comprimido = Comprimir(original);
    Console.Write("Comprimido: ");
    PrintArray(comprimido);

    // 2. Descompresión
    var descomprimido = Descomprimir(comprimido);
    Console.Write("Descomprimido: ");
    PrintArray(descomprimido);
}


void PrintArray(int[] array) {
    Console.WriteLine($"[{string.Join(", ", array)}]");
}

// --------------------------------------------------------------------------------
// --- MÉTODOS DE COMPRESIÓN/DESCOMPRESIÓN ---
// --------------------------------------------------------------------------------

int[] Comprimir(int[] array) {
    if (array.Length == 0) 
        return [];

    // Paso 1: Determinar el tamaño exacto del array comprimido
    var arraySize = array.Length;
    var compressedSize = 0;
    var i = 0;

    while (i < arraySize) {
        compressedSize += 2; // Siempre añadimos (cuenta, valor)
        var currentValue = array[i];
        var j = i;

        // Contar cuántas veces se repite el valor consecutivamente
        while (j < arraySize && array[j] == currentValue) j++;
        // i avanza a la posición del siguiente grupo
        i = j;
    }

    // Paso 2: Crear y llenar el array comprimido
    var compressedArray = new int[compressedSize];
    var compressedIndex = 0;
    i = 0; // Reiniciamos el índice de la entrada

    while (i < arraySize) {
        var currentValue = array[i];
        var count = 0;
        var j = i;

        // Contar y avanzar j
        while (j < arraySize && array[j] == currentValue) {
            count++;
            j++;
        }

        // Llenar el array comprimido con (cuenta, valor)
        compressedArray[compressedIndex] = count;
        compressedArray[compressedIndex + 1] = currentValue;

        compressedIndex += 2; // Avanzamos el índice de salida
        i = j; // i avanza a la posición del siguiente grupo
    }

    return compressedArray;
}

int[] Descomprimir(int[] compressedArray) {
    if (compressedArray.Length == 0)
        return [];

    // Paso 1: Determinar el tamaño exacto del array descomprimido
    var originalSize = 0;

    // El array comprimido debe tener una longitud par
    for (var i = 0; i < compressedArray.Length; i += 2) {
        // El primer elemento del par es la cuenta
        var count = compressedArray[i];
        originalSize += count;
    }

    // Paso 2: Crear y llenar el array descomprimido
    var originalArray = new int[originalSize];
    var originalIndex = 0;

    // Recorremos el array comprimido en pares de (cuenta, valor)
    for (var i = 0; i < compressedArray.Length; i += 2) {
        var count = compressedArray[i];
        var value = compressedArray[i + 1];

        // Repetimos el valor 'value' 'count' veces
        for (var j = 0; j < count; j++) {
            originalArray[originalIndex] = value;
            originalIndex++;
        }
    }

    return originalArray;
}