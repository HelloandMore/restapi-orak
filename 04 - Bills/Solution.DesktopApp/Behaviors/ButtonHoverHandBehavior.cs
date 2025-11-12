// Behaviors/ButtonHoverHandBehavior.cs
using Microsoft.Maui.Controls;
using Microsoft.Maui;
using Microsoft.Maui.Handlers;

#if WINDOWS
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;
using Solution.DesktopApp.Platforms.Windows;
#endif

namespace Solution.DesktopApp.Behaviors;

public class ButtonHoverHandBehavior : Behavior<Button>
{
#if WINDOWS
    UIElement? platformElement;
#endif

    protected override void OnAttachedTo(Button bindable)
    {
        base.OnAttachedTo(bindable);

#if WINDOWS
        // Attach to HandlerChanged so we can get the native element when available
        bindable.HandlerChanged += OnHandlerChanged;
#endif
    }

#if WINDOWS
    void OnHandlerChanged(object? sender, System.EventArgs e)
    {
        if (sender is not Button btn) return;

        platformElement = btn.Handler?.PlatformView as UIElement;
        if (platformElement == null)
            return;

        platformElement.PointerEntered += PlatformElement_PointerEntered;
        platformElement.PointerExited += PlatformElement_PointerExited;
    }

    private void PlatformElement_PointerEntered(object? sender, PointerRoutedEventArgs e)
        => platformElement?.SetHandCursor();

    private void PlatformElement_PointerExited(object? sender, PointerRoutedEventArgs e)
        => platformElement?.ClearCursor();
#endif

    protected override void OnDetachingFrom(Button bindable)
    {
        base.OnDetachingFrom(bindable);

#if WINDOWS
        if (platformElement != null)
        {
            platformElement.PointerEntered -= PlatformElement_PointerEntered;
            platformElement.PointerExited -= PlatformElement_PointerExited;
            platformElement = null;
        }

        bindable.HandlerChanged -= OnHandlerChanged;
#endif
    }
}
