using OpenTK.Mathematics;
using Raylib_CSharp;
using Raylib_CSharp.Colors;
using Raylib_CSharp.Interact;
using Raylib_CSharp.Rendering;
using Raylib_CSharp.Textures;
using Raylib_CSharp.Windowing;
using Sparkle.CSharp;
using Sparkle.CSharp.Content.Types;

namespace Sparkle_Editor.Code;

public class Editor : Game 
{
    private string _title;

    public Editor(GameSettings settings, string title = "Editor") : base(settings)
    {
        this._title = title;
    }

    protected override void Init() 
    {
        base.Init();
        
        Window.SetTitle(_title);
    }

    protected override void Draw() 
    {
        base.Draw();

        if (Input.IsKeyDown(KeyboardKey.M)) {
            Graphics.DrawCircle(50, 50, 200, Color.Blue);
        }
        
        Window.SetTitle($"{_title} [FPS: {Time.GetFPS()}]");
    }
}