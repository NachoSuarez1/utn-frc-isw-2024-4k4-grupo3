using back.Models;
using back.Repositories.Abstractions;

namespace back.Repositories.Implementations
{
    public class EFPaymentOptionRepository : IPaymentOptionRepository
    {
        private EFDbContext _context = new EFDbContext();
        public IEnumerable<PaymentOption> PaymentOptions { get { return _context.PaymentOptions; } }

        public PaymentOption GetPaymentOption(int id) => _context.PaymentOptions.Where(p => p.Id == id).First();
    }
}
