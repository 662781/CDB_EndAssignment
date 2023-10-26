using DAL.Repositories.Interfaces;
using Domain;
using Service.Interfaces;

namespace Service
{
    public class MortgageApplicationService : IMortgageApplicationService
    {
        private readonly IMortgageApplicationRepo _applicationRepo;

        public MortgageApplicationService(IMortgageApplicationRepo applicationRepository)
        {
            _applicationRepo = applicationRepository;
        }

        public List<MortgageApplication> GetAllByBuyerId(int id)
        {
            return _applicationRepo.GetAllByBuyerId(id);
        }

        public MortgageApplication GetById(int id)
        {
            return _applicationRepo.GetById(id);
        }

        public MortgageApplication Create(CreateApplicationDTO applicationDTO)
        {
            MortgageApplication application = new MortgageApplication
            {
                HouseID = applicationDTO.HouseID,
                IsPending = true,
                BuyerID = applicationDTO.BuyerID
            };
            return _applicationRepo.Create(application);
        }

        public List<MortgageApplication> GetAllPending()
        {
            return _applicationRepo.GetAllPending();
        }
    }
}
