namespace Train.DesktopApp.Configurations;

public static class DIConfiguration
{
    public static MauiAppBuilder UseDIConfiguration(this MauiAppBuilder builder)
    {
        // ViewModels
        builder.Services.AddTransient<AppShellViewModel>();
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<TrainListViewModel>();
        builder.Services.AddTransient<CreateOrEditTrainViewModel>();

        // Views
        builder.Services.AddTransient<MainView>();
        builder.Services.AddTransient<TrainListView>();
        builder.Services.AddTransient<CreateOrEditTrainView>();

        // Services
        builder.Services.AddScoped<IGoogleDriveService, GoogleDriveService>();
        builder.Services.AddTransient<ITrainService, TrainService>();

        return builder;
    }
}