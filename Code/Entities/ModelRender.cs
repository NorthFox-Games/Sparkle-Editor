using System.Numerics;
using Raylib_CSharp.Geometry;
using Sparkle.CSharp.Entities;
using Sparkle.CSharp.Entities.Components;

namespace Sparkle_Editor.Code.Entities;

public class ModelRender : Entity
{
    private Model _model;

    public ModelRender(Vector3 position, Model model) : base(position)
    {
        _model = model;
    }

    protected override void Init()
    {
        base.Init();
        
        AddComponent(new ModelRenderer(_model, Vector3.Zero));
        
        //AddComponent(new CustomRigidbody3D(new BoxShape(1f), new Collider3D()));
    }
}