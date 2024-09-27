using System.Numerics;
using Raylib_CSharp.Interact;
using Raylib_CSharp.Rendering;
using Sparkle_Editor.Code.Entities;
using Sparkle_Editor.Code.EventArgs;
using Sparkle.CSharp.Entities;
using Sparkle.CSharp.Entities.Components;
using Sparkle.CSharp.Logging;
using Sparkle.CSharp.Scenes;

namespace Sparkle_Editor.Code.Scenes;

public class Test : Scene
{
    public Test() : base("Test", SceneType.Scene3D) { }
    
    private static event EventHandler<CreateEntityEventArgs> CreateEntityEvent; //nado sdelat: find new realization because its a shit

    protected override void Init() 
    {
        base.Init();
        
        Vector3 pos = new(10.0f, 10.0f, 10.0f);
        EditorCam cam3D = new(pos, Vector3.Zero, Vector3.UnitY);
        cam3D.MouseSensitivity = 1f;
        
        AddEntity(cam3D);
        
        //for test
        AddEntity(new ModelRender(new Vector3(0f,0f,0f), ContentRegistry.Models["Cube"]));
        AddEntity(new ModelRender(new Vector3(2f,0f,0f), ContentRegistry.Models["Cone"]));
        AddEntity(new ModelRender(new Vector3(4f,0f,0f), ContentRegistry.Models["Sphere"]));
        AddEntity(new ModelRender(new Vector3(6f,0f,0f), ContentRegistry.Models["Plane"]));
        AddEntity(new ModelRender(new Vector3(8f,0f,0f), ContentRegistry.Models["Cylinder"]));
        AddEntity(new Gizmos(new Vector3(-8f,0f,0f)));
        
        CreateEntityEvent += OnCreateEntity;
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

        if (Input.IsMouseButtonReleased(MouseButton.Left) && Physics.Raycast(out Entity hit))
        {
            Logger.Info($"Entity ID: {hit.Id}");
        }
    }
    
    private void OnCreateEntity(object sender, CreateEntityEventArgs ev)
    {
        var ent = new Entity(ev.Entity.Position);
        ent.Rotation = ev.Entity.Rotation;
        ent.Scale = ev.Entity.Scale;
        ent.Tag = ev.Entity.Tag;
        ent.AddComponent(ev.Entity.GetComponent<ModelRenderer>());
        
        AddEntity(ent);
    }
    
    public static void CreateEntity(Entity entity)
    {
        if (CreateEntityEvent != null)
        {
            CreateEntityEventArgs args = new CreateEntityEventArgs(entity);
            CreateEntityEvent("skull", args);
        }
    }
}