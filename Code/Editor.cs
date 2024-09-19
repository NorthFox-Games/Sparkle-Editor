using Raylib_CSharp;
using Raylib_CSharp.Collision;
using Raylib_CSharp.Windowing;
using Sparkle.CSharp;
using Sparkle.CSharp.Registries;

namespace Sparkle_Editor.Code;

public class Editor : Game
{
    private string _title;

    public Editor(GameSettings settings, string title = "Sparkle Editor") : base(settings)
    {
        _title = title;
    }

    protected override void Init() 
    {
        base.Init();
        
        Window.SetTitle(_title);
    }
    
    protected override void OnRun()
    {
        base.OnRun();
        RegistryManager.AddType(new ContentRegistry());
    }

    protected override void Draw() 
    {
        base.Draw();
        
        Window.SetTitle($"{_title} [FPS: {Time.GetFPS()}]");
    }
}