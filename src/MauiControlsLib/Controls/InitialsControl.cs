using Maui.BindableProperty.Generator.Core;
using MauiControlsLib.Controls.Internal;
using MauiControlsLib.Controls.Models;
using System.Security.Cryptography;
using System.Text;

namespace MauiControlsLib.Controls;

public partial class InitialsControl : GraphicsView
{
    private readonly InitialsCanvas _drawableCanvas;

#pragma warning disable CS0169

    /// <summary>
    ///     Gets or sets the default background color for the initials control.
    /// </summary>
    [AutoBindable(
        OnChanged = nameof(UpdateLayout),
        DefaultValue = "Colors.LightGray",
        DefaultBindingMode = nameof(BindingMode.OneWay))]
    private readonly Color _defaultBackgroundColor;

    /// <summary>
    ///     Gets or sets the light text color for the initials control.
    /// </summary>
    [AutoBindable(
        OnChanged = nameof(UpdateLayout),
        DefaultValue = "Colors.White",
        DefaultBindingMode = nameof(BindingMode.OneWay))]
    private readonly Color _textColorLight;

    /// <summary>
    ///     Gets or sets the dark text color for the initials control.
    /// </summary>
    [AutoBindable(
        OnChanged = nameof(UpdateLayout),
        DefaultValue = "Colors.Black",
        DefaultBindingMode = nameof(BindingMode.OneWay))]
    private readonly Color _textColorDark;

    /// <summary>
    ///     Gets or sets the name for the initials control.
    /// </summary>
    [AutoBindable(
        OnChanged = nameof(UpdateLayout),
        DefaultValue = "",
        DefaultBindingMode = nameof(BindingMode.OneWay))]
    private readonly string _name;

    /// <summary>
    ///     Gets or sets the size of the initials control.
    /// </summary>
    [AutoBindable(
        OnChanged = nameof(UpdateLayout),
        DefaultValue = "MauiControlsLib.Controls.Models.ControlSize.Small",
        DefaultBindingMode = nameof(BindingMode.OneWay))]
    private readonly ControlSize _size;

#pragma warning restore CS0169

    /// <summary>
    ///     Initializes a new instance of the <see cref="InitialsControl"/> class.
    /// </summary>
    public InitialsControl()
    {
        _drawableCanvas = new InitialsCanvas();
        Drawable = _drawableCanvas;
    }

    /// <summary>
    ///     Called when the control's parent is set.
    /// </summary>
    protected override void OnParentSet()
    {
        base.OnParentSet();

        if (Parent is null)
        {
            return;
        }

        UpdateLayout();
    }

    /// <summary>
    ///     Updates the layout of the control.
    /// </summary>
    private void UpdateLayout()
    {
        (Color BackgroundColor, Color TextColor) = GetBackgroundAndTextColorForName(Name);

        _drawableCanvas.BackgroundColor = BackgroundColor;
        _drawableCanvas.TextColor = TextColor;
        _drawableCanvas.Text = GetInitials(Name);

        switch (Size)
        {
            case ControlSize.Small:
            default:
                HeightRequest = WidthRequest = 48;
                _drawableCanvas.FontSize = 24;
                break;
            case ControlSize.Medium:
                HeightRequest = WidthRequest = 72;
                _drawableCanvas.FontSize = 44;
                break;
            case ControlSize.Large:
                HeightRequest = WidthRequest = 120;
                _drawableCanvas.FontSize = 80;
                break;
        }

        Invalidate();
    }

    /// <summary>
    ///     Gets the initials for a provided name
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private static string GetInitials(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return string.Empty;
        }

        var words = name.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        if (words.Length == 1)
        {
            return words[0][0].ToString();
        }

        if (words.Length > 1)
        {
            var initialsString = words[0][0].ToString() + words[words.Length - 1][0].ToString();
            return initialsString;
        }

        return string.Empty;
    }

    /// <summary>
    ///     Gets the background color and the text color of the initials control.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private (Color BackgroundColor, Color TextColor) GetBackgroundAndTextColorForName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            double defaultBrightness = DefaultBackgroundColor.Red * .3 + DefaultBackgroundColor.Green * .59 + DefaultBackgroundColor.Blue * .11;
            Color defaultTextColor = defaultBrightness < 0.5 ? TextColorLight : TextColorDark;

            return (DefaultBackgroundColor, defaultTextColor);
        }

        // get color for the provided text
        var hexColor = string.Concat("#FF", CreateMD5Hash(name).AsSpan(0, 6));

        // fix issue if value is too short
        if (hexColor.Length == 8)
            hexColor += "5";

        // create color from hex value
        Color backgroundColor = Color.FromArgb(hexColor);

        // get brightness and set textcolor
        double brightness = backgroundColor.Red * .3 + backgroundColor.Green * .59 + backgroundColor.Blue * .11;
        Color textColor = brightness < 0.5 ? TextColorLight : TextColorDark;

        return (backgroundColor, textColor);
    }

    /// <summary>
    ///     Create the MD5 hash of a string input.
    /// </summary>
    /// <param name="input">The string which should be hashed.</param>
    /// <returns>Hashed </returns>
    private static string CreateMD5Hash(string input)
    {
        byte[] inputBytes = Encoding.ASCII.GetBytes(input);
        byte[] hashBytes = MD5.HashData(inputBytes);

        return Convert.ToHexString(hashBytes);
    }
}
