using back.Data.Repositories.Abstractions;
using back.Entities;
using Microsoft.EntityFrameworkCore;

namespace back.Data.Repositories.Implementations
{
    public class EFQuoteRepository : IQuoteRepository
    {
        private DataContext _context;

        public EFQuoteRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Quote> Quotes { get { return _context.Quotes
                    .Include(o => o.Transport)
                    .Include(o => o.State)
                    .Include(o => o.SelectedPaymentOption)
                    .Include(o => o.PaymentOptions); } }

        public void Update(Quote quote)
        {
            var dbQuote = _context.Quotes.Find(quote.Id);
            if (dbQuote is not null)
            {
                dbQuote.State = quote.State;
                dbQuote.SelectedPaymentOption = quote.SelectedPaymentOption;
            }
            _context.SaveChanges();
        }
    }
}
