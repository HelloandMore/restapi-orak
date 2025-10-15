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



    public IAsyncRelayCommand EditCommand => new AsyncRelayCommand(OnEditAsync);

    public TrainListComponent()
    {
        InitializeComponent();
    }



    private async Task OnEditAsync()
    {
        ShellNavigationQueryParameters navigationQueryParameter = new ShellNavigationQueryParameters
        {
            { "Train", this.Train}
        };

        Shell.Current.ClearNavigationStack();
        await Shell.Current.GoToAsync(CreateOrEditTrainView.Name, navigationQueryParameter);
    }
}