using AzureFunctions.Domain;

namespace AzureFunctions.Service.Interfaces
{
    public interface IMortgageApplicationService
    {    
        public List<MortgageApplication> GetAllPending();

        public void UpdatePendingStatus(int id, bool newStatus);

        public void UpdateAllPendingToFalse(List<MortgageApplication> applications);
    }
}
