using CopperDevs.DearImGui;
using CopperDevs.DearImGui.Attributes;
using CopperDevs.DearImGui.Rendering;
using Sparkle_Editor.Code.Managers;

namespace Sparkle_Editor.Code.ImGui;

[Window("Projects", WindowOpen = true)]
public class ProjectsList : BaseWindow
{
    private bool _newProject = false;
    
    public override void WindowUpdate()
    {
        base.WindowUpdate();
        
        ImGuiNET.ImGui.SetWindowFocus();

        if (_newProject)
        {
            CopperImGui.Button("Back", () => {_newProject = false;});
            CopperImGui.Text("KUKU EPTA NAHUI");
            return;
        }
        
        CopperImGui.Separator("Welcome to Sparkle Editor!");

        CopperImGui.HorizontalGroup(
            () => CopperImGui.Button("New", () => { _newProject = true; }),
            () => CopperImGui.Button("Open", OpenProject)); //TODO: center the buttons
        
        CopperImGui.Separator("Last projects");
    }

    private void OpenProject()
    {
        string? path = ProjectManager.OpenExistProject();
        
        if (path == null) return;
        
        ImGuiNET.ImGui.CloseCurrentPopup();
    }
}