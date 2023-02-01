using API.Context;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUser(string name)
        {
            var user = await _context.Set<User>().FirstOrDefaultAsync(x => x.Name == name);

            return user;
        }

        public async Task CreateUser(User user)
        {
            _context.Set<User>().Add(user);

            await _context.SaveChangesAsync();
        }

        public async Task<IList<User>> GetAll()
        {
            return await _context.Set<User>().ToListAsync();
        }
    }
}
