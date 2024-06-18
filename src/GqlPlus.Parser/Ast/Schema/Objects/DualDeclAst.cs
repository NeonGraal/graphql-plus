using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

public sealed record class DualDeclAst(
  TokenAt At,
  string Name,
  string Description
) : AstObject<IGqlpDualField, IGqlpDualAlternate, IGqlpDualBase>(At, Name, Description)
  , IGqlpDualObject
{
  internal override string Abbr => "Du";
  public override string Label => "Dual";

  public DualDeclAst(TokenAt at, string name)
    : this(at, name, "")
  { }
}
