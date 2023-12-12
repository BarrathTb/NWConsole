using NLog;
using System.Linq;
using NWConsole.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
// other using statements ...

// Load configuration from appsettings.json
var config = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .Build();

// Configure Logger
LoggerConfig.ConfigureLogger();
// Create instance of Logger
LoggerConfig.LogDebug("Program started");

var optionsBuilder = new DbContextOptionsBuilder<NWContext>();
optionsBuilder.UseSqlServer(config["Northwind:ConnectionString"]); // Corrected line


using (NWContext dbContext = new NWContext(optionsBuilder.Options))
{
    MenuServices menuServices = new MenuServices(dbContext);

    try
    {
        menuServices.RunProgram();
    }
    catch (Exception ex)
    {
        LoggerConfig.LogDebug(ex.Message);
    }
}

