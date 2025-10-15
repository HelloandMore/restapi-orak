using CommunityToolkit.Mvvm.Input;

namespace Train.DesktopApp.ViewModels;

[ObservableObject]
public partial class AppShellViewModel
{
    public IAsyncRelayCommand ExitCommand => new AsyncRelayCommand(OnExitAsync);

    public IAsyncRelayCommand AddNewTrainCommand => new AsyncRelayCommand(OnAddNewTrainAsync);

    public IAsyncRelayCommand ListAllTrainsCommand => new AsyncRelayCommand(OnListAllTrainsAsync);

    private async Task OnExitAsync() => Application.Current.Quit();

    private async Task OnAddNewTrainAsync()
    {
        Shell.Current.ClearNavigationStack();
        await Shell.Current.GoToAsync(CreateOrEditTrainView.Name);
    }

    private async Task OnListAllTrainsAsync()
    {
        Shell.Current.ClearNavigationStack();
        await Shell.Current.GoToAsync(TrainListView.Name);
    }
}