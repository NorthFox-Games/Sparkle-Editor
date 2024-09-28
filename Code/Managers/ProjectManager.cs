using NativeFileDialogNET;

namespace Sparkle_Editor.Code.Managers;

public static class ProjectManager
{
    public static string? OpenExistProject()
    {
        using var selectFileDialog = new NativeFileDialog()
            .SelectFile()
            .AddFilter("Sparkle Editor Project", "seproj"); // Optionally add filters

        DialogResult result = selectFileDialog.Open(out string? output, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
        return result == DialogResult.Okay ? output : String.Empty;
    }
}