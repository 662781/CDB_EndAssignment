using AzureFunctions.DAL.Repositories;
using AzureFunctions.DAL.Repositories.Interfaces;
using AzureFunctions.Domain;
using AzureFunctions.Service.Interfaces;

namespace AzureFunctions.Service
{
    public class MortgageApplicationService : IMortgageApplicationService
    {
        private readonly IMortgageApplicationRepo _applicationRepo;

        public MortgageApplicationService(IMortgageApplicationRepo applicationRepo)
        {
            _applicationRepo = applicationRepo;
        }

        public List<MortgageApplication> GetAllPending()
        {
            return _applicationRepo.GetAllPending();
        }
    }
}
