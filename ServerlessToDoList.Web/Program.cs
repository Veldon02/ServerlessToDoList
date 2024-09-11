using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServerlessToDoList.Web.DI;
using ServerlessToDoList.Web.Middlewares;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication(builder => { builder.UseMiddleware<ExceptionHandlingMiddleware>(); })
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        services.AddPersistence();
    })
    .Build();

host.Run();