namespace GqlPlus.Verifier.Ast;

internal sealed record class SpreadAst(string Name)
  : AstNamedDirectives(Name), AstSelection, IEquatable<SpreadAst>
{
  protected override string Abbr => "S";

  public bool Equals(SpreadAst? other)
    => base.Equals(other);
  public override int GetHashCode()
    => base.GetHashCode();
}
