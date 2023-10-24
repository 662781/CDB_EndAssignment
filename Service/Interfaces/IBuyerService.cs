using DAL;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IBuyerService
    {
        public Buyer GetById(int id);

        public void Create(Buyer newBuyer);
    }
}
