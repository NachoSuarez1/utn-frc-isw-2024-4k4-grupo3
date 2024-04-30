namespace back.Services.Payments
{
    public class PaymentRequest
    {
        public string PaymentOption { get; set; }
        public CardInfo? Card { get; set; }
    }

    public class CardInfo
    {
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public string Pin { get; set; }
        public string FullName { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType()) return false;
            var card = obj as CardInfo;

            return CardType == card.CardType && 
                   CardNumber == card.CardNumber && 
                   Pin == card.Pin &&
                   FullName == card.FullName &&
                   DocumentType == card.DocumentType &&
                   DocumentNumber == card.DocumentNumber;
        }
    }
}
