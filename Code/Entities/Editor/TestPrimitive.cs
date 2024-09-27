using System.Numerics;
using Sparkle.CSharp.Entities;
using Sparkle.CSharp.Entities.Components;

namespace Sparkle_Editor.Code.Entities.Editor;

public class TestPrimitive : Entity
{
    public TestPrimitive(Vector3 Position) : base(Position)
    {
        
    }

    protected override void Init()
    {
        base.Init();
        
        AddComponent(new ModelRenderer(ContentRegistry.Models["Cube"], Vector3.Zero));
    }
}