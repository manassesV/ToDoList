namespace ToDoList.Infrastructure;

public static class InfrastructureExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ToDoListDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<ITodoTaskRepository, TodoTaskRepository>();


        return services;
    }
}
