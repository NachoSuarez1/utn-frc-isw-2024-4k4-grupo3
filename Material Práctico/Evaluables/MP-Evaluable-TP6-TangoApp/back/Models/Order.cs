namespace back.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<Quote> Quotes { get; set; }

        public Order(int id, List<Quote> quotes)
        {
            Id = id;
            Quotes = quotes;
        }
    }
}
