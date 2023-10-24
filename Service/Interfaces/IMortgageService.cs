using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IMortgageService
    {
        public void GenerateOffers();

        public void NotifyBuyers();

        protected double CalcDepositAmt(double income);

        protected double CalcLoanAmt(double income);

        protected int CalcLoanTermMonths(double income);

        protected double CalcInterestRate(double income);

    }
}
