﻿using CopperDevs.DearImGui;
using CopperDevs.DearImGui.Renderer.Raylib;
using Sparkle.CSharp.Overlays;

namespace Sparkle_Editor.Code.ImGui;

public class DearImGuiOverlay : Overlay
{
    public DearImGuiOverlay(string name) : base(name)
    {
        CopperImGui.Setup<RlImGuiRenderer>(true, true);
        CopperImGui.ShowDearImGuiAboutWindow = true;
        CopperImGui.ShowDearImGuiDemoWindow = true;
        CopperImGui.ShowDearImGuiMetricsWindow = true;
        CopperImGui.ShowDearImGuiDebugLogWindow = true;
        CopperImGui.ShowDearImGuiIdStackToolWindow = true;
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