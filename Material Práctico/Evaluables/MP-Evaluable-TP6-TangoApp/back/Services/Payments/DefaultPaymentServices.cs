using back.Data.Repositories.Abstractions;
using back.Entities;

namespace back.Services.Payments
{
    public class DefaultPaymentServices : IPaymentServices
    {
        public PaymentOption ProcessPayment(PaymentRequest paymentRequest, IPaymentOptionRepository repository) 
        {
            var payment = repository.PaymentOptions.Where(po => po.Description == paymentRequest.PaymentOption).First();
            if (payment.IsCard()) {
                ValidateCard(paymentRequest.Card);
            }

            return payment;
        }

        void ValidateCard(CardInfo card)
        {
        }
    }
}
