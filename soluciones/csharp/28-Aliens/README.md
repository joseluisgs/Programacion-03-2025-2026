# 🌌 Planeta Null: La Rebelión del Prog-JL 🛸

## 📜 Historia: Los Aliens del Código Corrupto

En la lejana galaxia de **Null**, un error crítico ha desatado el caos. Un escuadrón de **Aliens del Código (AC)** ha invadido este universo de **5x5 sectores de memoria**, buscando corromper todos los procesos y causar un **fatal `NullPointerException` galáctico**.

**Tú eres el último Guerrero Digital de Prog-JL.** Armado con tu **Blaster de Sintaxis**, debes defender Null, eliminar los AC y mantener tu memoria intacta. Cada sector de la matriz espacial representa una celda de memoria y puede estar en uno de estos estados:

* **👾 Alien del Código (AC)**
* **🛡️ Guerrero Digital (GD)**
* **◻️ Sector Libre (Memoria Disponible)**

Cada ciclo de ejecución es crucial: cada decisión de programación puede salvar o destruir la galaxia.

---

## ⚙️ Reglas de la Simulación Prog-JL

### 👾 Aliens del Código

1. **💻 Movimiento Aleatorio:** Cada **2 segundos**, los AC intentan moverse a una de las **8 celdas adyacentes** libres, como si ejecutaran un `foreach` buscando memoria disponible.
2. **🔁 Intentos Limitados:** Cada AC tiene **16 intentos** por ciclo para encontrar una celda válida; si no hay espacio, permanecen en su posición corrupta.

### 🛡️ Guerrero Digital

1. **💥 Disparo Sintáctico:** Cada disparo tiene **70% de probabilidad** de eliminar a un AC, como un `kill(AC)` exitoso.
2. **🧮 Contador de Aliens:** Cada AC eliminado decrementa el contador de invasores.
3. **❤️ Vidas:** Si un AC logra atacar, pierdes una vida del guerrero.

### 👾 Ataque de los Aliens

1. **⚡ Ataque Sincronizado:** Cada **5 segundos**, los AC ejecutan su `attack()` sobre el GD.
2. **🎯 Probabilidad de Éxito:** Cada ataque tiene **40% de chance** de acertar, simulando un bug crítico que afecta tu memoria.

---

## ⌨️ Ejecución: Compila el Destino de Null

Para iniciar la simulación, ejecuta el programa (`SimuladorNull.exe`) desde la línea de comandos, definiendo los parámetros de tu defensa digital:

```bash
.\SimuladorNull.exe dimension:X aliens:Y guerrero:V tiempo:T disparo:D ataque:A
```

| Parámetro                     | Clave       | Rango | Descripción                                    |
| :---------------------------- | :---------- | :---- | :--------------------------------------------- |
| **Dimensión**                 | `dimension` | > 0   | Tamaño de la matriz espacial (XxX).            |
| **Aliens Iniciales**          | `aliens`    | ≥ 0   | Número inicial de AC en la galaxia.            |
| **Vidas del Guerrero**        | `guerrero`  | ≥ 1   | Número de vidas del GD.                        |
| **Tiempo Total**              | `tiempo`    | > 0   | Segundos máximos de simulación.                |
| **Probabilidad de Disparo**   | `disparo`   | 0-100 | Porcentaje de éxito de tu Blaster de Sintaxis. |
| **Probabilidad de Ataque AC** | `ataque`    | 0-100 | Porcentaje de éxito de los ataques de los AC.  |

---

### 🕹️ Ejemplo Épico de Llamada

```bash
.\SimuladorNull.exe dimension:5 aliens:10 guerrero:3 tiempo:30 disparo:70 ataque:40
```

> **¡El destino del planeta Null está en tus manos! Que tu código sea fuerte y tu memoria estable. Solo tú puedes prevenir la corrupción total del universo Prog-JL.**

