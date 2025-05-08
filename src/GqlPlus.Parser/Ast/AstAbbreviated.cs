namespace GqlPlus.Ast;

internal abstract record class AstAbbreviated(ITokenAt At)
  : AstBase(At)
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
    => other is IGqlpAbbreviated abbr && Equals(abbr);
  public bool Equals(IGqlpAbbreviated? other)
    => other is not null;
  // && Abbr == other.Abbr

  // override object.GetHashCode
  public override int GetHashCode() => 0;

  ITokenAt IGqlpAbbreviated.At => At;

  IEnumerable<string?> IGqlpAbbreviated.GetFields() => GetFields();
  string IGqlpAbbreviated.Abbr => Abbr;
}
