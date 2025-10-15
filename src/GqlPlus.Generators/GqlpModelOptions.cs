
namespace GqlPlus;

public sealed class GqlpModelOptions(string baseNamespace, string typePrefix)
  : IEquatable<GqlpModelOptions>
{
  public string BaseNamespace { get; } = baseNamespace;
  public string TypePrefix { get; } = typePrefix;

  public bool Equals(GqlpModelOptions other)
    => BaseNamespace.Equals(other?.BaseNamespace, StringComparison.Ordinal)
    && TypePrefix.Equals(other?.TypePrefix, StringComparison.Ordinal);

  public override bool Equals(object obj)
    => obj is GqlpModelOptions options
    ? Equals(options)
    : base.Equals(obj);
  public override int GetHashCode()
    => HashCode.Combine(BaseNamespace, TypePrefix);
}
