namespace GqlPlus.Verifier.Ast;

internal abstract record class AstBase : IEquatable<AstBase>
{
  internal abstract string Abbr { get; }

  public ParseAt At { get; }

  internal AstBase(ParseAt loc)
    => At = loc;

  public sealed override string ToString()
    => "( "
      + string.Join(" ", GetFields().Where(s => s?.Length > 0))
      + " )";

  protected string AbbrAt
    => "!" + Abbr + At.ToString();

  internal virtual IEnumerable<string?> GetFields()
    => new[] { AbbrAt };

  internal ParseError Error(string message)
    => new(At, message);
  // override object.Equals
  public virtual bool Equals(AstBase? other)
    => other is not null;

  // override object.GetHashCode
  public override int GetHashCode() => 0;
}

