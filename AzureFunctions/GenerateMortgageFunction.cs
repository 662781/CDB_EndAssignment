using Domain;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Service;
using Service.Interfaces;

namespace AzureFunctions
{
    public class GenerateMortgageFunction
    {
        private readonly ILogger _logger;
        private readonly IMortgageService _mortgageService;
        private readonly IMortgageApplicationService _applicationService;

        public GenerateMortgageFunction(ILoggerFactory loggerFactory, MortgageService mortgageService, MortgageApplicationService applicationService)
        {
            _logger = loggerFactory.CreateLogger<GenerateMortgageFunction>();
            _mortgageService = mortgageService;
            _applicationService = applicationService;
        }

        /// <summary>
        /// This Azure Functions timer-triggered function is responsible for generating mortgage offers based on pending applications and logging the results.
        /// </summary>
        /// <param name="myTimer">The timer trigger that specifies the schedule for running this function.</param>
        [Function("GenerateMortgageFunction")]
        public void Run([TimerTrigger("*/20 * * * * *")] MyInfo myTimer)
        {
            try
            {
                _logger.LogInformation($"Timer function started. Next schedule: {myTimer.ScheduleStatus.Next}");

                List<MortgageApplication> pendingApplications = _applicationService.GetAllPending();

                if (pendingApplications.Count > 0)
                {
                    _mortgageService.GenerateOffers(pendingApplications);
                    _logger.LogInformation("Mortgage offers generated.");
                }
                else
                {
                    _logger.LogInformation("No applications pending, no offers were created.");
                }

                _logger.LogInformation($"Timer function completed at: {DateTime.Now}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

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
