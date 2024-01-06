using ClimateMonitor.Domain.Entities;
using ClimateMonitor.Domain.Repositories;
using Dommel;
using Npgsql;
using Microsoft.Extensions.Configuration;

namespace ClimateMonitor.Infra.Repositories;
public class ClimateSampleRepository : IClimateSampleRepository
{
   private readonly string? _connectionString;

   public ClimateSampleRepository(IConfiguration configuration)
   {
       _connectionString = configuration.GetConnectionString("ClimateMonitor");
   }

   public async Task<IEnumerable<ClimateSample>> GetAll()
   {
       await using var connection = new NpgsqlConnection(_connectionString);
       return await connection.GetAllAsync<ClimateSample>();
   }

   public async Task<ClimateSample?> GetById(Guid id)
   {
       await using var connection = new NpgsqlConnection(_connectionString);
       return await connection.GetAsync<ClimateSample>(id);
   }

   public async Task Create(ClimateSample climateSample)
   {
       await using var connection = new NpgsqlConnection(_connectionString);
       await connection.InsertAsync(climateSample);
   }

   public async Task Update(ClimateSample climateSample)
   {
       await using var connection = new NpgsqlConnection(_connectionString);
       await connection.UpdateAsync(climateSample);
   }

   public async Task Delete(Guid id)
   {
       await using var connection = new NpgsqlConnection(_connectionString);
       var entity =await connection.GetAsync<ClimateSample>(id);
       await connection.DeleteAsync(entity);

   }
}
