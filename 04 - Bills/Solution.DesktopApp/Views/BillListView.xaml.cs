namespace Solution.DesktopApp.Views;

public partial class BillListView : ContentPage
{
    private readonly BillListViewModel _viewModel;

    public BillListView(BillListViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.InitializeAsync();
    }
}
