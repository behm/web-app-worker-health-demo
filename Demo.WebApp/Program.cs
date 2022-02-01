using System.Runtime.InteropServices;
using Demo.WebApp.HealthChecks;
using Demo.WebApp.Workers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks()
    .AddCheck<SampleHealthCheck>("Sample");

builder.Services.AddHostedService<Worker>();

var app = builder.Build();

app.MapHealthChecks("/you-up");

app.MapGet("/", () => "Hello World!");
app.MapGet("/about", () => 
{
    return new {
        OperatingSystem = Environment.OSVersion,
        Platform = GetPlatform().ToString(),
        MachineName = Environment.MachineName,
        EnvironmentVariables = Environment.GetEnvironmentVariables()
    };
});

OSPlatform GetPlatform()
{
    if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
    {
        return OSPlatform.Linux;
    }

    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
    {
        return OSPlatform.Windows;
    }

    if (RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD))
    {
        return OSPlatform.Windows;
    }

    if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
    {
        return OSPlatform.OSX;
    }

    throw new Exception("Cannot determine operating system!");
}

app.Run();
