using DAL;
using Domain;
using Service.Interfaces;

namespace Service
{
    public class MortgageService : IMortgageService
    {
        private readonly BuyersContext _db;

        public MortgageService(BuyersContext db, MortgageApplicationService applicationService)
        {
            _db = db;
        }

        public void GenerateOffers(List<MortgageApplication> pendingApplications)
        {

            // Generate mortgage offers and store them in the database
            foreach (MortgageApplication application in pendingApplications)
            {
                Mortgage mortgage = new Mortgage
                {
                    DepositAmount = CalcDepositAmt(application.Buyer.MonthlyIncome),
                    LoanAmount = CalcLoanAmt(application.Buyer.MonthlyIncome),
                    LoanTermMonths = CalcLoanTermMonths(application.Buyer.MonthlyIncome),
                    InterestRate = CalcInterestRate(application.Buyer.MonthlyIncome),
                    BuyerID = application.BuyerID,
                    HouseID = application.HouseID
                };

                _db.Mortgages.Add(mortgage);
                _db.SaveChanges();
            }
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