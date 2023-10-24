using Domain;

namespace Service.Interfaces
{
    public interface IHouseService
    {
        public List<House> GetByPriceRange(float minPrice, float maxPrice);

        public House GetById(int id);

        public void Create(House newHouse);
    }
}
