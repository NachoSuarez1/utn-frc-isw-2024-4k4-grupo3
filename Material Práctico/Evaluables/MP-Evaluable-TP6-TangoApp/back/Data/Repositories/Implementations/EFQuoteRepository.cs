﻿using back.Data.Repositories.Abstractions;
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
            var dbQuote = _context.Quotes.FirstOrDefault(q => q.Id == quote.Id && q.OrderId == quote.OrderId);
            if (dbQuote is not null)
                dbQuote.Update(quote);

             _context.SaveChanges();
        }
    }
}
