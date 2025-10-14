namespace Train.Validators;

public class TrainModelValidator : BaseValidator<TrainModel>
{
    public static string NameProperty => nameof(TrainModel.Name);
    public static string TypeProperty => nameof(TrainModel.Type);
    public static string BuildDateProperty => nameof(TrainModel.BuildDate);
    public static string MaxSpeedProperty => nameof(TrainModel.MaxSpeed);
    public static string WeightProperty => nameof(TrainModel.Weight);
    public static string LengthProperty => nameof(TrainModel.Length);
    public static string GaugeProperty => nameof(TrainModel.Gauge);
    public static string PowerProperty => nameof(TrainModel.Power);
    public static string GlobalProperty => "Global";

    // Constructor for desktop app usage (no HTTP context needed)
    public TrainModelValidator() : base(null)
    {
        ConfigureRules();
    }

    // Constructor for API usage (with HTTP context)
    public TrainModelValidator(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        ConfigureRules();
    }

    private void ConfigureRules()
    {
        if (IsPutMethod)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required for update");
        }

        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");

        RuleFor(x => x.Type).NotEmpty().WithMessage("Type is required");

        RuleFor(x => x.BuildDate).NotNull().WithMessage("Build date is required")
                                  .InclusiveBetween(1800, DateTime.Now.Year).WithMessage("Invalid build date");

        RuleFor(x => x.MaxSpeed).NotNull().WithMessage("Max speed is required")
                                 .GreaterThan(0).WithMessage("Max speed has to be greater than 0");

        RuleFor(x => x.Weight).NotNull().WithMessage("Weight is required")
                              .GreaterThan(0).WithMessage("Weight has to be greater than 0");

        RuleFor(x => x.Length).NotNull().WithMessage("Length is required")
                              .GreaterThan(0).WithMessage("Length has to be greater than 0");

        RuleFor(x => x.Gauge).NotNull().WithMessage("Gauge is required")
                             .GreaterThan(0).WithMessage("Gauge has to be greater than 0");

        RuleFor(x => x.Power).NotNull().WithMessage("Power is required")
                             .GreaterThan(0).WithMessage("Power has to be greater than 0");
    }
}