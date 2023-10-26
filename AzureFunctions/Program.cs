using AzureFunctions.DAL;
using AzureFunctions.DAL.Repositories;
using AzureFunctions.DAL.Repositories.Interfaces;
using AzureFunctions.Service;
using AzureFunctions.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<MortgageContext>(options =>
        {
            options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection"));
        });
        services.AddScoped<IMortgageService, MortgageService>();
        services.AddScoped<IMortgageApplicationService, MortgageApplicationService>();
        services.AddScoped<IMortgageApplicationRepo, MortgageApplicationRepo>();
        services.AddScoped<IMortgageRepo, MortgageRepo>();
    })
    .Build();

host.Run();
