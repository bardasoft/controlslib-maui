namespace MauiControlsLib.Controls.Internal;


/// <summary>
///     Represents a drawable control for displaying a rating value 
///     using a user-defined shape.
/// </summary>
internal class RatingCanvas : IDrawable
{
    /// <summary>
    ///     Gets or sets the number of rating items to be displayed.
    /// </summary>
    public int Amount { get; set; }

    /// <summary>
    ///     Gets or sets the current rating value to be displayed.
    /// </summary>
    public double CurrentValue { get; set; }

    /// <summary>
    ///     Gets or sets the size of each rating item.
    /// </summary>
    public float ItemSize { get; set; }

    /// <summary>
    ///     Gets or sets the spacing between each rating item.
    /// </summary>
    public float ItemSpacing { get; set; }

    /// <summary>
    ///     Gets or sets the fill color to be used for each rating item.
    /// </summary>
    public Color FillColor { get; set; }

    /// <summary>
    ///     Gets or sets the unfill color to be used for each rating item.
    /// </summary>
    public Color UnfillColor { get; set; }

    /// <summary>
    ///     Gets or sets the path used to draw each rating item.
    /// </summary>
    public string Path { get; set; }

    /// <summary>
    ///     Gets or sets the background color for the control.
    /// </summary>
    public Color BackgroundColor { get; set; }

    /// <summary>
    ///     Draws the control onto a canvas.
    /// </summary>
    /// <param name="canvas">The canvas to draw onto.</param>
    /// <param name="dirtyRect">The portion of the canvas needing to be redrawn.</param>
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        // Enable antialiasing
        canvas.Antialias = true;

        // Draw the background
        DrawBackground(canvas, dirtyRect, BackgroundColor);

        // Make sure that the desired number of rating items will be drawn
        for (int i = 0; i < Amount; i++)
        {
            DrawRatingItem(canvas, i);
        }
    }

    /// <summary>
    ///     Draws a rating item onto a canvas.
    /// </summary>
    /// <param name="canvas">The canvas to draw onto.</param>
    /// <param name="itemIndex">The index of the rating item to draw.</param>
    private void DrawRatingItem(ICanvas canvas, int itemIndex)
    {
        // Save the current state of the canvas
        canvas.SaveState();

        // Translate the canvas to the correct position for this rating item
        canvas.Translate(itemIndex * ItemSize + itemIndex * ItemSpacing, 0);

        // Build the path used to draw this rating item
        PathBuilder pathBuilder = new();
        PathF shapePath = pathBuilder.BuildPath(Path);
        PathF scaledShapePath = shapePath.AsScaledPath(ItemSize / shapePath.Bounds.Height);

        // Draw the unfill color for this rating item
        DrawShape(canvas, scaledShapePath, UnfillColor, null);

        // If this item needs to be filled in, draw the fill color
        if (itemIndex < CurrentValue)
        {
            PathF clippedPath = new();
            clippedPath.AppendRectangle(0, 0, Convert.ToSingle(scaledShapePath.Bounds.Width * (CurrentValue - itemIndex)), scaledShapePath.Bounds.Height);

            DrawShape(canvas, scaledShapePath, FillColor, clippedPath);
        }

        // Restore the canvas to its previous state
        canvas.RestoreState();
    }

    /// <summary>
    ///     Draws the background for the control onto a canvas.
    /// </summary>
    /// <param name="canvas">The canvas to draw onto.</param>
    /// <param name="dirtyRect">The portion of the canvas needing to be redrawn.</param>
    /// <param name="backgroundColor">The background color to use for the control.</param>
    private static void DrawBackground(ICanvas canvas, RectF dirtyRect, Color backgroundColor)
    {
        // Save the current state of the canvas
        canvas.SaveState();

        // Set the fill color
        canvas.FillColor = backgroundColor;

        // Fill the rectangle
        canvas.FillRectangle(dirtyRect);

        // Restore the canvas to its previous state
        canvas.RestoreState();
    }

    /// <summary>
    ///     Draws a shape onto a canvas.
    /// </summary>
    /// <param name="canvas">The canvas to draw onto.</param>
    /// <param name="shapePath">The path used to draw the shape.</param>
    /// <param name="fillColor">The color to fill the shape with.</param>
    /// <param name="clippedPath">The path used to clip the shape.</param>
    private static void DrawShape(ICanvas canvas, PathF shapePath, Color fillColor, PathF clippedPath)
    {
        // Set the stroke size to 0
        canvas.StrokeSize = 0;

        // Set the fill color
        canvas.FillColor = fillColor;

        // If there is a clipping path, clip the shape
        if (clippedPath is not null)
        {
            canvas.ClipPath(clippedPath);
        }

        // Draw the path
        canvas.DrawPath(shapePath);

        // Fill the path
        canvas.FillPath(shapePath);
    }
}
