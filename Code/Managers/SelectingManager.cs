using Sparkle_Editor.Code.Scenes;
using Sparkle.CSharp.Entities;
using Sparkle.CSharp.Logging;

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
        
        Test.CreateEntity(Buffer);
        
        Logger.Info("Entity has been copied!");
    }
    
    public static void DuplicateSelectedEntity()
    {
        if (SelectedEntity == null) return;
        
        Test.CreateEntity(SelectedEntity);
        
        Logger.Info("Entity has been copied!");
    }
}