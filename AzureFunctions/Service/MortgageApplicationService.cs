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

        public void UpdatePendingStatus(int id, bool newStatus)
        {
            _applicationRepo.UpdatePendingStatus(id, newStatus);
        }

        public void UpdateAllPendingToFalse(List<MortgageApplication> applications)
        {
            foreach (MortgageApplication app in applications)
            {
                UpdatePendingStatus(app.ID, false);
            }
        }
    }
}
