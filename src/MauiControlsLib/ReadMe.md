# Controls Library for .NET MAUI

This repository contains some custom made controls for your .NET MAUI application.

This library is currently under development and for the moment there is a `HyperlinkLabel`, an `InitialsControl`, a `RatingControl`, and a `StaticChipControl` available.

## Installation

Install the package via [NuGet](https://www.nuget.org/packages/tsjdevapps.MauiControlsLib).

[![Nuget](https://img.shields.io/nuget/v/tsjdevapps.MauiControlsLib)](https://www.nuget.org/packages/tsjdevapps.MauiControlsLib)

## Initialization

Open the class `MauiProgram` and call `UseMauiControlsLib()` on the `MauiAppBuilder`.

```csharp
MauiAppBuilder builder = MauiApp.CreateBuilder();
builder
    .UseMauiApp<App>()
    .UseMauiControlsLib() // <--
    .ConfigureFonts(fonts =>
    {
        fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
        fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
    });

return builder.Build();
```

In order to make use of the control within XAML you can use this namespace:

```xml
xmlns:controls="http://www.tsjdev-apps.de/controls/maui"
```

## Available Controls

### HyperlinkLabel

You can use the `HyperlinkLabel` in your .NET MAUI application to show a simple label, which will open a website on a tap.

The following table explains all the available properties and their default value.

| **name** | **type** | **default value** | **description** |
|-|-|-|-|
| `Url` | `string` | `null` | The url which should be opened |

### InitialsControl

You can use the `InitialsControl` in your .NET MAUI application to show a round badge with the initials of a person.

The following table explains all the available properties and their default value.

| **name** | **type** | **default value** | **description** |
|-|-|-|-|
| `DefaultBackgroundColor` | `Color` | `Colors.LightGray` | Indicates the default background color if no `name` is available |
| `TextColorLight` | `Color` | `Colors.White` | Indicates the light text color |
| `TextColorDark` | `Color` | `Colors.Black` | Indicates the dark text color |
| `Name` | `string` | `string.Empty` | Indicates the name to take the initials from |
| `Size` | `ControlSize` | `ControlSize.Small` | Indicates the size of the control |

### RatingControl

You can use the `RatingControl` in your .NET MAUI application.

The following table explains all the available properties and their default value.

| **name** | **type** | **default value** | **description** |
|-|-|-|-|
| `Amount` | `int` | `5` | Indicates the number of rating items to be displayed |
| `CurrentValue` | `float` | `2.5f` | Indicates the current rating value to be displayed |
| `ItemSize` | `float` | `24f` | Indicates the size of each rating item |
| `ItemSpacing` | `float` | `6f` | Indicates the spacing between each rating item. |
| `FillColor` | `Color` | `Colors.Yellow` | Indicates the fill color to be used for each rating item |
| `UnfillColor` | `Color` | `Colors.LightGray` | Indicates the unfill color to be used for each rating item |
| `Path` | `string` | `<Star>` | Indicates the path used to draw each rating item |

### StaticChipControl

You can use the `StaticChipControl` in your .NET MAUI application.

The following table explains all the available properties and their default value.

| **name** | **type** | **default value** | **description** |
|-|-|-|-|
| `Text` | `string` | `string.Empty` | Indicates the text of the chip to be displayed |
| `Color` | `Color` | `Colors.LightGray` | Indicates the background color of the chip |
| `TextColor` | `Color` | `Colors.Black` | Indicates the text color of the text |
| `ImageSource` | `ImageSource` | `null` | Indicates the icon of the chip |

## License

[MIT](https://choosealicense.com/licenses/mit/)
