# Logger
Wrapper for any Logger package

Install packages:

1. Core package:

    [![NuGet](https://img.shields.io/badge/EasyMicroservices-Logger-orange.svg)](https://www.nuget.org/packages/EasyMicroservices.Logger.DependencyInjection/)


2. Use package:

   [![NuGet](https://img.shields.io/badge/EasyMicroservicesLogger-Log4net-orange.svg)](https://www.nuget.org/packages/EasyMicroservices.Logger.Log4net/)
   
   [![NuGet](https://img.shields.io/badge/EasyMicroservicesLogger-NLog-orange.svg)](https://www.nuget.org/packages/EasyMicroservices.Logger.NLog/)
   
   [![NuGet](https://img.shields.io/badge/EasyMicroservicesLogger-Serilog-orange.svg)](https://www.nuget.org/packages/EasyMicroservices.Logger.Serilog/)
   
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

[![Line Coverage Status](./src/CSharp/EasyMicroservices.Logger/coverage-badge-line.svg)](https://github.com/danpetitt/open-cover-badge-generator-action/)
