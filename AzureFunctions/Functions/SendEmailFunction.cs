using AzureFunctions.Service;
using AzureFunctions.Service.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureFunctions.Functions
{
    public class SendEmailFunction
    {
        private readonly ILogger _logger;
        private readonly IMortgageService _mortgageService;

        public SendEmailFunction(ILoggerFactory loggerFactory, MortgageService mortgageService)
        {
            _logger = loggerFactory.CreateLogger<SendEmailFunction>();
            _mortgageService = mortgageService;
        }

        [Function("SendEmailFunction")]
        public void Run([TimerTrigger("59 23 * * *")] MyInfo myTimer)
        {
            _mortgageService.NotifyBuyers();
            _logger.LogInformation($"Emails send");
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
        }
    }

}
