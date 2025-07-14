namespace MauiControlsLib;


public static class Initialization
{
    /// <summary>
    /// Configures the application to use the Maui Controls Library.
    /// </summary>
    /// <param name="mauiAppBuilder">The instance 
    /// of the MauiAppBuilder being extended.</param>
    /// <returns>The extended MauiAppBuilder instance.</returns>
    public static MauiAppBuilder UseMauiControlsLib(
        this MauiAppBuilder mauiAppBuilder)
    {
        // Currently we don't need to add a specific logic, but
        // this is in preparation for upcoming releases
        return mauiAppBuilder;
    }
}
