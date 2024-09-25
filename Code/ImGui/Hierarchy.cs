using CopperDevs.DearImGui;
using CopperDevs.DearImGui.Attributes;
using CopperDevs.DearImGui.Rendering;
using Sparkle.CSharp.Entities;
using Sparkle.CSharp.Logging;
using Sparkle.CSharp.Scenes;

namespace Sparkle_Editor.Code.ImGui;

[Window("Hierarchy", WindowOpen = true)]
public class Hierarchy : BaseWindow // inheriting from BaseWindow isn't required (only applying the Window attribute is), but you can inherit from it anyways so you can hard type the names
{
    private Entity _selectedEntity = null;
    
    public override void WindowUpdate()
    {
        CopperImGui.Button("Delete entity", () =>
        {
            if (_selectedEntity == null) return;

            _selectedEntity.Dispose();
            _selectedEntity = null;
            Logger.Info("Entity has been deleted!");
        });
        
        foreach (var entity in SceneManager.ActiveScene.GetEntities())
        {
            if (entity == null || entity.HasDisposed) continue;
            
            CopperImGui.Button($"{entity.Id}: Entity", () =>
            {
                Logger.Info($"Entity: {entity.Id}");
                _selectedEntity = entity;
            });
        }
    }
}