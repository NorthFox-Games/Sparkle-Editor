using Raylib_CSharp.Geometry;
using Sparkle.CSharp.Content;
using Sparkle.CSharp.Content.Types;
using Sparkle.CSharp.Registries;

namespace Sparkle_Editor.Code;

public class ContentRegistry : Registry
{
    public static Dictionary<string, Model> Models = new();
    
    protected override void Load(ContentManager content)
    {
        base.Load(content);
        
        Models.Add("Cube", content.Load(new ModelContent("Models/Primitives/Cube.glb")));
        //[Raylib_CSharp.Logging.Logger :: TraceLogCallback] FILEIO: [Models/Primitives/Cube.glb] Failed to open file
        //[Raylib_CSharp.Logging.Logger :: TraceLogCallback] MESH: [Models/Primitives/Cube.glb] Failed to load model mesh(es) data
        //[Raylib_CSharp.Logging.Logger :: TraceLogCallback] MATERIAL: [Models/Primitives/Cube.glb] Failed to load model material data, default to white material
    }
}