
namespace RequestDecompressionMiddleware
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // add request decompress middleware
            builder.Services.AddRequestDecompression();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRequestDecompression();

            // When user upload binary file like zip,rar etc it will decompress 
            // For ex : i have json file and i compress it in zip now i will decompress and read content from it.

            app.MapPost("/upload-zip", async (HttpRequest res) =>
            {
                using StreamReader sr = new(res.Body);
                var jsonData = await sr.ReadToEndAsync();

                return Results.Ok(jsonData);

            });
            

            app.Run();
        }
    }
}