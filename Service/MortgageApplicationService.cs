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
                .Where(a => a.BuyerID == id)
                .ToList();
        }

        public MortgageApplication GetById(int id)
        {
            return _db.Applications.FirstOrDefault(h => h.ID == id);
        }

        public MortgageApplication Create(CreateApplicationDTO applicationDTO)
        {
            MortgageApplication application = new MortgageApplication
            {
                HouseID = applicationDTO.HouseID,
                IsPending = true,
                BuyerID = applicationDTO.BuyerID
            };
            _db.Applications.Add(application);
            _db.SaveChanges();
            return application;
        }

        public List<MortgageApplication> GetAllPending()
        {
            return _db.Applications
                .Where(app => app.IsPending == true)
                .ToList();
        }
    }
}
