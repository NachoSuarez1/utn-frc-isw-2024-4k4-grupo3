using back.Models;
using back.Repositories.Abstractions;

namespace back.Repositories.Implementations
{
    public class EFUserRepository : IUserRepository
    {
        private EFDbContext _context = new EFDbContext();
        public IEnumerable<User> Users { get { return _context.Users; } }
    }
}
