namespace ParameterBindingServiceWithDI.Services
{
    public class UserRepository : IUserRepository
    {
        
        public static List<User> _users = new List<User>()
        {
            new User(){ Id = 1 , Name ="Jil"},
            new User(){ Id =2 , Name = "Bhavin"},
            new User(){ Id= 3 , Name = "Abhi"}
        };

        public User GetUser(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        public int AddUser(User user)
        {
            _users.Add(user);
            return 1;
        }
    }
}
