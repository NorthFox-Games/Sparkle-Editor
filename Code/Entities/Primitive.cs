using System.Numerics;
using Sparkle_Editor.Code.Entities.Editor;
using Sparkle.CSharp.Entities.Components;

namespace Sparkle_Editor.Code.Entities;

public class Primitive : EditorEntity
{
    public Primitive(string name, Vector3 position, ModelRenderer model, Quaternion rotation = new(), Vector3 scale = new()) : base(name, "", position, null, model, rotation, scale) { }
}