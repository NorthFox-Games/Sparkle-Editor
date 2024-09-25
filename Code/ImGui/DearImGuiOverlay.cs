using CopperDevs.DearImGui;
using CopperDevs.DearImGui.Renderer.Raylib;
using CopperDevs.Logger;
using Sparkle.CSharp.Overlays;

namespace Sparkle_Editor.Code.ImGui;

public class DearImGuiOverlay : Overlay
{
    public DearImGuiOverlay(string name) : base(name)
    {
        CopperImGui.Setup<RlImGuiRenderer>(true, true);
        CopperImGui.ShowDearImGuiAboutWindow = true;
        CopperImGui.ShowDearImGuiDemoWindow = false;
        CopperImGui.ShowDearImGuiMetricsWindow = false;
        CopperImGui.ShowDearImGuiDebugLogWindow = false;
        CopperImGui.ShowDearImGuiIdStackToolWindow = false;
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