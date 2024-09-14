using System.Numerics;
using Raylib_CSharp.Camera.Cam3D;
using Raylib_CSharp.Rendering;
using Sparkle_Editor.Code.Entities;
using Sparkle.CSharp.Entities;
using Sparkle.CSharp.Scenes;

namespace Sparkle_Editor.Code.Scenes;

public class Test : Scene {
    
    public Test() : base("Default Scene", SceneType.Scene3D) { }

    protected override void Init() 
    {
        base.Init();
        
        Vector3 pos = new Vector3(10.0f, 10.0f, 10.0f);
        EditorCam cam3D = new EditorCam(pos, Vector3.Zero, Vector3.UnitY, 90, CameraProjection.Perspective);
        cam3D.MouseSensitivity = 1f;
        
        this.AddEntity(cam3D);
    }
    
    protected override void Draw() 
    {
        base.Draw();
        
        SceneManager.ActiveCam3D!.BeginMode3D();
        
        Graphics.DrawGrid(100, 1);
        
        SceneManager.ActiveCam3D.EndMode3D();
    }
}