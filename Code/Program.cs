using Sparkle_Editor.Code.UI;
using Sparkle.CSharp;

namespace Sparkle_Editor.Code;

public static class Program
{
    private static void Main(string[] args)
    {
        GameSettings settings = new GameSettings();

        using Editor game = new Editor(settings, "Editor");
        game.Run(new Scenes.Test());
        
        UiManager.StartTestApp();
    }
}