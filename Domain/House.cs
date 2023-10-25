using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class House : BaseEntity
    {
        [Required]
        public string Address { get; set; }

        [Required]
        public double Price { get; set; }

    }
}