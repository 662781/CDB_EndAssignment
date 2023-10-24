using DAL;
using Domain;
using System.Security.Cryptography;

namespace Service
{
    public class BuyerService
    {
        private readonly BuyersContext _db;

        public BuyerService(BuyersContext db)
        {
            _db = db;
        }

        public Buyer GetById(int id)
        {
            return _db.Buyers.FirstOrDefault(b => b.ID == id);
        }

        public void Create(Buyer newBuyer)
        {
            _db.Buyers.Add(newBuyer);
            _db.SaveChanges();
        }
    }
}
