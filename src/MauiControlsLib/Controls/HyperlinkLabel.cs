using Maui.BindableProperty.Generator.Core;

namespace MauiControlsLib.Controls;

public sealed partial class HyperlinkLabel : Label
{
#pragma warning disable CS0169

    /// <summary>
    ///     Gets or sets the Uri to open if the HyperlinkLabel is tapped.
    /// </summary>
    [AutoBindable(
        DefaultValue = "null",
        DefaultBindingMode = nameof(BindingMode.OneWay))]
    private readonly string _url;

#pragma warning restore CS0169

    public HyperlinkLabel()
    {
        TextDecorations = TextDecorations.Underline;
        TextColor = Colors.Blue;


        GestureRecognizers.Add(new TapGestureRecognizer
        {
            Command = new Command(async () =>
            {
                if (string.IsNullOrEmpty(Url) || string.IsNullOrWhiteSpace(Url))
                {
                    return;
                }

                await Launcher.OpenAsync(Url);
            })
        });
    }
}
