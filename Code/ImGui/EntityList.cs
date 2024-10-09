using CopperDevs.DearImGui;
using CopperDevs.DearImGui.Attributes;
using CopperDevs.DearImGui.Rendering;
using ImGuiNET;
using Raylib_CSharp.Interact;
using Sparkle_Editor.Code.Managers;
using Sparkle.CSharp.Logging;
using Sparkle.CSharp.Scenes;

namespace Sparkle_Editor.Code.ImGui;

[Window("EntityList", WindowOpen = true)]
public class EntityList : BaseWindow
{
    public override void WindowUpdate()
    {
        base.WindowUpdate();
        
        if (ImGuiNET.ImGui.TreeNodeEx(SceneManager.ActiveScene?.Name, ImGuiTreeNodeFlags.DefaultOpen | ImGuiTreeNodeFlags.OpenOnArrow | ImGuiTreeNodeFlags.OpenOnDoubleClick))
        {
            foreach (var entity in SceneManager.ActiveScene?.GetEntities()!)
            {
                if (entity == null || entity.HasDisposed || entity.Id == 1) continue;
                
                ImGuiTreeNodeFlags flag = ImGuiTreeNodeFlags.Leaf;
                if (SelectingManager.SelectedEntity.Contains(entity)) flag |= ImGuiTreeNodeFlags.Selected;
                
                string name = $"{entity.Id}: Entity";
                
                if (!string.IsNullOrEmpty(entity.Tag))
                {
                    name = $"{entity.Id}: {entity.Tag}";
                }
                
                if (ImGuiNET.ImGui.TreeNodeEx(name, flag))
                {
                    if (ImGuiNET.ImGui.IsItemClicked() && Input.IsKeyDown(KeyboardKey.LeftControl))
                    {
                        Logger.Info($"Entity: {entity.Id}");
                        SelectingManager.SelectedEntity.Add(entity);
                    }
                    else if (ImGuiNET.ImGui.IsItemClicked())
                    {
                        Logger.Info($"Entity: {entity.Id}");
                        SelectingManager.SelectedEntity.Clear();
                        SelectingManager.SelectedEntity.Add(entity);
                    }
                
                    ImGuiNET.ImGui.TreePop();
                }
            }
        }
    }
}
