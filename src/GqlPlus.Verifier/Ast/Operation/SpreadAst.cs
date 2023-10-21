namespace GqlPlus.Verifier.Ast.Operation;

internal sealed record class SpreadAst(ParseAt At, string Name)
  : AstDirectives(At, Name), IAstSelection, IEquatable<SpreadAst>
{
  internal override string Abbr => "s";

  public bool Equals(SpreadAst? other)
    => base.Equals(other);
  public override int GetHashCode()
    => base.GetHashCode();
}
