namespace Solution.DesktopApp.Configurations;

public static class ConfigureDI
{
    public static MauiAppBuilder UseDIConfiguration(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<AppShellViewModel>();
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<BillListViewModel>();
        builder.Services.AddTransient<CreateOrEditBillViewModel>();

        builder.Services.AddTransient<MainView>();
        builder.Services.AddTransient<BillListView>();
        builder.Services.AddTransient<CreateOrEditBillView>();

        builder.Services.AddTransient<IBillService, BillService>();

        builder.Services.AddSingleton<IValidator<BillModel>, BillModelValidator>();
        builder.Services.AddSingleton<IValidator<BillItemModel>, BillItemModelValidator>();

        builder.Services.AddSingleton<AppShell>();

        return builder;
    }
}

