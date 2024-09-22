﻿using System.Numerics;
using Raylib_CSharp.Collision;
using Raylib_CSharp.Interact;
using Sparkle.CSharp.Entities;
using Sparkle.CSharp.Scenes;

namespace Sparkle_Editor.Code;

public static class Phisycs
{
    private const int Range = 8;
    
    public static bool Raycast(out Entity hit)
    {
        hit = null;
        
        Vector2 mousePosition = Input.GetMousePosition();

        // get ray of camera
        Ray mouseRay = SceneManager.ActiveCam3D.GetMouseRay(mousePosition);

        // foreach all entities on scene
        foreach (Entity entity in SceneManager.ActiveScene.GetEntities())
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
                    hit = entity;
                    return true;
                }
            }
        }
        
        return false;
    }
    
    /// <summary>
    /// Check entity in camera range or not
    /// </summary>
    public static bool IsEntityInCameraRange(Entity entity, float range)
    {
        Vector3 entityPosition = entity.Position; // get 3D pos entity
        Vector3 cameraPosition = SceneManager.ActiveCam3D.Position;

        // Calculate the distance between the camera and the entity
        float distance = Vector3.Distance(entityPosition, cameraPosition);

        // Check if the entity is within the specified range
        return distance <= range;
    }

    /// <summary>
    /// Checking ray intersection with AABB (axis-aligned bounding box)
    /// </summary>
    public static bool RayIntersectsAABB(Ray ray, Vector3 minBounds, Vector3 maxBounds)
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