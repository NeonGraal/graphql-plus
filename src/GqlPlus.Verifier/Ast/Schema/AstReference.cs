using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public abstract record class AstReference<TReference>(TokenAt At, string Name, string Description)
  : AstDescribed(At, Name, Description), IEquatable<TReference>
  where TReference : AstReference<TReference>
{
  public bool IsTypeParameter { get; set; }
  public TReference[] Arguments { get; set; } = [];

  public string FullType => Arguments
    .Bracket("<", ">")
    .Prepend(IsTypeParameter ? Name.Prefixed("$") : Name)
    .Joined();

  protected AstReference(TokenAt at, string name)
    : this(at, name, "") { }

  public virtual bool Equals(TReference? other)
    => base.Equals(other)
    && IsTypeParameter == other.IsTypeParameter
    && Arguments.SequenceEqual(other.Arguments);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), IsTypeParameter, Arguments.Length);

  internal override IEnumerable<string?> GetFields()
    => new[] {
      At.ToString(),
      IsTypeParameter ? Name.Prefixed("$") : Name
    }.Concat(Arguments.Bracket("<", ">"));
}
