using back.Data.Repositories.Abstractions;
using back.Entities;
using Microsoft.EntityFrameworkCore;

namespace back.Data.Repositories.Implementations
{
    public class EFOrderRepository : IOrderRepository
    {
        private DataContext _context;

        public EFOrderRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> Orders { get { return _context.Orders.Include(o => o.User); } }
    }
}
