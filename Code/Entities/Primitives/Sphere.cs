using System.Numerics;
using Jitter2.Collision.Shapes;
using Sparkle.CSharp.Entities;
using Sparkle.CSharp.Entities.Components;

namespace Sparkle_Editor.Code.Entities.Primitives;

public class Sphere : Entity
{
    public Sphere(Vector3 position) : base(position) { }

    protected override void Init()
    {
        base.Init();
        
        AddComponent(new ModelRenderer(ContentRegistry.Models["Sphere"], Vector3.Zero));
        //AddComponent(new RigidBody3D(new BoxShape(1f)));
    }
}