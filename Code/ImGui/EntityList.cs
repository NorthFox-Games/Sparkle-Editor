using CopperDevs.DearImGui.Attributes;
using CopperDevs.DearImGui.Rendering;
using ImGuiNET;
using Sparkle_Editor.Code.API;
using Sparkle_Editor.Code.Entities.Editor;
using Sparkle_Editor.Code.Managers;
using Sparkle.CSharp.Logging;
using Sparkle.CSharp.Scenes;

namespace Sparkle_Editor.Code.ImGui;

[Window("EntityList", WindowOpen = true)]
public class EntityList : BaseWindow
{
    public override void WindowUpdate()
    {
        if (ImGuiNET.ImGui.TreeNodeEx(SceneManager.ActiveScene.Name, ImGuiTreeNodeFlags.DefaultOpen | ImGuiTreeNodeFlags.OpenOnArrow | ImGuiTreeNodeFlags.OpenOnDoubleClick))
        {
            var entities = SceneManager.ActiveScene.GetEntities();
            entities = entities.RemoveAt(0);
            
            foreach (EditorEntity entity in entities)
            {
                if (entity == null || entity.HasDisposed) continue;
            
                ImGuiTreeNodeFlags flag = ImGuiTreeNodeFlags.Leaf;
                if (SelectingManager.SelectedEntity == entity) flag |= ImGuiTreeNodeFlags.Selected;
            
                if (ImGuiNET.ImGui.TreeNodeEx($"{entity.Id}: {entity.Name}", flag))
                {
                    if (ImGuiNET.ImGui.IsItemClicked())
                    {
                        Logger.Info($"Entity: {entity.Id}");
                        SelectingManager.SelectedEntity = entity;
                    }
                
                    ImGuiNET.ImGui.TreePop();
                }
            }
            
            ImGuiNET.ImGui.TreePop();
        }
    }
}
