namespace Train.DesktopApp.ViewModels;

public partial class CreateOrEditTrainViewModel(
    AppDbContext dbContext,
    ITrainService trainService,
    IGoogleDriveService googleDriveService) : TrainModel, IQueryAttributable
{
    #region life cycle commands
    public IAsyncRelayCommand AppearingCommand => new AsyncRelayCommand(OnAppearingAsync);
    public IAsyncRelayCommand DisappearingCommand => new AsyncRelayCommand(OnDisappearingAsync);
    #endregion

    public IRelayCommand ValidateCommand => new AsyncRelayCommand<string>(OnValidateAsync);

    #region event commands
    public IAsyncRelayCommand SubmitCommand => new AsyncRelayCommand(OnSubmitAsync);
    public IAsyncRelayCommand ImageSelectCommand => new AsyncRelayCommand(OnImageSelectAsync);
    #endregion

    private TrainModelValidator validator => new TrainModelValidator();

    [ObservableProperty]
    private ValidationResult validationResult = new ValidationResult();

    private delegate Task ButtonActionDelegate();
    private ButtonActionDelegate asyncButtonAction;

    [ObservableProperty]
    private string title;

    [ObservableProperty]
    private IList<string> trainTypes = ["High-speed train", "Electric train", "Diesel train", "Steam train", "Freight train", "Passenger train"];

    [ObservableProperty]
    private ImageSource image;

    private FileResult selectedFile = null;

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        bool hasValue = query.TryGetValue("Train", out object result);

        if(!hasValue)
        {
            asyncButtonAction = OnSaveAsync;
            Title = "Add new train";
            return;
        }

        TrainModel train = result as TrainModel;

        this.Id = train.Id;
        this.Name = train.Name;
        this.Type = train.Type;
        this.BuildDate = train.BuildDate;
        this.MaxSpeed = train.MaxSpeed;
        this.Weight = train.Weight;
        this.Length = train.Length;
        this.Gauge = train.Gauge;
        this.Power = train.Power;
        this.ImageId = train.ImageId;
        this.WebContentLink = train.WebContentLink;

        if(!string.IsNullOrEmpty(train.WebContentLink))
        {
            Image = new UriImageSource
            {
                Uri = new Uri(train.WebContentLink),
                CacheValidity = new TimeSpan(10, 0, 0, 0)
            };
        }

        asyncButtonAction = OnUpdateAsync;
        Title = "Update train";
    }

    private async Task OnAppearingAsync()
    {
    }

    private async Task OnDisappearingAsync()
    { }

    private async Task OnSubmitAsync() => await asyncButtonAction();

    private async Task OnSaveAsync()
    {
        this.ValidationResult = await validator.ValidateAsync(this);

        if (!ValidationResult.IsValid)
        {
            return;
        }

        if(selectedFile is not null)
        {
            var uploadResult = await googleDriveService.UploadFileAsync(selectedFile);

            if (uploadResult.IsError)
            {
                await Application.Current.MainPage.DisplayAlert("Error", uploadResult.FirstError.Description, "OK");
                return;
            }

            this.ImageId = uploadResult.Value.Id;
            this.WebContentLink = uploadResult.Value.WebContentLink;
        }

        var result = await trainService.CreateAsync(this);

        var message = result.IsError ? result.FirstError.Description : "Train saved.";
        var title = result.IsError ? "Error" : "Information";

        await Application.Current.MainPage.DisplayAlert(title, message, "OK");

        if (!result.IsError)
        {
            await Shell.Current.GoToAsync("..");
        }
    }

    private async Task OnUpdateAsync()
    {
        this.ValidationResult = await validator.ValidateAsync(this);

        if (!ValidationResult.IsValid)
        {
            return;
        }

        if (selectedFile is not null)
        {
            var uploadResult = await googleDriveService.UploadFileAsync(selectedFile);

            if (uploadResult.IsError)
            {
                await Application.Current.MainPage.DisplayAlert("Error", uploadResult.FirstError.Description, "OK");
                return;
            }

            this.ImageId = uploadResult.Value.Id;
            this.WebContentLink = uploadResult.Value.WebContentLink;
        }

        var result = await trainService.UpdateAsync(this);

        var message = result.IsError ? result.FirstError.Description : "Train updated.";
        var title = result.IsError ? "Error" : "Information";

        await Application.Current.MainPage.DisplayAlert(title, message, "OK");

        if (!result.IsError)
        {
            await Shell.Current.GoToAsync("..");
        }
    }

    private async Task OnImageSelectAsync()
    {
        try
        {
            var customFileType =
                DeviceInfo.Platform == DevicePlatform.iOS || DeviceInfo.Platform == DevicePlatform.MacCatalyst
                    ? new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                    {
                        { DevicePlatform.iOS, new[] { "public.image" } },
                        { DevicePlatform.MacCatalyst, new[] { "public.image" } }
                    })
                    : FilePickerFileType.Images;

            selectedFile = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = customFileType,
                PickerTitle = "Select an image"
            });

            if (selectedFile is not null)
            {
                using var fileStream = await selectedFile.OpenReadAsync();
                using var memoryStream = new MemoryStream();
                await fileStream.CopyToAsync(memoryStream);
                memoryStream.Position = 0;
                
                // Create a new MemoryStream that won't be disposed
                var imageBytes = memoryStream.ToArray();
                Image = ImageSource.FromStream(() => new MemoryStream(imageBytes));
            }
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", $"Failed to pick image: {ex.Message}", "OK");
        }
    }

    private async Task OnValidateAsync(string propertyName)
    {
        this.ValidationResult = await validator.ValidateAsync(this);
        OnPropertyChanged(nameof(ValidationResult));
    }
}