namespace Solution.Api.Configurations;

public static class DIConfiguration
{
    public static WebApplicationBuilder ConfigureDI(this WebApplicationBuilder builder)
    {
        // Services
        builder.Services.AddTransient<IMotorcycleService, MotorcycleService>();
        // Http Context Accessor
        builder.Services.AddHttpContextAccessor();
        return builder;
    }
}
