using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema.Objects;

public sealed record class DualDeclAst(
  TokenAt At,
  string Name,
  string Description
) : AstObject<DualFieldAst, DualReferenceAst>(At, Name, Description)
{
  internal override string Abbr => "D";
  public override string Label => "Dual";

  public DualDeclAst(TokenAt at, string name)
    : this(at, name, "")
  { }
}
