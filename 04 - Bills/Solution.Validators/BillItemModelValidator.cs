namespace Solution.Validators;

public class BillItemModelValidator : BaseValidator<BillItemModel>
{
    public static string ItemNameProperty => nameof(BillItemModel.ItemName);
    public static string QuantityProperty => nameof(BillItemModel.Quantity);
    public static string UnitPriceProperty => nameof(BillItemModel.UnitPrice);

    // Constructor for desktop app usage (no HTTP context needed)
    public BillItemModelValidator() : base(null)
    {
        ConfigureRules();
    }

    // Constructor for API usage (with HTTP context)
    public BillItemModelValidator(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        ConfigureRules();
    }

    private void ConfigureRules()
    {
        RuleFor(x => x.ItemName)
            .NotEmpty().WithMessage("Item name is required")
            .MaximumLength(256).WithMessage("Item name cannot exceed 256 characters");

        RuleFor(x => x.Quantity)
            .NotNull().WithMessage("Quantity is required")
            .GreaterThanOrEqualTo(1).WithMessage("Quantity must be at least 1");

        RuleFor(x => x.UnitPrice)
            .NotNull().WithMessage("Unit price is required")
            .GreaterThanOrEqualTo(1).WithMessage("Unit price must be at least 1");
    }
}
