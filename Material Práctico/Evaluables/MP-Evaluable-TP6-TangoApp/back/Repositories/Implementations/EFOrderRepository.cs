using back.Models;
using back.Repositories.Abstractions;

namespace back.Repositories.Implementations
{
    public class EFOrderRepository : IOrderRepository
    {
        private EFDbContext _context = new EFDbContext();

        public IEnumerable<Order> Orders { get { return _context.Orders; } }
    }
}
