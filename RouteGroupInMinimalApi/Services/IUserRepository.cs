namespace RouteGroupInMinimalApi.Services
{
    public interface IUserRepository
    {
        int AddUser(User user);
        User GetUser(int id);
        List<User> GetUsers();
    }
}