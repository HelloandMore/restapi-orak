# MAUI: ImageButton Hand Cursor on Windows
---

## Files to add

1. `Platforms/Windows/CursorExtensions.cs`
2. `Behaviors/ImageHoverHandBehavior.cs` (shared project)
3. XAML usage example: update your page(s) to attach the behavior to `ImageButton`.

---

## 1) Platforms/Windows/CursorExtensions.cs

Place this file under `Platforms/Windows/`.

```csharp
// Platforms/Windows/CursorExtensions.cs
using System;
using System.Reflection;
using Microsoft.UI.Xaml;
using Windows.UI.Core;

namespace YourAppNamespace.Platforms.Windows
{
    static class CursorExtensions
    {
        // Cached reflection PropertyInfo for UIElement.ProtectedCursor
        static readonly PropertyInfo ProtectedCursorProperty =
            typeof(UIElement).GetProperty("ProtectedCursor", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

        public static void SetHandCursor(this UIElement element)
        {
            if (element == null || ProtectedCursorProperty == null) return;

            // Create a CoreCursor(CoreCursorType.Hand, id: 0)
            var coreCursor = Activator.CreateInstance(typeof(CoreCursor), new object[] { CoreCursorType.Hand, 0 });
            ProtectedCursorProperty.SetValue(element, coreCursor);
        }

        public static void ClearCursor(this UIElement element)
        {
            if (element == null || ProtectedCursorProperty == null) return;
            ProtectedCursorProperty.SetValue(element, null);
        }
    }
}
```

**Notes for the agent:**
- Replace `YourAppNamespace` with the project's root namespace (you can programmatically detect `Assembly.GetEntryAssembly().GetName().Name`).

---

## 2) Behaviors/ImageHoverHandBehavior.cs

Add this file to a shared folder (e.g. `Behaviors/`) in the project.

```csharp
// Behaviors/ImageHoverHandBehavior.cs
using Microsoft.Maui.Controls;

using Microsoft.Maui;
using Microsoft.Maui.Handlers;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;
using YourAppNamespace.Platforms.Windows; // CursorExtensions namespace


namespace YourAppNamespace.Behaviors
{
    public class ImageHoverHandBehavior : Behavior<ImageButton>
    {
        UIElement? platformElement;

        protected override void OnAttachedTo(ImageButton bindable)
        {
            base.OnAttachedTo(bindable);

            // Attach to HandlerChanged so we can get the native element when available
            bindable.HandlerChanged += OnHandlerChanged;
        }

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

        protected override void OnDetachingFrom(ImageButton bindable)
        {
            base.OnDetachingFrom(bindable);

            if (platformElement != null)
            {
                platformElement.PointerEntered -= PlatformElement_PointerEntered;
                platformElement.PointerExited -= PlatformElement_PointerExited;
                platformElement = null;
            }

            bindable.HandlerChanged -= OnHandlerChanged;
        }
    }
}
```

**Notes for the agent:**
- Ensure `YourAppNamespace` is replaced consistently in both files.
- The behavior uses `HandlerChanged` to ensure the native control is available; this avoids race conditions at page creation.

---

## 3) XAML usage (example)

Add the behavior to any `ImageButton` you want to show the hand cursor for. Example XAML (replace namespace with your project's):

```xml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:behaviors="clr-namespace:YourAppNamespace.Behaviors"
             x:Class="YourAppNamespace.MainPage">

    <VerticalStackLayout Padding="20">
        <ImageButton Source="dotnet_bot.png" WidthRequest="64" HeightRequest="64">
            <ImageButton.Behaviors>
                <behaviors:ImageHoverHandBehavior />
            </ImageButton.Behaviors>
        </ImageButton>
    </VerticalStackLayout>
</ContentPage>
```

---

## 4) Automated agent tasks (checklist)

If you are instructing an AI agent with full project access, these are recommended steps it should perform:

1. Detect the project's root namespace automatically (e.g. `Assembly.GetEntryAssembly().GetName().Name`) and replace `YourAppNamespace` placeholders.
2. Create the directory `Platforms/Windows/` if it doesn't exist and add `CursorExtensions.cs` there.
3. Create `Behaviors/ImageHoverHandBehavior.cs` in the shared project folder.
4. Add `using` or `xmlns` imports in XAML files where behaviors are used (or add examples to a sample page).
5. Run a local `dotnet build -f net8.0-windows10.0.19041.0` (or the project's target) to ensure compilation.
6. Run the app on Windows and perform a smoke test: hover the mouse over the `ImageButton` to see the cursor change to a pointing hand.

---

## 5) Testing & edge cases

- **First-hover glitch:** In some WinUI environments, an element that has fully transparent background or hasn't been loaded might not show the cursor on the very first hover. If this is observed, the agent should ensure the `ImageButton` has `BackgroundColor="Transparent"` (explicit) or attach to `Loaded` and call `SetHandCursor()` there once.

- **Multiple instances:** The behavior attaches and detaches event handlers; the agent should verify there are no duplicate handlers if the same control is re-used.

- **Input modalities:** This change only affects mouse pointers on Windows. Touch interactions are unaffected.

---

## 6) Optional improvements

- **Attached property:** Convert the behavior to an attached property so XAML can be `local:HoverCursor.IsHand="True"`.
- **Enum selection:** Support an enum (`Arrow`, `Hand`, `IBeam`) and map to appropriate `CoreCursorType` values.
- **Unit tests:** Add integration tests that run on Windows to verify event attachment and cursor setting.

---

## 7) Rollback

To revert the change, the agent should:
1. Remove the two added files (or guard them behind a feature flag).
2. Remove XAML usages of the behavior.
3. Run a build to confirm cleanup.

---

## 8) Contact

If the agent needs to ask for anything (e.g. confirm namespace or target framework), prefer to auto-detect and create a backup of any edited files before modification.

---

*End of implementation document.*

