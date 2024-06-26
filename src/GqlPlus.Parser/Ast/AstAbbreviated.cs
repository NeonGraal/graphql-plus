using GqlPlus.Token;

namespace GqlPlus.Ast;

internal abstract record class AstAbbreviated(TokenAt At)
  : AstBase(At)
  , IEquatable<AstAbbreviated>
  , IGqlpAbbreviated
{
  internal abstract string Abbr { get; }

  public sealed override string ToString()
    => "( "
      + GetFields().Cast<string>().Joined()
      + " )";

  protected string AbbrAt
    => new[] { "!" + Abbr, At.ToString() }.Joined();

  internal virtual IEnumerable<string?> GetFields()
    => [AbbrAt];

  // override object.Equals
  public virtual bool Equals(AstAbbreviated? other)
    => other is not null;

  // override object.GetHashCode
  public override int GetHashCode() => 0;

  ITokenAt IGqlpAbbreviated.At => At;

  IEnumerable<string?> IGqlpAbbreviated.GetFields() => GetFields();
  string IGqlpAbbreviated.Abbr => Abbr;
}
