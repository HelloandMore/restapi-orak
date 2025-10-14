namespace Train.Api.Configurations
{
    public static class DIConfigurations
    {
        public static WebApplicationBuilder ConfigureDI(this WebApplicationBuilder builder)
        {
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddTransient<ITrainService, TrainService>();

            return builder;
        }
    }
}