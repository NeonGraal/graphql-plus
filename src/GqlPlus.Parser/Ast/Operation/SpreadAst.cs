namespace GqlPlus.Ast.Operation;

internal sealed record class SpreadAst(
  ITokenAt At,
  string Identifier
) : AstModifiers(At, Identifier)
  , IAstSpread
{
  internal override string Abbr => "s";

  public bool Equals(SpreadAst? other)
    => other is IAstSpread spread && Equals(spread);
  public bool Equals(IAstSpread? other)
    => base.Equals(other);
  public override int GetHashCode()
    => base.GetHashCode();
}
