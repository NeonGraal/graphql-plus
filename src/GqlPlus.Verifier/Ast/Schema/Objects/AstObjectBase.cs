using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema.Objects;

public abstract record class AstObjectBase<TObjBase>(
  TokenAt At,
  string Name,
  string Description
) : AstDescribed(At, Name, Description)
  , IEquatable<TObjBase>
  where TObjBase : AstObjectBase<TObjBase>
{
  public bool IsTypeParameter { get; set; }
  public TObjBase[] Arguments { get; set; } = [];

  public abstract string Label { get; }

  public string FullName => IsTypeParameter ? Name.Prefixed("$") : Name;

  public string TypeName => IsTypeParameter ? "" : Name;

  public string FullType => Arguments
    .Bracket("<", ">")
    .Prepend(FullName)
    .Joined();

  public virtual bool Equals(TObjBase? other)
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
