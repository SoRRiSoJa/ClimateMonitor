using ClimateMonitor.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClimateMonitor.Domain.Repositories;
public interface IClimateSampleRepository
{
   Task<IEnumerable<ClimateSample>> GetAll();
   Task<ClimateSample?> GetById(Guid id);
   Task Create(ClimateSample climateSample);
   Task Update(ClimateSample climateSample);
   Task Delete(Guid id);
}
