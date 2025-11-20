
// Debes agregar el paquete NuGet Microsoft.Extensions.Logging si no lo tienes ya.
// Microsoft.Extensions.Logging.Console
// dotnet add package Microsoft.Extensions.Logging.Console
// Crear la fábrica de logs

using Microsoft.Extensions.Logging;
using Serilog;

// Log de Microsoft.Extensions.Logging
using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
var logger = loggerFactory.CreateLogger<Program>();

// Serilog
// Necesitas agregar el paquete NuGet Serilog.Sinks.Console si no lo tienes ya.
// dotnet add package Serilog.Sinks.Console
// Configurar Serilog (una sola vez)
Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

// Ejemplos de uso de Microsoft.Extensions.Logging
logger.LogTrace("Mensaje de traza");
logger.LogDebug("Mensaje de depuración");
logger.LogInformation("Hola, este es un mensaje informativo.");
logger.LogWarning("¡Cuidado! Algo puede estar mal.");
logger.LogError("Ha ocurrido un error.");
logger.LogCritical("Error crítico, el sistema puede caerse.");

// Ejemplos de uso de Serilog
Log.Information("Hola, este es un mensaje informativo con Serilog.");
Log.Warning("¡Cuidado! Algo puede estar mal con Serilog.");
Log.Error("Ha ocurrido un error con Serilog.");
Log.Fatal("Error crítico con Serilog, el sistema puede caerse.");

// Llamamos a una función que también usa el logger
ProcesarLogNet();
ProcesarLogSerilog();

void ProcesarLogNet() {
    logger.LogInformation("Entrando a la función Procesar()");
    // ... código ...
    logger.LogInformation("Saliendo de la función Procesar()");
}

void ProcesarLogSerilog() {
    Log.Information("Entrando a la función ProcesarLogSerilog()");
    //... código...
    Log.Information("Saliendo de la función ProcesarLogSerilog()");
}