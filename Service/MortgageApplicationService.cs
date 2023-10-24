using DAL;
using Domain;

namespace Service
{
    public class MortgageApplicationService
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
    }
}
