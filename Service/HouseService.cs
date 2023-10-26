using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Domain;
using Domain.DTO;
using Service.Interfaces;

namespace Service
{
    public class HouseService : IHouseService
    {
        private readonly IHouseRepo _houseRepo;

        public HouseService(HouseRepo houseRepo)
        {
            _houseRepo = houseRepo;
        }

        public List<House> GetByPriceRange(float minPrice, float maxPrice)
        {
            return _houseRepo.GetByPriceRange(minPrice, maxPrice);
        }

        public House GetById(int id)
        {
            return _houseRepo.GetById(id);
        }

        public House Create(CreateHouseDTO houseDTO)
        {
            House newHouse = new House()
            {
                Address = houseDTO.Address,
                Price = houseDTO.Price
            };
            return _houseRepo.Create(newHouse);
        }
    }
}
