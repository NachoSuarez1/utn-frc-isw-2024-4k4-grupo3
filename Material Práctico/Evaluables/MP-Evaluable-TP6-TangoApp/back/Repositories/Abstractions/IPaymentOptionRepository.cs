using back.Models;

namespace back.Repositories.Abstractions
{
    public interface IPaymentOptionRepository
    {
        IEnumerable<PaymentOption> PaymentOptions { get; }
    }
}
