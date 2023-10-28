using Domain.BaseEntities;
using System.Text.Json.Serialization;

namespace Domain
{
    public class MortgageApplication : MortgageBase
    {
        public bool IsPending { get; set; }

        public virtual Buyer Buyer { get; set; }
    }
}
