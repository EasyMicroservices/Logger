# Logger


[![Line Coverage Status](./src/CSharp/coverage-badge-line.svg)](https://github.com/danpetitt/open-cover-badge-generator-action/)

![Linux (dotnet build and test)](https://img.shields.io/github/actions/workflow/status/EasyMicroservices/Logger/dotnet-linux.yml?branch=develop)
 
Introduction
-------------

Logging is a critical piece of the software development puzzle. It provides developers with a window into the operation of their applications, informing them not only of errors and exceptions but also of the flow of application logic and the state of the system at any given moment. The interfaces `ILoggerProvider` and `ILoggerAsyncProvider` act as blueprints for logging mechanisms across different layers of an application. They are designed to ensure consistency and allow for flexibility in logging techniques and strategies.

In a world where applications are becoming more asynchronous and distributed in nature, providing both synchronous and asynchronous logging capacities is indispensable. This helps accommodate various operational contexts, from handling immediate, time-sensitive data to dealing with long-running processes that require non-blocking operations.

Summary
--------

`ILoggerProvider` offers a set of methods that cater to different levels of logging severity – Verbose, Debug, Information, Warning, Error, and Fatal. It is tailor-made for applications where logging synchronously is acceptable, and simplicity is key. Each method corresponds to a particular level of interest or severity, allowing developers to categorize and filter logs based on their urgency and relevance.

`ILoggerAsyncProvider` inherits from `ILoggerProvider` and extends it by providing asynchronous counterparts for each of the logging methods. This is exceptionally important for applications that run on scalable, distributed systems where performance and resource optimization are vital. Non-blocking calls help maintain system responsiveness and throughput, especially under high load, by freeing up threads to perform other operations while the logging tasks complete in the background.

The significance of such interfaces grows exponentially when considering the myriad of logging frameworks available in the software landscape. By abstracting the logging functionality behind an interface, developers can seamlessly switch between different logging libraries without changing the application codebase, promoting modularity and adaptability.

Details
-------

### Interface Definition

- **ILoggerProvider**: Defines a synchronous logging standard which requires implementations to provide methods for logging messages at different levels. Each level serves a distinct purpose:
  - **Verbose**: For detailed debug information, typically of least importance.
  - **Debug**: Information valuable during development and debugging.
  - **Information**: General information about application processing.
  - **Warning**: Indicators of issues that are not errors but might require attention.
  - **Error**: For logging errors that can be handled and won't cause the system to stop.
  - **Fatal**: Critical issues that result in termination of the application.

- **ILoggerAsyncProvider**: Augments `ILoggerProvider` with asynchronous methods, necessitating task-based versions of the same logging levels to enable more efficient resource utilization during logging.

### Asynchronous Advantages

Asynchronous logging is not about speed but about resource efficiency. By implementing `ILoggerAsyncProvider`, developers can prevent the logging process from blocking critical threads, thereby enhancing the application's capability to handle concurrent operations. This is particularly advantageous when the logs are written to slower sinks such as network storage, databases, or when log aggregation and monitoring services are involved.

### Logging Frameworks

Each of the provided packages—Log4net, Logary, Loupe, NLog, Sentry, Serilog—is equipped with distinct features:

- **Log4net** is known for its simplicity and has been a standard choice among .NET developers.
  
- **Logary** targets high-performance and multi-target logging, focusing on F# and .NET applications.
  
- **Loupe** offers detailed monitoring and analysis capabilities alongside logging.
  
- **NLog** provides extensive configuration options and layout rendering.
  
- **Sentry** excels at real-time error tracking and is often used to monitor live environments.
  
- **Serilog** is designed to log structured data, allowing complex data queries on logs.

### Integration into ASP.NET Core via Dependency Injection

The easy integration into an ASP.NET Core application is achieved by installing the `EasyMicroservices.Logger.DependencyInjection` package and configuring it in the `Startup.cs` class of the application. The `AddLogger` extension method in the `ConfigureServices` method is where the choice of a logging provider is made. This single line of configuration hooks the chosen logger into the application's service container, making it available throughout the application via dependency injection.

### Conclusion

A detailed document describing this `ILoggerProvider` implementation would cover the interfaces' purpose, their significance in the architecture of modern applications, and the usage instructions—assisted by examples and use-case scenarios. It would also delve into the specifics of each logging method provided by the interfaces and the logging frameworks' strengths and how developers could harness these according to their application requirements.

Such a document would be crucial for enabling developers to make informed decisions about which logging practices to adopt and would serve as a guide for maintaining best practices in application monitoring and diagnostics.


Install packages:

   [![NuGet](https://img.shields.io/badge/EasyMicroservicesLogger-Log4net-orange.svg)](https://www.nuget.org/packages/EasyMicroservices.Logger.Log4net/)
   
   [![NuGet](https://img.shields.io/badge/EasyMicroservicesLogger-NLog-orange.svg)](https://www.nuget.org/packages/EasyMicroservices.Logger.NLog/)
   
   [![NuGet](https://img.shields.io/badge/EasyMicroservicesLogger-Serilog-orange.svg)](https://www.nuget.org/packages/EasyMicroservices.Logger.Serilog/)

   [![NuGet](https://img.shields.io/badge/EasyMicroservicesLogger-Logary-orange.svg)](https://www.nuget.org/packages/EasyMicroservices.Logger.Logary/)
   
   [![NuGet](https://img.shields.io/badge/EasyMicroservicesLogger-Loupe-orange.svg)](https://www.nuget.org/packages/EasyMicroservices.Logger.Loupe/)
      
   [![NuGet](https://img.shields.io/badge/EasyMicroservicesLogger-Sentry-orange.svg)](https://www.nuget.org/packages/EasyMicroservices.Logger.Sentry/)
   
   [![NuGet](https://img.shields.io/badge/EasyMicroservicesLogger-DependencyInjection-orange.svg)](https://www.nuget.org/packages/EasyMicroservices.Logger.DependencyInjection/)

Startup:

```csharp
public class Startup
{
    //...
    
    public void ConfigureServices(IServiceCollection services)
    {
        //configuration
        services.AddLogger(o => 
        { 
            o.UseSerilog();
            //or 
            o.UseNLog(); 
            //or 
            o.UseLog4net(); 
            //or 
            o.UseSentry(); 
            //or 
            o.UseLoupe(); 
            //or 
            o.UseLogary(); 
        });
    }
}
```
Usage:

```csharp

using Common.Models;
using EasyMicroservices.Logger.Interfaces;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class DIController : ControllerBase
{
    private readonly ILoggerProvider _logger;

    public DIController(ILoggerProvider logger)
    {
        _logger = logger;
    }

    [Route("Serialize")]
    [HttpGet]
    public IActionResult Serialize()
    {
        Customer model = new Customer() { Age = 51, FirstName = "Elon", LastName = "Musk" };
        _logger.Debug($"FirstName: {model.FirstName}");
        return Ok(result);
    }
}
```
