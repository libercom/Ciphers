using API.Models;
using API.ViewModels;

namespace API.Services
{
    public interface IUserService
    {
        Task CreateUser(UserViewModel userModel);
        Task<IList<User>> GetAll();
        Task<UserViewModel> Login(string name, string password);
    }
}
