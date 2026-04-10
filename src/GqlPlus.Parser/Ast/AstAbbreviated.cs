namespace GqlPlus.Ast;

internal abstract record class AstAbbreviated(ITokenAt At)
  : AstBase(At)
  , IAstAbbreviated
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

  public bool Equals(IAstAbbreviated? other)
    => other is not null;
  public override int GetHashCode() => 0;

  ITokenAt IAstAbbreviated.At => At;

  IEnumerable<string?> IAstAbbreviated.GetFields() => GetFields();
}
