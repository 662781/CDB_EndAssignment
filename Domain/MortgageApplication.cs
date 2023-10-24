using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MortgageApplication
    {
        public int ID { get; set; }

        [Required]
        public int HouseID { get; set; }
        
        [Required]
        public bool IsPending { get; set; }
        
        [Required]
        public int BuyerID { get; set; }
    }
}
