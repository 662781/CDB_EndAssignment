using Domain.BaseEntities;
using System.Text.Json.Serialization;

namespace Domain
{
    public class House : BaseEntity
    {
        public string Address { get; set; }

        public double Price { get; set; }

        [JsonIgnore]
        public virtual Mortgage Mortgage { get; set; }

    }
}