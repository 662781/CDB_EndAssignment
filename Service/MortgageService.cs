using DAL;
using Domain;
using Service.Interfaces;

namespace Service
{
    public class MortgageService : IMortgageService
    {
        private readonly BuyersContext _db;
        private readonly IMortgageApplicationService _applicationService;

        public MortgageService(BuyersContext db, MortgageApplicationService applicationService)
        {
            _db = db;
            _applicationService = applicationService;
        }
        
        public void GenerateOffers()
        {
            List<MortgageApplication> pendingApplications = _applicationService.GetAllPending();

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