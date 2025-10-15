namespace Train.DesktopApp;

public partial class AppShell : Shell
{
    public AppShellViewModel ViewModel => this.BindingContext as AppShellViewModel;

    public AppShell(AppShellViewModel viewModel)
    {
        this.BindingContext = viewModel;

        InitializeComponent();

        ConfigureShellNavigation();
    }

    private static void ConfigureShellNavigation()
    {
        // MainView route is already defined in AppShell.xaml as ShellContent, no need to register here
        Routing.RegisterRoute(TrainListView.Name, typeof(TrainListView));
        Routing.RegisterRoute(CreateOrEditTrainView.Name, typeof(CreateOrEditTrainView));
    }
}