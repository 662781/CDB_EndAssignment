using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.BaseEntities
{
    [NotMapped]
    public abstract class MortgageBase
    {
        public int ID { get; set; }

        public int BuyerID { get; set; }

        public int HouseID { get; set; }
    }
}
