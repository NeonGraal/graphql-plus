using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class DualReferenceAst(
  TokenAt At,
  string Name,
  string Description
) : AstReference<DualReferenceAst>(At, Name, Description), IEquatable<DualReferenceAst>
{
  public DualReferenceAst(TokenAt at, string name)
    : this(at, name, "") { }

  internal override string Abbr => "DR";
  public override string Label => "Dual";

  public override bool Equals(DualReferenceAst? other)
    => base.Equals(other);
  public override int GetHashCode()
    => base.GetHashCode();
}
