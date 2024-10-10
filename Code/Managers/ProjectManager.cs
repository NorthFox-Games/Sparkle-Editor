using NativeFileDialogNET;

namespace Sparkle_Editor.Code.Managers;

public static class ProjectManager
{
    public static string? OpenExistProject()
    {
        using var selectFileDialog = new NativeFileDialog()
            .SelectFile()
            .AddFilter("Sparkle Editor Project", "seproj");

        DialogResult result = selectFileDialog.Open(out string? output, Environment.GetFolderPath(Environment.SpecialFolder.Personal));
        return result == DialogResult.Okay ? output : String.Empty;
    }
}