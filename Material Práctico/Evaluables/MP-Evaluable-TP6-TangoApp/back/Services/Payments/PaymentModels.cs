namespace back.Services.Payments
{
    public class PaymentResult
    {
    }

    public class PaymentInfo
    {
    }

    public class PaymentException : Exception
    {
        public PaymentException(string message) : base(message)
        {
        }
    }
}
