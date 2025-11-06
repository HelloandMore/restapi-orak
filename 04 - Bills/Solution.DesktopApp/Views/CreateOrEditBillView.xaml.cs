namespace Solution.DesktopApp.Views;

public partial class CreateOrEditBillView : ContentPage
{
    public CreateOrEditBillView(CreateOrEditBillViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
