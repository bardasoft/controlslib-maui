using Maui.BindableProperty.Generator.Core;

namespace MauiControlsLib.Controls;

public partial class StaticChipControl : Border 
{
#pragma warning disable CS0169
    [AutoBindable(
        OnChanged = nameof(UpdateLayout),
        DefaultValue = "",
        DefaultBindingMode = nameof(BindingMode.OneWay))]
    private readonly string _text;

    [AutoBindable(
        OnChanged = nameof(UpdateLayout),
        DefaultValue = "Colors.LightGray",
        DefaultBindingMode = nameof(BindingMode.OneWay))]
    private readonly Color _color;

    [AutoBindable(
        OnChanged = nameof(UpdateLayout),
        DefaultValue = "Colors.Black",
        DefaultBindingMode = nameof(BindingMode.OneWay))]
    private readonly Color _textColor;

    [AutoBindable(
        OnChanged = nameof(UpdateLayout),
        DefaultValue = "null",
        DefaultBindingMode = nameof(BindingMode.OneWay))]
    private readonly ImageSource _imageSource;

#pragma warning restore CS0169

    public StaticChipControl()
    {
        InitializeComponent();
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

    private void UpdateLayout()
    {
        ChipLabel.Text = Text;
        ChipLabel.TextColor = TextColor;
        BackgroundColor = Color;

        if (ImageSource is not null)
        {
            ChipImage.Source = ImageSource;
            ChipImage.IsVisible = true;
            ChipLabel.Margin = new Thickness(8, 0, 0, 0);
        }
        else
        {
            ChipImage.IsVisible = false;
            ChipLabel.Margin = new Thickness(0);
        }
    }
}