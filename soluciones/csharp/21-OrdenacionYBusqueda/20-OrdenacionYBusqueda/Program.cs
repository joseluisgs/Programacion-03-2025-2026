using System.Diagnostics;
using System.Text;


// Constante para el tamaño del vector.
const int TamanoVector = 100_000;
const int RangoMaximo = 1_000_000_000; // Rango máximo para números aleatorios

Console.OutputEncoding = Encoding.UTF8;
Console.Clear();

// 1. Inicialización del vector - ¡SIN LINQ!
Console.WriteLine($"Generando un vector inicial de {TamanoVector} elementos...");
var rand = new Random();
var vectorInicial = new int[TamanoVector];


// Rellenado del array usando un bucle 'for'
for (var i = 0; i < TamanoVector; i++)
    // rand.Next(max) genera un número entre 0 (incluido) y max (excluido)
    vectorInicial[i] = rand.Next(RangoMaximo);

// Inicialización de herramientas de tiempo
var stopwatch = new Stopwatch();
long tiempoMs;
long tiempoNs;



// --- SECCIÓN DE ORDENACIÓN (Medición en Milisegundos) ---

Console.WriteLine("\n--- ALGORITMOS DE ORDENACIÓN (O(n^2) vs O(n log n)) ---");

// Probamos burbuja (Bubble Sort)
var vectorBurbuja = (int[])vectorInicial.Clone(); // Clonamos el vector inicial para no modificarlo
Console.WriteLine("\n1.- Ordenación Alg. de Burbuja (O(n^2)), por favor espere...");
stopwatch.Restart(); // Reiniciamos el cronómetro
BubbleSort(vectorBurbuja);
stopwatch.Stop(); // Detenemos el cronómetro
tiempoMs = stopwatch.ElapsedMilliseconds; // Obtenemos el tiempo en milisegundos
Console.WriteLine($"⏱️ Tiempo Alg. Burbuja: {tiempoMs} ms");

// Probamos selección (Selection Sort)
var vectorSeleccion = (int[])vectorInicial.Clone();
Console.WriteLine("\n2.- Ordenación Alg. de Selección (O(n^2)), por favor espere...");
stopwatch.Restart();
SelectionSort(vectorSeleccion);
stopwatch.Stop();
tiempoMs = stopwatch.ElapsedMilliseconds;
Console.WriteLine($"⏱️ Tiempo Alg. Selección: {tiempoMs} ms");

// Probamos inserción (Insertion Sort)
var vectorInsercion = (int[])vectorInicial.Clone();
Console.WriteLine("\n3.- Ordenación Alg. de Inserción (O(n^2)), por favor espere...");
stopwatch.Restart();
InsertionSort(vectorInsercion);
stopwatch.Stop();
tiempoMs = stopwatch.ElapsedMilliseconds;
Console.WriteLine($"⏱️ Tiempo Inserción: {tiempoMs} ms");

// Probamos Shell Sort
var vectorShell = (int[])vectorInicial.Clone();
Console.WriteLine("\n4- Ordenación Alg. Shell Sort (O(n log n)), por favor espere...");
stopwatch.Restart();
ShellSort(vectorShell);
stopwatch.Stop();
tiempoMs = stopwatch.ElapsedMilliseconds;
Console.WriteLine($"⏱️ Tiempo Alg. Shell Sort: {tiempoMs} ms");

// Probamos QuickSort
var vectorQuick = (int[])vectorInicial.Clone();
Console.WriteLine("\n5.- Ordenación Alg. QuickSort (O(n log n)), por favor espere...");
stopwatch.Restart();
QuickSort(vectorQuick);
stopwatch.Stop();
tiempoMs = stopwatch.ElapsedMilliseconds;
Console.WriteLine($"⏱️ Tiempo Alg. QuickSort: {tiempoMs} ms");

// Contra el método de ordenación de .NET
var vectorDotNet = (int[])vectorInicial.Clone();
Console.WriteLine("\n6.- Ordenación Array.Sort (.NET), por favor espere...");
stopwatch.Restart();
Array.Sort(vectorDotNet);
stopwatch.Stop();
tiempoMs = stopwatch.ElapsedMilliseconds;
Console.WriteLine($"⏱️ Tiempo Array.Sort (.NET): {tiempoMs} ms");


// --- SECCIÓN DE BÚSQUEDA (Medición en Nanosegundos) ---

Console.WriteLine("\n\n--- ALGORITMOS DE BÚSQUEDA (O(n) vs O(log n)) ---");

// Ordenamos el vector para la Búsqueda Binaria y la comparación nativa
var vectorOrdenado = (int[])vectorInicial.Clone();
Array.Sort(vectorOrdenado);

// Elegimos un elemento para buscar que sabemos que existe
var elementoParaBuscar = vectorInicial[rand.Next(TamanoVector)];
Console.WriteLine($"Elemento a buscar: {elementoParaBuscar}");

