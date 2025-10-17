### Guía del Lenguaje DAW

Esta guía proporciona una visión general de los conceptos básicos del lenguaje DAW, diseñado para ser sencillo y fácil de aprender.
Con ella podrás entender la sintaxis y las estructuras fundamentales necesarias para comenzar a programar. Es importante seguir las convenciones y buenas prácticas recomendadas para escribir código claro y mantenible.

- [Guía del Lenguaje DAW](#guía-del-lenguaje-daw)
  - [0. Comentarios](#0-comentarios)
  - [1. Estructura del Programa](#1-estructura-del-programa)
  - [2. Tipos de Datos](#2-tipos-de-datos)
  - [3. Variables y Constantes](#3-variables-y-constantes)
  - [4. Conversión de Tipos (Casting)](#4-conversión-de-tipos-casting)
  - [5. Enumeraciones](#5-enumeraciones)
  - [6. Operadores](#6-operadores)
  - [8. Entrada y Salida](#8-entrada-y-salida)
- [8. Programación Estructurada](#8-programación-estructurada)
  - [8.1. Secuencias](#81-secuencias)
  - [8.2. Condicionales](#82-condicionales)
  - [8.3. Bucles](#83-bucles)
- [9. Programación Modular](#9-programación-modular)
  - [9.1. Funciones y Procedimientos](#91-funciones-y-procedimientos)
  - [9.2. Parámetros y Argumentos](#92-parámetros-y-argumentos)
  - [9.3. Paso por Valor vs. Paso por Referencia](#93-paso-por-valor-vs-paso-por-referencia)
  - [9.4. Ámbito de las Variables](#94-ámbito-de-las-variables)
  - [9.5. Parámetros por Defecto, Opcionales y Nombrados](#95-parámetros-por-defecto-opcionales-y-nombrados)
  - [9.6. Sobrecarga de Funciones y Procedimientos](#96-sobrecarga-de-funciones-y-procedimientos)
  - [9.7. Parámetros Variables (`params`)](#97-parámetros-variables-params)
  - [9.8. Parámetros de Salida (`out`)](#98-parámetros-de-salida-out)
  - [9.9. Recursividad](#99-recursividad)
  - [9.10. Paquetes o Módulos](#910-paquetes-o-módulos)
- [10. Control de Excepciones](#10-control-de-excepciones)
  - [10.1. Bloques `try-catch` y `finally`](#101-bloques-try-catch-y-finally)
  - [10.2. Lanzar Excepciones (`throw`) y Aserciones (`assert`)](#102-lanzar-excepciones-throw-y-aserciones-assert)
- [11. Arrays (Arreglos)](#11-arrays-arreglos)
  - [11.1. Arrays Unidimensionales (Listas)](#111-arrays-unidimensionales-listas)
  - [11.2. Arrays Multidimensionales (Arrays Escalonados)](#112-arrays-multidimensionales-arrays-escalonados)
  - [11.3. Arrays con Tipos Anulables (`T?`) 💡](#113-arrays-con-tipos-anulables-t-)
    - [Valor por Defecto](#valor-por-defecto)
    - [Filtrado y Manejo de `null`](#filtrado-y-manejo-de-null)
    - [Ejemplo Completo (Array Unidimensional y Bidimensional)](#ejemplo-completo-array-unidimensional-y-bidimensional)
- [12. Cadenas de Texto (Strings)](#12-cadenas-de-texto-strings)
  - [12.1. Métodos de Limpieza y Transformación](#121-métodos-de-limpieza-y-transformación)
  - [12.2. Métodos de Verificación y Búsqueda](#122-métodos-de-verificación-y-búsqueda)
  - [12.3. Métodos de Sustitución y Extracción](#123-métodos-de-sustitución-y-extracción)
  - [12.4. StringBuilder (Construcción Eficiente de Cadenas)](#124-stringbuilder-construcción-eficiente-de-cadenas)
  - [12.5. Expresiones Regulares (Regex)](#125-expresiones-regulares-regex)
    - [Sintaxis Básica de Expresiones Regulares](#sintaxis-básica-de-expresiones-regulares)


-----

#### 0\. Comentarios

Notas que el programa ignora y sirven para explicar el código.

  * **Comentario de una línea:** Empieza con `//`.
    ```csharp
    // Esto es un comentario de una sola línea.
    int edad = 30; // También al final de una línea.
    ```
  * **Comentario de varias líneas:** Empieza con `/*` y finaliza con `*/`.
    ```csharp
    /*
    Este es un comentario
    que ocupa varias líneas.
    */
    ```

-----

#### 1\. Estructura del Programa

Todo el código se escribe dentro de un bloque principal `Main`, que es el punto de entrada que se ejecuta al iniciar el programa. Cada instrucción termina con punto y coma (`;`). El código es sensible a mayúsculas y minúsculas y los bloques de código se delimitan con llaves `{}`.
Además, se recomienda usar indentación (tabulaciones o espacios) para mejorar la legibilidad.

```csharp
Main {
    // Aquí va el código de nuestro programa.
    writeLine("¡Hola, mundo!");
}
```

-----

#### 2\. Tipos de Datos

Definen qué valores puede almacenar una variable. Los principales son:

  * **`int`**: Almacena números enteros. Su valor por defecto es `0`.
  * **`decimal`**: Almacena números con decimales de alta precisión. Su valor por defecto es `0.0`.
  * **`string`**: Almacena texto. Su valor por defecto es `""` (cadena vacía).
  * **`bool`**: Almacena `true` o `false`. Su valor por defecto es `false`.

-----

#### 3\. Variables y Constantes

Usaremos la convención **`camelCase`** para variables y `readonly`, y **`MAYUSCULAS_CON_GUIONES`** para constantes.

  * **Variables:** Contenedores cuyo valor puede cambiar. Es una buena práctica inicializarlas siempre. Son almacenadas en memoria y tienen un tipo fijo, deben declararse antes de usarse y su tipo no puede cambiar. Son de Lectura y Escritura, es decir, se pueden leer y modificar.
    ```csharp
    Main {
      int edad = 20;
      string nombre = "Ana";
    }
    ```
    * Declaración: `tipo nombre = valor_inicial;` Ejemplo: `int contador = 0;`
    * Asignación: `nombre = "Pedro";` (cambia el valor de la variable)
    * Inicialización: Asignar un valor al declararla.
   
     ```csharp
     Main {
      int contador;        // Declaración sin inicializar (no recomendado)
      contador = 0;       // Asignación posterior
      int total = 100;    // Declaración e inicialización en una línea (recomendado)
    }
    ```

  * **Inferencia de Tipos con `var`:** El compilador deduce el tipo a partir del valor. La variable debe ser inicializada y su tipo no puede cambiar después.
    ```csharp
    Main {
      var edad = 25;        // Se infiere que es int
      var nombre = "Juan";  // Se infiere que es string
      // var x;      // ERROR: no se puede inferir sin un valor
      // edad = "Pedro";  // ERROR: una vez es int, no puede ser string
    }
    ```
  * **Variables Nulas (`?`):** Para permitir que una variable almacene `null` (ausencia de valor), se añade `?`. `null` es diferente de un valor por defecto como `0` o `""`. Debes tener cuidado al usar variables que pueden ser `null` para evitar errores en tiempo de ejecución.
    ```csharp
    Main {
      string apellido = "";        // Caja con una cadena vacía
      string? segundoApellido = null; // La caja está vacía, no hay valor
      int? edadOpcional = null;
    }
    ```
  * **Constantes (`const`):** Valores fijos que no pueden cambiar y deben inicializarse al declararse. Son útiles para valores que no deben modificarse.
    ```csharp
    Main {
      const decimal PI = 3.1416m;
      const int MAX_ALUMNOS = 30;
    }
    ```
  * **Variables de solo lectura (`readonly`):** Su valor se asigna una sola vez (al declarar o después) y luego no puede cambiar. 
    ```csharp
    Main {
      readonly string version = "1.0";
      readonly int anoNacimiento;
      anoNacimiento = 1990; // Se asigna una vez
      // anoNacimiento = 1991; // ERROR: ya fue asignado
    }
    ```
-----

#### 4\. Conversión de Tipos (Casting)

Es el proceso de cambiar un valor de un tipo a otro.

  * **Conversión Implícita:** El lenguaje la realiza automáticamente si no hay riesgo de perder datos. Esto sucede al convertir de un tipo "más pequeño" a uno "más grande", se llama conversión por ampliación.
    ```csharp
    Main {
      int numeroInt = 10;
      decimal numeroDecimal = numeroInt; // Conversión implícita de int a decimal
    }
    ```
  * **Conversión Explícita:** Se indica manualmente con `(tipo)` cuando puede haber pérdida de información. Se llama conversión por estrechamiento, de un tipo "más grande" a uno "más pequeño".
    ```csharp
    Main {
      decimal numeroDecimal = 9.8m;
      int numeroInt = (int)numeroDecimal; // Se trunca la parte decimal, el resultado es 9
    }
    ```

-----

#### 5\. Enumeraciones

Permite crear un tipo de dato con un conjunto de constantes con nombre, haciendo el código más legible.

```csharp
Main {
  // Definición de la enumeración
  enum DiasSemana { LUNES, MARTES, MIERCOLES, JUEVES, VIERNES, SABADO, DOMINGO }

  // Uso de la enumeración
  var hoy = DiasSemana.Miercoles;
  writeLine("Hoy es " + hoy); // Muestra "Hoy es MIERCOLES"

  var mañana = DiasSemana.Jueves;
  writeLine("Mañana es " + mañana); // Muestra "Mañana es JUEVES"
}
```


-----

#### 6\. Operadores

  * **Operadores Aritméticos:** `+`, `-`, `*`, `/`, `%` (módulo o resto).
    *La división `/` se comporta diferente según el tipo:*
    ```csharp
    Main {
      int resultadoEntero = 9 / 2;      // Resultado: 4 (división entera)
      decimal resultadoDecimal = 9.0 / 2.0; // Resultado: 4.5 (división decimal)
    }
    ```
  * **Operadores de Asignación:** `=`, `+=`, `-=`, `*=`, `/=`.
    ```csharp
    Main {
      int contador = 0;
      contador += 5; // Equivalente a contador = contador + 5
      contador *= 2; // Equivalente a contador = contador * 2
    }
    ```
  * **Operadores de Comparación:** `==`, `!=`, `>`, `<`, `>=`, `<=`. Devuelven `bool`.
  
  ```csharp
    Main {
      int a = 5;
      int b = 10;
      bool esIgual = (a == b); // false
      bool esDiferente = (a != b); // true
      bool esMayor = (a > b); // false
      bool esMenorIgual = (a <= b); // true
    }
    ```
  * **Operadores Lógicos:** `&&` (Y), `||` (O), `!` (NO).
    ```csharp
    Main {
      bool esMayor = true;
      bool tienePermiso = false;
      bool puedeEntrar = esMayor && tienePermiso; // Resultado: false
      bool puedeSalir = esMayor || tienePermiso; // Resultado: true
      bool noEsMayor = !esMayor; // Resultado: false
    }
    ```
  * **Concatenación de Cadenas:** El operador `+` une cadenas de texto.
    ```csharp
    Main {
      int edad = 20;
      // Para operaciones matemáticas, usar paréntesis:
      writeLine("Dentro de 5 años tendrás " + (edad + 5)); // Muestra "Dentro de 5 años tendrás 25"
    }
    ```
  * **Operador Ternario (`? :`):** Selecciona entre dos valores según una condición.
    ```csharp
    Main {
      int edad = 20;
      string mensaje = (edad >= 18) ? "Eres mayor de edad" : "Eres menor de edad";
      writeLine(mensaje); // Muestra "Eres mayor de edad"
    }
    ```
  * **Operador de Nulidad (`??`):** Proporciona un valor por defecto si una variable es `null`.
    ```csharp
    Main {
      string? nombre = null;
      string nombreFinal = nombre ?? "Desconocido";
      writeLine(nombreFinal); // Muestra "Desconocido"
    }
    ```

-----

#### 7\. Precedencia de Operadores

Determina el orden en que se evalúan los operadores en una expresión. Los operadores con mayor precedencia se evalúan antes que los de menor precedencia. Si dos operadores tienen la misma precedencia, se evalúan de izquierda a derecha.

| Precedencia | Descripción                | Operadores                       |
| :---------: | :------------------------- | :------------------------------- |
|    **1**    | Paréntesis                 | `()`                             |
|    **2**    | Multiplicativos            | `*`, `/`, `%`                    |
|    **3**    | Aditivos                   | `+`, `-`                         |
|    **4**    | Relacionales y de Igualdad | `>`, `<`, `>=`, `<=`, `==`, `!=` |
|    **5**    | Lógico NOT (Unario)        | `!` (NO)                         |
|    **6**    | Lógico AND                 | `&&` (Y)                         |
|    **7**    | Lógico OR                  | `                                |  | ` (O) |
|    **8**    | Operador de Nulidad        | `??`                             |
|    **9**    | Operador Ternario          | `? :`                            |
|   **10**    | Asignación                 | `=`, `+=`, `-=`, `*=`            |

```csharp
Main {
  // Ejemplos de precedencia
  int resultado1 = 5 + 2 * 3; // 5 + (2 * 3) = 11
  int resultado2 = (5 + 2) * 3; // 7 * 3 = 21

  // Ejemplo de relacionales y lógicos
  bool esVerdadero = (5 > 3) && (2 < 4); // true && true = true
  bool esFalso = (5 < 3) || (2 > 4); // false || false = false
  bool esAmbos = (5 > 3) && (2 > 4); // true && true = true

  // Ejemplo de Nulidad vs. Ternario (precedencia 8 vs 9)
  string? nombre = null;
  string saludo = (nombre != null) ? "Hola, " + nombre : "Hola, Invitado"; // Comparación (4) se evalúa antes que Ternario (9)
  string saludo2 = "Hola, " + (nombre ?? "Invitado"); // Evaluación de nulidad (8) se evalúa antes que concatenación (3)


  // Ejemplo de Nulidad vs. Operadores Lógicos (precedencia 8 vs 6/7)
  string? usuario = null;
  string nombreFinal = usuario ?? "Invitado"; // Evaluación de nulidad (8)

  bool acceso = (nombreFinal != "Invitado") && true; // Comparación (4) se evalúa antes que AND (6)

  writeLine("Resultado1: " + resultado1); 
  writeLine("Nombre Final: " + nombreFinal);
  writeLine("Acceso concedido: " + acceso); // Muestra "Acceso concedido: false"
}
```


-----

#### 8\. Entrada y Salida

  * **Salida (`writeLine`):** Muestra texto o valores en la consola.
    ```csharp
    Main 
      string nombre = "Ana";
      writeLine("Hola, " + nombre);
    }
    ```
  * **Entrada (`readLine`):** Lee texto introducido por el usuario. **Siempre devuelve un `string`**, por lo que necesita casting explícito para convertirlo a otros tipos.
    ```csharp
    Main {
      // Leer un string
      writeLine("Introduce tu nombre:");
      string nombreUsuario = readLine();

      // Leer un entero (int)
      writeLine("Introduce tu edad:");
      int edadUsuario = (int)readLine();

      // Leer un decimal
      writeLine("Introduce el precio:");
      decimal precioProducto = (decimal)readLine();

      // Leer un booleano (bool)
      writeLine("¿Estás de acuerdo? (true/false):");
      bool acuerdo = (bool)readLine();
    }
    ```

-----


### 8\. Programación Estructurada

La **programación estructurada** es un paradigma que busca crear programas más claros y fáciles de mantener. Se basa en el **Teorema de la programación estructurada**, que demuestra que cualquier algoritmo puede ser implementado utilizando únicamente tres estructuras de control básicas: **secuencia**, **condicional** y **bucle**.

#### 8.1. Secuencias

Es la estructura más simple, donde las instrucciones se ejecutan una tras otra, en el orden en que están escritas.

```csharp
Main {
    // Ejemplo de Secuencia
    writeLine("Hola");
    writeLine("¿Cómo estás?");

    // Leemos el nombre del usuario
    writeLine("Por favor, introduce tu nombre:");
    string nombre = readLine();

    // Mostramos un saludo personalizado
    writeLine("Encantado de conocerte, " + nombre);
}
```

#### 8.2. Condicionales

Permiten que el programa tome decisiones y se comporte de manera diferente según las circunstancias.

  * **Condicional simple (`if`)**: Evalúa una condición booleana y ejecuta un bloque de código si es verdadera.
  * **Condicional compuesto (`if-else`)**: Permite ejecutar un bloque de código si se cumple una condición y otro si no.
  * **Condicionales múltiples (`if-else if-else`)**: Permiten encadenar varias condiciones. El programa evalúa las condiciones en orden y ejecuta el bloque de la primera que sea verdadera.
  * **Estructura `switch`**: Ofrece una alternativa más limpia a una larga cadena de `if-else if` para comparar una única variable con múltiples valores posibles.

<!-- end list -->

```csharp
Main {
    // Condicionales múltiples
    var edadAlumno = 16;
    if (edadAlumno >= 18) {
        writeLine("Eres mayor de edad.");
    } else if (edadAlumno >= 16) {
        writeLine("Casi eres mayor de edad.");
    } else {
        writeLine("Eres menor de edad.");
    }

    // Ejemplo de switch
    var dia = 3;
    string nombreDelDia;

    switch (dia) {
        case 1:
            nombreDelDia = "Lunes";
            break;
        case 2:
            nombreDelDia = "Martes";
            break;
        case 3:
            nombreDelDia = "Miércoles";
            break;
        case 6:
        case 7:
            nombreDelDia = "Fin de semana";
            break;
        default:
            nombreDelDia = "Día inválido";
            break;
    }
    writeLine("Hoy es: " + nombreDelDia);
}
```

#### 8.3. Bucles

Los bucles permiten repetir un bloque de código varias veces.

  * **Bucles indefinidos (`while` y `do-while`)**: Se ejecutan mientras se cumpla una condición y son útiles cuando no se sabe cuántas iteraciones se necesitarán. El `do-while` garantiza que se ejecute al menos una vez.
  * **Bucles definidos (`for`)**: Se utilizan cuando se sabe de antemano cuántas veces se quiere repetir un bloque de código. Se componen de tres partes: inicialización, condición y actualización. `for each` es una variante que recorre cada elemento de una colección.
  * **Recorriendo arrays con `for` y `for each`**: Una aplicación común de los bucles es recorrer colecciones de datos, como arrays.

<!-- end list -->

```csharp
Main {
    // Ejemplo de bucle while
    var contador = 0;
    while (contador < 5) {
        writeLine("Contador: " + contador);
        contador = contador + 1;
    }

    // Ejemplo de bucle do-while
    var numero = 0;
    do {
        writeLine("Número: " + numero);
        numero = numero + 1;
    } while (numero < 3);

    // Ejemplo de bucle for
    for (int i = 0; i <= 5; i = i + 1) {
        writeLine("Contador for: " + i);
    }

    // Ejemplo de bucle for each
    string[] nombres = {"Ana", "Luis", "Marta"};
    for each (var nombre in nombres) {
        writeLine("Hola, " + nombre);
    }
}
```

-----

### 9\. Programación Modular

La **programación modular** es un paradigma que divide un programa grande en partes más pequeñas e independientes, llamadas **módulos**. Las ventajas son que facilita la resolución del problema, aumenta la claridad y permite que varios programadores trabajen en el mismo proyecto. La descomposición modular se basa en la técnica "Divide y Vencerás" (DAC o Divide And Conquer).

#### 9.1. Funciones y Procedimientos

  * **Función**: Un bloque de código que realiza una tarea específica y **devuelve un valor** mediante la sentencia `return`.
  * **Procedimiento**: Similar a una función, pero **no devuelve ningún valor**.

<!-- end list -->

```csharp
// Función
function int sumar(int a, int b) {
    return a + b;
}

// Procedimiento
procedure saludar(string nombre) {
    writeLine("Hola, " + nombre + "!");
}

Main {
    int resultado = sumar(5, 3);
    writeLine("La suma es: " + resultado);
    saludar("Ana");
}
```

#### 9.2. Parámetros y Argumentos

Los **parámetros** son las variables definidas en la declaración de una función o procedimiento. Los **argumentos** son los valores reales que se pasan al llamar a la función.

En el lenguaje DAW, se aplica una estricta **seguridad y estrictez de tipos** para el paso de argumentos a parámetros:

1.  **Coincidencia Exacta de Tipos:** Los tipos de los argumentos pasados a una función o procedimiento **deben coincidir exactamente** con los tipos de los parámetros definidos.

2.  **Casting Explícito Obligatorio:** Se exige el *casting* explícito para cualquier conversión, incluso de un tipo de rango menor a uno de rango mayor (conversión por ampliación). Esto se hace para evitar cualquier ambigüedad y forzar al programador a ser consciente de la conversión que está realizando.

      * **Ejemplo de Casting Obligatorio:**

    <!-- end list -->

    ```csharp
    // Función que espera un decimal (mayor rango)
    function decimal calcularImpuesto(decimal baseImponible) {
        return baseImponible * 0.21m;
    }

    Main {
        int valorEntero = 100;
        
        // calcularImpuesto(valorEntero); // ERROR: Tipos no coinciden y el casting implícito está prohibido.
        
        // CORRECCIÓN: Se requiere casting explícito.
        decimal total = calcularImpuesto((decimal)valorEntero); 
        writeLine("Impuesto calculado: " + total);
    }
    ```

3.  **Excepción Segura (Conversión a Anulable):** La única excepción donde se permite una conversión automática (implícita) es la de un tipo base (`T`) a su versión anulable (`T?`), ya que es una conversión de contenedor sin riesgo de pérdida de datos o de valor.

    ```csharp
    string nombre = "Ana";
    string? nombreAnulable = nombre; // OK: Conversión segura (T a T?)
    ```

4.  **Prohibición Inversa:** Se prohíbe el paso directo de un tipo anulable (`T?`) a un tipo base (`T`). Esto obliga al desarrollador a verificar y gestionar explícitamente el estado `null` para evitar errores en tiempo de ejecución.

      * **Uso del Operador de Nulidad (`??`):** Una forma segura es proporcionar un valor por defecto si la variable es `null`.

    <!-- end list -->

    ```csharp
    procedure procesar(string nombre) {
        writeLine("Procesando: " + nombre);
    }

    Main {
        string? nombreOpcional = null;

        // procesar(nombreOpcional); // ERROR: No se puede pasar T? a T directamente
        
        // FORMA SEGURA: Usando el operador de nulidad ??
        procesar(nombreOpcional ?? "Usuario Invitado"); // Pasa "Usuario Invitado"
        
        nombreOpcional = "Luis";
        procesar(nombreOpcional ?? "Usuario Invitado"); // Pasa "Luis"
    }
    ```



#### 9.3. Paso por Valor vs. Paso por Referencia

  * **Paso por valor**: La función recibe una **copia** del dato original. Los cambios dentro de la función no afectan a la variable original fuera de ella. Es el comportamiento por defecto en DAW.
  * **Paso por referencia (`ref`)**: La función recibe la **dirección de memoria** de la variable original. Cualquier cambio que hagas al parámetro dentro de la función modificará directamente la variable original.

<!-- end list -->

```csharp
// Ejemplo de paso por referencia
procedure duplicar(ref int numero) {
    numero = numero * 2;
}

Main {
    var valorOriginal = 10;
    writeLine("Antes de la llamada: " + valorOriginal); // Imprime 10
    duplicar(ref valorOriginal);
    writeLine("Después de la llamada: " + valorOriginal); // Imprime 20
}
```

#### 9.4. Ámbito de las Variables

El **ámbito** de una variable determina dónde puede ser accedida o modificada.

  * **Ámbito global**: Las variables declaradas fuera de cualquier función y son accesibles desde cualquier parte del programa. **Su uso excesivo no es recomendable**.
  * **Ámbito local**: Las variables declaradas dentro de una función o procedimiento, y solo pueden ser accedidas y modificadas dentro de ese bloque.

<!-- end list -->

```csharp
var contadorGlobal = 0;
procedure incrementarContador() {
    var contadorLocal = 0;
    contadorLocal = contadorLocal + 1;
    contadorGlobal = contadorGlobal + 1;
    writeLine("Contador Local: " + contadorLocal);
    writeLine("Contador Global: " + contadorGlobal);
}

Main {
    incrementarContador();
    incrementarContador();
}
```

#### 9.5. Parámetros por Defecto, Opcionales y Nombrados

  * **Parámetros por defecto**: Permiten definir un valor predeterminado para un parámetro.
  * **Parámetros opcionales**: Son parámetros con valores por defecto que se pueden omitir al llamar a la función.
  * **Parámetros nombrados**: Permiten especificar los nombres de los parámetros al llamar a una función, permitiendo pasar argumentos en un orden diferente.

<!-- end list -->

```csharp
procedure mostrarInfo(string nombre, int edad = 18) {
    writeLine("Nombre: " + nombre);
    writeLine("Edad: " + edad);
}

Main {
    mostrarInfo("Ana", 25);
    mostrarInfo("Marta");
}
```

#### 9.6. Sobrecarga de Funciones y Procedimientos

La **sobrecarga** permite definir múltiples funciones o procedimientos con el mismo nombre, pero con diferentes listas de parámetros (diferente número o tipos de parámetros).

```csharp
function int calcularArea(int lado) {
    return lado * lado;
}

function decimal calcularArea(decimal radio) {
    return 3.1416m * radio * radio;
}

Main {
    int areaCuadrado = calcularArea(5);
    decimal areaCirculo = calcularArea(3.5m);
}
```

#### 9.7. Parámetros Variables (`params`)

Permiten que una función acepte un número indeterminado de valores.

```csharp
function int sumarTodos(params int numeros) {
    int suma = 0;
    foreach (var num in numeros) {
        suma = suma + num;
    }
    return suma;
}

Main {
    int total = sumarTodos(1, 2, 3, 4, 5);
}
```

#### 9.8. Parámetros de Salida (`out`)

Permiten que una función o procedimiento devuelva múltiples valores. No es necesario inicializar las variables que se pasan como parámetros de salida.

```csharp
procedure obtenerDatos(out string nombre, out int edad) {
    nombre = "Ana";
    edad = 25;
}

Main {
    string nombre;
    int edad;
    obtenerDatos(out nombre, out edad);
    writeLine("Nombre: " + nombre + ", Edad: " + edad);
}
```

#### 9.9. Recursividad

Es una técnica que consiste en llamar a una función o procedimiento dentro de sí mismo. Es importante incluir una **condición de parada** para evitar un bucle infinito.

```csharp
function int factorial(int n) {
    if (n <= 1) {
        return 1;
    } else {
        return n * factorial(n - 1);
    }
}
```

#### 9.10. Paquetes o Módulos

Un **paquete** o **módulo** (también conocido como librería) es un archivo o conjunto de archivos que agrupa funciones, procedimientos y tipos de datos relacionados. Para usarlas, se deben importar con la palabra clave `using`.

```csharp
using Math;

Main {
    decimal raiz = Math.sqrt(16.0m);
    int numeroAleatorio = Math.random(1, 10);
}
```

### 10\. Control de Excepciones

El **control de excepciones** es una técnica para gestionar errores inesperados que ocurren durante la ejecución de un programa. En DAW, las excepciones son **no requeridas** (unchecked), lo que significa que el compilador no te obliga a manejarlas, ofreciendo un código más limpio a cambio de una mayor responsabilidad del desarrollador para prevenirlos. La clase base de todas las excepciones es **`Exception`**.

#### 10.1. Bloques `try-catch` y `finally`

  * **`try`**: Encierra el código que podría generar un error.
  * **`catch`**: Captura y maneja una excepción si ocurre en el bloque `try`.
  * **`finally`**: Contiene código que se ejecuta siempre, independientemente de si hubo una excepción o no.

<!-- end list -->

```csharp
Main {
    try {
        int resultado = 10 / 0; // Esto generará una excepción
    } catch (Exception e) {
        writeLine("Error: " + e.message); // Captura el error
    } finally {
        writeLine("El proceso ha terminado.");
    }
}
```

#### 10.2. Lanzar Excepciones (`throw`) y Aserciones (`assert`)

  * **`throw`**: Se usa para lanzar una excepción de forma manual, interrumpiendo el flujo del programa. Es útil para validar errores de lógica de negocio.
  * **`assert`**: Es una herramienta de depuración que verifica una condición. Si es falsa, lanza una `AssertionException`. Se utiliza para validar supuestos durante el desarrollo, no para datos de usuario. No es recomendable dejar aserciones en el código de producción, ya que están destinadas a detectar errores lógicos durante la fase de desarrollo y prueba.

<!-- end list -->

```csharp
function decimal dividir(int numerador, int divisor) {
    // Lanzar una excepción de forma manual si el divisor es cero
    if (divisor == 0) {
        throw new DivideByZeroException("No se puede dividir por cero.");
    }
    return (decimal)numerador / divisor;
}

function validarEdad(int edad) {
    // Usar una aserción para la depuración
    assert(edad > 0, "La edad debe ser un número positivo.");
}
```

### 11\. Arrays (Arreglos)

Los arrays son colecciones de elementos del mismo tipo, almacenados en posiciones contiguas de memoria. Se definen usando corchetes `[]`. El tamaño de un array se define en el momento de su creación y no puede cambiarse posteriormente. Por lo tanto, los arrays tienen un tamaño fijo. Si se necesita cambiar su tamaño, es recomendable crear un nuevo array y copiar los elementos.

Se caracterizan por:

  * **Tipo Fijo:** Todos los elementos son del mismo tipo, lo fijamos en la declaración, y podemos consultarlo gracias a la propiedad `Length`.
  * **Acceso por Índice:** Cada elemento se accede mediante su posición (índice), que comienza en `0`.
  * **Dimensiones:** Pueden ser unidimensionales (listas) o multidimensionales (matrices). **En DAW, para las matrices, se usa el modelo de Array Escalonado (o Array de Arrays).**
  * **Inmutabilidad del Tamaño:** Una vez creado, el tamaño del array no puede cambiarse.
  * **Eficiencia:** Permiten acceso rápido a los elementos mediante su índice.
  * **Inicialización Automática (Valores por Defecto):** Los arrays se inicializan automáticamente con los valores por defecto del tipo: **0** para `int`, **`0.0`** para `decimal`, **`""`** (cadena vacía) para `string`, **`false`** para `bool`, y **`null`** para tipos anulables.

Para su **declaración** y **creación** se usa la siguiente sintaxis:

```csharp
// Declaración y creación de un array vacío con tamaño fijo:
tipo[] nombreDelArray = tipo[tamaño]; 
writeLine(nombreDelArray.Length); // Propiedad para conocer el tamaño del array
```

#### 11.1. Arrays Unidimensionales (Listas)

Los arrays unidimensionales son colecciones de elementos del mismo tipo, organizados en una sola dimensión (una lista). Se accede a sus elementos mediante un índice.

  * **Array Unidimensional:**

```csharp
Main {
  var size = 4;
  
  // 1. Declaración e Inicialización con Valores Específicos
  int[] numeros = {10, 20, 30, 40};

  // 2. Declaración e Inicialización por Defecto (Tamaño Fijo)
  int[] numerosVacios = int[size]; // Por defecto todos son 0
  writeLine("Primer elemento vacío: " + numerosVacios[0]); // Muestra 0

  // 3. Recorrido Estándar con Bucle for
  writeLine("--- Recorrido con FOR ---");
  for (int i = 0; i < numeros.Length; i++) { 
    writeLine("Elemento en índice " + i + ": " + numeros[i]);
  }

  // 4. Recorrido Simplificado con Bucle foreach (Se usa junto en DAW)
  writeLine("--- Recorrido con FOREACH ---");
  foreach (var num in numeros) {
    writeLine("Número: " + num);
  }
}
```

#### 11.2. Arrays Multidimensionales (Arrays Escalonados)

En el lenguaje DAW, los arrays multidimensionales se implementan bajo el modelo de **Array de Arrays** o **Array Escalonado** (*Jagged Array*). Por simplicidad sintáctica y didáctica, se permite la inicialización del tamaño de ambas dimensiones a la vez, aunque conceptualmente cada fila sea independiente.

  * **Array Bidimensional (Array Cuadrado/Rectangular):**

<
```csharp
Main {
  var size = 3; 

  // 1. Declaración e Inicialización con Valores Específicos (3x3)
  int[][] matrizCuadrada = {
    int[] {1, 2, 3},
    int[] {4, 5, 6},
    int[] {7, 8, 9}
  };
  writeLine("Elemento [1][1]: " + matrizCuadrada[1][1]); // Muestra 5

  // 2. Declaración e Inicialización por Defecto (Sintaxis simplificada de DAW)
  int[][] matrizVacia = int[size][size]; // Crea un array de 'size' filas, con cada fila de 'size' columnas.
  writeLine("Elemento [0][0] vacío: " + matrizVacia[0][0]); // Muestra 0

  // 3. Recorrido con Bucle FOR
  writeLine("--- Recorrido Cuadrado con FOR ---");
  for (int i = 0; i < matrizCuadrada.Length; i++) { // Bucle exterior: número de filas
    for (int j = 0; j < matrizCuadrada[i].Length; j++) { // Bucle interior: longitud de la fila actual
      writeLine("Elemento en [" + i + "][" + j + "]: " + matrizCuadrada[i][j]);
    }
  }

  // 4. Recorrido con Bucle FOREACH
  writeLine("--- Recorrido Cuadrado con FOREACH ---");
  for each (var fila in matrizCuadrada) { // Recorre cada array interno (fila)
    for each (var elemento in fila) { // Recorre cada elemento de la fila actual
      writeLine("Elemento: " + elemento);
    }
  }
}
```

  * **Array Escalonado con Filas/Columnas Distintas:**

Este ejemplo demuestra la flexibilidad real del modelo de Array Escalonado, donde la longitud de cada fila no es necesariamente uniforme.

```csharp
Main {
  var filas = 3;
  
  // 1. Declaración e Inicialización por Defecto (Solo la primera dimensión se inicializa)
  // El tamaño de las columnas debe asignarse por separado para que sean distintas
  int[][] matrizDistinta = int[filas][]; // Array de 3 filas, columnas no definidas aún

  // 2. Asignación de tamaño y valores (filas con distinta longitud)
  matrizDistinta[0] = int[] {10, 20};       // Fila 0 con 2 elementos
  matrizDistinta[1] = int[] {30, 40, 50, 60}; // Fila 1 con 4 elementos
  matrizDistinta[2] = int[] {70};           // Fila 2 con 1 elemento
  
  writeLine("Total de Filas: " + matrizDistinta.Length); // Muestra 3
  writeLine("Longitud de Fila 1: " + matrizDistinta[1].Length); // Muestra 4

  // Tambien podemos definir las columnas solo su tamaño, porque ya sabes que usan los valores por defecto
  matrizDistinta[0] = int[2]; // Fila 0 con 2 elementos (inicializados a 0) 
  matrizDistinta[1] = int[4]; // Fila 1 con 4 elementos (inicializados a 0)
  matrizDistinta[2] = int[1]; // Fila 2 con 1 elemento (inicializado a 0)

  // 3. Recorrido con Bucle FOR
  writeLine("--- Recorrido Distinto con FOR ---");
  for (int i = 0; i < matrizDistinta.Length; i++) { 
    writeLine("Fila " + i + " tiene " + matrizDistinta[i].Length + " elementos:");
    for (int j = 0; j < matrizDistinta[i].Length; j++) { 
      writeLine("  -> Elemento: " + matrizDistinta[i][j]);
    }
  }
}
```

Esa es una pregunta excelente y crucial para los alumnos de DAW, ya que la gestión de la nulidad es fundamental en cualquier lenguaje moderno.

Aquí tienes la ampliación de la sección **11. Arrays (Arreglos)**, detallando el manejo de arrays con tipos anulables (`?`):


#### 11.3. Arrays con Tipos Anulables (`T?`) 💡

Cuando un array se declara de un tipo anulable (ej. `int?[]`, `string?[]`), su comportamiento respecto a la inicialización y el manejo del valor `null` es el siguiente:

##### Valor por Defecto

El valor por defecto de cualquier elemento de un array de tipo anulable (`T?`) es **`null`**.

Esto significa que cuando declaras un array de tamaño fijo sin asignarle valores iniciales, todos sus elementos internos apuntan a la nada, esperando a ser rellenados, lo que es especialmente útil para representar datos opcionales o ausentes.

```csharp
Main {
  var size = 3;
  
  // Array Unidimensional de Enteros Anulables
  int?[] notasOpcionales = int?[size]; // Inicializado con {null, null, null}
  writeLine("Primer elemento (debería ser null): " + notasOpcionales[0]); // Null Pointer Exception si se intenta usar sin comprobar
  // Usalo como quieras, pero recuerda comprobar si es null antes de usarlo.
  if (notasOpcionales[0] != null) {
    writeLine("Nota real: " + notasOpcionales[0]);
  } else {
    writeLine("No hay nota asignada.");
  }
  
  // O usa el operador de nulidad para asignar un valor por defecto
  int notaSegura = notasOpcionales[0] ?? 0; // Si es null, usa 0
  writeLine("Nota para cálculo: " + notaSegura); // Muestra 0

  // Tambien puedes usar el operador ternario
  int notaSegura2 = (notasOpcionales[0] != null) ? notasOpcionales[0] : 0;
  writeLine("Nota para cálculo (ternario): " + notaSegura2); // Muestra 0


  // Array Bidimensional de Cadenas Anulables
  var filas = 2;
  var columnas = 2;
  string?[][] nombresOpcionales = string?[filas][columnas]; // Inicializado con null en todas las posiciones
  writeLine("Elemento [0][0] (debería ser null): " + nombresOpcionales[0][0]); // Null Pointer Exception si se intenta usar sin comprobar
  
  // Usalo como quieras, pero recuerda comprobar si es null antes de usarlo.
  if (nombresOpcionales[0][0] != null) {
    writeLine("Nombre real: " + nombresOpcionales[0][0]);
  } else {
    writeLine("No hay nombre asignado.");
  }
  
  // O usa el operador de nulidad para asignar un valor por defecto
  string nombreSeguro = nombresOpcionales[0][0] ?? "[Desconocido]"; // Si es null, usa "[Desconocido]"
  writeLine("Nombre para mostrar: " + nombreSeguro); // Muestra "[Desconocido]"

  // Tambien puedes usar el operador ternario
  string nombreSeguro2 = (nombresOpcionales[0][0] != null) ? nombresOpcionales[0][0] : "[Desconocido]";
  writeLine("Nombre para mostrar (ternario): " + nombreSeguro2); // M

}
```

##### Filtrado y Manejo de `null`

Existen dos métodos principales para gestionar la posible nulidad de un elemento dentro de un array, ya sea unidimensional o bidimensional:

1.  **Condicional Explícito (`if`):** La forma más clara y recomendada para la toma de decisiones.
2.  **Operador de Nulidad (`??` - Coalescencia):** La forma concisa y funcional para proporcionar un valor alternativo cuando el elemento es `null`.
3.  **Operador Ternario (`? :`):** Una forma intermedia que permite evaluar una condición y elegir entre dos valores.


##### Ejemplo Completo (Array Unidimensional y Bidimensional)

Este ejemplo demuestra la declaración, la inicialización por defecto con `null`, y las dos formas de gestionar ese valor.

```csharp
Main {
  // 1. Array Unidimensional de Enteros Anulables
  var size = 3;
  int?[] notasOpcionales = int?[size]; // Inicializado con {null, null, null}
  
  // Asignamos un valor real al primer elemento y dejamos los demás 'null'
  notasOpcionales[0] = 8;
  
  writeLine("--- Array Unidimensional (int?[]) ---");
  for (int i = 0; i < notasOpcionales.Length; i++) {
    
    // FILTRADO 1: Condicional Explícito (IF)
    if (notasOpcionales[i] != null) {
      writeLine("Índice " + i + ": Nota real: " + notasOpcionales[i]); 
    } else {
      writeLine("Índice " + i + ": No hay nota.");
    }

    // FILTRADO 2: Operador de Nulidad (?? - Coalescencia)
    // Asigna un valor por defecto (0) para usarlo en la operación.
    int notaSegura = notasOpcionales[i] ?? 0;
    writeLine("Índice " + i + ": Nota para cálculo: " + notaSegura);

    // FILTRADO 3: Operador Ternario (? :)
    int notaSegura2 = (notasOpcionales[i] != null) ? notasOpcionales[i] : 0;
    writeLine("Índice " + i + ": Nota para cálculo (ternario): " + notaSegura2);
  }

  // ----------------------------------------------------------------------
  
  // 2. Array Bidimensional de Cadenas Anulables
  var filas = 2;
  var columnas = 2;
  string?[][] nombresOpcionales = string?[filas][columnas]; // Inicializado con null en todas las posiciones
  
  // Asignamos algunos valores
  nombresOpcionales[0][0] = "Ana";
  // nombresOpcionales[0][1] queda en null
  nombresOpcionales[1][0] = "Beto";
  // nombresOpcionales[1][1] queda en null
  
  writeLine("\n--- Array Bidimensional (string?[][]) ---");
  for each (var fila in nombresOpcionales) {
    for each (var nombre in fila) {
      // FILTRADO: Operador de Nulidad (??)
      string nombreSeguro = nombre ?? "[Desconocido]"; 
      writeLine("Nombre: " + nombreSeguro);
    }
  }
}
```

### 12\. Cadenas de Texto (Strings)

Las cadenas de texto (*strings*) son inmutables, lo que significa que cualquier método que parezca modificar una cadena en realidad devuelve una **nueva** cadena con el resultado. Estas operaciones son cruciales para el pre-procesamiento de datos.

#### 12.1. Métodos de Limpieza y Transformación

Estos métodos se usan para normalizar los datos de entrada, haciéndolos consistentes antes de la validación o el almacenamiento.

| Método              | Descripción                                             | Devuelve |
| :------------------ | :------------------------------------------------------ | :------- |
| `frase.ToUpper()`   | Convierte toda la cadena a **MAYÚSCULAS**.              | `string` |
| `frase.ToLower()`   | Convierte toda la cadena a **minúsculas**.              | `string` |
| `frase.Trim()`      | Elimina los **espacios en blanco** iniciales y finales. | `string` |
| `frase.TrimStart()` | Elimina los espacios en blanco solo al **principio**.   | `string` |
| `frase.TrimEnd()`   | Elimina los espacios en blanco solo al **final**.       | `string` |

```csharp
Main {
  string datoUsuario = "   aNa.PeReZ@daw.com   ";
  
  // Limpieza y estandarización del email antes de su uso
  string emailLimpio = datoUsuario.Trim().ToLower(); 
  
  writeLine($"Email Original: '{datoUsuario}'");
  writeLine($"Email Limpio: '{emailLimpio}'"); // Muestra: 'ana.perez@daw.com'
}
```

#### 12.2. Métodos de Verificación y Búsqueda

Permiten comprobar si una cadena cumple ciertas condiciones o si contiene una subcadena específica. Devuelven un valor booleano (`bool`).

| Método                      | Descripción                                                                                       | Devuelve |
| :-------------------------- | :------------------------------------------------------------------------------------------------ | :------- |
| `frase.StartsWith("texto")` | Comprueba si la cadena comienza con la subcadena.                                                 | `bool`   |
| `frase.EndsWith("texto")`   | Comprueba si la cadena termina con la subcadena.                                                  | `bool`   |
| `frase.Contains("texto")`   | Comprueba si la cadena contiene la subcadena en cualquier parte.                                  | `bool`   |
| `frase.IndexOf("texto")`    | Devuelve la posición (índice `0`) donde comienza la subcadena. Si no la encuentra, devuelve `-1`. | `int`    |
| `frase.LastIndexOf("texto")`| Devuelve la posición (índice `0`) de la última aparición de la subcadena. Si no la encuentra, devuelve `-1`. | `int` |


```csharp
Main {
  string url = "https://www.miempresa.com/productos";

  // Verificación de protocolo (Validación)
  bool esSegura = url.StartsWith("https://"); // true
  
  // Búsqueda de dominio (Identificación)
  bool esMiEmpresa = url.Contains("miempresa.com"); // true
  
  // Detección de la ruta de la página
  int indiceRuta = url.IndexOf("/productos"); // Retorna 25
  
  writeLine($"¿Es URL segura?: {esSegura}");
  writeLine($"Índice de '/productos': {indiceRuta}");
}
```

#### 12.3. Métodos de Sustitución y Extracción

Útiles para modificar o extraer partes de la cadena.

| Método                                | Descripción                                                                            | Devuelve |
| :------------------------------------ | :------------------------------------------------------------------------------------- | :------- |
| `frase.Replace("viejo", "nuevo")`     | Reemplaza todas las ocurrencias del "viejo" texto por el "nuevo".                      | `string` |
| `frase.Substring(inicio, [longitud])` | Extrae una subcadena a partir de un índice de `inicio` dado y una `longitud` opcional. | `string` |
| `frase.Split('delimitador')`            | Divide la cadena en un array de subcadenas usando el `delimitador` especificado.       | `string[]` |

```csharp
Main {
  string cadenaBase = "El precio es 100 EUR.";
  
  // Sustitución
  string cadenaDolar = cadenaBase.Replace("EUR", "USD"); // "El precio es 100 USD."
  
  // Extracción
  // Extrae 3 caracteres a partir del índice 14 (donde empieza "100")
  string soloPrecio = cadenaBase.Substring(14, 3); // "100"
  
  writeLine($"Nueva moneda: {cadenaDolar}");
  writeLine($"Precio extraído: {soloPrecio}");

  // División
  string datos = "Ana,Perez,30,España";
  string[] partes = datos.Split(','); // ["Ana", "Perez", "30", "España"]
  writeLine("Nombre: " + partes[0]); // "Ana"
  writeLine("Edad: " + partes[2]); // "30"
  writeLine("País: " + partes[3]); // "España"

  // Con foreach
  foreach (var parte in partes) {
      writeLine("Parte: " + parte);
  }
}
```
#### 12.4. StringBuilder (Construcción Eficiente de Cadenas)
Para operaciones que implican muchas modificaciones a una cadena (como concatenaciones en bucles), es más eficiente usar `StringBuilder`, ya que evita la creación de múltiples objetos de cadena intermedios.

```csharp
Main {
  var sb = StringBuilder(); // Crear un nuevo StringBuilder

  // Construir una cadena mediante múltiples adiciones
  for (int i = 1; i <= 5; i++) {
      sb.Append("Número " + i + "\n"); // Añadir texto
  }

  string resultado = sb.ToString(); // Convertir a cadena final
  writeLine(resultado);
}
```

#### 12.5. Expresiones Regulares (Regex)
Permiten buscar y manipular texto de manera flexible. Para ello se utiliza la clase `Regex`. La idea es buscar e identificar patrones dentro de cadenas de texto. Para ello tenemos que conocer la sintaxis de las expresiones regulares.

##### Sintaxis Básica de Expresiones Regulares
  * **Literales:** Coinciden exactamente con el texto. Ejemplo: `@"hola"` busca "hola".
  * **Metacaracteres:** Tienen un significado especial.
    * `.`: Cualquier carácter excepto nueva línea.
    * `\d`: Dígito (0-9).
    * `\D`: No dígito.
    * `\w`: Carácter de palabra (letras, dígitos, guion bajo).
    * `\W`: No carácter de palabra.
    * `\s`: Espacio en blanco (espacio, tabulación, nueva línea).
    * `\S`: No espacio en blanco.
    * `^`: Inicio de la cadena.
    * `$`: Fin de la cadena.
    * `[]`: Conjunto de caracteres. Ejemplo: `[abc]` busca 'a', 'b' o 'c'.
    * `|`: Alternancia (OR). Ejemplo: `cat|dog` busca "cat" o "dog".
  * **Cuantificadores:** Indican cuántas veces debe aparecer el elemento anterior
    * `*`: 0 o más veces.
    * `+`: 1 o más veces.
    * `?`: 0 o 1 vez.
    * `{n}`: Exactamente n veces.
    * `{n,}`: Al menos n veces.
    * `{n,m}`: Entre n y m veces.
    * `()` : Agrupa partes de la expresión.
    * `\`: Escapa un metacarácter para tratarlo como literal. Ejemplo: `\.` busca un punto.
    * `(?<nombre>...)`: Crea un grupo con nombre.
    * `(?=...)`: Lookahead positivo.
    * `(?!...)`: Lookahead negativo.
  * **Ejemplos de patrones comunes:**
    * DNI: `@"\d{8}[A-Za-z]"` (8 dígitos seguidos de una letra).
    * Email: `@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}"`.
    * Teléfono: `@"\+?\d{1,3}?[-.\s]?\(?\d{1,4}?\)?[-.\s]?\d{1,4}[-.\s]?\d{1,9}"`.
    * URL: `@"https?://[^\s/$.?#].[^\s]*"`.
    * Pasaporte: `@"[A-Za-z]{2}\d{6}"` (2 letras seguidas de 6 dígitos).
    * IPv4: `@"\b(?:\d{1,3}\.){3}\d{1,3}\b"`.
    * Fecha (DD/MM/YYYY): `@"\b(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}\b"`.
    * Código Postal (España): `@"\b\d{5}\b"`.
    * Número de Tarjeta de Crédito: `@"\b(?:\d{4}[- ]?){3}\d{4}\b"`.
    * Código de Seguridad (CVV): `@"\b\d{3,4}\b"`.
    * Matrícula de Coche (España): `@"\b\d{4}[B-DF-HJ-NP-TV-Z]{3}\b"`.

  * **Crear una expresión regular:**
    ```csharp

    Main {
      // Patrón para encontrar números en una cadena
      var patron = @"\d+";
      var regex = Regex(patron);

      string texto = "Tengo 2 perros y 3 gatos.";
      var coincidencias = regex.Matches(texto);

      for each (var match in coincidencias) {
          writeLine("Número encontrado: " + match.Value); // Muestra "2" y "3"
      }
    }
    ```
  * **Métodos comunes:**
    * `IsMatch(cadena)`: Devuelve `true` si la cadena coincide con el patrón.
    * `Match(cadena)`: Devuelve la primera coincidencia.
    * `Matches(cadena)`: Devuelve todas las coincidencias.
    * `Replace(cadena, nuevoTexto)`: Reemplaza las coincidencias con un nuevo texto.
    ```csharp

    Main {
      var patronEmail = @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}";
      var regexEmail = Regex(patronEmail);

      string texto = "Contacta con nosotros en info@ejemplo.com";
      bool esEmailValido = regexEmail.IsMatch(texto);
      writeLine("¿El texto contiene un email válido? " + esEmailValido);

      string nuevoTexto = regexEmail.Replace(texto, "[email protegido]");
      writeLine(nuevoTexto); // Muestra "Contacta con nosotros en [email protegido]"
    }
    ```
    