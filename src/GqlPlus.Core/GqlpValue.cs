namespace GqlPlus;

public interface IGqlpValue
{
  string Tag { get; }
  bool IsEmpty();
}

public abstract class GqlpValue(string? tag = null)
  : IGqlpValue
{
  public string Tag { get; } = tag ?? "";

  public override bool Equals(object? obj)
    => obj is GqlpValue other
      && GetType() == other.GetType()
      && string.Equals(Tag, other.Tag, StringComparison.Ordinal)
      && ValueEquals(other);

  public override int GetHashCode()
    => Combine(GetType().GetHashCode(), StringComparer.Ordinal.GetHashCode(Tag), ValueHash());

  protected static int Combine(params int[] hashes)
    => hashes.Aggregate(17, (h, v) => unchecked((h * 31) + v));

  protected virtual bool ValueEquals(GqlpValue other) => true;
  protected virtual int ValueHash() => 0;
  public virtual bool IsEmpty() => true;
}

public sealed class GqlpNull(string? tag = null)
  : GqlpValue(tag ?? "Null");

public sealed class GqlpVoid(string? tag = null)
  : GqlpValue(tag ?? "Void");
