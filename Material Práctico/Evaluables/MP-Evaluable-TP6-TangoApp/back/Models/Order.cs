using System.ComponentModel.DataAnnotations.Schema;

namespace back.Models
{
    [Table("Orders")]
    public class Order
    {
        [Column("id")]
        public int Id { get; set; }

        public List<Quote> Quotes { get; set; }

        public Order(int id, List<Quote> quotes)
        {
            Id = id;
            Quotes = quotes;
        }
    }
}
