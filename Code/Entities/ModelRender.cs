using System.Numerics;
using Raylib_CSharp.Geometry;
using Sparkle_Editor.Code.Interfaces;
using Sparkle.CSharp.Entities;
using Sparkle.CSharp.Entities.Components;

namespace Sparkle_Editor.Code.Entities;

public class ModelRender : Entity, IEntity
{
    private Model _model;
    public string Name { get; set; } = "ModelRender";

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