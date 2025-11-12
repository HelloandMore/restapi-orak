// Behaviors/ImageHoverHandBehavior.cs
using Microsoft.Maui.Controls;
using Microsoft.Maui;
using Microsoft.Maui.Handlers;

#if WINDOWS
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;
using Solution.DesktopApp.Platforms.Windows;
#endif

namespace Solution.DesktopApp.Behaviors;

public class ImageHoverHandBehavior : Behavior<ImageButton>
{
#if WINDOWS
    UIElement? platformElement;
#endif

    protected override void OnAttachedTo(ImageButton bindable)
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
        if (sender is not ImageButton ib) return;

        platformElement = ib.Handler?.PlatformView as UIElement;
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

    protected override void OnDetachingFrom(ImageButton bindable)
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
