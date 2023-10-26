using AzureFunctions.Domain;
using Microsoft.EntityFrameworkCore;

namespace AzureFunctions.DAL
{
    public class MortgageContext : DbContext
    {
        public DbSet<Mortgage> Mortgages { get; set; }
        public DbSet<MortgageApplication> Applications { get; set; }

        public MortgageContext(DbContextOptions<MortgageContext> options) : base(options) { }
    }
}
