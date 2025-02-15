
namespace GqlPlus;

public sealed class GqlModelOptions(string baseNamespace)
  : IEquatable<GqlModelOptions>
{
  public string BaseNamespace { get; } = baseNamespace;

  public bool Equals(GqlModelOptions other)
    => BaseNamespace.Equals(other?.BaseNamespace, StringComparison.Ordinal);

  public override bool Equals(object obj)
    => obj is GqlModelOptions options
    ? Equals(options)
    : base.Equals(obj);
  public override int GetHashCode()
    => HashCode.Combine(BaseNamespace);
}
