using Microsoft.EntityFrameworkCore;

namespace back.Entities
{
    [PrimaryKey(nameof(Id), nameof(OrderId))]
    public class Quote
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public string PickUpDate { get; set; }
        public string DeliveryDate { get; set; }
        public int Amount { get; set; }
        public User Transport { get; set; }
        public State State { get; set; }
        public PaymentOption? SelectedPaymentOption { get; set; }
        public ICollection<PaymentOption> PaymentOptions { get; set; }
    }
}
