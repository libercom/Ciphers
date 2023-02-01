using API.Models;

namespace API.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUser(string name);
        Task CreateUser(User user);
        Task<IList<User>> GetAll();
    }
}
