using System.Numerics;
using CopperDevs.DearImGui;
using CopperDevs.DearImGui.Attributes;
using CopperDevs.DearImGui.Rendering;
using ImGuiNET;
using Sparkle_Editor.Code.Managers;

namespace Sparkle_Editor.Code.ImGui;

[Window("Inspector", WindowOpen = true)]
public class Inspector : BaseWindow
{
    public override void WindowUpdate()
    {
        var ent = SelectingManager.SelectedEntity;
         
        if (ent == null) return;

        Vector3 tempPosition = ent.Position;
        
        CopperImGui.Text($"ID: {ent.Id}");
        CopperImGui.Text($"TAG: {ent.Tag}");
        CopperImGui.HorizontalGroup(() => {ImGuiNET.ImGui.DragFloat("X", ref tempPosition.X);});
        CopperImGui.HorizontalGroup(() => {ImGuiNET.ImGui.DragFloat("Y", ref tempPosition.Y);}); 
        CopperImGui.HorizontalGroup(() => {ImGuiNET.ImGui.DragFloat("Z", ref tempPosition.Z);});
        CopperImGui.Separator("Components");

        ent.Position = tempPosition;
    }
}