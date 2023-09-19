
namespace FileUploadInMinimalApi
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

            // Upload single file
            app.MapPost("/uploadfile", async (IFormFile iformFile) =>
            {
                var tempFileName = Path.GetTempFileName();
                using var fileStream = File.OpenWrite(tempFileName);
                await iformFile.CopyToAsync(fileStream);
            });

            // Upload Multiple files
            app.MapPost("/uploadfiles", async (IFormFileCollection files) =>
            {
                foreach (var file in files)
                {
                    var tempFileName = Path.GetTempFileName();
                    using var fileStream = File.OpenWrite(tempFileName);
                    await file.CopyToAsync(fileStream);
                }
            });

            app.Run();
        }
    }
}