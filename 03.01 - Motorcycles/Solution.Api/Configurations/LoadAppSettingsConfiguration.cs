namespace Solution.Api.Configurations;

public static class LoadAppSettingsConfiguration
{
    public static WebApplicationBuilder LoadAppSettingsVariables(this WebApplicationBuilder builder)
    {
        var env = builder.Configuration.GetValue<string>("Environment");

        builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
                             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                             .AddJsonFile($"appsettings.{env}.json", true)
                             .AddEnvironmentVariables();
        return builder;
    }
}
