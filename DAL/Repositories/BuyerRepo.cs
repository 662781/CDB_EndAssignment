using DAL.Repositories.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class BuyerRepo : IBuyerRepo
    {
        private readonly BuyersContext _db;

        public BuyerRepo(BuyersContext db)
        {
            _db = db;
        }

        public Buyer GetById(int id)
        {
            return _db.Buyers.FirstOrDefault(b => b.ID == id);
        }

        public Buyer Create(Buyer buyer)
        {
            _db.Buyers.Add(buyer);
            _db.SaveChanges();
            return buyer;
        }
    }
}
