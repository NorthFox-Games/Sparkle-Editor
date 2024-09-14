using System.Numerics;
using Raylib_CSharp.Camera.Cam3D;
using Raylib_CSharp.Rendering;
using Sparkle.CSharp.Entities;
using Sparkle.CSharp.Scenes;

namespace Sparkle_Editor.Code.Scenes;

public class DefaultScene : Scene {
    
    public DefaultScene() : base("Default Scene", SceneType.Scene3D) { }

    protected override void Init() {
        base.Init();
        
        Vector3 pos = new Vector3(10.0f, 10.0f, 10.0f);
        Cam3D cam3D = new Cam3D(pos, Vector3.Zero, Vector3.UnitY, 90, CameraProjection.Perspective);
        cam3D.MouseSensitivity = 1.5f;
        
        this.AddEntity(cam3D);
    }
    
    protected override void Draw() {
        base.Draw();
        
        // BEGIN 3D
        SceneManager.ActiveCam3D!.BeginMode3D();
        
        //DRAW GIRD
        Graphics.DrawGrid(100, 1);
        
        // END 3D
        SceneManager.ActiveCam3D.EndMode3D();
    }
}