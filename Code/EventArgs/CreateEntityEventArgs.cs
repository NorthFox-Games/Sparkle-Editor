using System.Numerics;
using Sparkle.CSharp.Entities;
namespace Sparkle_Editor.Code.EventArgs;

public class CreateEntityEventArgs(Entity entity) : System.EventArgs
{
    public Entity Entity { get; } = entity;
}