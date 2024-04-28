using back.Data.Repositories.Abstractions;
using back.Entities;
using Microsoft.EntityFrameworkCore;

namespace back.Data.Repositories.Implementations
{
    public class EFUserRepository : IUserRepository
    {
        private DataContext _context;
        public IEnumerable<User> Users { get { return _context.Users; } }

        public EFUserRepository(DataContext context)
        {
            _context = context;
        }
    }
}
