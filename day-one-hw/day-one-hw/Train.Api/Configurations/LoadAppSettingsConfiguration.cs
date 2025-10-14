namespace Train.Api.Configurations
{
    public static class LoadAppSettingsConfiguration
    {
        public static WebApplicationBuilder LoadAppSettingsVariables(this WebApplicationBuilder builder)
        {
            var environment = builder.Environment.EnvironmentName;

            builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true)
                .AddJsonFile($"appsettings.{environment}.json", true)
                .AddEnvironmentVariables();

            return builder;
        }
    }
}