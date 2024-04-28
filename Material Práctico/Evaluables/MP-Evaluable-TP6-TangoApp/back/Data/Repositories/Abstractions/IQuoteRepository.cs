using back.Entities;

namespace back.Data.Repositories.Abstractions
{
    public interface IQuoteRepository
    {
        IEnumerable<Quote> Quotes { get; }
        void Update(Quote quote);
    }
}
