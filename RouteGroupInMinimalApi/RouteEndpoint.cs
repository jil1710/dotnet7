using RouteGroupInMinimalApi.Services;

namespace RouteGroupInMinimalApi
{
    public static class RouteEndpoint
    {
        public static RouteGroupBuilder MapUserApi(this RouteGroupBuilder group)
        {
            group.MapGet("/", (IUserRepository user) =>
            {
                return Results.Ok(user.GetUsers());
            });
            group.MapGet("/{id}", (int id,IUserRepository user) =>
            {
                return Results.Ok(user.GetUser(id));
            });

            return group;
        }
    }
}
