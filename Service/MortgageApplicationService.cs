using DAL;
using Domain;
using Service.Interfaces;

namespace Service
{
    public class MortgageApplicationService : IMortgageApplicationService
    {
        private readonly BuyersContext _db;

        public MortgageApplicationService(BuyersContext db)
        {
            _db = db;
        }

        public List<MortgageApplication> GetAllByBuyerId(int id)
        {
            return _db.Applications
                .Where(a => a.Buyer.ID == id)
                .ToList();
        }

        public MortgageApplication GetById(int id)
        {
            return _db.Applications.FirstOrDefault(h => h.ID == id);
        }

        public void Create(MortgageApplication newApplication)
        {
            newApplication.IsPending = true;
            _db.Applications.Add(newApplication);
            _db.SaveChanges();
        }

        public List<MortgageApplication> GetAllPending()
        {
            return _db.Applications
                .Where(app => app.IsPending == true)
                .ToList();
        }
    }
}
