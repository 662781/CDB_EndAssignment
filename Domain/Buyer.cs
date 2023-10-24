using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain
{
    public class Buyer
    {
        public int ID { get; set; }

        [MaxLength(60)]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public double MonthlyIncome { get; set; }

        public virtual ICollection<Mortgage> Mortgages { get; set; }

        public virtual ICollection<MortgageApplication> Applications { get; set; }


    }
}
