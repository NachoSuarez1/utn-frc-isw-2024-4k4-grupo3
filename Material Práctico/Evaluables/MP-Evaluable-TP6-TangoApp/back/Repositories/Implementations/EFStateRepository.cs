using back.Models;
using back.Repositories.Abstractions;

namespace back.Repositories.Implementations
{
    public class EFStateRepository : IStateRepository
    {
        private EFDbContext _context = new EFDbContext();
        public IEnumerable<State> States { get { return _context.States; } }
    }
}
