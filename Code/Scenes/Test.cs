using System.Numerics;
using Raylib_CSharp.Rendering;
using Sparkle_Editor.Code.Entities;
using Sparkle_Editor.Code.Entities.Primitives;
using Sparkle.CSharp.Scenes;

namespace Sparkle_Editor.Code.Scenes;

public class Test : Scene
{
    public Test() : base("Test", SceneType.Scene3D) { }

    protected override void Init() 
    {
        base.Init();
        
        Vector3 pos = new(10.0f, 10.0f, 10.0f);
        EditorCam cam3D = new(pos, Vector3.Zero, Vector3.UnitY);
        cam3D.MouseSensitivity = 1f;
        
        AddEntity(cam3D);
        AddEntity(new Cube(new Vector3(0f,0f,0f)));
    }
    
    protected override void Draw() 
    {
        base.Draw();
        
        SceneManager.ActiveCam3D!.BeginMode3D();
        
        Graphics.DrawGrid(100, 1);
        
        SceneManager.ActiveCam3D.EndMode3D();
    }
}