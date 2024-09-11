using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ServerlessToDoList.Web.Interfaces.Repositories;
using ServerlessToDoList.Web.Interfaces.Services;
using ServerlessToDoList.Web.Persistence;
using ServerlessToDoList.Web.Persistence.Repositories;
using ServerlessToDoList.Web.Services;

namespace ServerlessToDoList.Web.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjections(this IServiceCollection services)
    {
        services.AddServices();
        services.AddPersistence();

        return services;
    }

    private static void AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<ToDoListDbContext>(options =>
        {
            options.UseSqlServer(Environment.GetEnvironmentVariable("DatabaseConectionString"));
        });

        services.AddRepositories();
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IToDoListItemRepository, ToDoListItemRepository>();
        services.AddScoped<IToDoListRepository, ToDoListRepository>();
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IToDoListService, ToDoListService>();
    }
}