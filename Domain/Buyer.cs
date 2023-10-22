using System.ComponentModel.DataAnnotations;

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

        //Use LazyLoading
        public virtual ICollection<Mortgage> Mortgages { get; set; }
        public virtual ICollection<House> Houses { get; set; }

        //Use EagerLoading
        //public List<Mortgage> Mortgages { get; set; }

    }
}
