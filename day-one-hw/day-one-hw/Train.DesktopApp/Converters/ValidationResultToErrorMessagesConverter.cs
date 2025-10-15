namespace Train.DesktopApp.Converters;

public class ValidationResultToErrorMessagesConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if(value is not ValidationResult validationResult || validationResult.IsValid)
        {
            return null;
        }
        if (parameter == null)
        {
            return null;
        }
        
        var property = parameter as string;
        var errorMessages = validationResult.Errors.Where(x => x.PropertyName == property)
                                                   .Select(x => x.ErrorMessage);

        return string.Join(Environment.NewLine, errorMessages);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        // This converter is intended for one-way binding only
        return null;
    }
}