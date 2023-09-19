
using Microsoft.Extensions.Primitives;

namespace BindArray_StringFromHeader_QueryString
{
    public class Program
    {
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

            // Bind query string values to a primitive type array.
            // GET  /tags?q=1&q=2&q=3
            app.MapGet("/tags", (int[] q) =>
                                  $"tag1: {q[0]} , tag2: {q[1]}, tag3: {q[2]}");

            // Bind to a string array.
            // GET /tags2?names=john&names=jack&names=jane
            app.MapGet("/tags2", (string[] names) =>
                        $"tag1: {names[0]} , tag2: {names[1]}, tag3: {names[2]}");

            // Bind to StringValues.
            // GET /tags3?names=john&names=jack&names=jane
            app.MapGet("/tags3", (StringValues names) =>
                        $"tag1: {names[0]} , tag2: {names[1]}, tag3: {names[2]}");

            app.Run();
        }
    }
}