using DAL.Repositories.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class HouseRepo : IHouseRepo
    {
        private readonly BuyersContext _db;

        public HouseRepo(BuyersContext db)
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

        public House Create(House house)
        {
            _db.Houses.Add(house);
            _db.SaveChanges();
            return house;
        }
    }
}

