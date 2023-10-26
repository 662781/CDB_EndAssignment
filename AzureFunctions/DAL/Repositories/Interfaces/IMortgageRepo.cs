using AzureFunctions.Domain;

namespace AzureFunctions.DAL.Repositories.Interfaces
{
    public interface IMortgageRepo
    {
        public void Create(Mortgage mortgage);
    }
}
