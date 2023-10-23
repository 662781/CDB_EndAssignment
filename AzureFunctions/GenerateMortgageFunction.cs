using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Service;

namespace AzureFunctions
{
    public class GenerateMortgageFunction
    {
        private readonly ILogger _logger;
        private readonly MortgageService _mortgageService;

        public GenerateMortgageFunction(ILoggerFactory loggerFactory, MortgageService mortgageService)
        {
            _logger = loggerFactory.CreateLogger<GenerateMortgageFunction>();
            _mortgageService = mortgageService;
        }

        [Function("Function1")]
        public void Run([TimerTrigger("54 23 * * *")] MyInfo myTimer)
        {
            _mortgageService.GenerateOffers();
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            _logger.LogInformation($"Mortgage Offers generated");
            _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
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
