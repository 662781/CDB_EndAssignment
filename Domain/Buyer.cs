using Domain.BaseEntities;
using System.Text.Json.Serialization;

namespace Domain
{
    public class Buyer : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public double MonthlyIncome { get; set; }

        public virtual ICollection<Mortgage> Mortgages { get; set; }

        public virtual ICollection<MortgageApplication> Applications { get; set; }

    }
}
