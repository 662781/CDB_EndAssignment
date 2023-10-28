using AzureFunctions.Domain;

namespace AzureFunctions.Service.Interfaces
{
    public interface IMortgageService
    {
        public void GenerateOffers(List<MortgageApplication> pendingApplications);

        public void NotifyBuyers();

        public List<Mortgage> GetAllFromToday();

        protected double CalcDepositAmt(double income);

        protected double CalcLoanAmt(double income);

        protected int CalcLoanTermMonths(double income);

        protected double CalcInterestRate(double income);

    }
}
