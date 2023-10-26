using Domain;

namespace DAL.Repositories.Interfaces
{
    public interface IHouseRepo
    {
        List<House> GetByPriceRange(float minPrice, float maxPrice);
        House GetById(int id);
        House Create(House house);
    }
}
