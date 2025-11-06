namespace Solution.DesktopApp
{
    public partial class AppShell : Shell
    {
        public AppShell(AppShellViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;

            // Register routes for navigation
            Routing.RegisterRoute(nameof(BillListView), typeof(BillListView));
            Routing.RegisterRoute(nameof(CreateOrEditBillView), typeof(CreateOrEditBillView));
        }
    }
}
