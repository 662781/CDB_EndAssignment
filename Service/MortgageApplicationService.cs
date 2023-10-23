using DAL;

namespace Service
{
    public class MortgageApplicationService
    {
        private readonly BuyersContext _db;

        public MortgageApplicationService(BuyersContext db)
        {
            _db = db;
        }
    }
}
