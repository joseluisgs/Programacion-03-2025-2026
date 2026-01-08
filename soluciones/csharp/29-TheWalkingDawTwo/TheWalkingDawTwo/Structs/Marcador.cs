using TheWalkingDawTwo.Enums;

namespace TheWalkingDawTwo.Structs;

// Struct Marcador: estado mutable del juego
public struct Marcador {
    public int TiempoMs; // tiempo transcurrido en ms
    public int Salud; // vida actual del jugador
    public int Municion; // munición actual
    public int EnemigosMuertos; // contador de enemigos muertos
    public Direccion Direccion; // Dirección actual (enum)
    public Posicion Posicion; // Posición del jugador (fila/col)
    public EstadoSalida Salida; // Estado de salida (enum)
}