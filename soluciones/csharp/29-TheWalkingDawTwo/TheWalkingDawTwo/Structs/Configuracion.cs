namespace TheWalkingDawTwo.Structs;

// Struct con la configuración del juego (solo datos)
public struct Configuracion {
    public int TamTablero;
    public int NumBloques;
    public int NumEnemigos;
    public int NumVidas;
    public int SaludInicial;
    public int MunicionInicial;
    public int ProbRecibirAtaque; // 0-100
    public int DuracionJuegoMs; // milisegundos
    public int PausaMs; // pausa por ciclo en ms
    public int EnemigosIntervaloMs; // cada cuánto aparece nuevo enemigo (ms)
}