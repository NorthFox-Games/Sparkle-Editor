using Sparkle.CSharp.Entities;
using Sparkle.CSharp.Logging;
using Sparkle.CSharp.Scenes;

namespace Sparkle_Editor.Code.Managers;

public static class SelectingManager // componenty pohui na copirovanie, Ispravit!
{
    public static Entity SelectedEntity { get; set; }
    public static Entity Buffer { get; set; }

    public static void DeleteSelectedEntity()
    {
        if (SelectedEntity == null) return;
        
        SelectedEntity.Dispose();
        SelectedEntity = null;
        
        Logger.Info("Entity has been deleted!");
    }
    
    public static void CopySelectedEntity()
    {
        if (SelectedEntity == null) return;
        
        Buffer = SelectedEntity;
        
        Logger.Info("Entity has been copied!");
    }
    
    public static void PasteSelectedEntity()
    {
        if (Buffer == null) return;

        Duplicate(Buffer);
        
        Logger.Info("Entity has been copied!");
    }
    
    public static void DuplicateSelectedEntity()
    {
        if (SelectedEntity == null) return;
        
        Duplicate(SelectedEntity);
        
        Logger.Info("Entity has been copied!");
    }

    private static Entity Duplicate(Entity entity)
    {
        Entity duplicate = new Entity(entity.Position)
        {
            Rotation = entity.Rotation,
            Scale = entity.Scale,
            Tag = entity.Tag
        };

        foreach (var component in entity.GetComponents())
        {
            duplicate.AddComponent(component.Clone());
        }
        
        SceneManager.ActiveScene?.AddEntity(duplicate);
        
        return duplicate;
    }
}