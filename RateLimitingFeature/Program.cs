
using System.Threading.RateLimiting;

namespace RateLimitingFeature
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

            // configure rate limiter 
            builder.Services.AddRateLimiter(options =>
            {
                options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;


                // here for particular user we set rate limiting based on ip address
                options.AddPolicy("fixed", httpContext => 
                                RateLimitPartition.GetFixedWindowLimiter(
                                    partitionKey: httpContext.Connection.RemoteIpAddress?.ToString(),
                                    factory: _ => new FixedWindowRateLimiterOptions() 
                                    { 
                                        // 10 request in 10 second if try to request more then status code 429 appear
                                        PermitLimit = 10, 
                                        Window= TimeSpan.FromSeconds(10)
                                    })
                                );
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRateLimiter();

            app.MapGet("/users", () =>
            {
                if(users.Count > 0)
                {
                    return Results.Ok(users);
                }

                return Results.BadRequest("No Users!");
            }).RequireRateLimiting("fixed");
            

            app.Run();
        }
    }
}