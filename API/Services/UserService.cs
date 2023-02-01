using API.Models;
using API.Repositories;
using API.ShaEncryptor;
using API.ViewModels;
using AsymmetricCiphers;

namespace API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IShaEncryptor _shaEncryptor;

        public UserService(IUserRepository repository, IShaEncryptor shaEncryptor)
        {
            _repository = repository;
            _shaEncryptor = shaEncryptor;
        }

        public async Task<IList<User>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task CreateUser(UserViewModel userModel)
        {
            var password = userModel.Password;
            var rsa = new RSA();

            password = _shaEncryptor.HashPassword(password);
            password = rsa.Encrypt(password);

            var user = new User(password, userModel.Name, userModel.Role);

            await _repository.CreateUser(user);
        }

        public async Task<UserViewModel> Login(string name, string password)
        {
            password = _shaEncryptor.HashPassword(password);

            var rsa = new RSA();
            var user = await _repository.GetUser(name);
            var decryptedPassword = rsa.Decrypt(user.Password);

            if (string.Equals(password, decryptedPassword, StringComparison.OrdinalIgnoreCase))
            {
                return new UserViewModel { Name = user.Name, Password = "", Role = user.Role };
            }
            else
            {
                return null;
            }
        }
    }
}
