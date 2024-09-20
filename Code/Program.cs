using System.Reflection;
using Avalonia;
using Sparkle_Editor.Code.UI;
using Sparkle.CSharp;

namespace Sparkle_Editor.Code;

public static class Program
{
    public static Version Version = Assembly.GetEntryAssembly().GetName().Version;

    public static Thread UIThread { get; private set; }
    public static Thread GameThread { get; private set; }
    
    [STAThread]
    private static void Main(string[] args)
    {
        // For some reason it doesn't work on Mac(ARM) processors (Tested on Apple M2)
        GameThread = new Thread(new ThreadStart(Game));
        UIThread = new Thread(() => BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args));
        
        DiscordManager.Initialize();
        
        GameThread.Start();
        UIThread.Start();
    }

    private static void Game()
    {
        GameSettings settings = new GameSettings();
        
        using Editor game = new Editor(settings, "Editor");
        game.Run(new Scenes.Test());
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .LogToTrace();
}