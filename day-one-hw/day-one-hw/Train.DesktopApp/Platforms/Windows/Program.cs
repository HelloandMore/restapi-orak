using Microsoft.UI.Xaml;

namespace Train.DesktopApp.WinUI;

public class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        Microsoft.UI.Xaml.Application.Start(_ => new MauiWinUIApplication());
    }

    public class MauiWinUIApplication : Microsoft.Maui.MauiWinUIApplication
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}