using AzureFunctions.Domain.BaseEntities;
using System.Text.Json.Serialization;

namespace AzureFunctions.Domain
{
    public class Buyer : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double MonthlyIncome { get; set; }

        [JsonIgnore]
        public virtual ICollection<Mortgage> Mortgages { get; set; }

        [JsonIgnore]
        public List<MortgageApplication> Applications { get; set; }

    }
}
