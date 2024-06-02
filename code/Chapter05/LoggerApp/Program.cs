// To use ILoggerFactory, LoggerFactory, ILogger.
using Microsoft.Extensions.Logging; 

using ILoggerFactory factory = 
  LoggerFactory.Create(builder =>
  {
    // This extension method is only available when you reference
    // the Microsoft.Extensions.Logging.Console package.
    builder.AddConsole();

    // Optionally, add other providers like:
    // AddDebug, AddEventLog, AddSerilog, AddLog4Net.
    // These methods are only available if you reference the 
    // appropriate packages.

    // Optionally, add configuration like:
    // AddFilter, AddConfiguration.
  });

// The generic type parameter is used to categorize log messages.
ILogger logger = factory.CreateLogger<Program>();

string[] messageTemplates =
{
  "Logging is {Description}", // messageTemplates[0]
  "Product ID: {ProductId}, Product Name: {ProductName}"
};

logger.LogInformation(
  // The message parameter is poorly named. It is NOT a message.
  // It is a template format string that can contain placeholders.
  message: messageTemplates[0], 
  args: "cool!");

logger.LogWarning(messageTemplates[1],
  // Passing a params array of objects for args parameter.
  1, "Chai");
