using DAL;
using Domain;
using Domain.DTO;
using Service.Interfaces;

namespace Service
{
    public class BuyerService :IBuyerService
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

        public Buyer Create(CreateBuyerDTO buyerDTO)
        {
            Buyer buyer = new Buyer
            {
                FirstName = buyerDTO.FirstName,
                LastName = buyerDTO.LastName,
                MonthlyIncome = buyerDTO.MonthlyIncome
            };
            _db.Buyers.Add(buyer);
            _db.SaveChanges();
            return buyer;
        }
    }
}
