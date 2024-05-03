using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

public sealed record class DualDeclAst(
  TokenAt At,
  string Name,
  string Description
) : AstObject<DualFieldAst, DualBaseAst>(At, Name, Description)
{
  internal override string Abbr => "Du";
  public override string Label => "Dual";

  public DualDeclAst(TokenAt at, string name)
    : this(at, name, "")
  { }
}
