using Sparkle.CSharp.Entities;
using Sparkle.CSharp.Logging;

namespace Sparkle_Editor.Code.Managers;

public static class SelectingManager
{
    public static Entity SelectedEntity { get; set; }

    public static void DeleteSelectedEntity()
    {
        SelectedEntity.Dispose();
        SelectedEntity = null;
        Logger.Info("Entity has been deleted!");
    }
}