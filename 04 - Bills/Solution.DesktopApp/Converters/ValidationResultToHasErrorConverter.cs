namespace Solution.DesktopApp.Converters;

public class ValidationResultToHasErrorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not ValidationResult validationResult || parameter is not string property)
        {
            return false;
        }

        return validationResult.Errors.Any(x => x.PropertyName == property);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
