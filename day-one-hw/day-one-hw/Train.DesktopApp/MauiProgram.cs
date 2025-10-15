using CommunityToolkit.Maui.Markup;
using Train.DesktopApp.Configurations;
using Syncfusion.Maui.Core.Hosting;
using Syncfusion.Maui.Toolkit.Hosting;

namespace Train.DesktopApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>()
               .UseMauiCommunityToolkit()
               .ConfigureSyncfusionCore()
               .ConfigureSyncfusionToolkit()
               .UseMauiCommunityToolkitMarkup()
               .UseFontConfiguration()
               .UseAppConfigurations()
               .UseAppSettingsMapping()
               .UseDIConfiguration()
               .UseMsSqlServer();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
