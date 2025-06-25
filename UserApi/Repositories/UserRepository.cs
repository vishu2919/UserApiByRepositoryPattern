using UserApi.Models;

namespace UserApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static List<User> users = new List<User>();
        private static int nextId = 1;

        public User GetUserById(int userId)
        {
            return users.FirstOrDefault(u => u.UserId == userId);
        }

        public User AddUser(User user)
        {
            user.UserId = nextId++;
            users.Add(user);
            return user;
        }

    }
}
