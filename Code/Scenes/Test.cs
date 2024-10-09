using System.Numerics;
using Raylib_CSharp.Interact;
using Raylib_CSharp.Rendering;
using Sparkle_Editor.Code.Entities;
using Sparkle_Editor.Code.Managers;
using Sparkle.CSharp.Entities;
using Sparkle.CSharp.Logging;
using Sparkle.CSharp.Scenes;

namespace Sparkle_Editor.Code.Scenes;

public class Test : Scene
{
    public Test() : base("Test", SceneType.Scene3D) { }
    
    protected override void Init() 
    {
        base.Init();
        
        EditorCam cam3D = new(new Vector3(10, 10, 10), Vector3.Zero, Vector3.UnitY);
        cam3D.MouseSensitivity = 1f;
        
        AddEntity(cam3D);
        
        //for test
        AddEntity(new ModelRender(new Vector3(0f,0f,0f), ContentRegistry.Models["Cube"]));
        AddEntity(new ModelRender(new Vector3(2f,0f,0f), ContentRegistry.Models["Cone"]));
        AddEntity(new ModelRender(new Vector3(4f,0f,0f), ContentRegistry.Models["Sphere"]));
        AddEntity(new ModelRender(new Vector3(6f,0f,0f), ContentRegistry.Models["Plane"]));
        AddEntity(new ModelRender(new Vector3(8f,0f,0f), ContentRegistry.Models["Cylinder"]));
    }
    
    protected override void Draw() 
    {
        base.Draw();
        
        SceneManager.ActiveCam3D!.BeginMode3D();
        
        Graphics.DrawGrid(100, 1);
        
        SceneManager.ActiveCam3D.EndMode3D();
    }

    protected override void Update()
    {
        base.Update();
        
        if (Input.IsMouseButtonReleased(MouseButton.Left) && Physics.Raycast(out Entity hitM) && Input.IsKeyDown(KeyboardKey.LeftControl))
        {
            SelectingManager.SelectedEntity.Add(hitM);
            Logger.Info($"Entity ID: {hitM.Id}");
        }
        else if (Input.IsMouseButtonReleased(MouseButton.Left) && Physics.Raycast(out Entity hit))
        {
            SelectingManager.SelectedEntity.Clear();
            SelectingManager.SelectedEntity.Add(hit);
            Logger.Info($"Entity ID: {hit.Id}");
        }
    }
}