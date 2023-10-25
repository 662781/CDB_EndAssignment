using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain
{
    public class Buyer : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double MonthlyIncome { get; set; }

        [JsonIgnore]
        public virtual ICollection<Mortgage> Mortgages { get; set; }

        [JsonIgnore]
        public virtual ICollection<MortgageApplication> Applications { get; set; }

    }
}
