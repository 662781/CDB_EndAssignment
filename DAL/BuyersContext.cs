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

        public BuyersContext(DbContextOptions<BuyersContext> options) : base(options) { }

        // Handle all property requirements and relations between entities.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Mortgage class
            modelBuilder.Entity<Mortgage>()
                .Property(m => m.DepositAmount)
                .IsRequired();

            modelBuilder.Entity<Mortgage>()
                .Property(m => m.LoanAmount)
                .IsRequired();

            modelBuilder.Entity<Mortgage>()
                .Property(m => m.LoanTermMonths)
                .IsRequired();

            modelBuilder.Entity<Mortgage>()
                .Property(m => m.InterestRate)
                .IsRequired();

            modelBuilder.Entity<Mortgage>()
                .Property(p => p.Created)
                .HasColumnType("timestamp")
                .HasDefaultValueSql("GetDate() ");

            modelBuilder.Entity<Mortgage>()
                .Property(m => m.HouseID)
                .IsRequired();

            // Configure Buyer class
            modelBuilder.Entity<Buyer>()
                .Property(b => b.FirstName)
                .IsRequired()
                .HasMaxLength(60);

            modelBuilder.Entity<Buyer>()
                .Property(b => b.LastName)
                .IsRequired();

            modelBuilder.Entity<Buyer>()
                .Property(b => b.MonthlyIncome)
                .IsRequired();

            // Configure House class
            modelBuilder.Entity<House>()
                .Property(h => h.Address)
                .IsRequired();

            modelBuilder.Entity<House>()
                .Property(h => h.Price)
                .IsRequired();

            // Configure MortgageApplication class
            modelBuilder.Entity<MortgageApplication>()
                .Property(a => a.HouseID)
                .IsRequired();

            modelBuilder.Entity<MortgageApplication>()
                .Property(a => a.IsPending)
                .IsRequired();

            modelBuilder.Entity<MortgageApplication>()
                .Property(a => a.BuyerID)
                .IsRequired();

            // Define relationships
            modelBuilder.Entity<Buyer>()
                .HasMany(b => b.Mortgages)
                .WithOne(m => m.Buyer)
                .HasForeignKey(m => m.BuyerID);

            modelBuilder.Entity<Buyer>()
                .HasMany(b => b.Applications)
                .WithOne(a => a.Buyer)
                .HasForeignKey(a => a.BuyerID);

            modelBuilder.Entity<House>()
                .HasOne(h => h.Mortgage)
                .WithOne(m => m.House)
                .HasForeignKey<Mortgage>(m => m.HouseID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
