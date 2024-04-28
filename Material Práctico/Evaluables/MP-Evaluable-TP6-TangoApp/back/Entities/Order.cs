namespace back.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string OriginAddress { get; set; }
        public string DestinationAddress { get; set; }
    }
}
