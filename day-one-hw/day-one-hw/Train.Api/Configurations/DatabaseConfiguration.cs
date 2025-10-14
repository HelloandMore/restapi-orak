namespace Train.Api.Configurations;

public static class DatabaseConfiguration
{
    public static WebApplicationBuilder ConfigureDatabase(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString, options =>
            {
                options.MigrationsAssembly(Train.Database.AssemblyReference.Assembly.FullName);
                options.EnableRetryOnFailure();
                options.CommandTimeout(300);
            }));

        return builder;
    }
}