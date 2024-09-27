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
        Quaternion tempRotation = ent.Rotation;
        Vector3 tempScale = ent.Scale;
        
        CopperImGui.HorizontalGroup(
            () => {CopperImGui.Button("Delete", () => {SelectingManager.SelectedEntity.Dispose();});}
            //() => {CopperImGui.Button("Copy", () => { SelectingManager.CopyEntity();});}, 
            //() => {CopperImGui.Button("Paste", () => { SelectingManager.PasteEntity();});},
            //() => {CopperImGui.Button("Duplicate", () => { SelectingManager.DuplicateEntity();});
            );

        CopperImGui.Separator("Information");
        
        CopperImGui.Text($"Id: {ent.Id}");
        //CopperImGui.Text($"Name: {ent}");
        if (!string.IsNullOrEmpty(ent.Tag))
        {
            CopperImGui.Text($"Tag: {ent.Tag}");
        }
        
        CopperImGui.Space();
        
        ImGuiTreeNodeFlags flag = ImGuiTreeNodeFlags.DefaultOpen | ImGuiTreeNodeFlags.OpenOnArrow | ImGuiTreeNodeFlags.OpenOnDoubleClick;
        
        if (ImGuiNET.ImGui.TreeNodeEx("Position", flag))
        {
            CopperImGui.HorizontalGroup(() => {ImGuiNET.ImGui.DragFloat("X", ref tempPosition.X);});
            CopperImGui.HorizontalGroup(() => {ImGuiNET.ImGui.DragFloat("Y", ref tempPosition.Y);}); 
            CopperImGui.HorizontalGroup(() => {ImGuiNET.ImGui.DragFloat("Z", ref tempPosition.Z);});
            
            ImGuiNET.ImGui.TreePop();
        }
        //doesnt work
        if (ImGuiNET.ImGui.TreeNodeEx("Rotation", flag))
        {
            CopperImGui.HorizontalGroup(() => {ImGuiNET.ImGui.DragFloat("X", ref tempRotation.X);});
            CopperImGui.HorizontalGroup(() => {ImGuiNET.ImGui.DragFloat("Y", ref tempRotation.Y);}); 
            CopperImGui.HorizontalGroup(() => {ImGuiNET.ImGui.DragFloat("Z", ref tempRotation.Z);});
            
            ImGuiNET.ImGui.TreePop();
        }
        
        if (ImGuiNET.ImGui.TreeNodeEx("Scale", flag))
        {
            CopperImGui.HorizontalGroup(() => {ImGuiNET.ImGui.DragFloat("X", ref tempScale.X);});
            CopperImGui.HorizontalGroup(() => {ImGuiNET.ImGui.DragFloat("Y", ref tempScale.Y);}); 
            CopperImGui.HorizontalGroup(() => {ImGuiNET.ImGui.DragFloat("Z", ref tempScale.Z);});
            
            ImGuiNET.ImGui.TreePop();
        }
        
        ent.Position = tempPosition;
        ent.Rotation = tempRotation;
        ent.Scale = tempScale;
        
        CopperImGui.Separator("Components");
        
        foreach (var comp in ent.GetComponents())
        {
            string compName = comp.ToString().Replace(comp.GetType().Namespace + ".", string.Empty);
            if (ImGuiNET.ImGui.TreeNodeEx(compName, flag))
            {
                Vector3 offsetPos = comp.OffsetPos;
                    
                if (ImGuiNET.ImGui.TreeNodeEx("Offset Position", flag))
                {
                    CopperImGui.HorizontalGroup(() => {ImGuiNET.ImGui.DragFloat("X", ref offsetPos.X);});
                    CopperImGui.HorizontalGroup(() => {ImGuiNET.ImGui.DragFloat("Y", ref offsetPos.Y);}); 
                    CopperImGui.HorizontalGroup(() => {ImGuiNET.ImGui.DragFloat("Z", ref offsetPos.Z);});
            
                    ImGuiNET.ImGui.TreePop();
                }
                
                comp.OffsetPos = offsetPos;
                
                ImGuiNET.ImGui.TreePop();
            }
        }
    }
}