// Búsqueda Lineal
Console.WriteLine("\n1.- Búsqueda Lineal, por favor espere...");
stopwatch.Restart();
LinearSearch(vectorInicial, elementoParaBuscar);
stopwatch.Stop();
tiempoNs = stopwatch.ElapsedTicks * (1_000_000_000 / Stopwatch.Frequency); // Convertimos ticks a nanosegundos
Console.WriteLine($"⏱️ Tiempo Búsqueda Lineal: {tiempoNs} ns");

// Búsqueda Binaria
Console.WriteLine("\n2.- Búsqueda Binaria, por favor espere...");
stopwatch.Restart();
BinarySearch(vectorOrdenado, elementoParaBuscar);
stopwatch.Stop();
tiempoNs = stopwatch.ElapsedTicks * (1_000_000_000 / Stopwatch.Frequency);
Console.WriteLine($"⏱️ Tiempo Búsqueda Binaria: {tiempoNs} ns");

// Búsqueda Binaria de .NET
Console.WriteLine("\n3.- Búsqueda Array.BinarySearch (.NET), por favor espere...");
stopwatch.Restart();
Array.BinarySearch(vectorOrdenado, elementoParaBuscar);
stopwatch.Stop();
tiempoNs = stopwatch.ElapsedTicks * (1_000_000_000 / Stopwatch.Frequency);
Console.WriteLine($"⏱️ Tiempo Array.BinarySearch (.NET): {tiempoNs} ns");



Console.WriteLine("\n👋 Presiona una tecla para salir...");
Console.ReadKey();
return;
// --- Implementación de Algoritmos (Clásica y Didáctica) ---

/**
 * Método de ordenación de burbuja O(n²)
 */
void BubbleSort(int[] vector) {
    for (var i = 0; i < vector.Length - 1; i++) {
        for (var j = 0; j < vector.Length - 1 - i; j++)
            if (vector[j] > vector[j + 1]) {
                // Swap Clásico
                var aux = vector[j];
                vector[j] = vector[j + 1];
                vector[j + 1] = aux;
            }
    }
}

/**
 * Método de ordenación por selección O(n²)
 */
void SelectionSort(int[] array) {
    for (var i = 0; i < array.Length - 1; i++) {
        var minIndex = i;
        for (var j = i + 1; j < array.Length; j++)
            if (array[j] < array[minIndex])
                minIndex = j;

        // Intercambio Clásico
        var aux = array[i];
        array[i] = array[minIndex];
        array[minIndex] = aux;
    }
}

/**
 * Método de ordenación por inserción O(n²)
 */
void InsertionSort(int[] array) {
    for (var i = 1; i < array.Length; i++) {
        var temp = array[i];
        var j = i - 1;
        while (j >= 0 && array[j] > temp) {
            array[j + 1] = array[j];
            j--;
        }

        array[j + 1] = temp;
    }
}

/**
 * Método de ordenación Shell Sort
 */
void ShellSort(int[] array) {
    var h = 1;
    while (h < array.Length / 3) h = 3 * h + 1;
    while (h >= 1) {
        for (var i = h; i < array.Length; i++) {
            var temp = array[i];
            var j = i;
            while (j >= h && array[j - h] > temp) {
                array[j] = array[j - h];
                j -= h;
            }

            array[j] = temp;
        }

        h /= 3;
    }
}

/**
 * Método de ordenación QuickSort
 */
void QuickSort(int[] array) {
    QuicksortRecursive(array, 0, array.Length - 1);
}

void QuicksortRecursive(int[] array, int left, int right) {
    if (left < right) {
        var pivotIndex = Pivot(array, left, right);
        QuicksortRecursive(array, left, pivotIndex - 1);
        QuicksortRecursive(array, pivotIndex + 1, right);
    }
}

int Pivot(int[] array, int left, int right) {
    var pivot = array[left];
    var i = left;
    var j = right;

    while (i < j) {
        while (i < j && array[i] <= pivot) i++;
        while (array[j] > pivot) j--;

        if (i < j) {
            // Intercambio Clásico
            var aux = array[i];
            array[i] = array[j];
            array[j] = aux;
        }
    }

    // Colocar el pivote en su posición final
    var auxFinal = array[left];
    array[left] = array[j];
    array[j] = auxFinal;
    return j;
}

/**
 * Método de búsqueda lineal o secuencial O(n)
 */
int LinearSearch(int[] array, int value) {
    for (var i = 0; i < array.Length; i++)
        if (array[i] == value)
            return i;

    return -1;
}

/**
 * Método de búsqueda binaria iterativo O(log n)
 */
int BinarySearch(int[] array, int value) {
    var left = 0;
    var right = array.Length - 1;

    while (left <= right) {
        // left + (right - left) / 2 es la forma didáctica de prevenir overflows
        var middle = left + (right - left) / 2;

        if (array[middle] == value) return middle;

        if (array[middle] < value)
            left = middle + 1;
        else
            right = middle - 1;
    }

    return -1;
}