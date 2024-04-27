using back.Models;

namespace back.Repositories.Abstractions
{
    public interface IQuoteRepository
    {
        IEnumerable<Quote> Quotes { get; }
        void Update(Quote quote);
    }
}
