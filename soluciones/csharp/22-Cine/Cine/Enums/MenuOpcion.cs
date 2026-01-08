namespace Cine.Enums;

// MenuOpcion.cs
// ----------------------------------------------------------------------------------
// Enumeración: MenuOpcion
// Propósito: Define las opciones del menú principal, asignando valores enteros para
// simplificar el uso en el bloque 'switch' del programa principal.
// ----------------------------------------------------------------------------------

// Nota: Al usar 'enum', se cumplen los requisitos de usar las constantes
// como si fueran numeradas, ya que se leen como enteros internamente.
public enum MenuOpcion {
    // Las opciones se definen con sus valores.
    Mostrar = 1,
    Comprar = 2,
    Devolver = 3,
    Informe = 4, // Opción 4 ahora es INFORME.
    Salir = 5
}