using System.Numerics;
using CopperDevs.DearImGui;
using CopperDevs.DearImGui.Renderer.Raylib;
using Raylib_CSharp.Logging;
using Sparkle_Editor.Code.Entities;
using Sparkle_Editor.Code.Managers;
using Sparkle.CSharp.Overlays;
using Logger = Sparkle.CSharp.Logging.Logger;

namespace Sparkle_Editor.Code.ImGui;

public class DearImGuiOverlay : Overlay
{
    public DearImGuiOverlay(string name) : base(name)
    {
        CopperImGui.Setup<RlImGuiRenderer>(true, true);
        CopperImGui.ShowDearImGuiAboutWindow = false;
        CopperImGui.ShowDearImGuiDemoWindow = true;
        CopperImGui.ShowDearImGuiMetricsWindow = false;
        CopperImGui.ShowDearImGuiDebugLogWindow = false;
        CopperImGui.ShowDearImGuiIdStackToolWindow = false;

        (string, Action)[] MenuActions = new (string, Action)[]
        {
            new ValueTuple<string, Action>("Project", () =>
            {
                CopperImGui.MenuItem("New", () => Logger.Info("New Project"));
                CopperImGui.MenuItem("Open", () => Logger.Info(ProjectManager.OpenExistProject()!));
            }),
            
            new ValueTuple<string, Action>("Create Entity", () =>
            {
                CopperImGui.MenuItem("Cube", () => SelectingManager.CreateEntity(new ModelRender(new Vector3(0f,0f,0f), ContentRegistry.Models["Cube"])));
                CopperImGui.MenuItem("Cone", () => SelectingManager.CreateEntity(new ModelRender(new Vector3(0f,0f,0f), ContentRegistry.Models["Cone"])));
                CopperImGui.MenuItem("Sphere", () => SelectingManager.CreateEntity(new ModelRender(new Vector3(0f,0f,0f), ContentRegistry.Models["Sphere"])));
                CopperImGui.MenuItem("Plane", () => SelectingManager.CreateEntity(new ModelRender(new Vector3(0f,0f,0f), ContentRegistry.Models["Plane"])));
                CopperImGui.MenuItem("Cylinder", () => SelectingManager.CreateEntity(new ModelRender(new Vector3(0f,0f,0f), ContentRegistry.Models["Cylinder"])));
            }),
        };
        
        CopperImGui.PreRendered += () =>
        {
            CopperImGui.MenuBar(true, MenuActions);
        };
    }

    protected override void Draw()
    {
        CopperImGui.Render();
    }

    ~DearImGuiOverlay()
    {
        CopperImGui.Shutdown();
    }
}