using AzureFunctions.Domain.BaseEntities;
using System.Text.Json.Serialization;

namespace AzureFunctions.Domain
{
    public class House : BaseEntity
    {
        public string Address { get; set; }

        public double Price { get; set; }

        public virtual Mortgage Mortgage { get; set; }

    }
}