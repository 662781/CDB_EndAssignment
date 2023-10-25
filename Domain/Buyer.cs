using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain
{
    public class Buyer : BaseEntity
    {
        [MaxLength(60)]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public double MonthlyIncome { get; set; }

        [JsonIgnore]
        public virtual ICollection<Mortgage> Mortgages { get; set; }

        [JsonIgnore]
        public virtual ICollection<MortgageApplication> Applications { get; set; }

    }
}
