
### **Ejercicio: Compresión y descompresión de arrays**

Se pide implementar dos funciones para trabajar con arrays de números enteros (`int[]`):

1. **Comprimir(array)**
   Esta función recibe un array de números y devuelve otro array donde las secuencias de números iguales se reemplazan por **dos valores** consecutivos:

   * El **número de veces** que se repite el valor consecutivamente.
   * El **valor** que se repite.

   **Ejemplos de compresión:**

   * Array básico

     ```
     Entrada:    0, 1, 2, 3, 4, 5
     Comprimido: 1,0,1,1,1,2,1,3,1,4,1,5
     ```
   * Array con repeticiones

     ```
     Entrada:    7,7,7,8,8
     Comprimido: 3,7,2,8
     ```
   * Array con un solo elemento

     ```
     Entrada:    10
     Comprimido: 1,10
     ```
   * Array con muchos elementos iguales (p.ej., 255 veces el número 5)

     ```
     Entrada:    5,5,5,... (255 veces)
     Comprimido: 255,5
     ```

2. **Descomprimir(array)**
   Esta función recibe un array previamente comprimido con la técnica anterior y devuelve el **array original**, restaurando todos los valores en el orden original.

   **Ejemplos de descompresión:**

   * Array comprimido básico

     ```
     Comprimido: 1,0,1,1,1,2,1,3,1,4,1,5
     Descomprimido: 0,1,2,3,4,5
     ```
   * Array comprimido con repeticiones

     ```
     Comprimido: 3,7,2,8
     Descomprimido: 7,7,7,8,8
     ```
   * Array comprimido con un solo elemento

     ```
     Comprimido: 1,10
     Descomprimido: 10
     ```
   * Array comprimido con muchos elementos iguales

     ```
     Comprimido: 255,5
     Descomprimido: 5,5,5,... (255 veces)
     ```
---