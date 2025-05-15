namespace ToDoList.Application;

public static class ApplicationExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<CreateTodoTaskCommand>();
            cfg.RegisterServicesFromAssemblyContaining<UpdateTodoTaskCommand>();

        });

        services.AddScoped<ITodoTaskQueries, TodoTaskQueries>();
        return services;
    }
}
