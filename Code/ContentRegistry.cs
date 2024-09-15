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
        
        // Load to RAM model (Cube)
        Models.Add("Cube", content.Load(new ModelContent("content/models/primitives/cube.glb")));
    }
}