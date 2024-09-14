using Sparkle_Editor.Code.Scenes;
using Sparkle.CSharp;

namespace Sparkle_Editor.Code;

public static class Program
{
    private static void Main()
    {
        GameSettings settings = new GameSettings(); // Override the options within the struct as desired.

        using Editor game = new Editor(settings, "Привет пупсик");
        game.Run(new DefaultScene());
    }
}