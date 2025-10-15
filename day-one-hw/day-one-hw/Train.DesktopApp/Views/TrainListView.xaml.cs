namespace Train.DesktopApp.Views;

public partial class TrainListView : ContentPage
{
    public TrainListViewModel ViewModel => this.BindingContext as TrainListViewModel;

    public static string Name => nameof(TrainListView);

    public TrainListView(TrainListViewModel viewModel)
    {
        this.BindingContext = viewModel;

        InitializeComponent();
    }
}