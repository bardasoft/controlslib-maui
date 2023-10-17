namespace MauiControlsLib.Controls.Internal;

/// <summary>
///     Represents a drawable control for displaying initials
/// </summary>
internal class InitialsCanvas : IDrawable
{
    /// <summary>
    ///     Gets or sets the background color for the initials control.
    /// </summary>
    public Color BackgroundColor { get; set; }

    /// <summary>
    ///     Gets or sets the text color for the initials control.
    /// </summary>
    public Color TextColor { get; set; }

    /// <summary>
    ///     Gets or sets the text to be displayed on the initials control.
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    ///     Gets or sets the font size of the text to be displayed on the initials control.
    /// </summary>
    public float FontSize { get; set; }


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

        // Draw the initials
        DrawInitials(canvas, dirtyRect, Text, TextColor, FontSize);
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

        // Fill the ellipse
        canvas.FillEllipse(dirtyRect.X, dirtyRect.Y, dirtyRect.Width, dirtyRect.Height);

        // Restore the canvas to its previous state
        canvas.RestoreState();
    }

    /// <summary>
    ///     Draws the initials onto a canvas.
    /// </summary>
    /// <param name="canvas">The canvas to draw onto.</param>
    /// <param name="dirtyRect">The portion of the canvas needing to be redrawn.</param>
    /// <param name="text">The text to be displayed.</param>
    /// <param name="textColor">The text color to use for the text.</param>
    /// <param name="fontSize">The font size to use for the text.</param>
    private static void DrawInitials(ICanvas canvas, RectF dirtyRect, string text, Color textColor, float fontSize)
    {
        // Save the current state of the canvas
        canvas.SaveState();

        // Set the font color and the font size
        canvas.FontColor = textColor;
        canvas.FontSize = fontSize;

        // Draw the string 
        canvas.DrawString(text, 0, 0, dirtyRect.Width, dirtyRect.Height, HorizontalAlignment.Center, VerticalAlignment.Center);

        // Restore the canvas to its previous state
        canvas.RestoreState();
    }
}
