using System.ComponentModel.DataAnnotations;
using Domain.BaseEntities;

namespace Domain
{
    public class Mortgage : MortgageBase
    {
        public double DepositAmount { get; set; }

        public double LoanAmount { get; set; }

        public int LoanTermMonths { get; set; }

        public double InterestRate { get; set; }

        public DateTime Created { get; set; }

        public virtual Buyer Buyer { get; set; }

        public virtual House House { get; set; }

    }
}
