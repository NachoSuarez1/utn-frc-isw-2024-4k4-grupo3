using back.Data.Repositories.Abstractions;
using back.Entities;
using Microsoft.EntityFrameworkCore;

namespace back.Data.Repositories.Implementations
{
    public class EFStateRepository : IStateRepository
    {
        private DataContext _context;

        public EFStateRepository(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<State> States { get { return _context.States; } }

        public State GetConfirmed() => _context.States.Where(s => s.Id == 1).First();
        public State GetDiscarded() => _context.States.Where(s => s.Id == 2).First();
        public State GetPending() => _context.States.Where(s => s.Id == 3).First();
    }
}
