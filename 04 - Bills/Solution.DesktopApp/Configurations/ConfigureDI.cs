namespace Solution.DesktopApp.Configurations;

public static class ConfigureDI
{
    public static MauiAppBuilder UseDIConfiguration(this MauiAppBuilder builder)
    {
        // Register ViewModels
        builder.Services.AddTransient<AppShellViewModel>();
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<BillListViewModel>();
        builder.Services.AddTransient<CreateOrEditBillViewModel>();

        // Register Views
        builder.Services.AddTransient<MainView>();
        builder.Services.AddTransient<BillListView>();
        builder.Services.AddTransient<CreateOrEditBillView>();

        // Register Services
        builder.Services.AddTransient<IBillService, BillService>();

        // Register Validators
        builder.Services.AddSingleton<IValidator<BillModel>, BillModelValidator>();
        builder.Services.AddSingleton<IValidator<BillItemModel>, BillItemModelValidator>();

        // Register Shell
        builder.Services.AddSingleton<AppShell>();

        return builder;
    }
}

