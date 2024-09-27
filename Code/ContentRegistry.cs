using Raylib_CSharp.Geometry;
using Sparkle.CSharp.Content;
using Sparkle.CSharp.Content.Types;
using Sparkle.CSharp.Registries;

namespace Sparkle_Editor.Code;

public class ContentRegistry : Registry
{
    public static Dictionary<string, Model> Models = new ();
    
    protected override void Load(ContentManager content)
    {
        base.Load(content);
        
        // Load to RAM primitives models
        Models.Add("Cube", content.Load(new ModelContent("content/models/primitives/cube.glb")));
        Models.Add("Sphere", content.Load(new ModelContent("content/models/primitives/sphere.glb")));
        Models.Add("Cylinder", content.Load(new ModelContent("content/models/primitives/cylinder.glb")));
        Models.Add("Plane", content.Load(new ModelContent("content/models/primitives/plane.glb")));
        Models.Add("Cone", content.Load(new ModelContent("content/models/primitives/cone.glb")));
        
        // this is not primitive xd
        Models.Add("Gizmos", content.Load(new ModelContent("content/models/gizmos.glb")));
    }
}