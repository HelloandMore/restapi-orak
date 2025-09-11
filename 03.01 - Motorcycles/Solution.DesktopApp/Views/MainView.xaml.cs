namespace Solution.DesktopApp;

public partial class MainView : ContentPage
{
    public MainViewModel ViewModel => this.BindingContext as MainViewModel;

    public static string Name => nameof(MainView);

    public MainView(MainViewModel viewModel)
    {
        this.BindingContext = viewModel;

        InitializeComponent();
    }

    void OnPointerEntered(object sender, PointerEventArgs e)
    {
        if (sender is VisualElement ve)
        {
            // quick scale + subtle fade to indicate interactivity
            _ = ve.ScaleTo(1.06, 100, Easing.CubicOut);
            _ = ve.FadeTo(0.95, 100, Easing.CubicOut);
        }
    }

    void OnPointerExited(object sender, PointerEventArgs e)
    {
        if (sender is VisualElement ve)
        {
            _ = ve.ScaleTo(1.0, 100, Easing.CubicOut);
            _ = ve.FadeTo(1.0, 100, Easing.CubicOut);
        }
    }
}
