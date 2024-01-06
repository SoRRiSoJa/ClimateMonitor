using ClimateMonitor.Domain.Entities;
using Dapper.FluentMap.Dommel.Mapping;

namespace ClimateMonitor.Infra.Mappers;

public class ClimateSampleMap:  DommelEntityMap<ClimateSample>
{
    public ClimateSampleMap()
    {
        ToTable("ClimateSamples");
        Map(x => x.Id).ToColumn("Id").IsKey();           
        Map(x => x.TemperatureDHT22).ToColumn("TemperatureDHT22");
        Map(x => x.TemperatureCCS811).ToColumn("TemperatureCCS811");
        Map(x => x.TemperatureBMP280).ToColumn("TemperatureBMP280");
        Map(x => x.TemperatureAHT20).ToColumn("TemperatureAHT20");
        Map(x => x.HumidityAHT20).ToColumn("HumidityAHT20");
        Map(x => x.HumidityDHT22).ToColumn("HumidityDHT22");
        Map(x => x.PressureBMP280).ToColumn("PressureBMP280");
        Map(x => x.ECO2).ToColumn("ECO2");
        Map(x => x.TEVOC).ToColumn("TEVOC");
        Map(x => x.PrecipitationHouer).ToColumn("PrecipitationHouer");
        Map(x => x.PrecipitationDay).ToColumn("PrecipitationDay");
        Map(x => x.Date).ToColumn("Date"); 
    }
}