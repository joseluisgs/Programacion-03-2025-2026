/*
Tipos Nullables en C#
    - T? -> Tipo que puede tener valor T o ser null
    - int? x, es un numero que puede ser entero o null
    - Estudiante? e es un estudiante que puede ser un Estudiante o null
    - Debemos jugar con el != null, HasValue, Value, patrones de tipo, etc.
    - != null -> Es una comprobación directa de si el valor es distinto de null
    - (T) -> Es un casting directo de T? a T, pero si es null lanza una excepción
    - ! -> Es el operador llamado null-forgiving, que fuerza el acceso al valor no nulo, pero si es null lanza una excepción
    - HasValue -> Es una propiedad que me dice si el valor es null o no en un T?
    - Value -> Es una propiedad que me da el valor del T? en caso de que no sea null, es decir T
    - is T -> Es un operador que me dice si un objeto es de tipo T o T?, pero luego debemos acceder al valor con Value
    - is { } var -> Es un patrón que me dice si un objeto es no nulo, y si lo es lo asigna a la variable var, es decir var es del tipo T
    - ?. -> Es el operador de acceso seguro, que me permite acceder a los miembros de un objeto solo si no es null, en caso contrario devuelve null
*/



// Diego's Template

using System.Text;
using Nulos.Structs;

Console.OutputEncoding = Encoding.UTF8;
Console.Clear();

// Zonas de constantes
const int Size = 10;

// Ya tengo mi Main :)
Main(args);

// Para no cerrar inmediatamente
Console.WriteLine("👋 Presiona una tecla para salir...");
Console.ReadKey();
return;


void Main(string[] args) {
    Estudiante?[] listado = new Estudiante?[Size];
    RellenarEstudiantes(listado);
    for (int i = 0; i < listado.Length; i++) {
        // No se puede acceder directamente a los campos de un struct nullable
        // Console.WriteLine($"Estudiante {i + 1}: {listado[i].Id}");
        // Comprobar no nulo
        if (listado[i]!= null) {
            Estudiante estudiante = (Estudiante)listado[i]!; // Casting de nullable a no nulo
            Console.WriteLine($"Estudiante {i + 1}: {estudiante.Id} - {estudiante.Nombre} - {estudiante.Calificacion}");
        } else {
            Console.WriteLine($"Estudiante {i + 1}: No hay datos");
        }
        
        Console.WriteLine("---");
        
        if (listado[i]!= null) {
            // con Value accedemos al valor que puede existir en el tipo nullable
            Console.WriteLine($"Estudiante {i + 1}: {listado[i]!.Value.Id} - {listado[i]!.Value.Nombre} - {listado[i]!.Value.Calificacion} - {listado[i]!.Value.Curso ?? "Sin curso"}");
        } else {
            Console.WriteLine($"Estudiante {i + 1}: No hay datos");
        }
        
        Console.WriteLine("---");
        
        // Con HasValue comprobamos si tiene valor, es decir, si es distinto de null
        if (listado[i].HasValue) {
            // Con ! forzamos el acceso al valor no nulo
            Console.WriteLine(
                $"Estudiante {i + 1}: {listado[i]!.Value.Id} - {listado[i]!.Value.Nombre} - {listado[i]!.Value.Calificacion} - {listado[i]!.Value.Curso ?? "Sin curso"}");
        } else {
            Console.WriteLine($"Estudiante {i + 1}: No hay datos");
        }

        Console.WriteLine("---");
        
        // Usando patron de si es de tipo Estudiante
        if (listado[i] is Estudiante) {
            // con Value accedemos al valor no nulo
            Console.WriteLine($"Estudiante {i + 1}: {listado[i]!.Value.Id} - {listado[i]!.Value.Nombre} - {listado[i]!.Value.Calificacion} - {listado[i]!.Value.Curso ?? "Sin curso"}");
        } else {
            Console.WriteLine($"Estudiante {i + 1}: No hay datos");
        }
        
        Console.WriteLine("---");
        
        // Usando patron de no nulo con asignación directa al tipo
        if (listado[i] is { } est) {
            // con Value accedemos al valor no nulo
            Console.WriteLine($"Estudiante {i + 1}: {est.Id} - {est.Nombre} - {est.Calificacion} - {est.Curso ?? "Sin curso"}");
        } else {
            Console.WriteLine($"Estudiante {i + 1}: No hay datos");
        }
        
        Console.WriteLine("---");
        
      // Usando ?. el cual acceder a los valores de forma segura
      // Pero no es el adecuado para este caso, investiga que saldría.
      // Console.WriteLine($"Estudiante {i + 1}: {listado[i]?.Id} - {listado[i]?.Nombre} - {listado[i]?.Calificacion} - {listado[i]?.Curso?? "Sin curso"}");
    }
    
    var index = BuscarEstudiante(listado, 3);
    
    if (index != -1) {
        Console.WriteLine($"Estudiante encontrado en la posición {index}");
        Console.WriteLine($"{listado[index]?.Nombre}");
        Console.WriteLine($"{listado[index]?.Curso?.Length}");
    } else {
        Console.WriteLine("Estudiante no encontrado");
    }

    
}

void RellenarEstudiantes(Estudiante?[] estudiante) {
    for (var i = 0; i < estudiante.Length; i++) {
        if (i % 2 == 0) {
            estudiante[i] = new Estudiante {
                Id = i + 1,
                Nombre = $"Estudiante {i + 1}",
                Calificacion = 5.0 + i,
                Curso = (i % 4 == 0) ? "Programacion" : null
            };
        } else {
            estudiante[i] = null;
        }
    }
}

int BuscarEstudiante(Estudiante?[] estudiante, int i) {
    // Busqueda lineal
    for (var index = 0; index < estudiante.Length; index++) {
        /*if (estudiante[index] is { } est && est.Id == i) {
            return index;
        }*/
        if (estudiante[index]?.Id == i) {
            return index;
        }
    }

    return -1;
}
