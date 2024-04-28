using back.Entities;

namespace back.Data.Repositories.Abstractions
{
    public interface IPaymentOptionRepository
    {
        IEnumerable<PaymentOption> PaymentOptions { get; }

        PaymentOption GetPaymentOption(int id);
        PaymentOption GetPaymentOption(string type);
    }
}
