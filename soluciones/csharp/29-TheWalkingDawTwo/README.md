# 🧟‍♂️ THE WALKIND DAW II: Escape del IES Luis Vives 💻

## 📜 Historia: El Último Examen y el Apocalipsis Prog-JL

Es un día normal en el **IES Luis Vives**… hasta que un error crítico de **Null Pointer** desata el **Virus Prog-JL**, transformando a algunos alumnos y profesores en **Zombies del Código (ZC)**.

**Tú eres Daryl**, un estudiante que logró encerrarse en un aula antes de que la infección se propagara. Pero el tiempo corre y el examen de Programación se acerca. El virus amenaza con **asolar todo el instituto**, y cada segundo que pases encerrado pone tu vida en riesgo.

Tu objetivo: **escapar del IES Luis Vives** antes de que los ZC te atrapen, usando tu ingenio y los recursos disponibles en las aulas.

Cada celda del instituto puede estar ocupada por:

* **🧟 Zombie del Código (ZC)**
* **◻️ Bloque o obstáculo (mesas, sillas, armarios)**
* **💊 Paquete de Salud**
* **🙂 Daryl (Tú)**
* **🚪 Puerta de salida** *(siempre en la esquina inferior derecha)*

Tu posición inicial es **aleatoria**, y el mundo está lleno de obstáculos, zombies y paquetes de salud distribuidos de manera estratégica.

---

## ⚙️ Mecánicas de Supervivencia Prog-JL

### 💖 Salud y Munición

* Comienzas con **10 puntos de salud** y **10 municiones** (lapiceros, marcadores o lanzamientos de libros de programación).
* Cada vez que te encuentres con un ZC:

  * Si tienes munición, puedes dispararle; **50% de probabilidad** de que el ZC te ataque primero.
  * Si no tienes munición, puedes usar tu **machete de código**, pero **pierdes 2 puntos de salud**.

### 🧱 Obstáculos del Instituto

* Los bloques (mesas, sillas) pueden ser destruidos **si tienes al menos 2 municiones**.
* Si no tienes munición suficiente, tendrás que **cambiar de dirección** y buscar un camino libre hacia la salida.

### 🚶 Movimiento

* Cada **segundo**, Daryl se mueve en **una dirección aleatoria**.
* Si chocas con el borde del aula o un obstáculo, tu dirección se ajusta automáticamente para seguir dentro del instituto.

### 🧟‍♂️ Spawn de Zombies

* Cada **5 segundos**, un nuevo ZC aparece en una celda aleatoria **si hay espacio disponible**, simulando la propagación del **Virus Prog-JL** tras el Null Pointer fatal.

### ⏳ Fin del Juego

El juego termina cuando:

1. Tu **salud llega a 0**.
2. Se **acaban los 30 segundos** de tiempo.
3. Alcanzas la **puerta de salida**, que está **en la esquina inferior derecha de la cuadrícula**.

---

## ⌨️ Ejecución: Escapa del IES Luis Vives en Prog-JL

Para iniciar la simulación, ejecuta el programa (`WalkindDAW.exe`) desde la línea de comandos con los parámetros de inicialización:

```bash
.\WalkindDAW.exe dimension:X salud:H municion:M tiempo:T zombies:Z bloques:B
```

| Parámetro             | Clave       | Rango | Descripción                                  |
| :-------------------- | :---------- | :---- | :------------------------------------------- |
| **Dimensión**         | `dimension` | > 0   | Tamaño de la cuadrícula del instituto (XxX). |
| **Salud Inicial**     | `salud`     | ≥ 1   | Puntos de salud iniciales de Daryl.          |
| **Munición Inicial**  | `municion`  | ≥ 0   | Munición disponible al inicio.               |
| **Tiempo Máximo**     | `tiempo`    | > 0   | Segundos que dura la simulación.             |
| **Zombies Iniciales** | `zombies`   | ≥ 0   | Número inicial de ZC en la cuadrícula.       |
| **Bloques Iniciales** | `bloques`   | ≥ 0   | Número inicial de obstáculos del aula.       |

---

### 🕹️ Ejemplo Épico de Llamada

```bash
.\WalkindDAW.exe dimension:5 salud:10 municion:10 tiempo:30 zombies:3 bloques:4
```

> **¡El Virus Prog-JL corre por el IES Luis Vives y tu Null Pointer ha transformado a varios compañeros en ZC! Sobrevive, dispara, esquiva y alcanza la puerta en la esquina inferior derecha antes de que tu código y tu salud colapsen. ¡El examen aún puede esperar si logras escapar!**

