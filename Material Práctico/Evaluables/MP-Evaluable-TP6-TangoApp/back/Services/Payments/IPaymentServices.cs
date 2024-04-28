using back.Data.Repositories.Abstractions;
using back.Entities;

namespace back.Services.Payments
{
    public interface IPaymentServices
    {
        public PaymentOption ProcessPayment(PaymentRequest paymentRequest, IPaymentOptionRepository repository);
    }
}
