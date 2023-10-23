using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Mortgage
    {
        public int ID { get; set; }

        [Required]
        public double DepositAmount { get; set; }

        [Required]
        public double LoanAmount { get; set; }

        [Required]
        public int LoanTermMonths { get; set; }

        [Required]
        public double InterestRate { get; set; }

        [Required]
        [Timestamp,DataType("timestamp")]
        public byte[] TimeStamp { get; set; }

        public virtual Buyer Buyer { get; set; }

        [Required]
        public int HouseID { get; set; }

    }
}
