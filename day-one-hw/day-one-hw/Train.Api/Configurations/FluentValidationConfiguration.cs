namespace Train.Api.Configurations;

public static class FluentValidationConfiguration
{
    public static WebApplicationBuilder ConfigureFluentValidation(this WebApplicationBuilder builder)
    {
        builder.Services.AddFluentValidationAutoValidation(options =>
        {
            options.DisableDataAnnotationsValidation = true;
        });

        builder.Services.AddFluentValidationClientsideAdapters();
        builder.Services.AddValidatorsFromAssembly(Train.Validators.AssemblyReference.Assembly);

        return builder;
    }
}