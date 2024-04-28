using back.Data.Repositories.Abstractions;
using back.Entities;

namespace back.Data.Repositories.Implementations
{
    public class EFPaymentOptionRepository : IPaymentOptionRepository
    {
        private DataContext _context;

        public EFPaymentOptionRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<PaymentOption> PaymentOptions { get { return _context.PaymentOptions; } }

        public PaymentOption GetPaymentOption(int id) => _context.PaymentOptions.Where(p => p.Id == id).First();
        public PaymentOption GetPaymentOption(string type) => _context.PaymentOptions.Where(p => p.Description == type).First();
    }
}
