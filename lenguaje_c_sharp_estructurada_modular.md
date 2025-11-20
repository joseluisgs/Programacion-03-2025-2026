# Lenguaje C\# Para Programación Estructurada y Modular


![Índice de Contenidos](https://miro.medium.com/1*NGrpOtl30SnYdtg9GwErCA.jpeg)


- [Lenguaje C# Para Programación Estructurada y Modular](#lenguaje-c-para-programación-estructurada-y-modular)
  - [1. Introducción y Estructura Base de C#](#1-introducción-y-estructura-base-de-c)
    - [1.1. Estructura del Programa: La Revolución `Main`](#11-estructura-del-programa-la-revolución-main)
      - [A. Estructura Clásica (Orientada a Objetos)](#a-estructura-clásica-orientada-a-objetos)
      - [B. Estructura Moderna (Top-Level Statements)](#b-estructura-moderna-top-level-statements)
  - [1.2. Módulos y Paquetes (`using` y `static`)](#12-módulos-y-paquetes-using-y-static)
    - [A. Ahorrándonos Palabras con `using`](#a-ahorrándonos-palabras-con-using)
    - [B. Ahorrándonos la Clase con `using static`](#b-ahorrándonos-la-clase-con-using-static)
    - [1.3. Argumentos de Línea de Comandos](#13-argumentos-de-línea-de-comandos)
    - [1.4. Entrada de Consola y Conversión de Tipos](#14-entrada-de-consola-y-conversión-de-tipos)
      - [A. Conversión Explícita (Recomendado para DAW, pero Inseguro)](#a-conversión-explícita-recomendado-para-daw-pero-inseguro)
      - [B. Conversión Segura con `TryParse` (El Estándar C#)](#b-conversión-segura-con-tryparse-el-estándar-c)
      - [C. Asignación a un `string` (`out` vs. Retorno)](#c-asignación-a-un-string-out-vs-retorno)
    - [1.5. Salida por consola](#15-salida-por-consola)
  - [2. Tipos, Variables y Disciplina de Tipado](#2-tipos-variables-y-disciplina-de-tipado)
    - [2.1. Tipos Primitivos en C#](#21-tipos-primitivos-en-c)
    - [2.2. Declaración de Variables y Tipos de Almacenamiento](#22-declaración-de-variables-y-tipos-de-almacenamiento)
    - [A. Variables Normales (Declaración Explícita)](#a-variables-normales-declaración-explícita)
    - [B. Inferencia de Tipos (`var`)](#b-inferencia-de-tipos-var)
    - [C. Constantes (`const`)](#c-constantes-const)
    - [2.3. Conversión de Tipos (`Casting`)](#23-conversión-de-tipos-casting)
      - [A. Conversión Implícita (Ensanchamiento/Widening)](#a-conversión-implícita-ensanchamientowidening)
      - [B. Conversión Explícita (Estrechamiento/Narrowing)](#b-conversión-explícita-estrechamientonarrowing)
      - [C. Casting Explícito en Ensanchamiento (Requerimiento)](#c-casting-explícito-en-ensanchamiento-requerimiento)
    - [2.4. Tipos Anulables y Null-Safety](#24-tipos-anulables-y-null-safety)
      - [A. Operador de Coalescencia Nula (`??` y `??=`)](#a-operador-de-coalescencia-nula--y-)
      - [B. Operador de Acceso Condicional (`?.`)](#b-operador-de-acceso-condicional-)
      - [C. Operador Null-Forgiving (`!`)](#c-operador-null-forgiving-)
      - [D. Mecanismos de Acceso Seguro al Valor](#d-mecanismos-de-acceso-seguro-al-valor)
        - [Acceso Clásico con `!= null` y `.Value`](#acceso-clásico-con--null-y-value)
        - [Usando `.HasValue` y Casting Explícito](#usando-hasvalue-y-casting-explícito)
        - [**NO RECOMENDADA** - Chequeo Clásico con el Operador Null-Forgiving (`!`)](#no-recomendada---chequeo-clásico-con-el-operador-null-forgiving-)
        - [Pattern Matching con `is Tipo`](#pattern-matching-con-is-tipo)
        - [Pattern Matching con `is { }` (La más limpia para obtener el valor)](#pattern-matching-con-is---la-más-limpia-para-obtener-el-valor)
        - [Operador Condicional `?.` (La más concisa y segura)](#operador-condicional--la-más-concisa-y-segura)
        - [Conclusión y Recomendación Final](#conclusión-y-recomendación-final)
    - [E. Análisis de Advertencias de Nullabilidad en C#](#e-análisis-de-advertencias-de-nullabilidad-en-c)
      - [C. Buenas Prácticas con NRT](#c-buenas-prácticas-con-nrt)
      - [D. Activando como Errores de compilación los Warnings de NRT](#d-activando-como-errores-de-compilación-los-warnings-de-nrt)
    - [2.5. Más Allá de los Tipos Primitivos](#25-más-allá-de-los-tipos-primitivos)
      - [A. Enumeraciones (`enum`)](#a-enumeraciones-enum)
      - [B. Tuplas (`(Tipo1, Tipo2, ...)`)](#b-tuplas-tipo1-tipo2-)
  - [3. Operadores](#3-operadores)
    - [3.1. Operadores Aritméticos](#31-operadores-aritméticos)
    - [3.2. Operadores de Asignación](#32-operadores-de-asignación)
    - [3.3. Operadores de Comparación (Relacionales)](#33-operadores-de-comparación-relacionales)
    - [3.4. Operadores Lógicos (Booleanos)](#34-operadores-lógicos-booleanos)
    - [3.5. Operadores Especiales y Concatenación](#35-operadores-especiales-y-concatenación)
      - [A. Operador Condicional Ternario (`? :`)](#a-operador-condicional-ternario--)
      - [B. Concatenación de Cadenas (`+` y Interpolación)](#b-concatenación-de-cadenas--y-interpolación)
    - [3.6. Precedencia de Operadores](#36-precedencia-de-operadores)
    - [3.7. Otros Operadores Útiles](#37-otros-operadores-útiles)
  - [4. Programación Estructurada: Estructuras de Control de Flujo](#4-programación-estructurada-estructuras-de-control-de-flujo)
    - [4.1. Secuencias](#41-secuencias)
    - [4.2. Estructuras Condicionales (`if-else` y `switch`)](#42-estructuras-condicionales-if-else-y-switch)
      - [A. Condicionales Simples y Múltiples (`if`, `else if`, `else`)](#a-condicionales-simples-y-múltiples-if-else-if-else)
      - [B. Selección Múltiple (`switch`)](#b-selección-múltiple-switch)
      - [C. Expresión `switch` y Pattern Matching](#c-expresión-switch-y-pattern-matching)
    - [4.3. Bucles (Ciclos)](#43-bucles-ciclos)
      - [A. Bucle Mientras (`while`)](#a-bucle-mientras-while)
      - [B. Bucle Repetir-Hasta (`do-while`)](#b-bucle-repetir-hasta-do-while)
      - [C. Bucle Para (`for`)](#c-bucle-para-for)
      - [D. Bucle Para Cada (`foreach`)](#d-bucle-para-cada-foreach)
      - [E. Modificadores de Bucles](#e-modificadores-de-bucles)
  - [5. Programación Modular (Métodos)](#5-programación-modular-métodos)
    - [5.1. Funciones y Procedimientos (Métodos)](#51-funciones-y-procedimientos-métodos)
    - [5.2. Parámetros y Argumentos: Disciplina de Tipado](#52-parámetros-y-argumentos-disciplina-de-tipado)
      - [A. Conversión Implícita (Ensanchamiento) en Llamadas](#a-conversión-implícita-ensanchamiento-en-llamadas)
      - [B. Conversión Explícita (Estrechamiento) y Prohibición de Anulables](#b-conversión-explícita-estrechamiento-y-prohibición-de-anulables)
    - [5.3. Paso de Parámetros por Valor y por Referencia](#53-paso-de-parámetros-por-valor-y-por-referencia)
    - [5.4. Parámetros de Salida (`out`)](#54-parámetros-de-salida-out)
    - [5.5. Parámetros Opcionales, por Defecto y Nombrados](#55-parámetros-opcionales-por-defecto-y-nombrados)
      - [A. Parámetros por Defecto (Opcionales)](#a-parámetros-por-defecto-opcionales)
      - [B. Argumentos Nombrados](#b-argumentos-nombrados)
    - [5.6. Sobrecarga de Métodos (`Overloading`)](#56-sobrecarga-de-métodos-overloading)
    - [5.7. Parámetros Variables (`params`)](#57-parámetros-variables-params)
    - [5.8. Devolución de Múltiples Valores con Tuplas](#58-devolución-de-múltiples-valores-con-tuplas)
      - [A. Definición de la Función con Tupla](#a-definición-de-la-función-con-tupla)
      - [B. Uso y Deconstrucción de la Tupla](#b-uso-y-deconstrucción-de-la-tupla)
    - [5.9. Recursividad](#59-recursividad)
    - [5.10. Ámbito de las Variables (`Scope`)](#510-ámbito-de-las-variables-scope)
    - [5.11. Espacios de Nombres (Namespaces)](#511-espacios-de-nombres-namespaces)
      - [A. Definición de un Espacio de Nombres](#a-definición-de-un-espacio-de-nombres)
      - [B. Uso de Espacios de Nombres](#b-uso-de-espacios-de-nombres)
  - [6. Arrays (Arreglos)](#6-arrays-arreglos)
    - [6.1. Arrays Unidimensionales](#61-arrays-unidimensionales)
    - [6.2. Arrays Multidimensionales](#62-arrays-multidimensionales)
      - [A. Arrays Rectangulares (Multidimensionales Clásicos)](#a-arrays-rectangulares-multidimensionales-clásicos)
      - [B. Arrays Escalonados o de Arrays (`Jagged Arrays`)](#b-arrays-escalonados-o-de-arrays-jagged-arrays)
      - [C. Comparación entre Arrays Rectangulares y Escalonados](#c-comparación-entre-arrays-rectangulares-y-escalonados)
    - [6.3. Arrays con Tipos Anulables (`T?[]`)](#63-arrays-con-tipos-anulables-t)
    - [6.4. Copiando/Cloando Arrays](#64-copiandocloando-arrays)
    - [6.5. Métodos Útiles para Arrays](#65-métodos-útiles-para-arrays)
    - [6.6. Arrays por referencia y paso a métodos](#66-arrays-por-referencia-y-paso-a-métodos)
      - [¿Por qué es necesario `ref` para la reasignación?](#por-qué-es-necesario-ref-para-la-reasignación)
    - [6.7. Argumentos de Programas](#67-argumentos-de-programas)
  - [7. Cadenas de Texto y Expresiones Regulares](#7-cadenas-de-texto-y-expresiones-regulares)
    - [7.1. La Clase `String` y la Inmutabilidad](#71-la-clase-string-y-la-inmutabilidad)
    - [7.2. Concatenación Moderna y Literales](#72-concatenación-moderna-y-literales)
      - [A. Interpolación de Cadenas (`$`)](#a-interpolación-de-cadenas-)
      - [B. Literales de Cadena Verbatim (`@`)](#b-literales-de-cadena-verbatim-)
      - [C. Literales de Cadena de Varias Líneas (`"""`)](#c-literales-de-cadena-de-varias-líneas-)
    - [7.3. Métodos Esenciales de la Clase `String`](#73-métodos-esenciales-de-la-clase-string)
    - [7.4. Strings, Inmutabilidad, y la Necesidad de `ref`](#74-strings-inmutabilidad-y-la-necesidad-de-ref)
      - [Concepto Clave: Los Strings son Inmutables](#concepto-clave-los-strings-son-inmutables)
      - [Strings Pasados a Métodos (Sin `ref`)](#strings-pasados-a-métodos-sin-ref)
      - [Reasignación de String Completo con `ref`](#reasignación-de-string-completo-con-ref)
      - [¿Por qué `ref` es necesario?](#por-qué-ref-es-necesario)
    - [7.5. Construcción Eficiente con `StringBuilder`](#75-construcción-eficiente-con-stringbuilder)
    - [7.6. Expresiones Regulares (`System.Text.RegularExpressions`)](#76-expresiones-regulares-systemtextregularexpressions)
      - [A. Uso Estático (Conciso)](#a-uso-estático-conciso)
      - [B. Uso Clásico (Creación de Objeto)](#b-uso-clásico-creación-de-objeto)
      - [C. Uso de Grupos en Expresiones Regulares](#c-uso-de-grupos-en-expresiones-regulares)
  - [8. Estructuras (Structs) y Enumeraciones (Enums)](#8-estructuras-structs-y-enumeraciones-enums)
    - [8.1. Definición y Uso de Estructuras](#81-definición-y-uso-de-estructuras)
    - [8.2. Inicialización de Estructuras](#82-inicialización-de-estructuras)
    - [8.3. Paso de Estructuras a Métodos (por valor)](#83-paso-de-estructuras-a-métodos-por-valor)
    - [8.4. Paso de Estructuras por Referencia (`ref`)](#84-paso-de-estructuras-por-referencia-ref)
    - [8.5. Estructuras de solo lectura (readonly struct)](#85-estructuras-de-solo-lectura-readonly-struct)
    - [8.6. Estructuras por referencia (ref struct)](#86-estructuras-por-referencia-ref-struct)
    - [8.7. Definición y Uso de Enumeraciones](#87-definición-y-uso-de-enumeraciones)
  - [9. Control de Excepciones](#9-control-de-excepciones)
    - [9.1. Estructura `try-catch-finally`](#91-estructura-try-catch-finally)
    - [9.2. Captura Múltiple y Específica](#92-captura-múltiple-y-específica)
      - [A. Múltiples Bloques `catch`](#a-múltiples-bloques-catch)
      - [B. Filtros de Excepción (`catch when`)](#b-filtros-de-excepción-catch-when)
        - [Propiedad `ex.ParamName`](#propiedad-exparamname)
    - [9.3. Lanzamiento Explícito de Excepciones (`throw`)](#93-lanzamiento-explícito-de-excepciones-throw)
    - [9.4. Aserciones (`Debug.Assert`)](#94-aserciones-debugassert)
  - [10. Creación, Compilación y Ejecución de Proyectos C# (NET CLI)](#10-creación-compilación-y-ejecución-de-proyectos-c-net-cli)
    - [10.1. Creación del Proyecto: `dotnet new`](#101-creación-del-proyecto-dotnet-new)
    - [10.2. Compilación y Ejecución en Desarrollo: `dotnet run`](#102-compilación-y-ejecución-en-desarrollo-dotnet-run)
    - [10.3. Creación del Ejecutable Nativo: `dotnet publish`](#103-creación-del-ejecutable-nativo-dotnet-publish)
    - [10.4. Ejecución del Ejecutable (Binario Nativo)](#104-ejecución-del-ejecutable-binario-nativo)
  - [11. Comentarios y Documentación (XMLDoc)](#11-comentarios-y-documentación-xmldoc)
    - [11.1. Tipos de Comentarios Básicos](#111-tipos-de-comentarios-básicos)
    - [11.2. Comentarios de Documentación XML (XMLDoc)](#112-comentarios-de-documentación-xml-xmldoc)
      - [A. Ventajas Clave](#a-ventajas-clave)
      - [B. Etiquetas XMLDoc Fundamentales (Iniciales)](#b-etiquetas-xmldoc-fundamentales-iniciales)
  - [Etiquetas XMLDoc de C# (Referencia Completa)](#etiquetas-xmldoc-de-c-referencia-completa)
  - [12. Convenciones de Nomenclatura (Naming Conventions)](#12-convenciones-de-nomenclatura-naming-conventions)
    - [12.1. Estilos de Capitalización en C#](#121-estilos-de-capitalización-en-c)
    - [12.2. Nomenclatura de Elementos por Tipo](#122-nomenclatura-de-elementos-por-tipo)
      - [A. Variables Locales y Parámetros (`camelCase`)](#a-variables-locales-y-parámetros-camelcase)
      - [B. Métodos, Constantes y `readonly` (`PascalCase`)](#b-métodos-constantes-y-readonly-pascalcase)
      - [C. Enumeraciones (`enum`) y sus Miembros (`PascalCase`)](#c-enumeraciones-enum-y-sus-miembros-pascalcase)
      - [D. Variables Booleanas y Preguntas (`is`, `has`, `can`)](#d-variables-booleanas-y-preguntas-is-has-can)
      - [E. Tuplas (`PascalCase`)](#e-tuplas-pascalcase)
    - [12.3. Recomendaciones Adicionales](#123-recomendaciones-adicionales)
  - [13. Librerías](#13-librerías)
    - [13.1. Configuración de NuGet en Proyectos C#](#131-configuración-de-nuget-en-proyectos-c)
    - [13.2. Uso de NuGet para Gestionar Librerías](#132-uso-de-nuget-para-gestionar-librerías)
  - [14. Logger](#14-logger)
    - [14.1. Configuración Básica de Serilog](#141-configuración-básica-de-serilog)
    - [14.2. Uso de Niveles de Log](#142-uso-de-niveles-de-log)
  - [15. Consola Avanzada. Spectre](#15-consola-avanzada-spectre)
    - [15.1. Instalación de Spectre.Console](#151-instalación-de-spectreconsole)
    - [15.2. Uso de colores y estilos](#152-uso-de-colores-y-estilos)
    - [15.3. Uso de tablas](#153-uso-de-tablas)
    - [15.4. Uso de prompts de entrada](#154-uso-de-prompts-de-entrada)
    - [15.5. Calendarios](#155-calendarios)
    - [15.6. Barras de Progreso](#156-barras-de-progreso)
    - [15.7. Emogis y Símbolos](#157-emogis-y-símbolos)
  - [16. DAW'S Template](#16-daws-template)



## 1\. Introducción y Estructura Base de C\#

Este punto establece el mapeo entre tu estructura de pseudocódigo y la sintaxis **más concisa y moderna** de C\#.

### 1.1. Estructura del Programa: La Revolución `Main`

En tu manual DAW, el programa comienza en un bloque principal (`Main { ... }`). C\# ofrece dos maneras de lograr esto: la clásica (orientada a objetos) y la moderna (funcional y concisa).

#### A. Estructura Clásica (Orientada a Objetos)

Este es el enfoque tradicional de C\#, donde el código debe estar obligatoriamente dentro de una **clase** y un método estático llamado `Main`.

| Estructura Clásica C\# | Sintaxis Clásica                         |
| :--------------------- | :--------------------------------------- |
| **Punto de Entrada**   | `public static void Main(string[] args)` |
| **Contenedor**         | `class Program { ... }`                  |

**Ejemplo Clásico (Código Verboso):**

```csharp
using System;
namespace MiProyectoDaw
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hola desde el Main clásico.");
        }
    }
}
```

#### B. Estructura Moderna (Top-Level Statements)

A partir de C\# 9.0, la sintaxis concisa es el estándar. Puedes escribir las instrucciones directamente en el archivo, igual que en tu bloque `Main` DAW. El compilador genera la clase `Program` y el método `Main` por ti.

| Estructura Moderna C\# | Sintaxis Moderna                                 |
| :--------------------- | :----------------------------------------------- |
| **Punto de Entrada**   | No se declara. El código es el punto de entrada. |
| **Contenedor**         | No se declara.                                   |

**Ejemplo Moderno (Código Conciso):**

```csharp
using System; 
// Se puede omitir el 'using System;' si no se usa Console o tipos de System.

Console.WriteLine("Hola desde la sintaxis moderna!");
// Aquí comienza y termina el programa. No hacen falta llaves ni clases.
```

| Tipo de Estructura | Archivo Típico          | Pros para DAW                                                          | Contras                                                                                                 |
| :----------------- | :---------------------- | :--------------------------------------------------------------------- | :------------------------------------------------------------------------------------------------------ |
| **Clásica**        | `Program.cs`            | Necesario para Programación Orientada a Objetos (OOP) avanzada.        | Demasiado **verboso** para ejercicios introductorios.                                                   |
| **Moderna**        | Cualquier archivo `.cs` | **Ideal para DAW.** Mapeo directo de `Main { ... }`, máxima concisión. | No permite métodos o campos de clase de forma nativa (se necesita un envoltorio, pero es transparente). |

> **Nota:** Para los ejercicios introductorios, usaremos la sintaxis **Moderna (Top-Level Statements)**. El fichero puede llamarse **`Program.cs`**, **`App.cs`**, o cualquier nombre con extensión `.cs`. Si hay varios archivos `.cs` en el proyecto, solo uno puede contener las Top-Level Statements.

> **Observación:** Las definiciones de funciones, structuras o enums, deben estar al final del archivo, **después** de las instrucciones principales. Esto es por cuestiones de orden de compilación.

## 1.2. Módulos y Paquetes (`using` y `static`)

En tu lenguaje DAW, si querías usar funciones avanzadas (como matemáticas), a veces necesitabas importar un **módulo** o **paquete**. En C\#, estos paquetes se llaman **`Namespaces`**.

La directiva **`using`** nos permite "ahorrarnos" tener que escribir el nombre completo del *namespace* cada vez que usamos una función.

### A. Ahorrándonos Palabras con `using`

| Concepto DAW    | Equivalencia C\#         | Ejemplo con `Math`                                 |
| :-------------- | :----------------------- | :------------------------------------------------- |
| Módulo/Paquete  | `Namespace`              | `System.Math` (contiene las funciones matemáticas) |
| Importar Módulo | `using NombreNamespace;` | **`using System;`**                                |

**Ejemplo de Ahorro:**

Si no usamos `using System;`, tenemos que escribir el nombre completo de la función:

```csharp
// Sin using: tenemos que prefijar con System.
double x = System.Math.Pow(2, 3); // x es 8.0
```

Si incluimos la directiva `using`:

```csharp
using System; 
// Ahora podemos usar Math sin el prefijo 'System.'
double x = Math.Pow(2, 3);
```

### B. Ahorrándonos la Clase con `using static`

C\# va un paso más allá para las clases que son solo un conjunto de funciones (como `Math` o `Console`). Podemos usar **`using static`** para ahorrarnos **también** el nombre de la clase.

| Clase que Solo Contiene Funciones   | Sintaxis C\# Moderna        |
| :---------------------------------- | :-------------------------- |
| `Math` (en el `namespace` `System`) | `using static System.Math;` |

**Ejemplo de Máximo Ahorro (Sintaxis `static`):**

```csharp
// Importamos la clase Math entera.
using static System.Math; 
using static System.Console; // También podemos importar Console

// Ahora no necesitamos escribir 'Math.' ni 'Console.'
WriteLine("El valor de pi es: " + PI); 
double resultado = Pow(4, 2); // Equivalente a Math.Pow(4, 2);
WriteLine("4 al cuadrado es: " + resultado); 
```

> La sintaxis **`using`** te permite escribir código más conciso, limpio y fácil de leer, eliminando prefijos largos de *namespaces* o clases. En el contexto de un programa con **Top-Level Statements**, este ahorro es máximo.

### 1.3. Argumentos de Línea de Comandos

En la sintaxis moderna, los argumentos pasados al ejecutar el programa (`dotnet run -- arg1 arg2`) se recogen automáticamente en la variable implícita **`args`** (un `string[]`).

**Acceso a `args` en C\# Moderno:**

```csharp
using System; 

if (args.Length > 0)
{
    Console.WriteLine($"El primer argumento es: {args[0]}"); // Acceso al primer elemento
}
else
{
    Console.WriteLine("No se pasaron argumentos.");
}
```

-----

### 1.4. Entrada de Consola y Conversión de Tipos

El punto clave para los alumnos de DAW es la conversión estricta, ya que `Console.ReadLine()` **siempre devuelve un `string`**.

#### A. Conversión Explícita (Recomendado para DAW, pero Inseguro)

Esto mapea directamente el concepto `(int)readLine()` de tu pseudocódigo. Se usa `Convert.ToTipo` o `Tipo.Parse()`.

```csharp
// 1. Usando Convert (similar a un 'cast' genérico)
int edad = Convert.ToInt32(Console.ReadLine()); 
decimal precio = Convert.ToDecimal(Console.ReadLine());

// 2. Usando Parse (método del tipo de destino)
decimal precio = decimal.Parse(Console.ReadLine()); 
int cantidad = int.Parse(Console.ReadLine());
```

⚠️ **Peligro:** Si el usuario introduce texto no válido (ej. "abc"), estos métodos lanzarán una excepción en tiempo de ejecución (`FormatException`), deteniendo el programa.

#### B. Conversión Segura con `TryParse` (El Estándar C\#)

El enfoque más moderno y robusto en C\# es usar **`Tipo.TryParse()`**. Este método intenta la conversión y devuelve un `bool` indicando éxito o fracaso, **sin lanzar excepciones**.

Esta es la forma **recomendada** para la entrada de datos, ya que permite la gestión de errores (tu punto 10) de forma limpia.

| Sintaxis `TryParse`                                        | Uso                                                                                                                                           |
| :--------------------------------------------------------- | :-------------------------------------------------------------------------------------------------------------------------------------------- |
| **`bool éxito = Tipo.TryParse(input, out Tipo variable)`** | **`input`**: El `string` a convertir. <br>**`out Tipo variable`**: La variable donde se almacena el resultado (si la conversión tiene éxito). |

**Ejemplo de `int.TryParse` (Lectura y Conversión Segura):**

```csharp
using System; 

Console.Write("Introduce un número entero: ");
string inputString = Console.ReadLine(); // Lee siempre como string

// C# moderno: Declaración de 'numValue' dentro del 'out'
if (int.TryParse(inputString, out int numValue))
{
    // Bloque IF: Si el string se convirtió correctamente
    Console.WriteLine($"Éxito. Número leído: {numValue}");
}
else
{
    // Bloque ELSE: Si el string no pudo convertirse
    Console.WriteLine($"Error. '{inputString}' no es un número entero válido.");
}


// Podemos usar un do while para repetir hasta que el usuario introduzca un valor válido
int numeroValido;
do
{
    Console.Write("Introduce un número entero válido: ");
    string entrada = Console.ReadLine();
} while (!int.TryParse(entrada, out numeroValido));
```

#### C. Asignación a un `string` (`out` vs. Retorno)

  * **`Console.ReadLine()` devuelve el `string`:** La función ya retorna el valor de tipo `string`. La forma más limpia es usar la **asignación simple**.

    ```csharp
    // Forma correcta y simple:
    string nombre = Console.ReadLine(); 
    ```

  * **`out` en `TryParse` (Uso Correcto):** `out` solo se usa cuando un método necesita **devolver más de un resultado** (el `bool` de éxito **Y** el `int` convertido).

    ```csharp
    // Uso de 'out' en TryParse: devuelve el bool de éxito Y el valor convertido
    int.TryParse("123", out int valor); 
    ```

> **Conclusión Didáctica:** La lectura de un `string` es una **asignación simple**. La lectura de tipos numéricos requiere **`Tipo.TryParse()`** (forma moderna y segura) o **`Convert.ToTipo()`** (forma directa, pero frágil). Los alumnos de DAW deben acostumbrarse a usar `TryParse` por su robustez.


### 1.5. Salida por consola
En C\#, la salida por consola se realiza principalmente con el método `Console.WriteLine()`, que imprime texto seguido de un salto de línea. También existe `Console.Write()` para imprimir sin salto de línea. 

Podemos usar interpolación de cadenas para incluir variables directamente en el texto o concatenar cadenas con el operador `+`.

```csharp
string nombre = "Juan";
int edad = 30;
Console.WriteLine($"Hola, mi nombre es {nombre} y tengo {edad} años.");
Console.Write("Este es un mensaje sin salto de línea. ");
Console.Write("Aquí continúa en la misma línea. " + "\n"); // Usando \n para salto de línea, /t para tabulación
Console.WriteLine("Este es otro mensaje con salto de línea.");
Console.WriteLine("Concatenación: " + nombre + " tiene " + edad + " años.");
```

## 2\. Tipos, Variables y Disciplina de Tipado

### 2.1. Tipos Primitivos en C\#

C\# es un lenguaje de **tipado estático y fuerte**, lo que significa que cada variable debe tener un tipo definido y este no puede cambiar. El sistema de tipos es crucial para la estabilidad y rendimiento del código.

Aquí está el mapeo de los tipos fundamentales de C\#, incluyendo sus tamaños y usos clave:

| Concepto           | Tipo C\# (Palabra Clave) | Tamaño   | Rango y Uso Clave                                                                          |
| :----------------- | :----------------------- | :------- | :----------------------------------------------------------------------------------------- |
| **Enteros**        | `sbyte`, `byte`          | 8 bits   | `byte`: 0 a 255. `sbyte`: -128 a 127. Para datos pequeños.                                 |
|                    | **`short`**, `ushort`    | 16 bits  | Enteros de rango intermedio.                                                               |
|                    | **`int`**                | 32 bits  | **Entero por defecto.** Uso general (equivale a `System.Int32`).                           |
|                    | **`long`**               | 64 bits  | Para números muy grandes (equivale a `System.Int64`).                                      |
| **Punto Flotante** | **`float`**              | 32 bits  | Precisión simple. Requiere el sufijo **`f`** (ej: `10.5f`).                                |
|                    | **`double`**             | 64 bits  | **Tipo decimal por defecto.** Doble precisión.                                             |
| **Monetario**      | **`decimal`**            | 128 bits | Alta precisión, ideal para cálculos financieros. Requiere el sufijo **`m`** (ej: `1.99m`). |
| **Lógico**         | **`bool`**               | 1 bit    | Solo puede ser `true` o `false`.                                                           |
| **Texto**          | **`char`**               | 16 bits  | Un único carácter (comillas simples: `'A'`).                                               |
|                    | **`string`**             | Variable | Secuencia de caracteres (comillas dobles: `"Hola"`). Es un tipo por referencia.            |


### 2.2. Declaración de Variables y Tipos de Almacenamiento

En C\#, puedes declarar variables de manera **explícita** (usando el tipo) o **implícita** (usando `var`). Además, existen modificadores para definir valores fijos (`const` y `readonly`).


### A. Variables Normales (Declaración Explícita)

Se especifica el **tipo de dato** antes del nombre de la variable. Su valor es **mutable** (puede cambiarse).

| Convención  | Ejemplo                 |
| :---------- | :---------------------- |
| **Nombres** | Se usa **`camelCase`**. |

```csharp
// Declaración y asignación explícita
int miContador = 5;
string mensaje = "Inicio de la aplicación.";

// El valor puede reasignarse
miContador = 10;
```

Pero que significa internamente y como procede un compilador cuando se escribe `int edad = 5;`?
- El compilador reserva un espacio en memoria suficiente para almacenar un entero (4 bytes, 32 bits).
- Asocia el nombre `edad` a esa ubicación de memoria. Es decir, edad es un alias para esa dirección,por ejemplo 0x1A2B3C4D.
- Al asignar el valor `5`, el compilador convierte ese valor a su representación binaria (0000 0000 0000 0000 0000 0000 0000 0101) y lo almacena en la dirección de memoria asociada a `edad`.

### B. Inferencia de Tipos (`var`)

La palabra clave **`var`** permite una declaración **implícita**. El compilador deduce el tipo de la variable a partir del valor asignado durante la inicialización.

| Característica | Ejemplo                                                          |
| :------------- | :--------------------------------------------------------------- |
| **Requisito**  | Debe **inicializarse inmediatamente**.                           |
| **Convención** | La variable resultante es local, por lo que usa **`camelCase`**. |

```csharp
var nombre = "Lucía";      // El compilador infiere 'string'.
var edad = 25;             // El compilador infiere 'int'.
// Nota: El tipo es fijo una vez inferido.
```

### C. Constantes (`const`)

Define un valor que **nunca puede cambiar**. Son utilizadas para valores que se conocen en el momento de la **compilación**.

| Característica    | Ejemplo                                                               |
| :---------------- | :-------------------------------------------------------------------- |
| **Inmutabilidad** | Totalmente inmutable.                                                 |
| **Convención**    | Se nombran usando **`PascalCase`** para seguir los estándares de C\#. |

```csharp
// CORRECTO en C#: PascalCase para constantes
const double ValorPi = 3.14159; 
const int LimiteMaximo = 50;

// LimiteMaximo = 10; // ERROR: No se puede asignar a una constante.
```


### 2.3. Conversión de Tipos (`Casting`)

El *casting* se refiere al proceso de cambiar el tipo de una variable. En C\#, esto se clasifica en dos categorías principales.

#### A. Conversión Implícita (Ensanchamiento/Widening)

Ocurre cuando se convierte de un tipo con **menor rango** a un tipo con **mayor rango**, ya que no hay riesgo de pérdida de información (el tipo destino "cabe" al origen). El compilador lo hace automáticamente.

```csharp
int smallInt = 10;
long largeInt = smallInt; // Implícito: un 'int' cabe perfectamente en un 'long'.
```

#### B. Conversión Explícita (Estrechamiento/Narrowing)

Ocurre cuando se convierte de un tipo con **mayor rango** a uno con **menor rango**. Esta conversión **siempre requiere un *cast* explícito** (`(Tipo)valor`), ya que hay riesgo de perder datos o desbordamiento.

```csharp
double numeroGrande = 123.45;
int numeroEntero = (int)numeroGrande; // Explícito: Se pierde la parte decimal (.45)
```

#### C. Casting Explícito en Ensanchamiento (Requerimiento)

Aunque C\# realiza la conversión de menor a mayor rango de forma implícita, puede ser necesario forzar el *casting* explícito incluso en el ensanchamiento.

**Razón del Requerimiento Explícito:**

El *casting* explícito se utiliza para **afirmar intencionalidad**. Si tienes una función que espera un `double` y le pasas un `int`, aunque el compilador lo acepte, incluir el *cast* explícito **`(double)`** en la llamada a la función asegura que el programador es consciente de la conversión, proporcionando un código más claro y menos ambiguo.

```csharp
int valorInt = 5;
// Aunque sea implícito, podemos forzar la visibilidad de la conversión:
double valorDouble = (double)valorInt; // El programador declara explícitamente el deseo de ensanchar.
```

### 2.4. Tipos Anulables y Null-Safety

C\# utiliza el sufijo **`?`** para declarar que una variable de tipo de valor (como `int` o `bool`) puede almacenar el valor `null` (ausencia de valor).

```csharp
int? edad = null; // Un entero que puede ser nulo
```

Esto introduce la necesidad de manejar la nulidad de forma segura.

#### A. Operador de Coalescencia Nula (`??` y `??=`)

Este operador `??` permite proporcionar un valor por defecto si la variable anulable es `null`. Es fundamental para pasar un valor potencialmente nulo a una función que espera un tipo no anulable.

```csharp
int? unidadesStock = null;

// Si unidadesStock es null, asigna 0. Si no, asigna su valor.
int unidadesSeguras = unidadesStock ?? 0; 
```

Por otro lado, el operador `??=` asigna un valor solo si la variable es `null`.

```csharp
int? unidadesStock = null;
unidadesStock ??= 10; // Si es null, se asigna 10.
```

#### B. Operador de Acceso Condicional (`?.`)
El operador **`?.`** permite acceder a miembros (propiedades o métodos) de un objeto solo si este no es `null`. Si el objeto es `null`, la expresión completa devuelve `null` sin lanzar una excepción.

Equivale a un chequeo previo de nulidad.(if (obj != null) { obj.Propiedad; } else { null; })

```csharp
string? saludo = null;
Console.WriteLine(saludo?.Length);
// Si saludo es null, no se lanza excepción; la expresión devuelve null.

saludo = "Hola";
Console.WriteLine(saludo?.Length); // Devuelve 4, ya que saludo no es null.

```

#### C. Operador Null-Forgiving (`!`)

El operador **`!`** (C\# 8.0+) se utiliza al final de una expresión para decirle al compilador que, aunque la expresión podría ser nula, **el programador garantiza** que no lo será en ese momento. Se usa para suprimir advertencias del compilador. Pero debe usarse con precaución, ya que si la variable es realmente `null`, se lanzará una excepción en tiempo de ejecución, esta excepción es `NullReferenceException`. Si lo hacemos de forma incorrecta, estaremos rompiendo la seguridad de tipos de C\#. Con ello le decimos al compilador "confía en mí, sé lo que hago".

```csharp
string nombreCompleto = ObtenerNombre()!; // Le decimos al compilador: confía, esto no será null.
if (nombreCompleto is not null)
{
    Console.WriteLine(nombreCompleto!.Length); // Seguro, ya verificado.
}
```

#### D. Mecanismos de Acceso Seguro al Valor

Cuando trabajamos con **Tipos de Valor Anulables** (e.g., `Libro?`), es fundamental entender que el objeto **es un contenedor** que puede estar vacío (`null`). Para acceder a las propiedades del tipo subyacente (el `struct Libro`), primero debemos "abrir el contenedor" de forma segura.

Un intento directo como `estanteria[i].Titulo` fallará si `estanteria[i]` es `null`, lanzando una excepción `System.InvalidOperationException`.

A continuación, se presentan las diversas técnicas que C\# ofrece, ordenadas desde las más explícitas y tradicionales hasta las más modernas y concisas.

```csharp
// Definición del struct para los ejemplos:
struct Libro {
    public string Titulo;
    public string Autor;
}

// Función de ejemplo que busca un libro en una estantería que admite huecos (null):
int BuscarLibroPorTitulo(string titulo, Libro?[] estanteria) {
    for (var i = 0; i < estanteria.Length; i++) {
        // estanteria[i] es de tipo Libro? (Libro anulable).
        // ... (Aquí se aplican los mecanismos)
    }
    return -1; // No encontrado
}
```

##### Acceso Clásico con `!= null` y `.Value`

Este es el método base que demuestra la estructura del `Libro?`.

| Herramientas | `if (x != null)` y `x.Value` |
| :----------: | :--------------------------- |

```csharp
// 2. Classic Explicit Access con .Value (La más segura y explícita)
if (estanteria[i] != null) {
    // El compilador garantiza que, dentro de este 'if', el valor existe.
    // Usamos .Value para obtener el struct Libro NO NULO.
    if (estanteria[i].Value.Titulo == titulo) {
        return i;
    }
}
```

Es la **Opción más clara y segura** para principiantes. Enseña que hay que validar el contenedor (`!= null`) antes de extraer su contenido (`.Value`).

##### Usando `.HasValue` y Casting Explícito

La propiedad **`.HasValue`** es un sinónimo directo de `!= null` para los tipos anulables. La segunda parte introduce la posibilidad de hacer un *casting* explícito.

| Herramientas | `.HasValue` y `(Tipo)` Casting |
| :----------: | :----------------------------- |

```csharp
// 3. Usando la propiedad HasValue y/o el casting explícito
if (estanteria[i].HasValue) { // HasValue es sinónimo de != null

    // A. Acceso con .Value (más simple)
    // if (estanteria[i].Value.Titulo == titulo) return i;

    // B. Acceso con casting (más verboso)
    // Se requiere el operador '!' si el compilador no puede deducir la no-nulidad
    var libroCasteado = (Libro)estanteria[i]!; 
    if (libroCasteado.Titulo == titulo) {
        return i;
    }
}
```

Es una alternativa `.HasValue` y el uso del **casting explícito**. El casting es menos común que `.Value` y solo debe usarse si es estrictamente necesario, y requiere el operador `!` si el valor proviene de un contexto incierto.

##### **NO RECOMENDADA** - Chequeo Clásico con el Operador Null-Forgiving (`!`)

El operador **`!`** (Operador de Perdón de Nulo) **no añade seguridad**, solo silencia las advertencias de nulidad del compilador. Se usa para forzar el acceso.

| Herramienta | `if (x != null)` + `x!.Value` |
| :---------: | :---------------------------- |

```csharp
// 1. La forma Clásica + Operador Null-Forgiving (!)
if (estanteria[i] != null) {
    // La '!' le dice al compilador: confía en que esto no es null.
    // Aunque ya lo hemos chequeado con el 'if', la '!' es solo un supresor de advertencias.
    if (estanteria[i]!.Value.Titulo == titulo) { 
        return i;
    }
}
```

**¡ADVERTENCIA\!** 🛑 Si se usa `!` sin un chequeo previo, garantiza un `NullReferenceException` si el valor es `null`. Es una herramienta avanzada para manejar falsos positivos del compilador, no para escribir código seguro.

##### Pattern Matching con `is Tipo`

Esta sintaxis de *pattern matching* comprueba si el valor es del tipo especificado y, si lo es, lo extrae en una nueva variable.

| Herramienta | `is Tipo variable` |
| :---------: | :----------------- |

```csharp
// 4. Pattern Matching con 'is Tipo' (C# 7.0+)
if (estanteria[i] is Libro libro) {
    // Si 'estanteria[i]' no es null, se desempaqueta en la variable 'libro' (NO NULA).
    // Ya que hemos hecho el chequeo, no necesitamos .Value.
    if (libro.Titulo == titulo) {
        return i;
    }
}
```

##### Pattern Matching con `is { }` (La más limpia para obtener el valor)

Esta es la mejor forma de **obtener el valor no nulo** y almacenarlo en una variable, superando a la Opción 4 en claridad para este propósito.

| Herramienta | `is { } variable` |
| :---------: | :---------------- |

```csharp
// 5. Pattern Matching con 'is { }' (La más moderna y recomendada para desempaquetar)
if (estanteria[i] is { } libro) {
    // El patrón { } (pattern de propiedad) comprueba que la referencia existe (no es null)
    // y lo asigna a la variable 'libro', que es de tipo Libro (no-nulo).
    if (libro.Titulo == titulo) {
        return i;
    }
}
```

Es la opción recomendada para cuando necesitamos el **objeto completo no nulo** para usarlo en un bloque de código posterior.

##### Operador Condicional `?.` (La más concisa y segura)

Este operador es un **cortocircuito seguro** diseñado para acceder a miembros sin riesgo. Es la mejor opción si solo necesitas acceder a una propiedad o método específico.

| Herramienta | `x?.Propiedad` |
| :---------: | :------------- |

```csharp
// 6. Uso del Operador Condicional ?. (La más concisa y segura)
// Si estanteria[i] es null, estanteria[i]?.Titulo es null.
// La expresión completa compara (null == titulo), que es false, sin error.
if (estanteria[i]?.Titulo == titulo) {
    return i;
}
```

Esta es la **Opción más compacta y recomendada** para la **implementación final**. Permite manejar la nulidad en línea, convirtiéndose en el enfoque preferido cuando el objetivo es simplemente acceder a un miembro y compararlo o usarlo.

##### Conclusión y Recomendación Final

El manejo de tipos anulables ha evolucionado en C\# hacia una mayor seguridad y concisión.

| Situación                       | Mejor Opción                        | Razón                                                                                                               |
| :------------------------------ | :---------------------------------- | :------------------------------------------------------------------------------------------------------------------ |
| **Entender el concepto**        | **Opción 2 (`!= null` + `.Value`)** | Es la más explícita y muestra las propiedades del `Nullable<T>`.                                                    |
| **Necesitar el objeto NO NULO** | **Opción 5 (`is { } variable`)**    | Desempaqueta y declara la variable de forma limpia y segura.                                                        |
| **Acceder a un miembro**        | **Opción 6 (`?.`)**                 | Es la más corta, evita `NullReferenceException` con un "cortocircuito". **(Recomendada como implementación final)** |


```csharp
// IMPLEMENTACIÓN FINAL RECOMENDADA
for (var i = 0; i < estanteria.Length; i++)
    if (estanteria[i]?.Titulo == titulo)
        return i;
```

### E. Análisis de Advertencias de Nullabilidad en C\#

C# tiene control de nullabilidad (NRT - Nullable Reference Types) que ayuda a prevenir errores comunes relacionados con referencias nulas. Cuando NRT está habilitado, el compilador advierte sobre posibles desreferencias de referencias nulas. Es decir te dará un Warning si detecta que podrías estar usando una variable que podría ser null sin verificarlo primero.

> ⚠️ Análisis de la Advertencia: El problema radica en la diferencia entre la **anulabilidad esperada** y la **anulabilidad real** de la variable.

Además, podemos hacer que los warning por nulos se trasformen en errores de compilación (lo que es recomendable para evitar errores en tiempo de ejecución) habilidadndo la opción en el archivo de proyecto `.csproj`:

```xml
<PropertyGroup>
    <Nullable>enable</Nullable>
    <TreatWarningsAsErrors>true</TreatWarningsAsErrors>
</PropertyGroup>
```

Cuando defines este código en un proyecto con `Nullable` activado:

```csharp
string nombreCompleto = ObtenerNombre(); // ObtenerNombre() devuelve string? (string o null)

// Luego usas la variable sin verificar si es null:
Console.WriteLine(nombreCompleto.Length); // Y daría una advertencia aquí, y si lo ejecutas y es null, lanzaría una NullReferenceException.
```
El compilador de C\# generará una advertencia en la línea donde usas `nombreCompleto` (por ejemplo, al acceder a `.Length`), diciendo: **Desreferencia de una referencia posiblemente nula.**

**¿Por qué ocurre?**

1.  **`ObtenerNombre()` devuelve `string?`**: Esto significa que el método puede retornar una referencia válida a un `string` **o** puede retornar `null`.
2.  **`string nombreCompleto` es no anulable**: Al declarar `string nombreCompleto`, le estás diciendo al compilador que esperas que esta variable **siempre** contenga una referencia válida a un *string* (no `null`).
3.  **Advertencia de Peligro**: El compilador ve que estás asignando un valor potencialmente nulo (`string?`) a una variable que tú declaraste como no nula (`string`). Lo acepta, pero te **advierte** de que si `ObtenerNombre()` devuelve `null`, y luego intentas usar `nombreCompleto` sin verificarlo (como al acceder a `.Length`), podrías tener una **`NullReferenceException`** en tiempo de ejecución.

**✅ Soluciones Correctas (Evitando el Riesgo)**

Para eliminar la advertencia de forma segura, debes manejar explícitamente la posibilidad de nulidad.

- Opción 1: Declarar la Variable como Anulable

Si esperas que pueda ser nula, declara la variable como tal:

```csharp
string? nombreCompleto = ObtenerNombre(); // Warning, pero filtro con un if

// Ahora, el compilador TE OBLIGA a verificar antes de usarla:
if (nombreCompleto is not null) // ¡Verificación obligatoria!
{
    Console.WriteLine($"Longitud: {nombreCompleto.Length}");
} 
else
{
    Console.WriteLine("Nombre no proporcionado.");
}
```

- Opción 2: Usar el Operador Null-Forgiving (`!`)

Si, y **solo si**, sabes con certeza (por una lógica externa que el compilador no puede inferir) que la función *nunca* devolverá `null` en ese punto, puedes suprimir la advertencia, pero como mencionaste, esto rompe la seguridad:

```csharp
string nombreCompleto = ObtenerNombre()!; // Warning, pero le dices al compilador: "Confía en mí, no será null."

// Riesgo alto si tu "garantía" es incorrecta.
Console.WriteLine(nombreCompleto.Length); 
```

- Opción 3: Usar el Operador Null-Coalescing (`??`)

Proporciona un valor predeterminado seguro en caso de que sea nulo:

```csharp
string nombreCompleto = ObtenerNombre() ?? "Desconocido"; // Warning, pero Si es null, usa "Desconocido".

// Ahora, 'nombreCompleto' NUNCA es null.
Console.WriteLine($"Longitud: {nombreCompleto.Length}");
```

- Opcion 4: Usar ? Operador de Acceso Condicional (`?.`)
Si solo quieres acceder a una propiedad o método si la variable no es nula:

```csharp
string? nombreCompleto = ObtenerNombre(); // Warning, pero filtro con ?.
int? longitud = nombreCompleto?.Length; // Si es null, longitud será null también.
Console.WriteLine($"Longitud: {longitud ?? 0}"); // Si longitud es null, muestra 0.
```

#### C. Buenas Prácticas con NRT
1.  **Habilita NRT en tus proyectos**: Esto te ayudará a detectar posibles problemas de nulidad durante la compilación.
2.  **Declara tipos anulables solo cuando sea necesario**: Usa `string?` solo si realmente esperas que pueda ser `null`.
3.  **Verifica siempre antes de usar**: Si tienes una variable que puede ser `null`, asegúrate de verificar su valor antes de acceder a sus miembros o métodos.
4.  **Evita el uso excesivo de `!`**: Úsalo solo cuando estés absolutamente seguro de que la variable no será `null` en ese contexto específico.
5.  **Utiliza `??` para valores predeterminados**: Esto puede simplificar tu código y evitar errores de nulidad.
6.  **Utiliza `?.` para accesos seguros**: Esto te permite acceder a miembros de una variable solo si no es `null`, evitando excepciones.
7.  **Documenta tus métodos**: Si un método puede devolver `null`, asegúrate de documentarlo claramente para que otros desarrolladores (o tú mismo en el futuro) sepan cómo manejarlo.
8. **Prueba tu código**: Asegúrate de probar escenarios donde las variables puedan ser `null` para garantizar que tu manejo de nulidad es robusto.


#### D. Activando como Errores de compilación los Warnings de NRT
Para reforzar la disciplina de tipado y evitar errores en tiempo de ejecución relacionados con referencias nulas, puedes configurar tu proyecto para que los warnings de NRT se traten como errores de compilación. Esto obliga a los desarrolladores a abordar cualquier posible problema de nulidad antes de que el código pueda compilarse. Esta es la filosofía que usa Kotlin o Swift con su sistema de tipos anulables.

Para activar esta configuración, debes modificar el archivo de proyecto `.csproj` agregando la siguiente línea dentro del nodo `<PropertyGroup>`:

```xml
<Nullable>enable</Nullable>
<TreatWarningsAsErrors>true</TreatWarningsAsErrors>
```
Aquí te explico cada línea:
- `<Nullable>enable</Nullable>`: Esto activa el análisis de nulidad, que genera las advertencias que deseas convertir en errores. Esto es un requisito para que funcione el paso 2.

- `<WarningsAsErrors>Nullable</WarningsAsErrors>`: Al establecer su valor en Nullable, le indicas al compilador que todas las advertencias relacionadas con los Tipos de Referencia Anulables (cuyos códigos empiezan con CS86xx, como CS8602, CS8600, CS8603, etc.) deben ser tratadas como errores de compilación.


De esta manera, cualquier intento de compilar código que pueda provocar una referencia nula sin el manejo adecuado resultará en un error de compilación, obligando a los desarrolladores a corregir el problema antes de que el código pueda ejecutarse. Es decir en el ejmeplo anterior:

```csharp
string nombreCompleto = ObtenerNombre(); // ObtenerNombre() devuelve string? (string o null)
// Luego usas la variable sin verificar si es null:
Console.WriteLine(nombreCompleto.Length); // Daría un ERROR de compilación ahora, por lo que te obliga a manejar la nulidad.

```

### 2.5. Más Allá de los Tipos Primitivos

Para completar el punto sobre tipado en C\#, es necesario incluir dos elementos de tipado estructurado que son fundamentales:

#### A. Enumeraciones (`enum`)

Las enumeraciones permiten definir un conjunto de constantes nombradas. Esto mejora la legibilidad y previene el uso de "números mágicos" en el código. Veremos más de ellos en la sección de [estructuras y enumeraciones](#8-estructuras-structs-y-enumeraciones-enums).

```csharp
enum DiaSemana 
{
    Lunes,   // Valor 0 por defecto
    Martes,  // Valor 1
    Miercoles
}

DiaSemana hoy = DiaSemana.Martes;
```

#### B. Tuplas (`(Tipo1, Tipo2, ...)`)
Las tuplas permiten agrupar múltiples valores en una sola estructura sin necesidad de definir una estructura personalizada. Son útiles para devolver múltiples valores desde un método o crear estructuras simples. Las tuplas se definen usando paréntesis y pueden tener nombres de campos para mejorar la legibilidad, además se pueden desestructurar fácilmente, es decir, asignar sus valores a variables individuales de forma directa.

```csharp
// Definición y uso de una tupla
(string Nombre, int Edad) ObtenerDatos()
{
    return ("Ana", 28);
}

var datos = ObtenerDatos();
Console.WriteLine($"Nombre: {datos.Nombre}, Edad: {datos.Edad}");

var persona = (Nombre: "Carlos", Edad: 35); // Tupla con nombres de campos
Console.WriteLine($"Nombre: {persona.Nombre}, Edad: {persona.Edad}");

// Desestructuración de tupla
var (nombre, edad) = ObtenerDatos();
Console.WriteLine($"Nombre: {nombre}, Edad: {edad}");

// Si solo quiero el nombre, uso un guion bajo para ignorar la edad
var (soloNombre, _) = ObtenerDatos();

Console.WriteLine($"Nombre: {soloNombre}");

```

-----

## 3\. Operadores

Este punto establece el uso de los operadores básicos en C\# para construir expresiones y tomar decisiones.

### 3.1. Operadores Aritméticos

Son idénticos a los de la mayoría de los lenguajes, incluyendo tu pseudocódigo, y siguen las reglas estándar de precedencia matemática.

| Operación DAW  | Operador C\# | Descripción                    | Ejemplo C\#                                     |
| :------------- | :----------- | :----------------------------- | :---------------------------------------------- |
| Suma           | `+`          | Suma                           | `var res = 5 + 3;`                              |
| Resta          | `-`          | Resta                          | `var res = 5 - 3;`                              |
| Multiplicación | `*`          | Multiplicación                 | `var res = 5 * 3;`                              |
| División       | `/`          | División. Cuidado con enteros. | `var res = 5 / 2;` (Resultado es **2**, no 2.5) |
| Módulo         | `%`          | Resto de la división entera    | `var res = 5 % 2;` (Resultado es **1**)         |
| Incremento     | `++`         | Aumenta en 1 (ej: `i++`)       | `i++;`                                          |
| Decremento     | `--`         | Disminuye en 1 (ej: `i--`)     | `i--;`                                          |

> ⚠️ **Advertencia de la División Entera (`/`):** Si ambos operandos son **`int`** (enteros), C\# realiza una división entera, descartando la parte decimal. Para obtener un resultado decimal, al menos uno de los operandos debe ser de tipo flotante (`float`, `double` o `decimal`).
>
> ```csharp
> int a = 5, b = 2;
> double c = a / b;     // c es 2.0 (División entera antes de la asignación)
> double d = (double)a / b; // d es 2.5 (Casting explícito a 'double' forzado)
> ```

### 3.2. Operadores de Asignación

El operador de asignación simple es `=`, pero C\# ofrece operadores compuestos para abreviar operaciones comunes.

| Operación DAW       | Operador C\# | Equivalencia Larga |
| :------------------ | :----------- | :----------------- |
| Asignación          | `=`          | `x = 5;`           |
| Acumulación         | `+=`         | `x = x + 5;`       |
| Resta y Asigna      | `-=`         | `x = x - 5;`       |
| Multiplica y Asigna | `*=`         | `x = x * 5;`       |
| Divide y Asigna     | `/=`         | `x = x / 5;`       |


>**Nota:** Estos operadores compuestos funcionan con todos los tipos numéricos y también con cadenas (`string`), donde `+=` realiza concatenación.
>

¿Por qué es más óptimo usar `x += 5;` en lugar de `x = x + 5;`? Porque el primero es más conciso y claro, y evita la repetición del nombre de la variable, lo que reduce errores potenciales y mejora la legibilidad del código. Además, el segundo crea una variable temporal intermedia para almacenar el resultado y luego asigna ese valor a `x`, lo que puede ser menos eficiente en términos de rendimiento, especialmente en operaciones dentro de bucles o funciones críticas.

### 3.3. Operadores de Comparación (Relacionales)

Se utilizan para comparar dos valores y siempre devuelven un valor **`bool`** (`true` o `false`).

| Comparación DAW   | Operador C\# | Descripción                |
| :---------------- | :----------- | :------------------------- |
| Igual a           | `==`         | Verifica si son iguales    |
| Distinto de       | `!=`         | Verifica si son diferentes |
| Mayor que         | `>`          |                            |
| Menor que         | `<`          |                            |
| Mayor o igual que | `>=`         |                            |
| Menor o igual que | `<=`         |                            |

### 3.4. Operadores Lógicos (Booleanos)

Combinan expresiones booleanas para crear condiciones compuestas.

| Lógico DAW | Operador C\# | Descripción                                                                                                    |
| :--------- | :----------- | :------------------------------------------------------------------------------------------------------------- |
| Y          | **`&&`**     | **AND (Cortocircuito):** `true` si ambos operandos son `true`. Si el primero es `false`, no evalúa el segundo. |
| O          | **`||`**     | **OR (Cortocircuito):** `true` si al menos un operando es `true`. Si el primero es `true`, no evalúa el segundo. |
| NO         | **`!`**      | **NOT:** Invierte el valor del operando.                                                                       |

> **Cortocircuito (`Short-Circuiting`):** El uso de `&&` y `||` es el estándar en C\#. Su principal ventaja es la **eficiencia** y la **seguridad**. Por ejemplo, con `&&`, si la primera condición ya es `false`, C\# sabe que el resultado final será `false` y evita evaluar la segunda condición. Esto es crucial para evitar errores, como intentar acceder a un objeto que podría ser `null`.
>
> ```csharp
> // Ejemplo de seguridad: solo verifica .Length si el objeto NO es null.
> if (objeto != null && objeto.Length > 0) 
> {
>    // ...
> }
> ```

### 3.5. Operadores Especiales y Concatenación

C\# incluye operadores específicos muy útiles.

#### A. Operador Condicional Ternario (`? :`)

Es una forma concisa de una estructura `if-else` simple, ideal para asignaciones cortas.

| Sintaxis C\#                                       | Descripción                                                                              |
| :------------------------------------------------- | :--------------------------------------------------------------------------------------- |
| **`condicion ? valorSiVerdadero : valorSiFalso;`** | Si la condición es `true`, devuelve el primer valor; si es `false`, devuelve el segundo. |

```csharp
int edad = 19;
// Si edad >= 18, asigna "Mayor", si no, asigna "Menor".
string estatus = (edad >= 18) ? "Mayor de edad" : "Menor de edad"; 
```

#### B. Concatenación de Cadenas (`+` y Interpolación)

El operador `+` se usa para unir cadenas (concatenación). Sin embargo, en C\#, la forma moderna y preferida es la **Interpolación de Cadenas**.

| Método            | Sintaxis C\#                | Ventajas                                                                                                                    |
| :---------------- | :-------------------------- | :-------------------------------------------------------------------------------------------------------------------------- |
| Clásico           | `saludo + nombre`           | Simple, pero menos legible con muchas variables.                                                                            |
| **Interpolación** | **`$"{saludo}, {nombre}"`** | **Recomendado.** Permite incrustar variables y expresiones directamente dentro de la cadena, haciendo el código más limpio. |

```csharp
string nombre = "Alex";
int puntos = 100;


// Con concatenación clásica:
Console.WriteLine("El jugador " + nombre + " tiene " + (puntos * 2) + " puntos.");

// Interpolación (la cadena empieza con $):
Console.WriteLine($"El jugador {nombre} tiene {puntos * 2} puntos.");
```

### 3.6. Precedencia de Operadores

La precedencia de operadores en C\# es similar a la de tu lenguaje DAW y la de las matemáticas. Los paréntesis `()` se usan para forzar un orden de evaluación.

| Precedencia   | Categoría       | Operadores                                              |
| :------------ | :-------------- | :------------------------------------------------------ |
| **Alta (1)**  | Primarios       | `()` (paréntesis), `.` (miembro), `++`, `--` (postfijo) |
| **Media (2)** | Unarios         | `+`, `-`, `!`, `++`, `--` (prefijo), `(Tipo)` (cast)    |
| **Media (3)** | Multiplicativos | `*`, `/`, `%`                                           |
| **Media (4)** | Aditivos        | `+`, `-`                                                |
| **Media (5)** | Relacionales    | `<`, `>`, `<=`, `>=`                                    |
| **Media (6)** | Igualdad        | `==`, `!=`                                              |
| **Baja (7)**  | Lógicos         | `&&`, `                                                 |  | ` |
| **Baja (8)**  | Condicional     | `? :`                                                   |
| **Baja (9)**  | Asignación      | `=`, `+=`, `-=`, `*=`, etc.                             |

**Ejemplo:**
`var resultado = 1 + 2 * 3;` // Resultado es 7, ya que `*` tiene mayor precedencia que `+`.

Excelente. Pasamos al núcleo de la lógica de programación: las **Estructuras de Control de Flujo**. Este punto 4 consolidará la programación estructurada de tu manual DAW usando la sintaxis moderna de C\#.

### 3.7. Otros Operadores Útiles
| Operación DAW        | Operador C\# | Descripción                                         |
| :------------------- | :----------- | :-------------------------------------------------- |
| Operador de Acceso   | `.`          | Accede a miembros (métodos, propiedades) de un estructura. |
| Operador de Indexado | `[]`         | Accede a elementos en arrays o colecciones.         |
| Operador de Nuevo Objeto | `new`        | Crea una nueva instancia de un tipo. Reservando la memoria necesaria. |
| Coalescencia Nula     | `??`         | Devuelve el operando de la izquierda si no es null; de lo contrario, devuelve el de la derecha. |
| Asignación de Coalescencia Nula | `??=`        | Asigna el operando de la derecha solo si el operando de la izquierda es null. |
| Operador is         | `is`         | Comprueba si un variable es de un tipo específico.     |
| Operador nameof     | `nameof`     | Devuelve el nombre de una variable, tipo o miembro como cadena. |
| Operador sizeof      | `sizeof`     | Devuelve el tamaño en bytes de un tipo de valor.       |


```csharp
int[] numeros = { 1, 2, 3, 4, 5 };
Console.WriteLine(numeros[2]); // Acceso al tercer elemento del array (índice 2)
int tamañoEntero = sizeof(int); // Tamaño en bytes de un entero
string nombreVariable = nameof(numeros); // Devuelve "numeros"
if (numeros is int[]) 
{
    Console.WriteLine("La variable 'numeros' es un array de enteros.");
}
```

-----

## 4\. Programación Estructurada: Estructuras de Control de Flujo

La programación estructurada define la secuencia en la que se ejecutan las instrucciones. En C\#, esto se logra principalmente mediante estructuras condicionales y bucles.

### 4.1. Secuencias

La **secuencia** es la ejecución de instrucciones una tras otra, de arriba abajo. En C\#, cada instrucción debe terminar con un punto y coma (**`;`**).

```csharp
// 1. Asignación
int a = 10; 

// 2. Operación
int b = a + 5; 

// 3. Salida
Console.WriteLine(b); // Las instrucciones se ejecutan secuencialmente.
```

### 4.2. Estructuras Condicionales (`if-else` y `switch`)

Las estructuras condicionales permiten ejecutar un bloque de código solo si una condición booleana es verdadera.

#### A. Condicionales Simples y Múltiples (`if`, `else if`, `else`)

La sintaxis de C\# para el condicional `if` requiere que la condición se encierre entre **paréntesis `()`** y los bloques de código se agrupen con **llaves `{}`**.

| Concepto DAW       | Sintaxis DAW              | Implementación C\#        |
| :----------------- | :------------------------ | :------------------------ |
| Condicional        | `SI (condición) ENTONCES` | **`if (condicion)`**      |
| Opción Alternativa | `SINO SI (condición)`     | **`else if (condicion)`** |
| Opción por Defecto | `SINO`                    | **`else`**                |

**Ejemplo C\#:**

```csharp
var puntuacion = 85;
var calificacion;

if (puntuacion >= 90)
{
    calificacion = "Sobresaliente";
}
else if (puntuacion >= 70)
{
    calificacion = "Notable";
}
else
{
    calificacion = "Aprobado";
}

Console.WriteLine($"Calificación: {calificacion}");
```

> **Ahorro de Llaves:** Si el bloque `if` o `else` contiene **una sola instrucción**, las llaves `{}` son opcionales. No obstante, **se recomienda usarlas siempre** por claridad y para evitar errores si se añaden más líneas después.


#### B. Selección Múltiple (`switch`)

El `switch` es ideal cuando se necesita evaluar una única expresión contra múltiples valores constantes.

| Concepto DAW   | Implementación C\#          | Notas Clave             |
| :------------- | :-------------------------- | :---------------------- |
| Selector       | `SEGUN (variable) HACER`    | **`switch (variable)`** |
| Caso           | `CASO valor:`               | **`case valor:`**       |
| Salida de Caso | **`FINCASO`** o **`BREAK`** | **`break;`**            |
| Por Defecto    | `CASO OTRO:`                | **`default:`**          |

**Ejemplo C\# con `switch` (Sintaxis Tradicional):**

```csharp
int dia = 3;

switch (dia)
{
    case 1:
        Console.WriteLine("Lunes");
        break; // Obligatorio para salir del case y evitar 'fall-through'
    case 5:
    case 6: // Múltiples casos pueden compartir el mismo bloque de código
        Console.WriteLine("Fin de semana (o casi)");
        break;
    default:
        Console.WriteLine("Día no válido");
        break;
}
```

-----

#### C. Expresión `switch` y Pattern Matching

La **Expresión `switch`** (C\# 8.0+) es la evolución moderna del `switch`. Se utiliza como una **expresión funcional** que evalúa un valor y **devuelve un resultado** directamente, sin usar `case:` ni `break;`.

| Característica       | Descripción                                                   |
| :------------------- | :------------------------------------------------------------ |
| **Sintaxis**         | Es una **expresión** que siempre devuelve un valor.           |
| **Separadores**      | Los casos y sus resultados se separan por una **coma (`,`)**. |
| **Caso Por Defecto** | El guion bajo (`_`) es el caso por defecto (`default`).       |

**Ejemplo de Expresión `switch` (Concisa):**

```csharp
var resultadoDia = dia switch
{
    // Sintaxis: valor_a_comparar => valor_a_devolver
    1 => "Lunes",
    5 or 6 => "Fin de semana (o casi)", // Uso del operador 'or' moderno
    _ => "Día no válido" // El guion bajo (_) es el equivalente a 'default'
};
```

**Pattern Matching Avanzado:**

El Pattern Matching permite usar operadores relacionales directamente en los casos del `switch` para evaluar **rangos o condiciones complejas** de forma muy legible:

```csharp
int temperatura = 15;

string descripcion = temperatura switch
{
    < 0   => "Congelado",
    >= 25 => "Caluroso",
    // Usa 'and' o 'or' para definir rangos complejos
    >= 10 and < 25 => "Templado", 
    _     => "Frío"
};
// Resultado: descripcion es "Templado"
```

-----

### 4.3. Bucles (Ciclos)

Los bucles permiten repetir un bloque de código hasta que se cumpla una condición de terminación.

#### A. Bucle Mientras (`while`)

Ejecuta el bloque **cero o más veces**, ya que la condición se evalúa **antes** de la primera ejecución.

| Concepto DAW      | Sintaxis DAW                 | Implementación C\#      |
| :---------------- | :--------------------------- | :---------------------- |
| Bucle Condicional | `MIENTRAS (condición) HACER` | **`while (condicion)`** |

```csharp
int contador = 0;
while (contador < 3)
{
    Console.WriteLine($"Contador: {contador}");
    contador++; // Es crucial actualizar la condición para evitar un bucle infinito.
}
```

#### B. Bucle Repetir-Hasta (`do-while`)

Ejecuta el bloque **al menos una vez**, ya que la condición se evalúa **después** de la primera ejecución.

| Concepto DAW           | Sintaxis DAW                        | Implementación C\#                  |
| :--------------------- | :---------------------------------- | :---------------------------------- |
| Bucle Post-condicional | `REPETIR ... HASTA QUE (condición)` | **`do { ... } while (condicion);`** |

```csharp
int op = 0;
do
{
    Console.WriteLine("Introduce 1 para salir:");
    // Se fuerza la lectura, garantizando que el bloque se ejecuta una vez.
    int.TryParse(Console.ReadLine(), out op); 
} while (op != 1);
```

#### C. Bucle Para (`for`)

El bucle `for` es ideal para ciclos con un número de repeticiones conocido y control total sobre el índice.

| Concepto DAW      | Sintaxis DAW              | Implementación C\#                                |
| :---------------- | :------------------------ | :------------------------------------------------ |
| Bucle Determinado | `PARA i DESDE 1 HASTA 10` | **`for (inicialización; condición; incremento)`** |

```csharp
// Equivalente a: PARA i DESDE 0 HASTA 9
for (int i = 0; i < 10; i++) 
{
    Console.WriteLine($"Iteración {i}");
}
```

#### D. Bucle Para Cada (`foreach`)

Este bucle está optimizado para **iterar colecciones** (Arrays, Listas) sin preocuparse por el índice. Es la forma preferida de iterar en C\#.

| Concepto DAW     | Sintaxis DAW                      | Implementación C\#                         |
| :--------------- | :-------------------------------- | :----------------------------------------- |
| Iterar Colección | `PARA CADA elemento EN coleccion` | **`foreach (Tipo elemento in coleccion)`** |

```csharp
string[] nombres = { "Ana", "Beto", "Carla" };

foreach (var nombre in nombres)
{
    Console.WriteLine($"Hola, {nombre}"); 
}
```

#### E. Modificadores de Bucles

C\# utiliza las palabras clave estándar para controlar la ejecución del bucle:

  * **`break`**: **Termina** la ejecución del bucle *inmediatamente* y continúa con la instrucción que sigue al bucle.
  * **`continue`**: **Salta** la iteración actual y pasa directamente a la siguiente iteración del bucle.

<!-- end list -->

```csharp
for (int i = 0; i < 10; i++)
{
    if (i == 5)
    {
        break; // Detiene el bucle completamente en la iteración 5
    }
    if (i % 2 != 0)
    {
        continue; // Salta los números impares, solo imprime pares
    }
    Console.WriteLine(i); 
}
```

-----

## 5\. Programación Modular (Métodos)

En C\#, la lógica modular se implementa a través de **Métodos**. Un método es un bloque de código que realiza una tarea.

> **Nota:** Las funciones deben definirse despues del codigo principal en los **Top-Level Statements**.

### 5.1. Funciones y Procedimientos (Métodos)

Dado que estamos usando la sintaxis moderna (**Top-Level Statements**), los métodos se definen directamente y se distinguen por su tipo de retorno:

| Concepto DAW      | Equivalencia C\#  | Descripción                                                              |
| :---------------- | :---------------- | :----------------------------------------------------------------------- |
| **Procedimiento** | **`void`**        | No devuelve ningún valor. Se usa la palabra clave `void`.                |
| **Función**       | **`TipoRetorno`** | Devuelve un valor de un tipo específico (`int`, `string`, `bool`, etc.). |

**Ejemplos:**

```csharp
// Procedimiento (usa void)
void Saludar(string nombre) 
{
    Console.WriteLine($"Hola, {nombre}.");
}

// Función (usa 'int' como tipo de retorno)
int Sumar(int a, int b) 
{
    // Una función debe terminar con 'return valor;'
    return a + b;
}

// Llamadas desde el código principal:
Saludar("Desarrolladores");
var resultado = Sumar(10, 5); // resultado es 15
```

-----

### 5.2. Parámetros y Argumentos: Disciplina de Tipado

La verificación de tipos en C\# es **estricta**, pero permite ciertas conversiones. Esto es clave para entender la diferencia entre la regla de tu pseudocódigo y el comportamiento real de C\#.

#### A. Conversión Implícita (Ensanchamiento) en Llamadas

En el estándar C\#, el tipo del argumento pasado puede ser **automáticamente convertido** (conversión implícita o ensanchamiento) si se pasa de un rango menor a uno mayor y no hay riesgo de pérdida de datos.

```csharp
void RecibirDouble(double d) { /* ... */ }

int numero = 10;
// C# estándar: PERMITE esta llamada sin casting. 'int' se convierte implícitamente a 'double'.
RecibirDouble(numero); // OK

// 💡 Aplicación de Rigor Didáctico: Para mantener la disciplina estricta de tu curso,
// se recomienda a los alumnos forzar el casting explícito (double)numero, 
// aunque C# no lo exija.
```

#### B. Conversión Explícita (Estrechamiento) y Prohibición de Anulables

El compilador es **absolutamente estricto** en los siguientes casos, donde el *casting* explícito es obligatorio o se requiere una solución de seguridad:

| Situación                               | Requisito en C\#                   | Solución Obligatoria                              |
| :-------------------------------------- | :--------------------------------- | :------------------------------------------------ |
| **Estrechamiento (Mayor a Menor)**      | **`casting` explícito** (`(int)`)  | Riesgo de pérdida de información (ej. decimales). |
| **`T?` a `T` (Anulable a No Anulable)** | **Seguridad Nula (`null-safety`)** | Uso del operador **`??`** (Coalescencia Nula).    |

**Ejemplo de Seguridad Nula:**

```csharp
void Procesar(int numero) { /* ... */ } // Espera un int (NO null)

int? miNumero = ObtenerNumeroOpcional(); 

// Solución: Garantizar un valor por defecto si miNumero es null.
Procesar(miNumero ?? 0); 
```

### 5.3. Paso de Parámetros por Valor y por Referencia

Por defecto, C\# utiliza el **paso por valor**. La variable original solo se modifica si se utiliza la palabra clave **`ref`** para el paso por referencia.


| Mecanismo          | Palabra Clave | Comportamiento                                        |
| :----------------- | :------------ | :---------------------------------------------------- |
| **Por Valor**      | *(Ninguna)*   | Se envía una **copia** del valor.                     |
| **Por Referencia** | **`ref`**     | Se envía una **referencia** a la posición de memoria. |


¿Pero qué significa esto en la práctica? El paso **por valor** implica que cualquier cambio dentro del método **no afecta** a la variable original. En cambio, el paso **por referencia** permite que los cambios dentro del método **se reflejen** en la variable original.

Recordemos que cuando definimos `int edad = 25;`, la variable `edad` almacena el valor `25` **directamente** en su espacio de memoria. Esto quiere decir que `edad` **es la ubicación de memoria** que contiene el valor $25$, por ejemplo en la dirección $0x0012FF7C$.

Si pasamos `edad` a un método sin `ref` (paso **por valor**), el sistema **copia el valor** $25$ a una nueva dirección de memoria (por ejemplo, $0x0012FF80$), que es identificada por el parámetro de la función. Dado que el parámetro de la función es ahora una **copia totalmente independiente** de la variable original, cualquier modificación sobre él no tendrá **ningún efecto** sobre la variable `edad` original.

¿Qué pasa a nivel interno si usamos `ref`? Pues al parámetro de la función no le copiamos el contenido almacenado por la variable si no que le pasamos directamente su **dirección de memoria**. Es como si ahora tuviésemos dos alias o referencias apuntando al **mismo espacio de memoria**. Esto quiere decir que si dentro de la función cambiamos el valor de dicha variable, ese cambio es visible fuera de ella, pues en el fondo hemos accedido por otra referencia a la posición de memoria original donde estaba almacenada.


```csharp

**Ejemplo de `ref`:**

```csharp
void SumarReferencia(ref int num) 
{
    num = num + 10; 
}

int valor = 5;
SumarReferencia(ref valor); // 'ref' debe usarse en la definición y en la llamada.
// valor ahora es 15
```

### 5.4. Parámetros de Salida (`out`)

La palabra clave **`out`** permite a un método "devolver" múltiples valores. A diferencia de `ref`, la variable `out` no necesita ser inicializada antes de la llamada, pero **debe ser asignada** dentro del método.

```csharp
void Dividir(int dividendo, int divisor, out int cociente, out int resto)
{
    cociente = dividendo / divisor;
    resto = dividendo % divisor;
}

// C# moderno permite la declaración en la llamada:
Dividir(10, 3, out int resCociente, out int resResto); 

Console.WriteLine($"Cociente: {resCociente}, Resto: {resResto}"); 
```

### 5.5. Parámetros Opcionales, por Defecto y Nombrados

#### A. Parámetros por Defecto (Opcionales)

Se definen asignándoles un valor en la firma del método. Deben ir **al final** de la lista de parámetros.

```csharp
void Imprimir(string mensaje, int veces = 1) 
{
    // ...
}
Imprimir("Hola");         // usa veces = 1
Imprimir("Hola", 3);      // usa veces = 3
```

#### B. Argumentos Nombrados

Permiten especificar el argumento por el nombre del parámetro, haciendo la llamada más legible, especialmente cuando hay muchos parámetros opcionales.

```csharp
void Configurar(string color, int tamaño = 10, bool visible = true) { /* ... */ }

// Se llama nombrando el parámetro, permitiendo saltarse 'tamaño'.
Configurar(visible: false, color: "Azul"); 
```

### 5.6. Sobrecarga de Métodos (`Overloading`)

Permite tener **múltiples métodos con el mismo nombre** siempre que tengan una **firma diferente** (número o tipo de parámetros).

```csharp
int Sumar(int a, int b) { return a + b; }
decimal Sumar(decimal a, decimal b) { return a + b; } // Sobrecarga: distinto tipo de parámetro
```

### 5.7. Parámetros Variables (`params`)

La palabra clave **`params`** permite que un método acepte un número variable de argumentos de un tipo específico, agrupándolos en un *array*.

```csharp
int SumarMultiples(params int[] numeros)
{
    var suma = 0;
    foreach (var n in numeros)
    {
        suma += n;
    }
    return suma;
}

var s1 = SumarMultiples(1, 2, 3); // Se puede llamar como si fueran argumentos individuales
```

### 5.8. Devolución de Múltiples Valores con Tuplas

En el diseño modular, una función a menudo necesita calcular y devolver más de un valor (ej. un resultado y un código de estado). Mientras que los parámetros `out` permiten esto, la forma moderna, limpia y **segura** en C\# es mediante el uso de **Tuplas** (`ValueTuple`).

Una Tupla es un tipo estructural ligero que agrupa un conjunto de valores heterogéneos (de distintos tipos) en un solo contenedor.

#### A. Definición de la Función con Tupla

Para declarar una función que devuelve una tupla, se encierran los tipos y los nombres de los campos de retorno entre paréntesis `()` en la firma del método. Los nombres de los campos de la tupla `(Suma, Producto)` deben usar `PascalCase` (Mayúscula Inicial) por convención.

```csharp
(int Suma, int Producto) RealizarCalculos(int a, int b)
{
    // El 'return' agrupa los valores en el orden definido.
    return (a + b, a * b);
}
```

#### B. Uso y Deconstrucción de la Tupla

El método más elegante para consumir una tupla es la **deconstrucción**, que asigna los valores de la tupla a variables separadas en una sola instrucción, de manera limpia.

```csharp
// 1. Llamada a la función y deconstrucción inmediata
var (resultadoSuma, resultadoProducto) = RealizarCalculos(10, 5); 

// resultadoSuma contendrá 15, resultadoProducto contendrá 50

Console.WriteLine($"Suma: {resultadoSuma}");
Console.WriteLine($"Producto: {resultadoProducto}");

// 2. Acceso a los miembros por su nombre
var resultados = RealizarCalculos(8, 2);

Console.WriteLine($"Producto: {resultados.Producto}"); 
```

Poro otro lado, si no se desean todos los valores, se puede usar el **discards** (`_`) para ignorar los que no interesan:

```csharp
var (suma, _) = RealizarCalculos(7, 3); // Ignora el producto
Console.WriteLine($"Suma: {suma}");
```

| Beneficio Modular | Descripción                                                                      |
| :---------------- | :------------------------------------------------------------------------------- |
| **Claridad**      | La firma del método indica exactamente qué múltiples valores se esperan.         |
| **Tipado Seguro** | Cada miembro de la tupla tiene un tipo fijo y seguro.                            |
| **Simplicidad**   | Reemplaza el uso de los complejos parámetros `out` para la mayoría de los casos. |

-----

### 5.9. Recursividad

Se produce cuando un método se llama a sí mismo. Requiere un **caso base** para evitar un bucle infinito.

```csharp
long Factorial(int n)
{
    if (n <= 1)
    {
        return 1; // Caso Base
    }
    return n * Factorial(n - 1); // Llamada Recursiva
}
```

### 5.10. Ámbito de las Variables (`Scope`)

El **ámbito** define la parte del código donde una variable es accesible, y está delimitado por las **llaves `{}`**. Las variables existen solo dentro del bloque donde fueron declaradas.

```csharp
if (true) 
{
    int x = 10; // 'x' existe solo dentro de este bloque
}
// 'x' no es accesible aquí.
```

Debemos tener en cuenta la diferencia del alcance de las variables definidas dentro de métodos (locales) y las definidas fuera (globales), pero en el contexto de Top-Level Statements, todas las variables definidas en el código principal son locales a ese ámbito y la visibilidad entre módulos.

- Local: Dentro de un método o bloque.
- Global: Variables definidas fuera de cualquier método (no aplicable en Top-Level Statements).
- Módulo: Variables y métodos accesibles dentro del mismo archivo o espacio de nombres.

```csharp

int contadorGlobal = 0; // Variable de módulo
void IncrementarContador() 
{
    contadorGlobal++; // Accede a la variable de módulo
}
IncrementarContador();

Console.WriteLine($"Contador Global: {contadorGlobal}");

int sumarLocal(int a, int b) 
{
    int resultadoLocal = a + b; // Variable local al método
    return resultadoLocal;
}


for(int i = 0; i < 5; i++) 
{
    int contadorLocal = i; // Variable local al bloque del for
    Console.WriteLine($"Contador Local: {contadorLocal}");
}

Console.WriteLine(contadorLocal); // Error: 'contadorLocal' no es accesible aquí.

var resultado = Sumar(3, 4); // Llamada a función definida anteriormente

```

### 5.11. Espacios de Nombres (Namespaces)
Los **Espacios de Nombres (Namespaces)** en C\# son contenedores lógicos que organizan y agrupan clases, estructuras, interfaces, enumeraciones y otros tipos relacionados. Ayudan a evitar conflictos de nombres y facilitan la gestión del código en proyectos grandes.

#### A. Definición de un Espacio de Nombres
Un espacio de nombres se define utilizando la palabra clave `namespace`, seguida del nombre del espacio y un bloque de llaves `{}` que contiene los tipos que pertenecen a ese espacio.

```csharp
namespace MiAplicacion.Utilidades
{
    public struct Posicion
    {
        public int X;
        public int Y;
    }
}
```
#### B. Uso de Espacios de Nombres
Para utilizar tipos definidos en un espacio de nombres diferente, se debe importar el espacio de nombres utilizando la directiva `using` al inicio del archivo de código.

```csharp
using MiAplicacion.Utilidades;
Posicion pos = new Posicion();
pos.X = 10;
pos.Y = 20;
Console.WriteLine($"Posición: ({pos.X}, {pos.Y})");
```


## 6\. Arrays (Arreglos)

En C\#, los **Arrays** (arreglos) son estructuras de datos que almacenan una colección de elementos del **mismo tipo** en ubicaciones de memoria contiguas. Su característica principal es que **el tamaño es fijo** una vez que se han creado. **Los índices siempre comienzan en 0.**

### 6.1. Arrays Unidimensionales

Un *array* unidimensional es la secuencia más básica de datos.

| Operación          | Sintaxis C\#                       | Ejemplo                                          |
| :----------------- | :--------------------------------- | :----------------------------------------------- |
| **Declaración**    | `Tipo[] nombreArray;`              | `int[] edades;`                                  |
| **Creación**       | `new Tipo[tamaño];`                | `edades = new int[3];`                           |
| **Inicialización** | `Tipo[] nombre = { v1, v2, ... };` | `string[] nombres = { "Ana", "Beto", "Carla" };` |

**Ejemplos de Creación y Asignación:**

```csharp
// 1. Declaración, Creación y Asignación
int[] edades = new int[3]; 
edades[0] = 25;
edades[1] = 30;

// 2. Inicialización abreviada
string[] colores = { "Rojo", "Verde", "Azul" };

// 3. Acceso a la longitud (el número de elementos)
int total = colores.Length; // total es 3
```

**Recorrido de Arrays:**

Los *arrays* se pueden recorrer utilizando los bucles `for` (para un control preciso del índice) o `foreach` (para iterar sobre cada elemento).

```csharp
// Usando for:
for (int i = 0; i < colores.Length; i++)
{
    Console.WriteLine($"Elemento en índice {i}: {colores[i]}");
}
// Usando foreach (Recomendado):
foreach (var color in colores)
{
    Console.WriteLine(color);
}
```

### 6.2. Arrays Multidimensionales

C\# ofrece dos modelos principales para representar estructuras tabulares o de datos con múltiples dimensiones, como matrices: **Rectangulares** y **Escalonados**.

#### A. Arrays Rectangulares (Multidimensionales Clásicos)

Estos *arrays* son matrices donde todas las filas tienen la misma longitud (como una tabla o cuadrícula). Se definen utilizando una **coma** dentro de los corchetes. **OJO**: Cuidado con `.Length`, ya que devuelve el total de elementos, no la longitud por dimensión. Para eso se usa `GetLength(dimension)`.

| Operación       | Sintaxis C\#                 | Notas                        |
| :-------------- | :--------------------------- | :--------------------------- |
| **Declaración** | `Tipo[,] nombreArray;`       | Una coma para 2 dimensiones. |
| **Creación**    | `new Tipo[filas, columnas];` |                              |
| **Acceso**      | `array[fila, columna]`       |                              |

**Ejemplos:**

```csharp
// 1. Array de 2x3 (2 filas, 3 columnas)
int[,] matriz = new int[2, 3]; 

// Asignación de valor: [fila, columna]
matriz[0, 1] = 50; 

// 2. Inicialización
int[,] tablero = {
    { 1, 2, 3 }, 
    { 4, 5, 6 }
};

// Recorrido de Arrays Rectangulares (se usa GetLength(dimension)):
for (int i = 0; i < tablero.GetLength(0); i++) // Dimensión 0 (Filas)
{
    for (int j = 0; j < tablero.GetLength(1); j++) // Dimensión 1 (Columnas)
    {
        Console.Write($"{tablero[i, j]} ");
    }
    Console.WriteLine(); 
}
```

#### B. Arrays Escalonados o de Arrays (`Jagged Arrays`)

Este modelo permite crear un **array de *arrays***, donde cada sub-array (fila) puede tener una longitud diferente. Es ideal para modelar datos irregulares. Se define usando **doble corchete** `[][]`. **OJO** debes iniciar cada fila por separado. Sobre todo si no toma valores por defecto.

| Operación       | Sintaxis C\#            | Notas                                           |
| :-------------- | :---------------------- | :---------------------------------------------- |
| **Declaración** | `Tipo[][] nombreArray;` | Corchetes separados.                            |
| **Creación**    | `new Tipo[filas][];`    | Solo se define el número de filas inicialmente. |
| **Acceso**      | `array[fila][columna]`  | Requiere dos pares de corchetes.                |

**Ejemplos:**

```csharp
// 1. Crear un array de 3 filas, dejando la longitud de las columnas indefinida
int[][] tablaIrregular = new int[3][];

// 2. Asignar arrays internos con diferente longitud
tablaIrregular[0] = new int[] { 1, 2 };          // Longitud 2
tablaIrregular[1] = new int[] { 3, 4, 5, 6 };    // Longitud 4
tablaIrregular[2] = new int[] { 7 };             // Longitud 1

// Recorrido de Arrays Escalonados (se usa .Length en ambos niveles):
for (int i = 0; i < tablaIrregular.Length; i++) // Recorre las filas
{
    // tablaIrregular[i].Length da la longitud de la fila actual
    foreach (var valor in tablaIrregular[i])
    {
        Console.Write($"{valor} ");
    }
    Console.WriteLine();
}
```

#### C. Comparación entre Arrays Rectangulares y Escalonados
| Característica               | Arrays Rectangulares                | Arrays Escalonados                     |
| :--------------------------- | :--------------------------------- | :------------------------------------ |
| Estructura                   | Matriz fija (todas las filas igual longitud) | Array de arrays (filas pueden variar en longitud) |
| Sintaxis de Declaración      | `Tipo[,] nombre;`                  | `Tipo[][] nombre;`                  |
| Acceso a Elementos           | `array[fila, columna]`             | `array[fila][columna]`             |
| Uso Común                    | Datos tabulares regulares          | Datos irregulares o jerárquicos      |

### 6.3. Arrays con Tipos Anulables (`T?[]`)

Un *array* de tipos de valor anulables (`int?`, `bool?`, etc.) permite que cada posición del array almacene un valor válido **o `null`**.

```csharp
// Array de enteros que pueden ser null
int?[] posiblesNumeros = new int?[] { 10, null, 20 };

// Recorrido y manejo de null
foreach (var num in posiblesNumeros)
{
    // Si la posición tiene null, se usa el operador de Coalescencia Nula (??) para asignar 0.
    int valorSeguro = num ?? 0;
    Console.WriteLine($"Valor seguro: {valorSeguro}");
}
```

> **Nota:** Al usar tipos anulables en arrays, es importante manejar adecuadamente los valores `null` para evitar excepciones en tiempo de ejecución.
> **No es lo mismo un array del tipo `int[]` que uno del tipo `int?[]`. El primero no puede contener `null` en ninguna posición.**
> **No es lo mismo un array de tipos `int?[]` que un `int[]?`. El primero es un array que puede contener `null` en sus posiciones, mientras que el segundo es un array que puede ser `null` en sí mismo.**

```csharp
int?[] arrayAnulable = new int?[5]; // Array que puede contener null en sus posiciones
int[]? arrayQuePuedeSerNull = null;   // El array en sí puede ser
int?[]? arrayAnulableQuePuedeSerNull = null; // El array puede ser null y sus posiciones también
```

### 6.4. Copiando/Cloando Arrays
Para crear una copia independiente de un array, se utiliza el método **`Clone()`** o **`CopyTo()`**, que realiza una copia superficial (shallow copy). Esto es útil para evitar modificaciones no deseadas en el array original. Puedes usar esto o la copia profunda manual, tambien tenemos 

```csharp
// función para clonar arrays
int[] ClonarArray(int[] original)
{
    var copia = new int[original.Length];
    for (int i = 0; i < original.Length; i++)
    {
        copia[i] = original[i]; // Copia elemento a elemento
    }
    return copia;
}

int [] numeros = { 1, 2, 3 };
int [] copiaNumeros = ClonarArray(numeros); // copiaNumeros es una copia independiente

// Ahora con CopyTo, necesitamos tener ya el array creado con el tamaño
int[] destino = new int[numeros.Length];
numeros.CopyTo(destino, 0); // Copia el contenido de 'numeros' a 'destino'

// Usando Clone (devuelve un objeto, se debe castear)
int[] clon = (int[])numeros.Clone();
```

### 6.5. Métodos Útiles para Arrays
La clase estática **`Array`** en C\# proporciona varios métodos útiles para manipular arrays.
| Método                  | Descripción                                                | Ejemplo C\#                     |
| :---------------------- | :--------------------------------------------------------- | :------------------------------ |
| **`Array.Sort(array)`** | Ordena los elementos del array en orden ascendente.        | `Array.Sort(edades);`           |
| **`Array.Reverse(array)`** | Invierte el orden de los elementos en el array.              | `Array.Reverse(colores);`       |
| **`Array.IndexOf(array, valor)`** | Devuelve el índice de la primera aparición del valor en el array, o -1 si no se encuentra. | `int indice = Array.IndexOf(nombres, "Beto");` |
| **`Array.Resize(ref array, nuevoTamaño)`** | Cambia el tamaño del array, creando uno nuevo si es necesario. | `Array.Resize(ref numeros, 10);` |


### 6.6. Arrays por referencia y paso a métodos

En C\#, los arrays son **tipos de referencia**, lo que significa que cuando se pasan a métodos, se pasa una referencia al array original. Por lo tanto, cualquier modificación realizada en el array dentro del método afectará al array original.

```csharp
void ModificarArray(int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] += 10; // Modifica el array original
    }
}

int[] numeros = { 1, 2, 3 };
ModificarArray(numeros); // Pasa la referencia del array (por valor)
// Ahora 'numeros' es { 11, 12, 13 }
```

> **Nota:** ¿Pero qué pasa si queremos que el método pueda **reasignar el array completo** (crear un nuevo array y asignarlo a la variable original)? En ese caso, debemos usar la palabra clave `ref` para pasar la referencia del array por referencia.

```csharp
void ReasignarArray(ref int[] arr)
{
    arr = new int[] { 100, 200, 300 }; // Reasigna un nuevo array
}

int[] numeros = { 1, 2, 3 };
ReasignarArray(ref numeros); // Pasa la referencia del array por referencia
// Ahora 'numeros' es { 100, 200, 300 }
```

-----

#### ¿Por qué es necesario `ref` para la reasignación?

La razón fundamental es que, en C\#, el **mecanismo de paso por defecto es siempre por valor**, incluso para las variables de tipo de referencia.

1.  **Arrays y Referencias:** Los arrays son objetos almacenados en el *heap* (montón). La variable `int[] numeros` *no contiene* el array; contiene la **referencia** (la dirección de memoria) de dónde se encuentra ese array.
2.  **Paso por Valor de la Referencia:** Cuando llamas a `ModificarArray(numeros)`, el método recibe una **copia del valor de la referencia**.
      * Puedes usar la referencia copiada para acceder al array en el *heap* y modificar sus elementos (por eso `ModificarArray` funciona).
      * Sin embargo, si intentas asignar un nuevo array (`arr = new int[] {...}`) solo estás cambiando la **copia de la referencia** dentro del método. La variable `numeros` original fuera del método sigue apuntando al array antiguo.
3.  **Paso por Referencia con `ref`:** Al usar `ReasignarArray(ref numeros)`, le indicas a C\# que pase la variable `numeros` completa (incluyendo su contenido, que es la referencia) **por referencia**. Esto permite que cualquier cambio a la variable `arr` dentro del método (como asignarle un nuevo array) se refleje directamente en la variable original `numeros` fuera del método.

***Entonces un array pasa por Valor o por Referencia***

Aunque creas que el compartamiento cambia, lo que subyce es lo que hemos visto con los tipos simples. Aunque se suele decir que estos se pasan por "referencia", **el mecanismo subyacente sigue siendo el paso por valor ***pero*** de una dirección de memoria**.

1.  **Declaración del Array:** Cuando definimos un *array*, como `int[] numeros = new int[3];`, la variable `numeros` **no** almacena los datos $\{0, 0, 0\}$. En su lugar, almacena una **dirección de memoria** (una referencia o puntero, por ejemplo $0xABC123$) que apunta a la ubicación real de los datos en el *heap* (montón).

2.  **Paso por Valor de la Dirección (Comportamiento Estándar):**
    * Al pasar `numeros` a una función **sin** `ref`, lo que se copia es la **dirección de memoria** ($0xABC123$), es un paso por copia.
    * El parámetro de la función recibe esta copia y también apunta a la misma ubicación en el *heap*. Es decir, ambas variables (la original y el parámetro) apuntan a la misma estructura de datos.
    * **Resultado:** Podemos **modificar** el **contenido** del *array* (por ejemplo, cambiar `numeros[0]` a $99$), y este cambio **se reflejará** fuera de la función, ya que ambas referencias acceden a la misma zona de datos.

    > **En resumen:** La **dirección** se pasa **por valor**, lo que permite **modificar el contenido** apuntado por esa dirección, pero no permite cambiar la dirección en sí misma.

3.  **El Límite del Paso Estándar:**
    * Si dentro de la función intentamos **re-asignar** el *array* a una **nueva dirección** (ej. `numeros = new int[5];`), solo estamos cambiando la copia local de la dirección.
    * La variable original (`numeros` fuera de la función) **seguirá apuntando a la dirección antigua** ($0xABC123$), y no habrá ningún efecto visible fuera del método.

Si queremos **cambiar el apuntador** del *array* o **re-asignar** el vector original desde dentro de la función, debemos usar explícitamente la palabra clave `ref`.

¿Qué pasa a nivel interno si usamos `ref`?
* Al parámetro de la función no le copiamos el contenido de la variable (que es la dirección $0xABC123$).
* En su lugar, le pasamos directamente la **dirección de memoria de la variable misma** (ej. la dirección $0xFFF99$ donde está guardada la referencia $0xABC123$).
* Esto nos permite tener un **control absoluto**: podemos modificar el contenido apuntado, o **cambiar la dirección almacenada** en la variable original (por ejemplo, reasignar `numeros = new int[5];`), y este cambio se hará permanente y visible fuera de la función.

Así que ten en cuenta esto cuando decimos qué algo pasa por valor o por referencia y qué realmente se almacena en la variable.

### 6.7. Argumentos de Programas
Cuando se ejecuta un programa C\#, es posible pasar argumentos desde la línea de comandos. Estos argumentos se reciben como un array de cadenas (`string[] args`) en el método `Main`. Como usamos Top-Level Statements, los argumentos se pueden acceder directamente a través de la variable `args`.

```csharp
// Ejemplo de uso de argumentos en Main
if (args.Length > 0)
{
    Console.WriteLine($"Argumento recibido: {args[0]}");
}
else
{
    Console.WriteLine("No se recibieron argumentos.");
}
```

## 7\. Cadenas de Texto y Expresiones Regulares

### 7.1. La Clase `String` y la Inmutabilidad

El tipo **`string`** en C\# es una secuencia de caracteres (texto). Es un tipo de referencia (una clase) que encapsula el texto. El concepto más importante que deben dominar es la **inmutabilidad**.

**Inmutabilidad:** Una vez que se crea un objeto `string` y se le asigna un valor, su contenido **no puede cambiar**. Cualquier operación que parezca modificar el `string` (como concatenación, reemplazo o conversión a mayúsculas) en realidad genera y devuelve un **objeto `string` completamente nuevo** en la memoria.

| Característica        | Sintaxis C\#             | Descripción                                                 |
| :-------------------- | :----------------------- | :---------------------------------------------------------- |
| **Declaración**       | `string nombre = "Ana";` | Las cadenas se encierran en comillas dobles.                |
| **Longitud**          | `.Length`                | Propiedad que devuelve el número de caracteres.             |
| **Acceso a Carácter** | `nombre[indice]`         | Permite acceder a un carácter específico (índices desde 0). |

### 7.2. Concatenación Moderna y Literales

#### A. Interpolación de Cadenas (`$`)

La **Interpolación de Cadenas** es la técnica más limpia, legible y preferida en C\# para construir cadenas. Se usa el símbolo **`$`** antes de la comilla de apertura y permite incrustar variables o cualquier expresión entre **llaves `{}`**.

```csharp
int cantidad = 3;
double precioUnitario = 15.5;

// Interpolación: El código dentro de {} se evalúa y se convierte a texto.
string factura = $"Se compraron {cantidad} unidades a {precioUnitario}€ cada una.";

// Se puede aplicar formato directamente:
string total = $"Total a pagar: {cantidad * precioUnitario:C2}"; // ':C2' aplica formato monetario (2 decimales)
```

#### B. Literales de Cadena Verbatim (`@`)

Anteponer el símbolo **`@`** a una cadena la convierte en una **cadena literal (verbatim)**. C\# ignora las secuencias de escape comunes (como `\n` o `\\`), tratando el contenido como texto sin formato. Esto es esencial para rutas de archivo o expresiones regulares.

```csharp
// Sin @: Se requiere doble barra invertida (escape)
string rutaClasica = "C:\\Users\\Documentos\\";

// Con @: Se usa una sola barra invertida (Verbatim)
string rutaVerbatim = @"C:\Users\Documentos\";
```

#### C. Literales de Cadena de Varias Líneas (`"""`)

A partir de C\# 11, se pueden usar **tres comillas dobles (`"""`)** para crear bloques de texto que se extienden por varias líneas, preservando los saltos de línea y el formato original. Es perfecto para incrustar JSON, XML, HTML o bloques de SQL.

```csharp
// Creación de un bloque JSON de forma limpia
var datosJSON = """
{
    "id": 101,
    "nombre": "Producto X",
    "stock": 50
}
""";

Console.WriteLine(datosJSON);
```

### 7.3. Métodos Esenciales de la Clase `String`

La clase `String` incluye numerosos métodos útiles para la manipulación y validación de texto.

| Método Común                | Retorno    | Descripción                                                                                    | Ejemplo C\#                   |
| :-------------------------- | :--------- | :--------------------------------------------------------------------------------------------- | :---------------------------- |
| **`ToUpper()`**             | `string`   | Convierte la cadena a mayúsculas.                                                              | `texto.ToUpper()`             |
| **`ToLower()`**             | `string`   | Convierte la cadena a minúsculas.                                                              | `texto.ToLower()`             |
| **`Trim()`**                | `string`   | Elimina espacios en blanco al principio y al final.                                            | `entrada.Trim()`              |
| **`Substring(i, [l])`**     | `string`   | Extrae una subcadena a partir del índice `i` y con longitud `l` (opcional).                    | `isbn.Substring(0, 3)`        |
| **`IndexOf(s)`**            | `int`      | Devuelve el índice de la primera aparición de la subcadena `s`, o `-1` si no existe.           | `email.IndexOf('@')`          |
| **`Contains(s)`**           | `bool`     | Verifica si la cadena contiene la subcadena `s`.                                               | `texto.Contains("error")`     |
| **`Replace(v, n)`**         | `string`   | Crea una nueva cadena reemplazando la subcadena vieja (`v`) por la nueva (`n`).                | `fecha.Replace("/", "-")`     |
| **`Split(char)`**           | `string[]` | Divide la cadena en un *array* de subcadenas usando un separador (ej. `,`).                    | `linea.Split(',')`            |
| **`StartsWith(s)`**         | `bool`     | Verifica si la cadena comienza con la subcadena `s`.                                           | `codigo.StartsWith("DAW")`    |
| **`EndsWith(s)`**           | `bool`     | Verifica si la cadena termina con la subcadena `s`.                                            | `nombre.EndsWith(".pdf")`     |
| **`IsNullOrEmpty(s)`**      | `bool`     | Método estático. Verifica si la cadena es `null` o está vacía (`""`).                          | `string.IsNullOrEmpty(input)` |
| **`String.Join(sep, arr)`** | `string`   | Método estático. Une los elementos de un *array* de *strings* o colección usando un separador. | `string.Join("-", partes)`    |


Tambien podemos crear un string repitiendo un caracter tantas veces como queramos.
```csharp
string linea = new string('-', 30); // Crea una línea de 30 guiones
Console.WriteLine(linea);
```


### 7.4. Strings, Inmutabilidad, y la Necesidad de `ref`

#### Concepto Clave: Los Strings son Inmutables

En C\#, la clase `string` es un **tipo de referencia**, al igual que los arrays. Esto significa que una variable `string` contiene una **referencia** (una dirección de memoria) al objeto de cadena real que se encuentra en el *heap*.

Sin embargo, los `string` tienen una característica crucial: son **inmutables**. Una vez creado un objeto `string`, su contenido no se puede cambiar. Cualquier operación que parezca modificar una cadena (como concatenación o asignación) en realidad **crea un objeto `string` completamente nuevo** en el *heap*.

-----

#### Strings Pasados a Métodos (Sin `ref`)

Cuando un `string` se pasa a un método, se pasa una **copia de la referencia**.

Si intentas "cambiar" la cadena dentro del método, lo que realmente haces es **reasignar la variable local del parámetro** para que apunte a un nuevo objeto `string`. La variable original fuera del método **no se ve afectada**.

```csharp
void ModificarString(string s)
{
    // C# crea un *nuevo* objeto "¡Adiós!" en el heap.
    // La variable local 's' ahora apunta a ese nuevo objeto.
    s = "¡Adiós!"; 
    // La variable original 'texto' fuera del método NO cambia.
}

string texto = "¡Hola!";
ModificarString(texto); 

// Ahora 'texto' sigue siendo "¡Hola!"
```

-----

#### Reasignación de String Completo con `ref`

Si necesitas que el método pueda cambiar la **variable original** (es decir, hacer que apunte a un nuevo objeto `string`), debes usar la palabra clave `ref`.

El uso de `ref` con `string` es idéntico a su uso con arrays, ya que en ambos casos se está permitiendo que el método modifique el **valor de la variable de referencia** original.

```csharp
void ReasignarStringConRef(ref string s)
{
    // C# crea un *nuevo* objeto "¡Adiós!" en el heap.
    // Gracias a 'ref', la variable original 'texto' ahora apunta a este nuevo objeto.
    s = "¡Adiós!"; 
}

string texto = "¡Hola!";
ReasignarStringConRef(ref texto); 

// Ahora 'texto' es "¡Adiós!"
```

-----

#### ¿Por qué `ref` es necesario?

La necesidad de `ref` se debe al mismo principio que con los arrays: el paso de parámetros por defecto es **por valor**, incluso para tipos de referencia:

1.  La variable `string texto` contiene una **referencia** (una dirección).
2.  Al pasar la variable **sin `ref`**, el método recibe una **copia de esa referencia**.
3.  Al intentar reasignar (`s = ...`), solo se modifica la **copia local** de la referencia dentro del método, dejando la variable `texto` original intacta.
4.  Al pasar con **`ref`**, la variable `texto` se pasa **por referencia**, permitiendo al método `ReasignarStringConRef` modificar el valor de la variable original, haciendo que apunte al nuevo objeto `string` creado.

### 7.5. Construcción Eficiente con `StringBuilder`

Dado que la concatenación repetitiva con `+` genera muchos objetos intermedios debido a la inmutabilidad de `string`, C\# proporciona la clase **`System.Text.StringBuilder`** para optimizar este proceso.

`StringBuilder` es una clase **mutable** que gestiona un *buffer* interno de caracteres, realizando las modificaciones in-place hasta que se necesita el resultado final.

```csharp
using System.Text;

// 1. Crear una instancia
var constructor = new StringBuilder(); 

// 2. Usar .Append() para añadir contenido de forma eficiente
constructor.Append("Reporte Generado el ");
constructor.Append(DateTime.Now.ToShortDateString());
constructor.Append("\nTotal de elementos: ");
constructor.Append(50);

// 3. Obtener el string final inmutable
string reporteFinal = constructor.ToString(); 
```

### 7.6. Expresiones Regulares (`System.Text.RegularExpressions`)

Las **Expresiones Regulares (Regex)** son patrones de búsqueda para identificar, validar o manipular texto que sigue reglas complejas (ej. formatos de email, matrículas, números de teléfono).

En C\#, el motor de Regex se encuentra en el *namespace* **`System.Text.RegularExpressions`**.

#### A. Uso Estático (Conciso)

Para validaciones rápidas, se recomienda usar los métodos estáticos de la clase `Regex`, que son más concisos:

```csharp
using System.Text.RegularExpressions;

string numeroTelefono = "666-123-456";
// El patrón @"" es una cadena verbatim. \d significa dígito.
var patron = @"\d{3}-\d{3}-\d{3}"; 

// IsMatch verifica si la cadena coincide con el patrón.
if (Regex.IsMatch(numeroTelefono, patron))
{
    Console.WriteLine("Formato de teléfono válido.");
}
```

#### B. Uso Clásico (Creación de Objeto)

Para operaciones complejas o repetitivas, se crea un objeto `Regex` para compilar el patrón una sola vez.

```csharp
// Patrón para buscar números (\d+) en una cadena
var patron = @"\d+"; 
var regex = new Regex(patron); // Se crea el objeto Regex

string texto = "Tienes 2 avisos y 5 tareas pendientes.";

// .Matches() devuelve todas las coincidencias
MatchCollection coincidencias = regex.Matches(texto);

foreach (Match match in coincidencias) 
{
    Console.WriteLine($"Coincidencia encontrada: {match.Value}"); // Muestra "2" y "5"
}
```

#### C. Uso de Grupos en Expresiones Regulares
Los **grupos** permiten capturar partes específicas de una coincidencia para su posterior uso. Se definen usando paréntesis `()` en el patrón.

Los indices son:
- Grupo 0: Coincidencia completa
- Grupo 1: Primer grupo capturado
- Grupo 2: Segundo grupo capturado, etc.
- ...

```csharp
var patron = @"(\d{3})-(\d{3})-(\d{3})"; // Patrón con grupos para teléfono
var regex = new Regex(patron);
string telefono = "666-123-456";
Match match = regex.Match(telefono);
if (match.Success)
{
    // Acceso a los grupos capturados
    string codigoArea = match.Groups[1].Value; // "666"
    string parteMedio = match.Groups[2].Value; // "123"
    string parteFinal = match.Groups[3].Value; // "456"

    Console.WriteLine($"Código Área: {codigoArea}, Medio: {parteMedio}, Final: {parteFinal}");
}
```
Tambien podemos usar alias con los grupos y referirnos a ellos de manera alternativa (más legible), aunque también podemos referirnos a ellos por su índice.

```csharp
var patron = @"(?<Area>\d{3})-(?<Medio>\d{3})-(?<Final>\d{3})"; // Grupos con nombres
var regex = new Regex(patron);
string telefono = "666-123-456";
Match match = regex.Match(telefono);
if (match.Success)
{
    // Acceso a los grupos capturados por nombre
    string codigoArea = match.Groups["Area"].Value; // "666"
    string parteMedio = match.Groups["Medio"].Value; // "123"
    string parteFinal = match.Groups["Final"].Value; // "456"

    Console.WriteLine($"Código Área: {codigoArea}, Medio: {parteMedio}, Final: {parteFinal}");
}
```

## 8. Estructuras (Structs) y Enumeraciones (Enums)

Las **Estructuras (Structs)** en C\# son tipos de datos que permiten agrupar variables de diferentes tipos bajo un mismo nombre. Son de tipo valor, por lo que se almacenan directamente en la pila de memoria. Además, se pasan por valor a los métodos, lo que significa que se crea una copia al pasarlos como argumentos.

Al crearlas, debemos iniciar todos sus campos antes de usarlas. Si no tendrá n valores predeterminados.

Sin queremos modificar el valor original, debemos usar la palabra clave `ref` al pasarlo a un método o `out` si queremos devolver un valor a través del parámetro.

> **Nota:** Las estructuras deben definirse despues del codigo principal en los **Top-Level Statements** pero mejor aún **hazlo en otro archivo** para mantener el código organizado.

### 8.1. Definición y Uso de Estructuras

```csharp
// Definición de una estructura simple
struct Punto
{
    public int X;
    public int Y;
}

// Uso de la estructura
Punto p1; // Declaración
p1.X = 10; // Asignación de valores
p1.Y = 20;

Console.WriteLine($"Punto p1: ({p1.X}, {p1.Y})");
```

Si usamos otro fichero, por ejemplo `Structs/Punto.cs`, la definición de la estructura sería la misma, pero el uso en el código principal se mantendría igual.

```csharp
using Structs; // Asegúrate de usar el espacio de nombres correcto
Punto p1; // Declaración
p1.X = 10; // Asignación de valores
p1.Y = 20;
Console.WriteLine($"Punto p1: ({p1.X}, {p1.Y})");
```

### 8.2. Inicialización de Estructuras
También podemos inicializar una estructura al declararla utilizando llaves `{}` y asignando los valores de sus campos directamente, sin necesidad de asignarlos uno por uno.

El orden no importa siempre que los nombres coincidan con los campos existentes. Esta forma crea la estructura con sus valores predeterminados y luego asigna los campos indicados entre llaves.

```csharp
Punto pInicializado = new Punto { X = 30, Y = 40 };
Console.WriteLine($"Punto inicializado: ({pInicializado.X}, {pInicializado.Y})");
```
T
Tambien puedes usar los paréntesis `()` para inicializar una estructura, pero en este caso, debes proporcionar los valores en el orden en que se definen los campos en la estructura.

```csharp
Punto pOrden = new Punto(50, 60); // Asumiendo que la estructura tiene un constructor que acepta dos enteros
Console.WriteLine($"Punto ordenado: ({pOrden.X}, {pOrden.Y})");
```

### 8.3. Paso de Estructuras a Métodos (por valor)

```csharp
void MoverPunto(Punto punto, int deltaX, int deltaY)
{
    punto.X += deltaX;
    punto.Y += deltaY;
    Console.WriteLine($"Punto movido dentro del método: ({punto.X}, {punto.Y})");
}

Punto p2 = new Punto { X = 5, Y = 15 };
MoverPunto(p2, 10, 10); // Se pasa por valor
Console.WriteLine($"Punto p2 después de llamar al método: ({p2.X}, {p2.Y})"); // No cambia
```
### 8.4. Paso de Estructuras por Referencia (`ref`)

```csharp
void MoverPuntoRef(ref Punto punto, int deltaX, int deltaY)
{
    punto.X += deltaX;
    punto.Y += deltaY;
    Console.WriteLine($"Punto movido dentro del método (ref): ({punto.X}, {punto.Y})");
}

Punto p3 = new Punto { X = 5, Y = 15 };
MoverPuntoRef(ref p3, 10, 10); // Se pasa por referencia
Console.WriteLine($"Punto p3 después de llamar al método (ref): ({p3.X}, {p3.Y})"); // Cambia
```

### 8.5. Estructuras de solo lectura (readonly struct)

Cuando queremos garantizar que los campos de una estructura no se puedan modificar después de ser creados, se puede declarar como readonly.

Esto mejora la seguridad y el rendimiento, ya que el compilador puede optimizar su uso.
```csharp
readonly struct Coordenada
{
    public int Latitud { get; }
    public int Longitud { get; }
}

Coordenada coord = new Coordenada { Latitud = 40, Longitud = -3 };
Console.WriteLine($"Coordenada: ({coord.Latitud}, {coord.Longitud})");
// No podemos hacer 
// coord.Latitud = 41; // Error: No se puede modificar un campo de una estructura readonly

```

### 8.6. Estructuras por referencia (ref struct)

Las estructuras por referencia (ref struct) son estructuras especiales que solo pueden existir en la pila, no en el heap.

Esto significa que no pueden usarse como parte de otras estructuras o clases, ni pueden ser capturadas. Se utilizan para optimizar el rendimiento en escenarios específicos, como el manejo de buffers de memoria.

```csharp
ref struct BufferTemporal
{
    public Span<byte> Datos;
}

BufferTemporal buffer = new BufferTemporal
{
    Datos = stackalloc byte[256] // Asignación en la pila
};

Console.WriteLine($"Tamaño del buffer: {buffer.Datos.Length} bytes");
```


### 8.7. Definición y Uso de Enumeraciones
Las **Enumeraciones (Enums)** son tipos de datos que permiten definir un conjunto de constantes con nombre, facilitando la legibilidad y el mantenimiento del código.

> **Nota:** Las enumeraciones deben definirse después del código principal en los **Top-Level Statements**, pero es mejor aún **hacerlo en otro archivo** para mantener el código organizado.

De forma predeterminada, los valores constantes asociados de los miembros de enumeración son de tipo int; comienzan con cero y aumentan en uno siguiendo el orden de texto de definición.

Podemos decir que un enum, son un conjunto de enteros que les ponemos un alias.

También puede especificar explícitamente los valores constantes asociados, si lo desea.

Cuando llamas a `.ToString()` sobre una variable de tipo enum, C# por defecto devuelve la cadena que corresponde al nombre del miembro. Tambien pudes usar `nameof()` para obtener el nombre del miembro como cadena en tiempo de compilación o `Enum.GetName()` para obtener el nombre del miembro en tiempo de ejecución en función de su valor numérico.

```csharp
// Definición de una enumeración
enum DiasDeLaSemana
{
    Domingo,
    Lunes,
    Martes,
    Miércoles,
    Jueves,
    Viernes,
    Sábado
}

// Uso de la enumeración
DiasDeLaSemana hoy = DiasDeLaSemana.Lunes;
Console.WriteLine($"Hoy es: {hoy}");

// Comparación de valores de enumeración
if (hoy == DiasDeLaSemana.Lunes)
{
    Console.WriteLine("Es el primer día de la semana laboral.");
}

// Conversión de enumeración a entero
int diaNumero = (int)hoy; // diaNumero será 1
Console.WriteLine($"Número del día: {diaNumero}"); 

// Conversión de entero a enumeración
DiasDeLaSemana diaConvertido = (DiasDeLaSemana)3; // diaConvertido será Miércoles
Console.WriteLine($"Día convertido: {diaConvertido}");

// También puede especificar explícitamente los valores constantes asociados, si lo desea.
enum MesesDelAño
{
    Enero = 1,
    Febrero = 2,
    Marzo = 3,
    Abril = 4,
    Mayo = 5,
    Junio = 6,
    Julio = 7,
    Agosto = 8,
    Septiembre = 9,
    Octubre = 10,
    Noviembre = 11,
    Diciembre = 12
}

MesesDelAño mesActual = MesesDelAño.Mayo;
Console.WriteLine($"Mes actual: {mesActual} con valor numérico { (int)mesActual }");

public enum NivelAcceso
{
    Invitado = 1,
    Usuario = 2,
    Administrador = 3
}

NivelAcceso miNivel = NivelAcceso.Administrador;

// 1. Usando .ToString()
string nombreDelNivel = miNivel.ToString(); 

Console.WriteLine(nombreDelNivel); // Salida: Administrador

// Obtener el nombre directamente de la constante del enum
string nombreConstante = nameof(NivelAcceso.Usuario);

Console.WriteLine(nombreConstante); // Salida: Usuario

int valorNumerico = 3; // Corresponde a Administrador

// Obtiene la clave (string) del enum a partir de su tipo y su valor numérico
string nombreObtenido = Enum.GetName(typeof(NivelAcceso), valorNumerico);

Console.WriteLine(nombreObtenido); // Salida: Administrador

```

Este ejemplo se puede crear en otro fichero, por ejemplo `Enums/DiasDeLaSemana.cs`, y luego usarlo en el código principal de la misma manera que con las estructuras importando el espacio de nombres correcto.

```csharp
using Enums; // Asegúrate de usar el espacio de nombres correcto
DiasDeLaSemana hoy = DiasDeLaSemana.Lunes;
Console.WriteLine($"Hoy es: {hoy}");
```
Como hemos dicho, los enums son un conjunto de enteros con alias, por lo que podemos hacer entre otrasc osas, un vector de enteros y asignarles un enum, o a un enum, asignar otro valor que no exista.

```csharp
int[] diasLaborables = { (int)DiasDeLaSemana.Lunes, (int)DiasDeLaSemana.Martes, (int)DiasDeLaSemana.Miércoles, (int)DiasDeLaSemana.Jueves, (int)DiasDeLaSemana.Viernes };

foreach (var dia in diasLaborables)
{
    Console.WriteLine($"Día laborable número: {dia}");
}

DiasDeLaSemana diaNoDefinido = (DiasDeLaSemana)10; // No existe en la definición del enum
Console.WriteLine($"Día no definido: {diaNoDefinido}"); // Salida: Día no definido: 10
```

## 9\. Control de Excepciones

El **Control de Excepciones** es un mecanismo esencial de C\# para gestionar errores inesperados (Excepciones) que interrumpen el flujo normal de ejecución de un programa, como un fallo de conexión o una entrada de datos inválida.

### 9.1. Estructura `try-catch-finally`

La estructura principal para la gestión de errores se divide en tres bloques interrelacionados:

| Bloque C\#    | Propósito                                                                                                                                                 |
| :------------ | :-------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **`try`**     | Contiene el código "de riesgo", donde se espera que pueda ocurrir una excepción.                                                                          |
| **`catch`**   | Contiene la lógica que se ejecuta **solo si** se lanza una excepción en el bloque `try`. Aquí se maneja la recuperación o el registro del error.          |
| **`finally`** | Contiene código que se ejecuta **siempre**, sin importar si hubo o no una excepción. Es ideal para tareas de limpieza (ej. cerrar conexiones o archivos). |

**Sintaxis y Uso Básico:**

```csharp
using System;

try
{
    Console.Write("Introduce un número entero: ");
    string input = Console.ReadLine();
    
    // El método Parse puede lanzar una FormatException si el input no es un número.
    int numero = int.Parse(input); 

    Console.WriteLine($"Número procesado: {numero * 2}");
}
// Captura genérica: Si algo sale mal en el 'try', este bloque lo gestiona.
catch (Exception ex)
{
    Console.WriteLine("¡Error de entrada!");
    Console.WriteLine($"Mensaje de error: {ex.Message}");
}
finally
{
    // Este mensaje se mostrará siempre.
    Console.WriteLine("Proceso de validación finalizado.");
}
```

### 9.2. Captura Múltiple y Específica

C\# permite al programador decidir qué hacer con cada tipo de error. Se utilizan varios bloques `catch` para manejar errores de forma granular.

#### A. Múltiples Bloques `catch`

Se colocan bloques `catch` de específicos a generales. C\# busca el primer bloque que coincida con el tipo de la excepción.

> **Regla Clave:** El bloque **`catch (Exception ex)`** (el más genérico de todos) debe ir **siempre al final**, ya que si se pone primero, capturaría todos los errores e impediría que los bloques específicos sean evaluados.

```csharp
try
{
    // ... Código que genera un error
}
// 1. Captura para problemas de formato (ej. int.Parse("hola"))
catch (FormatException ex) 
{
    Console.WriteLine("Error: El dato no era un número válido.");
}
// 2. Captura para problemas de desbordamiento de memoria
catch (OverflowException ex)
{
    Console.WriteLine("Error: El número es demasiado grande.");
}
// 3. Captura general (el último recurso)
catch (Exception ex) 
{
    Console.WriteLine($"Ocurrió un error inesperado de tipo {ex.GetType().Name}.");
}
```

#### B. Filtros de Excepción (`catch when`)

C\# utiliza la palabra clave **`when`** para añadir una condición lógica al bloque `catch`. Esto es la forma más avanzada de capturar, ya que el bloque solo se ejecuta si se cumplen **ambas condiciones**: el tipo de excepción **y** la condición `when`.

Esto es especialmente útil cuando se necesita **distinguir el origen de una excepción general** (como `ArgumentException`).

##### Propiedad `ex.ParamName`

La propiedad **`ex.ParamName`** está disponible en las clases de error de argumento (`ArgumentException`, `ArgumentNullException`). Esta propiedad contiene la **cadena de texto con el nombre del parámetro** de la función que causó el error, permitiendo al código que captura el error identificar el origen preciso.

**Ejemplo con `throw` y `catch when`:**

```csharp
// Función que lanza ArgumentException
void ProcesarDatos(int cantidad)
{
    // El error se genera aquí
    if (cantidad <= 0)
    {
        // Se lanza la excepción. nameof(cantidad) devuelve la cadena "cantidad"
        // y la asigna a la propiedad ParamName de la excepción.
        throw new ArgumentException("La cantidad debe ser positiva.", nameof(cantidad)); 
    }
    
    // ...
}

try
{
    ProcesarDatos(-10); // Lanza ArgumentException con ParamName = "cantidad"
}
// Este catch solo se ejecuta si es ArgumentException Y si el error vino del parámetro "cantidad"
catch (ArgumentException ex) when (ex.ParamName == "cantidad")
{
    Console.WriteLine($"[FILTRADO ESPECÍFICO] Error de valor detectado en el parámetro '{ex.ParamName}'.");
}
// Este catch atraparía cualquier otra ArgumentException (ej. si viniera de otro parámetro)
catch (ArgumentException ex)
{
    Console.WriteLine($"[CAPTURADO GENÉRICO] Error de argumento en el parámetro '{ex.ParamName}'.");
}
```

### 9.3. Lanzamiento Explícito de Excepciones (`throw`)

La palabra clave **`throw`** se utiliza para que el programador lance una excepción de forma **manual** e **intencional**.

> **IMPORTANTE:** El uso de `throw` **no es obligatorio** en todos los métodos. Solo se utiliza cuando se verifica que se ha violado una regla de negocio y el método no puede continuar.

El `throw` interrumpe inmediatamente el flujo de ejecución y transfiere el control al primer bloque `catch` compatible que se encuentre en la pila de llamadas.

```csharp
// Función que comprueba una condición y lanza el error.
void AsignarDescuento(decimal porcentaje)
{
    if (porcentaje > 1)
    {
        // La ejecución se detiene aquí y se lanza el error.
        throw new ArgumentException("El porcentaje debe ser un valor entre 0 y 1.");
    }
    // ... El código solo continúa si no se lanzó el throw.
}
```

### 9.4. Aserciones (`Debug.Assert`)

Las **Aserciones** son herramientas de desarrollo (no de producción) que verifican condiciones que **nunca deberían ser falsas** si la lógica del código es correcta.

Se utiliza la clase **`Debug`** (requiere `using System.Diagnostics;`).

```csharp
using System.Diagnostics;

void Dividir(int numerador, int denominador)
{
    // Si el denominador es cero (FALLO LÓGICO), el programa se detiene en modo Debug.
    // Esto es para que el desarrollador encuentre el error de lógica.
    Debug.Assert(denominador != 0, "ERROR LÓGICO: El denominador no debe ser cero.");

    int resultado = numerador / denominador;
}
```

> **Diferencia Clave:**
>
>   * **`try-catch`** maneja errores **esperados y recuperables** en cualquier entorno.
>   * **`Debug.Assert`** verifica **fallos de lógica** en el entorno de desarrollo. En producción, el código de `Debug.Assert` se ignora.
>


Absolutamente. Para que los alumnos puedan generar un ejecutable nativo del sistema (un `.exe` en Windows o un binario en Linux/macOS) que se pueda ejecutar directamente, necesitamos usar el comando de publicación, no solo el de compilación.

Aquí tienes el punto 9, ajustado para generar el ejecutable de forma autónoma.

-----

## 10\. Creación, Compilación y Ejecución de Proyectos C\# (NET CLI)

El **.NET CLI** (Command Line Interface) es la herramienta fundamental para trabajar con proyectos C\# desde la terminal. Permite gestionar, compilar y publicar aplicaciones sin depender de un entorno de desarrollo integrado (IDE).

### 10.1. Creación del Proyecto: `dotnet new`

El comando `dotnet new` crea la estructura inicial del proyecto utilizando una plantilla. Para aplicaciones sencillas, usamos la plantilla `console`.

| Comando              | Descripción                                                           |
| :------------------- | :-------------------------------------------------------------------- |
| `dotnet new console` | Crea un nuevo proyecto de aplicación de consola en la carpeta actual. |ç
| `dotnet new console -n MiProyecto` | Crea un nuevo proyecto de consola en una carpeta llamada `MiProyecto`. |

**Pasos para Crear:**

1.  **Crear Carpeta y Navegar:**
    ```bash
    mkdir MiAppConsola
    cd MiAppConsola
    ```
2.  **Generar el Proyecto:**
    ```bash
    dotnet new console
    ```
    Esto genera el archivo de código (`Program.cs`) y el archivo de configuración del proyecto (`MiAppConsola.csproj`).

Otra manera
    de crear el proyecto en una sola línea es:
    
    ```bash
    dotnet new console -n MiAppConsola
    cd MiAppConsola
    ```

### 10.2. Compilación y Ejecución en Desarrollo: `dotnet run`

Durante la fase de codificación, `dotnet run` es el comando más conveniente, ya que **compila el proyecto y lo ejecuta inmediatamente** si detecta cambios.

| Comando      | Descripción                                                                                           |
| :----------- | :---------------------------------------------------------------------------------------------------- |
| `dotnet run` | Compila si es necesario, luego ejecuta la aplicación y muestra la salida directamente en la terminal. |
| `-c <config>` | (Opcional) Especifica la configuración de compilación (`Debug` o `Release`). Por defecto es `Debug`. |


**Ejemplo de Uso:**

```bash
# Estando dentro de la carpeta MiAppConsola/

# 1. Editas tu código en Program.cs
# 2. Ejecutas:
dotnet run
# Esto compila (si hay cambios) y ejecuta la aplicación.
dotnet run -c Release # Para ejecutar la versión optimizada
```

Para pasar argumentos a la aplicación, se usa `--` para separar los argumentos del comando `dotnet run` de los argumentos que se pasan a la aplicación. En el siguiente ejemplo, `arg1` y `arg2` son argumentos que se pasan a la aplicación:

```bash
dotnet run -- arg1 arg2
```

### 10.3. Creación del Ejecutable Nativo: `dotnet publish`

Para generar el archivo ejecutable que se pueda distribuir y ejecutar **directamente en el sistema operativo** (como un `.exe` o un binario autónomo), se utiliza el comando `dotnet publish`.

Este comando genera todos los archivos necesarios en una carpeta de distribución final.

| Comando Clave      | Descripción                                                                                  |
| :----------------- | :------------------------------------------------------------------------------------------- |
| `dotnet publish`   | Prepara la aplicación para su distribución.                                                  |
| `-c Release`       | (Obligatorio) Publica la versión **optimizada** del proyecto, no la de depuración (*Debug*). |
| `-r <runtime_id>`  | **Especifica la plataforma de destino** (ej. `win-x64` o `linux-x64`).                       |
| `--self-contained` | (Opcional, pero recomendado) Incluye el *runtime* .NET, haciendo el binario **autónomo**.    |

**Ejemplo para Generar un Ejecutable para Windows (64-bit):**

```bash
# Estando dentro de la carpeta MiAppConsola/

# Genera un ejecutable autónomo y optimizado para Windows de 64-bit
dotnet publish -c Release -r win-x64 --self-contained
```

**Resultado de la Publicación:**

La aplicación final y todos sus componentes (incluyendo el ejecutable) se guardan en la carpeta:

```bash
/bin/Release/net8.0/win-x64/publish/
```

### 10.4. Ejecución del Ejecutable (Binario Nativo)

Una vez que se ha ejecutado `dotnet publish`, el alumno puede ir a la carpeta de publicación y ejecutar el binario **sin necesidad del .NET CLI**.

1.  **Navegar a la Carpeta de Publicación:**

    ```bash
    cd bin/Release/net8.0/win-x64/publish/
    ```

2.  **Ejecutar el Archivo Nativo:**

      * **En Windows:**
        ```bash
        ./MiAppConsola.exe
        ```
      * **En Linux/macOS:**
        ```bash
        ./MiAppConsola
        ```

De esta forma, el alumno tiene control total sobre la generación de un binario final.

Tienes razón, la complejidad de las etiquetas XMLDoc puede ser abrumadora al principio, y la propiedad `ex.ParamName` a menudo se confunde. Además, en los bloques de código con `///`, el IDE automáticamente inserta algunas etiquetas, por lo que es mejor centrarse en las más comunes y obligatorias.

Voy a repetir el punto 10, simplificándolo para centrarse solo en las etiquetas fundamentales (`<summary>`, `<param>`, `<returns>`) y haciendo los ejemplos más claros.

-----

## 11\. Comentarios y Documentación (XMLDoc)

Los comentarios son líneas de texto que el compilador de C\# ignora. Su propósito es mejorar la **legibilidad** y **documentación** del código fuente para los programadores.

### 11.1. Tipos de Comentarios Básicos

| Tipo            | Sintaxis C\#            | Propósito                                                                      |
| :-------------- | :---------------------- | :----------------------------------------------------------------------------- |
| **Línea Única** | `// Comentario aquí`    | Útil para notas rápidas o deshabilitar temporalmente una sola línea de código. |
| **Bloque**      | `/* Comentario aquí */` | Permite escribir texto en varias líneas sin tener que usar `//` repetidamente. |

```csharp
/* * Este bloque explica que la siguiente
 * variable almacena la versión.
 */
// Versión actual:
int version = 1; 
```

### 11.2. Comentarios de Documentación XML (XMLDoc)

Los **Comentarios de Documentación XML** (o **XMLDoc**) son comentarios especiales que se usan para documentar elementos públicos (métodos, clases, etc.). Se crean usando **tres barras diagonales (`///`)** inmediatamente antes de la declaración del elemento.

#### A. Ventajas Clave

1.  **IntelliSense:** Es la ventaja principal. La documentación se muestra automáticamente en las ventanas de autocompletado y ayuda de los IDEs, facilitando el uso del código.
2.  **Documentación Automática:** Permite al compilador generar un archivo `.xml` que contiene la documentación de la API.

#### B. Etiquetas XMLDoc Fundamentales (Iniciales)

Para empezar con XMLDoc, solo se necesita dominar la etiqueta de resumen y las de la firma del método:

¡Por supuesto! Aquí tienes la tabla fusionada y completa de las etiquetas de **Comentarios de Documentación XML (XMLDoc)** en C\#, que cubren desde los elementos esenciales hasta las etiquetas para metadatos y referencias.

***

## Etiquetas XMLDoc de C\# (Referencia Completa)

Esta tabla resume las etiquetas estándar que se utilizan con las tres barras diagonales (`///`) para generar documentación de API en C\# (IntelliSense).

| Etiqueta                      | Aplicación Típica      | Propósito                                                                                                                                      |
| :---------------------------- | :--------------------- | :--------------------------------------------------------------------------------------------------------------------------------------------- |
| **`<summary>`**               | Métodos, Clases, Tipos | **Obligatoria.** Describe brevemente el propósito del elemento. Aparece primero en IntelliSense.                                               |
| **`<param name="nombre">`**   | Métodos, Constructores | Describe un parámetro de entrada. El atributo `name` debe coincidir con el nombre del parámetro.                                               |
| **`<returns>`**               | Funciones              | Describe el valor o tipo de dato devuelto por la función.                                                                                      |
| **`<exception cref="Tipo">`** | Métodos                | Documenta una excepción específica que el método puede lanzar (ej. `ArgumentException`).                                                       |
| **`<remarks>`**               | General                | Proporciona una explicación detallada, notas de diseño o información adicional importante.                                                     |
| **`<example>`**               | General                | Muestra un fragmento de código que ejemplifica el uso correcto del elemento documentado.                                                       |
| **`<see cref="Tipo"/>`**      | General                | Crea un enlace interno a otro tipo, método o miembro del código (referencia cruzada).                                                          |
| **`<seealso cref="Tipo"/>`**  | General                | Indica temas o elementos relacionados que el usuario debería consultar para más contexto.                                                      |
| **`<c>`**                     | General                | Formatea texto dentro de la documentación como **código en línea** (útil para nombres de variables o funciones cortas, ej. `<c>contador</c>`). |

**Ejemplo de XMLDoc Simple y Clara:**

```csharp
/// <summary>
/// Calcula el impuesto IVA que se debe aplicar a un producto.
/// </summary>
/// <param name="precioBase">El precio original del producto sin impuesto.</param>
/// <param name="tasaIVA">El porcentaje de IVA a aplicar (ej. 0.21 para 21%).</param>
/// <returns>El valor total del IVA a pagar.</returns>
/// <exception cref="ArgumentException">Lanzada si la <paramref name="tasaIVA"/> es negativa.</exception>
double CalcularIVA(double precioBase, double tasaIVA)
{
    // Verificación de la regla de negocio: el IVA no puede ser negativo.
    if (tasaIVA < 0)
    {
        // Se lanza la excepción, usando nameof(tasaIVA) para indicar el parámetro erróneo.
        throw new ArgumentException("La tasa de IVA no puede ser un valor negativo.", nameof(tasaIVA));
    }
    
    return precioBase * tasaIVA;
}
```

## 12\. Convenciones de Nomenclatura (Naming Conventions)

C\# utiliza convenciones de nomenclatura estrictas para mejorar la legibilidad y la coherencia del código en proyectos grandes. Es vital seguir los estándares de .NET.

### 12.1. Estilos de Capitalización en C\#

En C\#, dos estilos de capitalización dominan la nomenclatura:

| Convención       | Estilo                                                                                | Uso Principal                                              | Ejemplo                                     |
| :--------------- | :------------------------------------------------------------------------------------ | :--------------------------------------------------------- | :------------------------------------------ |
| **`camelCase`**  | La primera letra es **minúscula**, y las siguientes palabras comienzan con mayúscula. | **Variables locales**, argumentos de métodos (parámetros). | `nombreUsuario`, `tasaInteres`              |
| **`PascalCase`** | La primera letra de **todas las palabras** es mayúscula.                              | **Métodos**, **Constantes**, **Enumeraciones**, Clases.    | `CalcularTotal`, `MaxVidas`, `TipoVehiculo` |

-----

### 12.2. Nomenclatura de Elementos por Tipo

#### A. Variables Locales y Parámetros (`camelCase`)

Se utiliza `camelCase` para variables declaradas dentro de un bloque de código y para los parámetros que recibe un método.

```csharp
// camelCase para el parámetro (costo) y la variable local (costoFinal)
double AplicarImpuesto(double costo) 
{
    const double TASA_IVA = 0.21; // TasaIVA usa PascalCase
    double costoFinal = costo * (1 + TASA_IVA);
    return costoFinal;
}
```

#### B. Métodos, Constantes y `readonly` (`PascalCase`)

En C\#, todos estos elementos usan **`PascalCase`** para distinguirlos de las variables locales.

1.  **Métodos / Funciones:** Siempre usan `PascalCase`. Deben comenzar con un verbo para indicar acción (ej. `Obtener`, `Guardar`, `Validar`).
2.  **Constantes (`const`):** En C\#, deben usar **`PascalCase`** (ej. `TasaMaxima`, no `TASA_MAXIMA`). Esto las alinea con el resto de miembros públicos.
3.  **Campos de Solo Lectura (`readonly`):** Se nombran con `PascalCase`. Representan valores que se establecen una vez (normalmente en la inicialización) y no cambian después.

<!-- end list -->

```csharp
// PascalCase para la constante
const int MaxIntentosLogin = 3; 

// PascalCase para el campo de solo lectura
readonly string VersionAplicacion = "2.0";

// PascalCase para el método
void ReiniciarTemporizador() 
{
    // ...
}
```

#### C. Enumeraciones (`enum`) y sus Miembros (`PascalCase`)

Tanto el tipo `enum` como cada uno de los valores definidos dentro de él deben seguir la convención **`PascalCase`**.

```csharp
// El tipo y sus miembros usan PascalCase
enum EstadoPedido 
{
    Pendiente, 
    EnProceso,
    Enviado,
    Entregado
}
```

#### D. Variables Booleanas y Preguntas (`is`, `has`, `can`)

Las variables de tipo `bool` deben nombrarse con un prefijo que exprese un estado o una habilidad (un predicado), haciendo que el código sea más legible en las condiciones. Los prefijos se usan en **`camelCase`**.

| Prefijo   | Significado        | Ejemplo C\#                  | Lectura en Código  |
| :-------- | :----------------- | :--------------------------- | :----------------- |
| **`is`**  | Es (Estado actual) | `isValido`, `isActivo`       | `if (isActivo)`    |
| **`has`** | Tiene (Posesión)   | `hasErrores`, `hasDatos`     | `if (hasDatos)`    |
| **`can`** | Puede (Habilidad)  | `canEscribir`, `canConectar` | `if (canConectar)` |


#### E. Tuplas (`PascalCase`)
Las tuplas son estructuras de datos ligeras que agrupan varios valores. Los nombres de los elementos dentro de una tupla deben usar **`PascalCase`** para mantener la coherencia con otros tipos.

```csharp
var persona = (Nombre: "Juan", Edad: 30, Ciudad: "Madrid");

// Acceso a los elementos de la tupla
Console.WriteLine($"Nombre: {persona.Nombre}, Edad: {persona.Edad}, Ciudad: {persona.Ciudad}");
 
(int Suma, int Producto) RealizarCalculos(int a, int b)
{
    // El 'return' agrupa los valores en el orden definido.
    return (a + b, a * b);
}
var resultados = RealizarCalculos(5, 10);
Console.WriteLine($"Suma: {resultados.Suma}, Producto: {resultados.Producto}");
```



### 12.3. Recomendaciones Adicionales

1.  **Claridad antes que Concisión:** Utiliza nombres completos y descriptivos. Evita las abreviaturas crípticas (ej. `cuentaCliente` en lugar de `cClte`).
2.  **Uso de `var`:** Aunque `var` permite al compilador inferir el tipo, la variable resultante debe seguir las reglas de nomenclatura local (`camelCase`).
3.  **Singular y Plural:** Usa nombres singulares para elementos individuales (`cliente`) y plurales para colecciones de elementos (`clientes`).
4.  **Consistencia:** Mantén un estilo uniforme en todo el proyecto para facilitar la lectura y el mantenimiento del código.
5.  **Evita Prefijos y Sufijos Innecesarios:** No uses prefijos como `m_` o `s_` para campos o variables. En C\#, la convención de nomenclatura ya es suficiente para distinguir los tipos de elementos.
6.  **Nombres de Espacios de Nombres (Namespaces):** Utiliza `PascalCase` y sigue la convención de usar el nombre de la empresa o proyecto seguido del módulo o funcionalidad (ej. `MiEmpresa.MiProyecto.Modulo`).

## 13. Librerías
Las **Librerías** en C\# son colecciones de código precompilado que proporcionan funcionalidades reutilizables para los desarrolladores. Estas librerías pueden ser parte del framework .NET, de terceros o creadas por el propio desarrollador.

### 13.1. Configuración de NuGet en Proyectos C\#
Para utilizar librerías externas en un proyecto C\#, es común usar **NuGet**, el gestor de paquetes oficial para .NET. NuGet facilita la búsqueda, instalación y gestión de librerías de terceros.

Para ello en debes haber configurado antes el fichero de configuración de NuGet, llamado `NuGet.config`. Este archivo define las fuentes de paquetes desde donde se descargarán las librerías. Este fichero está en tu carpeta de usuario, por ejemplo en Windows en `C:\Users\TuUsuario\AppData\Roaming\NuGet\nuget.config`. Aquí tienes un ejemplo básico de cómo debería verse este archivo:
```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" protocolVersion="3" />
    </packageSources>
</configuration>
```

### 13.2. Uso de NuGet para Gestionar Librerías
**NuGet** es el gestor de paquetes oficial para .NET. Permite a los desarrolladores buscar, instalar y gestionar librerías de terceros fácilmente.
Para configurar NuGet en tu proyecto, sigue estos pasos:
**Crear un Proyecto:** Si aún no tienes un proyecto, crea uno usando el comando:

    ```bash
    dotnet new console -n MiProyecto
    cd MiProyecto
    ```

Desde la consola:
**Agregar un Paquete NuGet:** Usa el comando `dotnet add package` para instalar una librería. Por ejemplo, para agregar la librería `Serilog.Sinks.Console`, ejecuta:

    ```bash
    dotnet add package Serilog.Sinks.Console
    ```

Desde JetBrains Rider:
**Explorar y Agregar Paquetes:** Abre el proyecto en Rider, ve a la sección de NuGet en la configuración del proyecto, busca la librería que deseas y agrégala directamente desde la interfaz gráfica.


**Restaurar Paquetes:** Si has clonado un proyecto que ya tiene paquetes NuGet, restaura los paquetes usando:

    ```bash
    dotnet restore
    ```

O desde JetBrains Rider, simplemente abre el proyecto y Rider detectará automáticamente los paquetes faltantes y te ofrecerá restaurarlos.

## 14. Logger
El **Logger** es una herramienta esencial en el desarrollo de software que permite registrar eventos, errores y otra información relevante durante la ejecución de una aplicación. En C\#, existen varias librerías populares para implementar logging, la propia de Microsoft o la de **Serilog** una de las más utilizadas debido a su flexibilidad y facilidad de uso.

### 14.1. Configuración Básica de Serilog
Para configurar Serilog en tu proyecto C\#, sigue estos pasos:
1.  **Agregar Paquetes NuGet:** Asegúrate de tener los paquetes necesarios instalados. Puedes agregar Serilog y un sink (destino) para la consola usando los siguientes comandos:

    ```bash
    dotnet add package Serilog
    dotnet add package Serilog.Sinks.Console
    ```
2.  **Configurar Serilog en el Código:** En tu archivo `Program.cs`, configura Serilog para que registre mensajes en la consola.

    ```csharp
    using Serilog;
    Log = new LoggerConfiguration().WriteTo.Console().CreateLogger();
    Log.Information("Aplicación iniciada.");
    try
    {
        // Código de la aplicación
        Log.Information("Ejecutando la aplicación...");
    }
    catch (Exception ex)
    {
        Log.Error(ex, "Ocurrió un error inesperado.");
    }
    finally
    {
        Log.Information("Aplicación finalizada.");
    }
    ```

### 14.2. Uso de Niveles de Log
Serilog soporta varios niveles de log que permiten categorizar la importancia de los mensajes registrados. Los niveles comunes incluyen:
| Nivel        | Descripción                                                                                   |
| :----------- | :-------------------------------------------------------------------------------------------- |
| **Verbose**  | Mensajes detallados para diagnóstico.                                                        |
| **Debug**    | Información útil para depuración.                                                            |
| **Information** | Mensajes informativos sobre el estado de la aplicación.                                   |
| **Warning**  | Advertencias sobre situaciones potencialmente problemáticas.                                 |
| **Error**    | Errores que impiden el funcionamiento normal de la aplicación.                              |
| **Fatal**    | Errores críticos que requieren atención inmediata.                                          |


## 15\. Consola Avanzada. Spectre
**Spectre.Console** es una librería de C\# que permite crear aplicaciones de consola enriquecidas con características avanzadas como propts, tablas, gráficos, colores y más. Es ideal para mejorar la experiencia del usuario en aplicaciones de línea de comandos. Su url oficial es: [https://spectreconsole.net/](https://spectreconsole.net/)

### 15.1. Instalación de Spectre.Console
Para utilizar Spectre.Console en tu proyecto C\#, primero debes agregar el paquete NuGet correspondiente. Puedes hacerlo desde la consola con el siguiente comando:

```bash
dotnet add package Spectre.Console
```

Luego, en tu código, puedes comenzar a usar las funcionalidades de Spectre.Console importando el espacio de nombres:

```csharp
using Spectre.Console;
// Ejemplo básico de uso de Spectre.Console
AnsiConsole.MarkupLine("[bold green]¡Hola, Spectre.Console![/]");
```

### 15.2. Uso de colores y estilos
Spectre.Console permite aplicar colores y estilos fácilmente en la consola utilizando la sintaxis de marcado (markup). Aquí tienes algunos ejemplos:

```csharp
using Spectre.Console;
AnsiConsole.MarkupLine("[red]Texto en rojo[/]");
AnsiConsole.MarkupLine("[bold blue]Texto en azul y negrita[/]");
AnsiConsole.MarkupLine("[underline yellow]Texto subrayado en amarillo[/]");
// Si solo queremos un write
AnsiConsole.Markup("[green]Texto verde sin salto de línea[/]");

// Texto en negrita cursiva y subrayado en fondo rojo y letras amarillas
AnsiConsole.MarkupLine("[bold italic underline yellow on red]Texto estilizado[/]");
```

### 15.3. Uso de tablas
Spectre.Console facilita la creación de tablas para organizar y presentar datos de manera estructurada en la consola. Aquí tienes un ejemplo de cómo crear y mostrar una tabla:

```csharp
using Spectre.Console;
var table = new Table();
table.AddColumn("Nombre");
table.AddColumn("Edad");
table.AddColumn("Ciudad");
table.AddRow("Juan", "30", "Madrid");
table.AddRow("María", "25", "Barcelona");
table.AddRow("Luis", "28", "Valencia");
AnsiConsole.Write(table);
```

Nos dara una salida como esta:

```
┌───────┬─────┬───────────┐
│ Nombre│ Edad│ Ciudad    │
├───────┼─────┼───────────┤
│ Juan  │ 30  │ Madrid    │
│ María │ 25  │ Barcelona │
│ Luis  │ 28  │ Valencia  │
└───────┴─────┴───────────┘
```

### 15.4. Uso de prompts de entrada
Spectre.Console también ofrece funcionalidades para crear prompts interactivos que permiten a los usuarios ingresar datos de manera sencilla. Aquí tienes un ejemplo de cómo utilizar un prompt para solicitar al usuario su nombre:

```csharp
using Spectre.Console;
// Crear un prompt para solicitar el nombre del usuario
var nombre = AnsiConsole.Prompt(
    new TextPrompt<string>("¿Cuál es tu [green]nombre[/]?") // Pregunta con estilo devuelve un string
        .PromptStyle("cyan")
        .ValidationErrorMessage("[red]Por favor, ingresa un nombre válido.[/]") // Mensaje de error personalizado si no es válido
        .Validate(name => !string.IsNullOrWhiteSpace(name)) // Validación para que no esté vacío, puede ser un regex o cualquier otra condición
);

// Propmpt para solicitar la edad del usuario y debe ser entre 10 y 90
var edad = AnsiConsole.Prompt(
    new TextPrompt<int>("¿Cuál es tu [green]edad[/]?") // Pregunta con estilo devuelve un int
        .PromptStyle("cyan")
        .ValidationErrorMessage("[red]Por favor, ingresa una edad válida entre 10 y 90.[/]") // Mensaje de error personalizado si no es válido
        .Validate(age => age >= 10 && age <= 90) // Validación para que esté entre 10 y 90
);

// propmt para seleccionar una opción de una lista
var colorFavorito = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("Selecciona tu [green]color favorito[/]:")
        .PageSize(10)
        .AddChoices(new[] { "Rojo", "Verde", "Azul", "Amarillo", "Negro" })
);

// propt de un booleano (sí/no)
var aceptaTerminos = AnsiConsole.Prompt(
    new ConfirmationPrompt("¿Aceptas los [green]términos y condiciones[/]?")
        .DefaultValue(false) // Valor por defecto si el usuario solo presiona Enter
);

// propt con validacion de un regex
var email = AnsiConsole.Prompt(
    new TextPrompt<string>("¿Cuál es tu [green]correo electrónico[/]?") // Pregunta con estilo devuelve un string
        .PromptStyle("cyan")
        .ValidationErrorMessage("[red]Por favor, ingresa un correo electrónico válido.[/]") // Mensaje de error personalizado si no es válido
        .Validate(mail => Regex.IsMatch(mail, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) // Validación con regex para formato de email
);
```

### 15.5. Calendarios
Spectre.Console permite mostrar calendarios en la consola, lo que puede ser útil para aplicaciones que requieren selección de fechas o visualización de eventos. Aquí tienes un ejemplo básico de cómo mostrar un calendario:

```csharp
using Spectre.Console;
var calendar = new Calendar(DateTime.Now.Year, DateTime.Now.Month); // Crea un calendario para el mes y año actuales
calendar.Culture("es-ES"); // Configura el idioma a español
calendar.HeaderStyle(Style.Parse("blue bold")); // Estilo del encabezado
AnsiConsole.Write(calendar); // Muestra el calendario en la consola
```
### 15.6. Barras de Progreso
Spectre.Console facilita la creación de barras de progreso para indicar el avance de tareas largas. Aquí tienes un ejemplo de cómo implementar una barra de progreso:

```csharp
using Spectre.Console;

AnsiConsole.Progress()
    .AutoClear(false) // Mantiene la barra de progreso visible después de completar (opcional)
    .Columns(new ProgressColumn[]
    {
        new TaskDescriptionColumn(), // Descripción de la tarea
        new ProgressBarColumn(),       // Barra de progreso visual
        new PercentageColumn(),         // Porcentaje completado
        new RemainingTimeColumn(),     // Tiempo restante estimado
    })
    .Start(ctx =>
    {
        var task = ctx.AddTask("Procesando datos...", maxValue: 100);
        Procesar34Veces(task);
    });

void Procesar34Veces(ProgressTask task)
{
    int totalIteraciones = 34;
    double incremento = task.MaxValue / totalIteraciones;

    for (int i = 0; i < totalIteraciones; i++)
    {
        // Aquí va tu proceso real
        Thread.Sleep(200); // Simula trabajo

        task.Increment(incremento);
    }

    // Asegurar que termina redondo al 100%
    task.Value = task.MaxValue;
}

```

### 15.7. Emogis y Símbolos
Spectre.Console soporta el uso de emojis y símbolos para mejorar la apariencia visual de las aplicaciones de consola. Puedes consultar la [documentación oficial](https://spectreconsole.net/appendix/emojis) para obtener más información. Aquí tienes un ejemplo de cómo utilizar emojis en tus mensajes:

```csharp
using Spectre.Console;

Emoji.Remap("globe_showing_europe_africa", "😄"); // Remap 

// Podemos usarlo con : y sabiendo su código
AnsiConsole.MarkupLine("Hello :globe_showing_europe_africa:!");

// Podemos Reemplazar emojis en un string
var phrase = "Hello :globe_showing_europe_africa:!";
var rendered = Emoji.Replace(phrase);
AnsiConsole.MarkupLine(rendered);
```

## 16. DAW'S Template

Vamos a crear una plantilla de estructuración de Programas usando C\# que siga las mejores prácticas vistas en los puntos anteriores. Esta plantilla servirá como base para futuros proyectos, asegurando consistencia y calidad en el código.

```csharp
// DAW'S Template - Plantilla Base para Proyectos en C#
using System;


// Configurar el logger estático: Nivel mínimo Debug y salida a la consola con template.
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug() // Permitir mensajes Debug y superiores
    .WriteTo.Console() // Salida a consola
    .CreateLogger(); // Utilizamos Serilog para el logging


// Configuración de consola y Encoding
Console.Title = "Bases de Datos Alumnado con Arrays Estáticos en C#";
Console.OutputEncoding = Encoding.UTF8;
Console.Clear();

// Constantes y variables globales (Justificadas)
const int TamanoInicial = 10;
// Expresión regular para validar nombres: letras, acentos, ñ, espacios, mínimo 3 caracteres.
const string RegexNombre = @"^[A-Za-zñÑáéíóúÁÉÍÓÚ\s]{3,}$";
// Formato de cultura para España (números con coma decimal y monedas o fechas locales)
CultureInfo localeEs = CultureInfo.GetCultureInfo("es-ES");
// Numeros aleatorios
Random random = Random.Shared;

// otras que puedas necesitar

// Programa principal
Main(args);

// Limpieza de logs y salida
Log.CloseAndFlush(); // Asegura que todos los logs pendientes se escriban.
Console.WriteLine("\n⌨️ Presiona una tecla para salir...");
Console.ReadKey();

// Programa principal
void Main(string[] args) {
    // Variables locales
    int resultado = 0;
    resultado = Sumar(5, 10);
    Console.WriteLine($"El resultado de la suma es: {resultado}");
}

// Metodos auxiliares
int Sumar(int a, int b) {
    Log.Debug("Sumando {A} + {B}", a, b);
    return a + b;
}
```