using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [NotMapped]
    public abstract class BaseEntity
    {
        public int ID { get; set; }
    }
}
