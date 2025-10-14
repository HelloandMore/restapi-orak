using FluentValidation.Results;
using System.Globalization;

namespace Train.DesktopApp.Converters;

public class ValidationResultToErrorMessagesConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is ValidationResult validationResult && !validationResult.IsValid)
        {
            return string.Join(Environment.NewLine, validationResult.Errors.Select(e => e.ErrorMessage));
        }

        return string.Empty;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}