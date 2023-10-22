using DAL;
using Domain;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureFunctions
{
    public class GenerateMortgageFunction
    {
        private readonly ILogger _logger;
        private readonly BuyersContext _db;

        public GenerateMortgageFunction(ILoggerFactory loggerFactory, BuyersContext buyersContext)
        {
            _logger = loggerFactory.CreateLogger<GenerateMortgageFunction>();
            _db = buyersContext;
        }

        [Function("Function1")]
        public void Run([TimerTrigger("54 23 * * *")] MyInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            Generate();
        }

        private void Generate()
        {
            // Retrieve pending mortgage applications
            var pendingApplications = _db.Applications
                .Where(app => app.IsPending == true)
                .ToList();

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

    public class MyInfo
    {
        public MyScheduleStatus ScheduleStatus { get; set; }

        public bool IsPastDue { get; set; }
    }

    public class MyScheduleStatus
    {
        public DateTime Last { get; set; }

        public DateTime Next { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
