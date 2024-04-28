using back.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace back.Repositories
{
    public class EFDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<PaymentOption> PaymentOptions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Quote> Quotes { get; set; }
    }
}
