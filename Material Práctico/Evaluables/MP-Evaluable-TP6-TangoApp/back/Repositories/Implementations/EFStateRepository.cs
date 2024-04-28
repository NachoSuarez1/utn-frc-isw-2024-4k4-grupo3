using back.Models;
using back.Repositories.Abstractions;

namespace back.Repositories.Implementations
{
    public class EFStateRepository : IStateRepository
    {
        private EFDbContext _context = new EFDbContext();
        public IEnumerable<State> States { get { return _context.States; } }

        public State GetConfirmed() => _context.States.Where(s => s.Id == 1).First();

        public State GetDiscarded() => _context.States.Where(s => s.Id == 2).First();
    }
}
