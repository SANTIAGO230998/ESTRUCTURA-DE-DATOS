# Árbol Binario en C# con Graphviz

## Descripción

Este proyecto implementa un **árbol binario en C#**, construido a partir de datos almacenados en archivos de texto (.txt).
Permite visualizar la estructura mediante **Graphviz**, además de analizar sus propiedades.

---

## Funcionalidades

* Cargar árboles desde archivos `.txt`
* Definir relaciones padre-hijo (izquierda/derecha)
* Buscar elementos
* Recorridos:

  * Preorden
  * Inorden
  * Postorden
* Reportería:

  * Raíz
  * Número de nodos
  * Hojas
  * Altura
* Generación automática de imagen del árbol (`.png`)
* Medición de tiempo de ejecución

---
## Requisitos

* Visual Studio / .NET
* Graphviz

Configurar en el código:

```csharp
startInfo.FileName = @"C:\Program Files\Graphviz\bin\dot.exe";
```

---

## Uso

1. Ejecutar el programa
2. Cargar un ejemplo
3. Visualizar la imagen generada automáticamente
