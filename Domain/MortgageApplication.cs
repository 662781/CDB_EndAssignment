using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MortgageApplication
    {
        public int ID { get; set; }

        public int HouseID { get; set; }

        public bool IsPending { get; set; }

        public virtual Buyer Buyer { get; set; }
    }
}
