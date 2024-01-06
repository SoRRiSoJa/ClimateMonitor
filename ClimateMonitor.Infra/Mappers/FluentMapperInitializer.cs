using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;

namespace ClimateMonitor.Infra.Mappers;

public class FluentMapperInitializer
{
    public static void Initialize()
    {
        FluentMapper.Initialize(config =>
        {
            config.AddMap(new ClimateSampleMap());
            config.ForDommel();
        });
    }
}