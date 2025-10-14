namespace Train.DesktopApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        ConfigureShellNavigation();
    }

    private static void ConfigureShellNavigation()
    {
        Routing.RegisterRoute(MainView.Name, typeof(MainView));
        Routing.RegisterRoute(TrainListView.Name, typeof(TrainListView));
    }
}