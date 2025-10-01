namespace Solution.Validators;

public class ManufacturerModelValidator : BaseValidator<ManufacturerModel>
{
	public static string NameProperty => nameof(ManufacturerModel.Name);
	public static string GlobalProperty => "Global";

	// Constructor for desktop app usage (no HTTP context needed)
	public ManufacturerModelValidator() : base(null)
	{
		ConfigureRules();
	}

	// Constructor for API usage (with HTTP context)
	public ManufacturerModelValidator(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
	{
		ConfigureRules();
	}

	private void ConfigureRules()
	{
		if (IsPutMethod)
		{
			RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required for update");
		}

		RuleFor(x => x.Name)
			.NotEmpty().WithMessage("Name is required")
			.MaximumLength(64).WithMessage("Name cannot exceed 64 characters");
	}
}