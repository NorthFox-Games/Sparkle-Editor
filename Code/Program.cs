using Sparkle_Editor.Code.UI;
using Sparkle.CSharp;

namespace Sparkle_Editor.Code;

public static class Program
{
    private static void Main(string[] args)
    {
        Thread GameThread = new Thread(new ThreadStart(Game));
        Thread UIThread = new Thread(new ThreadStart(UI));
        
        GameThread.Start();
        UIThread.Start();
    }

    private static void Game()
    {
        GameSettings settings = new GameSettings();
        
        using Editor game = new Editor(settings, "Editor");
        game.Run(new Scenes.Test());
    }
    
    private static void UI() => UiManager.StartTestApp();
}