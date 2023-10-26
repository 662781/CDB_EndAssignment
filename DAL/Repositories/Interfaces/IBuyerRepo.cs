using Domain;

namespace DAL.Repositories.Interfaces
{
    public interface IBuyerRepo
    {
        Buyer GetById(int id);
        Buyer Create(Buyer buyer);
    }
}
