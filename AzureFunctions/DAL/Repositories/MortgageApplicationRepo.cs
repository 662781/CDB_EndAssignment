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

        public void UpdatePendingStatus(int id, bool newStatus)
        {
            MortgageApplication application = _db.Applications.FirstOrDefault(app => app.ID == id);

            if (application != null)
            {
                application.IsPending = newStatus;
                _db.SaveChanges();
            }
        }
    }
}
