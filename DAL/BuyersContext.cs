using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class BuyersContext : DbContext
    {
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Mortgage> Mortgages { get; set; }
        public DbSet<MortgageApplication> Applications { get; set; }

        public BuyersContext(DbContextOptions<BuyersContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<House>()
                .HasOne(h => h.Mortgage)
                .WithOne(m => m.House)
                .HasForeignKey<Mortgage>(m => m.HouseID)
                .IsRequired();

            builder.Entity<Mortgage>()
                .HasOne(m => m.House)
                .WithOne(h => h.Mortgage)
                .HasForeignKey<House>(h => h.MortgageID)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
