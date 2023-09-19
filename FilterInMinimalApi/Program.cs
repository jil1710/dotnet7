
using Microsoft.AspNetCore.Mvc;

namespace FilterInMinimalApi
{
    public class Program
    {
        public static List<User> users = new List<User>()
        {
            new User(){ Id = 1 , Name ="Jil"},
            new User(){ Id =2 , Name = "Bhavin"},
            new User(){ Id= 3 , Name = "Abhi"}
        };
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.MapGet("/users", () =>
            {
                return Results.Ok(users);
            });


            /*
                we can add as many as we want endpointfilter in minimal apis.
                For Practical demonstration we can check if header with key "x-name" is missing then we cannot resgister user
                We can filter according to out needs
             */
            app.MapPost("add-user", ([FromBody] User user, HttpContext httpContext) =>
            {
                if(user is not null)
                {
                    users.Add(user);
                    return Results.Ok("User Created!");
                }
                return Results.BadRequest("All fields are required");

            }).AddEndpointFilter(async (ctx, next) =>
            {
                if (ctx.HttpContext.Request.Headers.ContainsKey("x-name"))
                {
                    return await next(ctx);
                }
                else
                {
                    return Results.Problem("Hrader x-name is missing!");
                }
            });

            app.Run();
        }
    }
}