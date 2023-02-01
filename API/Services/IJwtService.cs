using API.ViewModels;

namespace API.Services
{
    public interface IJwtService
    {
        string GenerateToken(UserViewModel user);
    }
}
