using FluentValidation.Results;
using System.Globalization;

namespace Train.DesktopApp.Converters;

public class ValidationResultToHasErrorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is ValidationResult validationResult)
        {
            return !validationResult.IsValid;
        }

        return false;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}