using Microsoft.Extensions.Configuration;

namespace Train.DesktopApp.Configurations;

public static class AppConfiguration
{
    public static MauiAppBuilder UseAppConfigurations(this MauiAppBuilder builder)
    {
#if DEBUG
        var file = "appSettings.Development.json";
#else
        var file = "appSettings.Production.json";
#endif
        var stream = new MemoryStream(File.ReadAllBytes($"{file}"));

        var config = new ConfigurationBuilder()
                    .AddJsonStream(stream)
                    .Build();

        builder.Configuration.AddConfiguration(config);

        return builder;
    }
}