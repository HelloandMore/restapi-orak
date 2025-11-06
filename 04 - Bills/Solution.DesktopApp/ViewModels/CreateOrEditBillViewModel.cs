namespace Solution.DesktopApp.ViewModels;

public partial class CreateOrEditBillViewModel : ObservableObject, IQueryAttributable
{
    private readonly IBillService _billService;

    [ObservableProperty]
    private int? billId;

    [ObservableProperty]
    private string billNumber = string.Empty;

    [ObservableProperty]
    private DateTime billDate = DateTime.Now;
            
    [ObservableProperty]
    private ObservableCollection<BillItemModel> items = [];

    [ObservableProperty]
    private string itemName = string.Empty;

    [ObservableProperty]
    private int quantity = 1;

    [ObservableProperty]
    private decimal unitPrice = 0;

    [ObservableProperty]
    private decimal totalAmount = 0;

    [ObservableProperty]
    private bool isEditMode = false;

    [ObservableProperty]
    private string title = "Új számla";

    public IAsyncRelayCommand AddItemCommand { get; }
    public IAsyncRelayCommand<BillItemModel> EditItemCommand { get; }
    public IAsyncRelayCommand<BillItemModel> DeleteItemCommand { get; }
    public IAsyncRelayCommand SaveCommand { get; }
    public IAsyncRelayCommand CancelCommand { get; }

    public CreateOrEditBillViewModel(IBillService billService)
    {
        _billService = billService;

        AddItemCommand = new AsyncRelayCommand(AddItemAsync, CanAddItem);
        EditItemCommand = new AsyncRelayCommand<BillItemModel>(EditItemAsync);
        DeleteItemCommand = new AsyncRelayCommand<BillItemModel>(DeleteItemAsync);
        SaveCommand = new AsyncRelayCommand(SaveAsync, CanSave);
        CancelCommand = new AsyncRelayCommand(CancelAsync);

        Items.CollectionChanged += (s, e) =>
        {
            CalculateTotalAmount();
            SaveCommand.NotifyCanExecuteChanged();
        };
    }

    // Handle the navigation parameter
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("BillId", out var billIdObj) && billIdObj != null)
        {
            if (int.TryParse(billIdObj.ToString(), out var id))
            {
                BillId = id;
            }
        }
    }

    partial void OnBillIdChanged(int? value)
    {
        if (value.HasValue)
        {
            IsEditMode = true;
            Title = "Számla szerkesztése";
            _ = LoadBillAsync(value.Value);
        }
        else
        {
            IsEditMode = false;
            Title = "Új számla";
        }
    }

    partial void OnItemNameChanged(string value) => AddItemCommand.NotifyCanExecuteChanged();
    partial void OnQuantityChanged(int value) => AddItemCommand.NotifyCanExecuteChanged();
    partial void OnUnitPriceChanged(decimal value) => AddItemCommand.NotifyCanExecuteChanged();

    private async Task LoadBillAsync(int id)
    {
        var result = await _billService.GetByIdAsync(id);

        if (result.IsError)
        {
            await Shell.Current.DisplayAlert("Hiba", "Nem sikerült betölteni a számlát.", "OK");
            await Shell.Current.GoToAsync("..");
            return;
        }

        var bill = result.Value;
        BillNumber = bill.BillNumber ?? string.Empty;
        BillDate = bill.BillDate ?? DateTime.Now;

        Items.Clear();
        if (bill.Items != null)
        {
            foreach (var item in bill.Items)
            {
                Items.Add(item);
            }
        }

        CalculateTotalAmount();
    }

    private bool CanAddItem()
    {
        return !string.IsNullOrWhiteSpace(ItemName) 
               && Quantity >= 1 
               && UnitPrice >= 1;
    }

    private async Task AddItemAsync()
    {
        var newItem = new BillItemModel
        {
            ItemName = ItemName,
            Quantity = Quantity,
            UnitPrice = UnitPrice
        };

        Items.Add(newItem);

        // Clear input fields
        ItemName = string.Empty;
        Quantity = 1;
        UnitPrice = 0;

        await Task.CompletedTask;
    }

    private async Task EditItemAsync(BillItemModel? item)
    {
        if (item == null) return;

        // Populate input fields with item data for editing
        ItemName = item.ItemName ?? string.Empty;
        Quantity = item.Quantity ?? 1;
        UnitPrice = item.UnitPrice ?? 0;

        // Remove the item from the list (will be re-added when Add is clicked)
        Items.Remove(item);

        await Task.CompletedTask;
    }

    private async Task DeleteItemAsync(BillItemModel? item)
    {
        if (item == null) return;

        bool confirmed = await Shell.Current.DisplayAlert(
            "Megerősítés",
            $"Biztosan törölni szeretné a következő tételt: {item.ItemName} ?",
            "Igen",
            "Nem");

        if (!confirmed) return;

        Items.Remove(item);
    }

    private void CalculateTotalAmount()
    {
        TotalAmount = Items.Sum(i => (i.Quantity ?? 0) * (i.UnitPrice ?? 0));
    }

    private bool CanSave()
    {
        return Items.Count > 0;
    }

    private async Task SaveAsync()
    {
        if (string.IsNullOrWhiteSpace(BillNumber))
        {
            await Shell.Current.DisplayAlert("Hiányzó adat", "Kérem adja meg a számlaszámot.", "OK");
            return;
        }

        var bill = new BillModel
        {
            Id = BillId,
            BillNumber = BillNumber,
            BillDate = BillDate,
            Items = Items.ToList()
        };

        if (IsEditMode)
        {
            var updateResult = await _billService.UpdateAsync(bill);
            if (updateResult.IsError)
            {
                var errorMessage = updateResult.FirstError.Description;
                await Shell.Current.DisplayAlert("Hiba", errorMessage, "OK");
                return;
            }
        }
        else
        {
            var createResult = await _billService.CreateAsync(bill);
            if (createResult.IsError)
            {
                var errorMessage = createResult.FirstError.Description;
                await Shell.Current.DisplayAlert("Hiba", errorMessage, "OK");
                return;
            }
        }

        await Shell.Current.DisplayAlert("Siker", 
            IsEditMode ? "A számla sikeresen módosítva." : "A számla sikeresen létrehozva.", 
            "OK");
        
        await Shell.Current.GoToAsync("..");
    }

    private async Task CancelAsync()
    {
        bool confirmed = await Shell.Current.DisplayAlert(
            "Megerősítés",
            "Biztosan megszakítja? A nem mentett változások elvesznek.",
            "Igen",
            "Nem");

        if (confirmed)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
