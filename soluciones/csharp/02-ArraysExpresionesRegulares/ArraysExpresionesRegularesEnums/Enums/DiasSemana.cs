namespace ArraysExpresionesRegulares.Enums;

// Los enums representa aun conjunto de constantes bajo un mismo tipo de dato
// Por defecto el primer valor es 0 y van incrementandose en 1
// Podemos asignar valores específicos a cada uno de los elementos
// Si asignamos un valor específico a un elemento, los siguientes se incrementan a partir de ese valor
// Podemos cambiar el tipo de dato subyacente del enum (por defecto es int) usando ": tipoDato"
public enum DiasSemana {
    Lunes, 
    Martes, 
    Miercoles,
    Jueves, 
    Viernes = 12, 
    Sabado, 
    Domingo
}