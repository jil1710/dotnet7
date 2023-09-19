
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace JsonPropertyNameInValidation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            /*
                By default, when a validation error occurs, model validation produces a ModelStateDictionary with the property name as the error key. 
                Some apps, such as single page apps, benefit from using JSON property names for validation errors generated from Web APIs.
                The following code configures validation to use the SystemTextJsonValidationMetadataProvider to use JSON property names:
             */

            builder.Services.AddControllers(options =>
            {
                options.ModelMetadataDetailsProviders.Add(new SystemTextJsonValidationMetadataProvider());
            });

            

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

            app.MapDefaultControllerRoute();

            app.Run();
        }
    }
}