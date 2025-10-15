using Train.Core.Models.Settings;

namespace Train.DesktopApp.Configurations;

public static class AppSettingsConfiguration
{
    public static MauiAppBuilder UseAppSettingsMapping(this MauiAppBuilder builder)
    {
        var googleDriveSettings = builder.Configuration.GetRequiredSection("GoogleDrive").Get<GoogleDriveSettings>();
        
        if (googleDriveSettings != null)
        {
            builder.Services.AddSingleton<GoogleDriveSettings>(googleDriveSettings);
        }

        return builder;
    }
}