using CopperDevs.DearImGui;
using CopperDevs.DearImGui.Attributes;
using CopperDevs.DearImGui.Rendering;
using ImGuiNET;
using Sparkle_Editor.Code.Managers;
using Sparkle.CSharp.Logging;
using Sparkle.CSharp.Scenes;

namespace Sparkle_Editor.Code.ImGui;

[Window("EntityList", WindowOpen = true)]
public class EntityList : BaseWindow
{
    public override void WindowUpdate()
    {
        CopperImGui.Button("Delete entity", () =>
        {
            if (SelectingManager.SelectedEntity == null) return;

            SelectingManager.SelectedEntity.Dispose();
            SelectingManager.SelectedEntity = null;
            Logger.Info("Entity has been deleted!");
        });
        
        foreach (var entity in SceneManager.ActiveScene.GetEntities())
        {
            if (entity == null || entity.HasDisposed) continue;
            
            ImGuiTreeNodeFlags flag = ImGuiTreeNodeFlags.Leaf;
            if (SelectingManager.SelectedEntity == entity) flag |= ImGuiTreeNodeFlags.Selected;
            
            if (ImGuiNET.ImGui.TreeNodeEx($"{entity.Id}: Entity", flag))
            {
                if (ImGuiNET.ImGui.IsItemClicked())
                {
                    Logger.Info($"Entity: {entity.Id}");
                    SelectingManager.SelectedEntity = entity;
                }
                
                ImGuiNET.ImGui.TreePop();
            }
        }
    }
}
