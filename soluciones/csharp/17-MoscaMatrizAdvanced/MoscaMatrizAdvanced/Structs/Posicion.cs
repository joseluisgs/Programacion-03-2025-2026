namespace _12_MoscaMatriz.Structs;

// Define una posición (Fila y Columna) dentro de la matriz.
// Es una buena práctica usar 'struct' para tipos pequeños que solo contienen datos.
// Los campos se definen como 'public' para acceso directo (programación estructurada modular).
internal struct Posicion {
    public int Fila; // Índice de la fila (0-indexado)
    public int Columna; // Índice de la columna (0-indexado)
}