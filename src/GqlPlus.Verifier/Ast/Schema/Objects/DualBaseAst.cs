using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

public sealed record class DualBaseAst(
  TokenAt At,
  string Name,
  string Description
) : AstObjectBase<DualBaseAst>(At, Name, Description)
  , IEquatable<DualBaseAst>
{
  public DualBaseAst(TokenAt at, string name)
    : this(at, name, "") { }

  internal override string Abbr => "DR";
  public override string Label => "Dual";

  public override bool Equals(DualBaseAst? other)
    => base.Equals(other);
  public override int GetHashCode()
    => base.GetHashCode();
}
