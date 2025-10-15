namespace Train.DesktopApp.Components;

public partial class TrainListComponent : ContentView
{
    public static readonly BindableProperty TrainProperty = BindableProperty.Create(
         propertyName: nameof(Train),
         returnType: typeof(TrainModel),
         declaringType: typeof(TrainListComponent),
         defaultValue: null,
         defaultBindingMode: BindingMode.OneWay
    );

    public TrainModel Train
    {
        get => (TrainModel)GetValue(TrainProperty);
        set => SetValue(TrainProperty, value);
    }

    public static readonly BindableProperty DeleteCommandProperty = BindableProperty.Create(
         propertyName: nameof(DeleteCommand),
         returnType: typeof(IAsyncRelayCommand),
         declaringType: typeof(TrainListComponent),
         defaultValue: null,
         defaultBindingMode: BindingMode.OneWay
    );

    public IAsyncRelayCommand DeleteCommand
    {
        get => (IAsyncRelayCommand)GetValue(DeleteCommandProperty);
        set => SetValue(DeleteCommandProperty, value);
    }

    public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
         propertyName: nameof(CommandParameter),
         returnType: typeof(string),
         declaringType: typeof(TrainListComponent),
         defaultValue: null,
         defaultBindingMode: BindingMode.TwoWay
        );

    public string CommandParameter
    {
        get => (string)GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }

    public IAsyncRelayCommand EditCommand => new AsyncRelayCommand(OnEditAsync);

    public TrainListComponent()
	{
		InitializeComponent();
	}

    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();

        if (Train is not null)
        {
            CommandParameter = Train.Id;
        }
    }

    private async Task OnEditAsync()
    {
        var parameters = new Dictionary<string, object>
        {
            { "Train", Train }
        };

        await Shell.Current.GoToAsync(CreateOrEditTrainView.Name, parameters);
    }
}