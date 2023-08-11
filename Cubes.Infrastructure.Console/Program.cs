using Cubes.Application.Interfaces;
using Cubes.Application.Services;
using Cubes.Domain.Entities;
using Cubes.Domain.Interfaces.Repositories;
using Cubes.Infrastructure.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Cubes.Infrastructure.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Build())
            .CreateLogger();

            Log.Logger.Information("Application starting...");

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddScoped<ICubeService, CubeService>();
                    services.AddScoped<IValidationService, ValidationService>();
                    services.AddScoped<ICubesCollidationService, CubesCollidationService>();
                    services.AddScoped<IBuildCubesList, BuildCubesList>();
                    services.AddScoped<ICalculateIntersectingVolume, CalculateIntersectingVolume>();
                    services.AddScoped<IRepository<ResponseEntity>, Repository>();
                })
                .Build();



            var service = ActivatorUtilities.CreateInstance<CubeService>(host.Services);
            service.Run();
        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
           .AddEnvironmentVariables()
           .Build();
        }
    }
}