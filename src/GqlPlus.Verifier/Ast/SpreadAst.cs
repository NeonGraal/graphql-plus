namespace GqlPlus.Verifier.Ast;

internal sealed record class SpreadAst(string Name)
  : NamedDirectivesAst(Name), SelectionAst, IEquatable<SpreadAst>
{
  public bool Equals(SpreadAst? other)
    => base.Equals(other);
  public override int GetHashCode()
    => base.GetHashCode();
}
