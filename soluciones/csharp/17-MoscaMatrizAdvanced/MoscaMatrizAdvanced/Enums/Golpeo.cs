namespace _12_MoscaMatriz.Enums;

// Define los posibles resultados tras un intento de golpeo.
// Se ha renombrado a 'Golpeo' para mayor concisión.
internal enum Golpeo {
    Acertado, // Resultado si la posición del golpeo coincide con la de la mosca.
    Fallado, // Resultado si el golpeo no fue acertado ni adyacente.
    Casi // Resultado si el golpeo fue en una casilla adyacente a la mosca.
}