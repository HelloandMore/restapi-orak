namespace Solution.DesktopApp.Converters;

public class ValidationResultToErrorMessagesConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not ValidationResult validationResult || parameter is not string property)
        {
            return string.Empty;
        }

        var errorMessages = validationResult.Errors
            .Where(x => x.PropertyName == property)
            .Select(x => x.ErrorMessage);

        return string.Join(Environment.NewLine, errorMessages);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
