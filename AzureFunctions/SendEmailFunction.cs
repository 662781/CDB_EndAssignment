using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureFunctions
{
    public class SendEmailFunction
    {
        private readonly ILogger _logger;

        public SendEmailFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<SendEmailFunction>();
        }

        [Function("Function2")]
        public void Run([TimerTrigger("59 23 * * *")] MyInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
        }
    }

}
