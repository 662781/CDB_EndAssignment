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

    }
}
