using AzureFunctions.DAL.Repositories.Interfaces;
using AzureFunctions.Domain;
using Google.Protobuf.WellKnownTypes;
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
            DateTime today = DateTime.Now.Date;
            return _db.Mortgages
                .Where(m => new DateTime(BitConverter.ToInt64(m.Created, 0)) == today)
                .Include(m => m.Buyer)
                .ToList();
        }
    }
}
