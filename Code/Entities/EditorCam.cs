using System.Numerics;
using Raylib_CSharp.Camera.Cam3D;
using Raylib_CSharp.Interact;
using Sparkle.CSharp.Entities;

namespace Sparkle_Editor.Code.Entities;

public class EditorCam : Cam3D
{
    public EditorCam(Vector3 position, Vector3 target, Vector3 up, float fov = 90, CameraProjection projection = CameraProjection.Perspective, CameraMode mode = CameraMode.Free)
        : base(position, target, up, fov, projection, mode) { }

    protected override void Update()
    {
        base.Update();

        if (Mode != CameraMode.Free && Input.IsMouseButtonDown(MouseButton.Right))
        {
            Mode = CameraMode.Free;
            Input.HideCursor();
            Input.DisableCursor();
        } 
        else if (Mode != CameraMode.Custom && !Input.IsMouseButtonDown(MouseButton.Right))
        {
            Mode = CameraMode.Custom;
            Input.ShowCursor();
            Input.EnableCursor();
        }
    }
}