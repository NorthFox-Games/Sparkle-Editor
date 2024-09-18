using OpenTK.Mathematics;
using Raylib_CSharp;
using Raylib_CSharp.Camera.Cam3D;
using Raylib_CSharp.Collision;
using Raylib_CSharp.Windowing;
using Sparkle.CSharp;
using Sparkle.CSharp.Entities.Components;
using Sparkle.CSharp.Registries;

namespace Sparkle_Editor.Code;

public class Editor : Game
{
    private string _title;

    public Editor(GameSettings settings, string title = "Sparkle Editor") : base(settings)
    {
        _title = title;
    }

    protected override void Init() 
    {
        base.Init();
        
        Window.SetTitle(_title);
    }
    
    protected override void OnRun()
    {
        base.OnRun();
        RegistryManager.AddType(new ContentRegistry());
    }

    protected override void Draw() 
    {
        base.Draw();
        
        Window.SetTitle($"{_title} [FPS: {Time.GetFPS()}]");
    }
    
    public Ray CalculateRay(Vector2 screenPosition, Matrix4 projectionMatrix, Matrix4 viewMatrix, int screenWidth, int screenHeight, Vector3 cameraPosition)
    {
        // Normalize screen coordinates
        float x = (2.0f * screenPosition.X) / screenWidth - 1.0f;
        float y = 1.0f - (2.0f * screenPosition.Y) / screenHeight;
        Vector4 clipCoords = new Vector4(x, y, -1.0f, 1.0f);

        // Inverse projection matrix
        Matrix4 invProjection = Matrix4.Invert(projectionMatrix);
        Vector4 eyeCoords = invProjection * clipCoords;
        eyeCoords.Z = -1.0f;
        eyeCoords.W = 0.0f;

        // Inverse view matrix
        Matrix4 invView = Matrix4.Invert(viewMatrix);
        Vector3 rayWorld = Vector3.Normalize((invView * eyeCoords).Xyz);

        return new Ray(new System.Numerics.Vector3(cameraPosition.X, cameraPosition.Y, cameraPosition.Z), new System.Numerics.Vector3(rayWorld.X, rayWorld.Y, rayWorld.Z));
    }
    
    public bool RayIntersectsAABB(Ray ray, BoundingBox box, out float distance)
    {
        distance = 0;
        float tmin = (box.Min.X - ray.Position.X) / ray.Direction.X;
        float tmax = (box.Max.X - ray.Position.X) / ray.Direction.X;

        if (tmin > tmax)
        {
            var temp = tmin;
            tmin = tmax;
            tmax = temp;
        }

        float tymin = (box.Min.Y - ray.Position.Y) / ray.Direction.Y;
        float tymax = (box.Max.Y - ray.Position.Y) / ray.Direction.Y;

        if (tymin > tymax)
        {
            var temp = tymin;
            tymin = tymax;
            tymax = temp;
        }

        if ((tmin > tymax) || (tymin > tmax))
            return false;

        if (tymin > tmin)
            tmin = tymin;

        if (tymax < tmax)
            tmax = tymax;

        float tzmin = (box.Min.Z - ray.Position.Z) / ray.Direction.Z;
        float tzmax = (box.Max.Z - ray.Position.Z) / ray.Direction.Z;

        if (tzmin > tzmax)
        {
            var temp = tzmin;
            tzmin = tzmax;
            tzmax = temp;
        }

        if ((tmin > tzmax) || (tzmin > tmax))
            return false;

        if (tzmin > tmin)
            tmin = tzmin;

        if (tzmax < tmax)
            tmax = tzmax;

        distance = tmin;
        return true;
    }
    
    public RigidBody3D RaycastToRigidbody(Vector2 screenPosition, Camera3D camera, List<RigidBody3D> rigidbodies, Matrix4 projectionMatrix, Matrix4 viewMatrix, int screenWidth, int screenHeight)
    {
        // Создаём луч от курсора
        Ray ray = CalculateRay(screenPosition, projectionMatrix, viewMatrix, screenWidth, screenHeight, new Vector3(camera.Position.X, camera.Position.Y, camera.Position.Z));

        RigidBody3D hitRigidbody = null;
        float closestDistance = float.MaxValue;

        // Проверяем пересечение каждого объекта с Rigidbody3D
        foreach (var rigidbody in rigidbodies)
        {
            Coll collider = rigidbody.Collider;  // Предполагается, что у каждого rigidbody есть коллайдер

            if (RayIntersectsAABB(ray, collider.BoundingBox, out float distance))
            {
                // Находим ближайший объект
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    hitRigidbody = rigidbody;
                }
            }
        }

        return hitRigidbody;
    }

}

public class Collider3D
{
    public BoundingBox BoundingBox { get; set; }

    public Collider3D(BoundingBox boundingBox)
    {
        this.BoundingBox = boundingBox;
    }

    // Проверка пересечения луча с коллайдером
    public bool RayIntersects(Ray ray, out float distance)
    {
        distance = 0;
        return RayIntersectsAABB(ray, BoundingBox, out distance);
    }
}