namespace back.Entities.DTOs
{
    public class QuoteDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string PickUpDate { get; set; }
        public string DeliveryDate { get; set; }
        public int Amount { get; set; }
        public string Transport { get; set; }
        public string State { get; set; }
        public string? SelectedPaymentOption { get; set; }
        public List<string> PaymentOptions { get; set; }

        public static QuoteDTO ToDTO(Quote q)
        {
            return new QuoteDTO() {
                Id = q.Id,
                OrderId = q.OrderId,
                PickUpDate = q.PickUpDate,
                DeliveryDate = q.DeliveryDate,
                Amount = q.Amount,
                Transport = $"{q.Transport.FirstName} {q.Transport.LastName}",
                State = q.State.Description,
                SelectedPaymentOption = q.SelectedPaymentOption?.Description,
                PaymentOptions = q.PaymentOptions.Select(x => x.Description).ToList()
            };
        }
    }
}
