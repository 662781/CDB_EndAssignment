using DAL;
using Domain;
using Service.Interfaces;

namespace Service
{
    public class HouseService : IHouseService
    {
        private readonly BuyersContext _db;

        public HouseService(BuyersContext db)
        {
            _db = db;
        }

        public List<House> GetByPriceRange(float minPrice, float maxPrice)
        {
            return _db.Houses
                .Where(h => h.Price >= minPrice && h.Price <= maxPrice)
                .ToList();
        }

        public House GetById(int id)
        {
            return _db.Houses.FirstOrDefault(h => h.ID == id);
        }

        public void Create(House newHouse)
        {
            _db.Houses.Add(newHouse);
            _db.SaveChanges();
        }
    }
}
