using System.Numerics;
using Jitter2.Collision.Shapes;
using Sparkle.CSharp.Entities;
using Sparkle.CSharp.Entities.Components;

namespace Sparkle_Editor.Code.Entities.Primitives;

public class Cylinder : Entity
{
    public Cylinder(Vector3 position) : base(position) { }

    protected override void Init()
    {
        base.Init();
        
        AddComponent(new ModelRenderer(ContentRegistry.Models["Cylinder"], Vector3.Zero));
        //AddComponent(new RigidBody3D(new BoxShape(1f)));
    }
}