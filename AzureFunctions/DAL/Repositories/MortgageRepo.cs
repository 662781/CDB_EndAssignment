using AzureFunctions.DAL.Repositories.Interfaces;
using AzureFunctions.Domain;
using Microsoft.EntityFrameworkCore;

namespace AzureFunctions.DAL.Repositories
{
    public class MortgageRepo : IMortgageRepo
    {
        private readonly MortgageContext _db;

        public MortgageRepo(MortgageContext db)
        {
            _db = db;
        }
        public void Create(Mortgage mortgage)
        {
            _db.Mortgages.Add(mortgage);
            _db.SaveChanges();
        }

        public List<Mortgage> GetAllFromToday()
        {
            return _db.Mortgages
                .Where(m => m.Created.Date == DateTime.Today)
                .Include(m => m.Buyer)
                .ToList();
        }
    }
}
