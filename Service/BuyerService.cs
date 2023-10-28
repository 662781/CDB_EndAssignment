using Domain;
using Domain.DTO;
using Service.Interfaces;
using DAL.Repositories;
using DAL.Repositories.Interfaces;

namespace Service
{
    public class BuyerService : IBuyerService
    {
        private readonly IBuyerRepo _buyerRepo;

        public BuyerService(BuyerRepo buyerRepo)
        {
            _buyerRepo = buyerRepo;
        }

        public Buyer GetById(int id)
        {
            return _buyerRepo.GetById(id);
        }

        public Buyer Create(CreateBuyerDTO buyerDTO)
        {
            Buyer buyer = new Buyer
            {
                FirstName = buyerDTO.FirstName,
                LastName = buyerDTO.LastName,
                MonthlyIncome = buyerDTO.MonthlyIncome,
                Email = buyerDTO.Email
            };
            return _buyerRepo.Create(buyer);
        }
    }
}
