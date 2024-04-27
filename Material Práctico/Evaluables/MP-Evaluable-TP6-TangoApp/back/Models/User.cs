using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back.Models
{
    [Table("Users")]
    public class User
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("qualification")]
        public int Qualification { get; set; }

        public List<Order> Orders { get; set; }

        public User(int id, string firstName, string lastName, string email, int qualification, List<Order> orders)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Qualification = qualification;
            Orders = orders;
        }
    }
}
