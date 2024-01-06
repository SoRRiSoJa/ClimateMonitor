using System;
namespace ClimateMonitor.Domain.Entities;

public class ClimateSample
{
    public Guid Id { get; set; } 
    public decimal TemperatureDHT22 { get; set; }
    public decimal TemperatureCCS811 { get; set; }
    public decimal TemperatureBMP280 { get; set; }
    public decimal TemperatureAHT20 { get; set; }
    public decimal HumidityAHT20 { get; set; }
    public decimal HumidityDHT22 { get; set; }
    public decimal PressureBMP280 { get; set; }
    public decimal ECO2 { get; set; }
    public decimal TEVOC { get; set; }
    public decimal PrecipitationHouer { get; set; }
    public int PrecipitationDay { get; set; }
    public DateTime Date { get; set; }  
    public override string ToString()
    {
        return $"Date: {Date} - TemperatureDHT22: {TemperatureDHT22} - TemperatureCCS811: {TemperatureCCS811} - TemperatureBMP280: {TemperatureBMP280} - TemperatureAHT20: {TemperatureAHT20} - HumidityAHT20: {HumidityAHT20} - HumidityDHT22: {HumidityDHT22} - PressureBMP280: {PressureBMP280} - ECO2: {ECO2} - TEVOC: {TEVOC} - PrecipitationHouer: {PrecipitationHouer} - PrecipitationDay: {PrecipitationDay}";
    }

    public static List<ClimateSample> GenerateRandomSamples(int sample)
    {
     Random random = new Random();
     List<ClimateSample> samples = new List<ClimateSample>();
     var tempStandard = 45;
     var humidityStandard = 60;
     for (var i = 0; i < sample; i++)
     {
         var newSample = new ClimateSample
         {
             Id = Guid.NewGuid(),
             TemperatureDHT22 = Convert.ToDecimal(random.NextDouble() * tempStandard + 1),
             TemperatureCCS811 = Convert.ToDecimal(random.NextDouble() * tempStandard + 1),
             TemperatureBMP280 = Convert.ToDecimal(random.NextDouble() * tempStandard + 1),
             TemperatureAHT20 = Convert.ToDecimal(random.NextDouble() * tempStandard + 1),
             HumidityAHT20 = Convert.ToDecimal(random.NextDouble() * humidityStandard + 1),
             HumidityDHT22 = Convert.ToDecimal(random.NextDouble() * humidityStandard + 1),
             PressureBMP280 = Convert.ToDecimal(random.NextDouble() * 1000 + 1),
             ECO2 = Convert.ToDecimal(random.NextDouble() * 400 + 1),
             TEVOC = Convert.ToDecimal(random.NextDouble() * 800 + 1),
             PrecipitationHouer = Convert.ToDecimal(random.NextInt64() * 25 + 1),
             PrecipitationDay = 35,
             Date = DateTime.Now
         };
             samples.Add(newSample);
     }
     return samples;
    }
 }
