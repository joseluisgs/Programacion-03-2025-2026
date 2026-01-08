# Práctica CINE-DAW: Gestión Modular de Sala de Cine

- [Práctica CINE-DAW: Gestión Modular de Sala de Cine](#práctica-cine-daw-gestión-modular-de-sala-de-cine)
  - [1. Configuración Inicial y Constantes](#1-configuración-inicial-y-constantes)
    - [1.1. Parámetros de la Sala y Validación](#11-parámetros-de-la-sala-y-validación)
    - [1.2. Requisitos de Información de una Butaca](#12-requisitos-de-información-de-una-butaca)
  - [2. Requisitos funcionales, no funcionales y de información](#2-requisitos-funcionales-no-funcionales-y-de-información)
    - [2.1. Sistema de Coordenadas y Visualización](#21-sistema-de-coordenadas-y-visualización)
    - [2.2. Entrada de Coordenadas](#22-entrada-de-coordenadas)
  - [3. Requisitos Funcionales del Menú Principal](#3-requisitos-funcionales-del-menú-principal)
  - [4. Requisitos de Información del Informe](#4-requisitos-de-información-del-informe)


El objetivo es implementar un programa que gestione una sala de cine mediante matrices, enfocándose en la **robustez de la interfaz** a través de la consola. El programa debe garantizar la integridad de los datos validando estrictamente todas las entradas del usuario.

## 1\. Configuración Inicial y Constantes

### 1.1. Parámetros de la Sala y Validación

La dimensión de la sala (`Filas:Columnas`) **debe intentarse leer primero** de los argumentos de línea de comandos.

  * Si los argumentos faltan o son inválidos, el programa debe iniciar un **bucle de solicitud en la consola** hasta obtener datos correctos.

| Parámetro        | Rango de Validación    | Formato de Validación                                           |
| :--------------- | :--------------------- | :-------------------------------------------------------------- |
| **Filas (F)**    | Entero entre **4 y 7** | El sistema debe identificar el número antes del separador `:`   |
| **Columnas (C)** | Entero entre **5 y 9** | El sistema debe identificar el número después del separador `:` |

**Interacción Inicial (Manejo de Errores):**

El programa debe gestionar la falta de argumentos o el formato incorrecto con mensajes claros y reintentar la solicitud.

| Flujo de Uso                   | Entrada del Usuario               | Salida Esperada del Sistema                                                                                                                                                                                   |
| :----------------------------- | :-------------------------------- | :------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| **Inicio (Argumentos Faltan)** | *(El usuario no pasa argumentos)* | `Bienvenido a CINEMAD.` `ERROR: Faltan argumentos. Formato de ejecución: -filas:X -columnas:Y` `--- Modo Consola de Respaldo ---` `Introduzca las dimensiones de la sala (F:C). Rango permitido: [4-7]:[5-9]` |
| **Error de Formato (Consola)** | `8,5`                             | `ERROR: Formato inválido. Use F:C. Ejemplo: 6:9` ` Introduzca de nuevo las dimensiones:  `                                                                                                                    |
| **Error de Rango (Consola)**   | `3:5`                             | `ERROR: Rango inválido. Filas: [4-7], Columnas: [5-9].` ` Introduzca de nuevo las dimensiones:  `                                                                                                             |
| **Éxito (Consola)**            | `5:8`                             | `Sala configurada: 5 filas x 8 columnas.` `Iniciando simulación...`                                                                                                                                           |

### 1.2. Requisitos de Información de una Butaca

La matriz de la sala utiliza tres estados y un precio fijo. Al iniciar, la sala debe estar `Libre`, con **1 a 3 butacas** elegidas **aleatoriamente** como `Fuera Servicio`.

| Concepto           | Representación Interna | Símbolo de Impresión | Valor     |
| :----------------- | :--------------------- | :------------------- | :-------- |
| **Libre**          | (Valor entero 0)       | **`[🟢]`**            | N/A       |
| **Ocupada**        | (Valor entero 1)       | **`[🔴]`**            | N/A       |
| **Fuera Servicio** | (Valor entero 2)       | **`[🚫]`**            | N/A       |
| **Precio**         | (Valor decimal fijo)   | N/A                  | **6,50€** |

-----

## 2\. Requisitos funcionales, no funcionales y de información

### 2.1. Sistema de Coordenadas y Visualización

La sala debe mostrarse con coordenadas **Mixtas**: **Filas con Letras** (A, B, C...) y **Columnas con Números** (1, 2, 3...).

**Salida Requerida (`Ver el estado de la sala`):**

```
    1   2   3   4   5
A  [🟢] [🟢] [🔴] [🟢] [🟢]
B  [🚫] [🟢] [🟢] [🟢] [🔴]
C  [🟢] [🟢] [🔴] [🚫] [🟢]
```

### 2.2. Entrada de Coordenadas

Las operaciones de `Comprar` y `Devolver` deben solicitar la coordenada en el formato **`Letra:Numero`**.

**Validación:** El programa debe validar tanto el **formato** (`Letra:Número`) como el **rango** (que la coordenada exista en la sala) en un bucle de reintento.

**Interacción de Coordenadas (Manejo de Errores):**

| Flujo de Compra/Devolución | Entrada del Usuario | Salida Esperada del Sistema                                                                |
| :------------------------- | :------------------ | :----------------------------------------------------------------------------------------- |
| **Solicitud**              | `2` (Comprar)       | ` Introduzca butaca (ej. A:5):  `                                                          |
| **Error de Formato**       | `A-5`               | `ERROR: Formato incorrecto. Use LETRA:NUMERO (ej. C:4).` ` Introduzca butaca (ej. A:5):  ` |
| **Error de Límite**        | `Z:9`               | `ERROR: Coordenada fuera de los límites de la sala.` ` Introduzca butaca (ej. A:5):  `     |
| **Éxito**                  | `B:3`               | *(El programa procede a procesar la butaca B:3)*                                           |

-----

## 3\. Requisitos Funcionales del Menú Principal

El programa debe operar con el siguiente menú en un bucle principal:

| Opción | Título del Menú  | Requerimiento Funcional                           | Mensajes de Éxito y Fallo                                                                                                                |
| :----- | :--------------- | :------------------------------------------------ | :--------------------------------------------------------------------------------------------------------------------------------------- |
| **1**  | Ver Sala         | Mostrar la matriz de la sala.                     | N/A                                                                                                                                      |
| **2**  | Comprar Entrada  | Solicitar coordenada. Cambiar estado a `Ocupada`. | **Éxito:** `Butaca A:3 comprada con éxito. Precio: 6.50€.` **Fallo:** `ERROR: La butaca A:3 ya está OCUPADA o FUERA DE SERVICIO.`        |
| **3**  | Devolver Entrada | Solicitar coordenada. Cambiar estado a `Libre`.   | **Éxito:** `Devolución completada. Butaca B:1 ahora está LIBRE.` **Fallo:** `ERROR: La butaca B:1 no puede devolverse. No está OCUPADA.` |
| **4**  | Recaudación      | Calcular y mostrar solo el total de dinero.       | `RECAUDACIÓN ACTUAL: XX entradas * 6.50€ = XXX.XX€`                                                                                      |
| **5**  | Informe          | Mostrar todas las estadísticas (Sección 4).       | Ver **Salida del Informe** abajo.                                                                                                        |
| **6**  | Salir            | Terminar la ejecución del programa.               | `Gracias por usar CINEMAD. ¡Hasta pronto!`                                                                                               |

-----

## 4\. Requisitos de Información del Informe

La función de informe (Opción 5) debe calcular y mostrar las siguientes estadísticas:

| Estadística                 | Criterio de Cálculo                                                                                    |
| :-------------------------- | :----------------------------------------------------------------------------------------------------- |
| **Entradas Vendidas**       | Número de butacas `Ocupada`.                                                                           |
| **Asientos Libres**         | Número de butacas `Libre`.                                                                             |
| **Asientos No Disponibles** | Número de butacas `Fuera Servicio`.                                                                    |
| **Total Recaudado**         | `Vendidas` x **6,50€**                                                                                 |
| **Porcentaje de Ocupación** | `(Vendidas / Total de Asientos Disponibles) * 100`. (Asientos Disponibles = Total - `Fuera Servicio`). |

**Salida Requerida del Informe (Opción 5):**

```
--- INFORME CINEMAD ---
Entradas Vendidas: 5
Asientos Libres: 18
Asientos No Disponibles (F/S): 2
Ocupación: 21.74% (sobre 23 asientos disponibles)
Recaudación Total: 32.50€
```