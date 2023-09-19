namespace ParameterBindingServiceWithDI.Services
{
    public interface IUserRepository
    {
        int AddUser(User user);
        User GetUser(int id);
    }
}