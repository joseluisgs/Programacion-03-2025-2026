namespace _09_Buscaminas.Enums;

// Estado de la celda
public enum Celda {
    Oculta = -1, // Casilla aún sin revelar (estado inicial)
    Marcada = -2, // 🚩 Casilla marcada por el jugador (sospecha de mina)
    Mina = -3, // 💣 Casilla con mina (se revela al perder)

    Vacia = 0 // Casilla revelada sin minas alrededor (equivale al 0 en Buscaminas)
    // Si al revelar calculamos el número de minas adyacentes, el valor será 1..8 (cast implícito)
}