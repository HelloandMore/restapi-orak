namespace Train.DesktopApp.ViewModels;

[ObservableObject]
public partial class TrainListViewModel(ITrainService trainService)
{
    #region life cycle commands
    public IAsyncRelayCommand AppearingCommand => new AsyncRelayCommand(OnAppearingAsync);
    public IAsyncRelayCommand DisappearingCommand => new AsyncRelayCommand(OnDisappearingAsync);
    #endregion

    #region paging commands
    public ICommand PreviousPageCommand { get; private set; }
    public ICommand NextPageCommand { get; private set; }
    #endregion

    #region component commands
    public IAsyncRelayCommand DeleteCommand => new AsyncRelayCommand<string>((id) => OnDeleteAsync(id));
    #endregion

    [ObservableProperty]
    private ObservableCollection<TrainModel> trains;

    private int page = 1;
    private bool isLoading = false;
    private bool hasNextPage = false;
    private int numberOfTrainsInDB = 0;

    private async Task OnAppearingAsync()
    {
        PreviousPageCommand = new Command(async () => await OnPreviousPageAsync(), () => page > 1 && !isLoading);
        NextPageCommand = new Command(async () => await OnNextPageAsync(), () => !isLoading && hasNextPage);

        await LoadTrainsAsync();
    }

    private async Task OnDisappearingAsync()
    { }

    private async Task OnPreviousPageAsync()
    {
        if (isLoading) return;

        page = page <= 1 ? 1 : --page;
        await LoadTrainsAsync();
    }

    private async Task OnNextPageAsync()
    {
        if (isLoading) return;

        page++;
        await LoadTrainsAsync();
    }

    private async Task LoadTrainsAsync()
    {
        isLoading = true;

        var result = await trainService.GetPagedAsync(page);

        if (result.IsError)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Trains not loaded!", "OK");
            return;
        }

        Trains = new ObservableCollection<TrainModel>(result.Value.Items);
        numberOfTrainsInDB = result.Value.Count;

        hasNextPage = numberOfTrainsInDB - (page * 10) > 0;
        isLoading = false;

        ((Command)PreviousPageCommand).ChangeCanExecute();
        ((Command)NextPageCommand).ChangeCanExecute();
    }

    private async Task OnDeleteAsync(string? id)
    { 
        var result = await trainService.DeleteAsync(id);

        var message = result.IsError ? result.FirstError.Description : "Train deleted.";
        var title = result.IsError ? "Error" : "Information";

        if (!result.IsError)
        {
            var train = trains.SingleOrDefault(x => x.Id == id);
            trains.Remove(train);

            if(trains.Count == 0)
            {
                await LoadTrainsAsync();
            }
        }

        await Application.Current.MainPage.DisplayAlert(title, message, "OK");
    }
}