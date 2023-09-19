
namespace OutputcacheFeature
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


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add new Feature of .net 7 Output cache
            builder.Services.AddOutputCache(options =>
            {
                options.AddPolicy("cache-by-query-name", policy =>
                {
                    policy.SetVaryByQuery("name");
                    policy.Expire(TimeSpan.FromSeconds(10));
                    policy.Cache();
                });

                // default 
                options.AddPolicy("cache", policy =>
                {
                    policy.Cache();
                });

                options.AddPolicy("no-cache", policy =>
                {
                    policy.NoCache();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();


            app.UseOutputCache();

            app.MapGet("/user-by-name", (string? name) =>
            {
                if (name is not null)
                {
                    return Results.Ok(users.FirstOrDefault(x => x.Name.ToLower() == name.ToLower()));
                }

                return Results.BadRequest("User name not exist");
            }).CacheOutput("cache-by-query-name");

            app.MapGet("/users-cache", () =>
            {
                return Results.Ok(users);

            }).CacheOutput("cache");

            app.MapGet("/users-no-cache", () =>
            {
                return Results.Ok(users);

            }).CacheOutput("no-cache");


            app.Run();
        }
    }
}