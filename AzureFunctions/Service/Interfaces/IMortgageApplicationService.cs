using AzureFunctions.Domain;

namespace AzureFunctions.Service.Interfaces
{
    public interface IMortgageApplicationService
    {    
        public List<MortgageApplication> GetAllPending();
    }
}
