using Domain;

namespace DAL.Repositories.Interfaces
{
    public interface IMortgageApplicationRepo
    {
        List<MortgageApplication> GetAllByBuyerId(int id);
        MortgageApplication GetById(int id);
        MortgageApplication Create(MortgageApplication application);
        List<MortgageApplication> GetAllPending();
    }
}
