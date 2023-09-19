
using Microsoft.AspNetCore.Mvc;
using ParameterBindingServiceWithDI.Services;

namespace ParameterBindingServiceWithDI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            /* you can take advantage of dependency injection to bind parameters in the action methods of your API controllers. 
             * If the type is configured as a service, you no longer need to add the [FromServices] attribute to your method parameters. 
            */
            builder.Services.AddSingleton<IUserRepository,UserRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.MapDefaultControllerRoute();

            app.MapGet("/fetch-user-with-latest-dotnet7-feature/{id}", (int id, IUserRepository userRepository) =>
            {
                return Results.Ok(userRepository.GetUser(id));
            });
            
            
            app.MapGet("/fetch-user-with-dotnet6-feature/{id}", ([AsParameters]int id, [FromServices] IUserRepository userRepository) =>
            {
                return Results.Ok(userRepository.GetUser(id));
            });

            

            app.Run();
        }
    }
}