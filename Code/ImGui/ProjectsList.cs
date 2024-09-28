using CopperDevs.DearImGui;
using CopperDevs.DearImGui.Attributes;
using CopperDevs.DearImGui.Rendering;

namespace Sparkle_Editor.Code.ImGui;

[Window("Projects", WindowOpen = true)]
public class ProjectsList : BaseWindow
{
    public override void WindowUpdate()
    {
        base.WindowUpdate();
        
        CopperImGui.Separator("Welcome to Sparkle Editor");
        
        CopperImGui.HorizontalGroup(
            () => CopperImGui.Button("New", () => {throw new NotImplementedException();}),
            () => { CopperImGui.Button("Open", () => {throw new NotImplementedException();}); });
    }
}