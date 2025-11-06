namespace Solution.Validators;

public class BillModelValidator : BaseValidator<BillModel>
{
    public static string BillNumberProperty => nameof(BillModel.BillNumber);
    public static string BillDateProperty => nameof(BillModel.BillDate);
    public static string ItemsProperty => nameof(BillModel.Items);

    // Constructor for desktop app usage (no HTTP context needed)
    public BillModelValidator() : base(null)
    {
        ConfigureRules();
    }

    // Constructor for API usage (with HTTP context)
    public BillModelValidator(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        ConfigureRules();
    }

    private void ConfigureRules()
    {
        if (IsPutMethod)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required for update");
            
            // For updates, BillNumber is optional (can keep the existing one)
            RuleFor(x => x.BillNumber)
                .MaximumLength(128).WithMessage("Bill number cannot exceed 128 characters")
                .When(x => !string.IsNullOrEmpty(x.BillNumber));
        }
        else
        {
            // For creation, BillNumber is required
            RuleFor(x => x.BillNumber)
                .NotEmpty().WithMessage("Bill number is required")
                .MaximumLength(128).WithMessage("Bill number cannot exceed 128 characters");
        }

        RuleFor(x => x.BillDate)
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Bill date cannot be in the future")
            .When(x => x.BillDate.HasValue);

        RuleFor(x => x.Items)
            .NotNull().WithMessage("Items are required")
            .Must(items => items != null && items.Count > 0).WithMessage("At least one item is required");

        RuleForEach(x => x.Items).SetValidator(new BillItemModelValidator());
    }
}
