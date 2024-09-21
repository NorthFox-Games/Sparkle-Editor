using System.Numerics;
using Raylib_CSharp.Collision;
using Raylib_CSharp.Interact;
using Raylib_CSharp.Rendering;
using Raylib_CSharp.Transformations;
using Sparkle_Editor.Code.Entities;
using Sparkle.CSharp.Entities;
using Sparkle.CSharp.Scenes;

namespace Sparkle_Editor.Code.Scenes;

public class Test : Scene
{
    private const int Range = 8; // Диапазон проверки между камерой и сущностью
    
    public Test() : base("Test", SceneType.Scene3D) { }

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
        
        if (Input.IsMouseButtonDown(MouseButton.Left))
        {
            Vector2 mousePosition = Input.GetMousePosition();

            // get ray of camera
            Ray mouseRay = SceneManager.ActiveCam3D.GetMouseRay(mousePosition);

            // foreach all entities on scene
            foreach (Entity entity in this.GetEntities())
            {
                Vector3 entityPosition = entity.Position; // 3D pos entity
                Vector3 entitySize = entity.Scale;        // Scale of entity

                Vector3 minBounds = entityPosition - (entitySize / 2);
                Vector3 maxBounds = entityPosition + (entitySize / 2);

                // check intersects of aabb
                if (RayIntersectsAABB(mouseRay, minBounds, maxBounds))
                {
                    if (IsEntityInCameraRange(entity, Range))
                    {
                        Console.WriteLine($"Entity {entity.Id} selected by cursor.");
                        break;
                    }
                }
            }
        }
    }
    
    private bool IsEntityInCameraRange(Entity entity, float range)
    {
        Vector3 entityPosition = entity.Position; // get 3D pos entity
        Vector3 cameraPosition = SceneManager.ActiveCam3D.Position;

        // Calculate the distance between the camera and the entity
        float distance = Vector3.Distance(entityPosition, cameraPosition);

        // Check if the entity is within the specified range
        return distance <= range;
    }

    // Checking ray intersection with AABB (axis-aligned bounding box)
    private bool RayIntersectsAABB(Ray ray, Vector3 minBounds, Vector3 maxBounds)
    {
        float tmin = (minBounds.X - ray.Position.X) / ray.Direction.X;
        float tmax = (maxBounds.X - ray.Position.X) / ray.Direction.X;

        if (tmin > tmax)
        {
            float temp = tmin;
            tmin = tmax;
            tmax = temp;
        }

        float tymin = (minBounds.Y - ray.Position.Y) / ray.Direction.Y;
        float tymax = (maxBounds.Y - ray.Position.Y) / ray.Direction.Y;

        if (tymin > tymax)
        {
            float temp = tymin;
            tymin = tymax;
            tymax = temp;
        }

        if ((tmin > tymax) || (tymin > tmax))
            return false;

        if (tymin > tmin)
            tmin = tymin;

        if (tymax < tmax)
            tmax = tymax;

        float tzmin = (minBounds.Z - SceneManager.ActiveCam3D.Position.Z) / ray.Direction.Z;
        float tzmax = (maxBounds.Z - SceneManager.ActiveCam3D.Position.Z) / ray.Direction.Z;

        if (tzmin > tzmax)
        {
            float temp = tzmin;
            tzmin = tzmax;
            tzmax = temp;
        }

        if ((tmin > tzmax) || (tzmin > tmax))
            return false;

        return true;
    }
}