using Domain;
using Domain.DTO;

namespace Service.Interfaces
{
    public interface IHouseService
    {
        public List<House> GetByPriceRange(float minPrice, float maxPrice);

        public House GetById(int id);

        public House Create(CreateHouseDTO houseDTO);
    }
}
