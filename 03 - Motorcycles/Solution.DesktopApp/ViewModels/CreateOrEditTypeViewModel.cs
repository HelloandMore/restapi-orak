using Solution.Database.Migrations;

namespace Solution.DesktopApp.ViewModels;

public partial class CreateOrEditTypeViewModel(
    AppDbContext dbContext,
    ITypeService typeService) : TypeModel, IQueryAttributable
{
    #region life cycle commands
    public IAsyncRelayCommand AppearingCommand => new AsyncRelayCommand(OnAppearingAsync);
    public IAsyncRelayCommand DisappearingCommand => new AsyncRelayCommand(OnDisappearingAsync);
    #endregion

    public IRelayCommand ValidateCommand => new AsyncRelayCommand<string>(OnValidateAsync);

    #region event commands
    public IAsyncRelayCommand SubmitCommand => new AsyncRelayCommand(OnSubmitAsync);
    #endregion

    private TypeModelValidator validator => new TypeModelValidator();

    [ObservableProperty]
    private ValidationResult validationResult = new ValidationResult();

    private delegate Task ButtonActionDelegate();
    private ButtonActionDelegate asyncButtonAction;

    [ObservableProperty]
    private string title;

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        bool hasValue = query.TryGetValue("Type", out object result);

        if (!hasValue)
        {
            asyncButtonAction = OnSaveAsync;
            this.title = "Add new type";
            return;
        }

        TypeModel type = result as TypeModel;

        this.Id = type.Id;
        this.Name = type.Name;

        asyncButtonAction = OnUpdateAsync;
        this.title = "Update type";
    }

    private async Task OnAppearingAsync()
    {
    }

    private async Task OnDisappearingAsync()
    { }

    private async Task OnSubmitAsync() => await asyncButtonAction();

    private async Task OnSaveAsync()
    {
        this.validationResult = await validator.ValidateAsync(this);

        if (!this.validationResult.IsValid)
        {
            return;
        }

        var result = await typeService.CreateAsync(this);
        var message = result.IsError ? result.FirstError.Description : "Type saved.";
        var title = result.IsError ? "Error" : "Information";

        if (!result.IsError)
        {
            ClearForm();
        }

        await Application.Current.MainPage.DisplayAlert(title, message, "OK");
    }

    private async Task OnUpdateAsync()
    {
        this.validationResult = await validator.ValidateAsync(this);

        if (!this.validationResult.IsValid)
        {
            return;
        }

        var result = await typeService.UpdateAsync(this);
        var message = result.IsError ? result.FirstError.Description : "Type updated.";
        var title = result.IsError ? "Error" : "Information";

        await Application.Current.MainPage.DisplayAlert(title, message, "OK");
    }

    private void ClearForm()
    {
        this.Name = null;
    }

    private async Task OnValidateAsync(string propertyName)
    {
        var result = await validator.ValidateAsync(this, options => options.IncludeProperties(propertyName));

        this.validationResult.Errors.Remove(this.validationResult.Errors.FirstOrDefault(x => x.PropertyName == propertyName));
        this.validationResult.Errors.Remove(this.validationResult.Errors.FirstOrDefault(x => x.PropertyName == TypeModelValidator.GlobalProperty));
        this.validationResult.Errors.AddRange(result.Errors);

        OnPropertyChanged(nameof(ValidationResult));
    }
}
