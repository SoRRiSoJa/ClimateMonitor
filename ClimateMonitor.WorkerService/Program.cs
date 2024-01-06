using ClimateMonitor.WorkerService;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostedService<DataFromStationWorker>();

var host = builder.Build();
host.Run();