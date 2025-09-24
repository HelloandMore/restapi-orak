namespace Solution.Validators
{
    public class ManufacturerModelValidator : AbstractValidator<ManufacturerModel>
    {
        public static string NameProperty => nameof(ManufacturerModel.Name);
        public static string GlobalProperty => "Global";

        public ManufacturerModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(64).WithMessage("Name cannot exceed 64 characters");
        }
    }
}