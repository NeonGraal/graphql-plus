using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

public sealed record class DualBaseAst(
  TokenAt At,
  string Name,
  string Description
) : AstObjectBase<DualBaseAst>(At, Name, Description)
  , IEquatable<DualBaseAst>
  , IGqlpDualBase
{
  public DualBaseAst(TokenAt at, string name)
    : this(at, name, "") { }

  internal override string Abbr => "DR";
  public override string Label => "Dual";

  string IGqlpDualBase.Dual => Name;
  IEnumerable<IGqlpDualBase> IGqlpObjectBase<IGqlpDualBase>.TypeArguments => TypeArguments;

  public override bool Equals(DualBaseAst? other)
    => base.Equals(other);
  public override int GetHashCode()
    => base.GetHashCode();
  bool IEquatable<IGqlpDualBase>.Equals(IGqlpDualBase? other)
    => Equals(other);
}
