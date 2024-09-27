using System.Numerics;
using Sparkle.CSharp.Entities;
using Sparkle.CSharp.Entities.Components;

namespace Sparkle_Editor.Code.Entities;

public class Gizmos : Entity
{
    public Gizmos(Vector3 position) : base(position) { }
    
    protected override void Init()
    {
        base.Init();
        
        AddComponent(new ModelRenderer(ContentRegistry.Models["Gizmos"], Vector3.Zero));
    }
}