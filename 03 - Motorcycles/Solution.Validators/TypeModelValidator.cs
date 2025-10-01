namespace Solution.Validators;

public class TypeModelValidator : BaseValidator<TypeModel>
{
	public static string NameProperty => nameof(TypeModel.Name);
	public static string GlobalProperty => "Global";

	// Constructor for desktop app usage (no HTTP context needed)
	public TypeModelValidator() : base(null)
	{
		ConfigureRules();
	}

	// Constructor for API usage (with HTTP context)
	public TypeModelValidator(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
	{
		ConfigureRules();
	}

	private void ConfigureRules()
	{
		if (IsPutMethod)
		{
			RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required for update");
			//validalni hogy az id letezik
		}

		RuleFor(x => x.Name)
			.NotEmpty().WithMessage("Name is required")
			.MaximumLength(64).WithMessage("Name cannot exceed 64 characters");
	}
}