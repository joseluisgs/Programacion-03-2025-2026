namespace Cine.Enums;

// ----------------------------------------------------------------------------------
// Enumeración: Estado
// Propósito: Define los posibles estados de una butaca en la sala de cine.
// Nota didáctica: En C#, las enumeraciones proporcionan un conjunto de constantes
// simbólicas con nombre. Esto hace que el código sea más legible y menos propenso
// a errores que usar números mágicos (como 0, 1, 2). 💡
// ----------------------------------------------------------------------------------
public enum Estado {
    // [💺] Disponible para la venta
    Libre = 0,

    // [🔴] Butaca vendida/ocupada
    Ocupada = 1,

    // [🚫] Butaca no disponible (por ejemplo, por avería)
    FueraServicio = 2
}