using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public abstract record class AstReference<T>(TokenAt At, string Name, string Description)
  : AstDescribed(At, Name, Description), IEquatable<T>
  where T : AstReference<T>
{
  public bool IsTypeParameter { get; set; }
  public T[] Arguments { get; set; } = Array.Empty<T>();

  protected AstReference(TokenAt at, string name)
    : this(at, name, "") { }

  public virtual bool Equals(T? other)
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
