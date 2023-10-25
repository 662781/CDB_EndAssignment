using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain
{
    public class MortgageApplication : BaseEntity
    {
        public int HouseID { get; set; }
        
        public bool IsPending { get; set; }
        
        public int BuyerID { get; set; }

        [JsonIgnore]
        public virtual Buyer Buyer { get; set; }
    }
}
