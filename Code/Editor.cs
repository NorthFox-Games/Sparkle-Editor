using Raylib_CSharp;
using Raylib_CSharp.Interact;
using Raylib_CSharp.Windowing;
using Sparkle_Editor.Code.Managers;
using Sparkle_Editor.Code.ImGui;
using Sparkle.CSharp;
using Sparkle.CSharp.Entities;
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
        RegistryManager.Add(new ContentRegistry());

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

    protected override void Update()
    {
        base.Update();
        
        if (Input.IsMouseButtonReleased(MouseButton.Left) && Physics.Raycast(out Entity hitM) && Input.IsKeyDown(KeyboardKey.LeftControl))
        {
            SelectingManager.SelectedEntity.Add(hitM);
            Logger.Info($"Entity ID: {hitM.Id}");
        }
        else if (Input.IsMouseButtonReleased(MouseButton.Left) && Physics.Raycast(out Entity hit))
        {
            SelectingManager.SelectedEntity.Clear();
            SelectingManager.SelectedEntity.Add(hit);
            Logger.Info($"Entity ID: {hit.Id}");
        }

        if (Input.IsKeyDown(KeyboardKey.LeftControl) && Input.IsKeyPressed(KeyboardKey.C))
        {
            SelectingManager.CopySelectedEntity();
        }
        if (Input.IsKeyDown(KeyboardKey.LeftControl) && Input.IsKeyPressed(KeyboardKey.V))
        {
            SelectingManager.PasteSelectedEntity();
        }
        if (Input.IsKeyDown(KeyboardKey.LeftControl) && Input.IsKeyPressed(KeyboardKey.D))
        {
            SelectingManager.DuplicateSelectedEntity();
        }
        if (Input.IsKeyPressed(KeyboardKey.Delete))
        {
            SelectingManager.DeleteSelectedEntity();
        }
    }
    
    protected override void OnClose()
    {
        base.OnClose();

        DiscordManager.Client.Dispose();
        Environment.Exit(0);
    }
}