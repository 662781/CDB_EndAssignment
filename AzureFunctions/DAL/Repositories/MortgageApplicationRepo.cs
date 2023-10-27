using AzureFunctions.DAL.Repositories.Interfaces;
using AzureFunctions.Domain;
using Microsoft.EntityFrameworkCore;

namespace AzureFunctions.DAL.Repositories
{
    public class MortgageApplicationRepo : IMortgageApplicationRepo
    {
        private readonly MortgageContext _db;

        public MortgageApplicationRepo(MortgageContext db)
        {
            _db = db;
        }

        public List<MortgageApplication> GetAllPending()
        {
            return _db.Applications
                .Where(app => app.IsPending == true)
                .Include(app => app.Buyer)
                .ToList();
        }
    }
}
