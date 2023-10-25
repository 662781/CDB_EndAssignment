using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.Interfaces;
using Service;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    //.ConfigureServices(services =>
    //{
    //    services.AddSingleton<IMortgageService, MortgageService>();
    //    services.AddSingleton<IMortgageApplicationService, MortgageApplicationService>();
    //    services.AddSingleton<IBuyerService, BuyerService>();
    //})
    .Build();

host.Run();
