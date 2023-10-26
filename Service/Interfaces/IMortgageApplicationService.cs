using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IMortgageApplicationService
    {
        public List<MortgageApplication> GetAllByBuyerId(int id);

        public MortgageApplication GetById(int id);

        public MortgageApplication Create(CreateApplicationDTO applicationDTO);
    }
}
