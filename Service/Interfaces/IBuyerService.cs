using Domain;
using Domain.DTO;

namespace Service.Interfaces
{
    public interface IBuyerService
    {
        public Buyer GetById(int id);

        public Buyer Create(CreateBuyerDTO buyerDTO);
    }
}
