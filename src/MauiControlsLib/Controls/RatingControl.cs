using Maui.BindableProperty.Generator.Core;
using MauiControlsLib.Controls.Internal;

namespace MauiControlsLib.Controls;

public partial class RatingControl : GraphicsView
{
    private readonly RatingCanvas _drawableCanvas;


    /// <summary>
    ///     Gets or sets the number of rating items to be displayed.
    /// </summary>
    [AutoBindable(
        OnChanged = nameof(UpdateLayout),
        DefaultValue = "5",
        DefaultBindingMode = nameof(BindingMode.OneWay))]
    private readonly int _amount;

    /// <summary>
    ///     Gets or sets the current rating value to be displayed.
    /// </summary>
    [AutoBindable(
        OnChanged = nameof(UpdateLayout),
        DefaultValue = "2.5f",
        DefaultBindingMode = nameof(BindingMode.OneWay))]
    private readonly float _currentValue;

    /// <summary>
    ///     Gets or sets the size of each rating item.
    /// </summary>
    [AutoBindable(
        OnChanged = nameof(UpdateLayout),
        DefaultValue = "24f",
        DefaultBindingMode = nameof(BindingMode.OneWay))]
    private readonly float _itemSize;

    /// <summary>
    ///     Gets or sets the spacing between each rating item.
    /// </summary>
    [AutoBindable(
        OnChanged = nameof(UpdateLayout),
        DefaultValue = "6f",
        DefaultBindingMode = nameof(BindingMode.OneWay))]
    private readonly float _itemSpacing;

    /// <summary>
    ///     Gets or sets the fill color to be used for each rating item.
    /// </summary>
    [AutoBindable(
        OnChanged = nameof(UpdateLayout),
        DefaultValue = "Colors.Yellow",
        DefaultBindingMode = nameof(BindingMode.OneWay))]
    private readonly Color _fillColor = Colors.Yellow;

    /// <summary>
    ///     Gets or sets the unfill color to be used for each rating item.
    /// </summary>
    [AutoBindable(
        OnChanged = nameof(UpdateLayout),
        DefaultValue = "Colors.LightGray",
        DefaultBindingMode = nameof(BindingMode.OneWay))]
    private readonly Color _unfillColor;

    /// <summary>
    ///     Gets or sets the path used to draw each rating item.
    /// </summary>
    public static readonly BindableProperty PathProperty =
        BindableProperty.Create(nameof(Path), typeof(string), typeof(RatingControl), "M16.001007,0L20.944,10.533997 32,12.223022 23.998993,20.421997 25.889008,32 16.001007,26.533997 6.1109924,32 8,20.421997 0,12.223022 11.057007,10.533997z", BindingMode.OneWay, propertyChanged: OnPathChanged);

    public string Path
    {
        get => (string)GetValue(PathProperty);
        set => SetValue(PathProperty, value);
    }

    private static void OnPathChanged(BindableObject bindableObject, object oldValue, object newValue)
    {
        if (newValue is not null && bindableObject is RatingControl rating && newValue != oldValue)
            rating.UpdateLayout();
    }


    /// <summary>
    ///     Initializes a new instance of the <see cref="RatingControl"/> class.
    /// </summary>
    public RatingControl()
    {
        _drawableCanvas = new RatingCanvas();
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
        _drawableCanvas.Amount = Amount;
        _drawableCanvas.CurrentValue = CurrentValue;
        _drawableCanvas.ItemSize = ItemSize;
        _drawableCanvas.ItemSpacing = ItemSpacing;
        _drawableCanvas.FillColor = FillColor;
        _drawableCanvas.UnfillColor = UnfillColor;
        _drawableCanvas.Path = Path;
        HeightRequest = ItemSize;
        WidthRequest = ItemSize * Amount + (ItemSpacing * (Amount - 1));

        Invalidate();
    }
}
