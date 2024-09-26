using System.Numerics;
using Sparkle.CSharp.Entities.Components;

namespace Sparkle_Editor.Code.Entities.Editor;

public class Gizmos : EditorEntity
{
    public Gizmos(Vector3 position) : base("Gizmos", "", position, null, new ModelRenderer(ContentRegistry.Models["Gizmos"], Vector3.Zero)) { }
}