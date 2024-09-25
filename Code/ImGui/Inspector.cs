using CopperDevs.DearImGui;
using CopperDevs.DearImGui.Attributes;
using CopperDevs.DearImGui.Rendering;
using Sparkle_Editor.Code.Managers;

namespace Sparkle_Editor.Code.ImGui;

[Window("Inspector", WindowOpen = true)]
public class Inspector : BaseWindow
{
    public override void WindowUpdate()
    {
        var ent = SelectingManager.SelectedEntity;
         
        if (ent == null) return;
        
        CopperImGui.Text($"ID: {ent.Id}");
        CopperImGui.Text($"TAG: {ent.Tag}");
        CopperImGui.Separator("Components");
        CopperImGui.HorizontalGroup(() => {ImGuiNET.ImGui.InputText("X", new byte[16], 16);});
        CopperImGui.HorizontalGroup(() => {ImGuiNET.ImGui.InputText("Y", new byte[16], 16);}); 
        CopperImGui.HorizontalGroup(() => {ImGuiNET.ImGui.InputText("Z", new byte[16], 16);});
    }
}