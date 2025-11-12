namespace Solution.DesktopApp.ViewModels;

public partial class BillListViewModel : ObservableObject
{
    private readonly IBillService _billService;

    [ObservableProperty]
    private ObservableCollection<BillModel> bills = [];

    [ObservableProperty]
    private int currentPage = 1;

    [ObservableProperty]
    private int totalPages = 1;

    [ObservableProperty]
    private bool isLoading = false;

    [ObservableProperty]
    private string pageInfo = "1 / 1";

    public IAsyncRelayCommand LoadBillsCommand => new AsyncRelayCommand(LoadBillsAsync);
    public IAsyncRelayCommand<BillModel> EditBillCommand => new AsyncRelayCommand<BillModel>(EditBillAsync);
    public IAsyncRelayCommand<BillModel> DeleteBillCommand => new AsyncRelayCommand<BillModel>(DeleteBillAsync);
    public IAsyncRelayCommand NextPageCommand { get; private set; }
    public IAsyncRelayCommand PreviousPageCommand { get; private set; }

    public BillListViewModel(IBillService billService)
    {
        _billService = billService;

        NextPageCommand = new AsyncRelayCommand(NextPageAsync, () => CurrentPage < TotalPages);
        PreviousPageCommand = new AsyncRelayCommand(PreviousPageAsync, () => CurrentPage > 1);
    }

    public async Task InitializeAsync()
    {
        await LoadBillsAsync();
    }

    private async Task LoadBillsAsync()
    {
        IsLoading = true;
        try
        {
            var result = await _billService.GetPagedAsync(CurrentPage);

            if (result.IsError)
            {
                await Shell.Current.DisplayAlert("Hiba", "Nem sikerült betölteni a számlákat.", "OK");
                return;
            }

            Bills.Clear();
            foreach (var bill in result.Value.Items)
            {
                Bills.Add(bill);
            }

            TotalPages = result.Value.TotalPages;
            PageInfo = $"{CurrentPage} / {TotalPages}";

            NextPageCommand.NotifyCanExecuteChanged();
            PreviousPageCommand.NotifyCanExecuteChanged();
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Hiba", $"Váratlan hiba történt: {ex.Message}", "OK");
        }
        finally
        {
            IsLoading = false;
        }
    }

    private async Task EditBillAsync(BillModel? bill)
    {
        if (bill == null || !bill.Id.HasValue) return;

        var navigationParameter = new Dictionary<string, object>
        {
            { "BillId", bill.Id.Value.ToString() }
        };

        await Shell.Current.GoToAsync(nameof(CreateOrEditBillView), navigationParameter);
    }

    private async Task DeleteBillAsync(BillModel? bill)
    {
        if (bill == null) return;

        bool confirmed = await Shell.Current.DisplayAlert(
            "Megerősítés",
            $"Biztosan törölni szeretné a következő számlát: {bill.BillNumber} ?",
            "Igen",
            "Nem");

        if (!confirmed) return;

        var result = await _billService.DeleteAsync(bill.Id!.Value);

        if (result.IsError)
        {
            await Shell.Current.DisplayAlert("Hiba", "Nem sikerült törölni a számlát.", "OK");
            return;
        }

        await Shell.Current.DisplayAlert("Siker", "A számla sikeresen törölve.", "OK");
        await LoadBillsAsync();
    }

    private async Task NextPageAsync()
    {
        if (isLoading) return;

        CurrentPage++;
        await LoadBillsAsync();
    }

    private async Task PreviousPageAsync()
    {
        if (isLoading) return;

        if (CurrentPage > 1)
        {
            CurrentPage--;
            await LoadBillsAsync();
        }
    }
}
