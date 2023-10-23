using DAL;
namespace Service
{
    public class BuyerService
    {
        private readonly BuyersContext _db;

        public BuyerService(BuyersContext db)
        {
            _db = db;
        }
    }
}
