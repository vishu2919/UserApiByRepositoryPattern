using UserApi.Models;

namespace UserApi.Repositories
{
    public interface IUserRepository
    {
        User GetUserById(int userId);
        User AddUser(User user);
    }
}
