using Cine.Enums;

namespace Cine.Structs;

// Butaca.cs
// ----------------------------------------------------------------------------------
// Estructura: Butaca
// Propósito: Representa una butaca completa con su estado, posición y precio.
// ----------------------------------------------------------------------------------

public struct Butaca {
    // Usamos 'decimal' para el precio. En C#, 'decimal' es el tipo recomendado
    // para manejar valores monetarios por su alta precisión y evitar problemas
    // de redondeo inherentes a 'float' o 'double'. 💰, a parte de sacarlo
    public Posicion Posicion;
    public decimal Precio;
    public Estado Estado;
}