using AzureFunctions.Domain;

namespace AzureFunctions.DAL.Repositories.Interfaces
{
    public interface IMortgageApplicationRepo
    {
        List<MortgageApplication> GetAllPending();

        void UpdatePendingStatus(int id, bool newStatus);
    }
}
