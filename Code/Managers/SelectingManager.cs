using Sparkle.CSharp.Entities;
using Sparkle.CSharp.Logging;
using Sparkle.CSharp.Scenes;

namespace Sparkle_Editor.Code.Managers;

public static class SelectingManager // componenty pohui na copirovanie, Ispravit! // ne pihi translitom debil!
{
    public static List<Entity> SelectedEntity { get; set; } = new();
    public static List<Entity> Buffer { get; set; }

    public static void DeleteSelectedEntity()
    {
        if (SelectedEntity == null) return;

        var entitiesToRemove = SelectedEntity.ToList();
        
        foreach (var ent in entitiesToRemove)
        {
            ent.Dispose();
            SelectedEntity.Remove(ent);
        }
        entitiesToRemove.Clear();
        
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
        
        foreach (var ent in Buffer)
        {
            CreateEntity(ent);
        }
        
        Logger.Info("Entity has been copied!");
    }
    
    public static void DuplicateSelectedEntity()
    {
        if (SelectedEntity == null) return;
        
        foreach (var ent in SelectedEntity)
        {
            CreateEntity(ent);
        }
        
        Logger.Info("Entity has been copied!");
    }

    private static Entity CreateEntity(Entity entity)
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