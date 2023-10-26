using AzureFunctions.DAL.Repositories.Interfaces;
using AzureFunctions.Domain;

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
                .ToList();
        }
    }
}
