using Microsoft.Extensions.Options;

namespace ExampleWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly WorkerSettings _settings;

        public Worker(ILogger<Worker> logger, IOptions<WorkerSettings> settings)
        {
            _logger = logger;
            _settings = settings.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}" + _settings.Author, DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}