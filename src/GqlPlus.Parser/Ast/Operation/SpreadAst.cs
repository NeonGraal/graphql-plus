namespace GqlPlus.Ast.Operation;

internal sealed record class SpreadAst(
  ITokenAt At,
  string Identifier
) : AstModifiers(At, Identifier)
  , IAstSpread
{
  internal override string Abbr => "s";

  public bool Equals(SpreadAst? other)
    => other is IAstOpSpread spread && Equals(spread);
  public bool Equals(IAstSpread? other)
    => Equals(other as IAstOpSpread);
  public bool Equals(IAstOpSpread? other)
    => base.Equals(other);
  public override int GetHashCode()
    => base.GetHashCode();
}
