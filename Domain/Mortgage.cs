using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Mortgage : BaseEntity
    {
        public double DepositAmount { get; set; }

        public double LoanAmount { get; set; }

        public int LoanTermMonths { get; set; }

        public double InterestRate { get; set; }

        public byte[] Created { get; set; }

        public int BuyerID { get; set; }

        public virtual Buyer Buyer { get; set; }

        public int HouseID { get; set; }
        public virtual House House { get; set; }

    }
}
