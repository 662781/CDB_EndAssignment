using DAL;
using Domain;

namespace Service
{
    public class MortgageService
    {
        private readonly BuyersContext _db;

        public MortgageService(BuyersContext db)
        {
            _db = db;
        }
        
        public void GenerateOffers()
        {
            // Retrieve pending mortgage applications
            List<MortgageApplication> pendingApplications = _db.Applications
                .Where(app => app.IsPending == true)
                .ToList();

            // Only continue if the list contains applications
            if (pendingApplications.Count > 0)
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
                        HouseID = application.HouseID
                    };

                    _db.Mortgages.Add(mortgage);
                    _db.SaveChanges();
                }
            }
        }

        public void NotifyBuyers()
        {

        }

        private static double CalcDepositAmt(double income)
        {
            return 0.0;
        }

        private static double CalcLoanAmt(double income)
        {
            return 0.0;
        }

        private static int CalcLoanTermMonths(double income)
        {
            return 0;
        }

        private static double CalcInterestRate(double income)
        {
            return 0.0;
        }
    }
}