using DAL;
using Domain;
using Service.Interfaces;

namespace Service
{
    public class MortgageService : IMortgageService
    {
        private readonly BuyersContext _db;
        private readonly IBuyerService _buyerService;

        public MortgageService(BuyersContext db, MortgageApplicationService applicationService, BuyerService buyerService)
        {
            _db = db;
            _buyerService = buyerService;
        }

        public void GenerateOffers(List<MortgageApplication> pendingApplications)
        {

            // Generate mortgage offers and store them in the database
            foreach (MortgageApplication application in pendingApplications)
            {
                Buyer currentBuyer = _buyerService.GetById(application.BuyerID);
                Mortgage mortgage = new Mortgage
                {
                    DepositAmount = CalcDepositAmt(currentBuyer.MonthlyIncome),
                    LoanAmount = CalcLoanAmt(currentBuyer.MonthlyIncome),
                    LoanTermMonths = CalcLoanTermMonths(currentBuyer.MonthlyIncome),
                    InterestRate = CalcInterestRate(currentBuyer.MonthlyIncome),
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