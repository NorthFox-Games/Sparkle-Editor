using System.Numerics;
using Sparkle.CSharp.Entities;
using Sparkle.CSharp.Entities.Components;

namespace Sparkle_Editor.Code.Entities.Primitives;

public class Cube : Entity
{
    public Cube(Vector3 position) : base(position) { }

    protected override void Init()
    {
        base.Init();
        
        ModelRenderer modelRenderer = new ModelRenderer(ContentRegistry.Models["Cube"], Vector3.Zero);
        AddComponent(modelRenderer);
    }
}