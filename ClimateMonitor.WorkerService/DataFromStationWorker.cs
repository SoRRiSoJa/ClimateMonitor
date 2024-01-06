using System.Text;
using ClimateMonitor.Domain.Entities;
using ClimateMonitor.Domain.Repositories;
using ClimateMonitor.Infra.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace ClimateMonitor.WorkerService;

public class DataFromStationWorker: BackgroundService
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly IClimateSampleRepository _climateSampleRepository;
    private readonly IOptions<RabbitMqConfig>? _configuration;
    public DataFromStationWorker(IOptions<RabbitMqConfig>? configuration,IClimateSampleRepository climateSampleRepository)
    {
        _configuration = configuration;
        var factory = new ConnectionFactory() { HostName = _configuration?.Value?.HostName }; 
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _climateSampleRepository = climateSampleRepository;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await DownloadAllMessages();
    }
    private async Task DownloadAllMessages()
    {
        var messages = _channel.BasicGet(_configuration?.Value?.QueueName, autoAck: true);

        while (messages != null)
        {
            var body = messages.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            var climateSample = JsonConvert.DeserializeObject<ClimateSample>(message);
            if (climateSample is not null)
            {
                await _climateSampleRepository.Create(climateSample);    
            } 
            messages =  _channel.BasicGet(_configuration?.Value?.QueueName, autoAck: true);
        }
        _connection.Close();
    }
}