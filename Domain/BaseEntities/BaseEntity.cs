using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.BaseEntities
{
    [NotMapped]
    public abstract class BaseEntity
    {
        public int ID { get; set; }
    }
}
