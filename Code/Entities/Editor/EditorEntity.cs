using System.Numerics;
using Raylib_CSharp.Geometry;
using Sparkle.CSharp.Entities;
using Sparkle.CSharp.Entities.Components;
using Sparkle.CSharp.Scenes;

namespace Sparkle_Editor.Code.Entities.Editor;

public class EditorEntity : Entity
{
    public ModelRenderer Model { get; }
    public string Name { get; }
    public EditorEntity Parent { get; }
    public List<EditorEntity> Childs { get; }

    public EditorEntity(string name, string tag, Vector3 position, EditorEntity parent = null, ModelRenderer model = null, Quaternion rotation = new(), Vector3 scale = new()) : base(position)
    {
        Name = name;
        Parent = parent;
        Model = model;
        base.Rotation = rotation;
        base.Scale = scale;
        base.Tag = tag;
    }

    protected override void Init()
    {
        base.Init();

        if (Model == null)
        {
            AddComponent(new ModelRenderer(ContentRegistry.Models["Empty"], Vector3.Zero));
        }
        else
        {
            AddComponent(Model);
        }
        
        //AddComponent(new CustomRigidbody3D(new BoxShape(1f), new Collider3D()));

        if (Parent != null)
        {
            Parent.Childs.Add(this);
        }
    }
}