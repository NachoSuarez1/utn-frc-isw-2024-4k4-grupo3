using System.ComponentModel.DataAnnotations.Schema;

namespace back.Entities
{
    public class PaymentOption
    {
        public int Id { get; set; }
        public string Description { get; set; }

        [InverseProperty("PaymentOptions")]
        public ICollection<Quote> QuotesOption { get; set; }

        [InverseProperty("SelectedPaymentOption")]
        public ICollection<Quote> QuotesSelected { get; set; }

        public bool IsCard() => Id == 1;
    }
}
