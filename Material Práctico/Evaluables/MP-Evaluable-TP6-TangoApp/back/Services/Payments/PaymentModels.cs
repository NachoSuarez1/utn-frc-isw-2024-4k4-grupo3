namespace back.Services.Payments
{
    public class PaymentRequest
    {
        public string PaymentOption { get; set; }
        public CardInfo? Card { get; set; }
    }

    public class CardInfo
    {

    }

    public class PaymentResponse
    {

    }
}
