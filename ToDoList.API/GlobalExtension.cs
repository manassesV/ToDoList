﻿using System.Text.Json.Serialization;
using ToDoList.API.Swagger;

namespace ToDoList.API;

public static class GlobalExtension
{
    public static IHostApplicationBuilder AddServiceDescriptors(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;

        services.AddControllers()
             .AddJsonOptions(options =>
             {
                 options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
             });
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        builder.Services.AddCors(options =>
        {

            options.AddPolicy("AllowAll",
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
        });

        //swagger
        services.AddAndConfigureSwagger(
            builder.Configuration,
            Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"),
            true);


        services.AddScoped<TodoTaskServices>();
        services.AddApiVersionConfiguration();
        services.AddApplication();
        services.AddInfrastructure(builder.Configuration.GetConnectionString("todolistdb"));

        return builder;
    }
}
