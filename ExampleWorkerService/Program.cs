using ExampleWorkerService;


IConfiguration configuration = new ConfigurationBuilder()
                            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                            .AddJsonFile("appsettings.json")
                            .Build();

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService(options =>
    {
        options.ServiceName = "ExampleWorkerService";
    }).ConfigureServices(services =>
    {
        services.Configure<WorkerSettings>(configuration.GetSection("WorkerSettings"));
        
        services.AddHostedService<Worker>();
    }).Build();




await host.RunAsync();
