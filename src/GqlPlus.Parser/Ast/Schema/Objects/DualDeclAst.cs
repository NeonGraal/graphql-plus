using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class DualDeclAst(
  ITokenAt At,
  string Name,
  string Description
) : AstObject<IGqlpDualField>(At, Name, Description)
  , IGqlpDualObject
{
  internal override string Abbr => "Du";
  public override string Label => "Dual";

  public DualDeclAst(TokenAt at, string name)
    : this(at, name, "")
  { }
}
