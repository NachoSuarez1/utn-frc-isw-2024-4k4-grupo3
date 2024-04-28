using back.Models;
using back.Repositories.Abstractions;

namespace back.Repositories.Implementations
{
    public class EFQuoteRepository : IQuoteRepository
    {
        private EFDbContext _context = new EFDbContext();

        public IEnumerable<Quote> Quotes { get { return _context.Quotes; } }

        public void Update(Quote quote)
        {
            var dbQuote = _context.Quotes.Find(quote.Id);
            if (dbQuote is not null) {
                dbQuote.State = quote.State;
                dbQuote.SelectedPaymentOption = quote.SelectedPaymentOption;
            }
            _context.SaveChanges();
        }
    }
}
