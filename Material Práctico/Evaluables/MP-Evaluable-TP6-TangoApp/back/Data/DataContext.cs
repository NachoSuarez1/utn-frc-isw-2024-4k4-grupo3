using back.Entities;
using Microsoft.EntityFrameworkCore;

namespace back.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<PaymentOption> PaymentOptions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Quote> Quotes { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quote>()
                .HasMany(x => x.PaymentOptions)
                .WithMany(y => y.QuotesOption)
                .UsingEntity(j => j.ToTable("Quotes_x_PaymentOptions"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
