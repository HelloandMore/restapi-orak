namespace Train.DesktopApp;

public static class ExceptionHandler
{
    public static void HandleException(Exception exception)
    {
        // Log the exception
        System.Diagnostics.Debug.WriteLine($"Exception occurred: {exception.Message}");
        System.Diagnostics.Debug.WriteLine($"Stack trace: {exception.StackTrace}");

        // In a production app, you might want to log to a file or send to a logging service
        // For now, we'll just write to debug output
    }

    public static async Task HandleExceptionAsync(Exception exception)
    {
        HandleException(exception);

        // You could also show a user-friendly dialog here
        await Task.CompletedTask;
    }
}