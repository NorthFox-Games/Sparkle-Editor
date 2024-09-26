using CopperDevs.DearImGui;
using Raylib_CSharp;
using Raylib_CSharp.Windowing;
using Sparkle_Editor.Code.Managers;
using Sparkle_Editor.Code.ImGui;
using Sparkle.CSharp;
using Sparkle.CSharp.Logging;
using Sparkle.CSharp.Overlays;
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
        
        var myOverlay = new DearImGuiOverlay("DearImGui Overlay")
        {
            Enabled = true,
        };
        OverlayManager.Add(myOverlay);
    }
    
    protected override void OnRun()
    {
        base.OnRun();
        RegistryManager.AddType(new ContentRegistry());

        if (Program.Version.Major <= 1)
        {
            Logger.Warn("You are using a alpha branch! v" + Program.Version);
        }
    }

    protected override void Draw() 
    {
        base.Draw();
        
        Window.SetTitle($"{_title} [FPS: {Time.GetFPS()}]");
    }


    protected override void OnClose()
    {
        base.OnClose();

        DiscordManager.Client.Dispose();
        Environment.Exit(0);
    }
}