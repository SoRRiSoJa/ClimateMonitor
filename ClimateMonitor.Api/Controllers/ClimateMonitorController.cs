using ClimateMonitor.Domain.Entities;
using ClimateMonitor.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClimateMonitor.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ClimateMonitorController: ControllerBase
{
    private readonly IClimateSampleRepository _climateSampleRepository;
    public ClimateMonitorController(IClimateSampleRepository climateSampleRepository)
    {
        _climateSampleRepository = climateSampleRepository;
    }   
    [HttpGet]
    public async Task<IEnumerable<ClimateSample>> GetAll()
    {
        return await _climateSampleRepository.GetAll();
    }
    [HttpGet("{id}")]
    public async Task<ClimateSample> GetById(Guid id)
    {
        return await _climateSampleRepository.GetById(id);
    }

    [HttpPost]
    public async Task Create(ClimateSample climateSample)
    {
        var samples = ClimateSample.GenerateRandomSamples(10);
        foreach (var sample in samples)
        {
            await _climateSampleRepository.Create(sample);
        }
    }
}