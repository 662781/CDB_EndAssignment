using AzureFunctions.DAL.Repositories;
using AzureFunctions.DAL.Repositories.Interfaces;
using AzureFunctions.Domain;
using AzureFunctions.Service.Interfaces;

namespace AzureFunctions.Service
{
    public class MortgageService : IMortgageService
    {
        private readonly IMortgageRepo _mortgageRepo;

        public MortgageService(IMortgageRepo mortgageRepo)
        {
            _mortgageRepo = mortgageRepo;
        }
        public List<Mortgage> GenerateOffers(List<MortgageApplication> pendingApplications)
        {
            List<Mortgage> newMortgages = new List<Mortgage>();
            // Generate mortgage offers and store them in the database
            foreach (MortgageApplication application in pendingApplications)
            {
                Mortgage mortgage = new Mortgage()
                {
                    DepositAmount = CalcDepositAmt(application.Buyer.MonthlyIncome),
                    LoanAmount = CalcLoanAmt(application.Buyer.MonthlyIncome),
                    LoanTermMonths = CalcLoanTermMonths(application.Buyer.MonthlyIncome),
                    InterestRate = CalcInterestRate(application.Buyer.MonthlyIncome),
                    BuyerID = application.BuyerID,
                    HouseID = application.HouseID
                };

                newMortgages.Add(mortgage);
                _mortgageRepo.Create(mortgage);
            }

            return newMortgages;
        }

        public void NotifyBuyers()
        {

        }

        public double CalcDepositAmt(double income)
        {
            return 0.0;
        }

        public double CalcLoanAmt(double income)
        {
            return 0.0;
        }

        public int CalcLoanTermMonths(double income)
        {
            return 0;
        }

        public double CalcInterestRate(double income)
        {
            return 0.0;
        }
    }
}