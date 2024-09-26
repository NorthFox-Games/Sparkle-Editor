using Sparkle_Editor.Code.Entities.Editor;
using Sparkle_Editor.Code.Scenes;
using Sparkle.CSharp.Entities;
using Sparkle.CSharp.Logging;
using Sparkle.CSharp.Scenes;

namespace Sparkle_Editor.Code.Managers;

public class SelectingManager
{
    public static EditorEntity SelectedEntity { get; set; }

    public static EditorEntity Buffer { get; set; }

    public static void CleanBuffer() => Buffer = null;
    
    public static void DeleteEntity()
    {
        if (SelectedEntity == null) return;

        SelectedEntity.Dispose();
        SelectedEntity = null;
        
        Logger.Info("Entity has been deleted!");
    }
    
    public static void CopyEntity()
    {
        if (SelectedEntity == null) return;

        Buffer = SelectedEntity;
        
        Logger.Info("Entity has been copied!");
    }
    
    public static void PasteEntity()
    {
        if (Buffer == null) return;
        
        Test.CreateEntityInvoke(Buffer);
        
        Logger.Info("Entity has been pasted!");
    }
    
    public static void DuplicateEntity()
    {
        if (SelectedEntity == null) return;
        
        Test.CreateEntityInvoke(SelectedEntity);
        
        Logger.Info("Entity has been duplicated!");
    }
}