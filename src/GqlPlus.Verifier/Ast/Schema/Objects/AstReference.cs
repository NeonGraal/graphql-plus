using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema.Objects;

public abstract record class AstReference<TRef>(
  TokenAt At,
  string Name,
  string Description
) : AstDescribed(At, Name, Description), IEquatable<TRef>
  where TRef : AstReference<TRef>
{
  public bool IsTypeParameter { get; set; }
  public TRef[] Arguments { get; set; } = [];

  public abstract string Label { get; }

  public string FullName => IsTypeParameter ? Name.Prefixed("$") : Name;

  public string TypeName => IsTypeParameter ? "" : Name;

  public string FullType => Arguments
    .Bracket("<", ">")
    .Prepend(FullName)
    .Joined();

  public virtual bool Equals(TRef? other)
    => base.Equals(other)
    && IsTypeParameter == other.IsTypeParameter
    && Arguments.SequenceEqual(other.Arguments);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), IsTypeParameter, Arguments.Length);

  internal override IEnumerable<string?> GetFields()
    => new[] {
      At.ToString(),
      FullName
    }.Concat(Arguments.Bracket("<", ">"));
}
