using AzureFunctions.Service;
using AzureFunctions.Service.Interfaces;
using AzureFunctions.Domain;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureFunctions.Functions
{
    public class SendMortgageOffers
    {
        private readonly ILogger _logger;
        private readonly IMortgageService _mortgageService;

        public SendMortgageOffers(ILoggerFactory loggerFactory, IMortgageService mortgageService)
        {
            _logger = loggerFactory.CreateLogger<SendMortgageOffers>();
            _mortgageService = mortgageService;
        }

        [Function("SendMortgageOffers")]
        public void Run([TimerTrigger("*/20 * * * * *")] MyInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            List<Mortgage> mortgages = _mortgageService.GetAllFromToday();
            if (mortgages.Count > 0)
            {
                _mortgageService.NotifyBuyers(mortgages);
                _logger.LogInformation($"Emails send to buyers");
            }
            else
            {
                _logger.LogInformation($"No mortgages found from today, no emails sent.");
            }
            
            _logger.LogInformation($"Next timer schedule at: UNKNOWN");
        }
    }

}
