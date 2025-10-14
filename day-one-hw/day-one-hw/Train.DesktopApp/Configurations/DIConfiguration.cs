namespace Train.DesktopApp.Configurations;

public static class DIConfiguration
{
    public static MauiAppBuilder UseDIConfiguration(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<ITrainService, TrainService>();

        return builder;
    }
}