// 🍀 Sorteo de la Primitiva - Lenguaje DAW
using Math;

const CARTON_SIZE = 6;

Main {
    writeLine("🍀 Sorteo de la Primitiva");

    int[] boleto = generarCartonPrimitiva();

    writeLine("Tu boleto es:");
    imprimirCarton(boleto);
}

// ------------------------------------------------------------
// Genera un cartón de la primitiva con 6 números aleatorios sin repetirse
// ------------------------------------------------------------
function int[] generarCartonPrimitiva() {
    int[] carton = int[CARTON_SIZE];
    int numero;

    for (int i = 0; i < carton.Length; i++) {
        // Debemos que el número generado no esté en el cartón hasta que lo generemos de nuevo
        do {
            numero = numeroAleatorio(1, 49);
            // Si es verdadero es que está y debemos generar otro
        } while (existeNumeroEnCarton(numero, carton));
        // Si es falso es que no está y debemos guardarlo en el cartón
        carton[i] = numero;
    }

    return carton;
}

// ------------------------------------------------------------
// Genera un número aleatorio entre min y max (ambos incluidos)
// ------------------------------------------------------------
function int numeroAleatorio(int min, int max) {
    return Math.Random(min, max);
}

// ------------------------------------------------------------
// Comprueba si un número ya existe dentro del cartón
// ------------------------------------------------------------
function bool existeNumeroEnCarton(int numero, int[] carton) {
    // Busqueda lineal del número en el cartón
    foreach (int elemento in carton) {
        if (elemento == numero) {
            return true;
        }
    }
    return false;
}

// ------------------------------------------------------------
// Imprime el cartón con todos los números separados por espacios
// ------------------------------------------------------------
procedure imprimirCarton(int[] carton) {
    // Imprime los números del cartón separados por espacios
    // Usamos StringBuilder para construir la cadena de salida
    // ¿Por que StringBuilder es más eficiente que concatenar 
    // cadenas con el operador + ?
    // Esto es debido a que las cadenas en DAW son inmutables,
    // por lo que cada vez que concatenamos con + se crea una nueva cadena
    // en memoria. StringBuilder, en cambio, modifica la cadena existente
    // sin crear nuevas instancias, lo que lo hace más eficiente.
    var sb = StringBuilder();
    foreach (var numero in carton) {
        sb.Append(numero + " ");
    }
    writeLine(sb.ToString());
}
