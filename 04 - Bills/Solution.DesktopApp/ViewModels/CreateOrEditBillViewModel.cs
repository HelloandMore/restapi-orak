namespace Solution.DesktopApp.ViewModels;

public partial class CreateOrEditBillViewModel : ObservableObject, IQueryAttributable
{
    private readonly IBillService _billService;
    private BillModelValidator validator => new BillModelValidator();
    private BillItemModelValidator itemValidator => new BillItemModelValidator();

    public IRelayCommand ValidateCommand => new AsyncRelayCommand<string>(OnValidateAsync);

    [ObservableProperty]
    private ValidationResult validationResult = new ValidationResult();

    [ObservableProperty]
    private int? billId;

    [ObservableProperty]
    private string billNumber = string.Empty;

    [ObservableProperty]
    private DateTime billDate = DateTime.Now;

    [ObservableProperty]
    private ObservableCollection<BillItemModel> items = [];

    [ObservableProperty]
    private bool isEditMode = false;

    [ObservableProperty]
    private string title = "Új számla";

    [ObservableProperty]
    private string itemName = string.Empty;

    [ObservableProperty]
    private int quantity = 1;

    [ObservableProperty]
    private decimal unitPrice = 0;

    [ObservableProperty]
    private decimal totalAmount = 0;

    public IAsyncRelayCommand AddItemCommand { get; }
    public IAsyncRelayCommand<BillItemModel> EditItemCommand { get; }
    public IAsyncRelayCommand<BillItemModel> DeleteItemCommand { get; }
    public IAsyncRelayCommand SaveCommand { get; }
    public IAsyncRelayCommand CancelCommand { get; }

    public CreateOrEditBillViewModel(IBillService billService)
    {
        _billService = billService;

        AddItemCommand = new AsyncRelayCommand(AddItemAsync);
        EditItemCommand = new AsyncRelayCommand<BillItemModel>(EditItemAsync);
        DeleteItemCommand = new AsyncRelayCommand<BillItemModel>(DeleteItemAsync);
        SaveCommand = new AsyncRelayCommand(SaveAsync);
        CancelCommand = new AsyncRelayCommand(CancelAsync);

        Items.CollectionChanged += (s, e) => CalculateTotalAmount();
    }

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("BillId", out var billIdObj) && billIdObj != null)
        {
            if (int.TryParse(billIdObj.ToString(), out var id))
            {
                IsEditMode = true;
                Title = "Számla szerkesztése";
                await LoadBillAsync(id);
            }
        }
        else
        {
            IsEditMode = false;
            Title = "Új számla";
        }
    }

    private async Task OnValidateAsync(string propertyName)
    {
        var billModel = new BillModel
        {
            Id = BillId,
            BillNumber = BillNumber,
            BillDate = BillDate,
            Items = Items.ToList()
        };
        
        validationResult = await validator.ValidateAsync(billModel);
        OnPropertyChanged(nameof(ValidationResult));
    }

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
        BillId = bill.Id;
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

    private async Task AddItemAsync()
    {
        var newItem = new BillItemModel
        {
            ItemName = ItemName,
            Quantity = Quantity,
            UnitPrice = UnitPrice
        };

        var itemValidation = await itemValidator.ValidateAsync(newItem);
        if (!itemValidation.IsValid)
        {
            var errorMessages = string.Join("\n", itemValidation.Errors.Select(e => $"• {e.ErrorMessage}"));
            await Shell.Current.DisplayAlert("Validációs hiba", errorMessages, "OK");
            return;
        }

        Items.Add(newItem);

        ItemName = string.Empty;
        Quantity = 1;
        UnitPrice = 0;
    }

    private async Task EditItemAsync(BillItemModel? item)
    {
        if (item == null) return;

        ItemName = item.ItemName ?? string.Empty;
        Quantity = item.Quantity ?? 1;
        UnitPrice = item.UnitPrice ?? 0;

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

    private async Task SaveAsync()
    {
        var billModel = new BillModel
        {
            Id = BillId,
            BillNumber = BillNumber,
            BillDate = BillDate,
            Items = Items.ToList()
        };
        
        validationResult = await validator.ValidateAsync(billModel);
        OnPropertyChanged(nameof(ValidationResult));

        if (!validationResult.IsValid)
        {
            var errorMessages = string.Join("\n", validationResult.Errors.Select(e => $"• {e.ErrorMessage}"));
            await Shell.Current.DisplayAlert("Validációs hiba", errorMessages, "OK");
            return;
        }

        if (IsEditMode)
        {
            var updateResult = await _billService.UpdateAsync(billModel);
            if (updateResult.IsError)
            {
                var errorMessage = updateResult.FirstError.Description;
                await Shell.Current.DisplayAlert("Hiba", errorMessage, "OK");
                return;
            }
        }
        else
        {
            var createResult = await _billService.CreateAsync(billModel);
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
