# 🧟‍♂️ The Walking DAW: La Amenaza del Virus Prog-JL 💻

## 📜 Historia: El Último Cierre de Paréntesis

El año es 2025. El IES Luis Vives era un faro de conocimiento, hasta que un error de compilación fatal liberó el **Virus
Prog-JL**. No es un virus de la gripe, ni un *malware* común. Es una pesadilla biológica que se propaga por la
superficie del instituto, transformando a profesores y alumnos en lo que ahora conocemos como **Zombies del Código (ZC)
**, con una sed insaciable por código limpio y mentes sin compilar.

**Tú eres el último programador sano.** Tu misión: ejecutar la simulación que predecirá el destino del instituto y de la
humanidad. El campo de batalla es la **Matriz del Instituto**, donde cada celda es un aula, un pasillo o una mente en
peligro.

**¿Podrás compilar el futuro antes de que se corrompa por completo?**

-----

## ⚙️ La Simulación: Prediciendo el Fin (o la Salvación)

El programa simulará la propagación del Virus Prog-JL a lo largo de ciclos de tiempo definidos por el usuario. La Matriz
del Instituto se compone de celdas que pueden estar en uno de tres estados:

* **🧟 Zombie del Código (ZC)**
* **🙂 Persona Sana (Alumno/Profesor)**
* **◻️ Zona Libre (Espacio/Vacío)**

### 🔴 Reglas de los Zombies del Código (ZC)

Los ZC (personas infectadas) siguen estas reglas en cada ciclo:

1. **☠️ Probabilidad de Muerte (`muerte:X`):** Cada ZC tiene una probabilidad del **X%** de morir por inanición (o un
   error de sintaxis fatal) y desaparecer, dejando la celda **Zona Libre**.
2. **🏃 Movimiento Adyacente:** Si sobrevive, un ZC intentará moverse a **una de las 8 zonas adyacentes** elegida al
   azar, **solo si está Libre**. Si no hay Zonas Libres alrededor, el ZC permanece quieto.
3. **🧟Contagio: (`contagio:C`): ** Después de moverse (o quedarse quieto), el ZC intenta infectar a sus vecinos sanos.
   Si hay una **Persona Sana** adyacente, esta tiene una probabilidad del **C%** de ser infectada y convertirse en ZC en
   el siguiente ciclo.

### 🟢 Reglas de las Personas Sanas (Alumnos/Profesores)

Las personas sanas también luchan por sobrevivir y defenderse:

1. **🏃 Movimiento Adyacente:** Las **Personas Sanas** buscan moverse a **una de las 8 zonas adyacentes** elegida al
   azar, **solo si está Libre** en el siguiente estado. Si no tienen donde ir, permanecen quietas.
2. **⚔️ Defensa y Asesinato (`matar:K`):** Si una Persona Sana tiene uno o más ZC adyacentes, intentará combatirlos.
   Tiene una probabilidad del **K%** de matar a **un ZC vecino** (elegido al azar), dejando la zona de ese ZC **Libre**.
   Si la defensa es exitosa, la persona sana permanece en su posición.

-----

## ⌨️ Ejecución: Compila tu Destino

Para iniciar la simulación, debes ejecutar el programa (`Simulador.exe`) desde la línea de comandos, definiendo las
condiciones iniciales de la simulación.

**Sintaxis requerida para la ejecución:**

```bash
.\Simulador.exe dimension:X infectados:Y sanos:Z contagio:C tiempo:T muerte:M matar:K
```

| Parámetro        | Clave        | Rango   | Descripción                                             |
|:-----------------|:-------------|:--------|:--------------------------------------------------------|
| **Dimensión**    | `dimension`  | `> 0`   | Tamaño de la matriz (e.g., `dimension:40` para 40x40).  |
| **Infectados**   | `infectados` | `≥ 0`   | Número inicial de **Zombies del Código (ZC)**.          |
| **Sanos**        | `sanos`      | `≥ 0`   | Número inicial de **Personas Sanas**.                   |
| **Contagio**     | `contagio`   | `0-100` | Probabilidad (%) de infección por ZC.                   |
| **Tiempo**       | `tiempo`     | `> 0`   | Ciclos máximos de la simulación.                        |
| **Muerte ZC**    | `muerte`     | `0-100` | Probabilidad (%) de que un ZC muera por ciclo.          |
| **Matanza Sano** | `matar`      | `0-100` | Probabilidad (%) de que un sano mate a un ZC adyacente. |

### Ejemplo Épico de Llamada:

```bash
.\Simulador.exe dimension:40 infectados:10 sanos:300 contagio:35 tiempo:100 muerte:15 matar:5
```

> **¡El destino del IES Luis Vives está en tus manos. Que tu código sea fuerte y tus probabilidades de supervivencia
altas\!**

