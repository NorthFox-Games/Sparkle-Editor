using Avalonia;

namespace Sparkle_Editor.Code.UI;

public static class UiManager
{
    public static void StartTestApp()
    {
        BuildTestApp().StartWithClassicDesktopLifetime(new string[0]);
    }
    
    private static AppBuilder BuildTestApp()
    {
        return AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .LogToTrace();
    }
}