using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServerlessToDoList.Web.DI;
using ServerlessToDoList.Web.Mappings;
using ServerlessToDoList.Web.Middlewares;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication(builder => { builder.UseMiddleware<ExceptionHandlingMiddleware>(); })
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        services.AddDependencyInjections();
        services.AddAutoMapper(typeof(AutoMapperProfile));

        services.Configure<JsonOptions>(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });
    })
    .Build();

host.Run();