//HintName: BuildDataAttribute.g.cs

namespace GqlPlus;

[System.AttributeUsage(System.AttributeTargets.All, Inherited = false, AllowMultiple = true)]
public sealed class BuildDataAttribute(string segment) : Attribute
{
  public string Segment { get; } = segment;
}
