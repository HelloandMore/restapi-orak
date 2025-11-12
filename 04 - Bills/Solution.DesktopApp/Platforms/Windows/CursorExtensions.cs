// Platforms/Windows/CursorExtensions.cs
using System;
using System.Reflection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Input;

namespace Solution.DesktopApp.Platforms.Windows;

public static class CursorExtensions
{
    // Cached reflection PropertyInfo for UIElement.ProtectedCursor
    public static readonly PropertyInfo? ProtectedCursorProperty =
        typeof(UIElement).GetProperty("ProtectedCursor", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

    public static void SetHandCursor(this UIElement element)
    {
        if (element == null || ProtectedCursorProperty == null) return;

        try
        {
            // Use WinUI 3's InputSystemCursor for hand cursor
            var handCursor = InputSystemCursor.Create(InputSystemCursorShape.Hand);
            ProtectedCursorProperty.SetValue(element, handCursor);
        }
        catch (Exception ex)
        {
            // Silently fail if cursor setting is not supported
            System.Diagnostics.Debug.WriteLine($"Failed to set hand cursor: {ex.Message}");
        }
    }

    public static void ClearCursor(this UIElement element)
    {
        if (element == null || ProtectedCursorProperty == null) return;

        try
        {
            // Reset to default arrow cursor
            var arrowCursor = InputSystemCursor.Create(InputSystemCursorShape.Arrow);
            ProtectedCursorProperty.SetValue(element, arrowCursor);
        }
        catch (Exception ex)
        {
            // Silently fail if cursor setting is not supported
            System.Diagnostics.Debug.WriteLine($"Failed to clear cursor: {ex.Message}");
        }
    }
}
