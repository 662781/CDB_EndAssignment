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

        public double MonthlyIncome { get; set; }

        [JsonIgnore]
        public List<Mortgage> Mortgages { get; set; }

        [JsonIgnore]
        public List<MortgageApplication> Applications { get; set; }


    }
}
