using System.Numerics;
using Sparkle_Editor.Code.Interfaces;
using Sparkle.CSharp.Entities;
using Sparkle.CSharp.Entities.Components;

namespace Sparkle_Editor.Code.Entities;

public class Gizmos : Entity, IEntity
{
    public Gizmos(Vector3 position) : base(position) { }

    public string Name { get; set; } = "Gizmos";
    
    protected override void Init()
    {
        base.Init();
        
        AddComponent(new ModelRenderer(ContentRegistry.Models["Gizmos"], Vector3.Zero));
    }
}