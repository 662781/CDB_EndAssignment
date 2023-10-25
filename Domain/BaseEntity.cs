using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [NotMapped]
    public abstract class BaseEntity
    {
        public int ID { get; set; }
    }
}
