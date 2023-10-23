using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class House
    {
        public int ID { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public double Price { get; set; }

    }
}