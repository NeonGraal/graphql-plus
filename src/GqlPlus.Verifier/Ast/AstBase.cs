namespace GqlPlus.Verifier.Ast;

internal abstract record class AstBase : IEquatable<AstBase>
{
  protected abstract string Abbr { get; }

  public ParseAt At { get; }

  internal AstBase(ParseAt loc)
    => At = loc;

  public sealed override string ToString()
    => Abbr + "("
      + string.Join(" ", GetFields().Where(s => s?.Length > 0))
      + ")";

  internal virtual IEnumerable<string?> GetFields()
    => Array.Empty<string?>();

  internal ParseError Error(string message)
    => new(At, message);
  // override object.Equals
  public virtual bool Equals(AstBase? other) =>
    //var before = base.Equals(other);
    true;

  // override object.GetHashCode
  public override int GetHashCode() =>
    //return base.GetHashCode();
    0;
}

