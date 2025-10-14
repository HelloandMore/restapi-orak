namespace Train.DesktopApp.Configurations;

public static class SqlServerConfiguration
{
    public static MauiAppBuilder UseMsSqlServer(this MauiAppBuilder builder)
    {
        var connectionString = "Data Source=localhost;Database=TrainDB;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;";

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

        return builder;
    }
}