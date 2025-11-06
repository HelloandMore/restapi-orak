namespace Solution.DesktopApp.ViewModels;

public partial class AppShellViewModel : ObservableObject
{
    public IAsyncRelayCommand ExitCommand => new AsyncRelayCommand(OnExitAsync);

    public IAsyncRelayCommand AddNewBillCommand => new AsyncRelayCommand(OnAddNewBillAsync);

    public IAsyncRelayCommand ListAllBillsCommand => new AsyncRelayCommand(OnListAllBillsAsync);

    private async Task OnExitAsync()
    {
        Application.Current?.Quit();
        await Task.CompletedTask;
    }

    private async Task OnAddNewBillAsync()
    {
        await Shell.Current.GoToAsync(nameof(CreateOrEditBillView));
    }

    private async Task OnListAllBillsAsync()
    {
        await Shell.Current.GoToAsync(nameof(BillListView));
    }
}

