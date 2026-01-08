namespace _12_MoscaMatriz.Enums;

// Define el estado posible de una celda dentro de la matriz (tablero).
// Miembros en PascalCase (Vacio, Mosca) según la convención de C#.
// Por defecto, Vacio = 0 y Mosca = 1.
internal enum Celda {
    Vacio, // La celda está vacía (valor subyacente 0)
    Mosca, // La celda contiene la mosca (valor subyacente 1)
    MoscaMuerta // La celda contiene la mosca muerta (valor subyacente 2)
}