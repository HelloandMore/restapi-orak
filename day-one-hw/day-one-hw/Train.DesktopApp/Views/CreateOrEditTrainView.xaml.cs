namespace Train.DesktopApp.Views;

public partial class CreateOrEditTrainView : ContentPage
{
	public CreateOrEditTrainViewModel ViewModel => this.BindingContext as CreateOrEditTrainViewModel;

	public static string Name => nameof(CreateOrEditTrainView);

    public CreateOrEditTrainView(CreateOrEditTrainViewModel viewModel)
	{
		this.BindingContext = viewModel;

		InitializeComponent();
	}
}