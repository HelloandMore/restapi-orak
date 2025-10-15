namespace Train.DesktopApp.Converters;

public class ValidationResultToHasErrorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not ValidationResult validationResult || parameter == null)
        {
            return null;
        }

        if(validationResult.IsValid)
        {
            return false;
        }

        var property = parameter as string;

        return validationResult.Errors.Any(x => x.PropertyName == property);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        // This converter is intended for one-way binding only
        return null;
    }
}