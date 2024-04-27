namespace back.Services.Payments
{
    public interface IPaymentsServices
    {
        PaymentResult ProcessPayment(PaymentInfo paymentInfo);
    }
}
