namespace BaseDatosAlumnado.Structs;

// Estructura principal para almacenar los datos de un alumno.
public struct Alumno {
    public int Id; // Identificador único del alumno (autoincremental)
    public string Dni; // Clave primaria
    public string NombreCompleto;
    public double Nota;
}