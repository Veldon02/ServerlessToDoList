using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ServerlessToDoList.Web.Interfaces.Repositories;
using ServerlessToDoList.Web.Persistence;
using ServerlessToDoList.Web.Persistence.Repositories;

namespace ServerlessToDoList.Web.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<ToDoListDbContext>(options =>
        {
            options.UseSqlServer(Environment.GetEnvironmentVariable("DatabaseConectionString"));
        });

        services.AddRepositories();

        return services;
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IToDoListItemRepository, ToDoListItemRepository>();
        services.AddScoped<IToDoListRepository, ToDoListRepository>();
    }
}